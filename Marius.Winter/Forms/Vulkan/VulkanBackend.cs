using System;
using System.Diagnostics;
using NvgSharp;
using NvgSharp.OpenTK.Vulkan;
using OpenTK.Graphics.Vulkan;
using OpenTK.Mathematics;
using OpenTK.Platform;

namespace Marius.Winter.Forms.Vulkan;

internal unsafe class VulkanBackend : Backend
{
    private readonly VulkanDevice _device;

    private readonly VkSurfaceKHR _surface;
    private readonly VkCommandBuffer[] _commandBuffer;
    private readonly VkCommandBuffer[] _secondaryCommandBuffer;
    private readonly VkQueue _executionQueue;
    private readonly VkQueue _presentQueue;

    private readonly VulkanRenderer _renderer;

    private VulkanFrameBuffers _frameBuffers;
    private Vector2i _size;
    private bool _isResize;

    public override WindowHandle NativeWindow { get; }
    public override NvgContext Context { get; }

    public VulkanBackend(WindowHandle window, VulkanDevice device, VkSurfaceKHR surface, VkQueue executionQueue, VkQueue presentQueue, VulkanExtensions ext)
    {
        NativeWindow = window;

        _device = device;
        _surface = surface;
        _executionQueue = executionQueue;
        _presentQueue = presentQueue;

        _frameBuffers = CreateFrameBuffers(device, surface, executionQueue, 800, 600, VkSwapchainKHR.Zero);
        _commandBuffer = CreateCommandBuffers(device.Device, device.CommandPool, _frameBuffers.SwapchainCount);
        _secondaryCommandBuffer = CreateCommandBuffers(device.Device, device.CommandPool, _frameBuffers.SwapchainCount);

        var createInfo = new VulkanCreateInfo
        {
            Device = device.Device,
            PhysicalDevice = device.PhysicalDevice,
            CommandBuffer = _commandBuffer,
            SecondaryCommandBuffer = _secondaryCommandBuffer,
            Extensions = ext,
        };

        _renderer = new VulkanRenderer(createInfo, new VulkanFrameBuffer(this), executionQueue);
        Context = new NvgContext(_renderer);
    }

    public override void PrepareFrame(Color4<Rgba> backgroundColor)
    {
        var isResize = false;
        do
        {
            Toolkit.Window.GetFramebufferSize(NativeWindow, out var size);
            if (_isResize || size != _size)
            {
                _isResize = false;
                _size = size;

                Vk.DeviceWaitIdle(_device.Device);
                DestroyFrameBuffers(_device, ref _frameBuffers, _executionQueue);
                _frameBuffers = CreateFrameBuffers(_device, _surface, _executionQueue, size.X, size.Y, VkSwapchainKHR.Zero);
                _renderer.Viewport(size.X, size.Y);
            }

            PrepareFrame(backgroundColor, ref isResize);

        } while (isResize);
    }

    public override void SubmitFrame()
    {
        SubmitFrame(_device.Device, _executionQueue, _presentQueue, _commandBuffer[_frameBuffers.CurrentFrame], ref _frameBuffers, ref _isResize);
    }

