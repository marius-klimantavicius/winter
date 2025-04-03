using OpenTK.Graphics.Vulkan;

namespace Marius.Winter.Forms.Vulkan;

internal struct VulkanFrameBuffers
{
    public VkSwapchainKHR Swapchain;
    public VulkanSwapchain[] SwapchainBuffers;
    public uint SwapchainCount => (uint)SwapchainBuffers.Length;
    public VkFramebuffer[] Framebuffers;

    public uint CurrentFrameBuffer;
    public uint CurrentFrame;
    public uint SwapCount;

    public VkExtent2D BufferSize;

    public VkRenderPass RenderPass;

    public VulkanDepthBuffer DepthBuffer;
    public VkSemaphore[] PresentCompleteSemaphore;
    public VkSemaphore[] RenderCompleteSemaphore;
    public VkFence[] FlightFence;
}