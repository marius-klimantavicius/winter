using System.Runtime.InteropServices;
using OpenTK.Graphics.Vulkan;

namespace NvgSharp.OpenTK.Vulkan;

internal unsafe partial class VkNvgContext
{
    private VkNvgPipeline AllocPipeline()
    {
        var result = new VkNvgPipeline();
        Pipelines.Add(result);
        return result;
    }

    private VkNvgPipeline? FindPipeline(in VkNvgCreatePipelineKey pipelinekey)
    {
        VkNvgPipeline? pipeline = null;
        var span = CollectionsMarshal.AsSpan(Pipelines);
        for (var i = 0; i < span.Length; i++)
        {
            if (CompareCreatePipelineKey(in span[i].Key, pipelinekey) == 0)
            {
                pipeline = Pipelines[i];
                break;
            }
        }

        return pipeline;
    }

    private VkNvgPipeline CreatePipeline(ref VkNvgCreatePipelineKey pipelinekey)
    {
        var device = CreateInfo.Device;
        var pipelineLayout = PipelineLayout;
        var allocator = CreateInfo.Allocator;
        var renderpass = FrameBuffer.RenderPass;

        var vert_shader = FillVertShader;
        var frag_shader = FillFragShader;

        var vi_bindings = stackalloc VkVertexInputBindingDescription[1];
        vi_bindings[0].binding = 0;
        vi_bindings[0].stride = (uint)sizeof(Vertex);
        vi_bindings[0].inputRate = VkVertexInputRate.VertexInputRateVertex;

        var vi_attrs = stackalloc VkVertexInputAttributeDescription[2];
        vi_attrs[0].binding = 0;
        vi_attrs[0].location = 0;
        vi_attrs[0].format = VkFormat.FormatR32g32Sfloat;
        vi_attrs[0].offset = 0;
        vi_attrs[1].binding = 0;
        vi_attrs[1].location = 1;
        vi_attrs[1].format = VkFormat.FormatR32g32Sfloat;
        vi_attrs[1].offset = (2 * sizeof(float));

        var vi = new VkPipelineVertexInputStateCreateInfo
        {
            sType = VkStructureType.StructureTypePipelineVertexInputStateCreateInfo,
            vertexBindingDescriptionCount = 1,
            pVertexBindingDescriptions = vi_bindings,
            vertexAttributeDescriptionCount = 2,
            pVertexAttributeDescriptions = vi_attrs,
        };

        var ia = new VkPipelineInputAssemblyStateCreateInfo
        {
            sType = VkStructureType.StructureTypePipelineInputAssemblyStateCreateInfo,
            topology = pipelinekey.Topology,
        };

        var rs = new VkPipelineRasterizationStateCreateInfo
        {
            sType = VkStructureType.StructureTypePipelineRasterizationStateCreateInfo,
            polygonMode = VkPolygonMode.PolygonModeFill,
            cullMode = GetCullMode(pipelinekey),
            frontFace = VkFrontFace.FrontFaceCounterClockwise,
            depthClampEnable = 0,
            rasterizerDiscardEnable = 0,
            depthBiasEnable = 0,
            lineWidth = 1.0f,
        };

        var colorblend = CompositOperationToColorBlendAttachmentState(pipelinekey);
        pipelinekey.ColorWriteMask = GetColorWriteMask(pipelinekey);

        var cb = new VkPipelineColorBlendStateCreateInfo
        {
            sType = VkStructureType.StructureTypePipelineColorBlendStateCreateInfo,
            attachmentCount = 1,
            pAttachments = &colorblend,
        };

        var vp = new VkPipelineViewportStateCreateInfo
        {
            sType = VkStructureType.StructureTypePipelineViewportStateCreateInfo,
            viewportCount = 1,
            scissorCount = 1,
        };

        var dynamicStateEnables = stackalloc VkDynamicState[16];

        uint NUM_DYNAMIC_STATES = 0;
        dynamicStateEnables[NUM_DYNAMIC_STATES++] = VkDynamicState.DynamicStateViewport;
        dynamicStateEnables[NUM_DYNAMIC_STATES++] = VkDynamicState.DynamicStateScissor;
        if (CreateInfo.Extensions.DynamicState)
        {
            Ext.DynamicState = true;
            dynamicStateEnables[NUM_DYNAMIC_STATES++] = VkDynamicState.DynamicStatePrimitiveTopology;
            dynamicStateEnables[NUM_DYNAMIC_STATES++] = VkDynamicState.DynamicStateStencilTestEnable;
            dynamicStateEnables[NUM_DYNAMIC_STATES++] = VkDynamicState.DynamicStateStencilOp;
        }

        // if (CreateInfo.Extensions.ColorBlendEquation)
        // {
        //     Ext.ColorBlendEquation = true;
        //     dynamicStateEnables[NUM_DYNAMIC_STATES++] = VkDynamicState.DynamicStateColorBlendEquationExt;
        // }
        //
        // if (CreateInfo.Extensions.ColorWriteMask)
        // {
        //     Ext.ColorWriteMask = true;
        //     dynamicStateEnables[NUM_DYNAMIC_STATES++] = VkDynamicState.DynamicStateColorWriteMaskExt;
        // }

        var dynamicState = new VkPipelineDynamicStateCreateInfo
        {
            sType = VkStructureType.StructureTypePipelineDynamicStateCreateInfo,
            dynamicStateCount = NUM_DYNAMIC_STATES,
            pDynamicStates = dynamicStateEnables,
        };

        var ds = InitializeDepthStencilCreateInfo(ref pipelinekey);

        var ms = new VkPipelineMultisampleStateCreateInfo
        {
            sType = VkStructureType.StructureTypePipelineMultisampleStateCreateInfo,
            pSampleMask = null,
            rasterizationSamples = VkSampleCountFlagBits.SampleCount1Bit,
        };

        var main = stackalloc byte[5] { (byte)'m', (byte)'a', (byte)'i', (byte)'n', 0 };
        var shaderStages = stackalloc VkPipelineShaderStageCreateInfo[2];
        shaderStages[0].sType = VkStructureType.StructureTypePipelineShaderStageCreateInfo;
        shaderStages[1].sType = VkStructureType.StructureTypePipelineShaderStageCreateInfo;

        shaderStages[0].stage = VkShaderStageFlagBits.ShaderStageVertexBit;
        shaderStages[0].module = vert_shader;
        shaderStages[0].pName = main;

        var edgeAA = _edgeAntiAlias ? 1U : 0U;

        VkSpecializationMapEntry entry;
        entry.offset = 0;
        entry.constantID = 0;
        entry.size = sizeof(uint);

        VkSpecializationInfo specializationInfo;
        specializationInfo.mapEntryCount = 1;
        specializationInfo.pMapEntries = &entry;
        specializationInfo.dataSize = entry.size;
        specializationInfo.pData = &edgeAA;

        shaderStages[1].stage = VkShaderStageFlagBits.ShaderStageFragmentBit;
        shaderStages[1].module = frag_shader;
        shaderStages[1].pName = main;
        shaderStages[1].pSpecializationInfo = &specializationInfo;

        var pipelineCreateInfo = new VkGraphicsPipelineCreateInfo
        {
            sType = VkStructureType.StructureTypeGraphicsPipelineCreateInfo,
            layout = pipelineLayout,
            stageCount = 2,
            pStages = shaderStages,
            pVertexInputState = &vi,
            pInputAssemblyState = &ia,
            pRasterizationState = &rs,
            pColorBlendState = &cb,
            pMultisampleState = &ms,
            pViewportState = &vp,
            pDepthStencilState = &ds,
            renderPass = renderpass,
            pDynamicState = &dynamicState,
        };

        VkPipeline pipeline;
        CheckResult(Vk.CreateGraphicsPipelines(device, VkPipelineCache.Zero, 1, &pipelineCreateInfo, allocator, &pipeline));

        var ret = AllocPipeline();

        ret.Key = pipelinekey;
        ret.Pipeline = pipeline;
        return ret;
    }

