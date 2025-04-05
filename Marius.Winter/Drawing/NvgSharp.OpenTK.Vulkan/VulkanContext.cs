using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenTK.Graphics.Vulkan;

namespace NvgSharp.OpenTK.Vulkan;

internal unsafe partial class VulkanContext
{
    public VulkanFrameBuffer FrameBuffer { get; }
    private readonly bool _edgeAntiAlias, _stencilStrokes;

    private readonly VulkanCreateInfo CreateInfo;

    private VkPhysicalDeviceProperties DeviceProperties;
    private VkPhysicalDeviceMemoryProperties DeviceMemoryProperties;

    // own resources
    private readonly List<VulkanTexture> Textures = new List<VulkanTexture>();

    private DescriptorSetLayoutArray DescriptorSetLayout;
    private VkPipelineLayout PipelineLayout;

    private readonly List<VulkanPipeline> Pipelines = new List<VulkanPipeline>();

    private VulkanVertexConstants VertexConstants;

    // Per frame buffers
    private VkDescriptorPool DescriptorPool;
    private VkDescriptorSet[]? UniformDescriptorSet;
    private VkDescriptorSet[]? UniformDescriptorSet2;
    private VkDescriptorSet[]? SsboDescriptorSet;

    private uint DescriptorPoolCount;

    private readonly List<VulkanUniformInfo> Uniforms = new List<VulkanUniformInfo>();

    private VulkanBuffer[]? VertexBuffer;
    private VulkanBuffer[] FragUniformBuffer = Array.Empty<VulkanBuffer>();

    private VulkanPipeline? CurrentPipeline;

    private VkShaderModule FillFragShader;
    private VkShaderModule FillVertShader;
    private readonly VkQueue Queue;

    public VulkanExtensions Ext;

    private readonly delegate* unmanaged<VkCommandBuffer, VkPrimitiveTopology, void> _vkCmdSetPrimitiveTopologyEXT;
    private readonly delegate* unmanaged<VkCommandBuffer, int, void> _vkCmdSetStencilTestEnableEXT ;
    private readonly delegate* unmanaged<VkCommandBuffer, VkStencilFaceFlagBits, VkStencilOp, VkStencilOp, VkStencilOp, VkCompareOp, void> _vkCmdSetStencilOpEXT;
    private readonly delegate* unmanaged<VkCommandBuffer, uint, uint, VkColorBlendEquationEXT*, void> _vkCmdSetColorBlendEquationEXT;
    private readonly delegate* unmanaged<VkCommandBuffer, uint, uint, VkColorComponentFlagBits*, void> _vkCmdSetColorWriteMaskEXT;

    public VulkanContext(VulkanCreateInfo createInfo, VulkanFrameBuffer frameBuffer, VkQueue queue, bool edgeAntiAlias = true, bool stencilStrokes = true)
    {
        CreateInfo = createInfo;
        FrameBuffer = frameBuffer;
        Queue = queue;

        _vkCmdSetPrimitiveTopologyEXT = (delegate* unmanaged<VkCommandBuffer, VkPrimitiveTopology, void>)GetDeviceProcAddr(CreateInfo.Device, "vkCmdSetPrimitiveTopologyEXT");
        _vkCmdSetStencilTestEnableEXT = (delegate* unmanaged<VkCommandBuffer, int, void>)GetDeviceProcAddr(CreateInfo.Device, "vkCmdSetStencilTestEnableEXT");
        _vkCmdSetStencilOpEXT = (delegate* unmanaged<VkCommandBuffer, VkStencilFaceFlagBits, VkStencilOp, VkStencilOp, VkStencilOp, VkCompareOp, void>)GetDeviceProcAddr(CreateInfo.Device, "vkCmdSetStencilOpEXT");
        _vkCmdSetColorBlendEquationEXT = (delegate* unmanaged<VkCommandBuffer, uint, uint, VkColorBlendEquationEXT*, void>)GetDeviceProcAddr(CreateInfo.Device, "vkCmdSetColorBlendEquationEXT");
        _vkCmdSetColorWriteMaskEXT = (delegate* unmanaged<VkCommandBuffer, uint, uint, VkColorComponentFlagBits*, void>)GetDeviceProcAddr(CreateInfo.Device, "vkCmdSetColorWriteMaskEXT");
        
        _edgeAntiAlias = edgeAntiAlias;
        _stencilStrokes = stencilStrokes;

        return;

        static nint GetDeviceProcAddr(VkDevice device, string name)
        {
            var data = Marshal.StringToCoTaskMemAnsi(name);
            var result = Vk.GetDeviceProcAddr(device, (byte*)data);
            Marshal.FreeCoTaskMem(data);
            return result;
        }
    }

