using System;
using OpenTK.Graphics.Vulkan;

namespace NvgSharp.OpenTK.Vulkan;

public sealed unsafe class VulkanTexture : IDisposable
{
    private readonly VkDevice _device;
    private readonly VkAllocationCallbacks* _allocator;

    internal VkSampler Sampler;

    internal VkImage Image;
    internal VkImageLayout ImageLayout;
    internal VkImageView ImageView;

    internal VkDeviceMemory DeviceMemory;
    internal void* MappedMemory;
    internal ulong RowPitch;
    internal bool IsMapped;
    internal int Width;
    internal int Height;

    internal VulkanTexture(VkDevice device, VkAllocationCallbacks* allocator)
    {
        _device = device;
        _allocator = allocator;
    }

    ~VulkanTexture()
    {
        Dispose();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        try
        {
            VulkanContext.DeleteTexture(this, _device, _allocator);
        }
        catch
        {
            // Empty
        }
    }
}