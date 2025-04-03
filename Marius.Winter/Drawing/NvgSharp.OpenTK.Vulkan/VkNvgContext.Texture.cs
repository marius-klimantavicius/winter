using System;
using System.Buffers;
using System.Diagnostics;
using OpenTK.Graphics.Vulkan;

namespace NvgSharp.OpenTK.Vulkan;

internal unsafe partial class VkNvgContext
{
    public VkNvgTexture CreateTexture(int w, int h)
    {
        var tex = AllocTexture();

        var device = CreateInfo.Device;
        var allocator = CreateInfo.Allocator;

        var imageCreateInfo = new VkImageCreateInfo
        {
            sType = VkStructureType.StructureTypeImageCreateInfo,
            pNext = null,
            imageType = VkImageType.ImageType2d,
            format = VkFormat.FormatR8g8b8a8Unorm,
        };

        imageCreateInfo.extent.width = (uint)w;
        imageCreateInfo.extent.height = (uint)h;
        imageCreateInfo.extent.depth = 1;
        imageCreateInfo.mipLevels = 1;
        imageCreateInfo.arrayLayers = 1;
        imageCreateInfo.samples = VkSampleCountFlagBits.SampleCount1Bit;
        imageCreateInfo.tiling = VkImageTiling.ImageTilingLinear;
        imageCreateInfo.initialLayout = VkImageLayout.ImageLayoutPreinitialized;
        imageCreateInfo.usage = VkImageUsageFlagBits.ImageUsageSampledBit;
        imageCreateInfo.queueFamilyIndexCount = 0;
        imageCreateInfo.pQueueFamilyIndices = null;
        imageCreateInfo.sharingMode = VkSharingMode.SharingModeExclusive;
        imageCreateInfo.flags = 0;

        var memoryAllocateInfo = new VkMemoryAllocateInfo
        {
            sType = VkStructureType.StructureTypeMemoryAllocateInfo,
            allocationSize = 0,
        };

        VkImage mappableImage;
        VkDeviceMemory mappableMemory;

        CheckResult(Vk.CreateImage(device, &imageCreateInfo, allocator, &mappableImage));

        VkMemoryRequirements mem_reqs;
        Vk.GetImageMemoryRequirements(device, mappableImage, &mem_reqs);

        memoryAllocateInfo.allocationSize = mem_reqs.size;

        var flags = VkMemoryPropertyFlagBits.MemoryPropertyDeviceLocalBit | VkMemoryPropertyFlagBits.MemoryPropertyHostVisibleBit;
        var res = GetMemoryTypeFromProperties(DeviceMemoryProperties, mem_reqs.memoryTypeBits, flags, out memoryAllocateInfo.memoryTypeIndex);
        Debug.Assert(res == VkResult.Success);

        CheckResult(Vk.AllocateMemory(device, &memoryAllocateInfo, allocator, &mappableMemory));

        CheckResult(Vk.BindImageMemory(device, mappableImage, mappableMemory, 0));

        var samplerCreateInfo = new VkSamplerCreateInfo
        {
            sType = VkStructureType.StructureTypeSamplerCreateInfo,
            magFilter = VkFilter.FilterLinear,
            minFilter = VkFilter.FilterLinear,
            mipmapMode = VkSamplerMipmapMode.SamplerMipmapModeNearest,
            addressModeU = VkSamplerAddressMode.SamplerAddressModeClampToEdge,
            addressModeV = VkSamplerAddressMode.SamplerAddressModeClampToEdge,
            addressModeW = VkSamplerAddressMode.SamplerAddressModeClampToEdge,
            mipLodBias = 0.0f,
            anisotropyEnable = 0,
            maxAnisotropy = 1,
            compareEnable = 0,
            compareOp = VkCompareOp.CompareOpNever,
            minLod = 0.0f,
            maxLod = 0.0f,
            borderColor = VkBorderColor.BorderColorFloatOpaqueWhite,
        };

        /* create Sampler */
        fixed (VkSampler* sampler = &tex.Sampler)
            CheckResult(Vk.CreateSampler(device, &samplerCreateInfo, allocator, sampler));

        var viewInfo = new VkImageViewCreateInfo
        {
            sType = VkStructureType.StructureTypeImageViewCreateInfo,
            pNext = null,
            image = mappableImage,
            viewType = VkImageViewType.ImageViewType2d,
            format = imageCreateInfo.format,
        };
        viewInfo.components.r = VkComponentSwizzle.ComponentSwizzleR;
        viewInfo.components.g = VkComponentSwizzle.ComponentSwizzleG;
        viewInfo.components.b = VkComponentSwizzle.ComponentSwizzleB;
        viewInfo.components.a = VkComponentSwizzle.ComponentSwizzleA;
        viewInfo.subresourceRange.aspectMask = VkImageAspectFlagBits.ImageAspectColorBit;
        viewInfo.subresourceRange.baseMipLevel = 0;
        viewInfo.subresourceRange.levelCount = 1;
        viewInfo.subresourceRange.baseArrayLayer = 0;
        viewInfo.subresourceRange.layerCount = 1;

        var imageView = default(VkImageView);
        CheckResult(Vk.CreateImageView(device, &viewInfo, allocator, &imageView));

        tex.Height = h;
        tex.Width = w;
        tex.Image = mappableImage;
        tex.ImageView = imageView;
        tex.DeviceMemory = mappableMemory;
        tex.ImageLayout = VkImageLayout.ImageLayoutShaderReadOnlyOptimal;

        var textureFormat = 4;
        var textureSize = w * h * textureFormat;

        var generatedTexture = ArrayPool<byte>.Shared.Rent(textureSize);
        generatedTexture.AsSpan().Clear();

        UpdateTexture(device, tex, 0, 0, w, h, generatedTexture);

        ArrayPool<byte>.Shared.Return(generatedTexture);

        var currentFrame = FrameBuffer.CurrentFrame;
        InitTexture(CreateInfo.SecondaryCommandBuffer[currentFrame], Queue, tex);

        return tex;
    }

