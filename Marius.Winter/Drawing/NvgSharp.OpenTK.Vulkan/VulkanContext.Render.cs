using System;
using System.Buffers;
using System.Diagnostics;
using OpenTK.Graphics.Vulkan;

namespace NvgSharp.OpenTK.Vulkan;

internal unsafe partial class VulkanContext
{
    private VulkanTexture? _fallback;
    private VkDescriptorPool[] _destroyPool = Array.Empty<VkDescriptorPool>();

    public void Draw(ReadOnlySpan<CallInfo> calls, ReadOnlySpan<Vertex> vertexes)
    {
        var toReturn = default(int[]);
        var uniformOffsets = calls.Length > 256 ? (toReturn = ArrayPool<int>.Shared.Rent(calls.Length)).AsSpan(0, calls.Length) : stackalloc int[calls.Length];

        for (var i = 0; i < calls.Length; i++)
        {
            uniformOffsets[i] = Uniforms.Count;

            Uniforms.Add(Create(ref calls[i].UniformInfo));
            Uniforms.Add(Create(ref calls[i].UniformInfo2));

            continue;

            static VulkanUniformInfo Create(ref UniformInfo info)
            {
                var result = new VulkanUniformInfo
                {
                    innerCol = info.InnerColor,
                    outerCol = info.OuterColor,
                    scissorExt = info.ScissorExtent,
                    scissorScale = info.ScissorScale,
                    extent = info.Extent,
                    radius = info.Radius,
                    feather = info.Feather,
                    strokeMult = info.StrokeMult,
                    strokeThr = info.StrokeThr,
                    texType = 0, // or 1 depends on NVG_IMAGE_PREMULTIPLIED
                    type = info.Type,
                };

                VulkanUniformInfo.SetMatrix(result.scissorMat, info.ScissorMatrix);
                VulkanUniformInfo.SetMatrix(result.paintMat, info.PaintMatrix);

                return result;
            }
        }

        var device = CreateInfo.Device;
        var currentFrame = FrameBuffer.CurrentFrame;
        var memoryProperties = DeviceMemoryProperties;
        var allocator = CreateInfo.Allocator;

        if (VertexBuffer == null)
        {
            var maxFramesInFlight = FrameBuffer.SwapChainImageCount;
            VertexBuffer = new VulkanBuffer[maxFramesInFlight];
            FragUniformBuffer = new VulkanBuffer[maxFramesInFlight];
        }

        if (calls.Length > 0)
        {
            var flags = VkMemoryPropertyFlagBits.MemoryPropertyDeviceLocalBit | VkMemoryPropertyFlagBits.MemoryPropertyHostVisibleBit;
            UpdateBuffer(device, allocator, ref VertexBuffer[currentFrame], memoryProperties, VkBufferUsageFlagBits.BufferUsageVertexBufferBit, flags, vertexes);
            UpdateBuffer(device, allocator, ref FragUniformBuffer[currentFrame], memoryProperties, VkBufferUsageFlagBits.BufferUsageStorageBufferBit, flags, Uniforms);

            var offsets = 0UL;
            fixed (VulkanBuffer* ptr = &VertexBuffer[currentFrame])
                Vk.CmdBindVertexBuffers(CreateInfo.CommandBuffer[currentFrame], 0, 1, &ptr->Buffer, &offsets);

            CurrentPipeline = null;

            if (calls.Length > DescriptorPoolCount)
            {
                if (_destroyPool.Length < FrameBuffer.SwapChainImageCount)
                    Array.Resize(ref _destroyPool, (int)FrameBuffer.SwapChainImageCount);

                _destroyPool[currentFrame] = DescriptorPool;

                var pool_totals = 0L;
                var count = FrameBuffer.SwapChainImageCount;
                pool_totals += calls.Length * count; // uniform texture descriptors
                pool_totals += count; // ssbo descriptors
                DescriptorPool = CreateDescriptorPool(device, (uint)pool_totals, allocator);

                UniformDescriptorSet = new VkDescriptorSet[calls.Length * count];
                UniformDescriptorSet2 = new VkDescriptorSet[calls.Length * count];
                SsboDescriptorSet = new VkDescriptorSet[count];

                Span<VkDescriptorSetLayout> descriptorSetLayouts = DescriptorSetLayout;
                fixed (VkDescriptorSetLayout* layouts = descriptorSetLayouts)
                {
                    var alloc_info_0 = new VkDescriptorSetAllocateInfo
                    {
                        sType = VkStructureType.StructureTypeDescriptorSetAllocateInfo,
                        pNext = null,
                        descriptorPool = DescriptorPool,
                        descriptorSetCount = 1,
                        pSetLayouts = &layouts[0],
                    };

                    fixed (VkDescriptorSet* ptr = SsboDescriptorSet)
                        for (var i = 0; i < count; i++)
                            CheckResult(Vk.AllocateDescriptorSets(device, &alloc_info_0, &ptr[i]));

                    var alloc_info_1 = new VkDescriptorSetAllocateInfo
                    {
                        sType = VkStructureType.StructureTypeDescriptorSetAllocateInfo,
                        pNext = null,
                        descriptorPool = DescriptorPool,
                        descriptorSetCount = 1,
                        pSetLayouts = &layouts[1],
                    };

                    fixed (VkDescriptorSet* set = UniformDescriptorSet)
                    fixed (VkDescriptorSet* set2 = UniformDescriptorSet2)
                    {
                        for (var i = 0; i < calls.Length * count; i++)
                        {
                            CheckResult(Vk.AllocateDescriptorSets(device, &alloc_info_1, &set[i]));
                            CheckResult(Vk.AllocateDescriptorSets(device, &alloc_info_1, &set2[i]));
                        }
                    }
                }

                DescriptorPoolCount = (uint)calls.Length;
            }

            Debug.Assert(SsboDescriptorSet != null);

            var buffer_info = new VkDescriptorBufferInfo
            {
                buffer = FragUniformBuffer[currentFrame].Buffer,
                offset = 0,
                range = (uint)Uniforms.Count * (uint)sizeof(VulkanUniformInfo),
            };

            var write_frag_data = new VkWriteDescriptorSet
            {
                sType = VkStructureType.StructureTypeWriteDescriptorSet,
                dstSet = SsboDescriptorSet[currentFrame],
                descriptorCount = 1,
                descriptorType = VkDescriptorType.DescriptorTypeStorageBuffer,
                pBufferInfo = &buffer_info,
                dstBinding = 0,
            };
            Vk.UpdateDescriptorSets(device, 1, &write_frag_data, 0, null);

            var descriptor_offset = DescriptorPoolCount * currentFrame; // ensure descriptor sets dont clash
            for (var i = 0; i < calls.Length; i++)
            {
                var call = calls[i];
                switch (call.Type)
                {
                    case CallType.Fill:
                        RenderFill(call, uniformOffsets[i], descriptor_offset + (uint)i);
                        break;
                    case CallType.ConvexFill:
                        RenderConvexFill(call, uniformOffsets[i], descriptor_offset + (uint)i);
                        break;
                    case CallType.Stroke:
                        RenderStroke(call, uniformOffsets[i], descriptor_offset + (uint)i);
                        break;
                    case CallType.Triangles:
                        RenderTriangles(call, uniformOffsets[i], descriptor_offset + (uint)i);
                        break;
                }
            }
        }

        // Reset Calls
        Uniforms.Clear();

        if (toReturn != null)
            ArrayPool<int>.Shared.Return(toReturn);
    }

