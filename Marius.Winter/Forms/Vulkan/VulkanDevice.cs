using OpenTK.Graphics.Vulkan;

namespace Marius.Winter.Forms.Vulkan;

internal struct VulkanDevice
{
    public VkPhysicalDevice gpu;
    public VkPhysicalDeviceProperties gpuProperties;
    public VkPhysicalDeviceMemoryProperties memoryProperties;

    public VkQueueFamilyProperties[] queueFamilyProperties;

    public uint graphicsQueueFamilyIndex;
    public uint presentIndex;

    public VkDevice device;

    public VkCommandPool commandPool;
}