    private VkPipeline BindPipeline(VkCommandBuffer cmdBuffer, ref VkNvgCreatePipelineKey pipelinekey)
    {
        pipelinekey.ColorWriteMask = GetColorWriteMask(pipelinekey); // always set this before compare op
        var pipeline = FindPipeline(pipelinekey) ?? CreatePipeline(ref pipelinekey);

        if (pipeline != CurrentPipeline)
        {
            Vk.CmdBindPipeline(cmdBuffer, VkPipelineBindPoint.PipelineBindPointGraphics, pipeline.Pipeline);
            CurrentPipeline = pipeline;
        }

        return pipeline.Pipeline;
    }

    private int CompareCreatePipelineKey(in VkNvgCreatePipelineKey a, in VkNvgCreatePipelineKey b)
    {
        if (Ext.DynamicState)
        {
            if (a.Topology != b.Topology)
                return a.Topology - b.Topology;

            if (a.StencilTest != b.StencilTest)
                return a.StencilTest.CompareTo(b.StencilTest);

            if (a.StencilFill != b.StencilFill)
                return a.StencilFill.CompareTo(b.StencilFill);

            if (a.StencilStroke != b.StencilStroke)
                return a.StencilStroke - b.StencilStroke;
        }

        if (Ext.ColorWriteMask)
        {
            if (a.ColorWriteMask != b.ColorWriteMask)
                return a.ColorWriteMask.CompareTo(b.ColorWriteMask);
        }

        if (Ext.ColorBlendEquation)
        {
            if (a.EdgeAA != b.EdgeAA)
                return a.EdgeAA.CompareTo(b.EdgeAA);
        }

        return 0;
    }