    internal void BeforeRender()
    {
        var currentFrame = FrameBuffer.CurrentFrame;
        if (currentFrame < _destroyPool.Length && _destroyPool[currentFrame] != VkDescriptorPool.Zero)
        {
            Vk.DestroyDescriptorPool(CreateInfo.Device, _destroyPool[currentFrame], CreateInfo.Allocator);
            _destroyPool[currentFrame] = VkDescriptorPool.Zero;
        }
    }

    private void RenderFill(CallInfo callInfo, int uniformOffset, uint descriptor_offset)
    {
        Debug.Assert(UniformDescriptorSet != null);
        Debug.Assert(UniformDescriptorSet2 != null);
        Debug.Assert(SsboDescriptorSet != null);

        var currentFrame = FrameBuffer.CurrentFrame;
        var cmdBuffer = CreateInfo.CommandBuffer[currentFrame];

        var pipelineKey = new VulkanCreatePipelineKey
        {
            // Topology = VkPrimitiveTopology.PrimitiveTopologyTriangleStrip,
            Topology = VkPrimitiveTopology.PrimitiveTopologyTriangleFan,
            StencilFill = true,
        };

        BindPipeline(cmdBuffer, ref pipelineKey);
        SetDynamicState(cmdBuffer, ref pipelineKey);
        SetUniforms(UniformDescriptorSet[descriptor_offset], uniformOffset, (VulkanTexture?)callInfo.UniformInfo.Image);

        var sets = stackalloc VkDescriptorSet[2] { SsboDescriptorSet[currentFrame], UniformDescriptorSet[descriptor_offset] };
        Vk.CmdBindDescriptorSets(cmdBuffer, VkPipelineBindPoint.PipelineBindPointGraphics, PipelineLayout, 0, 2, sets, 0, null);

        foreach (var item in callInfo.FillStrokeInfos.Span)
            Vk.CmdDraw(cmdBuffer, (uint)item.FillCount, 1, (uint)item.FillOffset, 0);

        SetUniforms(UniformDescriptorSet2[descriptor_offset], uniformOffset + 1, (VulkanTexture?)callInfo.UniformInfo2.Image);
        sets[1] = UniformDescriptorSet2[descriptor_offset];
        Vk.CmdBindDescriptorSets(cmdBuffer, VkPipelineBindPoint.PipelineBindPointGraphics, PipelineLayout, 0, 2, sets, 0, null);

        if (_edgeAntiAlias)
        {
            pipelineKey.Topology = VkPrimitiveTopology.PrimitiveTopologyTriangleStrip;
            pipelineKey.StencilFill = false;
            pipelineKey.StencilTest = true;
            pipelineKey.EdgeAA = true;
            BindPipeline(cmdBuffer, ref pipelineKey);
            SetDynamicState(cmdBuffer, ref pipelineKey);

            foreach (var item in callInfo.FillStrokeInfos.Span)
                Vk.CmdDraw(cmdBuffer, (uint)item.StrokeCount, 1, (uint)item.StrokeOffset, 0);
        }

        pipelineKey.Topology = VkPrimitiveTopology.PrimitiveTopologyTriangleStrip;
        pipelineKey.StencilFill = false;
        pipelineKey.StencilTest = true;
        pipelineKey.EdgeAA = false;
        BindPipeline(cmdBuffer, ref pipelineKey);
        SetDynamicState(cmdBuffer, ref pipelineKey);
        Vk.CmdDraw(cmdBuffer, (uint)callInfo.TriangleCount, 1, (uint)callInfo.TriangleOffset, 0);
    }