    private void PrepareFrame(Color4<Rgba> backgroundColor, ref bool isResize)
    {
        var device = _device.Device;
        var commandBuffer = _commandBuffer[_frameBuffers.CurrentFrame];
        ref var fb = ref _frameBuffers;
        
        VkResult res;

        // Get the index of the next available swapchain image:
        fixed (uint* ptr = &fb.CurrentFrameBuffer)
            res = Vk.AcquireNextImageKHR(device, fb.Swapchain, ulong.MaxValue, fb.PresentCompleteSemaphore[fb.CurrentFrame], VkFence.Zero, ptr);

        if (res == VkResult.ErrorOutOfDateKhr)
        {
            Vk.QueueWaitIdle(_executionQueue);
            Vk.QueueWaitIdle(_presentQueue);
            
            isResize = true;
            return;
        }

        _renderer.BeforeRender();
        
        var beginInfo = new VkCommandBufferBeginInfo { sType = VkStructureType.StructureTypeCommandBufferBeginInfo };
        Vk.BeginCommandBuffer(commandBuffer, &beginInfo);

        var clearValues = stackalloc VkClearValue[2];
        clearValues[0].color.float32[0] = backgroundColor.X;
        clearValues[0].color.float32[1] = backgroundColor.Y;
        clearValues[0].color.float32[2] = backgroundColor.Z;
        clearValues[0].color.float32[3] = backgroundColor.W;
        clearValues[1].depthStencil.depth = 1.0f;
        clearValues[1].depthStencil.stencil = 0;

        var renderPassBeginInfo = new VkRenderPassBeginInfo
        {
            sType = VkStructureType.StructureTypeRenderPassBeginInfo,
            pNext = null,
            renderPass = fb.RenderPass,
            framebuffer = fb.Framebuffers[fb.CurrentFrameBuffer],
        };
        renderPassBeginInfo.renderArea.offset.x = 0;
        renderPassBeginInfo.renderArea.offset.y = 0;
        renderPassBeginInfo.renderArea.extent.width = fb.BufferSize.width;
        renderPassBeginInfo.renderArea.extent.height = fb.BufferSize.height;
        renderPassBeginInfo.clearValueCount = 2;
        renderPassBeginInfo.pClearValues = clearValues;

        Vk.CmdBeginRenderPass(commandBuffer, &renderPassBeginInfo, VkSubpassContents.SubpassContentsInline);

        VkViewport viewport;
        viewport.width = fb.BufferSize.width;
        viewport.height = fb.BufferSize.height;
        viewport.minDepth = 0.0f;
        viewport.maxDepth = 1.0f;
        viewport.x = renderPassBeginInfo.renderArea.offset.x;
        viewport.y = renderPassBeginInfo.renderArea.offset.y;
        Vk.CmdSetViewport(commandBuffer, 0, 1, &viewport);

        var scissor = renderPassBeginInfo.renderArea;
        Vk.CmdSetScissor(commandBuffer, 0, 1, &scissor);
    }

    private static void SubmitFrame(VkDevice device, VkQueue graphicsQueue, VkQueue presentQueue, VkCommandBuffer commandBuffer, ref VulkanFrameBuffers fb, ref bool isResize)
    {
        Vk.CmdEndRenderPass(commandBuffer);

        var imageBarrier = new VkImageMemoryBarrier
        {
            sType = VkStructureType.StructureTypeImageMemoryBarrier,
            srcAccessMask = VkAccessFlagBits.AccessColorAttachmentWriteBit,
            dstAccessMask = 0,
            oldLayout = VkImageLayout.ImageLayoutColorAttachmentOptimal,
            newLayout = VkImageLayout.ImageLayoutPresentSrcKhr,
            srcQueueFamilyIndex = Vk.QueueFamilyIgnored,
            dstQueueFamilyIndex = Vk.QueueFamilyIgnored,
            image = fb.SwapchainBuffers[fb.CurrentFrameBuffer].Image,
            subresourceRange = new VkImageSubresourceRange
            {
                aspectMask = VkImageAspectFlagBits.ImageAspectColorBit,
                baseMipLevel = 0,
                levelCount = 1,
                baseArrayLayer = 0,
                layerCount = 1,
            },
        };
        Vk.CmdPipelineBarrier(commandBuffer, VkPipelineStageFlagBits.PipelineStageColorAttachmentOutputBit, VkPipelineStageFlagBits.PipelineStageBottomOfPipeBit, 0, 0, null, 0, null, 1, &imageBarrier);

        Vk.EndCommandBuffer(commandBuffer);

        var pipelineStageFlags = VkPipelineStageFlagBits.PipelineStageColorAttachmentOutputBit;

        fixed (VkSemaphore* presentCompleteSemaphore = &fb.PresentCompleteSemaphore[fb.CurrentFrame])
        fixed (VkSemaphore* renderCompleteSemaphore = &fb.RenderCompleteSemaphore[fb.CurrentFrame])
        {
            var submitInfo = new VkSubmitInfo
            {
                sType = VkStructureType.StructureTypeSubmitInfo,
                pNext = null,
                waitSemaphoreCount = 1,
                pWaitSemaphores = presentCompleteSemaphore,
                pWaitDstStageMask = &pipelineStageFlags,
                commandBufferCount = 1,
                pCommandBuffers = &commandBuffer,
                signalSemaphoreCount = 1,
                pSignalSemaphores = renderCompleteSemaphore,
            };

            Vk.QueueSubmit(presentQueue, 1, &submitInfo, fb.FlightFence[fb.CurrentFrame]);
        }

        /* Now present the image in the window */

        fixed (VkSwapchainKHR* presentSwapchains = &fb.Swapchain)
        fixed (uint* presentImageIndices = &fb.CurrentFrameBuffer)
        fixed (VkSemaphore* presentWaitSemaphores = &fb.RenderCompleteSemaphore[fb.CurrentFrame])
        {
            var present = new VkPresentInfoKHR
            {
                sType = VkStructureType.StructureTypePresentInfoKhr,
                pNext = null,
                swapchainCount = 1,
                pSwapchains = presentSwapchains,
                pImageIndices = presentImageIndices,
                waitSemaphoreCount = 1,
                pWaitSemaphores = presentWaitSemaphores,
            };

            var res = Vk.QueuePresentKHR(presentQueue, &present);
            if (res == VkResult.ErrorOutOfDateKhr)
            {
                Vk.QueueWaitIdle(graphicsQueue);
                Vk.QueueWaitIdle(presentQueue);
                isResize = true;
                return;
            }

            fb.CurrentFrame = (fb.CurrentFrame + 1) % fb.SwapchainCount;
            fb.SwapCount++;

            if (fb.SwapCount >= fb.SwapchainCount)
            {
                fixed (VkFence* pFences = &fb.FlightFence[fb.CurrentFrame])
                {
                    Vk.WaitForFences(device, 1, pFences, 1, ulong.MaxValue);
                    Vk.ResetFences(device, 1, pFences);
                }
            }
        }
    }

