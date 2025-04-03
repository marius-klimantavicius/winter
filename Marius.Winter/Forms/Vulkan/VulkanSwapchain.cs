using OpenTK.Graphics.Vulkan;

namespace Marius.Winter.Forms.Vulkan;

internal struct VulkanSwapchain
{
    public VkImage image;
    public VkImageView view;
}