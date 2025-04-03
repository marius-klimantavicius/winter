using System;
using System.Drawing;
using OpenTK.Graphics.Vulkan;

namespace NvgSharp.OpenTK.Vulkan;

public class Renderer : INvgRenderer
{
    private readonly VkNvgContext _context;

    public Renderer(VkNvgCreateInfo createInfo, VkNvgFrameBuffer frameBuffer, VkQueue queue, bool edgeAntiAlias = true, bool stencilStrokes = true)
    {
        _context = new VkNvgContext(createInfo, frameBuffer, queue, edgeAntiAlias, stencilStrokes);
        _context.Create();
    }

    public object CreateTexture(int width, int height)
    {
        return _context.CreateTexture(width, height);
    }

    public Point GetTextureSize(object texture)
    {
        var tex = (VkNvgTexture)texture;
        _context.GetTextureSize(tex, out var w, out var h);
        return new Point(w, h);
    }

    public void SetTextureData(object texture, Rectangle bounds, byte[] data)
    {
        var tex = (VkNvgTexture)texture;
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