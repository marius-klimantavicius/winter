using System;
using OpenTK.Graphics.Vulkan;

namespace NvgSharp.OpenTK.Vulkan;

public sealed unsafe class VkNvgTexture : IDisposable
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

    internal VkNvgTexture(VkDevice device, VkAllocationCallbacks* allocator)
    {
        _device = device;
        _allocator = allocator;
    }

    ~VkNvgTexture()
    {
        Dispose();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        try
        {
            VkNvgContext.DeleteTexture(this, _device, _allocator);
        }
        catch
        {
            // Empty
        }
    }
}