    private void RenderConvexFill(CallInfo callInfo, int uniformOffset, uint descriptor_offset)
    {
        Debug.Assert(UniformDescriptorSet != null);
        Debug.Assert(SsboDescriptorSet != null);

        var currentFrame = FrameBuffer.CurrentFrame;
        var cmdBuffer = CreateInfo.CommandBuffer[currentFrame];

        var pipelineKey = new VulkanCreatePipelineKey
        {
            // Topology = VkPrimitiveTopology.PrimitiveTopologyTriangleStrip,
            Topology = VkPrimitiveTopology.PrimitiveTopologyTriangleFan,
        };

        BindPipeline(cmdBuffer, ref pipelineKey);
        SetDynamicState(cmdBuffer, ref pipelineKey);
        SetUniforms(UniformDescriptorSet[descriptor_offset], uniformOffset, (VulkanTexture?)callInfo.UniformInfo.Image);

        var sets = stackalloc VkDescriptorSet[2] { SsboDescriptorSet[currentFrame], UniformDescriptorSet[descriptor_offset] };
        Vk.CmdBindDescriptorSets(cmdBuffer, VkPipelineBindPoint.PipelineBindPointGraphics, PipelineLayout, 0, 2, sets, 0, null);

        foreach (var item in callInfo.FillStrokeInfos.Span)
            Vk.CmdDraw(cmdBuffer, (uint)item.FillCount, 1, (uint)item.FillOffset, 0);

        if (_edgeAntiAlias)
        {
            pipelineKey.Topology = VkPrimitiveTopology.PrimitiveTopologyTriangleStrip;
            BindPipeline(cmdBuffer, ref pipelineKey);
            SetDynamicState(cmdBuffer, ref pipelineKey);

            // Draw fringes
            foreach (var item in callInfo.FillStrokeInfos.Span)
                Vk.CmdDraw(cmdBuffer, (uint)item.StrokeCount, 1, (uint)item.StrokeOffset, 0);
        }
    }

