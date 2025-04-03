using System;
using NvgSharp;
using NvgSharp.OpenTK.OpenGL;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Platform;

namespace Marius.Winter.Forms;

public class OpenGLSurfaceFactory : SurfaceFactory
{
    private readonly bool _hasDepthBuffer;
    private readonly bool _hasStencilBuffer;
    private readonly int _glMajor;
    private readonly int _glMinor;

    private bool _hasFloatBuffer;

    public OpenGLSurfaceFactory(
        bool hasDepthBuffer = true,
        bool hasStencilBuffer = true,
        bool hasFloatBuffer = false,
        int glMajor = 3,
        int glMinor = 2
    )
    {
        _hasDepthBuffer = hasDepthBuffer;
        _hasStencilBuffer = hasStencilBuffer;
        _hasFloatBuffer = hasFloatBuffer;
        _glMajor = glMajor;
        _glMinor = glMinor;
    }

    public override Surface Create(Vector2i size, bool isFullScreen, bool resizable)
    {
        var colorBits = 8;
        var depthBits = 0;
        var stencilBits = 0;

        if (_hasStencilBuffer && !_hasDepthBuffer)
            throw new ArgumentException("hasStencilBuffer = True requires hasDepthBuffer = True");

        if (_hasDepthBuffer)
            depthBits = 32;

        if (_hasStencilBuffer)
        {
            depthBits = 24;
            stencilBits = 8;
        }

        if (_hasFloatBuffer)
            colorBits = 16;

        var hints = new OpenGLGraphicsApiHints
        {
            RedColorBits = colorBits,
            GreenColorBits = colorBits,
            BlueColorBits = colorBits,
            AlphaColorBits = colorBits,
            StencilBits = (ContextStencilBits)stencilBits,
            DepthBits = (ContextDepthBits)depthBits,
            PixelFormat = _hasFloatBuffer ? ContextPixelFormat.RGBAFloat : ContextPixelFormat.RGBA,
            Version = new Version(_glMajor, _glMinor),
            ForwardCompatibleFlag = true,
            Profile = OpenGLProfile.Core,
        };

        var monitor = isFullScreen ? Toolkit.Display.OpenPrimary() : null;
        var window = default(WindowHandle);
        for (var i = 0; i < 2; i++)
        {
            try
            {
                window = Toolkit.Window.Create(hints);
                if (window == null)
                    throw new Exception("Could not create window");

                if (isFullScreen)
                    Toolkit.Window.SetFullscreenDisplay(window, monitor);
                else
                    Toolkit.Window.SetSize(window, size);

                break;
            }
            catch
            {
                if (_hasFloatBuffer)
                    _hasFloatBuffer = false;

                hints.PixelFormat = ContextPixelFormat.RGBA;
            }
        }

        if (window == null)
            throw new Exception($"Could not create an OpenGL {_glMajor}.{_glMinor} context!");

        if (!resizable)
            Toolkit.Window.SetBorderStyle(window, WindowBorderStyle.FixedBorder);

        return new OpenGLSurface(window, _hasStencilBuffer);
    }

    private class OpenGLSurface : Surface
    {
        private readonly WindowHandle _window;
        private readonly OpenGLContextHandle _nativeContext;

        private Vector2i _fbSize;
        private Vector2i _size;
        private float _pixelRatio;

        public override WindowHandle NativeWindow => _window;
        public override NvgContext Context { get; }

        public OpenGLSurface(WindowHandle window, bool hasStencilBuffer)
        {
            _window = window;

            _nativeContext = Toolkit.OpenGL.CreateFromWindow(_window);
            Toolkit.OpenGL.SetCurrentContext(_nativeContext);
            GLLoader.LoadBindings(Toolkit.OpenGL.GetBindingsContext(_nativeContext));

            Toolkit.Window.GetFramebufferSize(_window, out _fbSize);

            GL.Viewport(0, 0, _fbSize.X, _fbSize.Y);
            //GL.ClearColor(_backgroundColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);
            Toolkit.OpenGL.SetSwapInterval(0);
            Toolkit.OpenGL.SwapBuffers(_nativeContext);

            var renderer = new Renderer(stencilStrokes: hasStencilBuffer);
            Context = new NvgContext(renderer, true, hasStencilBuffer);
        }

        public override void PrepareFrame(Color4<Rgba> backgroundColor)
        {
            Toolkit.OpenGL.SetCurrentContext(_nativeContext);
            Toolkit.Window.GetFramebufferSize(_window, out _fbSize);
            Toolkit.Window.GetClientSize(_window, out _size);

            var size = _size.ToVector2() / _pixelRatio;
            _size = new Vector2i((int)size.X, (int)size.Y);

            GL.Viewport(0, 0, _fbSize.X, _fbSize.Y);

            GL.ClearColor(backgroundColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);
        }

        public override void SubmitFrame()
        {
            Toolkit.OpenGL.SwapBuffers(_nativeContext);
        }
    }
}