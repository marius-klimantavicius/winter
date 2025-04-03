using OpenTK.Graphics.Vulkan;

namespace Marius.Winter.Forms.Vulkan;

internal struct VulkanDepthBuffer
{
    public VkFormat format;

    public VkImage image;
    public VkDeviceMemory mem;
    public VkImageView view;
}