    private void RenderStroke(CallInfo callInfo, int uniformOffset, uint descriptor_offset)
    {
        Debug.Assert(UniformDescriptorSet != null);
        Debug.Assert(UniformDescriptorSet2 != null);
        Debug.Assert(SsboDescriptorSet != null);

        var currentFrame = FrameBuffer.CurrentFrame;
        var cmdBuffer = CreateInfo.CommandBuffer[currentFrame];

        if (_stencilStrokes)
        {
            var pipelineKey = new VulkanCreatePipelineKey
            {
                Topology = VkPrimitiveTopology.PrimitiveTopologyTriangleStrip,
                // Fill stencil with 1 if stencil EQUAL passes
                StencilStroke = VulkanStencilSetting.Fill,
            };

            BindPipeline(cmdBuffer, ref pipelineKey);
            SetDynamicState(cmdBuffer, ref pipelineKey);
            SetUniforms(UniformDescriptorSet2[descriptor_offset], uniformOffset + 1, (VulkanTexture?)callInfo.UniformInfo2.Image);

            var sets = stackalloc VkDescriptorSet[2] { SsboDescriptorSet[currentFrame], UniformDescriptorSet2[descriptor_offset] };
            Vk.CmdBindDescriptorSets(cmdBuffer, VkPipelineBindPoint.PipelineBindPointGraphics, PipelineLayout, 0, 2, sets, 0, null);

            foreach (var item in callInfo.FillStrokeInfos.Span)
                Vk.CmdDraw(cmdBuffer, (uint)item.StrokeCount, 1, (uint)item.StrokeOffset, 0);

            SetUniforms(UniformDescriptorSet[descriptor_offset], uniformOffset, (VulkanTexture?)callInfo.UniformInfo.Image);
            sets[1] = UniformDescriptorSet[descriptor_offset];

            // Draw AA shape if stencil EQUAL passes
            pipelineKey.StencilStroke = VulkanStencilSetting.DrawAA;
            BindPipeline(cmdBuffer, ref pipelineKey);
            SetDynamicState(cmdBuffer, ref pipelineKey);
            Vk.CmdBindDescriptorSets(cmdBuffer, VkPipelineBindPoint.PipelineBindPointGraphics, PipelineLayout, 0, 2, sets, 0, null);

            foreach (var item in callInfo.FillStrokeInfos.Span)
                Vk.CmdDraw(cmdBuffer, (uint)item.StrokeCount, 1, (uint)item.StrokeOffset, 0);

            // Fill stencil with 0, always
            pipelineKey.StencilStroke = VulkanStencilSetting.Clear;
            BindPipeline(cmdBuffer, ref pipelineKey);
            SetDynamicState(cmdBuffer, ref pipelineKey);
            Vk.CmdBindDescriptorSets(cmdBuffer, VkPipelineBindPoint.PipelineBindPointGraphics, PipelineLayout, 0, 2, sets, 0, null);

            foreach (var item in callInfo.FillStrokeInfos.Span)
                Vk.CmdDraw(cmdBuffer, (uint)item.StrokeCount, 1, (uint)item.StrokeOffset, 0);
        }
        else
        {
            var pipelineKey = new VulkanCreatePipelineKey
            {
                StencilFill = false,
                Topology = VkPrimitiveTopology.PrimitiveTopologyTriangleStrip,
            };

            BindPipeline(cmdBuffer, ref pipelineKey);
            SetDynamicState(cmdBuffer, ref pipelineKey);
            SetUniforms(UniformDescriptorSet[descriptor_offset], uniformOffset, (VulkanTexture?)callInfo.UniformInfo.Image);
            var sets = stackalloc VkDescriptorSet[2] { SsboDescriptorSet[currentFrame], UniformDescriptorSet[descriptor_offset] };
            Vk.CmdBindDescriptorSets(cmdBuffer, VkPipelineBindPoint.PipelineBindPointGraphics, PipelineLayout, 0, 2, sets, 0, null);
            // Draw Strokes

            foreach (var item in callInfo.FillStrokeInfos.Span)
                Vk.CmdDraw(cmdBuffer, (uint)item.StrokeCount, 1, (uint)item.StrokeOffset, 0);
        }
    }

