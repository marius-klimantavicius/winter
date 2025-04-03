using OpenTK.Graphics.Vulkan;

namespace NvgSharp.OpenTK.Vulkan;

public abstract class VkNvgFrameBuffer
{
    public abstract VkRenderPass RenderPass { get; }
    public abstract uint SwapChainImageCount { get; }
    public abstract uint CurrentFrame { get; }
}