using System.Runtime.InteropServices;
using OpenTK.Graphics.Vulkan;

namespace NvgSharp.OpenTK.Vulkan;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct VulkanCreateInfo
{
    public VkPhysicalDevice PhysicalDevice;
    public VkDevice Device;
    public VkCommandBuffer[] CommandBuffer;
    public VkCommandBuffer[] SecondaryCommandBuffer;
    public VkAllocationCallbacks* Allocator; // Allocator for vulkan. can be null
    public VulkanExtensions Extensions;
}