    public void Create()
    {
        var device = CreateInfo.Device;
        var allocator = CreateInfo.Allocator;

        fixed (VkPhysicalDeviceMemoryProperties* deviceMemoryProperties = &DeviceMemoryProperties)
            Vk.GetPhysicalDeviceMemoryProperties(CreateInfo.PhysicalDevice, deviceMemoryProperties);

        fixed (VkPhysicalDeviceProperties* deviceProperties = &DeviceProperties)
            Vk.GetPhysicalDeviceProperties(CreateInfo.PhysicalDevice, deviceProperties);

        var fillVertShader = VulkanShader.FillVert;
        var fillFragShader = VulkanShader.FillFrag;

        FillVertShader = CreateShaderModule(device, fillVertShader, allocator);
        FillFragShader = CreateShaderModule(device, fillFragShader, allocator);

        CreateDescriptorSetLayout(device, allocator, DescriptorSetLayout);
        PipelineLayout = CreatePipelineLayout(allocator);

        VkPhysicalDeviceFeatures supportedFeatures;
        Vk.GetPhysicalDeviceFeatures(CreateInfo.PhysicalDevice, &supportedFeatures);
    }

    public void Dispose()
    {
        var device = CreateInfo.Device;
        var allocator = CreateInfo.Allocator;

        for (var i = 0; i < Textures.Count; i++)
        {
            if (Textures[i].Image != VkImage.Zero)
                DeleteTexture(Textures[i], device, allocator);
        }

        Debug.Assert(VertexBuffer != null);
        Debug.Assert(FragUniformBuffer != null);

        for (var i = 0; i < FrameBuffer.SwapChainImageCount; i++)
        {
            DestroyBuffer(device, allocator, ref VertexBuffer[i]);
            DestroyBuffer(device, allocator, ref FragUniformBuffer[i]);
        }

        Vk.DestroyShaderModule(device, FillVertShader, allocator);
        Vk.DestroyShaderModule(device, FillFragShader, allocator);

        Vk.DestroyDescriptorPool(device, DescriptorPool, allocator);
        Vk.DestroyDescriptorSetLayout(device, DescriptorSetLayout[0], allocator);
        Vk.DestroyDescriptorSetLayout(device, DescriptorSetLayout[1], allocator);
        Vk.DestroyPipelineLayout(device, PipelineLayout, allocator);

        for (var i = 0; i < Pipelines.Count; i++)
            Vk.DestroyPipeline(device, Pipelines[i].Pipeline, allocator);
    }

    public void Viewport(int width, int height)
    {
        _fallback ??= CreateTexture(1, 1);

        VertexConstants.ViewSize[0] = width;
        VertexConstants.ViewSize[1] = height;
    }

    private static VkResult GetMemoryTypeFromProperties(VkPhysicalDeviceMemoryProperties memoryProperties, uint typeBits, VkMemoryPropertyFlagBits requirements_mask, out uint typeIndex)
    {
        // Search memtypes to find first index with those properties
        for (var i = 0; i < memoryProperties.memoryTypeCount; i++)
        {
            if ((typeBits & 1) == 1)
            {
                // Type is available, does it match user properties?
                if ((memoryProperties.memoryTypes[i].propertyFlags & requirements_mask) == requirements_mask)
                {
                    typeIndex = (uint)i;
                    return VkResult.Success;
                }
            }

            typeBits >>= 1;
        }

        // No memory types matched, return failure
        typeIndex = 0;
        return VkResult.ErrorFormatNotSupported;
    }

    private static VkShaderModule CreateShaderModule(VkDevice device, ReadOnlySpan<uint> code, VkAllocationCallbacks* allocator)
    {
        fixed (uint* pCode = code)
        {
            var moduleCreateInfo = new VkShaderModuleCreateInfo
            {
                sType = VkStructureType.StructureTypeShaderModuleCreateInfo,
                pNext = null,
                flags = 0,
                codeSize = (uint)code.Length * sizeof(uint),
                pCode = pCode,
            };

            VkShaderModule module;
            CheckResult(Vk.CreateShaderModule(device, &moduleCreateInfo, allocator, &module));
            return module;
        }
    }

