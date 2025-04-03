using OpenTK.Graphics.Vulkan;

namespace Marius.Winter.Forms.Vulkan;

internal struct VulkanDevice
{
    public VkPhysicalDevice PhysicalDevice;
    public VkPhysicalDeviceProperties PhysicalDeviceProperties;
    public VkPhysicalDeviceMemoryProperties PhysicalDeviceMemoryProperties;

    public VkQueueFamilyProperties[] QueueFamilyProperties;

    public uint GraphicsQueueFamilyIndex;
    public uint PresentIndex;

    public VkDevice Device;
    public VkCommandPool CommandPool;
}