    private void RenderTriangles(CallInfo callInfo, int uniformOffset, uint descriptor_offset)
    {
        if (callInfo.TriangleCount == 0)
            return;

        Debug.Assert(UniformDescriptorSet != null);
        Debug.Assert(SsboDescriptorSet != null);

        var currentFrame = FrameBuffer.CurrentFrame;
        var cmdBuffer = CreateInfo.CommandBuffer[currentFrame];

        var pipelineKey = new VulkanCreatePipelineKey
        {
            Topology = VkPrimitiveTopology.PrimitiveTopologyTriangleList,
            StencilFill = false,
        };

        BindPipeline(cmdBuffer, ref pipelineKey);
        SetDynamicState(cmdBuffer, ref pipelineKey);
        SetUniforms(UniformDescriptorSet[descriptor_offset], uniformOffset, (VulkanTexture?)callInfo.UniformInfo.Image);
        var sets = stackalloc VkDescriptorSet[2] { SsboDescriptorSet[currentFrame], UniformDescriptorSet[descriptor_offset] };
        Vk.CmdBindDescriptorSets(cmdBuffer, VkPipelineBindPoint.PipelineBindPointGraphics, PipelineLayout, 0, 2, sets, 0, null);

        Vk.CmdDraw(cmdBuffer, (uint)callInfo.TriangleCount, 1, (uint)callInfo.TriangleOffset, 0);
    }

    private void SetDynamicState(VkCommandBuffer cmd, ref VulkanCreatePipelineKey pipelineKey)
    {
        if (Ext.DynamicState)
            _vkCmdSetPrimitiveTopologyEXT(cmd, pipelineKey.Topology);

        if (Ext.ColorWriteMask)
        {
            fixed (VkColorComponentFlagBits* colorWriteMask = &pipelineKey.ColorWriteMask)
                _vkCmdSetColorWriteMaskEXT(cmd, 0, 1, colorWriteMask);
        }

        if (Ext.ColorBlendEquation)
        {
            var colorBlendAttachment = CompositOperationToColorBlendAttachmentState(pipelineKey);
            var colorBlendEquation = new VkColorBlendEquationEXT
            {
                srcColorBlendFactor = colorBlendAttachment.srcColorBlendFactor,
                dstColorBlendFactor = colorBlendAttachment.dstColorBlendFactor,
                colorBlendOp = colorBlendAttachment.colorBlendOp,
                srcAlphaBlendFactor = colorBlendAttachment.srcAlphaBlendFactor,
                dstAlphaBlendFactor = colorBlendAttachment.dstAlphaBlendFactor,
                alphaBlendOp = colorBlendAttachment.alphaBlendOp,
            };
            _vkCmdSetColorBlendEquationEXT(cmd, 0, 1, &colorBlendEquation);
        }

        if (Ext.DynamicState)
        {
            var ds = InitializeDepthStencilCreateInfo(ref pipelineKey);
            _vkCmdSetStencilTestEnableEXT(cmd, ds.stencilTestEnable);
            if (ds.stencilTestEnable != 0)
            {
                _vkCmdSetStencilOpEXT(cmd, VkStencilFaceFlagBits.StencilFaceFrontBit, ds.front.failOp, ds.front.passOp, ds.front.depthFailOp, ds.front.compareOp);
                _vkCmdSetStencilOpEXT(cmd, VkStencilFaceFlagBits.StencilFaceBackBit, ds.back.failOp, ds.back.passOp, ds.back.depthFailOp, ds.back.compareOp);
            }
        }
    }

    private void SetUniforms(VkDescriptorSet descSet, int uniformOffset, VulkanTexture? tex)
    {
        var device = CreateInfo.Device;
        var currentFrame = FrameBuffer.CurrentFrame;

        VertexConstants.UniformOffset = (uint)uniformOffset;
        fixed (void* vertexConstants = &VertexConstants)
            Vk.CmdPushConstants(CreateInfo.CommandBuffer[currentFrame], PipelineLayout, VkShaderStageFlagBits.ShaderStageVertexBit, 0, (uint)sizeof(VulkanVertexConstants), vertexConstants);

        tex ??= _fallback!;
        VkDescriptorImageInfo imageInfo = new VkDescriptorImageInfo
        {
            imageLayout = tex.ImageLayout,
            imageView = tex.ImageView,
            sampler = tex.Sampler,
        };

        var write = new VkWriteDescriptorSet
        {
            sType = VkStructureType.StructureTypeWriteDescriptorSet,
            dstSet = descSet,
            dstBinding = 1,
            descriptorCount = 1,
            descriptorType = VkDescriptorType.DescriptorTypeCombinedImageSampler,
            pImageInfo = &imageInfo,
        };
        Vk.UpdateDescriptorSets(device, 1, &write, 0, null);
    }
}