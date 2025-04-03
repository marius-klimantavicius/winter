using System;
using System.Diagnostics;
using NvgSharp;
using NvgSharp.OpenTK.Vulkan;
using OpenTK.Graphics.Vulkan;
using OpenTK.Mathematics;
using OpenTK.Platform;

namespace Marius.Winter.Forms.Vulkan;

internal unsafe class VulkanSurface : Surface
{
    private readonly VulkanDevice _device;

    private readonly VkSurfaceKHR _surface;
    private readonly VkCommandBuffer[] _commandBuffer;
    private readonly VkCommandBuffer[] _secondaryCommandBuffer;
    private readonly VkQueue _executionQueue;
    private readonly VkQueue _presentQueue;

    private readonly Renderer _renderer;

    private VulkanFrameBuffers _frameBuffers;
    private Vector2i _size;
    private bool _isResize;

    public override WindowHandle NativeWindow { get; }
    public override NvgContext Context { get; }

    public VulkanSurface(WindowHandle window, VulkanDevice device, VkSurfaceKHR surface, VkQueue executionQueue, VkQueue presentQueue, VkNvgExt ext)
    {
        NativeWindow = window;

        _device = device;
        _surface = surface;
        _executionQueue = executionQueue;
        _presentQueue = presentQueue;

        _frameBuffers = CreateFrameBuffers(device, surface, executionQueue, 800, 600, VkSwapchainKHR.Zero);
        _commandBuffer = CreateCmdBuffer(device.device, device.commandPool, _frameBuffers.swapchain_image_count);
        _secondaryCommandBuffer = CreateCmdBuffer(device.device, device.commandPool, _frameBuffers.swapchain_image_count);

        var createInfo = new VkNvgCreateInfo
        {
            Device = device.device,
            PhysicalDevice = device.gpu,
            CommandBuffer = _commandBuffer,
            SecondaryCommandBuffer = _secondaryCommandBuffer,
            Extensions = ext,
        };

        _renderer = new Renderer(createInfo, new VulkanFrameBuffer(this), executionQueue);
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

                Vk.DeviceWaitIdle(_device.device);
                DestroyFrameBuffers(_device, ref _frameBuffers, _executionQueue);
                _frameBuffers = CreateFrameBuffers(_device, _surface, _executionQueue, size.X, size.Y, VkSwapchainKHR.Zero);
                _renderer.Viewport(size.X, size.Y);
            }

