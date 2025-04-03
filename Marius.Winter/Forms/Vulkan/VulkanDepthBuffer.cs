using OpenTK.Graphics.Vulkan;

namespace Marius.Winter.Forms.Vulkan;

internal struct VulkanDepthBuffer
{
    public VkFormat Format;

    public VkImage Image;
    public VkDeviceMemory DeviceMemory;
    public VkImageView ImageView;
}