    public static int DeleteTexture(VkNvgTexture? tex, VkDevice device, VkAllocationCallbacks* allocator)
    {
        if (tex != null)
        {
            if (tex.IsMapped)
            {
                Vk.UnmapMemory(device, tex.DeviceMemory);
                tex.IsMapped = false;
            }

            if (tex.ImageView != VkImageView.Zero)
            {
                Vk.DestroyImageView(device, tex.ImageView, allocator);
                tex.ImageView = VkImageView.Zero;
            }

            if (tex.Sampler != VkSampler.Zero)
            {
                Vk.DestroySampler(device, tex.Sampler, allocator);
                tex.Sampler = VkSampler.Zero;
            }

            if (tex.Image != VkImage.Zero)
            {
                Vk.DestroyImage(device, tex.Image, allocator);
                tex.Image = VkImage.Zero;
            }

            if (tex.DeviceMemory != VkDeviceMemory.Zero)
            {
                Vk.FreeMemory(device, tex.DeviceMemory, allocator);
                tex.DeviceMemory = VkDeviceMemory.Zero;
            }

            return 1;
        }

        return 0;
    }

    public void UpdateTexture(VkNvgTexture tex, int x, int y, int w, int h, byte[] data)
    {
        UpdateTexture(CreateInfo.Device, tex, x, y, w, h, data);
    }

    public void GetTextureSize(VkNvgTexture tex, out int w, out int h)
    {
        w = tex.Width;
        h = tex.Height;
    }

    private VkNvgTexture AllocTexture()
    {
        for (var i = 0; i < Textures.Count; i++)
        {
            if (Textures[i].Image == VkImage.Zero)
                return Textures[i];
        }

        var result = new VkNvgTexture(CreateInfo.Device, CreateInfo.Allocator);
        Textures.Add(result);
        return result;
    }

