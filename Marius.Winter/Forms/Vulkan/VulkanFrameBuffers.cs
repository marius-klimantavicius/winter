using OpenTK.Graphics.Vulkan;

namespace Marius.Winter.Forms.Vulkan;

internal struct VulkanFrameBuffers
{
    public VkSwapchainKHR swap_chain;
    public VulkanSwapchain[] swap_chain_buffers;
    public uint swapchain_image_count;
    public VkFramebuffer[] framebuffers;

    public uint current_frame_buffer;
    public uint current_frame;
    public uint num_swaps;

    public VkExtent2D buffer_size;

    public VkRenderPass render_pass;

    public VkFormat format;
    public VulkanDepthBuffer depth;
    public VkSemaphore[] present_complete_semaphore;
    public VkSemaphore[] render_complete_semaphore;
    public VkFence[] flight_fence;
}