    private static VkCommandBuffer[] CreateCommandBuffers(VkDevice device, VkCommandPool commandPool, uint commandBufferCount)
    {
        VkResult res;
        var cmd = new VkCommandBufferAllocateInfo
        {
            sType = VkStructureType.StructureTypeCommandBufferAllocateInfo,
            commandPool = commandPool,
            level = VkCommandBufferLevel.CommandBufferLevelPrimary,
            commandBufferCount = commandBufferCount,
        };

        var commandBuffers = new VkCommandBuffer[commandBufferCount];
        fixed (VkCommandBuffer* ptr = commandBuffers)
            res = Vk.AllocateCommandBuffers(device, &cmd, ptr);
        Debug.Assert(res == VkResult.Success);
        return commandBuffers;
    }

    private static bool GetMemoryTypeFromProperties(VkPhysicalDeviceMemoryProperties memoryProps, uint typeBits, VkMemoryPropertyFlagBits requirementsMask, ref uint typeIndex)
    {
        // Search memtypes to find first index with those properties
        for (var i = 0; i < memoryProps.memoryTypeCount; i++)
        {
            if ((typeBits & 1) == 1)
            {
                // Type is available, does it match user properties?
                if ((memoryProps.memoryTypes[i].propertyFlags & requirementsMask) == requirementsMask)
                {
                    typeIndex = (uint)i;
                    return true;
                }
            }

            typeBits >>= 1;
        }

        // No memory types matched, return failure
        return false;
    }