    private static void UpdateTexture(VkDevice device, VkNvgTexture tex, int dx, int dy, int w, int h, byte[] data)
    {
        if (!tex.IsMapped)
        {
            var memoryRequirements = new VkMemoryRequirements();
            Vk.GetImageMemoryRequirements(device, tex.Image, &memoryRequirements);
            var mappedMemory = default(void*);
            CheckResult(Vk.MapMemory(device, tex.DeviceMemory, 0, memoryRequirements.size, 0, &mappedMemory));
            tex.MappedMemory = mappedMemory;
            tex.IsMapped = true;

            var imageSubresource = new VkImageSubresource { aspectMask = VkImageAspectFlagBits.ImageAspectColorBit, arrayLayer = 0, mipLevel = 0 };
            VkSubresourceLayout layout;
            Vk.GetImageSubresourceLayout(device, tex.Image, &imageSubresource, &layout);
            tex.RowPitch = layout.rowPitch;
        }

        var compSize = 4;
        var rowLength = w * compSize;
        for (var y = 0; y < h; ++y)
        {
            var dest = new Span<byte>((byte*)tex.MappedMemory + (dy + y) * (nint)tex.RowPitch + dx * compSize, rowLength);
            data.AsSpan(y * rowLength, rowLength).CopyTo(dest);
        }
    }

    // call it after UpdateTexture
    private static void InitTexture(VkCommandBuffer cmdbuffer, VkQueue queue, VkNvgTexture tex)
    {
        var beginInfo = new VkCommandBufferBeginInfo
        {
            sType = VkStructureType.StructureTypeCommandBufferBeginInfo,
            flags = VkCommandBufferUsageFlagBits.CommandBufferUsageOneTimeSubmitBit,
        };

        Vk.BeginCommandBuffer(cmdbuffer, &beginInfo);

        var layoutTransitionBarrier = new VkImageMemoryBarrier
        {
            sType = VkStructureType.StructureTypeImageMemoryBarrier,
            srcAccessMask = 0,
            dstAccessMask = 0,
            oldLayout = VkImageLayout.ImageLayoutPreinitialized,
            newLayout = VkImageLayout.ImageLayoutShaderReadOnlyOptimal,
            srcQueueFamilyIndex = Vk.QueueFamilyIgnored,
            dstQueueFamilyIndex = Vk.QueueFamilyIgnored,
            image = tex.Image,
        };

        var resourceRange = new VkImageSubresourceRange
        {
            aspectMask = VkImageAspectFlagBits.ImageAspectColorBit,
            baseMipLevel = 0,
            levelCount = 1,
            baseArrayLayer = 0,
            layerCount = 1,
        };
        layoutTransitionBarrier.subresourceRange = resourceRange;

        Vk.CmdPipelineBarrier(cmdbuffer, VkPipelineStageFlagBits.PipelineStageTopOfPipeBit, VkPipelineStageFlagBits.PipelineStageTopOfPipeBit, 0, 0, null, 0, null, 1, &layoutTransitionBarrier);

        Vk.EndCommandBuffer(cmdbuffer);

        var waitStageMash = VkPipelineStageFlagBits.PipelineStageColorAttachmentOutputBit;
        var submitInfo = new VkSubmitInfo
        {
            sType = VkStructureType.StructureTypeSubmitInfo,
            waitSemaphoreCount = 0,
            pWaitSemaphores = null,
            pWaitDstStageMask = &waitStageMash,
            commandBufferCount = 1,
            pCommandBuffers = &cmdbuffer,
            signalSemaphoreCount = 0,
            pSignalSemaphores = null,
        };

        Vk.QueueSubmit(queue, 1, &submitInfo, VkFence.Zero);
        Vk.QueueWaitIdle(queue);
        Vk.ResetCommandBuffer(cmdbuffer, 0);
        tex.ImageLayout = VkImageLayout.ImageLayoutShaderReadOnlyOptimal;
    }
}