    private static VkPipelineDepthStencilStateCreateInfo InitializeDepthStencilCreateInfo(ref VkNvgCreatePipelineKey pipelinekey)
    {
        var ds = new VkPipelineDepthStencilStateCreateInfo
        {
            sType = VkStructureType.StructureTypePipelineDepthStencilStateCreateInfo,
            depthWriteEnable = 0,
            depthTestEnable = 1,
            depthCompareOp = VkCompareOp.CompareOpLessOrEqual,
            depthBoundsTestEnable = 0,
        };

        if (pipelinekey.StencilStroke != VkNvgStencilSetting.Undefined)
        {
            // enables
            ds.stencilTestEnable = 1;
            ds.front.failOp = VkStencilOp.StencilOpKeep;
            ds.front.depthFailOp = VkStencilOp.StencilOpKeep;
            ds.front.passOp = VkStencilOp.StencilOpKeep;
            ds.front.compareOp = VkCompareOp.CompareOpEqual;
            ds.front.reference = 0x00;
            ds.front.compareMask = 0xff;
            ds.front.writeMask = 0xff;
            ds.back = ds.front;
            ds.back.passOp = VkStencilOp.StencilOpDecrementAndClamp;

            switch (pipelinekey.StencilStroke)
            {
                case VkNvgStencilSetting.Fill:
                    ds.front.passOp = VkStencilOp.StencilOpIncrementAndClamp;
                    ds.back.passOp = VkStencilOp.StencilOpDecrementAndClamp;
                    break;
                case VkNvgStencilSetting.DrawAA:
                    ds.front.passOp = VkStencilOp.StencilOpKeep;
                    ds.back.passOp = VkStencilOp.StencilOpKeep;
                    break;
                case VkNvgStencilSetting.Clear:
                    ds.front.failOp = VkStencilOp.StencilOpZero;
                    ds.front.depthFailOp = VkStencilOp.StencilOpZero;
                    ds.front.passOp = VkStencilOp.StencilOpZero;
                    ds.front.compareOp = VkCompareOp.CompareOpAlways;
                    ds.back = ds.front;
                    break;
            }

            return ds;
        }

        ds.stencilTestEnable = 0;
        ds.back.failOp = VkStencilOp.StencilOpKeep;
        ds.back.passOp = VkStencilOp.StencilOpKeep;
        ds.back.compareOp = VkCompareOp.CompareOpAlways;

        if (pipelinekey.StencilFill)
        {
            ds.stencilTestEnable = 1;
            ds.front.compareOp = VkCompareOp.CompareOpAlways;
            ds.front.failOp = VkStencilOp.StencilOpKeep;
            ds.front.depthFailOp = VkStencilOp.StencilOpKeep;
            ds.front.passOp = VkStencilOp.StencilOpIncrementAndWrap;
            ds.front.reference = 0x0;
            ds.front.compareMask = 0xff;
            ds.front.writeMask = 0xff;
            ds.back = ds.front;
            ds.back.passOp = VkStencilOp.StencilOpDecrementAndWrap;
        }
        else if (pipelinekey.StencilTest)
        {
            ds.stencilTestEnable = 1;
            if (pipelinekey.EdgeAA)
            {
                ds.front.compareOp = VkCompareOp.CompareOpEqual;
                ds.front.reference = 0x0;
                ds.front.compareMask = 0xff;
                ds.front.writeMask = 0xff;
                ds.front.failOp = VkStencilOp.StencilOpKeep;
                ds.front.depthFailOp = VkStencilOp.StencilOpKeep;
                ds.front.passOp = VkStencilOp.StencilOpKeep;
                ds.back = ds.front;
            }
            else
            {
                ds.front.compareOp = VkCompareOp.CompareOpNotEqual;
                ds.front.reference = 0x0;
                ds.front.compareMask = 0xff;
                ds.front.writeMask = 0xff;
                ds.front.failOp = VkStencilOp.StencilOpZero;
                ds.front.depthFailOp = VkStencilOp.StencilOpZero;
                ds.front.passOp = VkStencilOp.StencilOpZero;
                ds.back = ds.front;
            }
        }

        return ds;
    }