    private static void CreateDescriptorSetLayout(VkDevice device, VkAllocationCallbacks* allocator, Span<VkDescriptorSetLayout> layouts)
    {
        var binding0 = new VkDescriptorSetLayoutBinding
        {
            binding = 0,
            descriptorType = VkDescriptorType.DescriptorTypeStorageBuffer,
            descriptorCount = 1,
            stageFlags = VkShaderStageFlagBits.ShaderStageFragmentBit,
            pImmutableSamplers = null,
        };

        var createInfo0 = new VkDescriptorSetLayoutCreateInfo
        {
            sType = VkStructureType.StructureTypeDescriptorSetLayoutCreateInfo,
            pNext = null,
            flags = 0,
            bindingCount = 1,
            pBindings = &binding0,
        };

        fixed (VkDescriptorSetLayout* layout = &layouts[0])
            CheckResult(Vk.CreateDescriptorSetLayout(device, &createInfo0, allocator, layout));

        var binding1 = new VkDescriptorSetLayoutBinding
        {
            binding = 1,
            descriptorType = VkDescriptorType.DescriptorTypeCombinedImageSampler,
            descriptorCount = 1,
            stageFlags = VkShaderStageFlagBits.ShaderStageFragmentBit,
            pImmutableSamplers = null,
        };
        var createInfo1 = new VkDescriptorSetLayoutCreateInfo
        {
            sType = VkStructureType.StructureTypeDescriptorSetLayoutCreateInfo,
            pNext = null,
            flags = 0,
            bindingCount = 1,
            pBindings = &binding1,
        };

        fixed (VkDescriptorSetLayout* layout = &layouts[1])
            CheckResult(Vk.CreateDescriptorSetLayout(device, &createInfo1, allocator, layout));
    }

    private static VkDescriptorPool CreateDescriptorPool(VkDevice device, uint count, VkAllocationCallbacks* allocator)
    {
        var type_count = stackalloc VkDescriptorPoolSize[3];
        type_count[0] = new VkDescriptorPoolSize { type = VkDescriptorType.DescriptorTypeInputAttachment, descriptorCount = 4 * count };
        type_count[1] = new VkDescriptorPoolSize { type = VkDescriptorType.DescriptorTypeStorageBuffer, descriptorCount = 4 * count };
        type_count[2] = new VkDescriptorPoolSize { type = VkDescriptorType.DescriptorTypeCombinedImageSampler, descriptorCount = 4 * count };

        var descriptor_pool = new VkDescriptorPoolCreateInfo
        {
            sType = VkStructureType.StructureTypeDescriptorPoolCreateInfo,
            pNext = null,
            flags = VkDescriptorPoolCreateFlagBits.DescriptorPoolCreateFreeDescriptorSetBit,
            maxSets = count * 2,
            poolSizeCount = 3,
            pPoolSizes = type_count,
        };

        VkDescriptorPool descPool;
        CheckResult(Vk.CreateDescriptorPool(device, &descriptor_pool, allocator, &descPool));
        return descPool;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void CheckResult(VkResult result)
    {
        if (result != VkResult.Success)
            ThrowVulkanError(result);

        return;

        [MethodImpl(MethodImplOptions.NoInlining)]
        static void ThrowVulkanError(VkResult result) => throw new Exception($"Vulkan error: {result}");
    }

    private VkPipelineLayout CreatePipelineLayout(VkAllocationCallbacks* allocator)
    {
        VkPushConstantRange pushConstantRange;
        pushConstantRange.offset = 0;
        pushConstantRange.size = (uint)sizeof(VulkanVertexConstants);
        pushConstantRange.stageFlags = VkShaderStageFlagBits.ShaderStageVertexBit;

        Span<VkDescriptorSetLayout> descriptorSetLayouts = DescriptorSetLayout;
        fixed (VkDescriptorSetLayout* setLayouts = descriptorSetLayouts)
        {
            var pipelineLayoutCreateInfo = new VkPipelineLayoutCreateInfo
            {
                sType = VkStructureType.StructureTypePipelineLayoutCreateInfo,
                setLayoutCount = 2,
                pSetLayouts = setLayouts,
                pushConstantRangeCount = 1,
                pPushConstantRanges = &pushConstantRange,
            };

            VkPipelineLayout pipelineLayout;

            CheckResult(Vk.CreatePipelineLayout(CreateInfo.Device, &pipelineLayoutCreateInfo, allocator, &pipelineLayout));

            return pipelineLayout;
        }
    }

    private nint GetDeviceProcAddress(string name)
    {
        var data = Marshal.StringToCoTaskMemAnsi(name);
        var fnptr = Vk.GetDeviceProcAddr(CreateInfo.Device, (byte*)data);
        Marshal.FreeCoTaskMem(data);

        if (fnptr == 0)
            throw new EntryPointNotFoundException($"Could not load {name}.");

        return fnptr;
    }

    [InlineArray(2)]
    private struct DescriptorSetLayoutArray
    {
#pragma warning disable CS0169 // Field is never used
        private VkDescriptorSetLayout _element0;
#pragma warning restore CS0169 // Field is never used
    }
}