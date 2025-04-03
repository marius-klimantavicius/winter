using System.Runtime.InteropServices;
using OpenTK.Graphics.Vulkan;

namespace NvgSharp.OpenTK.Vulkan;

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct VkNvgBuffer
{
    public VkBuffer Buffer;
    public VkDeviceMemory DeviceMemory;
    public ulong DeviceSize;
    public void* Mapped;
    public bool IsInitialized;
}