    private static VkPipelineColorBlendAttachmentState CompositOperationToColorBlendAttachmentState(in VkNvgCreatePipelineKey pipelineKey)
    {
        var state = new VkPipelineColorBlendAttachmentState
        {
            blendEnable = 1,
            colorBlendOp = VkBlendOp.BlendOpAdd,
            alphaBlendOp = VkBlendOp.BlendOpAdd,
            colorWriteMask = GetColorWriteMask(pipelineKey),
            srcColorBlendFactor = VkBlendFactor.BlendFactorOne,
            srcAlphaBlendFactor = VkBlendFactor.BlendFactorOne,
            dstColorBlendFactor = VkBlendFactor.BlendFactorOneMinusSrcAlpha,
            dstAlphaBlendFactor = VkBlendFactor.BlendFactorOneMinusSrcAlpha,
        };

        // if ((int)state.srcColorBlendFactor == -1 || (int)state.srcAlphaBlendFactor == -1 || (int)state.dstColorBlendFactor == -1 || (int)state.dstAlphaBlendFactor == -1)
        // {
        //     // default blend if failed convert
        //     state.srcColorBlendFactor = VkBlendFactor.BlendFactorOne;
        //     state.srcAlphaBlendFactor = VkBlendFactor.BlendFactorOneMinusSrcAlpha;
        //     state.dstColorBlendFactor = VkBlendFactor.BlendFactorOne;
        //     state.dstAlphaBlendFactor = VkBlendFactor.BlendFactorOneMinusSrcAlpha;
        // }

        return state;
    }

    private static VkColorComponentFlagBits GetColorWriteMask(in VkNvgCreatePipelineKey pipelineKey)
    {
        if (pipelineKey.StencilStroke == VkNvgStencilSetting.Clear)
            return 0;

        if (pipelineKey.StencilFill)
            return 0;

        return (VkColorComponentFlagBits)0xf;
    }

    private static VkCullModeFlagBits GetCullMode(in VkNvgCreatePipelineKey pipelineKey)
    {
        if (pipelineKey.StencilFill)
            return VkCullModeFlagBits.CullModeNone;

        return VkCullModeFlagBits.CullModeBackBit;
    }
}