    private static VulkanDepthBuffer CreateDepthBuffer(in VulkanDevice device, uint width, uint height)
    {
        VulkanDepthBuffer depth;
        depth.Format = VkFormat.FormatD24UnormS8Uint;

        const int depthFormatCount = 3;
        var depthFormats = stackalloc VkFormat[depthFormatCount] { VkFormat.FormatD32SfloatS8Uint, VkFormat.FormatD24UnormS8Uint, VkFormat.FormatD16UnormS8Uint };
        var imageTilling = VkImageTiling.ImageTilingOptimal;
        for (var i = 0; i < depthFormatCount; i++)
        {
            VkFormatProperties formatProperties;
            Vk.GetPhysicalDeviceFormatProperties(device.PhysicalDevice, depthFormats[i], &formatProperties);

            if ((formatProperties.linearTilingFeatures & VkFormatFeatureFlagBits.FormatFeatureDepthStencilAttachmentBit) != 0)
            {
                depth.Format = depthFormats[i];
                imageTilling = VkImageTiling.ImageTilingLinear;
                break;
            }

            if ((formatProperties.optimalTilingFeatures & VkFormatFeatureFlagBits.FormatFeatureDepthStencilAttachmentBit) != 0)
            {
                depth.Format = depthFormats[i];
                imageTilling = VkImageTiling.ImageTilingOptimal;
                break;
            }

            if (i == depthFormatCount - 1)
                throw new Exception("Failed to find supported depth format!");
        }

        var depthFormat = depth.Format;

        var imageCreateInfo = new VkImageCreateInfo
        {
            sType = VkStructureType.StructureTypeImageCreateInfo,
            imageType = VkImageType.ImageType2d,
            format = depthFormat,
            tiling = imageTilling,
        };
        imageCreateInfo.extent.width = width;
        imageCreateInfo.extent.height = height;
        imageCreateInfo.extent.depth = 1;
        imageCreateInfo.mipLevels = 1;
        imageCreateInfo.arrayLayers = 1;
        imageCreateInfo.samples = VkSampleCountFlagBits.SampleCount1Bit;
        imageCreateInfo.initialLayout = VkImageLayout.ImageLayoutUndefined;
        imageCreateInfo.queueFamilyIndexCount = 0;
        imageCreateInfo.pQueueFamilyIndices = null;
        imageCreateInfo.sharingMode = VkSharingMode.SharingModeExclusive;
        imageCreateInfo.usage = VkImageUsageFlagBits.ImageUsageDepthStencilAttachmentBit;

        var memoryAllocateInfo = new VkMemoryAllocateInfo { sType = VkStructureType.StructureTypeMemoryAllocateInfo };

        var viewInfo = new VkImageViewCreateInfo
        {
            sType = VkStructureType.StructureTypeImageViewCreateInfo,
            format = depthFormat,
        };
        viewInfo.components.r = VkComponentSwizzle.ComponentSwizzleR;
        viewInfo.components.g = VkComponentSwizzle.ComponentSwizzleG;
        viewInfo.components.b = VkComponentSwizzle.ComponentSwizzleB;
        viewInfo.components.a = VkComponentSwizzle.ComponentSwizzleA;
        viewInfo.subresourceRange.aspectMask = VkImageAspectFlagBits.ImageAspectDepthBit;
        viewInfo.subresourceRange.baseMipLevel = 0;
        viewInfo.subresourceRange.levelCount = 1;
        viewInfo.subresourceRange.baseArrayLayer = 0;
        viewInfo.subresourceRange.layerCount = 1;
        viewInfo.viewType = VkImageViewType.ImageViewType2d;

        if (depthFormat == VkFormat.FormatD16UnormS8Uint || depthFormat == VkFormat.FormatD24UnormS8Uint ||
            depthFormat == VkFormat.FormatD32SfloatS8Uint)
        {
            viewInfo.subresourceRange.aspectMask |= VkImageAspectFlagBits.ImageAspectStencilBit;
        }

        /* Create image */
        var res = Vk.CreateImage(device.Device, &imageCreateInfo, null, &depth.Image);
        Debug.Assert(res == VkResult.Success);

        VkMemoryRequirements memoryRequirements;
        Vk.GetImageMemoryRequirements(device.Device, depth.Image, &memoryRequirements);

        memoryAllocateInfo.allocationSize = memoryRequirements.size;
        /* Use the memory properties to determine the type of memory required */

        var pass = GetMemoryTypeFromProperties(device.PhysicalDeviceMemoryProperties, memoryRequirements.memoryTypeBits, VkMemoryPropertyFlagBits.MemoryPropertyDeviceLocalBit, ref memoryAllocateInfo.memoryTypeIndex);
        Debug.Assert(pass);

        /* Allocate memory */
        res = Vk.AllocateMemory(device.Device, &memoryAllocateInfo, null, &depth.DeviceMemory);
        Debug.Assert(res == VkResult.Success);

        /* Bind memory */
        res = Vk.BindImageMemory(device.Device, depth.Image, depth.DeviceMemory, 0);
        Debug.Assert(res == VkResult.Success);

        /* Create image view */
        viewInfo.image = depth.Image;
        res = Vk.CreateImageView(device.Device, &viewInfo, null, &depth.ImageView);
        Debug.Assert(res == VkResult.Success);

        return depth;
    }

