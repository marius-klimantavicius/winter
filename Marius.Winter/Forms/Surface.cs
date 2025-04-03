using NvgSharp;
using OpenTK.Mathematics;
using OpenTK.Platform;

namespace Marius.Winter.Forms;

public abstract class Surface
{
    public abstract WindowHandle NativeWindow { get; }
    public abstract NvgContext Context { get; }

    public abstract void PrepareFrame(Color4<Rgba> backgroundColor);
    public abstract void SubmitFrame();
}