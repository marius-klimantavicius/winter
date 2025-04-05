using System;
using System.Drawing;
using OpenTK.Graphics.Vulkan;

namespace NvgSharp.OpenTK.Vulkan;

public class VulkanRenderer : INvgRenderer
{
    private readonly VulkanContext _context;

    public VulkanRenderer(VulkanCreateInfo createInfo, VulkanFrameBuffer frameBuffer, VkQueue queue, bool edgeAntiAlias = true, bool stencilStrokes = true)
    {
        _context = new VulkanContext(createInfo, frameBuffer, queue, edgeAntiAlias, stencilStrokes);
        _context.Create();
    }

    public object CreateTexture(int width, int height)
    {
        return _context.CreateTexture(width, height);
    }

    public Point GetTextureSize(object texture)
    {
        var tex = (VulkanTexture)texture;
        _context.GetTextureSize(tex, out var w, out var h);
        return new Point(w, h);
    }

    public void SetTextureData(object texture, Rectangle bounds, byte[] data)
    {
        var tex = (VulkanTexture)texture;
        _context.UpdateTexture(tex, bounds.X, bounds.Y, bounds.Width, bounds.Height, data);
    }

    public void Draw(float devicePixelRatio, ReadOnlySpan<CallInfo> calls, Vertex[] vertexes)
    {
        _context.Draw(calls, vertexes);
    }

    public void Viewport(int width, int height)
    {
        _context.Viewport(width, height);
    }

    public void BeforeRender()
    {
        _context.BeforeRender();
    }
}