    private static VkRenderPass CreateRenderPass(VkDevice device, VkFormat colorFormat, VkFormat depthFormat)
    {
        var attachments = stackalloc VkAttachmentDescription[2];
        attachments[0].format = colorFormat;
        attachments[0].samples = VkSampleCountFlagBits.SampleCount1Bit;
        attachments[0].loadOp = VkAttachmentLoadOp.AttachmentLoadOpClear;
        attachments[0].storeOp = VkAttachmentStoreOp.AttachmentStoreOpStore;
        attachments[0].stencilLoadOp = VkAttachmentLoadOp.AttachmentLoadOpClear;
        attachments[0].stencilStoreOp = VkAttachmentStoreOp.AttachmentStoreOpDontCare;
        attachments[0].initialLayout = VkImageLayout.ImageLayoutUndefined;
        attachments[0].finalLayout = VkImageLayout.ImageLayoutColorAttachmentOptimal;

        attachments[1].format = depthFormat;
        attachments[1].samples = VkSampleCountFlagBits.SampleCount1Bit;
        attachments[1].loadOp = VkAttachmentLoadOp.AttachmentLoadOpClear;
        attachments[1].storeOp = VkAttachmentStoreOp.AttachmentStoreOpDontCare;
        attachments[1].stencilLoadOp = VkAttachmentLoadOp.AttachmentLoadOpClear;
        attachments[1].stencilStoreOp = VkAttachmentStoreOp.AttachmentStoreOpDontCare;
        attachments[1].initialLayout = VkImageLayout.ImageLayoutUndefined;
        attachments[1].finalLayout = VkImageLayout.ImageLayoutDepthStencilAttachmentOptimal;

        var colorReference = new VkAttachmentReference
        {
            attachment = 0,
            layout = VkImageLayout.ImageLayoutColorAttachmentOptimal,
        };

        var depthReference = new VkAttachmentReference
        {
            attachment = 1,
            layout = VkImageLayout.ImageLayoutDepthStencilAttachmentOptimal,
        };

        var subpassDescription = new VkSubpassDescription
        {
            pipelineBindPoint = VkPipelineBindPoint.PipelineBindPointGraphics,
            flags = 0,
            inputAttachmentCount = 0,
            pInputAttachments = null,
            colorAttachmentCount = 1,
            pColorAttachments = &colorReference,
            pResolveAttachments = null,
            pDepthStencilAttachment = &depthReference,
            preserveAttachmentCount = 0,
            pPreserveAttachments = null,
        };

        var passCreateInfo = new VkRenderPassCreateInfo
        {
            sType = VkStructureType.StructureTypeRenderPassCreateInfo,
            attachmentCount = 2,
            pAttachments = attachments,
            subpassCount = 1,
            pSubpasses = &subpassDescription,
        };

        VkRenderPass renderPass;
        var res = Vk.CreateRenderPass(device, &passCreateInfo, null, &renderPass);
        Debug.Assert(res == VkResult.Success);

        return renderPass;
    }

    private static VulkanSwapchain CreateSwapchainBuffers(in VulkanDevice device, VkFormat format, VkCommandBuffer commandBuffer, VkImage image)
    {
        VulkanSwapchain buffer;
        var colorAttachmentView = new VkImageViewCreateInfo
        {
            sType = VkStructureType.StructureTypeImageViewCreateInfo,
            format = format,
        };
        colorAttachmentView.components.r = VkComponentSwizzle.ComponentSwizzleR;
        colorAttachmentView.components.g = VkComponentSwizzle.ComponentSwizzleG;
        colorAttachmentView.components.b = VkComponentSwizzle.ComponentSwizzleB;
        colorAttachmentView.components.a = VkComponentSwizzle.ComponentSwizzleA;

        var subresourceRange = new VkImageSubresourceRange
        {
            aspectMask = VkImageAspectFlagBits.ImageAspectColorBit,
            baseMipLevel = 0,
            levelCount = 1,
            baseArrayLayer = 0,
            layerCount = 1,
        };

        colorAttachmentView.subresourceRange = subresourceRange;
        colorAttachmentView.viewType = VkImageViewType.ImageViewType2d;

        buffer.Image = image;

        SetupImageLayout(commandBuffer, image, VkImageAspectFlagBits.ImageAspectColorBit, VkImageLayout.ImageLayoutUndefined, VkImageLayout.ImageLayoutPresentSrcKhr);

        colorAttachmentView.image = buffer.Image;

        var res = Vk.CreateImageView(device.Device, &colorAttachmentView, null, &buffer.ImageView);
        Debug.Assert(res == VkResult.Success);

        return buffer;
    }

