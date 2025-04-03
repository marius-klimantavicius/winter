﻿using OpenTK.Graphics.Egl;

namespace OpenTK.Platform.Native.ANGLE;

internal class ANGLEOpenGLContextHandle : OpenGLContextHandle
{
    public EGLSurface EglSurface;
    public EGLContext EglContext;

    public ANGLEOpenGLContextHandle? SharedContext;

    public int SwapInterval = 0;

    public ANGLEOpenGLContextHandle(EGLSurface eglSurface, EGLContext eglContext, ANGLEOpenGLContextHandle? sharedContext)
    {
        EglSurface = eglSurface;
        EglContext = eglContext;
        SharedContext = sharedContext;
    }
}