            PrepareFrame(backgroundColor, ref isResize);

        } while (isResize);
    }

    public override void SubmitFrame()
    {
        SubmitFrame(_device.device, _executionQueue, _presentQueue, _commandBuffer[_frameBuffers.current_frame], ref _frameBuffers, ref _isResize);
    }

    private void PrepareFrame(Color4<Rgba> backgroundColor, ref bool isResize)
    {
        var device = _device.device;
        var cmd_buffer = _commandBuffer[_frameBuffers.current_frame];
        ref var fb = ref _frameBuffers;
        
        VkResult res;

        // Get the index of the next available swapchain image:
        fixed (uint* ptr = &fb.current_frame_buffer)
            res = Vk.AcquireNextImageKHR(device, fb.swap_chain, ulong.MaxValue, fb.present_complete_semaphore[fb.current_frame], VkFence.Zero, ptr);

        if (res == VkResult.ErrorOutOfDateKhr)
        {
            Vk.QueueWaitIdle(_executionQueue);
            Vk.QueueWaitIdle(_presentQueue);
            
            isResize = true;
            return;
        }

        _renderer.BeforeRender();
        
        var cmd_buf_info = new VkCommandBufferBeginInfo { sType = VkStructureType.StructureTypeCommandBufferBeginInfo };
        Vk.BeginCommandBuffer(cmd_buffer, &cmd_buf_info);

        var clear_values = stackalloc VkClearValue[2];
        clear_values[0].color.float32[0] = backgroundColor.X;
        clear_values[0].color.float32[1] = backgroundColor.Y;
        clear_values[0].color.float32[2] = backgroundColor.Z;
        clear_values[0].color.float32[3] = backgroundColor.W;
        clear_values[1].depthStencil.depth = 1.0f;
        clear_values[1].depthStencil.stencil = 0;

        var rp_begin = new VkRenderPassBeginInfo
        {
            sType = VkStructureType.StructureTypeRenderPassBeginInfo,
            pNext = null,
            renderPass = fb.render_pass,
            framebuffer = fb.framebuffers[fb.current_frame_buffer],
        };
        rp_begin.renderArea.offset.x = 0;
        rp_begin.renderArea.offset.y = 0;
        rp_begin.renderArea.extent.width = fb.buffer_size.width;
        rp_begin.renderArea.extent.height = fb.buffer_size.height;
        rp_begin.clearValueCount = 2;
        rp_begin.pClearValues = clear_values;

        Vk.CmdBeginRenderPass(cmd_buffer, &rp_begin, VkSubpassContents.SubpassContentsInline);

        VkViewport viewport;
        viewport.width = fb.buffer_size.width;
        viewport.height = fb.buffer_size.height;
        viewport.minDepth = 0.0f;
        viewport.maxDepth = 1.0f;
        viewport.x = rp_begin.renderArea.offset.x;
        viewport.y = rp_begin.renderArea.offset.y;
        Vk.CmdSetViewport(cmd_buffer, 0, 1, &viewport);

        var scissor = rp_begin.renderArea;
        Vk.CmdSetScissor(cmd_buffer, 0, 1, &scissor);
    }

    private static void SubmitFrame(VkDevice device, VkQueue graphicsQueue, VkQueue presentQueue, VkCommandBuffer cmd_buffer, ref VulkanFrameBuffers fb, ref bool isResize)
    {
        Vk.CmdEndRenderPass(cmd_buffer);

        var image_barrier = new VkImageMemoryBarrier
        {
            sType = VkStructureType.StructureTypeImageMemoryBarrier,
            srcAccessMask = VkAccessFlagBits.AccessColorAttachmentWriteBit,
            dstAccessMask = 0,
            oldLayout = VkImageLayout.ImageLayoutColorAttachmentOptimal,
            newLayout = VkImageLayout.ImageLayoutPresentSrcKhr,
            srcQueueFamilyIndex = Vk.QueueFamilyIgnored,
            dstQueueFamilyIndex = Vk.QueueFamilyIgnored,
            image = fb.swap_chain_buffers[fb.current_frame_buffer].image,
            subresourceRange = new VkImageSubresourceRange
            {
                aspectMask = VkImageAspectFlagBits.ImageAspectColorBit,
                baseMipLevel = 0,
                levelCount = 1,
                baseArrayLayer = 0,
                layerCount = 1,
            },
        };
        Vk.CmdPipelineBarrier(cmd_buffer, VkPipelineStageFlagBits.PipelineStageColorAttachmentOutputBit, VkPipelineStageFlagBits.PipelineStageBottomOfPipeBit, 0, 0, null, 0, null, 1, &image_barrier);

        Vk.EndCommandBuffer(cmd_buffer);

        var pipe_stage_flags = VkPipelineStageFlagBits.PipelineStageColorAttachmentOutputBit;

        fixed (VkSemaphore* present_complete_semaphore = &fb.present_complete_semaphore[fb.current_frame])
        fixed (VkSemaphore* render_complete_semaphore = &fb.render_complete_semaphore[fb.current_frame])
        {
            var submit_info = new VkSubmitInfo
            {
                sType = VkStructureType.StructureTypeSubmitInfo,
                pNext = null,
                waitSemaphoreCount = 1,
                pWaitSemaphores = present_complete_semaphore,
                pWaitDstStageMask = &pipe_stage_flags,
                commandBufferCount = 1,
                pCommandBuffers = &cmd_buffer,
                signalSemaphoreCount = 1,
                pSignalSemaphores = render_complete_semaphore,
            };

            Vk.QueueSubmit(presentQueue, 1, &submit_info, fb.flight_fence[fb.current_frame]);
        }

        /* Now present the image in the window */

        fixed (VkSwapchainKHR* presentPSwapchains = &fb.swap_chain)
        fixed (uint* presentPImageIndices = &fb.current_frame_buffer)
        fixed (VkSemaphore* presentPWaitSemaphores = &fb.render_complete_semaphore[fb.current_frame])
        {
            var present = new VkPresentInfoKHR
            {
                sType = VkStructureType.StructureTypePresentInfoKhr,
                pNext = null,
                swapchainCount = 1,
                pSwapchains = presentPSwapchains,
                pImageIndices = presentPImageIndices,
                waitSemaphoreCount = 1,
                pWaitSemaphores = presentPWaitSemaphores,
            };

            var res = Vk.QueuePresentKHR(presentQueue, &present);
            if (res == VkResult.ErrorOutOfDateKhr)
            {
                Vk.QueueWaitIdle(graphicsQueue);
                Vk.QueueWaitIdle(presentQueue);
                isResize = true;
                return;
            }

            fb.current_frame = (fb.current_frame + 1) % fb.swapchain_image_count;
            fb.num_swaps++;

            if (fb.num_swaps >= fb.swapchain_image_count)
            {
                fixed (VkFence* pFences = &fb.flight_fence[fb.current_frame])
                {
                    Vk.WaitForFences(device, 1, pFences, 1, ulong.MaxValue);
                    Vk.ResetFences(device, 1, pFences);
                }
            }
        }
    }

    private static VkCommandBuffer[] CreateCmdBuffer(VkDevice device, VkCommandPool cmd_pool, uint command_buffer_count)
    {
        VkResult res;
        var cmd = new VkCommandBufferAllocateInfo
        {
            sType = VkStructureType.StructureTypeCommandBufferAllocateInfo,
            commandPool = cmd_pool,
            level = VkCommandBufferLevel.CommandBufferLevelPrimary,
            commandBufferCount = command_buffer_count,
        };

        var cmd_buffer = new VkCommandBuffer[command_buffer_count];
        fixed (VkCommandBuffer* ptr = cmd_buffer)
            res = Vk.AllocateCommandBuffers(device, &cmd, ptr);
        Debug.Assert(res == VkResult.Success);
        return cmd_buffer;
    }

    private static bool GetMemoryTypeFromProperties(VkPhysicalDeviceMemoryProperties memoryProps, uint typeBits, VkMemoryPropertyFlagBits requirements_mask, ref uint typeIndex)
    {
        // Search memtypes to find first index with those properties
        for (var i = 0; i < memoryProps.memoryTypeCount; i++)
        {
            if ((typeBits & 1) == 1)
            {
                // Type is available, does it match user properties?
                if ((memoryProps.memoryTypes[i].propertyFlags & requirements_mask) == requirements_mask)
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
        depth.format = VkFormat.FormatD24UnormS8Uint;

        const int dformats = 3;
        var depth_formats = stackalloc VkFormat[dformats] { VkFormat.FormatD32SfloatS8Uint, VkFormat.FormatD24UnormS8Uint, VkFormat.FormatD16UnormS8Uint };
        var image_tilling = VkImageTiling.ImageTilingOptimal;
        for (var i = 0; i < dformats; i++)
        {
            VkFormatProperties fprops;
            Vk.GetPhysicalDeviceFormatProperties(device.gpu, depth_formats[i], &fprops);

            if ((fprops.linearTilingFeatures & VkFormatFeatureFlagBits.FormatFeatureDepthStencilAttachmentBit) != 0)
            {
                depth.format = depth_formats[i];
                image_tilling = VkImageTiling.ImageTilingLinear;
                break;
            }

            if ((fprops.optimalTilingFeatures & VkFormatFeatureFlagBits.FormatFeatureDepthStencilAttachmentBit) != 0)
            {
                depth.format = depth_formats[i];
                image_tilling = VkImageTiling.ImageTilingOptimal;
                break;
            }

            if (i == dformats - 1)
            {
                throw new Exception("Failed to find supported depth format!");
            }
        }

        var depth_format = depth.format;

        var image_info = new VkImageCreateInfo
        {
            sType = VkStructureType.StructureTypeImageCreateInfo,
            imageType = VkImageType.ImageType2d,
            format = depth_format,
            tiling = image_tilling,
        };
        image_info.extent.width = width;
        image_info.extent.height = height;
        image_info.extent.depth = 1;
        image_info.mipLevels = 1;
        image_info.arrayLayers = 1;
        image_info.samples = VkSampleCountFlagBits.SampleCount1Bit;
        image_info.initialLayout = VkImageLayout.ImageLayoutUndefined;
        image_info.queueFamilyIndexCount = 0;
        image_info.pQueueFamilyIndices = null;
        image_info.sharingMode = VkSharingMode.SharingModeExclusive;
        image_info.usage = VkImageUsageFlagBits.ImageUsageDepthStencilAttachmentBit;

        var mem_alloc = new VkMemoryAllocateInfo { sType = VkStructureType.StructureTypeMemoryAllocateInfo };

        var view_info = new VkImageViewCreateInfo
        {
            sType = VkStructureType.StructureTypeImageViewCreateInfo,
            format = depth_format,
        };
        view_info.components.r = VkComponentSwizzle.ComponentSwizzleR;
        view_info.components.g = VkComponentSwizzle.ComponentSwizzleG;
        view_info.components.b = VkComponentSwizzle.ComponentSwizzleB;
        view_info.components.a = VkComponentSwizzle.ComponentSwizzleA;
        view_info.subresourceRange.aspectMask = VkImageAspectFlagBits.ImageAspectDepthBit;
        view_info.subresourceRange.baseMipLevel = 0;
        view_info.subresourceRange.levelCount = 1;
        view_info.subresourceRange.baseArrayLayer = 0;
        view_info.subresourceRange.layerCount = 1;
        view_info.viewType = VkImageViewType.ImageViewType2d;

        if (depth_format == VkFormat.FormatD16UnormS8Uint || depth_format == VkFormat.FormatD24UnormS8Uint ||
            depth_format == VkFormat.FormatD32SfloatS8Uint)
        {
            view_info.subresourceRange.aspectMask |= VkImageAspectFlagBits.ImageAspectStencilBit;
        }

        VkMemoryRequirements mem_reqs;

        /* Create image */
        var res = Vk.CreateImage(device.device, &image_info, null, &depth.image);
        Debug.Assert(res == VkResult.Success);

        Vk.GetImageMemoryRequirements(device.device, depth.image, &mem_reqs);

        mem_alloc.allocationSize = mem_reqs.size;
        /* Use the memory properties to determine the type of memory required */

        var pass = GetMemoryTypeFromProperties(device.memoryProperties, mem_reqs.memoryTypeBits, VkMemoryPropertyFlagBits.MemoryPropertyDeviceLocalBit, ref mem_alloc.memoryTypeIndex);
        Debug.Assert(pass);

        /* Allocate memory */
        res = Vk.AllocateMemory(device.device, &mem_alloc, null, &depth.mem);
        Debug.Assert(res == VkResult.Success);

        /* Bind memory */
        res = Vk.BindImageMemory(device.device, depth.image, depth.mem, 0);
        Debug.Assert(res == VkResult.Success);

        /* Create image view */
        view_info.image = depth.image;
        res = Vk.CreateImageView(device.device, &view_info, null, &depth.view);
        Debug.Assert(res == VkResult.Success);

        return depth;
    }

    private static VkRenderPass CreateRenderPass(VkDevice device, VkFormat color_format, VkFormat depth_format)
    {
        var attachments = stackalloc VkAttachmentDescription[2];
        attachments[0].format = color_format;
        attachments[0].samples = VkSampleCountFlagBits.SampleCount1Bit;
        attachments[0].loadOp = VkAttachmentLoadOp.AttachmentLoadOpClear;
        attachments[0].storeOp = VkAttachmentStoreOp.AttachmentStoreOpStore;
        attachments[0].stencilLoadOp = VkAttachmentLoadOp.AttachmentLoadOpClear;
        attachments[0].stencilStoreOp = VkAttachmentStoreOp.AttachmentStoreOpDontCare;
        attachments[0].initialLayout = VkImageLayout.ImageLayoutUndefined;
        attachments[0].finalLayout = VkImageLayout.ImageLayoutColorAttachmentOptimal;

        attachments[1].format = depth_format;
        attachments[1].samples = VkSampleCountFlagBits.SampleCount1Bit;
        attachments[1].loadOp = VkAttachmentLoadOp.AttachmentLoadOpClear;
        attachments[1].storeOp = VkAttachmentStoreOp.AttachmentStoreOpDontCare;
        attachments[1].stencilLoadOp = VkAttachmentLoadOp.AttachmentLoadOpClear;
        attachments[1].stencilStoreOp = VkAttachmentStoreOp.AttachmentStoreOpDontCare;
        attachments[1].initialLayout = VkImageLayout.ImageLayoutUndefined;
        attachments[1].finalLayout = VkImageLayout.ImageLayoutDepthStencilAttachmentOptimal;

        var color_reference = new VkAttachmentReference
        {
            attachment = 0,
            layout = VkImageLayout.ImageLayoutColorAttachmentOptimal,
        };

        var depth_reference = new VkAttachmentReference
        {
            attachment = 1,
            layout = VkImageLayout.ImageLayoutDepthStencilAttachmentOptimal,
        };

        var subpass = new VkSubpassDescription
        {
            pipelineBindPoint = VkPipelineBindPoint.PipelineBindPointGraphics,
            flags = 0,
            inputAttachmentCount = 0,
            pInputAttachments = null,
            colorAttachmentCount = 1,
            pColorAttachments = &color_reference,
            pResolveAttachments = null,
            pDepthStencilAttachment = &depth_reference,
            preserveAttachmentCount = 0,
            pPreserveAttachments = null,
        };

        var rp_info = new VkRenderPassCreateInfo
        {
            sType = VkStructureType.StructureTypeRenderPassCreateInfo,
            attachmentCount = 2,
            pAttachments = attachments,
            subpassCount = 1,
            pSubpasses = &subpass,
        };
        VkRenderPass render_pass;
        var res = Vk.CreateRenderPass(device, &rp_info, null, &render_pass);
        Debug.Assert(res == VkResult.Success);
        return render_pass;
    }

    private static VulkanSwapchain CreateSwapchainBuffers(in VulkanDevice device, VkFormat format, VkCommandBuffer cmdbuffer, VkImage image)
    {
        VulkanSwapchain buffer;
        var color_attachment_view = new VkImageViewCreateInfo
        {
            sType = VkStructureType.StructureTypeImageViewCreateInfo,
            format = format,
        };
        color_attachment_view.components.r = VkComponentSwizzle.ComponentSwizzleR;
        color_attachment_view.components.g = VkComponentSwizzle.ComponentSwizzleG;
        color_attachment_view.components.b = VkComponentSwizzle.ComponentSwizzleB;
        color_attachment_view.components.a = VkComponentSwizzle.ComponentSwizzleA;
        var subresourceRange = new VkImageSubresourceRange
        {
            aspectMask = VkImageAspectFlagBits.ImageAspectColorBit,
            baseMipLevel = 0,
            levelCount = 1,
            baseArrayLayer = 0,
            layerCount = 1,
        };

        color_attachment_view.subresourceRange = subresourceRange;
        color_attachment_view.viewType = VkImageViewType.ImageViewType2d;

        buffer.image = image;

        SetupImageLayout(cmdbuffer, image, VkImageAspectFlagBits.ImageAspectColorBit, VkImageLayout.ImageLayoutUndefined, VkImageLayout.ImageLayoutPresentSrcKhr);

        color_attachment_view.image = buffer.image;

        var res = Vk.CreateImageView(device.device, &color_attachment_view, null, &buffer.view);
        Debug.Assert(res == VkResult.Success);
        return buffer;
    }

    private static void SetupImageLayout(VkCommandBuffer cmdbuffer, VkImage image, VkImageAspectFlagBits aspectMask, VkImageLayout old_image_layout, VkImageLayout new_image_layout)
    {
        var image_memory_barrier = new VkImageMemoryBarrier
        {
            sType = VkStructureType.StructureTypeImageMemoryBarrier,
            oldLayout = old_image_layout,
            newLayout = new_image_layout,
            image = image,
        };

        var subresourceRange = new VkImageSubresourceRange
        {
            aspectMask = aspectMask,
            baseMipLevel = 0, levelCount = 1, baseArrayLayer = 0, layerCount = 1,
        };
        image_memory_barrier.subresourceRange = subresourceRange;

        if (new_image_layout == VkImageLayout.ImageLayoutTransferDstOptimal)
        {
            /* Make sure anything that was copying from this image has completed */
            image_memory_barrier.dstAccessMask = VkAccessFlagBits.AccessTransferReadBit;
        }

        if (new_image_layout == VkImageLayout.ImageLayoutColorAttachmentOptimal)
        {
            image_memory_barrier.dstAccessMask = VkAccessFlagBits.AccessColorAttachmentWriteBit;
        }

        if (new_image_layout == VkImageLayout.ImageLayoutDepthStencilAttachmentOptimal)
        {
            image_memory_barrier.dstAccessMask = VkAccessFlagBits.AccessDepthStencilAttachmentWriteBit;
        }

        if (new_image_layout == VkImageLayout.ImageLayoutShaderReadOnlyOptimal)
        {
            /* Make sure any Copy or CPU writes to image are flushed */
            image_memory_barrier.dstAccessMask = VkAccessFlagBits.AccessShaderReadBit | VkAccessFlagBits.AccessInputAttachmentReadBit;
        }

        var pmemory_barrier = &image_memory_barrier;

        var src_stages = VkPipelineStageFlagBits.PipelineStageTopOfPipeBit;
        var dest_stages = VkPipelineStageFlagBits.PipelineStageTopOfPipeBit;

        Vk.CmdPipelineBarrier(cmdbuffer, src_stages, dest_stages, 0, 0, null, 0, null, 1, pmemory_barrier);
    }

    private static VulkanFrameBuffers CreateFrameBuffers(in VulkanDevice device, VkSurfaceKHR surface, VkQueue queue, int winWidth, int winHeight, VkSwapchainKHR oldSwapchain)
    {
        var supportsPresent = 0;
        Vk.GetPhysicalDeviceSurfaceSupportKHR(device.gpu, device.graphicsQueueFamilyIndex, surface, &supportsPresent);
        if (supportsPresent == 0)
            throw new Exception("Not supported");

        var setup_cmd_buffer = CreateCmdBuffer(device.device, device.commandPool, 1);

        var cmd_buf_info = new VkCommandBufferBeginInfo
        {
            sType = VkStructureType.StructureTypeCommandBufferBeginInfo,
        };
        Vk.BeginCommandBuffer(setup_cmd_buffer[0], &cmd_buf_info);

        var res = VkResult.Success;
        var colorFormat = VkFormat.FormatB8g8r8a8Unorm;
        VkColorSpaceKHR colorSpace;
        // Get the list of VkFormats that are supported:
        var formatCount = 0U;
        res = Vk.GetPhysicalDeviceSurfaceFormatsKHR(device.gpu, surface, &formatCount, null);
        Debug.Assert(res == VkResult.Success);
        var surfFormats = stackalloc VkSurfaceFormatKHR[(int)formatCount];

        res = Vk.GetPhysicalDeviceSurfaceFormatsKHR(device.gpu, surface, &formatCount, surfFormats);
        Debug.Assert(res == VkResult.Success);
        // If the format list includes just one entry of VK_FORMAT_UNDEFINED,
        // the surface has no preferred format.  Otherwise, at least one
        // supported format will be returned.
        if (formatCount == 1 && surfFormats[0].format == VkFormat.FormatUndefined)
        {
            colorFormat = VkFormat.FormatB8g8r8a8Unorm;
        }
        else
        {
            Debug.Assert(formatCount >= 1);
            colorFormat = surfFormats[0].format;
        }

        colorSpace = surfFormats[0].colorSpace;
        colorFormat = VkFormat.FormatB8g8r8a8Unorm;

        // Check the surface capabilities and formats
        VkSurfaceCapabilitiesKHR surfCapabilities;
        res = Vk.GetPhysicalDeviceSurfaceCapabilitiesKHR(device.gpu, surface, &surfCapabilities);
        Debug.Assert(res == VkResult.Success);

        VkExtent2D buffer_size;
        // width and height are either both -1, or both not -1.
        if (surfCapabilities.currentExtent.width == uint.MaxValue)
        {
            buffer_size.width = (uint)winWidth;
            buffer_size.height = (uint)winHeight;
        }
        else
        {
            // If the surface size is defined, the swap chain size must match
            buffer_size = surfCapabilities.currentExtent;
        }

        var depth = CreateDepthBuffer(device, buffer_size.width, buffer_size.height);

        var render_pass = CreateRenderPass(device.device, colorFormat, depth.format);

        var swapchainPresentMode = VkPresentModeKHR.PresentModeFifoKhr;

        var presentModeCount = 0U;
        Vk.GetPhysicalDeviceSurfacePresentModesKHR(device.gpu, surface, &presentModeCount, null);
        Debug.Assert(presentModeCount > 0);

        var presentModes = stackalloc VkPresentModeKHR[(int)presentModeCount];
        Vk.GetPhysicalDeviceSurfacePresentModesKHR(device.gpu, surface, &presentModeCount, presentModes);

        for (var m = 0; m < presentModeCount; m++)
        {
            if (presentModes[m] == VkPresentModeKHR.PresentModeMailboxKhr)
            {
                swapchainPresentMode = VkPresentModeKHR.PresentModeMailboxKhr;
                break;
            }

            if ((swapchainPresentMode != VkPresentModeKHR.PresentModeMailboxKhr) && (presentModes[m] == VkPresentModeKHR.PresentModeImmediateKhr))
            {
                swapchainPresentMode = VkPresentModeKHR.PresentModeImmediateKhr;
            }
        }

        VkSurfaceTransformFlagBitsKHR preTransform;
        if ((surfCapabilities.supportedTransforms & VkSurfaceTransformFlagBitsKHR.SurfaceTransformIdentityBitKhr) != 0)
        {
            preTransform = VkSurfaceTransformFlagBitsKHR.SurfaceTransformIdentityBitKhr;
        }
        else
        {
            preTransform = surfCapabilities.currentTransform;
        }

        // Determine the number of VkImage's to use in the swap chain (we desire to
        // own only 1 image at a time, besides the images being displayed and
        // queued for display):
        var desiredNumberOfSwapchainImages = Math.Max(surfCapabilities.minImageCount + 1, 3);
        if ((surfCapabilities.maxImageCount > 0) && (desiredNumberOfSwapchainImages > surfCapabilities.maxImageCount))
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
            imageExtent = buffer_size,
            imageUsage = VkImageUsageFlagBits.ImageUsageColorAttachmentBit,
            preTransform = preTransform,
            compositeAlpha = VkCompositeAlphaFlagBitsKHR.CompositeAlphaOpaqueBitKhr,
            imageArrayLayers = 1,
            imageSharingMode = VkSharingMode.SharingModeExclusive,
            presentMode = swapchainPresentMode,
            oldSwapchain = oldSwapchain,
            clipped = 1,
        };

        VkSwapchainKHR swap_chain;
        res = Vk.CreateSwapchainKHR(device.device, &swapchainInfo, null, &swap_chain);
        Debug.Assert(res == VkResult.Success);

        if (oldSwapchain != VkSwapchainKHR.Zero)
        {
            Vk.DestroySwapchainKHR(device.device, oldSwapchain, null);
        }

        uint swapchain_image_count;
        res = Vk.GetSwapchainImagesKHR(device.device, swap_chain, &swapchain_image_count, null);
        Debug.Assert(res == VkResult.Success);

        var swapchainImages = stackalloc VkImage[(int)swapchain_image_count];

        res = Vk.GetSwapchainImagesKHR(device.device, swap_chain, &swapchain_image_count, swapchainImages);
        Debug.Assert(res == VkResult.Success);

        var swap_chain_buffers = new VulkanSwapchain[swapchain_image_count];
        for (var i = 0; i < swapchain_image_count; i++)
        {
            swap_chain_buffers[i] = CreateSwapchainBuffers(device, colorFormat, setup_cmd_buffer[0], swapchainImages[i]);
        }

        var attachments = stackalloc VkImageView[2];
        attachments[1] = depth.view;

        var fb_info = new VkFramebufferCreateInfo
        {
            sType = VkStructureType.StructureTypeFramebufferCreateInfo,
            renderPass = render_pass,
            attachmentCount = 2,
            pAttachments = attachments,
            width = buffer_size.width,
            height = buffer_size.height,
            layers = 1,
        };

        var framebuffers = new VkFramebuffer [swapchain_image_count];
        fixed (VkFramebuffer* ptr = framebuffers)
        {
            for (var i = 0; i < swapchain_image_count; i++)
            {
                attachments[0] = swap_chain_buffers[i].view;
                res = Vk.CreateFramebuffer(device.device, &fb_info, null, &ptr[i]);
                Debug.Assert(res == VkResult.Success);
            }
        }

        Vk.EndCommandBuffer(setup_cmd_buffer[0]);
        fixed (VkCommandBuffer* ptr = setup_cmd_buffer)
        {
            var submitInfo = new VkSubmitInfo
            {
                sType = VkStructureType.StructureTypeSubmitInfo,
                commandBufferCount = 1,
                pCommandBuffers = ptr,
            };

            Vk.QueueSubmit(queue, 1, &submitInfo, VkFence.Zero);
            Vk.QueueWaitIdle(queue);

            Vk.FreeCommandBuffers(device.device, device.commandPool, 1, ptr);
        }

        var buffer = new VulkanFrameBuffers
        {
            swap_chain = swap_chain,
            swap_chain_buffers = swap_chain_buffers,
            swapchain_image_count = swapchain_image_count,
            framebuffers = framebuffers,
            current_frame_buffer = 0,
            format = colorFormat,
            buffer_size = buffer_size,
            render_pass = render_pass,
            depth = depth,
            present_complete_semaphore = new VkSemaphore[swapchain_image_count],
            render_complete_semaphore = new VkSemaphore[swapchain_image_count],
            flight_fence = new VkFence[swapchain_image_count],
        };

        var presentCompleteSemaphoreCreateInfo = new VkSemaphoreCreateInfo { sType = VkStructureType.StructureTypeSemaphoreCreateInfo };
        var fenceCreateInfo = new VkFenceCreateInfo { sType = VkStructureType.StructureTypeFenceCreateInfo };
        for (var i = 0; i < swapchain_image_count; i++)
        {
            fixed (VkSemaphore* ptr = &buffer.present_complete_semaphore[i])
                res = Vk.CreateSemaphore(device.device, &presentCompleteSemaphoreCreateInfo, null, ptr);
            Debug.Assert(res == VkResult.Success);

            fixed (VkSemaphore* ptr = &buffer.render_complete_semaphore[i])
                res = Vk.CreateSemaphore(device.device, &presentCompleteSemaphoreCreateInfo, null, ptr);
            Debug.Assert(res == VkResult.Success);

            fixed (VkFence* ptr = &buffer.flight_fence[i])
                res = Vk.CreateFence(device.device, &fenceCreateInfo, null, ptr);
            Debug.Assert(res == VkResult.Success);
        }

        return buffer;
    }

    private static void DestroyFrameBuffers(in VulkanDevice device, ref VulkanFrameBuffers buffer, VkQueue queue)
    {
        var res = Vk.QueueWaitIdle(queue);
        Debug.Assert(res == VkResult.Success);

        for (var i = 0; i < buffer.swapchain_image_count; ++i)
        {
            if (buffer.present_complete_semaphore[i] != VkSemaphore.Zero)
            {
                Vk.DestroySemaphore(device.device, buffer.present_complete_semaphore[i], null);
            }

            if (buffer.render_complete_semaphore[i] != VkSemaphore.Zero)
            {
                Vk.DestroySemaphore(device.device, buffer.render_complete_semaphore[i], null);
            }

            if (buffer.flight_fence[i] != VkFence.Zero)
            {
                Vk.DestroyFence(device.device, buffer.flight_fence[i], null);
            }
        }

        for (var i = 0; i < buffer.swapchain_image_count; ++i)
        {
            Vk.DestroyImageView(device.device, buffer.swap_chain_buffers[i].view, null);
            Vk.DestroyFramebuffer(device.device, buffer.framebuffers[i], null);
        }

        Vk.DestroyImageView(device.device, buffer.depth.view, null);
        Vk.DestroyImage(device.device, buffer.depth.image, null);
        Vk.FreeMemory(device.device, buffer.depth.mem, null);

        Vk.DestroyRenderPass(device.device, buffer.render_pass, null);
        Vk.DestroySwapchainKHR(device.device, buffer.swap_chain, null);

        buffer.framebuffers = null!;
        buffer.swap_chain_buffers = null!;
        buffer.present_complete_semaphore = null!;
        buffer.render_complete_semaphore = null!;
        buffer.flight_fence = null!;
    }

    private class VulkanFrameBuffer : VkNvgFrameBuffer
    {
        private readonly VulkanSurface _surface;

        public override VkRenderPass RenderPass => _surface._frameBuffers.render_pass;
        public override uint SwapChainImageCount => _surface._frameBuffers.swapchain_image_count;
        public override uint CurrentFrame => _surface._frameBuffers.current_frame;

        public VulkanFrameBuffer(VulkanSurface surface)
        {
            _surface = surface;
        }
    }
}