    private static void SetupImageLayout(VkCommandBuffer commandBuffer, VkImage image, VkImageAspectFlagBits aspectMask, VkImageLayout oldImageLayout, VkImageLayout newImageLayout)
    {
        var imageMemoryBarrier = new VkImageMemoryBarrier
        {
            sType = VkStructureType.StructureTypeImageMemoryBarrier,
            oldLayout = oldImageLayout,
            newLayout = newImageLayout,
            image = image,
        };

        var subresourceRange = new VkImageSubresourceRange
        {
            aspectMask = aspectMask,
            baseMipLevel = 0, levelCount = 1, baseArrayLayer = 0, layerCount = 1,
        };
        imageMemoryBarrier.subresourceRange = subresourceRange;

        imageMemoryBarrier.dstAccessMask = newImageLayout switch
        {
            VkImageLayout.ImageLayoutTransferDstOptimal => VkAccessFlagBits.AccessTransferReadBit,
            VkImageLayout.ImageLayoutColorAttachmentOptimal => VkAccessFlagBits.AccessColorAttachmentWriteBit,
            VkImageLayout.ImageLayoutDepthStencilAttachmentOptimal => VkAccessFlagBits.AccessDepthStencilAttachmentWriteBit,
            VkImageLayout.ImageLayoutShaderReadOnlyOptimal => VkAccessFlagBits.AccessShaderReadBit | VkAccessFlagBits.AccessInputAttachmentReadBit,
            _ => imageMemoryBarrier.dstAccessMask
        };

        var srcStageMask = VkPipelineStageFlagBits.PipelineStageTopOfPipeBit;
        var destStageMask = VkPipelineStageFlagBits.PipelineStageTopOfPipeBit;

        Vk.CmdPipelineBarrier(commandBuffer, srcStageMask, destStageMask, 0, 0, null, 0, null, 1, &imageMemoryBarrier);
    }

