using OpenTK.Graphics.Vulkan;

namespace Marius.Winter.Forms.Vulkan;

internal struct VulkanSwapchain
{
    public VkImage Image;
    public VkImageView ImageView;
}