    private static VulkanFrameBuffers CreateFrameBuffers(in VulkanDevice device, VkSurfaceKHR surface, VkQueue queue, int winWidth, int winHeight, VkSwapchainKHR oldSwapchain)
    {
        var supportsPresent = 0;
        Vk.GetPhysicalDeviceSurfaceSupportKHR(device.PhysicalDevice, device.GraphicsQueueFamilyIndex, surface, &supportsPresent);
        if (supportsPresent == 0)
            throw new Exception("Not supported");

        var setupCommandBuffer = CreateCommandBuffers(device.Device, device.CommandPool, 1);
        var bufferBeginInfo = new VkCommandBufferBeginInfo
        {
            sType = VkStructureType.StructureTypeCommandBufferBeginInfo,
        };

        Vk.BeginCommandBuffer(setupCommandBuffer[0], &bufferBeginInfo);

        // Get the list of VkFormats that are supported:
        var formatCount = 0U;
        var res = Vk.GetPhysicalDeviceSurfaceFormatsKHR(device.PhysicalDevice, surface, &formatCount, null);
        Debug.Assert(res == VkResult.Success);
        var surfFormats = stackalloc VkSurfaceFormatKHR[(int)formatCount];

        res = Vk.GetPhysicalDeviceSurfaceFormatsKHR(device.PhysicalDevice, surface, &formatCount, surfFormats);
        Debug.Assert(res == VkResult.Success);

        if (formatCount != 1 || surfFormats[0].format != VkFormat.FormatUndefined) 
            Debug.Assert(formatCount >= 1);

        var colorSpace = surfFormats[0].colorSpace;
        var colorFormat = VkFormat.FormatB8g8r8a8Unorm;

        // Check the surface capabilities and formats
        VkSurfaceCapabilitiesKHR surfCapabilities;
        res = Vk.GetPhysicalDeviceSurfaceCapabilitiesKHR(device.PhysicalDevice, surface, &surfCapabilities);
        Debug.Assert(res == VkResult.Success);

        VkExtent2D bufferSize;
        // width and height are either both -1, or both not -1.
        if (surfCapabilities.currentExtent.width == uint.MaxValue)
        {
            bufferSize.width = (uint)winWidth;
            bufferSize.height = (uint)winHeight;
        }
        else
        {
            // If the surface size is defined, the swap chain size must match
            bufferSize = surfCapabilities.currentExtent;
        }

        var depth = CreateDepthBuffer(device, bufferSize.width, bufferSize.height);
        var renderPass = CreateRenderPass(device.Device, colorFormat, depth.Format);

        var presentModeCount = 0U;
        Vk.GetPhysicalDeviceSurfacePresentModesKHR(device.PhysicalDevice, surface, &presentModeCount, null);
        Debug.Assert(presentModeCount > 0);

        var presentModes = stackalloc VkPresentModeKHR[(int)presentModeCount];
        Vk.GetPhysicalDeviceSurfacePresentModesKHR(device.PhysicalDevice, surface, &presentModeCount, presentModes);

        var swapchainPresentMode = VkPresentModeKHR.PresentModeFifoKhr;
        for (var i = 0; i < presentModeCount; i++)
        {
            if (presentModes[i] == VkPresentModeKHR.PresentModeMailboxKhr)
            {
                swapchainPresentMode = VkPresentModeKHR.PresentModeMailboxKhr;
                break;
            }

            if (presentModes[i] == VkPresentModeKHR.PresentModeImmediateKhr) 
                swapchainPresentMode = VkPresentModeKHR.PresentModeImmediateKhr;
        }

        var preTransform = default(VkSurfaceTransformFlagBitsKHR);
        if ((surfCapabilities.supportedTransforms & VkSurfaceTransformFlagBitsKHR.SurfaceTransformIdentityBitKhr) != 0)
            preTransform = VkSurfaceTransformFlagBitsKHR.SurfaceTransformIdentityBitKhr;
        else
            preTransform = surfCapabilities.currentTransform;

        // Determine the number of VkImage's to use in the swap chain (we desire to
        // own only 1 image at a time, besides the images being displayed and
        // queued for display):
        var desiredNumberOfSwapchainImages = Math.Max(surfCapabilities.minImageCount + 1, 3);
        if (surfCapabilities.maxImageCount > 0 && desiredNumberOfSwapchainImages > surfCapabilities.maxImageCount)
        {
            // Application must settle for fewer images than desired:
            desiredNumberOfSwapchainImages = surfCapabilities.maxImageCount;
        }

        var swapchainInfo = new VkSwapchainCreateInfoKHR
        {
            sType = VkStructureType.StructureTypeSwapchainCreateInfoKhr,
            surface = surface,
            minImageCount = desiredNumberOfSwapchainImages,
            imageFormat = colorFormat,
            imageColorSpace = colorSpace,
            imageExtent = bufferSize,
            imageUsage = VkImageUsageFlagBits.ImageUsageColorAttachmentBit,
            preTransform = preTransform,
            compositeAlpha = VkCompositeAlphaFlagBitsKHR.CompositeAlphaOpaqueBitKhr,
            imageArrayLayers = 1,
            imageSharingMode = VkSharingMode.SharingModeExclusive,
            presentMode = swapchainPresentMode,
            oldSwapchain = oldSwapchain,
            clipped = 1,
        };

        VkSwapchainKHR swapchain;
        res = Vk.CreateSwapchainKHR(device.Device, &swapchainInfo, null, &swapchain);
        Debug.Assert(res == VkResult.Success);

        if (oldSwapchain != VkSwapchainKHR.Zero) 
            Vk.DestroySwapchainKHR(device.Device, oldSwapchain, null);

        uint swapchainImageCount;
        res = Vk.GetSwapchainImagesKHR(device.Device, swapchain, &swapchainImageCount, null);
        Debug.Assert(res == VkResult.Success);

        var swapchainImages = stackalloc VkImage[(int)swapchainImageCount];

        res = Vk.GetSwapchainImagesKHR(device.Device, swapchain, &swapchainImageCount, swapchainImages);
        Debug.Assert(res == VkResult.Success);

        var swapChainBuffers = new VulkanSwapchain[swapchainImageCount];
        for (var i = 0; i < swapchainImageCount; i++) 
            swapChainBuffers[i] = CreateSwapchainBuffers(device, colorFormat, setupCommandBuffer[0], swapchainImages[i]);

        var attachments = stackalloc VkImageView[2];
        attachments[1] = depth.ImageView;

        var framebufferCreateInfo = new VkFramebufferCreateInfo
        {
            sType = VkStructureType.StructureTypeFramebufferCreateInfo,
            renderPass = renderPass,
            attachmentCount = 2,
            pAttachments = attachments,
            width = bufferSize.width,
            height = bufferSize.height,
            layers = 1,
        };

        var framebuffers = new VkFramebuffer [swapchainImageCount];
        fixed (VkFramebuffer* ptr = framebuffers)
        {
            for (var i = 0; i < swapchainImageCount; i++)
            {
                attachments[0] = swapChainBuffers[i].ImageView;
                res = Vk.CreateFramebuffer(device.Device, &framebufferCreateInfo, null, &ptr[i]);
                Debug.Assert(res == VkResult.Success);
            }
        }

        Vk.EndCommandBuffer(setupCommandBuffer[0]);

        fixed (VkCommandBuffer* ptr = setupCommandBuffer)
        {
            var submitInfo = new VkSubmitInfo
            {
                sType = VkStructureType.StructureTypeSubmitInfo,
                commandBufferCount = 1,
                pCommandBuffers = ptr,
            };

            Vk.QueueSubmit(queue, 1, &submitInfo, VkFence.Zero);
            Vk.QueueWaitIdle(queue);

            Vk.FreeCommandBuffers(device.Device, device.CommandPool, 1, ptr);
        }

        var buffer = new VulkanFrameBuffers
        {
            Swapchain = swapchain,
            SwapchainBuffers = swapChainBuffers,
            Framebuffers = framebuffers,
            CurrentFrameBuffer = 0,
            BufferSize = bufferSize,
            RenderPass = renderPass,
            DepthBuffer = depth,
            PresentCompleteSemaphore = new VkSemaphore[swapchainImageCount],
            RenderCompleteSemaphore = new VkSemaphore[swapchainImageCount],
            FlightFence = new VkFence[swapchainImageCount],
        };

        var presentCompleteSemaphoreCreateInfo = new VkSemaphoreCreateInfo { sType = VkStructureType.StructureTypeSemaphoreCreateInfo };
        var fenceCreateInfo = new VkFenceCreateInfo { sType = VkStructureType.StructureTypeFenceCreateInfo };
        for (var i = 0; i < swapchainImageCount; i++)
        {
            fixed (VkSemaphore* ptr = &buffer.PresentCompleteSemaphore[i])
                res = Vk.CreateSemaphore(device.Device, &presentCompleteSemaphoreCreateInfo, null, ptr);
            Debug.Assert(res == VkResult.Success);

            fixed (VkSemaphore* ptr = &buffer.RenderCompleteSemaphore[i])
                res = Vk.CreateSemaphore(device.Device, &presentCompleteSemaphoreCreateInfo, null, ptr);
            Debug.Assert(res == VkResult.Success);

            fixed (VkFence* ptr = &buffer.FlightFence[i])
                res = Vk.CreateFence(device.Device, &fenceCreateInfo, null, ptr);
            Debug.Assert(res == VkResult.Success);
        }

        return buffer;
    }

    private static void DestroyFrameBuffers(in VulkanDevice device, ref VulkanFrameBuffers buffer, VkQueue queue)
    {
        var res = Vk.QueueWaitIdle(queue);
        Debug.Assert(res == VkResult.Success);

        for (var i = 0; i < buffer.SwapchainCount; ++i)
        {
            if (buffer.PresentCompleteSemaphore[i] != VkSemaphore.Zero) 
                Vk.DestroySemaphore(device.Device, buffer.PresentCompleteSemaphore[i], null);

            if (buffer.RenderCompleteSemaphore[i] != VkSemaphore.Zero) 
                Vk.DestroySemaphore(device.Device, buffer.RenderCompleteSemaphore[i], null);

            if (buffer.FlightFence[i] != VkFence.Zero) 
                Vk.DestroyFence(device.Device, buffer.FlightFence[i], null);
        }

        for (var i = 0; i < buffer.SwapchainCount; ++i)
        {
            Vk.DestroyImageView(device.Device, buffer.SwapchainBuffers[i].ImageView, null);
            Vk.DestroyFramebuffer(device.Device, buffer.Framebuffers[i], null);
        }

        Vk.DestroyImageView(device.Device, buffer.DepthBuffer.ImageView, null);
        Vk.DestroyImage(device.Device, buffer.DepthBuffer.Image, null);
        Vk.FreeMemory(device.Device, buffer.DepthBuffer.DeviceMemory, null);

        Vk.DestroyRenderPass(device.Device, buffer.RenderPass, null);
        Vk.DestroySwapchainKHR(device.Device, buffer.Swapchain, null);

        buffer.Framebuffers = null!;
        buffer.SwapchainBuffers = null!;
        buffer.PresentCompleteSemaphore = null!;
        buffer.RenderCompleteSemaphore = null!;
        buffer.FlightFence = null!;
    }

    private sealed class VulkanFrameBuffer : NvgSharp.OpenTK.Vulkan.VulkanFrameBuffer
    {
        private readonly VulkanBackend _backend;

        public override VkRenderPass RenderPass => _backend._frameBuffers.RenderPass;
        public override uint SwapChainImageCount => _backend._frameBuffers.SwapchainCount;
        public override uint CurrentFrame => _backend._frameBuffers.CurrentFrame;

        public VulkanFrameBuffer(VulkanBackend backend)
        {
            _backend = backend;
        }
    }
}