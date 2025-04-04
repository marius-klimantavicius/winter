// This file is auto generated, do not edit. Generated: 2025-03-27 19:03:30 GMT+01:00

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenTK.Core.Native;
using OpenTK.Mathematics;

namespace OpenTK.Graphics.OpenGLES2;

public static unsafe partial class GL
{
    /// <inheritdoc cref="BindAttribLocation(int, uint, byte*)"/>
    public static unsafe void BindAttribLocation(int program, uint index, string name)
    {
        byte* name_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(name);
        BindAttribLocation(program, index, name_ptr);
        Marshal.FreeCoTaskMem((IntPtr)name_ptr);
    }
    /// <inheritdoc cref="BufferData(BufferTarget, nint, void*, BufferUsage)"/>
    public static unsafe void BufferData(BufferTarget target, nint size, IntPtr data, BufferUsage usage)
    {
        void* data_vptr = (void*)data;
        BufferData(target, size, data_vptr, usage);
    }
    /// <inheritdoc cref="BufferData(BufferTarget, nint, void*, BufferUsage)"/>
    public static unsafe void BufferData<T1>(BufferTarget target, nint size, ReadOnlySpan<T1> data, BufferUsage usage)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = data)
        {
            BufferData(target, size, data_ptr, usage);
        }
    }
    /// <inheritdoc cref="BufferData(BufferTarget, nint, void*, BufferUsage)"/>
    public static unsafe void BufferData<T1>(BufferTarget target, nint size, T1[] data, BufferUsage usage)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = data)
        {
            BufferData(target, size, data_ptr, usage);
        }
    }
    /// <inheritdoc cref="BufferData(BufferTarget, nint, void*, BufferUsage)"/>
    public static unsafe void BufferData<T1>(BufferTarget target, nint size, ref readonly T1 data, BufferUsage usage)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = &data)
        {
            BufferData(target, size, data_ptr, usage);
        }
    }
    /// <inheritdoc cref="BufferSubData(BufferTarget, IntPtr, nint, void*)"/>
    public static unsafe void BufferSubData(BufferTarget target, IntPtr offset, nint size, IntPtr data)
    {
        void* data_vptr = (void*)data;
        BufferSubData(target, offset, size, data_vptr);
    }
    /// <inheritdoc cref="BufferSubData(BufferTarget, IntPtr, nint, void*)"/>
    public static unsafe void BufferSubData<T1>(BufferTarget target, IntPtr offset, nint size, ReadOnlySpan<T1> data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = data)
        {
            BufferSubData(target, offset, size, data_ptr);
        }
    }
    /// <inheritdoc cref="BufferSubData(BufferTarget, IntPtr, nint, void*)"/>
    public static unsafe void BufferSubData<T1>(BufferTarget target, IntPtr offset, nint size, T1[] data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = data)
        {
            BufferSubData(target, offset, size, data_ptr);
        }
    }
    /// <inheritdoc cref="BufferSubData(BufferTarget, IntPtr, nint, void*)"/>
    public static unsafe void BufferSubData<T1>(BufferTarget target, IntPtr offset, nint size, ref readonly T1 data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = &data)
        {
            BufferSubData(target, offset, size, data_ptr);
        }
    }
    /// <inheritdoc cref="ClearBufferfi(Buffer, int, float, int)"/>
    public static unsafe void ClearBuffer(Buffer buffer, int drawbuffer, float depth, int stencil)
    {
        ClearBufferfi(buffer, drawbuffer, depth, stencil);
    }
    /// <inheritdoc cref="ClearBufferfv(Buffer, int, float*)"/>
    public static unsafe void ClearBufferf(Buffer buffer, int drawbuffer, ReadOnlySpan<float> value)
    {
        fixed (float* value_ptr = value)
        {
            ClearBufferfv(buffer, drawbuffer, value_ptr);
        }
    }
    /// <inheritdoc cref="ClearBufferfv(Buffer, int, float*)"/>
    public static unsafe void ClearBufferf(Buffer buffer, int drawbuffer, float[] value)
    {
        fixed (float* value_ptr = value)
        {
            ClearBufferfv(buffer, drawbuffer, value_ptr);
        }
    }
    /// <inheritdoc cref="ClearBufferfv(Buffer, int, float*)"/>
    public static unsafe void ClearBufferf(Buffer buffer, int drawbuffer, ref readonly float value)
    {
        fixed (float* value_ptr = &value)
        {
            ClearBufferfv(buffer, drawbuffer, value_ptr);
        }
    }
    /// <inheritdoc cref="ClearBufferiv(Buffer, int, int*)"/>
    public static unsafe void ClearBufferi(Buffer buffer, int drawbuffer, ReadOnlySpan<int> value)
    {
        fixed (int* value_ptr = value)
        {
            ClearBufferiv(buffer, drawbuffer, value_ptr);
        }
    }
    /// <inheritdoc cref="ClearBufferiv(Buffer, int, int*)"/>
    public static unsafe void ClearBufferi(Buffer buffer, int drawbuffer, int[] value)
    {
        fixed (int* value_ptr = value)
        {
            ClearBufferiv(buffer, drawbuffer, value_ptr);
        }
    }
    /// <inheritdoc cref="ClearBufferiv(Buffer, int, int*)"/>
    public static unsafe void ClearBufferi(Buffer buffer, int drawbuffer, ref readonly int value)
    {
        fixed (int* value_ptr = &value)
        {
            ClearBufferiv(buffer, drawbuffer, value_ptr);
        }
    }
    /// <inheritdoc cref="ClearBufferuiv(Buffer, int, uint*)"/>
    public static unsafe void ClearBufferui(Buffer buffer, int drawbuffer, ReadOnlySpan<uint> value)
    {
        fixed (uint* value_ptr = value)
        {
            ClearBufferuiv(buffer, drawbuffer, value_ptr);
        }
    }
    /// <inheritdoc cref="ClearBufferuiv(Buffer, int, uint*)"/>
    public static unsafe void ClearBufferui(Buffer buffer, int drawbuffer, uint[] value)
    {
        fixed (uint* value_ptr = value)
        {
            ClearBufferuiv(buffer, drawbuffer, value_ptr);
        }
    }
    /// <inheritdoc cref="ClearBufferuiv(Buffer, int, uint*)"/>
    public static unsafe void ClearBufferui(Buffer buffer, int drawbuffer, ref readonly uint value)
    {
        fixed (uint* value_ptr = &value)
        {
            ClearBufferuiv(buffer, drawbuffer, value_ptr);
        }
    }
    /// <inheritdoc cref="CompressedTexImage2D(TextureTarget, int, InternalFormat, int, int, int, int, void*)"/>
    public static unsafe void CompressedTexImage2D(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, int imageSize, IntPtr data)
    {
        void* data_vptr = (void*)data;
        CompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, data_vptr);
    }
    /// <inheritdoc cref="CompressedTexImage2D(TextureTarget, int, InternalFormat, int, int, int, int, void*)"/>
    public static unsafe void CompressedTexImage2D<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, int imageSize, ReadOnlySpan<T1> data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = data)
        {
            CompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, data_ptr);
        }
    }
    /// <inheritdoc cref="CompressedTexImage2D(TextureTarget, int, InternalFormat, int, int, int, int, void*)"/>
    public static unsafe void CompressedTexImage2D<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, int imageSize, T1[] data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = data)
        {
            CompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, data_ptr);
        }
    }
    /// <inheritdoc cref="CompressedTexImage2D(TextureTarget, int, InternalFormat, int, int, int, int, void*)"/>
    public static unsafe void CompressedTexImage2D<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, int imageSize, ref readonly T1 data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = &data)
        {
            CompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, data_ptr);
        }
    }
    /// <inheritdoc cref="CompressedTexImage3D(TextureTarget, int, InternalFormat, int, int, int, int, int, void*)"/>
    public static unsafe void CompressedTexImage3D(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, int imageSize, IntPtr data)
    {
        void* data_vptr = (void*)data;
        CompressedTexImage3D(target, level, internalformat, width, height, depth, border, imageSize, data_vptr);
    }
    /// <inheritdoc cref="CompressedTexImage3D(TextureTarget, int, InternalFormat, int, int, int, int, int, void*)"/>
    public static unsafe void CompressedTexImage3D<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, int imageSize, ReadOnlySpan<T1> data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = data)
        {
            CompressedTexImage3D(target, level, internalformat, width, height, depth, border, imageSize, data_ptr);
        }
    }
    /// <inheritdoc cref="CompressedTexImage3D(TextureTarget, int, InternalFormat, int, int, int, int, int, void*)"/>
    public static unsafe void CompressedTexImage3D<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, int imageSize, T1[] data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = data)
        {
            CompressedTexImage3D(target, level, internalformat, width, height, depth, border, imageSize, data_ptr);
        }
    }
    /// <inheritdoc cref="CompressedTexImage3D(TextureTarget, int, InternalFormat, int, int, int, int, int, void*)"/>
    public static unsafe void CompressedTexImage3D<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, int imageSize, ref readonly T1 data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = &data)
        {
            CompressedTexImage3D(target, level, internalformat, width, height, depth, border, imageSize, data_ptr);
        }
    }
    /// <inheritdoc cref="CompressedTexSubImage2D(TextureTarget, int, int, int, int, int, InternalFormat, int, void*)"/>
    public static unsafe void CompressedTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, InternalFormat format, int imageSize, IntPtr data)
    {
        void* data_vptr = (void*)data;
        CompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, data_vptr);
    }
    /// <inheritdoc cref="CompressedTexSubImage2D(TextureTarget, int, int, int, int, int, InternalFormat, int, void*)"/>
    public static unsafe void CompressedTexSubImage2D<T1>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, InternalFormat format, int imageSize, ReadOnlySpan<T1> data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = data)
        {
            CompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, data_ptr);
        }
    }
    /// <inheritdoc cref="CompressedTexSubImage2D(TextureTarget, int, int, int, int, int, InternalFormat, int, void*)"/>
    public static unsafe void CompressedTexSubImage2D<T1>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, InternalFormat format, int imageSize, T1[] data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = data)
        {
            CompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, data_ptr);
        }
    }
    /// <inheritdoc cref="CompressedTexSubImage2D(TextureTarget, int, int, int, int, int, InternalFormat, int, void*)"/>
    public static unsafe void CompressedTexSubImage2D<T1>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, InternalFormat format, int imageSize, ref readonly T1 data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = &data)
        {
            CompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, data_ptr);
        }
    }
    /// <inheritdoc cref="CompressedTexSubImage3D(TextureTarget, int, int, int, int, int, int, int, InternalFormat, int, void*)"/>
    public static unsafe void CompressedTexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, IntPtr data)
    {
        void* data_vptr = (void*)data;
        CompressedTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data_vptr);
    }
    /// <inheritdoc cref="CompressedTexSubImage3D(TextureTarget, int, int, int, int, int, int, int, InternalFormat, int, void*)"/>
    public static unsafe void CompressedTexSubImage3D<T1>(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, ReadOnlySpan<T1> data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = data)
        {
            CompressedTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data_ptr);
        }
    }
    /// <inheritdoc cref="CompressedTexSubImage3D(TextureTarget, int, int, int, int, int, int, int, InternalFormat, int, void*)"/>
    public static unsafe void CompressedTexSubImage3D<T1>(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, T1[] data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = data)
        {
            CompressedTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data_ptr);
        }
    }
    /// <inheritdoc cref="CompressedTexSubImage3D(TextureTarget, int, int, int, int, int, int, int, InternalFormat, int, void*)"/>
    public static unsafe void CompressedTexSubImage3D<T1>(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, ref readonly T1 data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = &data)
        {
            CompressedTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data_ptr);
        }
    }
    /// <inheritdoc cref="CreateShaderProgramv(ShaderType, int, byte**)"/>
    public static unsafe int CreateShaderProgram(ShaderType type, int count, string[] strings)
    {
        byte** strings_ptr = (byte**)MarshalTk.StringArrayToCoTaskMemUTF8(strings);
        var returnValue = CreateShaderProgramv(type, count, strings_ptr);
        MarshalTk.FreeStringArrayCoTaskMem((IntPtr)strings_ptr, strings.Length);
        return returnValue;
    }
    /// <inheritdoc cref="DebugMessageCallback(IntPtr, void*)"/>
    public static unsafe void DebugMessageCallback(GLDebugProc callback, IntPtr userParam)
    {
        void* userParam_vptr = (void*)userParam;
        IntPtr callback_ptr = Marshal.GetFunctionPointerForDelegate(callback);
        DebugMessageCallback(callback_ptr, userParam_vptr);
    }
    /// <inheritdoc cref="DebugMessageCallback(IntPtr, void*)"/>
    public static unsafe void DebugMessageCallback<T1>(GLDebugProc callback, ReadOnlySpan<T1> userParam)
        where T1 : unmanaged
    {
        fixed (void* userParam_ptr = userParam)
        {
            IntPtr callback_ptr = Marshal.GetFunctionPointerForDelegate(callback);
            DebugMessageCallback(callback_ptr, userParam_ptr);
        }
    }
    /// <inheritdoc cref="DebugMessageCallback(IntPtr, void*)"/>
    public static unsafe void DebugMessageCallback<T1>(GLDebugProc callback, T1[] userParam)
        where T1 : unmanaged
    {
        fixed (void* userParam_ptr = userParam)
        {
            IntPtr callback_ptr = Marshal.GetFunctionPointerForDelegate(callback);
            DebugMessageCallback(callback_ptr, userParam_ptr);
        }
    }
    /// <inheritdoc cref="DebugMessageCallback(IntPtr, void*)"/>
    public static unsafe void DebugMessageCallback<T1>(GLDebugProc callback, ref readonly T1 userParam)
        where T1 : unmanaged
    {
        fixed (void* userParam_ptr = &userParam)
        {
            IntPtr callback_ptr = Marshal.GetFunctionPointerForDelegate(callback);
            DebugMessageCallback(callback_ptr, userParam_ptr);
        }
    }
    /// <inheritdoc cref="DebugMessageControl(DebugSource, DebugType, DebugSeverity, int, uint*, bool)"/>
    public static unsafe void DebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, int count, ReadOnlySpan<uint> ids, bool enabled)
    {
        fixed (uint* ids_ptr = ids)
        {
            DebugMessageControl(source, type, severity, count, ids_ptr, enabled);
        }
    }
    /// <inheritdoc cref="DebugMessageControl(DebugSource, DebugType, DebugSeverity, int, uint*, bool)"/>
    public static unsafe void DebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, int count, uint[] ids, bool enabled)
    {
        fixed (uint* ids_ptr = ids)
        {
            DebugMessageControl(source, type, severity, count, ids_ptr, enabled);
        }
    }
    /// <inheritdoc cref="DebugMessageControl(DebugSource, DebugType, DebugSeverity, int, uint*, bool)"/>
    public static unsafe void DebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, int count, ref readonly uint ids, bool enabled)
    {
        fixed (uint* ids_ptr = &ids)
        {
            DebugMessageControl(source, type, severity, count, ids_ptr, enabled);
        }
    }
    /// <inheritdoc cref="DebugMessageInsert(DebugSource, DebugType, uint, DebugSeverity, int, byte*)"/>
    public static unsafe void DebugMessageInsert(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, string buf)
    {
        byte* buf_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(buf);
        DebugMessageInsert(source, type, id, severity, length, buf_ptr);
        Marshal.FreeCoTaskMem((IntPtr)buf_ptr);
    }
    /// <inheritdoc cref="DeleteBuffers(int, int*)"/>
    public static unsafe void DeleteBuffer(int buffer)
    {
        int n = 1;
        int* buffers_handle = &buffer;
        DeleteBuffers(n, buffers_handle);
    }
    /// <inheritdoc cref="DeleteBuffers(int, int*)"/>
    public static unsafe void DeleteBuffers(int n, ReadOnlySpan<int> buffers)
    {
        fixed (int* buffers_ptr = buffers)
        {
            DeleteBuffers(n, buffers_ptr);
        }
    }
    /// <inheritdoc cref="DeleteBuffers(int, int*)"/>
    public static unsafe void DeleteBuffers(int n, int[] buffers)
    {
        fixed (int* buffers_ptr = buffers)
        {
            DeleteBuffers(n, buffers_ptr);
        }
    }
    /// <inheritdoc cref="DeleteBuffers(int, int*)"/>
    public static unsafe void DeleteBuffers(int n, ref readonly int buffers)
    {
        fixed (int* buffers_ptr = &buffers)
        {
            DeleteBuffers(n, buffers_ptr);
        }
    }
    /// <inheritdoc cref="DeleteFramebuffers(int, int*)"/>
    public static unsafe void DeleteFramebuffer(int framebuffer)
    {
        int n = 1;
        int* framebuffers_handle = &framebuffer;
        DeleteFramebuffers(n, framebuffers_handle);
    }
    /// <inheritdoc cref="DeleteFramebuffers(int, int*)"/>
    public static unsafe void DeleteFramebuffers(int n, ReadOnlySpan<int> framebuffers)
    {
        fixed (int* framebuffers_ptr = framebuffers)
        {
            DeleteFramebuffers(n, framebuffers_ptr);
        }
    }
    /// <inheritdoc cref="DeleteFramebuffers(int, int*)"/>
    public static unsafe void DeleteFramebuffers(int n, int[] framebuffers)
    {
        fixed (int* framebuffers_ptr = framebuffers)
        {
            DeleteFramebuffers(n, framebuffers_ptr);
        }
    }
    /// <inheritdoc cref="DeleteFramebuffers(int, int*)"/>
    public static unsafe void DeleteFramebuffers(int n, ref readonly int framebuffers)
    {
        fixed (int* framebuffers_ptr = &framebuffers)
        {
            DeleteFramebuffers(n, framebuffers_ptr);
        }
    }
    /// <inheritdoc cref="DeleteProgramPipelines(int, int*)"/>
    public static unsafe void DeleteProgramPipeline(int pipeline)
    {
        int n = 1;
        int* pipelines_handle = &pipeline;
        DeleteProgramPipelines(n, pipelines_handle);
    }
    /// <inheritdoc cref="DeleteProgramPipelines(int, int*)"/>
    public static unsafe void DeleteProgramPipelines(int n, ReadOnlySpan<int> pipelines)
    {
        fixed (int* pipelines_ptr = pipelines)
        {
            DeleteProgramPipelines(n, pipelines_ptr);
        }
    }
    /// <inheritdoc cref="DeleteProgramPipelines(int, int*)"/>
    public static unsafe void DeleteProgramPipelines(int n, int[] pipelines)
    {
        fixed (int* pipelines_ptr = pipelines)
        {
            DeleteProgramPipelines(n, pipelines_ptr);
        }
    }
    /// <inheritdoc cref="DeleteProgramPipelines(int, int*)"/>
    public static unsafe void DeleteProgramPipelines(int n, ref readonly int pipelines)
    {
        fixed (int* pipelines_ptr = &pipelines)
        {
            DeleteProgramPipelines(n, pipelines_ptr);
        }
    }
    /// <inheritdoc cref="DeleteQueries(int, int*)"/>
    public static unsafe void DeleteQuery(int id)
    {
        int n = 1;
        int* ids_handle = &id;
        DeleteQueries(n, ids_handle);
    }
    /// <inheritdoc cref="DeleteQueries(int, int*)"/>
    public static unsafe void DeleteQueries(int n, ReadOnlySpan<int> ids)
    {
        fixed (int* ids_ptr = ids)
        {
            DeleteQueries(n, ids_ptr);
        }
    }
    /// <inheritdoc cref="DeleteQueries(int, int*)"/>
    public static unsafe void DeleteQueries(int n, int[] ids)
    {
        fixed (int* ids_ptr = ids)
        {
            DeleteQueries(n, ids_ptr);
        }
    }
    /// <inheritdoc cref="DeleteQueries(int, int*)"/>
    public static unsafe void DeleteQueries(int n, ref readonly int ids)
    {
        fixed (int* ids_ptr = &ids)
        {
            DeleteQueries(n, ids_ptr);
        }
    }
    /// <inheritdoc cref="DeleteRenderbuffers(int, int*)"/>
    public static unsafe void DeleteRenderbuffer(int renderbuffer)
    {
        int n = 1;
        int* renderbuffers_handle = &renderbuffer;
        DeleteRenderbuffers(n, renderbuffers_handle);
    }
    /// <inheritdoc cref="DeleteRenderbuffers(int, int*)"/>
    public static unsafe void DeleteRenderbuffers(int n, ReadOnlySpan<int> renderbuffers)
    {
        fixed (int* renderbuffers_ptr = renderbuffers)
        {
            DeleteRenderbuffers(n, renderbuffers_ptr);
        }
    }
    /// <inheritdoc cref="DeleteRenderbuffers(int, int*)"/>
    public static unsafe void DeleteRenderbuffers(int n, int[] renderbuffers)
    {
        fixed (int* renderbuffers_ptr = renderbuffers)
        {
            DeleteRenderbuffers(n, renderbuffers_ptr);
        }
    }
    /// <inheritdoc cref="DeleteRenderbuffers(int, int*)"/>
    public static unsafe void DeleteRenderbuffers(int n, ref readonly int renderbuffers)
    {
        fixed (int* renderbuffers_ptr = &renderbuffers)
        {
            DeleteRenderbuffers(n, renderbuffers_ptr);
        }
    }
    /// <inheritdoc cref="DeleteSamplers(int, int*)"/>
    public static unsafe void DeleteSampler(int sampler)
    {
        int count = 1;
        int* samplers_handle = &sampler;
        DeleteSamplers(count, samplers_handle);
    }
    /// <inheritdoc cref="DeleteSamplers(int, int*)"/>
    public static unsafe void DeleteSamplers(int count, ReadOnlySpan<int> samplers)
    {
        fixed (int* samplers_ptr = samplers)
        {
            DeleteSamplers(count, samplers_ptr);
        }
    }
    /// <inheritdoc cref="DeleteSamplers(int, int*)"/>
    public static unsafe void DeleteSamplers(int count, int[] samplers)
    {
        fixed (int* samplers_ptr = samplers)
        {
            DeleteSamplers(count, samplers_ptr);
        }
    }
    /// <inheritdoc cref="DeleteSamplers(int, int*)"/>
    public static unsafe void DeleteSamplers(int count, ref readonly int samplers)
    {
        fixed (int* samplers_ptr = &samplers)
        {
            DeleteSamplers(count, samplers_ptr);
        }
    }
    /// <inheritdoc cref="DeleteTextures(int, int*)"/>
    public static unsafe void DeleteTexture(int texture)
    {
        int n = 1;
        int* textures_handle = &texture;
        DeleteTextures(n, textures_handle);
    }
    /// <inheritdoc cref="DeleteTextures(int, int*)"/>
    public static unsafe void DeleteTextures(int n, ReadOnlySpan<int> textures)
    {
        fixed (int* textures_ptr = textures)
        {
            DeleteTextures(n, textures_ptr);
        }
    }
    /// <inheritdoc cref="DeleteTextures(int, int*)"/>
    public static unsafe void DeleteTextures(int n, int[] textures)
    {
        fixed (int* textures_ptr = textures)
        {
            DeleteTextures(n, textures_ptr);
        }
    }
    /// <inheritdoc cref="DeleteTextures(int, int*)"/>
    public static unsafe void DeleteTextures(int n, ref readonly int textures)
    {
        fixed (int* textures_ptr = &textures)
        {
            DeleteTextures(n, textures_ptr);
        }
    }
    /// <inheritdoc cref="DeleteTransformFeedbacks(int, int*)"/>
    public static unsafe void DeleteTransformFeedback(int id)
    {
        int n = 1;
        int* ids_handle = &id;
        DeleteTransformFeedbacks(n, ids_handle);
    }
    /// <inheritdoc cref="DeleteTransformFeedbacks(int, int*)"/>
    public static unsafe void DeleteTransformFeedbacks(int n, ReadOnlySpan<int> ids)
    {
        fixed (int* ids_ptr = ids)
        {
            DeleteTransformFeedbacks(n, ids_ptr);
        }
    }
    /// <inheritdoc cref="DeleteTransformFeedbacks(int, int*)"/>
    public static unsafe void DeleteTransformFeedbacks(int n, int[] ids)
    {
        fixed (int* ids_ptr = ids)
        {
            DeleteTransformFeedbacks(n, ids_ptr);
        }
    }
    /// <inheritdoc cref="DeleteTransformFeedbacks(int, int*)"/>
    public static unsafe void DeleteTransformFeedbacks(int n, ref readonly int ids)
    {
        fixed (int* ids_ptr = &ids)
        {
            DeleteTransformFeedbacks(n, ids_ptr);
        }
    }
    /// <inheritdoc cref="DeleteVertexArrays(int, int*)"/>
    public static unsafe void DeleteVertexArray(int array)
    {
        int n = 1;
        int* arrays_handle = &array;
        DeleteVertexArrays(n, arrays_handle);
    }
    /// <inheritdoc cref="DeleteVertexArrays(int, int*)"/>
    public static unsafe void DeleteVertexArrays(int n, ReadOnlySpan<int> arrays)
    {
        fixed (int* arrays_ptr = arrays)
        {
            DeleteVertexArrays(n, arrays_ptr);
        }
    }
    /// <inheritdoc cref="DeleteVertexArrays(int, int*)"/>
    public static unsafe void DeleteVertexArrays(int n, int[] arrays)
    {
        fixed (int* arrays_ptr = arrays)
        {
            DeleteVertexArrays(n, arrays_ptr);
        }
    }
    /// <inheritdoc cref="DeleteVertexArrays(int, int*)"/>
    public static unsafe void DeleteVertexArrays(int n, ref readonly int arrays)
    {
        fixed (int* arrays_ptr = &arrays)
        {
            DeleteVertexArrays(n, arrays_ptr);
        }
    }
    /// <inheritdoc cref="DrawArraysIndirect(PrimitiveType, void*)"/>
    public static unsafe void DrawArraysIndirect(PrimitiveType mode, IntPtr indirect)
    {
        void* indirect_vptr = (void*)indirect;
        DrawArraysIndirect(mode, indirect_vptr);
    }
    /// <inheritdoc cref="DrawArraysIndirect(PrimitiveType, void*)"/>
    public static unsafe void DrawArraysIndirect<T1>(PrimitiveType mode, ReadOnlySpan<T1> indirect)
        where T1 : unmanaged
    {
        fixed (void* indirect_ptr = indirect)
        {
            DrawArraysIndirect(mode, indirect_ptr);
        }
    }
    /// <inheritdoc cref="DrawArraysIndirect(PrimitiveType, void*)"/>
    public static unsafe void DrawArraysIndirect<T1>(PrimitiveType mode, T1[] indirect)
        where T1 : unmanaged
    {
        fixed (void* indirect_ptr = indirect)
        {
            DrawArraysIndirect(mode, indirect_ptr);
        }
    }
    /// <inheritdoc cref="DrawArraysIndirect(PrimitiveType, void*)"/>
    public static unsafe void DrawArraysIndirect<T1>(PrimitiveType mode, ref readonly T1 indirect)
        where T1 : unmanaged
    {
        fixed (void* indirect_ptr = &indirect)
        {
            DrawArraysIndirect(mode, indirect_ptr);
        }
    }
    /// <inheritdoc cref="DrawBuffers(int, DrawBufferMode*)"/>
    public static unsafe void DrawBuffers(int n, ReadOnlySpan<DrawBufferMode> bufs)
    {
        fixed (DrawBufferMode* bufs_ptr = bufs)
        {
            DrawBuffers(n, bufs_ptr);
        }
    }
    /// <inheritdoc cref="DrawBuffers(int, DrawBufferMode*)"/>
    public static unsafe void DrawBuffers(int n, DrawBufferMode[] bufs)
    {
        fixed (DrawBufferMode* bufs_ptr = bufs)
        {
            DrawBuffers(n, bufs_ptr);
        }
    }
    /// <inheritdoc cref="DrawBuffers(int, DrawBufferMode*)"/>
    public static unsafe void DrawBuffers(int n, ref readonly DrawBufferMode bufs)
    {
        fixed (DrawBufferMode* bufs_ptr = &bufs)
        {
            DrawBuffers(n, bufs_ptr);
        }
    }
    /// <inheritdoc cref="DrawElements(PrimitiveType, int, DrawElementsType, void*)"/>
    public static unsafe void DrawElements(PrimitiveType mode, int count, DrawElementsType type, nint offset)
    {
        void* indices = (void*)offset;
        DrawElements(mode, count, type, indices);
    }
    /// <inheritdoc cref="DrawElementsBaseVertex(PrimitiveType, int, DrawElementsType, void*, int)"/>
    public static unsafe void DrawElementsBaseVertex(PrimitiveType mode, int count, DrawElementsType type, nint offset, int basevertex)
    {
        void* indices = (void*)offset;
        DrawElementsBaseVertex(mode, count, type, indices, basevertex);
    }
    /// <inheritdoc cref="DrawElementsIndirect(PrimitiveType, DrawElementsType, void*)"/>
    public static unsafe void DrawElementsIndirect(PrimitiveType mode, DrawElementsType type, IntPtr indirect)
    {
        void* indirect_vptr = (void*)indirect;
        DrawElementsIndirect(mode, type, indirect_vptr);
    }
    /// <inheritdoc cref="DrawElementsIndirect(PrimitiveType, DrawElementsType, void*)"/>
    public static unsafe void DrawElementsIndirect<T1>(PrimitiveType mode, DrawElementsType type, ReadOnlySpan<T1> indirect)
        where T1 : unmanaged
    {
        fixed (void* indirect_ptr = indirect)
        {
            DrawElementsIndirect(mode, type, indirect_ptr);
        }
    }
    /// <inheritdoc cref="DrawElementsIndirect(PrimitiveType, DrawElementsType, void*)"/>
    public static unsafe void DrawElementsIndirect<T1>(PrimitiveType mode, DrawElementsType type, T1[] indirect)
        where T1 : unmanaged
    {
        fixed (void* indirect_ptr = indirect)
        {
            DrawElementsIndirect(mode, type, indirect_ptr);
        }
    }
    /// <inheritdoc cref="DrawElementsIndirect(PrimitiveType, DrawElementsType, void*)"/>
    public static unsafe void DrawElementsIndirect<T1>(PrimitiveType mode, DrawElementsType type, ref readonly T1 indirect)
        where T1 : unmanaged
    {
        fixed (void* indirect_ptr = &indirect)
        {
            DrawElementsIndirect(mode, type, indirect_ptr);
        }
    }
    /// <inheritdoc cref="DrawElementsInstanced(PrimitiveType, int, DrawElementsType, void*, int)"/>
    public static unsafe void DrawElementsInstanced(PrimitiveType mode, int count, DrawElementsType type, nint offset, int instancecount)
    {
        void* indices = (void*)offset;
        DrawElementsInstanced(mode, count, type, indices, instancecount);
    }
    /// <inheritdoc cref="DrawElementsInstancedBaseVertex(PrimitiveType, int, DrawElementsType, void*, int, int)"/>
    public static unsafe void DrawElementsInstancedBaseVertex(PrimitiveType mode, int count, DrawElementsType type, nint offset, int instancecount, int basevertex)
    {
        void* indices = (void*)offset;
        DrawElementsInstancedBaseVertex(mode, count, type, indices, instancecount, basevertex);
    }
    /// <inheritdoc cref="DrawRangeElements(PrimitiveType, uint, uint, int, DrawElementsType, void*)"/>
    public static unsafe void DrawRangeElements(PrimitiveType mode, uint start, uint end, int count, DrawElementsType type, nint offset)
    {
        void* indices = (void*)offset;
        DrawRangeElements(mode, start, end, count, type, indices);
    }
    /// <inheritdoc cref="DrawRangeElementsBaseVertex(PrimitiveType, uint, uint, int, DrawElementsType, void*, int)"/>
    public static unsafe void DrawRangeElementsBaseVertex(PrimitiveType mode, uint start, uint end, int count, DrawElementsType type, nint offset, int basevertex)
    {
        void* indices = (void*)offset;
        DrawRangeElementsBaseVertex(mode, start, end, count, type, indices, basevertex);
    }
    /// <inheritdoc cref="GenBuffers(int, int*)"/>
    public static unsafe int GenBuffer()
    {
        int n = 1;
        Unsafe.SkipInit(out int buffer);
        int* buffers_handle = &buffer;
        GenBuffers(n, buffers_handle);
        return buffer;
    }
    /// <inheritdoc cref="GenBuffers(int, int*)"/>
    public static unsafe void GenBuffer(out int buffer)
    {
        int n = 1;
        Unsafe.SkipInit(out buffer);
        fixed(int* buffers_handle = &buffer)
        {
            GenBuffers(n, buffers_handle);
        }
    }
    /// <inheritdoc cref="GenBuffers(int, int*)"/>
    public static unsafe void GenBuffers(int n, Span<int> buffers)
    {
        fixed (int* buffers_ptr = buffers)
        {
            GenBuffers(n, buffers_ptr);
        }
    }
    /// <inheritdoc cref="GenBuffers(int, int*)"/>
    public static unsafe void GenBuffers(int n, int[] buffers)
    {
        fixed (int* buffers_ptr = buffers)
        {
            GenBuffers(n, buffers_ptr);
        }
    }
    /// <inheritdoc cref="GenBuffers(int, int*)"/>
    public static unsafe void GenBuffers(int n, ref int buffers)
    {
        fixed (int* buffers_ptr = &buffers)
        {
            GenBuffers(n, buffers_ptr);
        }
    }
    /// <inheritdoc cref="GenFramebuffers(int, int*)"/>
    public static unsafe int GenFramebuffer()
    {
        int n = 1;
        Unsafe.SkipInit(out int framebuffer);
        int* framebuffers_handle = &framebuffer;
        GenFramebuffers(n, framebuffers_handle);
        return framebuffer;
    }
    /// <inheritdoc cref="GenFramebuffers(int, int*)"/>
    public static unsafe void GenFramebuffer(out int framebuffer)
    {
        int n = 1;
        Unsafe.SkipInit(out framebuffer);
        fixed(int* framebuffers_handle = &framebuffer)
        {
            GenFramebuffers(n, framebuffers_handle);
        }
    }
    /// <inheritdoc cref="GenFramebuffers(int, int*)"/>
    public static unsafe void GenFramebuffers(int n, Span<int> framebuffers)
    {
        fixed (int* framebuffers_ptr = framebuffers)
        {
            GenFramebuffers(n, framebuffers_ptr);
        }
    }
    /// <inheritdoc cref="GenFramebuffers(int, int*)"/>
    public static unsafe void GenFramebuffers(int n, int[] framebuffers)
    {
        fixed (int* framebuffers_ptr = framebuffers)
        {
            GenFramebuffers(n, framebuffers_ptr);
        }
    }
    /// <inheritdoc cref="GenFramebuffers(int, int*)"/>
    public static unsafe void GenFramebuffers(int n, ref int framebuffers)
    {
        fixed (int* framebuffers_ptr = &framebuffers)
        {
            GenFramebuffers(n, framebuffers_ptr);
        }
    }
    /// <inheritdoc cref="GenProgramPipelines(int, int*)"/>
    public static unsafe int GenProgramPipeline()
    {
        int n = 1;
        Unsafe.SkipInit(out int pipeline);
        int* pipelines_handle = &pipeline;
        GenProgramPipelines(n, pipelines_handle);
        return pipeline;
    }
    /// <inheritdoc cref="GenProgramPipelines(int, int*)"/>
    public static unsafe void GenProgramPipeline(out int pipeline)
    {
        int n = 1;
        Unsafe.SkipInit(out pipeline);
        fixed(int* pipelines_handle = &pipeline)
        {
            GenProgramPipelines(n, pipelines_handle);
        }
    }
    /// <inheritdoc cref="GenProgramPipelines(int, int*)"/>
    public static unsafe void GenProgramPipelines(int n, Span<int> pipelines)
    {
        fixed (int* pipelines_ptr = pipelines)
        {
            GenProgramPipelines(n, pipelines_ptr);
        }
    }
    /// <inheritdoc cref="GenProgramPipelines(int, int*)"/>
    public static unsafe void GenProgramPipelines(int n, int[] pipelines)
    {
        fixed (int* pipelines_ptr = pipelines)
        {
            GenProgramPipelines(n, pipelines_ptr);
        }
    }
    /// <inheritdoc cref="GenProgramPipelines(int, int*)"/>
    public static unsafe void GenProgramPipelines(int n, ref int pipelines)
    {
        fixed (int* pipelines_ptr = &pipelines)
        {
            GenProgramPipelines(n, pipelines_ptr);
        }
    }
    /// <inheritdoc cref="GenQueries(int, int*)"/>
    public static unsafe int GenQuery()
    {
        int n = 1;
        Unsafe.SkipInit(out int id);
        int* ids_handle = &id;
        GenQueries(n, ids_handle);
        return id;
    }
    /// <inheritdoc cref="GenQueries(int, int*)"/>
    public static unsafe void GenQuery(out int id)
    {
        int n = 1;
        Unsafe.SkipInit(out id);
        fixed(int* ids_handle = &id)
        {
            GenQueries(n, ids_handle);
        }
    }
    /// <inheritdoc cref="GenQueries(int, int*)"/>
    public static unsafe void GenQueries(int n, Span<int> ids)
    {
        fixed (int* ids_ptr = ids)
        {
            GenQueries(n, ids_ptr);
        }
    }
    /// <inheritdoc cref="GenQueries(int, int*)"/>
    public static unsafe void GenQueries(int n, int[] ids)
    {
        fixed (int* ids_ptr = ids)
        {
            GenQueries(n, ids_ptr);
        }
    }
    /// <inheritdoc cref="GenQueries(int, int*)"/>
    public static unsafe void GenQueries(int n, ref int ids)
    {
        fixed (int* ids_ptr = &ids)
        {
            GenQueries(n, ids_ptr);
        }
    }
    /// <inheritdoc cref="GenRenderbuffers(int, int*)"/>
    public static unsafe int GenRenderbuffer()
    {
        int n = 1;
        Unsafe.SkipInit(out int renderbuffer);
        int* renderbuffers_handle = &renderbuffer;
        GenRenderbuffers(n, renderbuffers_handle);
        return renderbuffer;
    }
    /// <inheritdoc cref="GenRenderbuffers(int, int*)"/>
    public static unsafe void GenRenderbuffer(out int renderbuffer)
    {
        int n = 1;
        Unsafe.SkipInit(out renderbuffer);
        fixed(int* renderbuffers_handle = &renderbuffer)
        {
            GenRenderbuffers(n, renderbuffers_handle);
        }
    }
    /// <inheritdoc cref="GenRenderbuffers(int, int*)"/>
    public static unsafe void GenRenderbuffers(int n, Span<int> renderbuffers)
    {
        fixed (int* renderbuffers_ptr = renderbuffers)
        {
            GenRenderbuffers(n, renderbuffers_ptr);
        }
    }
    /// <inheritdoc cref="GenRenderbuffers(int, int*)"/>
    public static unsafe void GenRenderbuffers(int n, int[] renderbuffers)
    {
        fixed (int* renderbuffers_ptr = renderbuffers)
        {
            GenRenderbuffers(n, renderbuffers_ptr);
        }
    }
    /// <inheritdoc cref="GenRenderbuffers(int, int*)"/>
    public static unsafe void GenRenderbuffers(int n, ref int renderbuffers)
    {
        fixed (int* renderbuffers_ptr = &renderbuffers)
        {
            GenRenderbuffers(n, renderbuffers_ptr);
        }
    }
    /// <inheritdoc cref="GenSamplers(int, int*)"/>
    public static unsafe int GenSampler()
    {
        int count = 1;
        Unsafe.SkipInit(out int sampler);
        int* samplers_handle = &sampler;
        GenSamplers(count, samplers_handle);
        return sampler;
    }
    /// <inheritdoc cref="GenSamplers(int, int*)"/>
    public static unsafe void GenSampler(out int sampler)
    {
        int count = 1;
        Unsafe.SkipInit(out sampler);
        fixed(int* samplers_handle = &sampler)
        {
            GenSamplers(count, samplers_handle);
        }
    }
    /// <inheritdoc cref="GenSamplers(int, int*)"/>
    public static unsafe void GenSamplers(int count, Span<int> samplers)
    {
        fixed (int* samplers_ptr = samplers)
        {
            GenSamplers(count, samplers_ptr);
        }
    }
    /// <inheritdoc cref="GenSamplers(int, int*)"/>
    public static unsafe void GenSamplers(int count, int[] samplers)
    {
        fixed (int* samplers_ptr = samplers)
        {
            GenSamplers(count, samplers_ptr);
        }
    }
    /// <inheritdoc cref="GenSamplers(int, int*)"/>
    public static unsafe void GenSamplers(int count, ref int samplers)
    {
        fixed (int* samplers_ptr = &samplers)
        {
            GenSamplers(count, samplers_ptr);
        }
    }
    /// <inheritdoc cref="GenTextures(int, int*)"/>
    public static unsafe int GenTexture()
    {
        int n = 1;
        Unsafe.SkipInit(out int texture);
        int* textures_handle = &texture;
        GenTextures(n, textures_handle);
        return texture;
    }
    /// <inheritdoc cref="GenTextures(int, int*)"/>
    public static unsafe void GenTexture(out int texture)
    {
        int n = 1;
        Unsafe.SkipInit(out texture);
        fixed(int* textures_handle = &texture)
        {
            GenTextures(n, textures_handle);
        }
    }
    /// <inheritdoc cref="GenTextures(int, int*)"/>
    public static unsafe void GenTextures(int n, Span<int> textures)
    {
        fixed (int* textures_ptr = textures)
        {
            GenTextures(n, textures_ptr);
        }
    }
    /// <inheritdoc cref="GenTextures(int, int*)"/>
    public static unsafe void GenTextures(int n, int[] textures)
    {
        fixed (int* textures_ptr = textures)
        {
            GenTextures(n, textures_ptr);
        }
    }
    /// <inheritdoc cref="GenTextures(int, int*)"/>
    public static unsafe void GenTextures(int n, ref int textures)
    {
        fixed (int* textures_ptr = &textures)
        {
            GenTextures(n, textures_ptr);
        }
    }
    /// <inheritdoc cref="GenTransformFeedbacks(int, int*)"/>
    public static unsafe int GenTransformFeedback()
    {
        int n = 1;
        Unsafe.SkipInit(out int id);
        int* ids_handle = &id;
        GenTransformFeedbacks(n, ids_handle);
        return id;
    }
    /// <inheritdoc cref="GenTransformFeedbacks(int, int*)"/>
    public static unsafe void GenTransformFeedback(out int id)
    {
        int n = 1;
        Unsafe.SkipInit(out id);
        fixed(int* ids_handle = &id)
        {
            GenTransformFeedbacks(n, ids_handle);
        }
    }
    /// <inheritdoc cref="GenTransformFeedbacks(int, int*)"/>
    public static unsafe void GenTransformFeedbacks(int n, Span<int> ids)
    {
        fixed (int* ids_ptr = ids)
        {
            GenTransformFeedbacks(n, ids_ptr);
        }
    }
    /// <inheritdoc cref="GenTransformFeedbacks(int, int*)"/>
    public static unsafe void GenTransformFeedbacks(int n, int[] ids)
    {
        fixed (int* ids_ptr = ids)
        {
            GenTransformFeedbacks(n, ids_ptr);
        }
    }
    /// <inheritdoc cref="GenTransformFeedbacks(int, int*)"/>
    public static unsafe void GenTransformFeedbacks(int n, ref int ids)
    {
        fixed (int* ids_ptr = &ids)
        {
            GenTransformFeedbacks(n, ids_ptr);
        }
    }
    /// <inheritdoc cref="GenVertexArrays(int, int*)"/>
    public static unsafe int GenVertexArray()
    {
        int n = 1;
        Unsafe.SkipInit(out int array);
        int* arrays_handle = &array;
        GenVertexArrays(n, arrays_handle);
        return array;
    }
    /// <inheritdoc cref="GenVertexArrays(int, int*)"/>
    public static unsafe void GenVertexArray(out int array)
    {
        int n = 1;
        Unsafe.SkipInit(out array);
        fixed(int* arrays_handle = &array)
        {
            GenVertexArrays(n, arrays_handle);
        }
    }
    /// <inheritdoc cref="GenVertexArrays(int, int*)"/>
    public static unsafe void GenVertexArrays(int n, Span<int> arrays)
    {
        fixed (int* arrays_ptr = arrays)
        {
            GenVertexArrays(n, arrays_ptr);
        }
    }
    /// <inheritdoc cref="GenVertexArrays(int, int*)"/>
    public static unsafe void GenVertexArrays(int n, int[] arrays)
    {
        fixed (int* arrays_ptr = arrays)
        {
            GenVertexArrays(n, arrays_ptr);
        }
    }
    /// <inheritdoc cref="GenVertexArrays(int, int*)"/>
    public static unsafe void GenVertexArrays(int n, ref int arrays)
    {
        fixed (int* arrays_ptr = &arrays)
        {
            GenVertexArrays(n, arrays_ptr);
        }
    }
    /// <inheritdoc cref="GetActiveAttrib(int, uint, int, int*, int*, AttributeType*, byte*)"/>
    public static unsafe string GetActiveAttrib(int program, uint index, int bufSize, out int length, out int size, out AttributeType type)
    {
        string name;
        fixed (int* length_ptr = &length)
        fixed (int* size_ptr = &size)
        fixed (AttributeType* type_ptr = &type)
        {
            var name_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetActiveAttrib(program, index, bufSize, length_ptr, size_ptr, type_ptr, name_ptr);
            name = Marshal.PtrToStringUTF8((IntPtr)name_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)name_ptr);
        }
        return name;
    }
    /// <inheritdoc cref="GetActiveAttrib(int, uint, int, int*, int*, AttributeType*, byte*)"/>
    public static unsafe void GetActiveAttrib(int program, uint index, int bufSize, out int length, out int size, out AttributeType type, out string name)
    {
        fixed (int* length_ptr = &length)
        fixed (int* size_ptr = &size)
        fixed (AttributeType* type_ptr = &type)
        {
            var name_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetActiveAttrib(program, index, bufSize, length_ptr, size_ptr, type_ptr, name_ptr);
            name = Marshal.PtrToStringUTF8((IntPtr)name_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)name_ptr);
        }
    }
    /// <inheritdoc cref="GetActiveUniform(int, uint, int, int*, int*, UniformType*, byte*)"/>
    public static unsafe string GetActiveUniform(int program, uint index, int bufSize, out int length, out int size, out UniformType type)
    {
        string name;
        fixed (int* length_ptr = &length)
        fixed (int* size_ptr = &size)
        fixed (UniformType* type_ptr = &type)
        {
            var name_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetActiveUniform(program, index, bufSize, length_ptr, size_ptr, type_ptr, name_ptr);
            name = Marshal.PtrToStringUTF8((IntPtr)name_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)name_ptr);
        }
        return name;
    }
    /// <inheritdoc cref="GetActiveUniform(int, uint, int, int*, int*, UniformType*, byte*)"/>
    public static unsafe void GetActiveUniform(int program, uint index, int bufSize, out int length, out int size, out UniformType type, out string name)
    {
        fixed (int* length_ptr = &length)
        fixed (int* size_ptr = &size)
        fixed (UniformType* type_ptr = &type)
        {
            var name_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetActiveUniform(program, index, bufSize, length_ptr, size_ptr, type_ptr, name_ptr);
            name = Marshal.PtrToStringUTF8((IntPtr)name_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)name_ptr);
        }
    }
    /// <inheritdoc cref="GetActiveUniformBlockiv(int, uint, UniformBlockPName, int*)"/>
    public static unsafe void GetActiveUniformBlocki(int program, uint uniformBlockIndex, UniformBlockPName pname, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetActiveUniformBlockiv(program, uniformBlockIndex, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetActiveUniformBlockiv(int, uint, UniformBlockPName, int*)"/>
    public static unsafe void GetActiveUniformBlocki(int program, uint uniformBlockIndex, UniformBlockPName pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetActiveUniformBlockiv(program, uniformBlockIndex, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetActiveUniformBlockiv(int, uint, UniformBlockPName, int*)"/>
    public static unsafe int GetActiveUniformBlocki(int program, uint uniformBlockIndex, UniformBlockPName pname)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        {
            GetActiveUniformBlockiv(program, uniformBlockIndex, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetActiveUniformBlockiv(int, uint, UniformBlockPName, int*)"/>
    public static unsafe void GetActiveUniformBlocki(int program, uint uniformBlockIndex, UniformBlockPName pname, out int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetActiveUniformBlockiv(program, uniformBlockIndex, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetActiveUniformBlockName(int, uint, int, int*, byte*)"/>
    public static unsafe string GetActiveUniformBlockName(int program, uint uniformBlockIndex, int bufSize, out int length)
    {
        string uniformBlockName;
        fixed (int* length_ptr = &length)
        {
            var uniformBlockName_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetActiveUniformBlockName(program, uniformBlockIndex, bufSize, length_ptr, uniformBlockName_ptr);
            uniformBlockName = Marshal.PtrToStringUTF8((IntPtr)uniformBlockName_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)uniformBlockName_ptr);
        }
        return uniformBlockName;
    }
    /// <inheritdoc cref="GetActiveUniformBlockName(int, uint, int, int*, byte*)"/>
    public static unsafe void GetActiveUniformBlockName(int program, uint uniformBlockIndex, int bufSize, out int length, out string uniformBlockName)
    {
        fixed (int* length_ptr = &length)
        {
            var uniformBlockName_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetActiveUniformBlockName(program, uniformBlockIndex, bufSize, length_ptr, uniformBlockName_ptr);
            uniformBlockName = Marshal.PtrToStringUTF8((IntPtr)uniformBlockName_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)uniformBlockName_ptr);
        }
    }
    /// <inheritdoc cref="GetActiveUniformsiv(int, int, uint*, UniformPName, int*)"/>
    public static unsafe void GetActiveUniformsi(int program, int uniformCount, ReadOnlySpan<uint> uniformIndices, UniformPName pname, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            fixed (uint* uniformIndices_ptr = uniformIndices)
            {
                GetActiveUniformsiv(program, uniformCount, uniformIndices_ptr, pname, parameters_ptr);
            }
        }
    }
    /// <inheritdoc cref="GetActiveUniformsiv(int, int, uint*, UniformPName, int*)"/>
    public static unsafe void GetActiveUniformsi(int program, int uniformCount, uint[] uniformIndices, UniformPName pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            fixed (uint* uniformIndices_ptr = uniformIndices)
            {
                GetActiveUniformsiv(program, uniformCount, uniformIndices_ptr, pname, parameters_ptr);
            }
        }
    }
    /// <inheritdoc cref="GetActiveUniformsiv(int, int, uint*, UniformPName, int*)"/>
    public static unsafe int GetActiveUniformsi(int program, int uniformCount, ref readonly uint uniformIndices, UniformPName pname)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        fixed (uint* uniformIndices_ptr = &uniformIndices)
        {
            GetActiveUniformsiv(program, uniformCount, uniformIndices_ptr, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetActiveUniformsiv(int, int, uint*, UniformPName, int*)"/>
    public static unsafe void GetActiveUniformsi(int program, int uniformCount, ref readonly uint uniformIndices, UniformPName pname, out int parameters)
    {
        fixed (uint* uniformIndices_ptr = &uniformIndices)
        fixed (int* parameters_ptr = &parameters)
        {
            GetActiveUniformsiv(program, uniformCount, uniformIndices_ptr, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetAttachedShaders(int, int, int*, int*)"/>
    public static unsafe void GetAttachedShaders(int program, int maxCount, out int count, Span<int> shaders)
    {
        fixed (int* count_ptr = &count)
        {
            fixed (int* shaders_ptr = shaders)
            {
                GetAttachedShaders(program, maxCount, count_ptr, shaders_ptr);
            }
        }
    }
    /// <inheritdoc cref="GetAttachedShaders(int, int, int*, int*)"/>
    public static unsafe void GetAttachedShaders(int program, int maxCount, out int count, int[] shaders)
    {
        fixed (int* count_ptr = &count)
        {
            fixed (int* shaders_ptr = shaders)
            {
                GetAttachedShaders(program, maxCount, count_ptr, shaders_ptr);
            }
        }
    }
    /// <inheritdoc cref="GetAttachedShaders(int, int, int*, int*)"/>
    public static unsafe void GetAttachedShaders(int program, int maxCount, out int count, ref int shaders)
    {
        fixed (int* count_ptr = &count)
        fixed (int* shaders_ptr = &shaders)
        {
            GetAttachedShaders(program, maxCount, count_ptr, shaders_ptr);
        }
    }
    /// <inheritdoc cref="GetAttribLocation(int, byte*)"/>
    public static unsafe int GetAttribLocation(int program, string name)
    {
        byte* name_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(name);
        var returnValue = GetAttribLocation(program, name_ptr);
        Marshal.FreeCoTaskMem((IntPtr)name_ptr);
        return returnValue;
    }
    /// <inheritdoc cref="GetBooleani_v(BufferTarget, uint, bool*)"/>
    public static unsafe void GetBoolean(BufferTarget target, uint index, Span<bool> data)
    {
        fixed (bool* data_ptr = data)
        {
            GetBooleani_v(target, index, data_ptr);
        }
    }
    /// <inheritdoc cref="GetBooleani_v(BufferTarget, uint, bool*)"/>
    public static unsafe void GetBoolean(BufferTarget target, uint index, bool[] data)
    {
        fixed (bool* data_ptr = data)
        {
            GetBooleani_v(target, index, data_ptr);
        }
    }
    /// <inheritdoc cref="GetBooleani_v(BufferTarget, uint, bool*)"/>
    public static unsafe bool GetBoolean(BufferTarget target, uint index)
    {
        bool data;
        bool* data_ptr = &data;
        {
            GetBooleani_v(target, index, data_ptr);
        }
        return data;
    }
    /// <inheritdoc cref="GetBooleani_v(BufferTarget, uint, bool*)"/>
    public static unsafe void GetBoolean(BufferTarget target, uint index, out bool data)
    {
        fixed (bool* data_ptr = &data)
        {
            GetBooleani_v(target, index, data_ptr);
        }
    }
    /// <inheritdoc cref="GetBooleanv(GetPName, bool*)"/>
    public static unsafe void GetBoolean(GetPName pname, Span<bool> data)
    {
        fixed (bool* data_ptr = data)
        {
            GetBooleanv(pname, data_ptr);
        }
    }
    /// <inheritdoc cref="GetBooleanv(GetPName, bool*)"/>
    public static unsafe void GetBoolean(GetPName pname, bool[] data)
    {
        fixed (bool* data_ptr = data)
        {
            GetBooleanv(pname, data_ptr);
        }
    }
    /// <inheritdoc cref="GetBooleanv(GetPName, bool*)"/>
    public static unsafe bool GetBoolean(GetPName pname)
    {
        bool data;
        bool* data_ptr = &data;
        {
            GetBooleanv(pname, data_ptr);
        }
        return data;
    }
    /// <inheritdoc cref="GetBooleanv(GetPName, bool*)"/>
    public static unsafe void GetBoolean(GetPName pname, out bool data)
    {
        fixed (bool* data_ptr = &data)
        {
            GetBooleanv(pname, data_ptr);
        }
    }
    /// <inheritdoc cref="GetBufferParameteri64v(BufferTarget, BufferPName, long*)"/>
    public static unsafe void GetBufferParameteri64(BufferTarget target, BufferPName pname, Span<long> parameters)
    {
        fixed (long* parameters_ptr = parameters)
        {
            GetBufferParameteri64v(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetBufferParameteri64v(BufferTarget, BufferPName, long*)"/>
    public static unsafe void GetBufferParameteri64(BufferTarget target, BufferPName pname, long[] parameters)
    {
        fixed (long* parameters_ptr = parameters)
        {
            GetBufferParameteri64v(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetBufferParameteri64v(BufferTarget, BufferPName, long*)"/>
    public static unsafe long GetBufferParameteri64(BufferTarget target, BufferPName pname)
    {
        long parameters;
        long* parameters_ptr = &parameters;
        {
            GetBufferParameteri64v(target, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetBufferParameteri64v(BufferTarget, BufferPName, long*)"/>
    public static unsafe void GetBufferParameteri64(BufferTarget target, BufferPName pname, out long parameters)
    {
        fixed (long* parameters_ptr = &parameters)
        {
            GetBufferParameteri64v(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetBufferParameteriv(BufferTarget, BufferPName, int*)"/>
    public static unsafe void GetBufferParameteri(BufferTarget target, BufferPName pname, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetBufferParameteriv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetBufferParameteriv(BufferTarget, BufferPName, int*)"/>
    public static unsafe void GetBufferParameteri(BufferTarget target, BufferPName pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetBufferParameteriv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetBufferParameteriv(BufferTarget, BufferPName, int*)"/>
    public static unsafe int GetBufferParameteri(BufferTarget target, BufferPName pname)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        {
            GetBufferParameteriv(target, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetBufferParameteriv(BufferTarget, BufferPName, int*)"/>
    public static unsafe void GetBufferParameteri(BufferTarget target, BufferPName pname, out int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetBufferParameteriv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetBufferPointerv(BufferTarget, BufferPointerNameARB, void**)"/>
    public static unsafe void GetBufferPointer(BufferTarget target, BufferPointerNameARB pname, void** parameters)
    {
        GetBufferPointerv(target, pname, parameters);
    }
    /// <inheritdoc cref="GetDebugMessageLog(uint, int, DebugSource*, DebugType*, uint*, DebugSeverity*, int*, byte*)"/>
    public static unsafe uint GetDebugMessageLog(uint count, int bufSize, Span<DebugSource> sources, Span<DebugType> types, Span<uint> ids, Span<DebugSeverity> severities, Span<int> lengths, out string messageLog)
    {
        uint returnValue;
        fixed (int* lengths_ptr = lengths)
        {
            fixed (DebugSeverity* severities_ptr = severities)
            {
                fixed (uint* ids_ptr = ids)
                {
                    fixed (DebugType* types_ptr = types)
                    {
                        fixed (DebugSource* sources_ptr = sources)
                        {
                            var messageLog_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                            returnValue = GetDebugMessageLog(count, bufSize, sources_ptr, types_ptr, ids_ptr, severities_ptr, lengths_ptr, messageLog_ptr);
                            messageLog = Marshal.PtrToStringUTF8((IntPtr)messageLog_ptr)!;
                            Marshal.FreeCoTaskMem((IntPtr)messageLog_ptr);
                        }
                    }
                }
            }
        }
        return returnValue;
    }
    /// <inheritdoc cref="GetDebugMessageLog(uint, int, DebugSource*, DebugType*, uint*, DebugSeverity*, int*, byte*)"/>
    public static unsafe uint GetDebugMessageLog(uint count, int bufSize, DebugSource[] sources, DebugType[] types, uint[] ids, DebugSeverity[] severities, int[] lengths, out string messageLog)
    {
        uint returnValue;
        fixed (int* lengths_ptr = lengths)
        {
            fixed (DebugSeverity* severities_ptr = severities)
            {
                fixed (uint* ids_ptr = ids)
                {
                    fixed (DebugType* types_ptr = types)
                    {
                        fixed (DebugSource* sources_ptr = sources)
                        {
                            var messageLog_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                            returnValue = GetDebugMessageLog(count, bufSize, sources_ptr, types_ptr, ids_ptr, severities_ptr, lengths_ptr, messageLog_ptr);
                            messageLog = Marshal.PtrToStringUTF8((IntPtr)messageLog_ptr)!;
                            Marshal.FreeCoTaskMem((IntPtr)messageLog_ptr);
                        }
                    }
                }
            }
        }
        return returnValue;
    }
    /// <inheritdoc cref="GetDebugMessageLog(uint, int, DebugSource*, DebugType*, uint*, DebugSeverity*, int*, byte*)"/>
    public static unsafe uint GetDebugMessageLog(uint count, int bufSize, ref DebugSource sources, ref DebugType types, ref uint ids, ref DebugSeverity severities, ref int lengths, out string messageLog)
    {
        uint returnValue;
        fixed (DebugSource* sources_ptr = &sources)
        fixed (DebugType* types_ptr = &types)
        fixed (uint* ids_ptr = &ids)
        fixed (DebugSeverity* severities_ptr = &severities)
        fixed (int* lengths_ptr = &lengths)
        {
            var messageLog_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            returnValue = GetDebugMessageLog(count, bufSize, sources_ptr, types_ptr, ids_ptr, severities_ptr, lengths_ptr, messageLog_ptr);
            messageLog = Marshal.PtrToStringUTF8((IntPtr)messageLog_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)messageLog_ptr);
        }
        return returnValue;
    }
    /// <inheritdoc cref="GetFloatv(GetPName, float*)"/>
    public static unsafe void GetFloat(GetPName pname, Span<float> data)
    {
        fixed (float* data_ptr = data)
        {
            GetFloatv(pname, data_ptr);
        }
    }
    /// <inheritdoc cref="GetFloatv(GetPName, float*)"/>
    public static unsafe void GetFloat(GetPName pname, float[] data)
    {
        fixed (float* data_ptr = data)
        {
            GetFloatv(pname, data_ptr);
        }
    }
    /// <inheritdoc cref="GetFloatv(GetPName, float*)"/>
    public static unsafe float GetFloat(GetPName pname)
    {
        float data;
        float* data_ptr = &data;
        {
            GetFloatv(pname, data_ptr);
        }
        return data;
    }
    /// <inheritdoc cref="GetFloatv(GetPName, float*)"/>
    public static unsafe void GetFloat(GetPName pname, out float data)
    {
        fixed (float* data_ptr = &data)
        {
            GetFloatv(pname, data_ptr);
        }
    }
    /// <inheritdoc cref="GetFragDataLocation(int, byte*)"/>
    public static unsafe int GetFragDataLocation(int program, string name)
    {
        byte* name_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(name);
        var returnValue = GetFragDataLocation(program, name_ptr);
        Marshal.FreeCoTaskMem((IntPtr)name_ptr);
        return returnValue;
    }
    /// <inheritdoc cref="GetFramebufferAttachmentParameteriv(FramebufferTarget, FramebufferAttachment, FramebufferAttachmentParameterName, int*)"/>
    public static unsafe void GetFramebufferAttachmentParameteri(FramebufferTarget target, FramebufferAttachment attachment, FramebufferAttachmentParameterName pname, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetFramebufferAttachmentParameteriv(target, attachment, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetFramebufferAttachmentParameteriv(FramebufferTarget, FramebufferAttachment, FramebufferAttachmentParameterName, int*)"/>
    public static unsafe void GetFramebufferAttachmentParameteri(FramebufferTarget target, FramebufferAttachment attachment, FramebufferAttachmentParameterName pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetFramebufferAttachmentParameteriv(target, attachment, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetFramebufferAttachmentParameteriv(FramebufferTarget, FramebufferAttachment, FramebufferAttachmentParameterName, int*)"/>
    public static unsafe int GetFramebufferAttachmentParameteri(FramebufferTarget target, FramebufferAttachment attachment, FramebufferAttachmentParameterName pname)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        {
            GetFramebufferAttachmentParameteriv(target, attachment, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetFramebufferAttachmentParameteriv(FramebufferTarget, FramebufferAttachment, FramebufferAttachmentParameterName, int*)"/>
    public static unsafe void GetFramebufferAttachmentParameteri(FramebufferTarget target, FramebufferAttachment attachment, FramebufferAttachmentParameterName pname, out int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetFramebufferAttachmentParameteriv(target, attachment, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetFramebufferParameteriv(FramebufferTarget, FramebufferAttachmentParameterName, int*)"/>
    public static unsafe void GetFramebufferParameteri(FramebufferTarget target, FramebufferAttachmentParameterName pname, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetFramebufferParameteriv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetFramebufferParameteriv(FramebufferTarget, FramebufferAttachmentParameterName, int*)"/>
    public static unsafe void GetFramebufferParameteri(FramebufferTarget target, FramebufferAttachmentParameterName pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetFramebufferParameteriv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetFramebufferParameteriv(FramebufferTarget, FramebufferAttachmentParameterName, int*)"/>
    public static unsafe int GetFramebufferParameteri(FramebufferTarget target, FramebufferAttachmentParameterName pname)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        {
            GetFramebufferParameteriv(target, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetFramebufferParameteriv(FramebufferTarget, FramebufferAttachmentParameterName, int*)"/>
    public static unsafe void GetFramebufferParameteri(FramebufferTarget target, FramebufferAttachmentParameterName pname, out int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetFramebufferParameteriv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetInteger64i_v(GetPName, uint, long*)"/>
    public static unsafe void GetInteger64(GetPName target, uint index, Span<long> data)
    {
        fixed (long* data_ptr = data)
        {
            GetInteger64i_v(target, index, data_ptr);
        }
    }
    /// <inheritdoc cref="GetInteger64i_v(GetPName, uint, long*)"/>
    public static unsafe void GetInteger64(GetPName target, uint index, long[] data)
    {
        fixed (long* data_ptr = data)
        {
            GetInteger64i_v(target, index, data_ptr);
        }
    }
    /// <inheritdoc cref="GetInteger64i_v(GetPName, uint, long*)"/>
    public static unsafe long GetInteger64(GetPName target, uint index)
    {
        long data;
        long* data_ptr = &data;
        {
            GetInteger64i_v(target, index, data_ptr);
        }
        return data;
    }
    /// <inheritdoc cref="GetInteger64i_v(GetPName, uint, long*)"/>
    public static unsafe void GetInteger64(GetPName target, uint index, out long data)
    {
        fixed (long* data_ptr = &data)
        {
            GetInteger64i_v(target, index, data_ptr);
        }
    }
    /// <inheritdoc cref="GetInteger64v(GetPName, long*)"/>
    public static unsafe void GetInteger64(GetPName pname, Span<long> data)
    {
        fixed (long* data_ptr = data)
        {
            GetInteger64v(pname, data_ptr);
        }
    }
    /// <inheritdoc cref="GetInteger64v(GetPName, long*)"/>
    public static unsafe void GetInteger64(GetPName pname, long[] data)
    {
        fixed (long* data_ptr = data)
        {
            GetInteger64v(pname, data_ptr);
        }
    }
    /// <inheritdoc cref="GetInteger64v(GetPName, long*)"/>
    public static unsafe long GetInteger64(GetPName pname)
    {
        long data;
        long* data_ptr = &data;
        {
            GetInteger64v(pname, data_ptr);
        }
        return data;
    }
    /// <inheritdoc cref="GetInteger64v(GetPName, long*)"/>
    public static unsafe void GetInteger64(GetPName pname, out long data)
    {
        fixed (long* data_ptr = &data)
        {
            GetInteger64v(pname, data_ptr);
        }
    }
    /// <inheritdoc cref="GetIntegeri_v(GetPName, uint, int*)"/>
    public static unsafe void GetInteger(GetPName target, uint index, Span<int> data)
    {
        fixed (int* data_ptr = data)
        {
            GetIntegeri_v(target, index, data_ptr);
        }
    }
    /// <inheritdoc cref="GetIntegeri_v(GetPName, uint, int*)"/>
    public static unsafe void GetInteger(GetPName target, uint index, int[] data)
    {
        fixed (int* data_ptr = data)
        {
            GetIntegeri_v(target, index, data_ptr);
        }
    }
    /// <inheritdoc cref="GetIntegeri_v(GetPName, uint, int*)"/>
    public static unsafe int GetInteger(GetPName target, uint index)
    {
        int data;
        int* data_ptr = &data;
        {
            GetIntegeri_v(target, index, data_ptr);
        }
        return data;
    }
    /// <inheritdoc cref="GetIntegeri_v(GetPName, uint, int*)"/>
    public static unsafe void GetInteger(GetPName target, uint index, out int data)
    {
        fixed (int* data_ptr = &data)
        {
            GetIntegeri_v(target, index, data_ptr);
        }
    }
    /// <inheritdoc cref="GetIntegerv(GetPName, int*)"/>
    public static unsafe void GetInteger(GetPName pname, Span<int> data)
    {
        fixed (int* data_ptr = data)
        {
            GetIntegerv(pname, data_ptr);
        }
    }
    /// <inheritdoc cref="GetIntegerv(GetPName, int*)"/>
    public static unsafe void GetInteger(GetPName pname, int[] data)
    {
        fixed (int* data_ptr = data)
        {
            GetIntegerv(pname, data_ptr);
        }
    }
    /// <inheritdoc cref="GetIntegerv(GetPName, int*)"/>
    public static unsafe int GetInteger(GetPName pname)
    {
        int data;
        int* data_ptr = &data;
        {
            GetIntegerv(pname, data_ptr);
        }
        return data;
    }
    /// <inheritdoc cref="GetIntegerv(GetPName, int*)"/>
    public static unsafe void GetInteger(GetPName pname, out int data)
    {
        fixed (int* data_ptr = &data)
        {
            GetIntegerv(pname, data_ptr);
        }
    }
    /// <inheritdoc cref="GetInternalformativ(TextureTarget, InternalFormat, InternalFormatPName, int, int*)"/>
    public static unsafe void GetInternalformati(TextureTarget target, InternalFormat internalformat, InternalFormatPName pname, int count, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetInternalformativ(target, internalformat, pname, count, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetInternalformativ(TextureTarget, InternalFormat, InternalFormatPName, int, int*)"/>
    public static unsafe void GetInternalformati(TextureTarget target, InternalFormat internalformat, InternalFormatPName pname, int count, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetInternalformativ(target, internalformat, pname, count, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetInternalformativ(TextureTarget, InternalFormat, InternalFormatPName, int, int*)"/>
    public static unsafe void GetInternalformati(TextureTarget target, InternalFormat internalformat, InternalFormatPName pname, int count, ref int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetInternalformativ(target, internalformat, pname, count, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetMultisamplefv(GetMultisamplePNameNV, uint, float*)"/>
    public static unsafe void GetMultisamplef(GetMultisamplePNameNV pname, uint index, Span<float> val)
    {
        fixed (float* val_ptr = val)
        {
            GetMultisamplefv(pname, index, val_ptr);
        }
    }
    /// <inheritdoc cref="GetMultisamplefv(GetMultisamplePNameNV, uint, float*)"/>
    public static unsafe void GetMultisamplef(GetMultisamplePNameNV pname, uint index, float[] val)
    {
        fixed (float* val_ptr = val)
        {
            GetMultisamplefv(pname, index, val_ptr);
        }
    }
    /// <inheritdoc cref="GetMultisamplefv(GetMultisamplePNameNV, uint, float*)"/>
    public static unsafe float GetMultisamplef(GetMultisamplePNameNV pname, uint index)
    {
        float val;
        float* val_ptr = &val;
        {
            GetMultisamplefv(pname, index, val_ptr);
        }
        return val;
    }
    /// <inheritdoc cref="GetMultisamplefv(GetMultisamplePNameNV, uint, float*)"/>
    public static unsafe void GetMultisamplef(GetMultisamplePNameNV pname, uint index, out float val)
    {
        fixed (float* val_ptr = &val)
        {
            GetMultisamplefv(pname, index, val_ptr);
        }
    }
    /// <inheritdoc cref="GetnUniformfv(int, int, int, float*)"/>
    public static unsafe void GetnUniformf(int program, int location, int bufSize, Span<float> parameters)
    {
        fixed (float* parameters_ptr = parameters)
        {
            GetnUniformfv(program, location, bufSize, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetnUniformfv(int, int, int, float*)"/>
    public static unsafe void GetnUniformf(int program, int location, int bufSize, float[] parameters)
    {
        fixed (float* parameters_ptr = parameters)
        {
            GetnUniformfv(program, location, bufSize, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetnUniformfv(int, int, int, float*)"/>
    public static unsafe void GetnUniformf(int program, int location, int bufSize, ref float parameters)
    {
        fixed (float* parameters_ptr = &parameters)
        {
            GetnUniformfv(program, location, bufSize, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetnUniformiv(int, int, int, int*)"/>
    public static unsafe void GetnUniformi(int program, int location, int bufSize, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetnUniformiv(program, location, bufSize, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetnUniformiv(int, int, int, int*)"/>
    public static unsafe void GetnUniformi(int program, int location, int bufSize, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetnUniformiv(program, location, bufSize, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetnUniformiv(int, int, int, int*)"/>
    public static unsafe void GetnUniformi(int program, int location, int bufSize, ref int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetnUniformiv(program, location, bufSize, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetnUniformuiv(int, int, int, uint*)"/>
    public static unsafe void GetnUniformui(int program, int location, int bufSize, Span<uint> parameters)
    {
        fixed (uint* parameters_ptr = parameters)
        {
            GetnUniformuiv(program, location, bufSize, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetnUniformuiv(int, int, int, uint*)"/>
    public static unsafe void GetnUniformui(int program, int location, int bufSize, uint[] parameters)
    {
        fixed (uint* parameters_ptr = parameters)
        {
            GetnUniformuiv(program, location, bufSize, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetnUniformuiv(int, int, int, uint*)"/>
    public static unsafe void GetnUniformui(int program, int location, int bufSize, ref uint parameters)
    {
        fixed (uint* parameters_ptr = &parameters)
        {
            GetnUniformuiv(program, location, bufSize, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetObjectLabel(ObjectIdentifier, uint, int, int*, byte*)"/>
    public static unsafe string GetObjectLabel(ObjectIdentifier identifier, uint name, int bufSize, out int length)
    {
        string label;
        fixed (int* length_ptr = &length)
        {
            var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetObjectLabel(identifier, name, bufSize, length_ptr, label_ptr);
            label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)label_ptr);
        }
        return label;
    }
    /// <inheritdoc cref="GetObjectLabel(ObjectIdentifier, uint, int, int*, byte*)"/>
    public static unsafe void GetObjectLabel(ObjectIdentifier identifier, uint name, int bufSize, out int length, out string label)
    {
        fixed (int* length_ptr = &length)
        {
            var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetObjectLabel(identifier, name, bufSize, length_ptr, label_ptr);
            label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)label_ptr);
        }
    }
    /// <inheritdoc cref="GetObjectPtrLabel(void*, int, int*, byte*)"/>
    public static unsafe string GetObjectPtrLabel(IntPtr ptr, int bufSize, out int length)
    {
        string label;
        fixed (int* length_ptr = &length)
        {
            var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            void* ptr_vptr = (void*)ptr;
            GetObjectPtrLabel(ptr_vptr, bufSize, length_ptr, label_ptr);
            label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)label_ptr);
        }
        return label;
    }
    /// <inheritdoc cref="GetObjectPtrLabel(void*, int, int*, byte*)"/>
    public static unsafe void GetObjectPtrLabel(IntPtr ptr, int bufSize, out int length, out string label)
    {
        fixed (int* length_ptr = &length)
        {
            var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            void* ptr_vptr = (void*)ptr;
            GetObjectPtrLabel(ptr_vptr, bufSize, length_ptr, label_ptr);
            label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)label_ptr);
        }
    }
    /// <inheritdoc cref="GetObjectPtrLabel(void*, int, int*, byte*)"/>
    public static unsafe string GetObjectPtrLabel<T1>(ReadOnlySpan<T1> ptr, int bufSize, out int length)
        where T1 : unmanaged
    {
        string label;
        fixed (int* length_ptr = &length)
        {
            fixed (void* ptr_ptr = ptr)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetObjectPtrLabel(ptr_ptr, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
        }
        return label;
    }
    /// <inheritdoc cref="GetObjectPtrLabel(void*, int, int*, byte*)"/>
    public static unsafe void GetObjectPtrLabel<T1>(ReadOnlySpan<T1> ptr, int bufSize, out int length, out string label)
        where T1 : unmanaged
    {
        fixed (int* length_ptr = &length)
        {
            fixed (void* ptr_ptr = ptr)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetObjectPtrLabel(ptr_ptr, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
        }
    }
    /// <inheritdoc cref="GetObjectPtrLabel(void*, int, int*, byte*)"/>
    public static unsafe string GetObjectPtrLabel<T1>(T1[] ptr, int bufSize, out int length)
        where T1 : unmanaged
    {
        string label;
        fixed (int* length_ptr = &length)
        {
            fixed (void* ptr_ptr = ptr)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetObjectPtrLabel(ptr_ptr, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
        }
        return label;
    }
    /// <inheritdoc cref="GetObjectPtrLabel(void*, int, int*, byte*)"/>
    public static unsafe void GetObjectPtrLabel<T1>(T1[] ptr, int bufSize, out int length, out string label)
        where T1 : unmanaged
    {
        fixed (int* length_ptr = &length)
        {
            fixed (void* ptr_ptr = ptr)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetObjectPtrLabel(ptr_ptr, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
        }
    }
    /// <inheritdoc cref="GetObjectPtrLabel(void*, int, int*, byte*)"/>
    public static unsafe string GetObjectPtrLabel<T1>(ref readonly T1 ptr, int bufSize, out int length)
        where T1 : unmanaged
    {
        string label;
        fixed (void* ptr_ptr = &ptr)
        fixed (int* length_ptr = &length)
        {
            var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetObjectPtrLabel(ptr_ptr, bufSize, length_ptr, label_ptr);
            label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)label_ptr);
        }
        return label;
    }
    /// <inheritdoc cref="GetObjectPtrLabel(void*, int, int*, byte*)"/>
    public static unsafe void GetObjectPtrLabel<T1>(ref readonly T1 ptr, int bufSize, out int length, out string label)
        where T1 : unmanaged
    {
        fixed (void* ptr_ptr = &ptr)
        fixed (int* length_ptr = &length)
        {
            var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetObjectPtrLabel(ptr_ptr, bufSize, length_ptr, label_ptr);
            label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)label_ptr);
        }
    }
    /// <inheritdoc cref="GetPointerv(GetPointervPName, void**)"/>
    public static unsafe void GetPointer(GetPointervPName pname, void** parameters)
    {
        GetPointerv(pname, parameters);
    }
    /// <inheritdoc cref="GetProgramBinary(int, int, int*, All*, void*)"/>
    public static unsafe void GetProgramBinary(int program, int bufSize, out int length, out All binaryFormat, IntPtr binary)
    {
        fixed (int* length_ptr = &length)
        fixed (All* binaryFormat_ptr = &binaryFormat)
        {
            void* binary_vptr = (void*)binary;
            GetProgramBinary(program, bufSize, length_ptr, binaryFormat_ptr, binary_vptr);
        }
    }
    /// <inheritdoc cref="GetProgramBinary(int, int, int*, All*, void*)"/>
    public static unsafe void GetProgramBinary<T1>(int program, int bufSize, out int length, out All binaryFormat, Span<T1> binary)
        where T1 : unmanaged
    {
        fixed (int* length_ptr = &length)
        fixed (All* binaryFormat_ptr = &binaryFormat)
        {
            fixed (void* binary_ptr = binary)
            {
                GetProgramBinary(program, bufSize, length_ptr, binaryFormat_ptr, binary_ptr);
            }
        }
    }
    /// <inheritdoc cref="GetProgramBinary(int, int, int*, All*, void*)"/>
    public static unsafe void GetProgramBinary<T1>(int program, int bufSize, out int length, out All binaryFormat, T1[] binary)
        where T1 : unmanaged
    {
        fixed (int* length_ptr = &length)
        fixed (All* binaryFormat_ptr = &binaryFormat)
        {
            fixed (void* binary_ptr = binary)
            {
                GetProgramBinary(program, bufSize, length_ptr, binaryFormat_ptr, binary_ptr);
            }
        }
    }
    /// <inheritdoc cref="GetProgramBinary(int, int, int*, All*, void*)"/>
    public static unsafe void GetProgramBinary<T1>(int program, int bufSize, out int length, out All binaryFormat, ref T1 binary)
        where T1 : unmanaged
    {
        fixed (int* length_ptr = &length)
        fixed (All* binaryFormat_ptr = &binaryFormat)
        fixed (void* binary_ptr = &binary)
        {
            GetProgramBinary(program, bufSize, length_ptr, binaryFormat_ptr, binary_ptr);
        }
    }
    /// <inheritdoc cref="GetProgramInfoLog(int, int, int*, byte*)"/>
    public static unsafe string GetProgramInfoLog(int program, int bufSize, out int length)
    {
        string infoLog;
        fixed (int* length_ptr = &length)
        {
            var infoLog_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetProgramInfoLog(program, bufSize, length_ptr, infoLog_ptr);
            infoLog = Marshal.PtrToStringUTF8((IntPtr)infoLog_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)infoLog_ptr);
        }
        return infoLog;
    }
    /// <inheritdoc cref="GetProgramInfoLog(int, int, int*, byte*)"/>
    public static unsafe void GetProgramInfoLog(int program, int bufSize, out int length, out string infoLog)
    {
        fixed (int* length_ptr = &length)
        {
            var infoLog_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetProgramInfoLog(program, bufSize, length_ptr, infoLog_ptr);
            infoLog = Marshal.PtrToStringUTF8((IntPtr)infoLog_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)infoLog_ptr);
        }
    }
    /// <inheritdoc cref="GetProgramInterfaceiv(int, ProgramInterface, ProgramInterfacePName, int*)"/>
    public static unsafe void GetProgramInterfacei(int program, ProgramInterface programInterface, ProgramInterfacePName pname, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetProgramInterfaceiv(program, programInterface, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetProgramInterfaceiv(int, ProgramInterface, ProgramInterfacePName, int*)"/>
    public static unsafe void GetProgramInterfacei(int program, ProgramInterface programInterface, ProgramInterfacePName pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetProgramInterfaceiv(program, programInterface, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetProgramInterfaceiv(int, ProgramInterface, ProgramInterfacePName, int*)"/>
    public static unsafe int GetProgramInterfacei(int program, ProgramInterface programInterface, ProgramInterfacePName pname)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        {
            GetProgramInterfaceiv(program, programInterface, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetProgramInterfaceiv(int, ProgramInterface, ProgramInterfacePName, int*)"/>
    public static unsafe void GetProgramInterfacei(int program, ProgramInterface programInterface, ProgramInterfacePName pname, out int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetProgramInterfaceiv(program, programInterface, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetProgramiv(int, ProgramProperty, int*)"/>
    public static unsafe void GetProgrami(int program, ProgramProperty pname, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetProgramiv(program, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetProgramiv(int, ProgramProperty, int*)"/>
    public static unsafe void GetProgrami(int program, ProgramProperty pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetProgramiv(program, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetProgramiv(int, ProgramProperty, int*)"/>
    public static unsafe int GetProgrami(int program, ProgramProperty pname)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        {
            GetProgramiv(program, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetProgramiv(int, ProgramProperty, int*)"/>
    public static unsafe void GetProgrami(int program, ProgramProperty pname, out int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetProgramiv(program, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetProgramPipelineInfoLog(int, int, int*, byte*)"/>
    public static unsafe string GetProgramPipelineInfoLog(int pipeline, int bufSize, out int length)
    {
        string infoLog;
        fixed (int* length_ptr = &length)
        {
            var infoLog_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetProgramPipelineInfoLog(pipeline, bufSize, length_ptr, infoLog_ptr);
            infoLog = Marshal.PtrToStringUTF8((IntPtr)infoLog_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)infoLog_ptr);
        }
        return infoLog;
    }
    /// <inheritdoc cref="GetProgramPipelineInfoLog(int, int, int*, byte*)"/>
    public static unsafe void GetProgramPipelineInfoLog(int pipeline, int bufSize, out int length, out string infoLog)
    {
        fixed (int* length_ptr = &length)
        {
            var infoLog_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetProgramPipelineInfoLog(pipeline, bufSize, length_ptr, infoLog_ptr);
            infoLog = Marshal.PtrToStringUTF8((IntPtr)infoLog_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)infoLog_ptr);
        }
    }
    /// <inheritdoc cref="GetProgramPipelineiv(int, PipelineParameterName, int*)"/>
    public static unsafe void GetProgramPipelinei(int pipeline, PipelineParameterName pname, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetProgramPipelineiv(pipeline, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetProgramPipelineiv(int, PipelineParameterName, int*)"/>
    public static unsafe void GetProgramPipelinei(int pipeline, PipelineParameterName pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetProgramPipelineiv(pipeline, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetProgramPipelineiv(int, PipelineParameterName, int*)"/>
    public static unsafe int GetProgramPipelinei(int pipeline, PipelineParameterName pname)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        {
            GetProgramPipelineiv(pipeline, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetProgramPipelineiv(int, PipelineParameterName, int*)"/>
    public static unsafe void GetProgramPipelinei(int pipeline, PipelineParameterName pname, out int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetProgramPipelineiv(pipeline, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetProgramResourceIndex(int, ProgramInterface, byte*)"/>
    public static unsafe uint GetProgramResourceIndex(int program, ProgramInterface programInterface, string name)
    {
        byte* name_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(name);
        var returnValue = GetProgramResourceIndex(program, programInterface, name_ptr);
        Marshal.FreeCoTaskMem((IntPtr)name_ptr);
        return returnValue;
    }
    /// <inheritdoc cref="GetProgramResourceiv(int, ProgramInterface, uint, int, ProgramResourceProperty*, int, int*, int*)"/>
    public static unsafe void GetProgramResourcei(int program, ProgramInterface programInterface, uint index, int propCount, ReadOnlySpan<ProgramResourceProperty> props, int count, out int length, Span<int> parameters)
    {
        fixed (int* length_ptr = &length)
        {
            fixed (int* parameters_ptr = parameters)
            {
                fixed (ProgramResourceProperty* props_ptr = props)
                {
                    GetProgramResourceiv(program, programInterface, index, propCount, props_ptr, count, length_ptr, parameters_ptr);
                }
            }
        }
    }
    /// <inheritdoc cref="GetProgramResourceiv(int, ProgramInterface, uint, int, ProgramResourceProperty*, int, int*, int*)"/>
    public static unsafe void GetProgramResourcei(int program, ProgramInterface programInterface, uint index, int propCount, ProgramResourceProperty[] props, int count, out int length, int[] parameters)
    {
        fixed (int* length_ptr = &length)
        {
            fixed (int* parameters_ptr = parameters)
            {
                fixed (ProgramResourceProperty* props_ptr = props)
                {
                    GetProgramResourceiv(program, programInterface, index, propCount, props_ptr, count, length_ptr, parameters_ptr);
                }
            }
        }
    }
    /// <inheritdoc cref="GetProgramResourceiv(int, ProgramInterface, uint, int, ProgramResourceProperty*, int, int*, int*)"/>
    public static unsafe void GetProgramResourcei(int program, ProgramInterface programInterface, uint index, int propCount, ref readonly ProgramResourceProperty props, int count, out int length, ref int parameters)
    {
        fixed (ProgramResourceProperty* props_ptr = &props)
        fixed (int* length_ptr = &length)
        fixed (int* parameters_ptr = &parameters)
        {
            GetProgramResourceiv(program, programInterface, index, propCount, props_ptr, count, length_ptr, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetProgramResourceLocation(int, ProgramInterface, byte*)"/>
    public static unsafe int GetProgramResourceLocation(int program, ProgramInterface programInterface, string name)
    {
        byte* name_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(name);
        var returnValue = GetProgramResourceLocation(program, programInterface, name_ptr);
        Marshal.FreeCoTaskMem((IntPtr)name_ptr);
        return returnValue;
    }
    /// <inheritdoc cref="GetProgramResourceName(int, ProgramInterface, uint, int, int*, byte*)"/>
    public static unsafe string GetProgramResourceName(int program, ProgramInterface programInterface, uint index, int bufSize, out int length)
    {
        string name;
        fixed (int* length_ptr = &length)
        {
            var name_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetProgramResourceName(program, programInterface, index, bufSize, length_ptr, name_ptr);
            name = Marshal.PtrToStringUTF8((IntPtr)name_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)name_ptr);
        }
        return name;
    }
    /// <inheritdoc cref="GetProgramResourceName(int, ProgramInterface, uint, int, int*, byte*)"/>
    public static unsafe void GetProgramResourceName(int program, ProgramInterface programInterface, uint index, int bufSize, out int length, out string name)
    {
        fixed (int* length_ptr = &length)
        {
            var name_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetProgramResourceName(program, programInterface, index, bufSize, length_ptr, name_ptr);
            name = Marshal.PtrToStringUTF8((IntPtr)name_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)name_ptr);
        }
    }
    /// <inheritdoc cref="GetQueryiv(QueryTarget, QueryParameterName, int*)"/>
    public static unsafe void GetQueryi(QueryTarget target, QueryParameterName pname, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetQueryiv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetQueryiv(QueryTarget, QueryParameterName, int*)"/>
    public static unsafe void GetQueryi(QueryTarget target, QueryParameterName pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetQueryiv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetQueryiv(QueryTarget, QueryParameterName, int*)"/>
    public static unsafe int GetQueryi(QueryTarget target, QueryParameterName pname)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        {
            GetQueryiv(target, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetQueryiv(QueryTarget, QueryParameterName, int*)"/>
    public static unsafe void GetQueryi(QueryTarget target, QueryParameterName pname, out int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetQueryiv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetQueryObjectuiv(int, QueryObjectParameterName, uint*)"/>
    public static unsafe void GetQueryObjectui(int id, QueryObjectParameterName pname, Span<uint> parameters)
    {
        fixed (uint* parameters_ptr = parameters)
        {
            GetQueryObjectuiv(id, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetQueryObjectuiv(int, QueryObjectParameterName, uint*)"/>
    public static unsafe void GetQueryObjectui(int id, QueryObjectParameterName pname, uint[] parameters)
    {
        fixed (uint* parameters_ptr = parameters)
        {
            GetQueryObjectuiv(id, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetQueryObjectuiv(int, QueryObjectParameterName, uint*)"/>
    public static unsafe uint GetQueryObjectui(int id, QueryObjectParameterName pname)
    {
        uint parameters;
        uint* parameters_ptr = &parameters;
        {
            GetQueryObjectuiv(id, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetQueryObjectuiv(int, QueryObjectParameterName, uint*)"/>
    public static unsafe void GetQueryObjectui(int id, QueryObjectParameterName pname, out uint parameters)
    {
        fixed (uint* parameters_ptr = &parameters)
        {
            GetQueryObjectuiv(id, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetRenderbufferParameteriv(RenderbufferTarget, RenderbufferParameterName, int*)"/>
    public static unsafe void GetRenderbufferParameteri(RenderbufferTarget target, RenderbufferParameterName pname, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetRenderbufferParameteriv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetRenderbufferParameteriv(RenderbufferTarget, RenderbufferParameterName, int*)"/>
    public static unsafe void GetRenderbufferParameteri(RenderbufferTarget target, RenderbufferParameterName pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetRenderbufferParameteriv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetRenderbufferParameteriv(RenderbufferTarget, RenderbufferParameterName, int*)"/>
    public static unsafe int GetRenderbufferParameteri(RenderbufferTarget target, RenderbufferParameterName pname)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        {
            GetRenderbufferParameteriv(target, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetRenderbufferParameteriv(RenderbufferTarget, RenderbufferParameterName, int*)"/>
    public static unsafe void GetRenderbufferParameteri(RenderbufferTarget target, RenderbufferParameterName pname, out int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetRenderbufferParameteriv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetSamplerParameterfv(int, SamplerParameterF, float*)"/>
    public static unsafe void GetSamplerParameterf(int sampler, SamplerParameterF pname, Span<float> parameters)
    {
        fixed (float* parameters_ptr = parameters)
        {
            GetSamplerParameterfv(sampler, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetSamplerParameterfv(int, SamplerParameterF, float*)"/>
    public static unsafe void GetSamplerParameterf(int sampler, SamplerParameterF pname, float[] parameters)
    {
        fixed (float* parameters_ptr = parameters)
        {
            GetSamplerParameterfv(sampler, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetSamplerParameterfv(int, SamplerParameterF, float*)"/>
    public static unsafe float GetSamplerParameterf(int sampler, SamplerParameterF pname)
    {
        float parameters;
        float* parameters_ptr = &parameters;
        {
            GetSamplerParameterfv(sampler, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetSamplerParameterfv(int, SamplerParameterF, float*)"/>
    public static unsafe void GetSamplerParameterf(int sampler, SamplerParameterF pname, out float parameters)
    {
        fixed (float* parameters_ptr = &parameters)
        {
            GetSamplerParameterfv(sampler, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetSamplerParameterIiv(int, SamplerParameterI, int*)"/>
    public static unsafe void GetSamplerParameterIi(int sampler, SamplerParameterI pname, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetSamplerParameterIiv(sampler, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetSamplerParameterIiv(int, SamplerParameterI, int*)"/>
    public static unsafe void GetSamplerParameterIi(int sampler, SamplerParameterI pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetSamplerParameterIiv(sampler, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetSamplerParameterIiv(int, SamplerParameterI, int*)"/>
    public static unsafe int GetSamplerParameterIi(int sampler, SamplerParameterI pname)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        {
            GetSamplerParameterIiv(sampler, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetSamplerParameterIiv(int, SamplerParameterI, int*)"/>
    public static unsafe void GetSamplerParameterIi(int sampler, SamplerParameterI pname, out int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetSamplerParameterIiv(sampler, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetSamplerParameterIuiv(int, SamplerParameterI, uint*)"/>
    public static unsafe void GetSamplerParameterIui(int sampler, SamplerParameterI pname, Span<uint> parameters)
    {
        fixed (uint* parameters_ptr = parameters)
        {
            GetSamplerParameterIuiv(sampler, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetSamplerParameterIuiv(int, SamplerParameterI, uint*)"/>
    public static unsafe void GetSamplerParameterIui(int sampler, SamplerParameterI pname, uint[] parameters)
    {
        fixed (uint* parameters_ptr = parameters)
        {
            GetSamplerParameterIuiv(sampler, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetSamplerParameterIuiv(int, SamplerParameterI, uint*)"/>
    public static unsafe uint GetSamplerParameterIui(int sampler, SamplerParameterI pname)
    {
        uint parameters;
        uint* parameters_ptr = &parameters;
        {
            GetSamplerParameterIuiv(sampler, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetSamplerParameterIuiv(int, SamplerParameterI, uint*)"/>
    public static unsafe void GetSamplerParameterIui(int sampler, SamplerParameterI pname, out uint parameters)
    {
        fixed (uint* parameters_ptr = &parameters)
        {
            GetSamplerParameterIuiv(sampler, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetSamplerParameteriv(int, SamplerParameterI, int*)"/>
    public static unsafe void GetSamplerParameteri(int sampler, SamplerParameterI pname, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetSamplerParameteriv(sampler, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetSamplerParameteriv(int, SamplerParameterI, int*)"/>
    public static unsafe void GetSamplerParameteri(int sampler, SamplerParameterI pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetSamplerParameteriv(sampler, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetSamplerParameteriv(int, SamplerParameterI, int*)"/>
    public static unsafe int GetSamplerParameteri(int sampler, SamplerParameterI pname)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        {
            GetSamplerParameteriv(sampler, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetSamplerParameteriv(int, SamplerParameterI, int*)"/>
    public static unsafe void GetSamplerParameteri(int sampler, SamplerParameterI pname, out int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetSamplerParameteriv(sampler, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetShaderInfoLog(int, int, int*, byte*)"/>
    public static unsafe string GetShaderInfoLog(int shader, int bufSize, out int length)
    {
        string infoLog;
        fixed (int* length_ptr = &length)
        {
            var infoLog_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetShaderInfoLog(shader, bufSize, length_ptr, infoLog_ptr);
            infoLog = Marshal.PtrToStringUTF8((IntPtr)infoLog_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)infoLog_ptr);
        }
        return infoLog;
    }
    /// <inheritdoc cref="GetShaderInfoLog(int, int, int*, byte*)"/>
    public static unsafe void GetShaderInfoLog(int shader, int bufSize, out int length, out string infoLog)
    {
        fixed (int* length_ptr = &length)
        {
            var infoLog_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetShaderInfoLog(shader, bufSize, length_ptr, infoLog_ptr);
            infoLog = Marshal.PtrToStringUTF8((IntPtr)infoLog_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)infoLog_ptr);
        }
    }
    /// <inheritdoc cref="GetShaderiv(int, ShaderParameterName, int*)"/>
    public static unsafe void GetShaderi(int shader, ShaderParameterName pname, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetShaderiv(shader, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetShaderiv(int, ShaderParameterName, int*)"/>
    public static unsafe void GetShaderi(int shader, ShaderParameterName pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetShaderiv(shader, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetShaderiv(int, ShaderParameterName, int*)"/>
    public static unsafe int GetShaderi(int shader, ShaderParameterName pname)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        {
            GetShaderiv(shader, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetShaderiv(int, ShaderParameterName, int*)"/>
    public static unsafe void GetShaderi(int shader, ShaderParameterName pname, out int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetShaderiv(shader, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetShaderPrecisionFormat(ShaderType, PrecisionType, int*, int*)"/>
    public static unsafe int GetShaderPrecisionFormat(ShaderType shadertype, PrecisionType precisiontype, Span<int> range)
    {
        int precision;
        int* precision_ptr = &precision;
        {
            fixed (int* range_ptr = range)
            {
                GetShaderPrecisionFormat(shadertype, precisiontype, range_ptr, precision_ptr);
            }
        }
        return precision;
    }
    /// <inheritdoc cref="GetShaderPrecisionFormat(ShaderType, PrecisionType, int*, int*)"/>
    public static unsafe void GetShaderPrecisionFormat(ShaderType shadertype, PrecisionType precisiontype, Span<int> range, out int precision)
    {
        fixed (int* precision_ptr = &precision)
        {
            fixed (int* range_ptr = range)
            {
                GetShaderPrecisionFormat(shadertype, precisiontype, range_ptr, precision_ptr);
            }
        }
    }
    /// <inheritdoc cref="GetShaderPrecisionFormat(ShaderType, PrecisionType, int*, int*)"/>
    public static unsafe int GetShaderPrecisionFormat(ShaderType shadertype, PrecisionType precisiontype, int[] range)
    {
        int precision;
        int* precision_ptr = &precision;
        {
            fixed (int* range_ptr = range)
            {
                GetShaderPrecisionFormat(shadertype, precisiontype, range_ptr, precision_ptr);
            }
        }
        return precision;
    }
    /// <inheritdoc cref="GetShaderPrecisionFormat(ShaderType, PrecisionType, int*, int*)"/>
    public static unsafe void GetShaderPrecisionFormat(ShaderType shadertype, PrecisionType precisiontype, int[] range, out int precision)
    {
        fixed (int* precision_ptr = &precision)
        {
            fixed (int* range_ptr = range)
            {
                GetShaderPrecisionFormat(shadertype, precisiontype, range_ptr, precision_ptr);
            }
        }
    }
    /// <inheritdoc cref="GetShaderPrecisionFormat(ShaderType, PrecisionType, int*, int*)"/>
    public static unsafe int GetShaderPrecisionFormat(ShaderType shadertype, PrecisionType precisiontype, ref int range)
    {
        int precision;
        int* precision_ptr = &precision;
        fixed (int* range_ptr = &range)
        {
            GetShaderPrecisionFormat(shadertype, precisiontype, range_ptr, precision_ptr);
        }
        return precision;
    }
    /// <inheritdoc cref="GetShaderPrecisionFormat(ShaderType, PrecisionType, int*, int*)"/>
    public static unsafe void GetShaderPrecisionFormat(ShaderType shadertype, PrecisionType precisiontype, ref int range, out int precision)
    {
        fixed (int* range_ptr = &range)
        fixed (int* precision_ptr = &precision)
        {
            GetShaderPrecisionFormat(shadertype, precisiontype, range_ptr, precision_ptr);
        }
    }
    /// <inheritdoc cref="GetShaderSource(int, int, int*, byte*)"/>
    public static unsafe string GetShaderSource(int shader, int bufSize, out int length)
    {
        string source;
        fixed (int* length_ptr = &length)
        {
            var source_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetShaderSource(shader, bufSize, length_ptr, source_ptr);
            source = Marshal.PtrToStringUTF8((IntPtr)source_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)source_ptr);
        }
        return source;
    }
    /// <inheritdoc cref="GetShaderSource(int, int, int*, byte*)"/>
    public static unsafe void GetShaderSource(int shader, int bufSize, out int length, out string source)
    {
        fixed (int* length_ptr = &length)
        {
            var source_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetShaderSource(shader, bufSize, length_ptr, source_ptr);
            source = Marshal.PtrToStringUTF8((IntPtr)source_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)source_ptr);
        }
    }
    /// <inheritdoc cref="GetString_(StringName)"/>
    public static unsafe string? GetString(StringName name)
    {
        var returnValue = GetString_(name);
        var returnValue_str = Marshal.PtrToStringAnsi((IntPtr)returnValue);
        return returnValue_str;
    }
    /// <inheritdoc cref="GetStringi_(StringName, uint)"/>
    public static unsafe string? GetStringi(StringName name, uint index)
    {
        var returnValue = GetStringi_(name, index);
        var returnValue_str = Marshal.PtrToStringAnsi((IntPtr)returnValue);
        return returnValue_str;
    }
    /// <inheritdoc cref="GetSynciv(GLSync, SyncParameterName, int, int*, int*)"/>
    public static unsafe void GetSynci(GLSync sync, SyncParameterName pname, int count, out int length, Span<int> values)
    {
        fixed (int* length_ptr = &length)
        {
            fixed (int* values_ptr = values)
            {
                GetSynciv(sync, pname, count, length_ptr, values_ptr);
            }
        }
    }
    /// <inheritdoc cref="GetSynciv(GLSync, SyncParameterName, int, int*, int*)"/>
    public static unsafe void GetSynci(GLSync sync, SyncParameterName pname, int count, out int length, int[] values)
    {
        fixed (int* length_ptr = &length)
        {
            fixed (int* values_ptr = values)
            {
                GetSynciv(sync, pname, count, length_ptr, values_ptr);
            }
        }
    }
    /// <inheritdoc cref="GetSynciv(GLSync, SyncParameterName, int, int*, int*)"/>
    public static unsafe void GetSynci(GLSync sync, SyncParameterName pname, int count, out int length, ref int values)
    {
        fixed (int* length_ptr = &length)
        fixed (int* values_ptr = &values)
        {
            GetSynciv(sync, pname, count, length_ptr, values_ptr);
        }
    }
    /// <inheritdoc cref="GetTexLevelParameterfv(TextureTarget, int, GetTextureParameter, float*)"/>
    public static unsafe void GetTexLevelParameterf(TextureTarget target, int level, GetTextureParameter pname, Span<float> parameters)
    {
        fixed (float* parameters_ptr = parameters)
        {
            GetTexLevelParameterfv(target, level, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTexLevelParameterfv(TextureTarget, int, GetTextureParameter, float*)"/>
    public static unsafe void GetTexLevelParameterf(TextureTarget target, int level, GetTextureParameter pname, float[] parameters)
    {
        fixed (float* parameters_ptr = parameters)
        {
            GetTexLevelParameterfv(target, level, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTexLevelParameterfv(TextureTarget, int, GetTextureParameter, float*)"/>
    public static unsafe float GetTexLevelParameterf(TextureTarget target, int level, GetTextureParameter pname)
    {
        float parameters;
        float* parameters_ptr = &parameters;
        {
            GetTexLevelParameterfv(target, level, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetTexLevelParameterfv(TextureTarget, int, GetTextureParameter, float*)"/>
    public static unsafe void GetTexLevelParameterf(TextureTarget target, int level, GetTextureParameter pname, out float parameters)
    {
        fixed (float* parameters_ptr = &parameters)
        {
            GetTexLevelParameterfv(target, level, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTexLevelParameteriv(TextureTarget, int, GetTextureParameter, int*)"/>
    public static unsafe void GetTexLevelParameteri(TextureTarget target, int level, GetTextureParameter pname, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetTexLevelParameteriv(target, level, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTexLevelParameteriv(TextureTarget, int, GetTextureParameter, int*)"/>
    public static unsafe void GetTexLevelParameteri(TextureTarget target, int level, GetTextureParameter pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetTexLevelParameteriv(target, level, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTexLevelParameteriv(TextureTarget, int, GetTextureParameter, int*)"/>
    public static unsafe int GetTexLevelParameteri(TextureTarget target, int level, GetTextureParameter pname)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        {
            GetTexLevelParameteriv(target, level, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetTexLevelParameteriv(TextureTarget, int, GetTextureParameter, int*)"/>
    public static unsafe void GetTexLevelParameteri(TextureTarget target, int level, GetTextureParameter pname, out int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetTexLevelParameteriv(target, level, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTexParameterfv(TextureTarget, GetTextureParameter, float*)"/>
    public static unsafe void GetTexParameterf(TextureTarget target, GetTextureParameter pname, Span<float> parameters)
    {
        fixed (float* parameters_ptr = parameters)
        {
            GetTexParameterfv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTexParameterfv(TextureTarget, GetTextureParameter, float*)"/>
    public static unsafe void GetTexParameterf(TextureTarget target, GetTextureParameter pname, float[] parameters)
    {
        fixed (float* parameters_ptr = parameters)
        {
            GetTexParameterfv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTexParameterfv(TextureTarget, GetTextureParameter, float*)"/>
    public static unsafe float GetTexParameterf(TextureTarget target, GetTextureParameter pname)
    {
        float parameters;
        float* parameters_ptr = &parameters;
        {
            GetTexParameterfv(target, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetTexParameterfv(TextureTarget, GetTextureParameter, float*)"/>
    public static unsafe void GetTexParameterf(TextureTarget target, GetTextureParameter pname, out float parameters)
    {
        fixed (float* parameters_ptr = &parameters)
        {
            GetTexParameterfv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTexParameterIiv(TextureTarget, GetTextureParameter, int*)"/>
    public static unsafe void GetTexParameterIi(TextureTarget target, GetTextureParameter pname, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetTexParameterIiv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTexParameterIiv(TextureTarget, GetTextureParameter, int*)"/>
    public static unsafe void GetTexParameterIi(TextureTarget target, GetTextureParameter pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetTexParameterIiv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTexParameterIiv(TextureTarget, GetTextureParameter, int*)"/>
    public static unsafe int GetTexParameterIi(TextureTarget target, GetTextureParameter pname)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        {
            GetTexParameterIiv(target, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetTexParameterIiv(TextureTarget, GetTextureParameter, int*)"/>
    public static unsafe void GetTexParameterIi(TextureTarget target, GetTextureParameter pname, out int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetTexParameterIiv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTexParameterIuiv(TextureTarget, GetTextureParameter, uint*)"/>
    public static unsafe void GetTexParameterIui(TextureTarget target, GetTextureParameter pname, Span<uint> parameters)
    {
        fixed (uint* parameters_ptr = parameters)
        {
            GetTexParameterIuiv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTexParameterIuiv(TextureTarget, GetTextureParameter, uint*)"/>
    public static unsafe void GetTexParameterIui(TextureTarget target, GetTextureParameter pname, uint[] parameters)
    {
        fixed (uint* parameters_ptr = parameters)
        {
            GetTexParameterIuiv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTexParameterIuiv(TextureTarget, GetTextureParameter, uint*)"/>
    public static unsafe uint GetTexParameterIui(TextureTarget target, GetTextureParameter pname)
    {
        uint parameters;
        uint* parameters_ptr = &parameters;
        {
            GetTexParameterIuiv(target, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetTexParameterIuiv(TextureTarget, GetTextureParameter, uint*)"/>
    public static unsafe void GetTexParameterIui(TextureTarget target, GetTextureParameter pname, out uint parameters)
    {
        fixed (uint* parameters_ptr = &parameters)
        {
            GetTexParameterIuiv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTexParameteriv(TextureTarget, GetTextureParameter, int*)"/>
    public static unsafe void GetTexParameteri(TextureTarget target, GetTextureParameter pname, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetTexParameteriv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTexParameteriv(TextureTarget, GetTextureParameter, int*)"/>
    public static unsafe void GetTexParameteri(TextureTarget target, GetTextureParameter pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetTexParameteriv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTexParameteriv(TextureTarget, GetTextureParameter, int*)"/>
    public static unsafe int GetTexParameteri(TextureTarget target, GetTextureParameter pname)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        {
            GetTexParameteriv(target, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetTexParameteriv(TextureTarget, GetTextureParameter, int*)"/>
    public static unsafe void GetTexParameteri(TextureTarget target, GetTextureParameter pname, out int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetTexParameteriv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetTransformFeedbackVarying(int, uint, int, int*, int*, AttributeType*, byte*)"/>
    public static unsafe string GetTransformFeedbackVarying(int program, uint index, int bufSize, out int length, out int size, out AttributeType type)
    {
        string name;
        fixed (int* length_ptr = &length)
        fixed (int* size_ptr = &size)
        fixed (AttributeType* type_ptr = &type)
        {
            var name_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetTransformFeedbackVarying(program, index, bufSize, length_ptr, size_ptr, type_ptr, name_ptr);
            name = Marshal.PtrToStringUTF8((IntPtr)name_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)name_ptr);
        }
        return name;
    }
    /// <inheritdoc cref="GetTransformFeedbackVarying(int, uint, int, int*, int*, AttributeType*, byte*)"/>
    public static unsafe void GetTransformFeedbackVarying(int program, uint index, int bufSize, out int length, out int size, out AttributeType type, out string name)
    {
        fixed (int* length_ptr = &length)
        fixed (int* size_ptr = &size)
        fixed (AttributeType* type_ptr = &type)
        {
            var name_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
            GetTransformFeedbackVarying(program, index, bufSize, length_ptr, size_ptr, type_ptr, name_ptr);
            name = Marshal.PtrToStringUTF8((IntPtr)name_ptr)!;
            Marshal.FreeCoTaskMem((IntPtr)name_ptr);
        }
    }
    /// <inheritdoc cref="GetUniformBlockIndex(int, byte*)"/>
    public static unsafe uint GetUniformBlockIndex(int program, string uniformBlockName)
    {
        byte* uniformBlockName_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(uniformBlockName);
        var returnValue = GetUniformBlockIndex(program, uniformBlockName_ptr);
        Marshal.FreeCoTaskMem((IntPtr)uniformBlockName_ptr);
        return returnValue;
    }
    /// <inheritdoc cref="GetUniformfv(int, int, float*)"/>
    public static unsafe void GetUniformf(int program, int location, Span<float> parameters)
    {
        fixed (float* parameters_ptr = parameters)
        {
            GetUniformfv(program, location, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetUniformfv(int, int, float*)"/>
    public static unsafe void GetUniformf(int program, int location, float[] parameters)
    {
        fixed (float* parameters_ptr = parameters)
        {
            GetUniformfv(program, location, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetUniformfv(int, int, float*)"/>
    public static unsafe float GetUniformf(int program, int location)
    {
        float parameters;
        float* parameters_ptr = &parameters;
        {
            GetUniformfv(program, location, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetUniformfv(int, int, float*)"/>
    public static unsafe void GetUniformf(int program, int location, out float parameters)
    {
        fixed (float* parameters_ptr = &parameters)
        {
            GetUniformfv(program, location, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetUniformIndices(int, int, byte**, uint*)"/>
    public static unsafe void GetUniformIndices(int program, int uniformCount, string[] uniformNames, Span<uint> uniformIndices)
    {
        fixed (uint* uniformIndices_ptr = uniformIndices)
        {
            byte** uniformNames_ptr = (byte**)MarshalTk.StringArrayToCoTaskMemUTF8(uniformNames);
            GetUniformIndices(program, uniformCount, uniformNames_ptr, uniformIndices_ptr);
            MarshalTk.FreeStringArrayCoTaskMem((IntPtr)uniformNames_ptr, uniformNames.Length);
        }
    }
    /// <inheritdoc cref="GetUniformIndices(int, int, byte**, uint*)"/>
    public static unsafe void GetUniformIndices(int program, int uniformCount, string[] uniformNames, uint[] uniformIndices)
    {
        fixed (uint* uniformIndices_ptr = uniformIndices)
        {
            byte** uniformNames_ptr = (byte**)MarshalTk.StringArrayToCoTaskMemUTF8(uniformNames);
            GetUniformIndices(program, uniformCount, uniformNames_ptr, uniformIndices_ptr);
            MarshalTk.FreeStringArrayCoTaskMem((IntPtr)uniformNames_ptr, uniformNames.Length);
        }
    }
    /// <inheritdoc cref="GetUniformIndices(int, int, byte**, uint*)"/>
    public static unsafe uint GetUniformIndices(int program, int uniformCount, string[] uniformNames)
    {
        uint uniformIndices;
        uint* uniformIndices_ptr = &uniformIndices;
        {
            byte** uniformNames_ptr = (byte**)MarshalTk.StringArrayToCoTaskMemUTF8(uniformNames);
            GetUniformIndices(program, uniformCount, uniformNames_ptr, uniformIndices_ptr);
            MarshalTk.FreeStringArrayCoTaskMem((IntPtr)uniformNames_ptr, uniformNames.Length);
        }
        return uniformIndices;
    }
    /// <inheritdoc cref="GetUniformIndices(int, int, byte**, uint*)"/>
    public static unsafe void GetUniformIndices(int program, int uniformCount, string[] uniformNames, out uint uniformIndices)
    {
        fixed (uint* uniformIndices_ptr = &uniformIndices)
        {
            byte** uniformNames_ptr = (byte**)MarshalTk.StringArrayToCoTaskMemUTF8(uniformNames);
            GetUniformIndices(program, uniformCount, uniformNames_ptr, uniformIndices_ptr);
            MarshalTk.FreeStringArrayCoTaskMem((IntPtr)uniformNames_ptr, uniformNames.Length);
        }
    }
    /// <inheritdoc cref="GetUniformiv(int, int, int*)"/>
    public static unsafe void GetUniformi(int program, int location, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetUniformiv(program, location, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetUniformiv(int, int, int*)"/>
    public static unsafe void GetUniformi(int program, int location, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetUniformiv(program, location, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetUniformiv(int, int, int*)"/>
    public static unsafe int GetUniformi(int program, int location)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        {
            GetUniformiv(program, location, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetUniformiv(int, int, int*)"/>
    public static unsafe void GetUniformi(int program, int location, out int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetUniformiv(program, location, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetUniformLocation(int, byte*)"/>
    public static unsafe int GetUniformLocation(int program, string name)
    {
        byte* name_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(name);
        var returnValue = GetUniformLocation(program, name_ptr);
        Marshal.FreeCoTaskMem((IntPtr)name_ptr);
        return returnValue;
    }
    /// <inheritdoc cref="GetUniformuiv(int, int, uint*)"/>
    public static unsafe void GetUniformui(int program, int location, Span<uint> parameters)
    {
        fixed (uint* parameters_ptr = parameters)
        {
            GetUniformuiv(program, location, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetUniformuiv(int, int, uint*)"/>
    public static unsafe void GetUniformui(int program, int location, uint[] parameters)
    {
        fixed (uint* parameters_ptr = parameters)
        {
            GetUniformuiv(program, location, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetUniformuiv(int, int, uint*)"/>
    public static unsafe uint GetUniformui(int program, int location)
    {
        uint parameters;
        uint* parameters_ptr = &parameters;
        {
            GetUniformuiv(program, location, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetUniformuiv(int, int, uint*)"/>
    public static unsafe void GetUniformui(int program, int location, out uint parameters)
    {
        fixed (uint* parameters_ptr = &parameters)
        {
            GetUniformuiv(program, location, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetVertexAttribfv(uint, VertexAttribPropertyARB, float*)"/>
    public static unsafe void GetVertexAttribf(uint index, VertexAttribPropertyARB pname, Span<float> parameters)
    {
        fixed (float* parameters_ptr = parameters)
        {
            GetVertexAttribfv(index, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetVertexAttribfv(uint, VertexAttribPropertyARB, float*)"/>
    public static unsafe void GetVertexAttribf(uint index, VertexAttribPropertyARB pname, float[] parameters)
    {
        fixed (float* parameters_ptr = parameters)
        {
            GetVertexAttribfv(index, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetVertexAttribfv(uint, VertexAttribPropertyARB, float*)"/>
    public static unsafe void GetVertexAttribf(uint index, VertexAttribPropertyARB pname, ref float parameters)
    {
        fixed (float* parameters_ptr = &parameters)
        {
            GetVertexAttribfv(index, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetVertexAttribIiv(uint, VertexAttribEnum, int*)"/>
    public static unsafe int GetVertexAttribIi(uint index, VertexAttribEnum pname)
    {
        int parameters;
        int* parameters_ptr = &parameters;
        {
            GetVertexAttribIiv(index, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetVertexAttribIiv(uint, VertexAttribEnum, int*)"/>
    public static unsafe void GetVertexAttribIi(uint index, VertexAttribEnum pname, out int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetVertexAttribIiv(index, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetVertexAttribIuiv(uint, VertexAttribEnum, uint*)"/>
    public static unsafe uint GetVertexAttribIui(uint index, VertexAttribEnum pname)
    {
        uint parameters;
        uint* parameters_ptr = &parameters;
        {
            GetVertexAttribIuiv(index, pname, parameters_ptr);
        }
        return parameters;
    }
    /// <inheritdoc cref="GetVertexAttribIuiv(uint, VertexAttribEnum, uint*)"/>
    public static unsafe void GetVertexAttribIui(uint index, VertexAttribEnum pname, out uint parameters)
    {
        fixed (uint* parameters_ptr = &parameters)
        {
            GetVertexAttribIuiv(index, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetVertexAttribiv(uint, VertexAttribPropertyARB, int*)"/>
    public static unsafe void GetVertexAttribi(uint index, VertexAttribPropertyARB pname, Span<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetVertexAttribiv(index, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetVertexAttribiv(uint, VertexAttribPropertyARB, int*)"/>
    public static unsafe void GetVertexAttribi(uint index, VertexAttribPropertyARB pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            GetVertexAttribiv(index, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetVertexAttribiv(uint, VertexAttribPropertyARB, int*)"/>
    public static unsafe void GetVertexAttribi(uint index, VertexAttribPropertyARB pname, ref int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            GetVertexAttribiv(index, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="GetVertexAttribPointerv(uint, VertexAttribPointerPropertyARB, void**)"/>
    public static unsafe void GetVertexAttribPointer(uint index, VertexAttribPointerPropertyARB pname, void** pointer)
    {
        GetVertexAttribPointerv(index, pname, pointer);
    }
    /// <inheritdoc cref="InvalidateFramebuffer(FramebufferTarget, int, InvalidateFramebufferAttachment*)"/>
    public static unsafe void InvalidateFramebuffer(FramebufferTarget target, int numAttachments, ReadOnlySpan<InvalidateFramebufferAttachment> attachments)
    {
        fixed (InvalidateFramebufferAttachment* attachments_ptr = attachments)
        {
            InvalidateFramebuffer(target, numAttachments, attachments_ptr);
        }
    }
    /// <inheritdoc cref="InvalidateFramebuffer(FramebufferTarget, int, InvalidateFramebufferAttachment*)"/>
    public static unsafe void InvalidateFramebuffer(FramebufferTarget target, int numAttachments, InvalidateFramebufferAttachment[] attachments)
    {
        fixed (InvalidateFramebufferAttachment* attachments_ptr = attachments)
        {
            InvalidateFramebuffer(target, numAttachments, attachments_ptr);
        }
    }
    /// <inheritdoc cref="InvalidateFramebuffer(FramebufferTarget, int, InvalidateFramebufferAttachment*)"/>
    public static unsafe void InvalidateFramebuffer(FramebufferTarget target, int numAttachments, ref readonly InvalidateFramebufferAttachment attachments)
    {
        fixed (InvalidateFramebufferAttachment* attachments_ptr = &attachments)
        {
            InvalidateFramebuffer(target, numAttachments, attachments_ptr);
        }
    }
    /// <inheritdoc cref="InvalidateSubFramebuffer(FramebufferTarget, int, InvalidateFramebufferAttachment*, int, int, int, int)"/>
    public static unsafe void InvalidateSubFramebuffer(FramebufferTarget target, int numAttachments, ReadOnlySpan<InvalidateFramebufferAttachment> attachments, int x, int y, int width, int height)
    {
        fixed (InvalidateFramebufferAttachment* attachments_ptr = attachments)
        {
            InvalidateSubFramebuffer(target, numAttachments, attachments_ptr, x, y, width, height);
        }
    }
    /// <inheritdoc cref="InvalidateSubFramebuffer(FramebufferTarget, int, InvalidateFramebufferAttachment*, int, int, int, int)"/>
    public static unsafe void InvalidateSubFramebuffer(FramebufferTarget target, int numAttachments, InvalidateFramebufferAttachment[] attachments, int x, int y, int width, int height)
    {
        fixed (InvalidateFramebufferAttachment* attachments_ptr = attachments)
        {
            InvalidateSubFramebuffer(target, numAttachments, attachments_ptr, x, y, width, height);
        }
    }
    /// <inheritdoc cref="InvalidateSubFramebuffer(FramebufferTarget, int, InvalidateFramebufferAttachment*, int, int, int, int)"/>
    public static unsafe void InvalidateSubFramebuffer(FramebufferTarget target, int numAttachments, ref readonly InvalidateFramebufferAttachment attachments, int x, int y, int width, int height)
    {
        fixed (InvalidateFramebufferAttachment* attachments_ptr = &attachments)
        {
            InvalidateSubFramebuffer(target, numAttachments, attachments_ptr, x, y, width, height);
        }
    }
    /// <inheritdoc cref="ObjectLabel(ObjectIdentifier, uint, int, byte*)"/>
    public static unsafe void ObjectLabel(ObjectIdentifier identifier, uint name, int length, string label)
    {
        byte* label_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(label);
        ObjectLabel(identifier, name, length, label_ptr);
        Marshal.FreeCoTaskMem((IntPtr)label_ptr);
    }
    /// <inheritdoc cref="ObjectPtrLabel(void*, int, byte*)"/>
    public static unsafe void ObjectPtrLabel(IntPtr ptr, int length, string label)
    {
        byte* label_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(label);
        void* ptr_vptr = (void*)ptr;
        ObjectPtrLabel(ptr_vptr, length, label_ptr);
        Marshal.FreeCoTaskMem((IntPtr)label_ptr);
    }
    /// <inheritdoc cref="ObjectPtrLabel(void*, int, byte*)"/>
    public static unsafe void ObjectPtrLabel<T1>(ReadOnlySpan<T1> ptr, int length, string label)
        where T1 : unmanaged
    {
        fixed (void* ptr_ptr = ptr)
        {
            byte* label_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(label);
            ObjectPtrLabel(ptr_ptr, length, label_ptr);
            Marshal.FreeCoTaskMem((IntPtr)label_ptr);
        }
    }
    /// <inheritdoc cref="ObjectPtrLabel(void*, int, byte*)"/>
    public static unsafe void ObjectPtrLabel<T1>(T1[] ptr, int length, string label)
        where T1 : unmanaged
    {
        fixed (void* ptr_ptr = ptr)
        {
            byte* label_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(label);
            ObjectPtrLabel(ptr_ptr, length, label_ptr);
            Marshal.FreeCoTaskMem((IntPtr)label_ptr);
        }
    }
    /// <inheritdoc cref="ObjectPtrLabel(void*, int, byte*)"/>
    public static unsafe void ObjectPtrLabel<T1>(ref readonly T1 ptr, int length, string label)
        where T1 : unmanaged
    {
        fixed (void* ptr_ptr = &ptr)
        {
            byte* label_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(label);
            ObjectPtrLabel(ptr_ptr, length, label_ptr);
            Marshal.FreeCoTaskMem((IntPtr)label_ptr);
        }
    }
    /// <inheritdoc cref="ProgramBinary(int, All, void*, int)"/>
    public static unsafe void ProgramBinary(int program, All binaryFormat, IntPtr binary, int length)
    {
        void* binary_vptr = (void*)binary;
        ProgramBinary(program, binaryFormat, binary_vptr, length);
    }
    /// <inheritdoc cref="ProgramBinary(int, All, void*, int)"/>
    public static unsafe void ProgramBinary<T1>(int program, All binaryFormat, ReadOnlySpan<T1> binary, int length)
        where T1 : unmanaged
    {
        fixed (void* binary_ptr = binary)
        {
            ProgramBinary(program, binaryFormat, binary_ptr, length);
        }
    }
    /// <inheritdoc cref="ProgramBinary(int, All, void*, int)"/>
    public static unsafe void ProgramBinary<T1>(int program, All binaryFormat, T1[] binary, int length)
        where T1 : unmanaged
    {
        fixed (void* binary_ptr = binary)
        {
            ProgramBinary(program, binaryFormat, binary_ptr, length);
        }
    }
    /// <inheritdoc cref="ProgramBinary(int, All, void*, int)"/>
    public static unsafe void ProgramBinary<T1>(int program, All binaryFormat, ref readonly T1 binary, int length)
        where T1 : unmanaged
    {
        fixed (void* binary_ptr = &binary)
        {
            ProgramBinary(program, binaryFormat, binary_ptr, length);
        }
    }
    /// <inheritdoc cref="ProgramUniform1fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform1f(int program, int location, int count, ref readonly float value)
    {
        fixed (float* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform1fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform1iv(int, int, int, int*)"/>
    public static unsafe void ProgramUniform1i(int program, int location, int count, ref readonly int value)
    {
        fixed (int* tmp_value = &value)
        {
            int* value_ptr = (int*)tmp_value;
            ProgramUniform1iv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform1uiv(int, int, int, uint*)"/>
    public static unsafe void ProgramUniform1ui(int program, int location, int count, ref readonly uint value)
    {
        fixed (uint* tmp_value = &value)
        {
            uint* value_ptr = (uint*)tmp_value;
            ProgramUniform1uiv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform2fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform2f(int program, int location, int count, ref readonly Vector2 value)
    {
        fixed (Vector2* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform2fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform2fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform2f(int program, int location, int count, ReadOnlySpan<Vector2> value)
    {
        fixed (Vector2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform2fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform2fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform2f(int program, int location, int count, Vector2[] value)
    {
        fixed (Vector2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform2fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform2fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform2f(int program, int location, int count, ref readonly System.Numerics.Vector2 value)
    {
        fixed (System.Numerics.Vector2* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform2fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform2fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform2f(int program, int location, int count, ReadOnlySpan<System.Numerics.Vector2> value)
    {
        fixed (System.Numerics.Vector2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform2fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform2fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform2f(int program, int location, int count, System.Numerics.Vector2[] value)
    {
        fixed (System.Numerics.Vector2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform2fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform2iv(int, int, int, int*)"/>
    public static unsafe void ProgramUniform2i(int program, int location, int count, ref readonly Vector2i value)
    {
        fixed (Vector2i* tmp_value = &value)
        {
            int* value_ptr = (int*)tmp_value;
            ProgramUniform2iv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform2iv(int, int, int, int*)"/>
    public static unsafe void ProgramUniform2i(int program, int location, int count, ReadOnlySpan<Vector2i> value)
    {
        fixed (Vector2i* tmp_value = value)
        {
            int* value_ptr = (int*)tmp_value;
            ProgramUniform2iv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform2iv(int, int, int, int*)"/>
    public static unsafe void ProgramUniform2i(int program, int location, int count, Vector2i[] value)
    {
        fixed (Vector2i* tmp_value = value)
        {
            int* value_ptr = (int*)tmp_value;
            ProgramUniform2iv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform2uiv(int, int, int, uint*)"/>
    public static unsafe void ProgramUniform2ui(int program, int location, int count, ref readonly Vector2i value)
    {
        fixed (Vector2i* tmp_value = &value)
        {
            uint* value_ptr = (uint*)tmp_value;
            ProgramUniform2uiv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform2uiv(int, int, int, uint*)"/>
    public static unsafe void ProgramUniform2ui(int program, int location, int count, ReadOnlySpan<Vector2i> value)
    {
        fixed (Vector2i* tmp_value = value)
        {
            uint* value_ptr = (uint*)tmp_value;
            ProgramUniform2uiv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform2uiv(int, int, int, uint*)"/>
    public static unsafe void ProgramUniform2ui(int program, int location, int count, Vector2i[] value)
    {
        fixed (Vector2i* tmp_value = value)
        {
            uint* value_ptr = (uint*)tmp_value;
            ProgramUniform2uiv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform3fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform3f(int program, int location, int count, ref readonly Vector3 value)
    {
        fixed (Vector3* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform3fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform3fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform3f(int program, int location, int count, ReadOnlySpan<Vector3> value)
    {
        fixed (Vector3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform3fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform3fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform3f(int program, int location, int count, Vector3[] value)
    {
        fixed (Vector3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform3fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform3fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform3f(int program, int location, int count, ref readonly System.Numerics.Vector3 value)
    {
        fixed (System.Numerics.Vector3* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform3fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform3fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform3f(int program, int location, int count, ReadOnlySpan<System.Numerics.Vector3> value)
    {
        fixed (System.Numerics.Vector3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform3fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform3fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform3f(int program, int location, int count, System.Numerics.Vector3[] value)
    {
        fixed (System.Numerics.Vector3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform3fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform3iv(int, int, int, int*)"/>
    public static unsafe void ProgramUniform3i(int program, int location, int count, ref readonly Vector3i value)
    {
        fixed (Vector3i* tmp_value = &value)
        {
            int* value_ptr = (int*)tmp_value;
            ProgramUniform3iv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform3iv(int, int, int, int*)"/>
    public static unsafe void ProgramUniform3i(int program, int location, int count, ReadOnlySpan<Vector3i> value)
    {
        fixed (Vector3i* tmp_value = value)
        {
            int* value_ptr = (int*)tmp_value;
            ProgramUniform3iv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform3iv(int, int, int, int*)"/>
    public static unsafe void ProgramUniform3i(int program, int location, int count, Vector3i[] value)
    {
        fixed (Vector3i* tmp_value = value)
        {
            int* value_ptr = (int*)tmp_value;
            ProgramUniform3iv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform3uiv(int, int, int, uint*)"/>
    public static unsafe void ProgramUniform3ui(int program, int location, int count, ref readonly Vector3i value)
    {
        fixed (Vector3i* tmp_value = &value)
        {
            uint* value_ptr = (uint*)tmp_value;
            ProgramUniform3uiv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform3uiv(int, int, int, uint*)"/>
    public static unsafe void ProgramUniform3ui(int program, int location, int count, ReadOnlySpan<Vector3i> value)
    {
        fixed (Vector3i* tmp_value = value)
        {
            uint* value_ptr = (uint*)tmp_value;
            ProgramUniform3uiv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform3uiv(int, int, int, uint*)"/>
    public static unsafe void ProgramUniform3ui(int program, int location, int count, Vector3i[] value)
    {
        fixed (Vector3i* tmp_value = value)
        {
            uint* value_ptr = (uint*)tmp_value;
            ProgramUniform3uiv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform4fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform4f(int program, int location, int count, ref readonly Vector4 value)
    {
        fixed (Vector4* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform4fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform4fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform4f(int program, int location, int count, ReadOnlySpan<Vector4> value)
    {
        fixed (Vector4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform4fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform4fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform4f(int program, int location, int count, Vector4[] value)
    {
        fixed (Vector4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform4fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform4fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform4f(int program, int location, int count, ref readonly System.Numerics.Vector4 value)
    {
        fixed (System.Numerics.Vector4* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform4fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform4fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform4f(int program, int location, int count, ReadOnlySpan<System.Numerics.Vector4> value)
    {
        fixed (System.Numerics.Vector4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform4fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform4fv(int, int, int, float*)"/>
    public static unsafe void ProgramUniform4f(int program, int location, int count, System.Numerics.Vector4[] value)
    {
        fixed (System.Numerics.Vector4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniform4fv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform4iv(int, int, int, int*)"/>
    public static unsafe void ProgramUniform4i(int program, int location, int count, ref readonly Vector4i value)
    {
        fixed (Vector4i* tmp_value = &value)
        {
            int* value_ptr = (int*)tmp_value;
            ProgramUniform4iv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform4iv(int, int, int, int*)"/>
    public static unsafe void ProgramUniform4i(int program, int location, int count, ReadOnlySpan<Vector4i> value)
    {
        fixed (Vector4i* tmp_value = value)
        {
            int* value_ptr = (int*)tmp_value;
            ProgramUniform4iv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform4iv(int, int, int, int*)"/>
    public static unsafe void ProgramUniform4i(int program, int location, int count, Vector4i[] value)
    {
        fixed (Vector4i* tmp_value = value)
        {
            int* value_ptr = (int*)tmp_value;
            ProgramUniform4iv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform4uiv(int, int, int, uint*)"/>
    public static unsafe void ProgramUniform4ui(int program, int location, int count, ref readonly Vector4i value)
    {
        fixed (Vector4i* tmp_value = &value)
        {
            uint* value_ptr = (uint*)tmp_value;
            ProgramUniform4uiv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform4uiv(int, int, int, uint*)"/>
    public static unsafe void ProgramUniform4ui(int program, int location, int count, ReadOnlySpan<Vector4i> value)
    {
        fixed (Vector4i* tmp_value = value)
        {
            uint* value_ptr = (uint*)tmp_value;
            ProgramUniform4uiv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniform4uiv(int, int, int, uint*)"/>
    public static unsafe void ProgramUniform4ui(int program, int location, int count, Vector4i[] value)
    {
        fixed (Vector4i* tmp_value = value)
        {
            uint* value_ptr = (uint*)tmp_value;
            ProgramUniform4uiv(program, location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix2fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix2f(int program, int location, int count, bool transpose, ref readonly Matrix2 value)
    {
        fixed (Matrix2* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix2fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix2fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix2f(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix2> value)
    {
        fixed (Matrix2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix2fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix2fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix2f(int program, int location, int count, bool transpose, Matrix2[] value)
    {
        fixed (Matrix2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix2fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix2x3fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix2x3f(int program, int location, int count, bool transpose, ref readonly Matrix2x3 value)
    {
        fixed (Matrix2x3* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix2x3fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix2x3fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix2x3f(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix2x3> value)
    {
        fixed (Matrix2x3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix2x3fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix2x3fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix2x3f(int program, int location, int count, bool transpose, Matrix2x3[] value)
    {
        fixed (Matrix2x3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix2x3fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix2x4fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix2x4f(int program, int location, int count, bool transpose, ref readonly Matrix2x4 value)
    {
        fixed (Matrix2x4* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix2x4fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix2x4fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix2x4f(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix2x4> value)
    {
        fixed (Matrix2x4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix2x4fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix2x4fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix2x4f(int program, int location, int count, bool transpose, Matrix2x4[] value)
    {
        fixed (Matrix2x4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix2x4fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix3fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix3f(int program, int location, int count, bool transpose, ref readonly Matrix3 value)
    {
        fixed (Matrix3* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix3fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix3fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix3f(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix3> value)
    {
        fixed (Matrix3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix3fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix3fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix3f(int program, int location, int count, bool transpose, Matrix3[] value)
    {
        fixed (Matrix3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix3fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix3x2fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix3x2f(int program, int location, int count, bool transpose, ref readonly Matrix3x2 value)
    {
        fixed (Matrix3x2* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix3x2fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix3x2fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix3x2f(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix3x2> value)
    {
        fixed (Matrix3x2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix3x2fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix3x2fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix3x2f(int program, int location, int count, bool transpose, Matrix3x2[] value)
    {
        fixed (Matrix3x2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix3x2fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix3x2fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix3x2f(int program, int location, int count, bool transpose, ref readonly System.Numerics.Matrix3x2 value)
    {
        fixed (System.Numerics.Matrix3x2* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix3x2fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix3x2fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix3x2f(int program, int location, int count, bool transpose, ReadOnlySpan<System.Numerics.Matrix3x2> value)
    {
        fixed (System.Numerics.Matrix3x2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix3x2fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix3x2fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix3x2f(int program, int location, int count, bool transpose, System.Numerics.Matrix3x2[] value)
    {
        fixed (System.Numerics.Matrix3x2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix3x2fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix3x4fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix3x4f(int program, int location, int count, bool transpose, ref readonly Matrix3x4 value)
    {
        fixed (Matrix3x4* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix3x4fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix3x4fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix3x4f(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix3x4> value)
    {
        fixed (Matrix3x4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix3x4fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix3x4fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix3x4f(int program, int location, int count, bool transpose, Matrix3x4[] value)
    {
        fixed (Matrix3x4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix3x4fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix4fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix4f(int program, int location, int count, bool transpose, ref readonly Matrix4 value)
    {
        fixed (Matrix4* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix4fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix4fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix4f(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix4> value)
    {
        fixed (Matrix4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix4fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix4fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix4f(int program, int location, int count, bool transpose, Matrix4[] value)
    {
        fixed (Matrix4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix4fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix4fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix4f(int program, int location, int count, bool transpose, ref readonly System.Numerics.Matrix4x4 value)
    {
        fixed (System.Numerics.Matrix4x4* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix4fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix4fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix4f(int program, int location, int count, bool transpose, ReadOnlySpan<System.Numerics.Matrix4x4> value)
    {
        fixed (System.Numerics.Matrix4x4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix4fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix4fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix4f(int program, int location, int count, bool transpose, System.Numerics.Matrix4x4[] value)
    {
        fixed (System.Numerics.Matrix4x4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix4fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix4x2fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix4x2f(int program, int location, int count, bool transpose, ref readonly Matrix4x2 value)
    {
        fixed (Matrix4x2* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix4x2fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix4x2fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix4x2f(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix4x2> value)
    {
        fixed (Matrix4x2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix4x2fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix4x2fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix4x2f(int program, int location, int count, bool transpose, Matrix4x2[] value)
    {
        fixed (Matrix4x2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix4x2fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix4x3fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix4x3f(int program, int location, int count, bool transpose, ref readonly Matrix4x3 value)
    {
        fixed (Matrix4x3* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix4x3fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix4x3fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix4x3f(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix4x3> value)
    {
        fixed (Matrix4x3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix4x3fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="ProgramUniformMatrix4x3fv(int, int, int, bool, float*)"/>
    public static unsafe void ProgramUniformMatrix4x3f(int program, int location, int count, bool transpose, Matrix4x3[] value)
    {
        fixed (Matrix4x3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            ProgramUniformMatrix4x3fv(program, location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="PushDebugGroup(DebugSource, uint, int, byte*)"/>
    public static unsafe void PushDebugGroup(DebugSource source, uint id, int length, string message)
    {
        byte* message_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(message);
        PushDebugGroup(source, id, length, message_ptr);
        Marshal.FreeCoTaskMem((IntPtr)message_ptr);
    }
    /// <inheritdoc cref="ReadnPixels(int, int, int, int, PixelFormat, PixelType, int, void*)"/>
    public static unsafe void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, IntPtr data)
    {
        void* data_vptr = (void*)data;
        ReadnPixels(x, y, width, height, format, type, bufSize, data_vptr);
    }
    /// <inheritdoc cref="ReadnPixels(int, int, int, int, PixelFormat, PixelType, int, void*)"/>
    public static unsafe void ReadnPixels<T1>(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, Span<T1> data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = data)
        {
            ReadnPixels(x, y, width, height, format, type, bufSize, data_ptr);
        }
    }
    /// <inheritdoc cref="ReadnPixels(int, int, int, int, PixelFormat, PixelType, int, void*)"/>
    public static unsafe void ReadnPixels<T1>(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, T1[] data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = data)
        {
            ReadnPixels(x, y, width, height, format, type, bufSize, data_ptr);
        }
    }
    /// <inheritdoc cref="ReadnPixels(int, int, int, int, PixelFormat, PixelType, int, void*)"/>
    public static unsafe void ReadnPixels<T1>(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, ref T1 data)
        where T1 : unmanaged
    {
        fixed (void* data_ptr = &data)
        {
            ReadnPixels(x, y, width, height, format, type, bufSize, data_ptr);
        }
    }
    /// <inheritdoc cref="ReadPixels(int, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, IntPtr pixels)
    {
        void* pixels_vptr = (void*)pixels;
        ReadPixels(x, y, width, height, format, type, pixels_vptr);
    }
    /// <inheritdoc cref="ReadPixels(int, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void ReadPixels<T1>(int x, int y, int width, int height, PixelFormat format, PixelType type, Span<T1> pixels)
        where T1 : unmanaged
    {
        fixed (void* pixels_ptr = pixels)
        {
            ReadPixels(x, y, width, height, format, type, pixels_ptr);
        }
    }
    /// <inheritdoc cref="ReadPixels(int, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void ReadPixels<T1>(int x, int y, int width, int height, PixelFormat format, PixelType type, T1[] pixels)
        where T1 : unmanaged
    {
        fixed (void* pixels_ptr = pixels)
        {
            ReadPixels(x, y, width, height, format, type, pixels_ptr);
        }
    }
    /// <inheritdoc cref="ReadPixels(int, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void ReadPixels<T1>(int x, int y, int width, int height, PixelFormat format, PixelType type, ref T1 pixels)
        where T1 : unmanaged
    {
        fixed (void* pixels_ptr = &pixels)
        {
            ReadPixels(x, y, width, height, format, type, pixels_ptr);
        }
    }
    /// <inheritdoc cref="SamplerParameterfv(int, SamplerParameterF, float*)"/>
    public static unsafe void SamplerParameterf(int sampler, SamplerParameterF pname, ReadOnlySpan<float> param)
    {
        fixed (float* param_ptr = param)
        {
            SamplerParameterfv(sampler, pname, param_ptr);
        }
    }
    /// <inheritdoc cref="SamplerParameterfv(int, SamplerParameterF, float*)"/>
    public static unsafe void SamplerParameterf(int sampler, SamplerParameterF pname, float[] param)
    {
        fixed (float* param_ptr = param)
        {
            SamplerParameterfv(sampler, pname, param_ptr);
        }
    }
    /// <inheritdoc cref="SamplerParameterfv(int, SamplerParameterF, float*)"/>
    public static unsafe void SamplerParameterf(int sampler, SamplerParameterF pname, ref readonly float param)
    {
        fixed (float* param_ptr = &param)
        {
            SamplerParameterfv(sampler, pname, param_ptr);
        }
    }
    /// <inheritdoc cref="SamplerParameterIiv(int, SamplerParameterI, int*)"/>
    public static unsafe void SamplerParameterIi(int sampler, SamplerParameterI pname, ReadOnlySpan<int> param)
    {
        fixed (int* param_ptr = param)
        {
            SamplerParameterIiv(sampler, pname, param_ptr);
        }
    }
    /// <inheritdoc cref="SamplerParameterIiv(int, SamplerParameterI, int*)"/>
    public static unsafe void SamplerParameterIi(int sampler, SamplerParameterI pname, int[] param)
    {
        fixed (int* param_ptr = param)
        {
            SamplerParameterIiv(sampler, pname, param_ptr);
        }
    }
    /// <inheritdoc cref="SamplerParameterIiv(int, SamplerParameterI, int*)"/>
    public static unsafe void SamplerParameterIi(int sampler, SamplerParameterI pname, ref readonly int param)
    {
        fixed (int* param_ptr = &param)
        {
            SamplerParameterIiv(sampler, pname, param_ptr);
        }
    }
    /// <inheritdoc cref="SamplerParameterIuiv(int, SamplerParameterI, uint*)"/>
    public static unsafe void SamplerParameterIui(int sampler, SamplerParameterI pname, ReadOnlySpan<uint> param)
    {
        fixed (uint* param_ptr = param)
        {
            SamplerParameterIuiv(sampler, pname, param_ptr);
        }
    }
    /// <inheritdoc cref="SamplerParameterIuiv(int, SamplerParameterI, uint*)"/>
    public static unsafe void SamplerParameterIui(int sampler, SamplerParameterI pname, uint[] param)
    {
        fixed (uint* param_ptr = param)
        {
            SamplerParameterIuiv(sampler, pname, param_ptr);
        }
    }
    /// <inheritdoc cref="SamplerParameterIuiv(int, SamplerParameterI, uint*)"/>
    public static unsafe void SamplerParameterIui(int sampler, SamplerParameterI pname, ref readonly uint param)
    {
        fixed (uint* param_ptr = &param)
        {
            SamplerParameterIuiv(sampler, pname, param_ptr);
        }
    }
    /// <inheritdoc cref="SamplerParameteriv(int, SamplerParameterI, int*)"/>
    public static unsafe void SamplerParameteri(int sampler, SamplerParameterI pname, ReadOnlySpan<int> param)
    {
        fixed (int* param_ptr = param)
        {
            SamplerParameteriv(sampler, pname, param_ptr);
        }
    }
    /// <inheritdoc cref="SamplerParameteriv(int, SamplerParameterI, int*)"/>
    public static unsafe void SamplerParameteri(int sampler, SamplerParameterI pname, int[] param)
    {
        fixed (int* param_ptr = param)
        {
            SamplerParameteriv(sampler, pname, param_ptr);
        }
    }
    /// <inheritdoc cref="SamplerParameteriv(int, SamplerParameterI, int*)"/>
    public static unsafe void SamplerParameteri(int sampler, SamplerParameterI pname, ref readonly int param)
    {
        fixed (int* param_ptr = &param)
        {
            SamplerParameteriv(sampler, pname, param_ptr);
        }
    }
    /// <inheritdoc cref="ShaderBinary(int, int*, ShaderBinaryFormat, void*, int)"/>
    public static unsafe void ShaderBinary(int count, ReadOnlySpan<int> shaders, ShaderBinaryFormat binaryFormat, IntPtr binary, int length)
    {
        fixed (int* shaders_ptr = shaders)
        {
            void* binary_vptr = (void*)binary;
            ShaderBinary(count, shaders_ptr, binaryFormat, binary_vptr, length);
        }
    }
    /// <inheritdoc cref="ShaderBinary(int, int*, ShaderBinaryFormat, void*, int)"/>
    public static unsafe void ShaderBinary(int count, int[] shaders, ShaderBinaryFormat binaryFormat, IntPtr binary, int length)
    {
        fixed (int* shaders_ptr = shaders)
        {
            void* binary_vptr = (void*)binary;
            ShaderBinary(count, shaders_ptr, binaryFormat, binary_vptr, length);
        }
    }
    /// <inheritdoc cref="ShaderBinary(int, int*, ShaderBinaryFormat, void*, int)"/>
    public static unsafe void ShaderBinary(int count, ref readonly int shaders, ShaderBinaryFormat binaryFormat, IntPtr binary, int length)
    {
        fixed (int* shaders_ptr = &shaders)
        {
            void* binary_vptr = (void*)binary;
            ShaderBinary(count, shaders_ptr, binaryFormat, binary_vptr, length);
        }
    }
    /// <inheritdoc cref="ShaderBinary(int, int*, ShaderBinaryFormat, void*, int)"/>
    public static unsafe void ShaderBinary<T1>(int count, ReadOnlySpan<int> shaders, ShaderBinaryFormat binaryFormat, ReadOnlySpan<T1> binary, int length)
        where T1 : unmanaged
    {
        fixed (void* binary_ptr = binary)
        {
            fixed (int* shaders_ptr = shaders)
            {
                ShaderBinary(count, shaders_ptr, binaryFormat, binary_ptr, length);
            }
        }
    }
    /// <inheritdoc cref="ShaderBinary(int, int*, ShaderBinaryFormat, void*, int)"/>
    public static unsafe void ShaderBinary<T1>(int count, int[] shaders, ShaderBinaryFormat binaryFormat, T1[] binary, int length)
        where T1 : unmanaged
    {
        fixed (void* binary_ptr = binary)
        {
            fixed (int* shaders_ptr = shaders)
            {
                ShaderBinary(count, shaders_ptr, binaryFormat, binary_ptr, length);
            }
        }
    }
    /// <inheritdoc cref="ShaderBinary(int, int*, ShaderBinaryFormat, void*, int)"/>
    public static unsafe void ShaderBinary<T1>(int count, ref readonly int shaders, ShaderBinaryFormat binaryFormat, ref readonly T1 binary, int length)
        where T1 : unmanaged
    {
        fixed (int* shaders_ptr = &shaders)
        fixed (void* binary_ptr = &binary)
        {
            ShaderBinary(count, shaders_ptr, binaryFormat, binary_ptr, length);
        }
    }
    /// <inheritdoc cref="ShaderSource(int, int, byte**, int*)"/>
    public static unsafe void ShaderSource(int shader, int count, string[] str, ReadOnlySpan<int> length)
    {
        fixed (int* length_ptr = length)
        {
            byte** str_ptr = (byte**)MarshalTk.StringArrayToCoTaskMemUTF8(str);
            ShaderSource(shader, count, str_ptr, length_ptr);
            MarshalTk.FreeStringArrayCoTaskMem((IntPtr)str_ptr, str.Length);
        }
    }
    /// <inheritdoc cref="ShaderSource(int, int, byte**, int*)"/>
    public static unsafe void ShaderSource(int shader, int count, string[] str, int[] length)
    {
        fixed (int* length_ptr = length)
        {
            byte** str_ptr = (byte**)MarshalTk.StringArrayToCoTaskMemUTF8(str);
            ShaderSource(shader, count, str_ptr, length_ptr);
            MarshalTk.FreeStringArrayCoTaskMem((IntPtr)str_ptr, str.Length);
        }
    }
    /// <inheritdoc cref="ShaderSource(int, int, byte**, int*)"/>
    public static unsafe void ShaderSource(int shader, int count, string[] str, ref readonly int length)
    {
        fixed (int* length_ptr = &length)
        {
            byte** str_ptr = (byte**)MarshalTk.StringArrayToCoTaskMemUTF8(str);
            ShaderSource(shader, count, str_ptr, length_ptr);
            MarshalTk.FreeStringArrayCoTaskMem((IntPtr)str_ptr, str.Length);
        }
    }
    /// <inheritdoc cref="TexImage2D(TextureTarget, int, InternalFormat, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void TexImage2D(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, IntPtr pixels)
    {
        void* pixels_vptr = (void*)pixels;
        TexImage2D(target, level, internalformat, width, height, border, format, type, pixels_vptr);
    }
    /// <inheritdoc cref="TexImage2D(TextureTarget, int, InternalFormat, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void TexImage2D<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, ReadOnlySpan<T1> pixels)
        where T1 : unmanaged
    {
        fixed (void* pixels_ptr = pixels)
        {
            TexImage2D(target, level, internalformat, width, height, border, format, type, pixels_ptr);
        }
    }
    /// <inheritdoc cref="TexImage2D(TextureTarget, int, InternalFormat, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void TexImage2D<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, T1[] pixels)
        where T1 : unmanaged
    {
        fixed (void* pixels_ptr = pixels)
        {
            TexImage2D(target, level, internalformat, width, height, border, format, type, pixels_ptr);
        }
    }
    /// <inheritdoc cref="TexImage2D(TextureTarget, int, InternalFormat, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void TexImage2D<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, ref readonly T1 pixels)
        where T1 : unmanaged
    {
        fixed (void* pixels_ptr = &pixels)
        {
            TexImage2D(target, level, internalformat, width, height, border, format, type, pixels_ptr);
        }
    }
    /// <inheritdoc cref="TexImage3D(TextureTarget, int, InternalFormat, int, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void TexImage3D(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, IntPtr pixels)
    {
        void* pixels_vptr = (void*)pixels;
        TexImage3D(target, level, internalformat, width, height, depth, border, format, type, pixels_vptr);
    }
    /// <inheritdoc cref="TexImage3D(TextureTarget, int, InternalFormat, int, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void TexImage3D<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, ReadOnlySpan<T1> pixels)
        where T1 : unmanaged
    {
        fixed (void* pixels_ptr = pixels)
        {
            TexImage3D(target, level, internalformat, width, height, depth, border, format, type, pixels_ptr);
        }
    }
    /// <inheritdoc cref="TexImage3D(TextureTarget, int, InternalFormat, int, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void TexImage3D<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, T1[] pixels)
        where T1 : unmanaged
    {
        fixed (void* pixels_ptr = pixels)
        {
            TexImage3D(target, level, internalformat, width, height, depth, border, format, type, pixels_ptr);
        }
    }
    /// <inheritdoc cref="TexImage3D(TextureTarget, int, InternalFormat, int, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void TexImage3D<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, ref readonly T1 pixels)
        where T1 : unmanaged
    {
        fixed (void* pixels_ptr = &pixels)
        {
            TexImage3D(target, level, internalformat, width, height, depth, border, format, type, pixels_ptr);
        }
    }
    /// <inheritdoc cref="TexParameterfv(TextureTarget, TextureParameterName, float*)"/>
    public static unsafe void TexParameterf(TextureTarget target, TextureParameterName pname, ReadOnlySpan<float> parameters)
    {
        fixed (float* parameters_ptr = parameters)
        {
            TexParameterfv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="TexParameterfv(TextureTarget, TextureParameterName, float*)"/>
    public static unsafe void TexParameterf(TextureTarget target, TextureParameterName pname, float[] parameters)
    {
        fixed (float* parameters_ptr = parameters)
        {
            TexParameterfv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="TexParameterfv(TextureTarget, TextureParameterName, float*)"/>
    public static unsafe void TexParameterf(TextureTarget target, TextureParameterName pname, ref readonly float parameters)
    {
        fixed (float* parameters_ptr = &parameters)
        {
            TexParameterfv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="TexParameterIiv(TextureTarget, TextureParameterName, int*)"/>
    public static unsafe void TexParameterIi(TextureTarget target, TextureParameterName pname, ReadOnlySpan<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            TexParameterIiv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="TexParameterIiv(TextureTarget, TextureParameterName, int*)"/>
    public static unsafe void TexParameterIi(TextureTarget target, TextureParameterName pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            TexParameterIiv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="TexParameterIiv(TextureTarget, TextureParameterName, int*)"/>
    public static unsafe void TexParameterIi(TextureTarget target, TextureParameterName pname, ref readonly int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            TexParameterIiv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="TexParameterIuiv(TextureTarget, TextureParameterName, uint*)"/>
    public static unsafe void TexParameterIui(TextureTarget target, TextureParameterName pname, ReadOnlySpan<uint> parameters)
    {
        fixed (uint* parameters_ptr = parameters)
        {
            TexParameterIuiv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="TexParameterIuiv(TextureTarget, TextureParameterName, uint*)"/>
    public static unsafe void TexParameterIui(TextureTarget target, TextureParameterName pname, uint[] parameters)
    {
        fixed (uint* parameters_ptr = parameters)
        {
            TexParameterIuiv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="TexParameterIuiv(TextureTarget, TextureParameterName, uint*)"/>
    public static unsafe void TexParameterIui(TextureTarget target, TextureParameterName pname, ref readonly uint parameters)
    {
        fixed (uint* parameters_ptr = &parameters)
        {
            TexParameterIuiv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="TexParameteriv(TextureTarget, TextureParameterName, int*)"/>
    public static unsafe void TexParameteri(TextureTarget target, TextureParameterName pname, ReadOnlySpan<int> parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            TexParameteriv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="TexParameteriv(TextureTarget, TextureParameterName, int*)"/>
    public static unsafe void TexParameteri(TextureTarget target, TextureParameterName pname, int[] parameters)
    {
        fixed (int* parameters_ptr = parameters)
        {
            TexParameteriv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="TexParameteriv(TextureTarget, TextureParameterName, int*)"/>
    public static unsafe void TexParameteri(TextureTarget target, TextureParameterName pname, ref readonly int parameters)
    {
        fixed (int* parameters_ptr = &parameters)
        {
            TexParameteriv(target, pname, parameters_ptr);
        }
    }
    /// <inheritdoc cref="TexSubImage2D(TextureTarget, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void TexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, IntPtr pixels)
    {
        void* pixels_vptr = (void*)pixels;
        TexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels_vptr);
    }
    /// <inheritdoc cref="TexSubImage2D(TextureTarget, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void TexSubImage2D<T1>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, ReadOnlySpan<T1> pixels)
        where T1 : unmanaged
    {
        fixed (void* pixels_ptr = pixels)
        {
            TexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels_ptr);
        }
    }
    /// <inheritdoc cref="TexSubImage2D(TextureTarget, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void TexSubImage2D<T1>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, T1[] pixels)
        where T1 : unmanaged
    {
        fixed (void* pixels_ptr = pixels)
        {
            TexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels_ptr);
        }
    }
    /// <inheritdoc cref="TexSubImage2D(TextureTarget, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void TexSubImage2D<T1>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, ref readonly T1 pixels)
        where T1 : unmanaged
    {
        fixed (void* pixels_ptr = &pixels)
        {
            TexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels_ptr);
        }
    }
    /// <inheritdoc cref="TexSubImage3D(TextureTarget, int, int, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void TexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, IntPtr pixels)
    {
        void* pixels_vptr = (void*)pixels;
        TexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels_vptr);
    }
    /// <inheritdoc cref="TexSubImage3D(TextureTarget, int, int, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void TexSubImage3D<T1>(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, ReadOnlySpan<T1> pixels)
        where T1 : unmanaged
    {
        fixed (void* pixels_ptr = pixels)
        {
            TexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels_ptr);
        }
    }
    /// <inheritdoc cref="TexSubImage3D(TextureTarget, int, int, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void TexSubImage3D<T1>(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, T1[] pixels)
        where T1 : unmanaged
    {
        fixed (void* pixels_ptr = pixels)
        {
            TexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels_ptr);
        }
    }
    /// <inheritdoc cref="TexSubImage3D(TextureTarget, int, int, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
    public static unsafe void TexSubImage3D<T1>(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, ref readonly T1 pixels)
        where T1 : unmanaged
    {
        fixed (void* pixels_ptr = &pixels)
        {
            TexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels_ptr);
        }
    }
    /// <inheritdoc cref="TransformFeedbackVaryings(int, int, byte**, TransformFeedbackBufferMode)"/>
    public static unsafe void TransformFeedbackVaryings(int program, int count, string[] varyings, TransformFeedbackBufferMode bufferMode)
    {
        byte** varyings_ptr = (byte**)MarshalTk.StringArrayToCoTaskMemUTF8(varyings);
        TransformFeedbackVaryings(program, count, varyings_ptr, bufferMode);
        MarshalTk.FreeStringArrayCoTaskMem((IntPtr)varyings_ptr, varyings.Length);
    }
    /// <inheritdoc cref="Uniform1fv(int, int, float*)"/>
    public static unsafe void Uniform1f(int location, int count, ref readonly float value)
    {
        fixed (float* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform1fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform1fv(int, int, float*)"/>
    public static unsafe void Uniform1f(int location, int count, ReadOnlySpan<float> value)
    {
        fixed (float* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform1fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform1fv(int, int, float*)"/>
    public static unsafe void Uniform1f(int location, int count, float[] value)
    {
        fixed (float* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform1fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform1iv(int, int, int*)"/>
    public static unsafe void Uniform1i(int location, int count, ref readonly int value)
    {
        fixed (int* tmp_value = &value)
        {
            int* value_ptr = (int*)tmp_value;
            Uniform1iv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform1iv(int, int, int*)"/>
    public static unsafe void Uniform1i(int location, int count, ReadOnlySpan<int> value)
    {
        fixed (int* tmp_value = value)
        {
            int* value_ptr = (int*)tmp_value;
            Uniform1iv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform1iv(int, int, int*)"/>
    public static unsafe void Uniform1i(int location, int count, int[] value)
    {
        fixed (int* tmp_value = value)
        {
            int* value_ptr = (int*)tmp_value;
            Uniform1iv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform1uiv(int, int, uint*)"/>
    public static unsafe void Uniform1ui(int location, int count, ref readonly uint value)
    {
        fixed (uint* tmp_value = &value)
        {
            uint* value_ptr = (uint*)tmp_value;
            Uniform1uiv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform1uiv(int, int, uint*)"/>
    public static unsafe void Uniform1ui(int location, int count, ReadOnlySpan<uint> value)
    {
        fixed (uint* tmp_value = value)
        {
            uint* value_ptr = (uint*)tmp_value;
            Uniform1uiv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform1uiv(int, int, uint*)"/>
    public static unsafe void Uniform1ui(int location, int count, uint[] value)
    {
        fixed (uint* tmp_value = value)
        {
            uint* value_ptr = (uint*)tmp_value;
            Uniform1uiv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform2fv(int, int, float*)"/>
    public static unsafe void Uniform2f(int location, int count, ref readonly Vector2 value)
    {
        fixed (Vector2* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform2fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform2fv(int, int, float*)"/>
    public static unsafe void Uniform2f(int location, int count, ReadOnlySpan<Vector2> value)
    {
        fixed (Vector2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform2fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform2fv(int, int, float*)"/>
    public static unsafe void Uniform2f(int location, int count, Vector2[] value)
    {
        fixed (Vector2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform2fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform2fv(int, int, float*)"/>
    public static unsafe void Uniform2f(int location, int count, ref readonly System.Numerics.Vector2 value)
    {
        fixed (System.Numerics.Vector2* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform2fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform2fv(int, int, float*)"/>
    public static unsafe void Uniform2f(int location, int count, ReadOnlySpan<System.Numerics.Vector2> value)
    {
        fixed (System.Numerics.Vector2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform2fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform2fv(int, int, float*)"/>
    public static unsafe void Uniform2f(int location, int count, System.Numerics.Vector2[] value)
    {
        fixed (System.Numerics.Vector2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform2fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform2iv(int, int, int*)"/>
    public static unsafe void Uniform2i(int location, int count, ref readonly Vector2i value)
    {
        fixed (Vector2i* tmp_value = &value)
        {
            int* value_ptr = (int*)tmp_value;
            Uniform2iv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform2iv(int, int, int*)"/>
    public static unsafe void Uniform2i(int location, int count, ReadOnlySpan<Vector2i> value)
    {
        fixed (Vector2i* tmp_value = value)
        {
            int* value_ptr = (int*)tmp_value;
            Uniform2iv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform2iv(int, int, int*)"/>
    public static unsafe void Uniform2i(int location, int count, Vector2i[] value)
    {
        fixed (Vector2i* tmp_value = value)
        {
            int* value_ptr = (int*)tmp_value;
            Uniform2iv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform2uiv(int, int, uint*)"/>
    public static unsafe void Uniform2ui(int location, int count, ref readonly Vector2i value)
    {
        fixed (Vector2i* tmp_value = &value)
        {
            uint* value_ptr = (uint*)tmp_value;
            Uniform2uiv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform2uiv(int, int, uint*)"/>
    public static unsafe void Uniform2ui(int location, int count, ReadOnlySpan<Vector2i> value)
    {
        fixed (Vector2i* tmp_value = value)
        {
            uint* value_ptr = (uint*)tmp_value;
            Uniform2uiv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform2uiv(int, int, uint*)"/>
    public static unsafe void Uniform2ui(int location, int count, Vector2i[] value)
    {
        fixed (Vector2i* tmp_value = value)
        {
            uint* value_ptr = (uint*)tmp_value;
            Uniform2uiv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform3fv(int, int, float*)"/>
    public static unsafe void Uniform3f(int location, int count, ref readonly Vector3 value)
    {
        fixed (Vector3* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform3fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform3fv(int, int, float*)"/>
    public static unsafe void Uniform3f(int location, int count, ReadOnlySpan<Vector3> value)
    {
        fixed (Vector3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform3fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform3fv(int, int, float*)"/>
    public static unsafe void Uniform3f(int location, int count, Vector3[] value)
    {
        fixed (Vector3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform3fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform3fv(int, int, float*)"/>
    public static unsafe void Uniform3f(int location, int count, ref readonly System.Numerics.Vector3 value)
    {
        fixed (System.Numerics.Vector3* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform3fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform3fv(int, int, float*)"/>
    public static unsafe void Uniform3f(int location, int count, ReadOnlySpan<System.Numerics.Vector3> value)
    {
        fixed (System.Numerics.Vector3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform3fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform3fv(int, int, float*)"/>
    public static unsafe void Uniform3f(int location, int count, System.Numerics.Vector3[] value)
    {
        fixed (System.Numerics.Vector3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform3fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform3iv(int, int, int*)"/>
    public static unsafe void Uniform3i(int location, int count, ref readonly Vector3i value)
    {
        fixed (Vector3i* tmp_value = &value)
        {
            int* value_ptr = (int*)tmp_value;
            Uniform3iv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform3iv(int, int, int*)"/>
    public static unsafe void Uniform3i(int location, int count, ReadOnlySpan<Vector3i> value)
    {
        fixed (Vector3i* tmp_value = value)
        {
            int* value_ptr = (int*)tmp_value;
            Uniform3iv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform3iv(int, int, int*)"/>
    public static unsafe void Uniform3i(int location, int count, Vector3i[] value)
    {
        fixed (Vector3i* tmp_value = value)
        {
            int* value_ptr = (int*)tmp_value;
            Uniform3iv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform3uiv(int, int, uint*)"/>
    public static unsafe void Uniform3ui(int location, int count, ref readonly Vector3i value)
    {
        fixed (Vector3i* tmp_value = &value)
        {
            uint* value_ptr = (uint*)tmp_value;
            Uniform3uiv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform3uiv(int, int, uint*)"/>
    public static unsafe void Uniform3ui(int location, int count, ReadOnlySpan<Vector3i> value)
    {
        fixed (Vector3i* tmp_value = value)
        {
            uint* value_ptr = (uint*)tmp_value;
            Uniform3uiv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform3uiv(int, int, uint*)"/>
    public static unsafe void Uniform3ui(int location, int count, Vector3i[] value)
    {
        fixed (Vector3i* tmp_value = value)
        {
            uint* value_ptr = (uint*)tmp_value;
            Uniform3uiv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform4fv(int, int, float*)"/>
    public static unsafe void Uniform4f(int location, int count, ref readonly Vector4 value)
    {
        fixed (Vector4* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform4fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform4fv(int, int, float*)"/>
    public static unsafe void Uniform4f(int location, int count, ReadOnlySpan<Vector4> value)
    {
        fixed (Vector4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform4fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform4fv(int, int, float*)"/>
    public static unsafe void Uniform4f(int location, int count, Vector4[] value)
    {
        fixed (Vector4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform4fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform4fv(int, int, float*)"/>
    public static unsafe void Uniform4f(int location, int count, ref readonly System.Numerics.Vector4 value)
    {
        fixed (System.Numerics.Vector4* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform4fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform4fv(int, int, float*)"/>
    public static unsafe void Uniform4f(int location, int count, ReadOnlySpan<System.Numerics.Vector4> value)
    {
        fixed (System.Numerics.Vector4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform4fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform4fv(int, int, float*)"/>
    public static unsafe void Uniform4f(int location, int count, System.Numerics.Vector4[] value)
    {
        fixed (System.Numerics.Vector4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            Uniform4fv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform4iv(int, int, int*)"/>
    public static unsafe void Uniform4i(int location, int count, ref readonly Vector4i value)
    {
        fixed (Vector4i* tmp_value = &value)
        {
            int* value_ptr = (int*)tmp_value;
            Uniform4iv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform4iv(int, int, int*)"/>
    public static unsafe void Uniform4i(int location, int count, ReadOnlySpan<Vector4i> value)
    {
        fixed (Vector4i* tmp_value = value)
        {
            int* value_ptr = (int*)tmp_value;
            Uniform4iv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform4iv(int, int, int*)"/>
    public static unsafe void Uniform4i(int location, int count, Vector4i[] value)
    {
        fixed (Vector4i* tmp_value = value)
        {
            int* value_ptr = (int*)tmp_value;
            Uniform4iv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform4uiv(int, int, uint*)"/>
    public static unsafe void Uniform4ui(int location, int count, ref readonly Vector4i value)
    {
        fixed (Vector4i* tmp_value = &value)
        {
            uint* value_ptr = (uint*)tmp_value;
            Uniform4uiv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform4uiv(int, int, uint*)"/>
    public static unsafe void Uniform4ui(int location, int count, ReadOnlySpan<Vector4i> value)
    {
        fixed (Vector4i* tmp_value = value)
        {
            uint* value_ptr = (uint*)tmp_value;
            Uniform4uiv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="Uniform4uiv(int, int, uint*)"/>
    public static unsafe void Uniform4ui(int location, int count, Vector4i[] value)
    {
        fixed (Vector4i* tmp_value = value)
        {
            uint* value_ptr = (uint*)tmp_value;
            Uniform4uiv(location, count, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix2fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix2f(int location, int count, bool transpose, ref readonly Matrix2 value)
    {
        fixed (Matrix2* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix2fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix2fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix2f(int location, int count, bool transpose, ReadOnlySpan<Matrix2> value)
    {
        fixed (Matrix2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix2fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix2fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix2f(int location, int count, bool transpose, Matrix2[] value)
    {
        fixed (Matrix2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix2fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix2x3fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix2x3f(int location, int count, bool transpose, ref readonly Matrix2x3 value)
    {
        fixed (Matrix2x3* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix2x3fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix2x3fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix2x3f(int location, int count, bool transpose, ReadOnlySpan<Matrix2x3> value)
    {
        fixed (Matrix2x3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix2x3fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix2x3fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix2x3f(int location, int count, bool transpose, Matrix2x3[] value)
    {
        fixed (Matrix2x3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix2x3fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix2x4fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix2x4f(int location, int count, bool transpose, ref readonly Matrix2x4 value)
    {
        fixed (Matrix2x4* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix2x4fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix2x4fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix2x4f(int location, int count, bool transpose, ReadOnlySpan<Matrix2x4> value)
    {
        fixed (Matrix2x4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix2x4fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix2x4fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix2x4f(int location, int count, bool transpose, Matrix2x4[] value)
    {
        fixed (Matrix2x4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix2x4fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix3fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix3f(int location, int count, bool transpose, ref readonly Matrix3 value)
    {
        fixed (Matrix3* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix3fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix3fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix3f(int location, int count, bool transpose, ReadOnlySpan<Matrix3> value)
    {
        fixed (Matrix3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix3fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix3fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix3f(int location, int count, bool transpose, Matrix3[] value)
    {
        fixed (Matrix3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix3fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix3x2fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix3x2f(int location, int count, bool transpose, ref readonly Matrix3x2 value)
    {
        fixed (Matrix3x2* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix3x2fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix3x2fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix3x2f(int location, int count, bool transpose, ReadOnlySpan<Matrix3x2> value)
    {
        fixed (Matrix3x2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix3x2fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix3x2fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix3x2f(int location, int count, bool transpose, Matrix3x2[] value)
    {
        fixed (Matrix3x2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix3x2fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix3x2fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix3x2f(int location, int count, bool transpose, ref readonly System.Numerics.Matrix3x2 value)
    {
        fixed (System.Numerics.Matrix3x2* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix3x2fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix3x2fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix3x2f(int location, int count, bool transpose, ReadOnlySpan<System.Numerics.Matrix3x2> value)
    {
        fixed (System.Numerics.Matrix3x2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix3x2fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix3x2fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix3x2f(int location, int count, bool transpose, System.Numerics.Matrix3x2[] value)
    {
        fixed (System.Numerics.Matrix3x2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix3x2fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix3x4fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix3x4f(int location, int count, bool transpose, ref readonly Matrix3x4 value)
    {
        fixed (Matrix3x4* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix3x4fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix3x4fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix3x4f(int location, int count, bool transpose, ReadOnlySpan<Matrix3x4> value)
    {
        fixed (Matrix3x4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix3x4fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix3x4fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix3x4f(int location, int count, bool transpose, Matrix3x4[] value)
    {
        fixed (Matrix3x4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix3x4fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix4fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix4f(int location, int count, bool transpose, ref readonly Matrix4 value)
    {
        fixed (Matrix4* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix4fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix4fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix4f(int location, int count, bool transpose, ReadOnlySpan<Matrix4> value)
    {
        fixed (Matrix4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix4fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix4fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix4f(int location, int count, bool transpose, Matrix4[] value)
    {
        fixed (Matrix4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix4fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix4fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix4f(int location, int count, bool transpose, ref readonly System.Numerics.Matrix4x4 value)
    {
        fixed (System.Numerics.Matrix4x4* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix4fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix4fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix4f(int location, int count, bool transpose, ReadOnlySpan<System.Numerics.Matrix4x4> value)
    {
        fixed (System.Numerics.Matrix4x4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix4fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix4fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix4f(int location, int count, bool transpose, System.Numerics.Matrix4x4[] value)
    {
        fixed (System.Numerics.Matrix4x4* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix4fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix4x2fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix4x2f(int location, int count, bool transpose, ref readonly Matrix4x2 value)
    {
        fixed (Matrix4x2* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix4x2fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix4x2fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix4x2f(int location, int count, bool transpose, ReadOnlySpan<Matrix4x2> value)
    {
        fixed (Matrix4x2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix4x2fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix4x2fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix4x2f(int location, int count, bool transpose, Matrix4x2[] value)
    {
        fixed (Matrix4x2* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix4x2fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix4x3fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix4x3f(int location, int count, bool transpose, ref readonly Matrix4x3 value)
    {
        fixed (Matrix4x3* tmp_value = &value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix4x3fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix4x3fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix4x3f(int location, int count, bool transpose, ReadOnlySpan<Matrix4x3> value)
    {
        fixed (Matrix4x3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix4x3fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="UniformMatrix4x3fv(int, int, bool, float*)"/>
    public static unsafe void UniformMatrix4x3f(int location, int count, bool transpose, Matrix4x3[] value)
    {
        fixed (Matrix4x3* tmp_value = value)
        {
            float* value_ptr = (float*)tmp_value;
            UniformMatrix4x3fv(location, count, transpose, value_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttrib1fv(uint, float*)"/>
    public static unsafe void VertexAttrib1f(uint index, ref readonly float v)
    {
        fixed (float* tmp_v = &v)
        {
            float* v_ptr = (float*)tmp_v;
            VertexAttrib1fv(index, v_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttrib2fv(uint, float*)"/>
    public static unsafe void VertexAttrib2f(uint index, ref readonly Vector2 v)
    {
        fixed (Vector2* tmp_v = &v)
        {
            float* v_ptr = (float*)tmp_v;
            VertexAttrib2fv(index, v_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttrib2fv(uint, float*)"/>
    public static unsafe void VertexAttrib2f(uint index, ref readonly System.Numerics.Vector2 v)
    {
        fixed (System.Numerics.Vector2* tmp_v = &v)
        {
            float* v_ptr = (float*)tmp_v;
            VertexAttrib2fv(index, v_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttrib2fv(uint, float*)"/>
    public static unsafe void VertexAttrib2f(uint index, ReadOnlySpan<System.Numerics.Vector2> v)
    {
        fixed (System.Numerics.Vector2* tmp_v = v)
        {
            float* v_ptr = (float*)tmp_v;
            VertexAttrib2fv(index, v_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttrib2fv(uint, float*)"/>
    public static unsafe void VertexAttrib2f(uint index, System.Numerics.Vector2[] v)
    {
        fixed (System.Numerics.Vector2* tmp_v = v)
        {
            float* v_ptr = (float*)tmp_v;
            VertexAttrib2fv(index, v_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttrib3fv(uint, float*)"/>
    public static unsafe void VertexAttrib3f(uint index, ref readonly Vector3 v)
    {
        fixed (Vector3* tmp_v = &v)
        {
            float* v_ptr = (float*)tmp_v;
            VertexAttrib3fv(index, v_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttrib3fv(uint, float*)"/>
    public static unsafe void VertexAttrib3f(uint index, ref readonly System.Numerics.Vector3 v)
    {
        fixed (System.Numerics.Vector3* tmp_v = &v)
        {
            float* v_ptr = (float*)tmp_v;
            VertexAttrib3fv(index, v_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttrib3fv(uint, float*)"/>
    public static unsafe void VertexAttrib3f(uint index, ReadOnlySpan<System.Numerics.Vector3> v)
    {
        fixed (System.Numerics.Vector3* tmp_v = v)
        {
            float* v_ptr = (float*)tmp_v;
            VertexAttrib3fv(index, v_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttrib3fv(uint, float*)"/>
    public static unsafe void VertexAttrib3f(uint index, System.Numerics.Vector3[] v)
    {
        fixed (System.Numerics.Vector3* tmp_v = v)
        {
            float* v_ptr = (float*)tmp_v;
            VertexAttrib3fv(index, v_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttrib4fv(uint, float*)"/>
    public static unsafe void VertexAttrib4f(uint index, ref readonly Vector4 v)
    {
        fixed (Vector4* tmp_v = &v)
        {
            float* v_ptr = (float*)tmp_v;
            VertexAttrib4fv(index, v_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttrib4fv(uint, float*)"/>
    public static unsafe void VertexAttrib4f(uint index, ref readonly System.Numerics.Vector4 v)
    {
        fixed (System.Numerics.Vector4* tmp_v = &v)
        {
            float* v_ptr = (float*)tmp_v;
            VertexAttrib4fv(index, v_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttrib4fv(uint, float*)"/>
    public static unsafe void VertexAttrib4f(uint index, ReadOnlySpan<System.Numerics.Vector4> v)
    {
        fixed (System.Numerics.Vector4* tmp_v = v)
        {
            float* v_ptr = (float*)tmp_v;
            VertexAttrib4fv(index, v_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttrib4fv(uint, float*)"/>
    public static unsafe void VertexAttrib4f(uint index, System.Numerics.Vector4[] v)
    {
        fixed (System.Numerics.Vector4* tmp_v = v)
        {
            float* v_ptr = (float*)tmp_v;
            VertexAttrib4fv(index, v_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttribI4iv(uint, int*)"/>
    public static unsafe void VertexAttribI4i(uint index, ref readonly Vector4i v)
    {
        fixed (Vector4i* tmp_v = &v)
        {
            int* v_ptr = (int*)tmp_v;
            VertexAttribI4iv(index, v_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttribI4uiv(uint, uint*)"/>
    public static unsafe void VertexAttribI4ui(uint index, ReadOnlySpan<uint> v)
    {
        fixed (uint* v_ptr = v)
        {
            VertexAttribI4uiv(index, v_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttribI4uiv(uint, uint*)"/>
    public static unsafe void VertexAttribI4ui(uint index, uint[] v)
    {
        fixed (uint* v_ptr = v)
        {
            VertexAttribI4uiv(index, v_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttribI4uiv(uint, uint*)"/>
    public static unsafe void VertexAttribI4ui(uint index, ref readonly uint v)
    {
        fixed (uint* v_ptr = &v)
        {
            VertexAttribI4uiv(index, v_ptr);
        }
    }
    /// <inheritdoc cref="VertexAttribIPointer(uint, int, VertexAttribIType, int, void*)"/>
    public static unsafe void VertexAttribIPointer(uint index, int size, VertexAttribIType type, int stride, nint offset)
    {
        void* pointer = (void*)offset;
        VertexAttribIPointer(index, size, type, stride, pointer);
    }
    /// <inheritdoc cref="VertexAttribPointer(uint, int, VertexAttribPointerType, bool, int, void*)"/>
    public static unsafe void VertexAttribPointer(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, nint offset)
    {
        void* pointer = (void*)offset;
        VertexAttribPointer(index, size, type, normalized, stride, pointer);
    }
    public static unsafe partial class AMD
    {
        /// <inheritdoc cref="DeletePerfMonitorsAMD(int, uint*)"/>
        public static unsafe void DeletePerfMonitorsAMD(int n, Span<uint> monitors)
        {
            fixed (uint* monitors_ptr = monitors)
            {
                DeletePerfMonitorsAMD(n, monitors_ptr);
            }
        }
        /// <inheritdoc cref="DeletePerfMonitorsAMD(int, uint*)"/>
        public static unsafe void DeletePerfMonitorsAMD(int n, uint[] monitors)
        {
            fixed (uint* monitors_ptr = monitors)
            {
                DeletePerfMonitorsAMD(n, monitors_ptr);
            }
        }
        /// <inheritdoc cref="DeletePerfMonitorsAMD(int, uint*)"/>
        public static unsafe void DeletePerfMonitorsAMD(int n, ref readonly uint monitors)
        {
            fixed (uint* monitors_ptr = &monitors)
            {
                DeletePerfMonitorsAMD(n, monitors_ptr);
            }
        }
        /// <inheritdoc cref="GenPerfMonitorsAMD(int, uint*)"/>
        public static unsafe void GenPerfMonitorsAMD(int n, Span<uint> monitors)
        {
            fixed (uint* monitors_ptr = monitors)
            {
                GenPerfMonitorsAMD(n, monitors_ptr);
            }
        }
        /// <inheritdoc cref="GenPerfMonitorsAMD(int, uint*)"/>
        public static unsafe void GenPerfMonitorsAMD(int n, uint[] monitors)
        {
            fixed (uint* monitors_ptr = monitors)
            {
                GenPerfMonitorsAMD(n, monitors_ptr);
            }
        }
        /// <inheritdoc cref="GenPerfMonitorsAMD(int, uint*)"/>
        public static unsafe void GenPerfMonitorsAMD(int n, ref uint monitors)
        {
            fixed (uint* monitors_ptr = &monitors)
            {
                GenPerfMonitorsAMD(n, monitors_ptr);
            }
        }
        /// <inheritdoc cref="GetPerfMonitorCounterDataAMD(uint, All, int, uint*, int*)"/>
        public static unsafe int GetPerfMonitorCounterDataAMD(uint monitor, All pname, int dataSize, Span<uint> data)
        {
            int bytesWritten;
            int* bytesWritten_ptr = &bytesWritten;
            {
                fixed (uint* data_ptr = data)
                {
                    GetPerfMonitorCounterDataAMD(monitor, pname, dataSize, data_ptr, bytesWritten_ptr);
                }
            }
            return bytesWritten;
        }
        /// <inheritdoc cref="GetPerfMonitorCounterDataAMD(uint, All, int, uint*, int*)"/>
        public static unsafe void GetPerfMonitorCounterDataAMD(uint monitor, All pname, int dataSize, Span<uint> data, out int bytesWritten)
        {
            fixed (int* bytesWritten_ptr = &bytesWritten)
            {
                fixed (uint* data_ptr = data)
                {
                    GetPerfMonitorCounterDataAMD(monitor, pname, dataSize, data_ptr, bytesWritten_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetPerfMonitorCounterDataAMD(uint, All, int, uint*, int*)"/>
        public static unsafe int GetPerfMonitorCounterDataAMD(uint monitor, All pname, int dataSize, uint[] data)
        {
            int bytesWritten;
            int* bytesWritten_ptr = &bytesWritten;
            {
                fixed (uint* data_ptr = data)
                {
                    GetPerfMonitorCounterDataAMD(monitor, pname, dataSize, data_ptr, bytesWritten_ptr);
                }
            }
            return bytesWritten;
        }
        /// <inheritdoc cref="GetPerfMonitorCounterDataAMD(uint, All, int, uint*, int*)"/>
        public static unsafe void GetPerfMonitorCounterDataAMD(uint monitor, All pname, int dataSize, uint[] data, out int bytesWritten)
        {
            fixed (int* bytesWritten_ptr = &bytesWritten)
            {
                fixed (uint* data_ptr = data)
                {
                    GetPerfMonitorCounterDataAMD(monitor, pname, dataSize, data_ptr, bytesWritten_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetPerfMonitorCounterDataAMD(uint, All, int, uint*, int*)"/>
        public static unsafe int GetPerfMonitorCounterDataAMD(uint monitor, All pname, int dataSize, ref uint data)
        {
            int bytesWritten;
            int* bytesWritten_ptr = &bytesWritten;
            fixed (uint* data_ptr = &data)
            {
                GetPerfMonitorCounterDataAMD(monitor, pname, dataSize, data_ptr, bytesWritten_ptr);
            }
            return bytesWritten;
        }
        /// <inheritdoc cref="GetPerfMonitorCounterDataAMD(uint, All, int, uint*, int*)"/>
        public static unsafe void GetPerfMonitorCounterDataAMD(uint monitor, All pname, int dataSize, ref uint data, out int bytesWritten)
        {
            fixed (uint* data_ptr = &data)
            fixed (int* bytesWritten_ptr = &bytesWritten)
            {
                GetPerfMonitorCounterDataAMD(monitor, pname, dataSize, data_ptr, bytesWritten_ptr);
            }
        }
        /// <inheritdoc cref="GetPerfMonitorCounterInfoAMD(uint, uint, All, void*)"/>
        public static unsafe void GetPerfMonitorCounterInfoAMD(uint group, uint counter, All pname, IntPtr data)
        {
            void* data_vptr = (void*)data;
            GetPerfMonitorCounterInfoAMD(group, counter, pname, data_vptr);
        }
        /// <inheritdoc cref="GetPerfMonitorCounterInfoAMD(uint, uint, All, void*)"/>
        public static unsafe void GetPerfMonitorCounterInfoAMD<T1>(uint group, uint counter, All pname, Span<T1> data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                GetPerfMonitorCounterInfoAMD(group, counter, pname, data_ptr);
            }
        }
        /// <inheritdoc cref="GetPerfMonitorCounterInfoAMD(uint, uint, All, void*)"/>
        public static unsafe void GetPerfMonitorCounterInfoAMD<T1>(uint group, uint counter, All pname, T1[] data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                GetPerfMonitorCounterInfoAMD(group, counter, pname, data_ptr);
            }
        }
        /// <inheritdoc cref="GetPerfMonitorCounterInfoAMD(uint, uint, All, void*)"/>
        public static unsafe T1 GetPerfMonitorCounterInfoAMD<T1>(uint group, uint counter, All pname)
            where T1 : unmanaged
        {
            T1 data;
            void* data_ptr = &data;
            {
                GetPerfMonitorCounterInfoAMD(group, counter, pname, data_ptr);
            }
            return data;
        }
        /// <inheritdoc cref="GetPerfMonitorCounterInfoAMD(uint, uint, All, void*)"/>
        public static unsafe void GetPerfMonitorCounterInfoAMD<T1>(uint group, uint counter, All pname, out T1 data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = &data)
            {
                GetPerfMonitorCounterInfoAMD(group, counter, pname, data_ptr);
            }
        }
        /// <inheritdoc cref="GetPerfMonitorCountersAMD(uint, int*, int*, int, uint*)"/>
        public static unsafe void GetPerfMonitorCountersAMD(uint group, out int numCounters, out int maxActiveCounters, int counterSize, Span<uint> counters)
        {
            fixed (int* numCounters_ptr = &numCounters)
            fixed (int* maxActiveCounters_ptr = &maxActiveCounters)
            {
                fixed (uint* counters_ptr = counters)
                {
                    GetPerfMonitorCountersAMD(group, numCounters_ptr, maxActiveCounters_ptr, counterSize, counters_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetPerfMonitorCountersAMD(uint, int*, int*, int, uint*)"/>
        public static unsafe void GetPerfMonitorCountersAMD(uint group, out int numCounters, out int maxActiveCounters, int counterSize, uint[] counters)
        {
            fixed (int* numCounters_ptr = &numCounters)
            fixed (int* maxActiveCounters_ptr = &maxActiveCounters)
            {
                fixed (uint* counters_ptr = counters)
                {
                    GetPerfMonitorCountersAMD(group, numCounters_ptr, maxActiveCounters_ptr, counterSize, counters_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetPerfMonitorCountersAMD(uint, int*, int*, int, uint*)"/>
        public static unsafe void GetPerfMonitorCountersAMD(uint group, out int numCounters, out int maxActiveCounters, int counterSize, ref uint counters)
        {
            fixed (int* numCounters_ptr = &numCounters)
            fixed (int* maxActiveCounters_ptr = &maxActiveCounters)
            fixed (uint* counters_ptr = &counters)
            {
                GetPerfMonitorCountersAMD(group, numCounters_ptr, maxActiveCounters_ptr, counterSize, counters_ptr);
            }
        }
        /// <inheritdoc cref="GetPerfMonitorCounterStringAMD(uint, uint, int, int*, byte*)"/>
        public static unsafe string GetPerfMonitorCounterStringAMD(uint group, uint counter, int bufSize, out int length)
        {
            string counterString;
            fixed (int* length_ptr = &length)
            {
                var counterString_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetPerfMonitorCounterStringAMD(group, counter, bufSize, length_ptr, counterString_ptr);
                counterString = Marshal.PtrToStringUTF8((IntPtr)counterString_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)counterString_ptr);
            }
            return counterString;
        }
        /// <inheritdoc cref="GetPerfMonitorCounterStringAMD(uint, uint, int, int*, byte*)"/>
        public static unsafe void GetPerfMonitorCounterStringAMD(uint group, uint counter, int bufSize, out int length, out string counterString)
        {
            fixed (int* length_ptr = &length)
            {
                var counterString_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetPerfMonitorCounterStringAMD(group, counter, bufSize, length_ptr, counterString_ptr);
                counterString = Marshal.PtrToStringUTF8((IntPtr)counterString_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)counterString_ptr);
            }
        }
        /// <inheritdoc cref="GetPerfMonitorGroupsAMD(int*, int, uint*)"/>
        public static unsafe void GetPerfMonitorGroupsAMD(out int numGroups, int groupsSize, Span<uint> groups)
        {
            fixed (int* numGroups_ptr = &numGroups)
            {
                fixed (uint* groups_ptr = groups)
                {
                    GetPerfMonitorGroupsAMD(numGroups_ptr, groupsSize, groups_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetPerfMonitorGroupsAMD(int*, int, uint*)"/>
        public static unsafe void GetPerfMonitorGroupsAMD(out int numGroups, int groupsSize, uint[] groups)
        {
            fixed (int* numGroups_ptr = &numGroups)
            {
                fixed (uint* groups_ptr = groups)
                {
                    GetPerfMonitorGroupsAMD(numGroups_ptr, groupsSize, groups_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetPerfMonitorGroupsAMD(int*, int, uint*)"/>
        public static unsafe void GetPerfMonitorGroupsAMD(out int numGroups, int groupsSize, ref uint groups)
        {
            fixed (int* numGroups_ptr = &numGroups)
            fixed (uint* groups_ptr = &groups)
            {
                GetPerfMonitorGroupsAMD(numGroups_ptr, groupsSize, groups_ptr);
            }
        }
        /// <inheritdoc cref="GetPerfMonitorGroupStringAMD(uint, int, int*, byte*)"/>
        public static unsafe string GetPerfMonitorGroupStringAMD(uint group, int bufSize, out int length)
        {
            string groupString;
            fixed (int* length_ptr = &length)
            {
                var groupString_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetPerfMonitorGroupStringAMD(group, bufSize, length_ptr, groupString_ptr);
                groupString = Marshal.PtrToStringUTF8((IntPtr)groupString_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)groupString_ptr);
            }
            return groupString;
        }
        /// <inheritdoc cref="GetPerfMonitorGroupStringAMD(uint, int, int*, byte*)"/>
        public static unsafe void GetPerfMonitorGroupStringAMD(uint group, int bufSize, out int length, out string groupString)
        {
            fixed (int* length_ptr = &length)
            {
                var groupString_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetPerfMonitorGroupStringAMD(group, bufSize, length_ptr, groupString_ptr);
                groupString = Marshal.PtrToStringUTF8((IntPtr)groupString_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)groupString_ptr);
            }
        }
        /// <inheritdoc cref="SelectPerfMonitorCountersAMD(uint, bool, uint, int, uint*)"/>
        public static unsafe void SelectPerfMonitorCountersAMD(uint monitor, bool enable, uint group, int numCounters, Span<uint> counterList)
        {
            fixed (uint* counterList_ptr = counterList)
            {
                SelectPerfMonitorCountersAMD(monitor, enable, group, numCounters, counterList_ptr);
            }
        }
        /// <inheritdoc cref="SelectPerfMonitorCountersAMD(uint, bool, uint, int, uint*)"/>
        public static unsafe void SelectPerfMonitorCountersAMD(uint monitor, bool enable, uint group, int numCounters, uint[] counterList)
        {
            fixed (uint* counterList_ptr = counterList)
            {
                SelectPerfMonitorCountersAMD(monitor, enable, group, numCounters, counterList_ptr);
            }
        }
        /// <inheritdoc cref="SelectPerfMonitorCountersAMD(uint, bool, uint, int, uint*)"/>
        public static unsafe void SelectPerfMonitorCountersAMD(uint monitor, bool enable, uint group, int numCounters, ref readonly uint counterList)
        {
            fixed (uint* counterList_ptr = &counterList)
            {
                SelectPerfMonitorCountersAMD(monitor, enable, group, numCounters, counterList_ptr);
            }
        }
    }
    public static unsafe partial class ANGLE
    {
        /// <inheritdoc cref="DrawElementsInstancedANGLE(PrimitiveType, int, DrawElementsType, void*, int)"/>
        public static unsafe void DrawElementsInstancedANGLE(PrimitiveType mode, int count, DrawElementsType type, nint offset, int primcount)
        {
            void* indices = (void*)offset;
            DrawElementsInstancedANGLE(mode, count, type, indices, primcount);
        }
        /// <inheritdoc cref="GetTranslatedShaderSourceANGLE(int, int, int*, byte*)"/>
        public static unsafe string GetTranslatedShaderSourceANGLE(int shader, int bufSize, out int length)
        {
            string source;
            fixed (int* length_ptr = &length)
            {
                var source_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetTranslatedShaderSourceANGLE(shader, bufSize, length_ptr, source_ptr);
                source = Marshal.PtrToStringUTF8((IntPtr)source_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)source_ptr);
            }
            return source;
        }
        /// <inheritdoc cref="GetTranslatedShaderSourceANGLE(int, int, int*, byte*)"/>
        public static unsafe void GetTranslatedShaderSourceANGLE(int shader, int bufSize, out int length, out string source)
        {
            fixed (int* length_ptr = &length)
            {
                var source_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetTranslatedShaderSourceANGLE(shader, bufSize, length_ptr, source_ptr);
                source = Marshal.PtrToStringUTF8((IntPtr)source_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)source_ptr);
            }
        }
    }
    public static unsafe partial class APPLE
    {
        /// <inheritdoc cref="GetInteger64vAPPLE(GetPName, long*)"/>
        public static unsafe void GetInteger64vAPPLE(GetPName pname, Span<long> parameters)
        {
            fixed (long* parameters_ptr = parameters)
            {
                GetInteger64vAPPLE(pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetInteger64vAPPLE(GetPName, long*)"/>
        public static unsafe void GetInteger64vAPPLE(GetPName pname, long[] parameters)
        {
            fixed (long* parameters_ptr = parameters)
            {
                GetInteger64vAPPLE(pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetInteger64vAPPLE(GetPName, long*)"/>
        public static unsafe void GetInteger64vAPPLE(GetPName pname, ref long parameters)
        {
            fixed (long* parameters_ptr = &parameters)
            {
                GetInteger64vAPPLE(pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSyncivAPPLE(GLSync, SyncParameterName, int, int*, int*)"/>
        public static unsafe void GetSyncivAPPLE(GLSync sync, SyncParameterName pname, int count, Span<int> length, Span<int> values)
        {
            fixed (int* values_ptr = values)
            {
                fixed (int* length_ptr = length)
                {
                    GetSyncivAPPLE(sync, pname, count, length_ptr, values_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetSyncivAPPLE(GLSync, SyncParameterName, int, int*, int*)"/>
        public static unsafe void GetSyncivAPPLE(GLSync sync, SyncParameterName pname, int count, int[] length, int[] values)
        {
            fixed (int* values_ptr = values)
            {
                fixed (int* length_ptr = length)
                {
                    GetSyncivAPPLE(sync, pname, count, length_ptr, values_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetSyncivAPPLE(GLSync, SyncParameterName, int, int*, int*)"/>
        public static unsafe void GetSyncivAPPLE(GLSync sync, SyncParameterName pname, int count, ref int length, ref int values)
        {
            fixed (int* length_ptr = &length)
            fixed (int* values_ptr = &values)
            {
                GetSyncivAPPLE(sync, pname, count, length_ptr, values_ptr);
            }
        }
    }
    public static unsafe partial class ARM
    {
    }
    public static unsafe partial class EXT
    {
        /// <inheritdoc cref="BindFragDataLocationEXT(int, uint, byte*)"/>
        public static unsafe void BindFragDataLocationEXT(int program, uint color, string name)
        {
            byte* name_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(name);
            BindFragDataLocationEXT(program, color, name_ptr);
            Marshal.FreeCoTaskMem((IntPtr)name_ptr);
        }
        /// <inheritdoc cref="BindFragDataLocationIndexedEXT(int, uint, uint, byte*)"/>
        public static unsafe void BindFragDataLocationIndexedEXT(int program, uint colorNumber, uint index, string name)
        {
            byte* name_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(name);
            BindFragDataLocationIndexedEXT(program, colorNumber, index, name_ptr);
            Marshal.FreeCoTaskMem((IntPtr)name_ptr);
        }
        /// <inheritdoc cref="BufferStorageEXT(BufferStorageTarget, nint, void*, BufferStorageMask)"/>
        public static unsafe void BufferStorageEXT(BufferStorageTarget target, nint size, IntPtr data, BufferStorageMask flags)
        {
            void* data_vptr = (void*)data;
            BufferStorageEXT(target, size, data_vptr, flags);
        }
        /// <inheritdoc cref="BufferStorageEXT(BufferStorageTarget, nint, void*, BufferStorageMask)"/>
        public static unsafe void BufferStorageEXT<T1>(BufferStorageTarget target, nint size, ReadOnlySpan<T1> data, BufferStorageMask flags)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                BufferStorageEXT(target, size, data_ptr, flags);
            }
        }
        /// <inheritdoc cref="BufferStorageEXT(BufferStorageTarget, nint, void*, BufferStorageMask)"/>
        public static unsafe void BufferStorageEXT<T1>(BufferStorageTarget target, nint size, T1[] data, BufferStorageMask flags)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                BufferStorageEXT(target, size, data_ptr, flags);
            }
        }
        /// <inheritdoc cref="BufferStorageEXT(BufferStorageTarget, nint, void*, BufferStorageMask)"/>
        public static unsafe void BufferStorageEXT<T1>(BufferStorageTarget target, nint size, ref readonly T1 data, BufferStorageMask flags)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = &data)
            {
                BufferStorageEXT(target, size, data_ptr, flags);
            }
        }
        /// <inheritdoc cref="BufferStorageExternalEXT(All, IntPtr, nint, void*, BufferStorageMask)"/>
        public static unsafe void BufferStorageExternalEXT(All target, IntPtr offset, nint size, IntPtr clientBuffer, BufferStorageMask flags)
        {
            void* clientBuffer_vptr = (void*)clientBuffer;
            BufferStorageExternalEXT(target, offset, size, clientBuffer_vptr, flags);
        }
        /// <inheritdoc cref="BufferStorageExternalEXT(All, IntPtr, nint, void*, BufferStorageMask)"/>
        public static unsafe void BufferStorageExternalEXT<T1>(All target, IntPtr offset, nint size, Span<T1> clientBuffer, BufferStorageMask flags)
            where T1 : unmanaged
        {
            fixed (void* clientBuffer_ptr = clientBuffer)
            {
                BufferStorageExternalEXT(target, offset, size, clientBuffer_ptr, flags);
            }
        }
        /// <inheritdoc cref="BufferStorageExternalEXT(All, IntPtr, nint, void*, BufferStorageMask)"/>
        public static unsafe void BufferStorageExternalEXT<T1>(All target, IntPtr offset, nint size, T1[] clientBuffer, BufferStorageMask flags)
            where T1 : unmanaged
        {
            fixed (void* clientBuffer_ptr = clientBuffer)
            {
                BufferStorageExternalEXT(target, offset, size, clientBuffer_ptr, flags);
            }
        }
        /// <inheritdoc cref="BufferStorageExternalEXT(All, IntPtr, nint, void*, BufferStorageMask)"/>
        public static unsafe void BufferStorageExternalEXT<T1>(All target, IntPtr offset, nint size, ref T1 clientBuffer, BufferStorageMask flags)
            where T1 : unmanaged
        {
            fixed (void* clientBuffer_ptr = &clientBuffer)
            {
                BufferStorageExternalEXT(target, offset, size, clientBuffer_ptr, flags);
            }
        }
        /// <inheritdoc cref="ClearPixelLocalStorageuiEXT(int, int, uint*)"/>
        public static unsafe void ClearPixelLocalStorageuiEXT(int offset, int n, ReadOnlySpan<uint> values)
        {
            fixed (uint* values_ptr = values)
            {
                ClearPixelLocalStorageuiEXT(offset, n, values_ptr);
            }
        }
        /// <inheritdoc cref="ClearPixelLocalStorageuiEXT(int, int, uint*)"/>
        public static unsafe void ClearPixelLocalStorageuiEXT(int offset, int n, uint[] values)
        {
            fixed (uint* values_ptr = values)
            {
                ClearPixelLocalStorageuiEXT(offset, n, values_ptr);
            }
        }
        /// <inheritdoc cref="ClearPixelLocalStorageuiEXT(int, int, uint*)"/>
        public static unsafe void ClearPixelLocalStorageuiEXT(int offset, int n, ref readonly uint values)
        {
            fixed (uint* values_ptr = &values)
            {
                ClearPixelLocalStorageuiEXT(offset, n, values_ptr);
            }
        }
        /// <inheritdoc cref="ClearTexImageEXT(int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void ClearTexImageEXT(int texture, int level, PixelFormat format, PixelType type, IntPtr data)
        {
            void* data_vptr = (void*)data;
            ClearTexImageEXT(texture, level, format, type, data_vptr);
        }
        /// <inheritdoc cref="ClearTexImageEXT(int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void ClearTexImageEXT<T1>(int texture, int level, PixelFormat format, PixelType type, ReadOnlySpan<T1> data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                ClearTexImageEXT(texture, level, format, type, data_ptr);
            }
        }
        /// <inheritdoc cref="ClearTexImageEXT(int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void ClearTexImageEXT<T1>(int texture, int level, PixelFormat format, PixelType type, T1[] data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                ClearTexImageEXT(texture, level, format, type, data_ptr);
            }
        }
        /// <inheritdoc cref="ClearTexImageEXT(int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void ClearTexImageEXT<T1>(int texture, int level, PixelFormat format, PixelType type, ref readonly T1 data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = &data)
            {
                ClearTexImageEXT(texture, level, format, type, data_ptr);
            }
        }
        /// <inheritdoc cref="ClearTexSubImageEXT(int, int, int, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void ClearTexSubImageEXT(int texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, IntPtr data)
        {
            void* data_vptr = (void*)data;
            ClearTexSubImageEXT(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, data_vptr);
        }
        /// <inheritdoc cref="ClearTexSubImageEXT(int, int, int, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void ClearTexSubImageEXT<T1>(int texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, ReadOnlySpan<T1> data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                ClearTexSubImageEXT(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, data_ptr);
            }
        }
        /// <inheritdoc cref="ClearTexSubImageEXT(int, int, int, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void ClearTexSubImageEXT<T1>(int texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, T1[] data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                ClearTexSubImageEXT(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, data_ptr);
            }
        }
        /// <inheritdoc cref="ClearTexSubImageEXT(int, int, int, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void ClearTexSubImageEXT<T1>(int texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, ref readonly T1 data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = &data)
            {
                ClearTexSubImageEXT(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, data_ptr);
            }
        }
        /// <inheritdoc cref="CreateMemoryObjectsEXT(int, uint*)"/>
        public static unsafe void CreateMemoryObjectsEXT(int n, Span<uint> memoryObjects)
        {
            fixed (uint* memoryObjects_ptr = memoryObjects)
            {
                CreateMemoryObjectsEXT(n, memoryObjects_ptr);
            }
        }
        /// <inheritdoc cref="CreateMemoryObjectsEXT(int, uint*)"/>
        public static unsafe void CreateMemoryObjectsEXT(int n, uint[] memoryObjects)
        {
            fixed (uint* memoryObjects_ptr = memoryObjects)
            {
                CreateMemoryObjectsEXT(n, memoryObjects_ptr);
            }
        }
        /// <inheritdoc cref="CreateMemoryObjectsEXT(int, uint*)"/>
        public static unsafe void CreateMemoryObjectsEXT(int n, ref uint memoryObjects)
        {
            fixed (uint* memoryObjects_ptr = &memoryObjects)
            {
                CreateMemoryObjectsEXT(n, memoryObjects_ptr);
            }
        }
        /// <inheritdoc cref="CreateShaderProgramEXT(ShaderType, byte*)"/>
        public static unsafe int CreateShaderProgramEXT(ShaderType type, string str)
        {
            byte* str_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(str);
            var returnValue = CreateShaderProgramEXT(type, str_ptr);
            Marshal.FreeCoTaskMem((IntPtr)str_ptr);
            return returnValue;
        }
        /// <inheritdoc cref="CreateShaderProgramvEXT(ShaderType, int, byte**)"/>
        public static unsafe int CreateShaderProgramvEXT(ShaderType type, int count, string[] strings)
        {
            byte** strings_ptr = (byte**)MarshalTk.StringArrayToCoTaskMemUTF8(strings);
            var returnValue = CreateShaderProgramvEXT(type, count, strings_ptr);
            MarshalTk.FreeStringArrayCoTaskMem((IntPtr)strings_ptr, strings.Length);
            return returnValue;
        }
        /// <inheritdoc cref="DeleteMemoryObjectsEXT(int, uint*)"/>
        public static unsafe void DeleteMemoryObjectsEXT(int n, ReadOnlySpan<uint> memoryObjects)
        {
            fixed (uint* memoryObjects_ptr = memoryObjects)
            {
                DeleteMemoryObjectsEXT(n, memoryObjects_ptr);
            }
        }
        /// <inheritdoc cref="DeleteMemoryObjectsEXT(int, uint*)"/>
        public static unsafe void DeleteMemoryObjectsEXT(int n, uint[] memoryObjects)
        {
            fixed (uint* memoryObjects_ptr = memoryObjects)
            {
                DeleteMemoryObjectsEXT(n, memoryObjects_ptr);
            }
        }
        /// <inheritdoc cref="DeleteMemoryObjectsEXT(int, uint*)"/>
        public static unsafe void DeleteMemoryObjectsEXT(int n, ref readonly uint memoryObjects)
        {
            fixed (uint* memoryObjects_ptr = &memoryObjects)
            {
                DeleteMemoryObjectsEXT(n, memoryObjects_ptr);
            }
        }
        /// <inheritdoc cref="DeleteProgramPipelinesEXT(int, int*)"/>
        public static unsafe void DeleteProgramPipelinesEXT(int n, ReadOnlySpan<int> pipelines)
        {
            fixed (int* pipelines_ptr = pipelines)
            {
                DeleteProgramPipelinesEXT(n, pipelines_ptr);
            }
        }
        /// <inheritdoc cref="DeleteProgramPipelinesEXT(int, int*)"/>
        public static unsafe void DeleteProgramPipelinesEXT(int n, int[] pipelines)
        {
            fixed (int* pipelines_ptr = pipelines)
            {
                DeleteProgramPipelinesEXT(n, pipelines_ptr);
            }
        }
        /// <inheritdoc cref="DeleteProgramPipelinesEXT(int, int*)"/>
        public static unsafe void DeleteProgramPipelinesEXT(int n, ref readonly int pipelines)
        {
            fixed (int* pipelines_ptr = &pipelines)
            {
                DeleteProgramPipelinesEXT(n, pipelines_ptr);
            }
        }
        /// <inheritdoc cref="DeleteQueriesEXT(int, int*)"/>
        public static unsafe void DeleteQueriesEXT(int n, ReadOnlySpan<int> ids)
        {
            fixed (int* ids_ptr = ids)
            {
                DeleteQueriesEXT(n, ids_ptr);
            }
        }
        /// <inheritdoc cref="DeleteQueriesEXT(int, int*)"/>
        public static unsafe void DeleteQueriesEXT(int n, int[] ids)
        {
            fixed (int* ids_ptr = ids)
            {
                DeleteQueriesEXT(n, ids_ptr);
            }
        }
        /// <inheritdoc cref="DeleteQueriesEXT(int, int*)"/>
        public static unsafe void DeleteQueriesEXT(int n, ref readonly int ids)
        {
            fixed (int* ids_ptr = &ids)
            {
                DeleteQueriesEXT(n, ids_ptr);
            }
        }
        /// <inheritdoc cref="DeleteSemaphoresEXT(int, uint*)"/>
        public static unsafe void DeleteSemaphoresEXT(int n, ReadOnlySpan<uint> semaphores)
        {
            fixed (uint* semaphores_ptr = semaphores)
            {
                DeleteSemaphoresEXT(n, semaphores_ptr);
            }
        }
        /// <inheritdoc cref="DeleteSemaphoresEXT(int, uint*)"/>
        public static unsafe void DeleteSemaphoresEXT(int n, uint[] semaphores)
        {
            fixed (uint* semaphores_ptr = semaphores)
            {
                DeleteSemaphoresEXT(n, semaphores_ptr);
            }
        }
        /// <inheritdoc cref="DeleteSemaphoresEXT(int, uint*)"/>
        public static unsafe void DeleteSemaphoresEXT(int n, ref readonly uint semaphores)
        {
            fixed (uint* semaphores_ptr = &semaphores)
            {
                DeleteSemaphoresEXT(n, semaphores_ptr);
            }
        }
        /// <inheritdoc cref="DiscardFramebufferEXT(FramebufferTarget, int, InvalidateFramebufferAttachment*)"/>
        public static unsafe void DiscardFramebufferEXT(FramebufferTarget target, int numAttachments, ReadOnlySpan<InvalidateFramebufferAttachment> attachments)
        {
            fixed (InvalidateFramebufferAttachment* attachments_ptr = attachments)
            {
                DiscardFramebufferEXT(target, numAttachments, attachments_ptr);
            }
        }
        /// <inheritdoc cref="DiscardFramebufferEXT(FramebufferTarget, int, InvalidateFramebufferAttachment*)"/>
        public static unsafe void DiscardFramebufferEXT(FramebufferTarget target, int numAttachments, InvalidateFramebufferAttachment[] attachments)
        {
            fixed (InvalidateFramebufferAttachment* attachments_ptr = attachments)
            {
                DiscardFramebufferEXT(target, numAttachments, attachments_ptr);
            }
        }
        /// <inheritdoc cref="DiscardFramebufferEXT(FramebufferTarget, int, InvalidateFramebufferAttachment*)"/>
        public static unsafe void DiscardFramebufferEXT(FramebufferTarget target, int numAttachments, ref readonly InvalidateFramebufferAttachment attachments)
        {
            fixed (InvalidateFramebufferAttachment* attachments_ptr = &attachments)
            {
                DiscardFramebufferEXT(target, numAttachments, attachments_ptr);
            }
        }
        /// <inheritdoc cref="DrawBuffersEXT(int, All*)"/>
        public static unsafe void DrawBuffersEXT(int n, ReadOnlySpan<All> bufs)
        {
            fixed (All* bufs_ptr = bufs)
            {
                DrawBuffersEXT(n, bufs_ptr);
            }
        }
        /// <inheritdoc cref="DrawBuffersEXT(int, All*)"/>
        public static unsafe void DrawBuffersEXT(int n, All[] bufs)
        {
            fixed (All* bufs_ptr = bufs)
            {
                DrawBuffersEXT(n, bufs_ptr);
            }
        }
        /// <inheritdoc cref="DrawBuffersEXT(int, All*)"/>
        public static unsafe void DrawBuffersEXT(int n, ref readonly All bufs)
        {
            fixed (All* bufs_ptr = &bufs)
            {
                DrawBuffersEXT(n, bufs_ptr);
            }
        }
        /// <inheritdoc cref="DrawBuffersIndexedEXT(int, All*, int*)"/>
        public static unsafe void DrawBuffersIndexedEXT(int n, ReadOnlySpan<All> location, ReadOnlySpan<int> indices)
        {
            fixed (int* indices_ptr = indices)
            {
                fixed (All* location_ptr = location)
                {
                    DrawBuffersIndexedEXT(n, location_ptr, indices_ptr);
                }
            }
        }
        /// <inheritdoc cref="DrawBuffersIndexedEXT(int, All*, int*)"/>
        public static unsafe void DrawBuffersIndexedEXT(int n, All[] location, int[] indices)
        {
            fixed (int* indices_ptr = indices)
            {
                fixed (All* location_ptr = location)
                {
                    DrawBuffersIndexedEXT(n, location_ptr, indices_ptr);
                }
            }
        }
        /// <inheritdoc cref="DrawBuffersIndexedEXT(int, All*, int*)"/>
        public static unsafe void DrawBuffersIndexedEXT(int n, ref readonly All location, ref readonly int indices)
        {
            fixed (All* location_ptr = &location)
            fixed (int* indices_ptr = &indices)
            {
                DrawBuffersIndexedEXT(n, location_ptr, indices_ptr);
            }
        }
        /// <inheritdoc cref="DrawElementsBaseVertexEXT(PrimitiveType, int, DrawElementsType, void*, int)"/>
        public static unsafe void DrawElementsBaseVertexEXT(PrimitiveType mode, int count, DrawElementsType type, nint offset, int basevertex)
        {
            void* indices = (void*)offset;
            DrawElementsBaseVertexEXT(mode, count, type, indices, basevertex);
        }
        /// <inheritdoc cref="DrawElementsInstancedBaseInstanceEXT(PrimitiveType, int, DrawElementsType, void*, int, uint)"/>
        public static unsafe void DrawElementsInstancedBaseInstanceEXT(PrimitiveType mode, int count, DrawElementsType type, nint offset, int instancecount, uint baseinstance)
        {
            void* indices = (void*)offset;
            DrawElementsInstancedBaseInstanceEXT(mode, count, type, indices, instancecount, baseinstance);
        }
        /// <inheritdoc cref="DrawElementsInstancedBaseVertexBaseInstanceEXT(PrimitiveType, int, DrawElementsType, void*, int, int, uint)"/>
        public static unsafe void DrawElementsInstancedBaseVertexBaseInstanceEXT(PrimitiveType mode, int count, DrawElementsType type, nint offset, int instancecount, int basevertex, uint baseinstance)
        {
            void* indices = (void*)offset;
            DrawElementsInstancedBaseVertexBaseInstanceEXT(mode, count, type, indices, instancecount, basevertex, baseinstance);
        }
        /// <inheritdoc cref="DrawElementsInstancedBaseVertexEXT(PrimitiveType, int, DrawElementsType, void*, int, int)"/>
        public static unsafe void DrawElementsInstancedBaseVertexEXT(PrimitiveType mode, int count, DrawElementsType type, nint offset, int instancecount, int basevertex)
        {
            void* indices = (void*)offset;
            DrawElementsInstancedBaseVertexEXT(mode, count, type, indices, instancecount, basevertex);
        }
        /// <inheritdoc cref="DrawElementsInstancedEXT(PrimitiveType, int, DrawElementsType, void*, int)"/>
        public static unsafe void DrawElementsInstancedEXT(PrimitiveType mode, int count, DrawElementsType type, nint offset, int primcount)
        {
            void* indices = (void*)offset;
            DrawElementsInstancedEXT(mode, count, type, indices, primcount);
        }
        /// <inheritdoc cref="DrawRangeElementsBaseVertexEXT(PrimitiveType, uint, uint, int, DrawElementsType, void*, int)"/>
        public static unsafe void DrawRangeElementsBaseVertexEXT(PrimitiveType mode, uint start, uint end, int count, DrawElementsType type, nint offset, int basevertex)
        {
            void* indices = (void*)offset;
            DrawRangeElementsBaseVertexEXT(mode, start, end, count, type, indices, basevertex);
        }
        /// <inheritdoc cref="EGLImageTargetTexStorageEXT(All, void*, int*)"/>
        public static unsafe void EGLImageTargetTexStorageEXT(All target, IntPtr image, ReadOnlySpan<int> attrib_list)
        {
            fixed (int* attrib_list_ptr = attrib_list)
            {
                void* image_vptr = (void*)image;
                EGLImageTargetTexStorageEXT(target, image_vptr, attrib_list_ptr);
            }
        }
        /// <inheritdoc cref="EGLImageTargetTexStorageEXT(All, void*, int*)"/>
        public static unsafe void EGLImageTargetTexStorageEXT(All target, IntPtr image, int[] attrib_list)
        {
            fixed (int* attrib_list_ptr = attrib_list)
            {
                void* image_vptr = (void*)image;
                EGLImageTargetTexStorageEXT(target, image_vptr, attrib_list_ptr);
            }
        }
        /// <inheritdoc cref="EGLImageTargetTexStorageEXT(All, void*, int*)"/>
        public static unsafe void EGLImageTargetTexStorageEXT(All target, IntPtr image, ref readonly int attrib_list)
        {
            fixed (int* attrib_list_ptr = &attrib_list)
            {
                void* image_vptr = (void*)image;
                EGLImageTargetTexStorageEXT(target, image_vptr, attrib_list_ptr);
            }
        }
        /// <inheritdoc cref="EGLImageTargetTexStorageEXT(All, void*, int*)"/>
        public static unsafe void EGLImageTargetTexStorageEXT<T1>(All target, Span<T1> image, ReadOnlySpan<int> attrib_list)
            where T1 : unmanaged
        {
            fixed (int* attrib_list_ptr = attrib_list)
            {
                fixed (void* image_ptr = image)
                {
                    EGLImageTargetTexStorageEXT(target, image_ptr, attrib_list_ptr);
                }
            }
        }
        /// <inheritdoc cref="EGLImageTargetTexStorageEXT(All, void*, int*)"/>
        public static unsafe void EGLImageTargetTexStorageEXT<T1>(All target, T1[] image, int[] attrib_list)
            where T1 : unmanaged
        {
            fixed (int* attrib_list_ptr = attrib_list)
            {
                fixed (void* image_ptr = image)
                {
                    EGLImageTargetTexStorageEXT(target, image_ptr, attrib_list_ptr);
                }
            }
        }
        /// <inheritdoc cref="EGLImageTargetTexStorageEXT(All, void*, int*)"/>
        public static unsafe void EGLImageTargetTexStorageEXT<T1>(All target, ref T1 image, ref readonly int attrib_list)
            where T1 : unmanaged
        {
            fixed (void* image_ptr = &image)
            fixed (int* attrib_list_ptr = &attrib_list)
            {
                EGLImageTargetTexStorageEXT(target, image_ptr, attrib_list_ptr);
            }
        }
        /// <inheritdoc cref="EGLImageTargetTextureStorageEXT(int, void*, int*)"/>
        public static unsafe void EGLImageTargetTextureStorageEXT(int texture, IntPtr image, ReadOnlySpan<int> attrib_list)
        {
            fixed (int* attrib_list_ptr = attrib_list)
            {
                void* image_vptr = (void*)image;
                EGLImageTargetTextureStorageEXT(texture, image_vptr, attrib_list_ptr);
            }
        }
        /// <inheritdoc cref="EGLImageTargetTextureStorageEXT(int, void*, int*)"/>
        public static unsafe void EGLImageTargetTextureStorageEXT(int texture, IntPtr image, int[] attrib_list)
        {
            fixed (int* attrib_list_ptr = attrib_list)
            {
                void* image_vptr = (void*)image;
                EGLImageTargetTextureStorageEXT(texture, image_vptr, attrib_list_ptr);
            }
        }
        /// <inheritdoc cref="EGLImageTargetTextureStorageEXT(int, void*, int*)"/>
        public static unsafe void EGLImageTargetTextureStorageEXT(int texture, IntPtr image, ref readonly int attrib_list)
        {
            fixed (int* attrib_list_ptr = &attrib_list)
            {
                void* image_vptr = (void*)image;
                EGLImageTargetTextureStorageEXT(texture, image_vptr, attrib_list_ptr);
            }
        }
        /// <inheritdoc cref="EGLImageTargetTextureStorageEXT(int, void*, int*)"/>
        public static unsafe void EGLImageTargetTextureStorageEXT<T1>(int texture, Span<T1> image, ReadOnlySpan<int> attrib_list)
            where T1 : unmanaged
        {
            fixed (int* attrib_list_ptr = attrib_list)
            {
                fixed (void* image_ptr = image)
                {
                    EGLImageTargetTextureStorageEXT(texture, image_ptr, attrib_list_ptr);
                }
            }
        }
        /// <inheritdoc cref="EGLImageTargetTextureStorageEXT(int, void*, int*)"/>
        public static unsafe void EGLImageTargetTextureStorageEXT<T1>(int texture, T1[] image, int[] attrib_list)
            where T1 : unmanaged
        {
            fixed (int* attrib_list_ptr = attrib_list)
            {
                fixed (void* image_ptr = image)
                {
                    EGLImageTargetTextureStorageEXT(texture, image_ptr, attrib_list_ptr);
                }
            }
        }
        /// <inheritdoc cref="EGLImageTargetTextureStorageEXT(int, void*, int*)"/>
        public static unsafe void EGLImageTargetTextureStorageEXT<T1>(int texture, ref T1 image, ref readonly int attrib_list)
            where T1 : unmanaged
        {
            fixed (void* image_ptr = &image)
            fixed (int* attrib_list_ptr = &attrib_list)
            {
                EGLImageTargetTextureStorageEXT(texture, image_ptr, attrib_list_ptr);
            }
        }
        /// <inheritdoc cref="GenProgramPipelinesEXT(int, int*)"/>
        public static unsafe void GenProgramPipelinesEXT(int n, Span<int> pipelines)
        {
            fixed (int* pipelines_ptr = pipelines)
            {
                GenProgramPipelinesEXT(n, pipelines_ptr);
            }
        }
        /// <inheritdoc cref="GenProgramPipelinesEXT(int, int*)"/>
        public static unsafe void GenProgramPipelinesEXT(int n, int[] pipelines)
        {
            fixed (int* pipelines_ptr = pipelines)
            {
                GenProgramPipelinesEXT(n, pipelines_ptr);
            }
        }
        /// <inheritdoc cref="GenProgramPipelinesEXT(int, int*)"/>
        public static unsafe void GenProgramPipelinesEXT(int n, ref int pipelines)
        {
            fixed (int* pipelines_ptr = &pipelines)
            {
                GenProgramPipelinesEXT(n, pipelines_ptr);
            }
        }
        /// <inheritdoc cref="GenQueriesEXT(int, int*)"/>
        public static unsafe void GenQueriesEXT(int n, Span<int> ids)
        {
            fixed (int* ids_ptr = ids)
            {
                GenQueriesEXT(n, ids_ptr);
            }
        }
        /// <inheritdoc cref="GenQueriesEXT(int, int*)"/>
        public static unsafe void GenQueriesEXT(int n, int[] ids)
        {
            fixed (int* ids_ptr = ids)
            {
                GenQueriesEXT(n, ids_ptr);
            }
        }
        /// <inheritdoc cref="GenQueriesEXT(int, int*)"/>
        public static unsafe void GenQueriesEXT(int n, ref int ids)
        {
            fixed (int* ids_ptr = &ids)
            {
                GenQueriesEXT(n, ids_ptr);
            }
        }
        /// <inheritdoc cref="GenSemaphoresEXT(int, uint*)"/>
        public static unsafe void GenSemaphoresEXT(int n, Span<uint> semaphores)
        {
            fixed (uint* semaphores_ptr = semaphores)
            {
                GenSemaphoresEXT(n, semaphores_ptr);
            }
        }
        /// <inheritdoc cref="GenSemaphoresEXT(int, uint*)"/>
        public static unsafe void GenSemaphoresEXT(int n, uint[] semaphores)
        {
            fixed (uint* semaphores_ptr = semaphores)
            {
                GenSemaphoresEXT(n, semaphores_ptr);
            }
        }
        /// <inheritdoc cref="GenSemaphoresEXT(int, uint*)"/>
        public static unsafe void GenSemaphoresEXT(int n, ref uint semaphores)
        {
            fixed (uint* semaphores_ptr = &semaphores)
            {
                GenSemaphoresEXT(n, semaphores_ptr);
            }
        }
        /// <inheritdoc cref="GetFragDataIndexEXT(int, byte*)"/>
        public static unsafe int GetFragDataIndexEXT(int program, string name)
        {
            byte* name_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(name);
            var returnValue = GetFragDataIndexEXT(program, name_ptr);
            Marshal.FreeCoTaskMem((IntPtr)name_ptr);
            return returnValue;
        }
        /// <inheritdoc cref="GetFragmentShadingRatesEXT(int, int, int*, ShadingRate*)"/>
        public static unsafe void GetFragmentShadingRatesEXT(int samples, int maxCount, out int count, Span<ShadingRate> shadingRates)
        {
            fixed (int* count_ptr = &count)
            {
                fixed (ShadingRate* shadingRates_ptr = shadingRates)
                {
                    GetFragmentShadingRatesEXT(samples, maxCount, count_ptr, shadingRates_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetFragmentShadingRatesEXT(int, int, int*, ShadingRate*)"/>
        public static unsafe void GetFragmentShadingRatesEXT(int samples, int maxCount, out int count, ShadingRate[] shadingRates)
        {
            fixed (int* count_ptr = &count)
            {
                fixed (ShadingRate* shadingRates_ptr = shadingRates)
                {
                    GetFragmentShadingRatesEXT(samples, maxCount, count_ptr, shadingRates_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetFragmentShadingRatesEXT(int, int, int*, ShadingRate*)"/>
        public static unsafe void GetFragmentShadingRatesEXT(int samples, int maxCount, out int count, ref ShadingRate shadingRates)
        {
            fixed (int* count_ptr = &count)
            fixed (ShadingRate* shadingRates_ptr = &shadingRates)
            {
                GetFragmentShadingRatesEXT(samples, maxCount, count_ptr, shadingRates_ptr);
            }
        }
        /// <inheritdoc cref="GetInteger64vEXT(GetPName, long*)"/>
        public static unsafe void GetInteger64vEXT(GetPName pname, Span<long> data)
        {
            fixed (long* data_ptr = data)
            {
                GetInteger64vEXT(pname, data_ptr);
            }
        }
        /// <inheritdoc cref="GetInteger64vEXT(GetPName, long*)"/>
        public static unsafe void GetInteger64vEXT(GetPName pname, long[] data)
        {
            fixed (long* data_ptr = data)
            {
                GetInteger64vEXT(pname, data_ptr);
            }
        }
        /// <inheritdoc cref="GetInteger64vEXT(GetPName, long*)"/>
        public static unsafe long GetInteger64vEXT(GetPName pname)
        {
            long data;
            long* data_ptr = &data;
            {
                GetInteger64vEXT(pname, data_ptr);
            }
            return data;
        }
        /// <inheritdoc cref="GetInteger64vEXT(GetPName, long*)"/>
        public static unsafe void GetInteger64vEXT(GetPName pname, out long data)
        {
            fixed (long* data_ptr = &data)
            {
                GetInteger64vEXT(pname, data_ptr);
            }
        }
        /// <inheritdoc cref="GetIntegeri_vEXT(GetPName, uint, int*)"/>
        public static unsafe void GetIntegeri_vEXT(GetPName target, uint index, Span<int> data)
        {
            fixed (int* data_ptr = data)
            {
                GetIntegeri_vEXT(target, index, data_ptr);
            }
        }
        /// <inheritdoc cref="GetIntegeri_vEXT(GetPName, uint, int*)"/>
        public static unsafe void GetIntegeri_vEXT(GetPName target, uint index, int[] data)
        {
            fixed (int* data_ptr = data)
            {
                GetIntegeri_vEXT(target, index, data_ptr);
            }
        }
        /// <inheritdoc cref="GetIntegeri_vEXT(GetPName, uint, int*)"/>
        public static unsafe void GetIntegeri_vEXT(GetPName target, uint index, ref int data)
        {
            fixed (int* data_ptr = &data)
            {
                GetIntegeri_vEXT(target, index, data_ptr);
            }
        }
        /// <inheritdoc cref="GetMemoryObjectParameterivEXT(uint, MemoryObjectParameterName, int*)"/>
        public static unsafe void GetMemoryObjectParameterivEXT(uint memoryObject, MemoryObjectParameterName pname, Span<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetMemoryObjectParameterivEXT(memoryObject, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetMemoryObjectParameterivEXT(uint, MemoryObjectParameterName, int*)"/>
        public static unsafe void GetMemoryObjectParameterivEXT(uint memoryObject, MemoryObjectParameterName pname, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetMemoryObjectParameterivEXT(memoryObject, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetMemoryObjectParameterivEXT(uint, MemoryObjectParameterName, int*)"/>
        public static unsafe void GetMemoryObjectParameterivEXT(uint memoryObject, MemoryObjectParameterName pname, ref int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                GetMemoryObjectParameterivEXT(memoryObject, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformfvEXT(int, int, int, float*)"/>
        public static unsafe void GetnUniformfvEXT(int program, int location, int bufSize, Span<float> parameters)
        {
            fixed (float* parameters_ptr = parameters)
            {
                GetnUniformfvEXT(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformfvEXT(int, int, int, float*)"/>
        public static unsafe void GetnUniformfvEXT(int program, int location, int bufSize, float[] parameters)
        {
            fixed (float* parameters_ptr = parameters)
            {
                GetnUniformfvEXT(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformfvEXT(int, int, int, float*)"/>
        public static unsafe void GetnUniformfvEXT(int program, int location, int bufSize, ref float parameters)
        {
            fixed (float* parameters_ptr = &parameters)
            {
                GetnUniformfvEXT(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformivEXT(int, int, int, int*)"/>
        public static unsafe void GetnUniformivEXT(int program, int location, int bufSize, Span<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetnUniformivEXT(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformivEXT(int, int, int, int*)"/>
        public static unsafe void GetnUniformivEXT(int program, int location, int bufSize, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetnUniformivEXT(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformivEXT(int, int, int, int*)"/>
        public static unsafe void GetnUniformivEXT(int program, int location, int bufSize, ref int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                GetnUniformivEXT(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetObjectLabelEXT(All, uint, int, int*, byte*)"/>
        public static unsafe string GetObjectLabelEXT(All type, uint obj, int bufSize, out int length)
        {
            string label;
            fixed (int* length_ptr = &length)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetObjectLabelEXT(type, obj, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
            return label;
        }
        /// <inheritdoc cref="GetObjectLabelEXT(All, uint, int, int*, byte*)"/>
        public static unsafe void GetObjectLabelEXT(All type, uint obj, int bufSize, out int length, out string label)
        {
            fixed (int* length_ptr = &length)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetObjectLabelEXT(type, obj, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
        }
        /// <inheritdoc cref="GetProgramPipelineInfoLogEXT(int, int, int*, byte*)"/>
        public static unsafe string GetProgramPipelineInfoLogEXT(int pipeline, int bufSize, out int length)
        {
            string infoLog;
            fixed (int* length_ptr = &length)
            {
                var infoLog_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetProgramPipelineInfoLogEXT(pipeline, bufSize, length_ptr, infoLog_ptr);
                infoLog = Marshal.PtrToStringUTF8((IntPtr)infoLog_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)infoLog_ptr);
            }
            return infoLog;
        }
        /// <inheritdoc cref="GetProgramPipelineInfoLogEXT(int, int, int*, byte*)"/>
        public static unsafe void GetProgramPipelineInfoLogEXT(int pipeline, int bufSize, out int length, out string infoLog)
        {
            fixed (int* length_ptr = &length)
            {
                var infoLog_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetProgramPipelineInfoLogEXT(pipeline, bufSize, length_ptr, infoLog_ptr);
                infoLog = Marshal.PtrToStringUTF8((IntPtr)infoLog_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)infoLog_ptr);
            }
        }
        /// <inheritdoc cref="GetProgramPipelineivEXT(int, PipelineParameterName, int*)"/>
        public static unsafe void GetProgramPipelineivEXT(int pipeline, PipelineParameterName pname, Span<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetProgramPipelineivEXT(pipeline, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetProgramPipelineivEXT(int, PipelineParameterName, int*)"/>
        public static unsafe void GetProgramPipelineivEXT(int pipeline, PipelineParameterName pname, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetProgramPipelineivEXT(pipeline, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetProgramPipelineivEXT(int, PipelineParameterName, int*)"/>
        public static unsafe void GetProgramPipelineivEXT(int pipeline, PipelineParameterName pname, ref int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                GetProgramPipelineivEXT(pipeline, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetProgramResourceLocationIndexEXT(int, ProgramInterface, byte*)"/>
        public static unsafe int GetProgramResourceLocationIndexEXT(int program, ProgramInterface programInterface, string name)
        {
            byte* name_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(name);
            var returnValue = GetProgramResourceLocationIndexEXT(program, programInterface, name_ptr);
            Marshal.FreeCoTaskMem((IntPtr)name_ptr);
            return returnValue;
        }
        /// <inheritdoc cref="GetQueryivEXT(QueryTarget, QueryParameterName, int*)"/>
        public static unsafe void GetQueryivEXT(QueryTarget target, QueryParameterName pname, Span<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetQueryivEXT(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetQueryivEXT(QueryTarget, QueryParameterName, int*)"/>
        public static unsafe void GetQueryivEXT(QueryTarget target, QueryParameterName pname, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetQueryivEXT(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetQueryivEXT(QueryTarget, QueryParameterName, int*)"/>
        public static unsafe int GetQueryivEXT(QueryTarget target, QueryParameterName pname)
        {
            int parameters;
            int* parameters_ptr = &parameters;
            {
                GetQueryivEXT(target, pname, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetQueryivEXT(QueryTarget, QueryParameterName, int*)"/>
        public static unsafe void GetQueryivEXT(QueryTarget target, QueryParameterName pname, out int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                GetQueryivEXT(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetQueryObjecti64vEXT(int, QueryObjectParameterName, long*)"/>
        public static unsafe void GetQueryObjecti64vEXT(int id, QueryObjectParameterName pname, Span<long> parameters)
        {
            fixed (long* parameters_ptr = parameters)
            {
                GetQueryObjecti64vEXT(id, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetQueryObjecti64vEXT(int, QueryObjectParameterName, long*)"/>
        public static unsafe void GetQueryObjecti64vEXT(int id, QueryObjectParameterName pname, long[] parameters)
        {
            fixed (long* parameters_ptr = parameters)
            {
                GetQueryObjecti64vEXT(id, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetQueryObjecti64vEXT(int, QueryObjectParameterName, long*)"/>
        public static unsafe long GetQueryObjecti64vEXT(int id, QueryObjectParameterName pname)
        {
            long parameters;
            long* parameters_ptr = &parameters;
            {
                GetQueryObjecti64vEXT(id, pname, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetQueryObjecti64vEXT(int, QueryObjectParameterName, long*)"/>
        public static unsafe void GetQueryObjecti64vEXT(int id, QueryObjectParameterName pname, out long parameters)
        {
            fixed (long* parameters_ptr = &parameters)
            {
                GetQueryObjecti64vEXT(id, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetQueryObjectivEXT(int, QueryObjectParameterName, int*)"/>
        public static unsafe void GetQueryObjectivEXT(int id, QueryObjectParameterName pname, Span<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetQueryObjectivEXT(id, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetQueryObjectivEXT(int, QueryObjectParameterName, int*)"/>
        public static unsafe void GetQueryObjectivEXT(int id, QueryObjectParameterName pname, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetQueryObjectivEXT(id, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetQueryObjectivEXT(int, QueryObjectParameterName, int*)"/>
        public static unsafe int GetQueryObjectivEXT(int id, QueryObjectParameterName pname)
        {
            int parameters;
            int* parameters_ptr = &parameters;
            {
                GetQueryObjectivEXT(id, pname, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetQueryObjectivEXT(int, QueryObjectParameterName, int*)"/>
        public static unsafe void GetQueryObjectivEXT(int id, QueryObjectParameterName pname, out int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                GetQueryObjectivEXT(id, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetQueryObjectui64vEXT(int, QueryObjectParameterName, ulong*)"/>
        public static unsafe void GetQueryObjectui64vEXT(int id, QueryObjectParameterName pname, Span<ulong> parameters)
        {
            fixed (ulong* parameters_ptr = parameters)
            {
                GetQueryObjectui64vEXT(id, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetQueryObjectui64vEXT(int, QueryObjectParameterName, ulong*)"/>
        public static unsafe void GetQueryObjectui64vEXT(int id, QueryObjectParameterName pname, ulong[] parameters)
        {
            fixed (ulong* parameters_ptr = parameters)
            {
                GetQueryObjectui64vEXT(id, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetQueryObjectui64vEXT(int, QueryObjectParameterName, ulong*)"/>
        public static unsafe ulong GetQueryObjectui64vEXT(int id, QueryObjectParameterName pname)
        {
            ulong parameters;
            ulong* parameters_ptr = &parameters;
            {
                GetQueryObjectui64vEXT(id, pname, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetQueryObjectui64vEXT(int, QueryObjectParameterName, ulong*)"/>
        public static unsafe void GetQueryObjectui64vEXT(int id, QueryObjectParameterName pname, out ulong parameters)
        {
            fixed (ulong* parameters_ptr = &parameters)
            {
                GetQueryObjectui64vEXT(id, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetQueryObjectuivEXT(int, QueryObjectParameterName, uint*)"/>
        public static unsafe void GetQueryObjectuivEXT(int id, QueryObjectParameterName pname, Span<uint> parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                GetQueryObjectuivEXT(id, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetQueryObjectuivEXT(int, QueryObjectParameterName, uint*)"/>
        public static unsafe void GetQueryObjectuivEXT(int id, QueryObjectParameterName pname, uint[] parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                GetQueryObjectuivEXT(id, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetQueryObjectuivEXT(int, QueryObjectParameterName, uint*)"/>
        public static unsafe uint GetQueryObjectuivEXT(int id, QueryObjectParameterName pname)
        {
            uint parameters;
            uint* parameters_ptr = &parameters;
            {
                GetQueryObjectuivEXT(id, pname, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetQueryObjectuivEXT(int, QueryObjectParameterName, uint*)"/>
        public static unsafe void GetQueryObjectuivEXT(int id, QueryObjectParameterName pname, out uint parameters)
        {
            fixed (uint* parameters_ptr = &parameters)
            {
                GetQueryObjectuivEXT(id, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameterIivEXT(int, SamplerParameterI, int*)"/>
        public static unsafe void GetSamplerParameterIivEXT(int sampler, SamplerParameterI pname, Span<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetSamplerParameterIivEXT(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameterIivEXT(int, SamplerParameterI, int*)"/>
        public static unsafe void GetSamplerParameterIivEXT(int sampler, SamplerParameterI pname, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetSamplerParameterIivEXT(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameterIivEXT(int, SamplerParameterI, int*)"/>
        public static unsafe int GetSamplerParameterIivEXT(int sampler, SamplerParameterI pname)
        {
            int parameters;
            int* parameters_ptr = &parameters;
            {
                GetSamplerParameterIivEXT(sampler, pname, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetSamplerParameterIivEXT(int, SamplerParameterI, int*)"/>
        public static unsafe void GetSamplerParameterIivEXT(int sampler, SamplerParameterI pname, out int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                GetSamplerParameterIivEXT(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameterIuivEXT(int, SamplerParameterI, uint*)"/>
        public static unsafe void GetSamplerParameterIuivEXT(int sampler, SamplerParameterI pname, Span<uint> parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                GetSamplerParameterIuivEXT(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameterIuivEXT(int, SamplerParameterI, uint*)"/>
        public static unsafe void GetSamplerParameterIuivEXT(int sampler, SamplerParameterI pname, uint[] parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                GetSamplerParameterIuivEXT(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameterIuivEXT(int, SamplerParameterI, uint*)"/>
        public static unsafe uint GetSamplerParameterIuivEXT(int sampler, SamplerParameterI pname)
        {
            uint parameters;
            uint* parameters_ptr = &parameters;
            {
                GetSamplerParameterIuivEXT(sampler, pname, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetSamplerParameterIuivEXT(int, SamplerParameterI, uint*)"/>
        public static unsafe void GetSamplerParameterIuivEXT(int sampler, SamplerParameterI pname, out uint parameters)
        {
            fixed (uint* parameters_ptr = &parameters)
            {
                GetSamplerParameterIuivEXT(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSemaphoreParameterui64vEXT(uint, SemaphoreParameterName, ulong*)"/>
        public static unsafe void GetSemaphoreParameterui64vEXT(uint semaphore, SemaphoreParameterName pname, Span<ulong> parameters)
        {
            fixed (ulong* parameters_ptr = parameters)
            {
                GetSemaphoreParameterui64vEXT(semaphore, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSemaphoreParameterui64vEXT(uint, SemaphoreParameterName, ulong*)"/>
        public static unsafe void GetSemaphoreParameterui64vEXT(uint semaphore, SemaphoreParameterName pname, ulong[] parameters)
        {
            fixed (ulong* parameters_ptr = parameters)
            {
                GetSemaphoreParameterui64vEXT(semaphore, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSemaphoreParameterui64vEXT(uint, SemaphoreParameterName, ulong*)"/>
        public static unsafe void GetSemaphoreParameterui64vEXT(uint semaphore, SemaphoreParameterName pname, ref ulong parameters)
        {
            fixed (ulong* parameters_ptr = &parameters)
            {
                GetSemaphoreParameterui64vEXT(semaphore, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetTexParameterIivEXT(TextureTarget, GetTextureParameter, int*)"/>
        public static unsafe void GetTexParameterIivEXT(TextureTarget target, GetTextureParameter pname, Span<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetTexParameterIivEXT(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetTexParameterIivEXT(TextureTarget, GetTextureParameter, int*)"/>
        public static unsafe void GetTexParameterIivEXT(TextureTarget target, GetTextureParameter pname, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetTexParameterIivEXT(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetTexParameterIivEXT(TextureTarget, GetTextureParameter, int*)"/>
        public static unsafe int GetTexParameterIivEXT(TextureTarget target, GetTextureParameter pname)
        {
            int parameters;
            int* parameters_ptr = &parameters;
            {
                GetTexParameterIivEXT(target, pname, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetTexParameterIivEXT(TextureTarget, GetTextureParameter, int*)"/>
        public static unsafe void GetTexParameterIivEXT(TextureTarget target, GetTextureParameter pname, out int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                GetTexParameterIivEXT(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetTexParameterIuivEXT(TextureTarget, GetTextureParameter, uint*)"/>
        public static unsafe void GetTexParameterIuivEXT(TextureTarget target, GetTextureParameter pname, Span<uint> parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                GetTexParameterIuivEXT(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetTexParameterIuivEXT(TextureTarget, GetTextureParameter, uint*)"/>
        public static unsafe void GetTexParameterIuivEXT(TextureTarget target, GetTextureParameter pname, uint[] parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                GetTexParameterIuivEXT(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetTexParameterIuivEXT(TextureTarget, GetTextureParameter, uint*)"/>
        public static unsafe uint GetTexParameterIuivEXT(TextureTarget target, GetTextureParameter pname)
        {
            uint parameters;
            uint* parameters_ptr = &parameters;
            {
                GetTexParameterIuivEXT(target, pname, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetTexParameterIuivEXT(TextureTarget, GetTextureParameter, uint*)"/>
        public static unsafe void GetTexParameterIuivEXT(TextureTarget target, GetTextureParameter pname, out uint parameters)
        {
            fixed (uint* parameters_ptr = &parameters)
            {
                GetTexParameterIuivEXT(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetUnsignedBytei_vEXT(All, uint, byte*)"/>
        public static unsafe void GetUnsignedBytei_vEXT(All target, uint index, Span<byte> data)
        {
            fixed (byte* data_ptr = data)
            {
                GetUnsignedBytei_vEXT(target, index, data_ptr);
            }
        }
        /// <inheritdoc cref="GetUnsignedBytei_vEXT(All, uint, byte*)"/>
        public static unsafe void GetUnsignedBytei_vEXT(All target, uint index, byte[] data)
        {
            fixed (byte* data_ptr = data)
            {
                GetUnsignedBytei_vEXT(target, index, data_ptr);
            }
        }
        /// <inheritdoc cref="GetUnsignedBytei_vEXT(All, uint, byte*)"/>
        public static unsafe byte GetUnsignedBytei_vEXT(All target, uint index)
        {
            byte data;
            byte* data_ptr = &data;
            {
                GetUnsignedBytei_vEXT(target, index, data_ptr);
            }
            return data;
        }
        /// <inheritdoc cref="GetUnsignedBytei_vEXT(All, uint, byte*)"/>
        public static unsafe void GetUnsignedBytei_vEXT(All target, uint index, out byte data)
        {
            fixed (byte* data_ptr = &data)
            {
                GetUnsignedBytei_vEXT(target, index, data_ptr);
            }
        }
        /// <inheritdoc cref="GetUnsignedBytevEXT(GetPName, byte*)"/>
        public static unsafe void GetUnsignedBytevEXT(GetPName pname, Span<byte> data)
        {
            fixed (byte* data_ptr = data)
            {
                GetUnsignedBytevEXT(pname, data_ptr);
            }
        }
        /// <inheritdoc cref="GetUnsignedBytevEXT(GetPName, byte*)"/>
        public static unsafe void GetUnsignedBytevEXT(GetPName pname, byte[] data)
        {
            fixed (byte* data_ptr = data)
            {
                GetUnsignedBytevEXT(pname, data_ptr);
            }
        }
        /// <inheritdoc cref="GetUnsignedBytevEXT(GetPName, byte*)"/>
        public static unsafe byte GetUnsignedBytevEXT(GetPName pname)
        {
            byte data;
            byte* data_ptr = &data;
            {
                GetUnsignedBytevEXT(pname, data_ptr);
            }
            return data;
        }
        /// <inheritdoc cref="GetUnsignedBytevEXT(GetPName, byte*)"/>
        public static unsafe void GetUnsignedBytevEXT(GetPName pname, out byte data)
        {
            fixed (byte* data_ptr = &data)
            {
                GetUnsignedBytevEXT(pname, data_ptr);
            }
        }
        /// <inheritdoc cref="ImportMemoryWin32HandleEXT(uint, ulong, ExternalHandleType, void*)"/>
        public static unsafe void ImportMemoryWin32HandleEXT(uint memory, ulong size, ExternalHandleType handleType, IntPtr handle)
        {
            void* handle_vptr = (void*)handle;
            ImportMemoryWin32HandleEXT(memory, size, handleType, handle_vptr);
        }
        /// <inheritdoc cref="ImportMemoryWin32HandleEXT(uint, ulong, ExternalHandleType, void*)"/>
        public static unsafe void ImportMemoryWin32HandleEXT<T1>(uint memory, ulong size, ExternalHandleType handleType, Span<T1> handle)
            where T1 : unmanaged
        {
            fixed (void* handle_ptr = handle)
            {
                ImportMemoryWin32HandleEXT(memory, size, handleType, handle_ptr);
            }
        }
        /// <inheritdoc cref="ImportMemoryWin32HandleEXT(uint, ulong, ExternalHandleType, void*)"/>
        public static unsafe void ImportMemoryWin32HandleEXT<T1>(uint memory, ulong size, ExternalHandleType handleType, T1[] handle)
            where T1 : unmanaged
        {
            fixed (void* handle_ptr = handle)
            {
                ImportMemoryWin32HandleEXT(memory, size, handleType, handle_ptr);
            }
        }
        /// <inheritdoc cref="ImportMemoryWin32HandleEXT(uint, ulong, ExternalHandleType, void*)"/>
        public static unsafe void ImportMemoryWin32HandleEXT<T1>(uint memory, ulong size, ExternalHandleType handleType, ref readonly T1 handle)
            where T1 : unmanaged
        {
            fixed (void* handle_ptr = &handle)
            {
                ImportMemoryWin32HandleEXT(memory, size, handleType, handle_ptr);
            }
        }
        /// <inheritdoc cref="ImportMemoryWin32NameEXT(uint, ulong, ExternalHandleType, void*)"/>
        public static unsafe void ImportMemoryWin32NameEXT(uint memory, ulong size, ExternalHandleType handleType, IntPtr name)
        {
            void* name_vptr = (void*)name;
            ImportMemoryWin32NameEXT(memory, size, handleType, name_vptr);
        }
        /// <inheritdoc cref="ImportMemoryWin32NameEXT(uint, ulong, ExternalHandleType, void*)"/>
        public static unsafe void ImportMemoryWin32NameEXT<T1>(uint memory, ulong size, ExternalHandleType handleType, ReadOnlySpan<T1> name)
            where T1 : unmanaged
        {
            fixed (void* name_ptr = name)
            {
                ImportMemoryWin32NameEXT(memory, size, handleType, name_ptr);
            }
        }
        /// <inheritdoc cref="ImportMemoryWin32NameEXT(uint, ulong, ExternalHandleType, void*)"/>
        public static unsafe void ImportMemoryWin32NameEXT<T1>(uint memory, ulong size, ExternalHandleType handleType, T1[] name)
            where T1 : unmanaged
        {
            fixed (void* name_ptr = name)
            {
                ImportMemoryWin32NameEXT(memory, size, handleType, name_ptr);
            }
        }
        /// <inheritdoc cref="ImportMemoryWin32NameEXT(uint, ulong, ExternalHandleType, void*)"/>
        public static unsafe void ImportMemoryWin32NameEXT<T1>(uint memory, ulong size, ExternalHandleType handleType, ref readonly T1 name)
            where T1 : unmanaged
        {
            fixed (void* name_ptr = &name)
            {
                ImportMemoryWin32NameEXT(memory, size, handleType, name_ptr);
            }
        }
        /// <inheritdoc cref="ImportSemaphoreWin32HandleEXT(uint, ExternalHandleType, void*)"/>
        public static unsafe void ImportSemaphoreWin32HandleEXT(uint semaphore, ExternalHandleType handleType, IntPtr handle)
        {
            void* handle_vptr = (void*)handle;
            ImportSemaphoreWin32HandleEXT(semaphore, handleType, handle_vptr);
        }
        /// <inheritdoc cref="ImportSemaphoreWin32HandleEXT(uint, ExternalHandleType, void*)"/>
        public static unsafe void ImportSemaphoreWin32HandleEXT<T1>(uint semaphore, ExternalHandleType handleType, Span<T1> handle)
            where T1 : unmanaged
        {
            fixed (void* handle_ptr = handle)
            {
                ImportSemaphoreWin32HandleEXT(semaphore, handleType, handle_ptr);
            }
        }
        /// <inheritdoc cref="ImportSemaphoreWin32HandleEXT(uint, ExternalHandleType, void*)"/>
        public static unsafe void ImportSemaphoreWin32HandleEXT<T1>(uint semaphore, ExternalHandleType handleType, T1[] handle)
            where T1 : unmanaged
        {
            fixed (void* handle_ptr = handle)
            {
                ImportSemaphoreWin32HandleEXT(semaphore, handleType, handle_ptr);
            }
        }
        /// <inheritdoc cref="ImportSemaphoreWin32HandleEXT(uint, ExternalHandleType, void*)"/>
        public static unsafe void ImportSemaphoreWin32HandleEXT<T1>(uint semaphore, ExternalHandleType handleType, ref T1 handle)
            where T1 : unmanaged
        {
            fixed (void* handle_ptr = &handle)
            {
                ImportSemaphoreWin32HandleEXT(semaphore, handleType, handle_ptr);
            }
        }
        /// <inheritdoc cref="ImportSemaphoreWin32NameEXT(uint, ExternalHandleType, void*)"/>
        public static unsafe void ImportSemaphoreWin32NameEXT(uint semaphore, ExternalHandleType handleType, IntPtr name)
        {
            void* name_vptr = (void*)name;
            ImportSemaphoreWin32NameEXT(semaphore, handleType, name_vptr);
        }
        /// <inheritdoc cref="ImportSemaphoreWin32NameEXT(uint, ExternalHandleType, void*)"/>
        public static unsafe void ImportSemaphoreWin32NameEXT<T1>(uint semaphore, ExternalHandleType handleType, ReadOnlySpan<T1> name)
            where T1 : unmanaged
        {
            fixed (void* name_ptr = name)
            {
                ImportSemaphoreWin32NameEXT(semaphore, handleType, name_ptr);
            }
        }
        /// <inheritdoc cref="ImportSemaphoreWin32NameEXT(uint, ExternalHandleType, void*)"/>
        public static unsafe void ImportSemaphoreWin32NameEXT<T1>(uint semaphore, ExternalHandleType handleType, T1[] name)
            where T1 : unmanaged
        {
            fixed (void* name_ptr = name)
            {
                ImportSemaphoreWin32NameEXT(semaphore, handleType, name_ptr);
            }
        }
        /// <inheritdoc cref="ImportSemaphoreWin32NameEXT(uint, ExternalHandleType, void*)"/>
        public static unsafe void ImportSemaphoreWin32NameEXT<T1>(uint semaphore, ExternalHandleType handleType, ref readonly T1 name)
            where T1 : unmanaged
        {
            fixed (void* name_ptr = &name)
            {
                ImportSemaphoreWin32NameEXT(semaphore, handleType, name_ptr);
            }
        }
        /// <inheritdoc cref="InsertEventMarkerEXT(int, byte*)"/>
        public static unsafe void InsertEventMarkerEXT(int length, string marker)
        {
            byte* marker_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(marker);
            InsertEventMarkerEXT(length, marker_ptr);
            Marshal.FreeCoTaskMem((IntPtr)marker_ptr);
        }
        /// <inheritdoc cref="LabelObjectEXT(All, uint, int, byte*)"/>
        public static unsafe void LabelObjectEXT(All type, uint obj, int length, string label)
        {
            byte* label_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(label);
            LabelObjectEXT(type, obj, length, label_ptr);
            Marshal.FreeCoTaskMem((IntPtr)label_ptr);
        }
        /// <inheritdoc cref="MemoryObjectParameterivEXT(uint, MemoryObjectParameterName, int*)"/>
        public static unsafe void MemoryObjectParameterivEXT(uint memoryObject, MemoryObjectParameterName pname, ReadOnlySpan<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                MemoryObjectParameterivEXT(memoryObject, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="MemoryObjectParameterivEXT(uint, MemoryObjectParameterName, int*)"/>
        public static unsafe void MemoryObjectParameterivEXT(uint memoryObject, MemoryObjectParameterName pname, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                MemoryObjectParameterivEXT(memoryObject, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="MemoryObjectParameterivEXT(uint, MemoryObjectParameterName, int*)"/>
        public static unsafe void MemoryObjectParameterivEXT(uint memoryObject, MemoryObjectParameterName pname, ref readonly int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                MemoryObjectParameterivEXT(memoryObject, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="MultiDrawArraysEXT(PrimitiveType, int*, int*, int)"/>
        public static unsafe void MultiDrawArraysEXT(PrimitiveType mode, ReadOnlySpan<int> first, ReadOnlySpan<int> count, int primcount)
        {
            fixed (int* count_ptr = count)
            {
                fixed (int* first_ptr = first)
                {
                    MultiDrawArraysEXT(mode, first_ptr, count_ptr, primcount);
                }
            }
        }
        /// <inheritdoc cref="MultiDrawArraysEXT(PrimitiveType, int*, int*, int)"/>
        public static unsafe void MultiDrawArraysEXT(PrimitiveType mode, int[] first, int[] count, int primcount)
        {
            fixed (int* count_ptr = count)
            {
                fixed (int* first_ptr = first)
                {
                    MultiDrawArraysEXT(mode, first_ptr, count_ptr, primcount);
                }
            }
        }
        /// <inheritdoc cref="MultiDrawArraysEXT(PrimitiveType, int*, int*, int)"/>
        public static unsafe void MultiDrawArraysEXT(PrimitiveType mode, ref readonly int first, ref readonly int count, int primcount)
        {
            fixed (int* first_ptr = &first)
            fixed (int* count_ptr = &count)
            {
                MultiDrawArraysEXT(mode, first_ptr, count_ptr, primcount);
            }
        }
        /// <inheritdoc cref="MultiDrawArraysIndirectEXT(PrimitiveType, void*, int, int)"/>
        public static unsafe void MultiDrawArraysIndirectEXT(PrimitiveType mode, IntPtr indirect, int drawcount, int stride)
        {
            void* indirect_vptr = (void*)indirect;
            MultiDrawArraysIndirectEXT(mode, indirect_vptr, drawcount, stride);
        }
        /// <inheritdoc cref="MultiDrawArraysIndirectEXT(PrimitiveType, void*, int, int)"/>
        public static unsafe void MultiDrawArraysIndirectEXT<T1>(PrimitiveType mode, ReadOnlySpan<T1> indirect, int drawcount, int stride)
            where T1 : unmanaged
        {
            fixed (void* indirect_ptr = indirect)
            {
                MultiDrawArraysIndirectEXT(mode, indirect_ptr, drawcount, stride);
            }
        }
        /// <inheritdoc cref="MultiDrawArraysIndirectEXT(PrimitiveType, void*, int, int)"/>
        public static unsafe void MultiDrawArraysIndirectEXT<T1>(PrimitiveType mode, T1[] indirect, int drawcount, int stride)
            where T1 : unmanaged
        {
            fixed (void* indirect_ptr = indirect)
            {
                MultiDrawArraysIndirectEXT(mode, indirect_ptr, drawcount, stride);
            }
        }
        /// <inheritdoc cref="MultiDrawArraysIndirectEXT(PrimitiveType, void*, int, int)"/>
        public static unsafe void MultiDrawArraysIndirectEXT<T1>(PrimitiveType mode, ref readonly T1 indirect, int drawcount, int stride)
            where T1 : unmanaged
        {
            fixed (void* indirect_ptr = &indirect)
            {
                MultiDrawArraysIndirectEXT(mode, indirect_ptr, drawcount, stride);
            }
        }
        /// <inheritdoc cref="MultiDrawElementsBaseVertexEXT(PrimitiveType, int*, DrawElementsType, void**, int, int*)"/>
        public static unsafe void MultiDrawElementsBaseVertexEXT(PrimitiveType mode, ReadOnlySpan<int> count, DrawElementsType type, void** indices, int drawcount, ReadOnlySpan<int> basevertex)
        {
            fixed (int* basevertex_ptr = basevertex)
            {
                fixed (int* count_ptr = count)
                {
                    MultiDrawElementsBaseVertexEXT(mode, count_ptr, type, indices, drawcount, basevertex_ptr);
                }
            }
        }
        /// <inheritdoc cref="MultiDrawElementsBaseVertexEXT(PrimitiveType, int*, DrawElementsType, void**, int, int*)"/>
        public static unsafe void MultiDrawElementsBaseVertexEXT(PrimitiveType mode, int[] count, DrawElementsType type, void** indices, int drawcount, int[] basevertex)
        {
            fixed (int* basevertex_ptr = basevertex)
            {
                fixed (int* count_ptr = count)
                {
                    MultiDrawElementsBaseVertexEXT(mode, count_ptr, type, indices, drawcount, basevertex_ptr);
                }
            }
        }
        /// <inheritdoc cref="MultiDrawElementsBaseVertexEXT(PrimitiveType, int*, DrawElementsType, void**, int, int*)"/>
        public static unsafe void MultiDrawElementsBaseVertexEXT(PrimitiveType mode, ref readonly int count, DrawElementsType type, void** indices, int drawcount, ref readonly int basevertex)
        {
            fixed (int* count_ptr = &count)
            fixed (int* basevertex_ptr = &basevertex)
            {
                MultiDrawElementsBaseVertexEXT(mode, count_ptr, type, indices, drawcount, basevertex_ptr);
            }
        }
        /// <inheritdoc cref="MultiDrawElementsEXT(PrimitiveType, int*, DrawElementsType, void**, int)"/>
        public static unsafe void MultiDrawElementsEXT(PrimitiveType mode, ReadOnlySpan<int> count, DrawElementsType type, void** indices, int primcount)
        {
            fixed (int* count_ptr = count)
            {
                MultiDrawElementsEXT(mode, count_ptr, type, indices, primcount);
            }
        }
        /// <inheritdoc cref="MultiDrawElementsEXT(PrimitiveType, int*, DrawElementsType, void**, int)"/>
        public static unsafe void MultiDrawElementsEXT(PrimitiveType mode, int[] count, DrawElementsType type, void** indices, int primcount)
        {
            fixed (int* count_ptr = count)
            {
                MultiDrawElementsEXT(mode, count_ptr, type, indices, primcount);
            }
        }
        /// <inheritdoc cref="MultiDrawElementsEXT(PrimitiveType, int*, DrawElementsType, void**, int)"/>
        public static unsafe void MultiDrawElementsEXT(PrimitiveType mode, ref readonly int count, DrawElementsType type, void** indices, int primcount)
        {
            fixed (int* count_ptr = &count)
            {
                MultiDrawElementsEXT(mode, count_ptr, type, indices, primcount);
            }
        }
        /// <inheritdoc cref="MultiDrawElementsIndirectEXT(PrimitiveType, DrawElementsType, void*, int, int)"/>
        public static unsafe void MultiDrawElementsIndirectEXT(PrimitiveType mode, DrawElementsType type, IntPtr indirect, int drawcount, int stride)
        {
            void* indirect_vptr = (void*)indirect;
            MultiDrawElementsIndirectEXT(mode, type, indirect_vptr, drawcount, stride);
        }
        /// <inheritdoc cref="MultiDrawElementsIndirectEXT(PrimitiveType, DrawElementsType, void*, int, int)"/>
        public static unsafe void MultiDrawElementsIndirectEXT<T1>(PrimitiveType mode, DrawElementsType type, ReadOnlySpan<T1> indirect, int drawcount, int stride)
            where T1 : unmanaged
        {
            fixed (void* indirect_ptr = indirect)
            {
                MultiDrawElementsIndirectEXT(mode, type, indirect_ptr, drawcount, stride);
            }
        }
        /// <inheritdoc cref="MultiDrawElementsIndirectEXT(PrimitiveType, DrawElementsType, void*, int, int)"/>
        public static unsafe void MultiDrawElementsIndirectEXT<T1>(PrimitiveType mode, DrawElementsType type, T1[] indirect, int drawcount, int stride)
            where T1 : unmanaged
        {
            fixed (void* indirect_ptr = indirect)
            {
                MultiDrawElementsIndirectEXT(mode, type, indirect_ptr, drawcount, stride);
            }
        }
        /// <inheritdoc cref="MultiDrawElementsIndirectEXT(PrimitiveType, DrawElementsType, void*, int, int)"/>
        public static unsafe void MultiDrawElementsIndirectEXT<T1>(PrimitiveType mode, DrawElementsType type, ref readonly T1 indirect, int drawcount, int stride)
            where T1 : unmanaged
        {
            fixed (void* indirect_ptr = &indirect)
            {
                MultiDrawElementsIndirectEXT(mode, type, indirect_ptr, drawcount, stride);
            }
        }
        /// <inheritdoc cref="NamedBufferStorageExternalEXT(int, IntPtr, nint, void*, BufferStorageMask)"/>
        public static unsafe void NamedBufferStorageExternalEXT(int buffer, IntPtr offset, nint size, IntPtr clientBuffer, BufferStorageMask flags)
        {
            void* clientBuffer_vptr = (void*)clientBuffer;
            NamedBufferStorageExternalEXT(buffer, offset, size, clientBuffer_vptr, flags);
        }
        /// <inheritdoc cref="NamedBufferStorageExternalEXT(int, IntPtr, nint, void*, BufferStorageMask)"/>
        public static unsafe void NamedBufferStorageExternalEXT<T1>(int buffer, IntPtr offset, nint size, Span<T1> clientBuffer, BufferStorageMask flags)
            where T1 : unmanaged
        {
            fixed (void* clientBuffer_ptr = clientBuffer)
            {
                NamedBufferStorageExternalEXT(buffer, offset, size, clientBuffer_ptr, flags);
            }
        }
        /// <inheritdoc cref="NamedBufferStorageExternalEXT(int, IntPtr, nint, void*, BufferStorageMask)"/>
        public static unsafe void NamedBufferStorageExternalEXT<T1>(int buffer, IntPtr offset, nint size, T1[] clientBuffer, BufferStorageMask flags)
            where T1 : unmanaged
        {
            fixed (void* clientBuffer_ptr = clientBuffer)
            {
                NamedBufferStorageExternalEXT(buffer, offset, size, clientBuffer_ptr, flags);
            }
        }
        /// <inheritdoc cref="NamedBufferStorageExternalEXT(int, IntPtr, nint, void*, BufferStorageMask)"/>
        public static unsafe void NamedBufferStorageExternalEXT<T1>(int buffer, IntPtr offset, nint size, ref T1 clientBuffer, BufferStorageMask flags)
            where T1 : unmanaged
        {
            fixed (void* clientBuffer_ptr = &clientBuffer)
            {
                NamedBufferStorageExternalEXT(buffer, offset, size, clientBuffer_ptr, flags);
            }
        }
        /// <inheritdoc cref="ProgramUniform1fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform1fvEXT(int program, int location, int count, ref readonly float value)
        {
            fixed (float* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform1fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform1ivEXT(int, int, int, int*)"/>
        public static unsafe void ProgramUniform1ivEXT(int program, int location, int count, ref readonly int value)
        {
            fixed (int* tmp_value = &value)
            {
                int* value_ptr = (int*)tmp_value;
                ProgramUniform1ivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform1uivEXT(int, int, int, uint*)"/>
        public static unsafe void ProgramUniform1uivEXT(int program, int location, int count, ref readonly uint value)
        {
            fixed (uint* tmp_value = &value)
            {
                uint* value_ptr = (uint*)tmp_value;
                ProgramUniform1uivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform2fvEXT(int program, int location, int count, ref readonly Vector2 value)
        {
            fixed (Vector2* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform2fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform2fvEXT(int program, int location, int count, ReadOnlySpan<Vector2> value)
        {
            fixed (Vector2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform2fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform2fvEXT(int program, int location, int count, Vector2[] value)
        {
            fixed (Vector2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform2fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform2fvEXT(int program, int location, int count, ref readonly System.Numerics.Vector2 value)
        {
            fixed (System.Numerics.Vector2* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform2fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform2fvEXT(int program, int location, int count, ReadOnlySpan<System.Numerics.Vector2> value)
        {
            fixed (System.Numerics.Vector2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform2fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform2fvEXT(int program, int location, int count, System.Numerics.Vector2[] value)
        {
            fixed (System.Numerics.Vector2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform2fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2ivEXT(int, int, int, int*)"/>
        public static unsafe void ProgramUniform2ivEXT(int program, int location, int count, ref readonly Vector2i value)
        {
            fixed (Vector2i* tmp_value = &value)
            {
                int* value_ptr = (int*)tmp_value;
                ProgramUniform2ivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2ivEXT(int, int, int, int*)"/>
        public static unsafe void ProgramUniform2ivEXT(int program, int location, int count, ReadOnlySpan<Vector2i> value)
        {
            fixed (Vector2i* tmp_value = value)
            {
                int* value_ptr = (int*)tmp_value;
                ProgramUniform2ivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2ivEXT(int, int, int, int*)"/>
        public static unsafe void ProgramUniform2ivEXT(int program, int location, int count, Vector2i[] value)
        {
            fixed (Vector2i* tmp_value = value)
            {
                int* value_ptr = (int*)tmp_value;
                ProgramUniform2ivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2uivEXT(int, int, int, uint*)"/>
        public static unsafe void ProgramUniform2uivEXT(int program, int location, int count, ref readonly Vector2i value)
        {
            fixed (Vector2i* tmp_value = &value)
            {
                uint* value_ptr = (uint*)tmp_value;
                ProgramUniform2uivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2uivEXT(int, int, int, uint*)"/>
        public static unsafe void ProgramUniform2uivEXT(int program, int location, int count, ReadOnlySpan<Vector2i> value)
        {
            fixed (Vector2i* tmp_value = value)
            {
                uint* value_ptr = (uint*)tmp_value;
                ProgramUniform2uivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2uivEXT(int, int, int, uint*)"/>
        public static unsafe void ProgramUniform2uivEXT(int program, int location, int count, Vector2i[] value)
        {
            fixed (Vector2i* tmp_value = value)
            {
                uint* value_ptr = (uint*)tmp_value;
                ProgramUniform2uivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform3fvEXT(int program, int location, int count, ref readonly Vector3 value)
        {
            fixed (Vector3* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform3fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform3fvEXT(int program, int location, int count, ReadOnlySpan<Vector3> value)
        {
            fixed (Vector3* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform3fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform3fvEXT(int program, int location, int count, Vector3[] value)
        {
            fixed (Vector3* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform3fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform3fvEXT(int program, int location, int count, ref readonly System.Numerics.Vector3 value)
        {
            fixed (System.Numerics.Vector3* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform3fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform3fvEXT(int program, int location, int count, ReadOnlySpan<System.Numerics.Vector3> value)
        {
            fixed (System.Numerics.Vector3* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform3fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform3fvEXT(int program, int location, int count, System.Numerics.Vector3[] value)
        {
            fixed (System.Numerics.Vector3* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform3fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3ivEXT(int, int, int, int*)"/>
        public static unsafe void ProgramUniform3ivEXT(int program, int location, int count, ref readonly Vector3i value)
        {
            fixed (Vector3i* tmp_value = &value)
            {
                int* value_ptr = (int*)tmp_value;
                ProgramUniform3ivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3ivEXT(int, int, int, int*)"/>
        public static unsafe void ProgramUniform3ivEXT(int program, int location, int count, ReadOnlySpan<Vector3i> value)
        {
            fixed (Vector3i* tmp_value = value)
            {
                int* value_ptr = (int*)tmp_value;
                ProgramUniform3ivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3ivEXT(int, int, int, int*)"/>
        public static unsafe void ProgramUniform3ivEXT(int program, int location, int count, Vector3i[] value)
        {
            fixed (Vector3i* tmp_value = value)
            {
                int* value_ptr = (int*)tmp_value;
                ProgramUniform3ivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3uivEXT(int, int, int, uint*)"/>
        public static unsafe void ProgramUniform3uivEXT(int program, int location, int count, ref readonly Vector3i value)
        {
            fixed (Vector3i* tmp_value = &value)
            {
                uint* value_ptr = (uint*)tmp_value;
                ProgramUniform3uivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3uivEXT(int, int, int, uint*)"/>
        public static unsafe void ProgramUniform3uivEXT(int program, int location, int count, ReadOnlySpan<Vector3i> value)
        {
            fixed (Vector3i* tmp_value = value)
            {
                uint* value_ptr = (uint*)tmp_value;
                ProgramUniform3uivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3uivEXT(int, int, int, uint*)"/>
        public static unsafe void ProgramUniform3uivEXT(int program, int location, int count, Vector3i[] value)
        {
            fixed (Vector3i* tmp_value = value)
            {
                uint* value_ptr = (uint*)tmp_value;
                ProgramUniform3uivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform4fvEXT(int program, int location, int count, ref readonly Vector4 value)
        {
            fixed (Vector4* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform4fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform4fvEXT(int program, int location, int count, ReadOnlySpan<Vector4> value)
        {
            fixed (Vector4* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform4fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform4fvEXT(int program, int location, int count, Vector4[] value)
        {
            fixed (Vector4* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform4fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform4fvEXT(int program, int location, int count, ref readonly System.Numerics.Vector4 value)
        {
            fixed (System.Numerics.Vector4* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform4fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform4fvEXT(int program, int location, int count, ReadOnlySpan<System.Numerics.Vector4> value)
        {
            fixed (System.Numerics.Vector4* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform4fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4fvEXT(int, int, int, float*)"/>
        public static unsafe void ProgramUniform4fvEXT(int program, int location, int count, System.Numerics.Vector4[] value)
        {
            fixed (System.Numerics.Vector4* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniform4fvEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4ivEXT(int, int, int, int*)"/>
        public static unsafe void ProgramUniform4ivEXT(int program, int location, int count, ref readonly Vector4i value)
        {
            fixed (Vector4i* tmp_value = &value)
            {
                int* value_ptr = (int*)tmp_value;
                ProgramUniform4ivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4ivEXT(int, int, int, int*)"/>
        public static unsafe void ProgramUniform4ivEXT(int program, int location, int count, ReadOnlySpan<Vector4i> value)
        {
            fixed (Vector4i* tmp_value = value)
            {
                int* value_ptr = (int*)tmp_value;
                ProgramUniform4ivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4ivEXT(int, int, int, int*)"/>
        public static unsafe void ProgramUniform4ivEXT(int program, int location, int count, Vector4i[] value)
        {
            fixed (Vector4i* tmp_value = value)
            {
                int* value_ptr = (int*)tmp_value;
                ProgramUniform4ivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4uivEXT(int, int, int, uint*)"/>
        public static unsafe void ProgramUniform4uivEXT(int program, int location, int count, ref readonly Vector4i value)
        {
            fixed (Vector4i* tmp_value = &value)
            {
                uint* value_ptr = (uint*)tmp_value;
                ProgramUniform4uivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4uivEXT(int, int, int, uint*)"/>
        public static unsafe void ProgramUniform4uivEXT(int program, int location, int count, ReadOnlySpan<Vector4i> value)
        {
            fixed (Vector4i* tmp_value = value)
            {
                uint* value_ptr = (uint*)tmp_value;
                ProgramUniform4uivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4uivEXT(int, int, int, uint*)"/>
        public static unsafe void ProgramUniform4uivEXT(int program, int location, int count, Vector4i[] value)
        {
            fixed (Vector4i* tmp_value = value)
            {
                uint* value_ptr = (uint*)tmp_value;
                ProgramUniform4uivEXT(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix2fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix2fvEXT(int program, int location, int count, bool transpose, ref readonly Matrix2 value)
        {
            fixed (Matrix2* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix2fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix2fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix2fvEXT(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix2> value)
        {
            fixed (Matrix2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix2fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix2fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix2fvEXT(int program, int location, int count, bool transpose, Matrix2[] value)
        {
            fixed (Matrix2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix2fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix2x3fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix2x3fvEXT(int program, int location, int count, bool transpose, ref readonly Matrix2x3 value)
        {
            fixed (Matrix2x3* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix2x3fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix2x3fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix2x3fvEXT(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix2x3> value)
        {
            fixed (Matrix2x3* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix2x3fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix2x3fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix2x3fvEXT(int program, int location, int count, bool transpose, Matrix2x3[] value)
        {
            fixed (Matrix2x3* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix2x3fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix2x4fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix2x4fvEXT(int program, int location, int count, bool transpose, ref readonly Matrix2x4 value)
        {
            fixed (Matrix2x4* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix2x4fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix2x4fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix2x4fvEXT(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix2x4> value)
        {
            fixed (Matrix2x4* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix2x4fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix2x4fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix2x4fvEXT(int program, int location, int count, bool transpose, Matrix2x4[] value)
        {
            fixed (Matrix2x4* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix2x4fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix3fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix3fvEXT(int program, int location, int count, bool transpose, ref readonly Matrix3 value)
        {
            fixed (Matrix3* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix3fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix3fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix3fvEXT(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix3> value)
        {
            fixed (Matrix3* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix3fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix3fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix3fvEXT(int program, int location, int count, bool transpose, Matrix3[] value)
        {
            fixed (Matrix3* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix3fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix3x2fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix3x2fvEXT(int program, int location, int count, bool transpose, ref readonly Matrix3x2 value)
        {
            fixed (Matrix3x2* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix3x2fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix3x2fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix3x2fvEXT(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix3x2> value)
        {
            fixed (Matrix3x2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix3x2fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix3x2fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix3x2fvEXT(int program, int location, int count, bool transpose, Matrix3x2[] value)
        {
            fixed (Matrix3x2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix3x2fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix3x2fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix3x2fvEXT(int program, int location, int count, bool transpose, ref readonly System.Numerics.Matrix3x2 value)
        {
            fixed (System.Numerics.Matrix3x2* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix3x2fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix3x2fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix3x2fvEXT(int program, int location, int count, bool transpose, ReadOnlySpan<System.Numerics.Matrix3x2> value)
        {
            fixed (System.Numerics.Matrix3x2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix3x2fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix3x2fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix3x2fvEXT(int program, int location, int count, bool transpose, System.Numerics.Matrix3x2[] value)
        {
            fixed (System.Numerics.Matrix3x2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix3x2fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix3x4fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix3x4fvEXT(int program, int location, int count, bool transpose, ref readonly Matrix3x4 value)
        {
            fixed (Matrix3x4* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix3x4fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix3x4fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix3x4fvEXT(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix3x4> value)
        {
            fixed (Matrix3x4* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix3x4fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix3x4fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix3x4fvEXT(int program, int location, int count, bool transpose, Matrix3x4[] value)
        {
            fixed (Matrix3x4* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix3x4fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix4fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix4fvEXT(int program, int location, int count, bool transpose, ref readonly Matrix4 value)
        {
            fixed (Matrix4* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix4fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix4fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix4fvEXT(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix4> value)
        {
            fixed (Matrix4* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix4fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix4fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix4fvEXT(int program, int location, int count, bool transpose, Matrix4[] value)
        {
            fixed (Matrix4* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix4fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix4fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix4fvEXT(int program, int location, int count, bool transpose, ref readonly System.Numerics.Matrix4x4 value)
        {
            fixed (System.Numerics.Matrix4x4* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix4fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix4fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix4fvEXT(int program, int location, int count, bool transpose, ReadOnlySpan<System.Numerics.Matrix4x4> value)
        {
            fixed (System.Numerics.Matrix4x4* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix4fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix4fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix4fvEXT(int program, int location, int count, bool transpose, System.Numerics.Matrix4x4[] value)
        {
            fixed (System.Numerics.Matrix4x4* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix4fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix4x2fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix4x2fvEXT(int program, int location, int count, bool transpose, ref readonly Matrix4x2 value)
        {
            fixed (Matrix4x2* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix4x2fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix4x2fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix4x2fvEXT(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix4x2> value)
        {
            fixed (Matrix4x2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix4x2fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix4x2fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix4x2fvEXT(int program, int location, int count, bool transpose, Matrix4x2[] value)
        {
            fixed (Matrix4x2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix4x2fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix4x3fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix4x3fvEXT(int program, int location, int count, bool transpose, ref readonly Matrix4x3 value)
        {
            fixed (Matrix4x3* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix4x3fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix4x3fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix4x3fvEXT(int program, int location, int count, bool transpose, ReadOnlySpan<Matrix4x3> value)
        {
            fixed (Matrix4x3* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix4x3fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformMatrix4x3fvEXT(int, int, int, bool, float*)"/>
        public static unsafe void ProgramUniformMatrix4x3fvEXT(int program, int location, int count, bool transpose, Matrix4x3[] value)
        {
            fixed (Matrix4x3* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                ProgramUniformMatrix4x3fvEXT(program, location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="PushGroupMarkerEXT(int, byte*)"/>
        public static unsafe void PushGroupMarkerEXT(int length, string marker)
        {
            byte* marker_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(marker);
            PushGroupMarkerEXT(length, marker_ptr);
            Marshal.FreeCoTaskMem((IntPtr)marker_ptr);
        }
        /// <inheritdoc cref="ReadnPixelsEXT(int, int, int, int, PixelFormat, PixelType, int, void*)"/>
        public static unsafe void ReadnPixelsEXT(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, IntPtr data)
        {
            void* data_vptr = (void*)data;
            ReadnPixelsEXT(x, y, width, height, format, type, bufSize, data_vptr);
        }
        /// <inheritdoc cref="ReadnPixelsEXT(int, int, int, int, PixelFormat, PixelType, int, void*)"/>
        public static unsafe void ReadnPixelsEXT<T1>(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, Span<T1> data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                ReadnPixelsEXT(x, y, width, height, format, type, bufSize, data_ptr);
            }
        }
        /// <inheritdoc cref="ReadnPixelsEXT(int, int, int, int, PixelFormat, PixelType, int, void*)"/>
        public static unsafe void ReadnPixelsEXT<T1>(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, T1[] data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                ReadnPixelsEXT(x, y, width, height, format, type, bufSize, data_ptr);
            }
        }
        /// <inheritdoc cref="ReadnPixelsEXT(int, int, int, int, PixelFormat, PixelType, int, void*)"/>
        public static unsafe void ReadnPixelsEXT<T1>(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, ref T1 data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = &data)
            {
                ReadnPixelsEXT(x, y, width, height, format, type, bufSize, data_ptr);
            }
        }
        /// <inheritdoc cref="SamplerParameterIivEXT(int, SamplerParameterI, int*)"/>
        public static unsafe void SamplerParameterIivEXT(int sampler, SamplerParameterI pname, ReadOnlySpan<int> param)
        {
            fixed (int* param_ptr = param)
            {
                SamplerParameterIivEXT(sampler, pname, param_ptr);
            }
        }
        /// <inheritdoc cref="SamplerParameterIivEXT(int, SamplerParameterI, int*)"/>
        public static unsafe void SamplerParameterIivEXT(int sampler, SamplerParameterI pname, int[] param)
        {
            fixed (int* param_ptr = param)
            {
                SamplerParameterIivEXT(sampler, pname, param_ptr);
            }
        }
        /// <inheritdoc cref="SamplerParameterIivEXT(int, SamplerParameterI, int*)"/>
        public static unsafe void SamplerParameterIivEXT(int sampler, SamplerParameterI pname, ref readonly int param)
        {
            fixed (int* param_ptr = &param)
            {
                SamplerParameterIivEXT(sampler, pname, param_ptr);
            }
        }
        /// <inheritdoc cref="SamplerParameterIuivEXT(int, SamplerParameterI, uint*)"/>
        public static unsafe void SamplerParameterIuivEXT(int sampler, SamplerParameterI pname, ReadOnlySpan<uint> param)
        {
            fixed (uint* param_ptr = param)
            {
                SamplerParameterIuivEXT(sampler, pname, param_ptr);
            }
        }
        /// <inheritdoc cref="SamplerParameterIuivEXT(int, SamplerParameterI, uint*)"/>
        public static unsafe void SamplerParameterIuivEXT(int sampler, SamplerParameterI pname, uint[] param)
        {
            fixed (uint* param_ptr = param)
            {
                SamplerParameterIuivEXT(sampler, pname, param_ptr);
            }
        }
        /// <inheritdoc cref="SamplerParameterIuivEXT(int, SamplerParameterI, uint*)"/>
        public static unsafe void SamplerParameterIuivEXT(int sampler, SamplerParameterI pname, ref readonly uint param)
        {
            fixed (uint* param_ptr = &param)
            {
                SamplerParameterIuivEXT(sampler, pname, param_ptr);
            }
        }
        /// <inheritdoc cref="SemaphoreParameterui64vEXT(uint, SemaphoreParameterName, ulong*)"/>
        public static unsafe void SemaphoreParameterui64vEXT(uint semaphore, SemaphoreParameterName pname, ReadOnlySpan<ulong> parameters)
        {
            fixed (ulong* parameters_ptr = parameters)
            {
                SemaphoreParameterui64vEXT(semaphore, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="SemaphoreParameterui64vEXT(uint, SemaphoreParameterName, ulong*)"/>
        public static unsafe void SemaphoreParameterui64vEXT(uint semaphore, SemaphoreParameterName pname, ulong[] parameters)
        {
            fixed (ulong* parameters_ptr = parameters)
            {
                SemaphoreParameterui64vEXT(semaphore, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="SemaphoreParameterui64vEXT(uint, SemaphoreParameterName, ulong*)"/>
        public static unsafe void SemaphoreParameterui64vEXT(uint semaphore, SemaphoreParameterName pname, ref readonly ulong parameters)
        {
            fixed (ulong* parameters_ptr = &parameters)
            {
                SemaphoreParameterui64vEXT(semaphore, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="SignalSemaphoreEXT(uint, uint, int*, uint, int*, TextureLayout*)"/>
        public static unsafe void SignalSemaphoreEXT(uint semaphore, uint numBufferBarriers, ReadOnlySpan<int> buffers, uint numTextureBarriers, ReadOnlySpan<int> textures, ReadOnlySpan<TextureLayout> dstLayouts)
        {
            fixed (TextureLayout* dstLayouts_ptr = dstLayouts)
            {
                fixed (int* textures_ptr = textures)
                {
                    fixed (int* buffers_ptr = buffers)
                    {
                        SignalSemaphoreEXT(semaphore, numBufferBarriers, buffers_ptr, numTextureBarriers, textures_ptr, dstLayouts_ptr);
                    }
                }
            }
        }
        /// <inheritdoc cref="SignalSemaphoreEXT(uint, uint, int*, uint, int*, TextureLayout*)"/>
        public static unsafe void SignalSemaphoreEXT(uint semaphore, uint numBufferBarriers, int[] buffers, uint numTextureBarriers, int[] textures, TextureLayout[] dstLayouts)
        {
            fixed (TextureLayout* dstLayouts_ptr = dstLayouts)
            {
                fixed (int* textures_ptr = textures)
                {
                    fixed (int* buffers_ptr = buffers)
                    {
                        SignalSemaphoreEXT(semaphore, numBufferBarriers, buffers_ptr, numTextureBarriers, textures_ptr, dstLayouts_ptr);
                    }
                }
            }
        }
        /// <inheritdoc cref="SignalSemaphoreEXT(uint, uint, int*, uint, int*, TextureLayout*)"/>
        public static unsafe void SignalSemaphoreEXT(uint semaphore, uint numBufferBarriers, ref readonly int buffers, uint numTextureBarriers, ref readonly int textures, ref readonly TextureLayout dstLayouts)
        {
            fixed (int* buffers_ptr = &buffers)
            fixed (int* textures_ptr = &textures)
            fixed (TextureLayout* dstLayouts_ptr = &dstLayouts)
            {
                SignalSemaphoreEXT(semaphore, numBufferBarriers, buffers_ptr, numTextureBarriers, textures_ptr, dstLayouts_ptr);
            }
        }
        /// <inheritdoc cref="TexParameterIivEXT(TextureTarget, TextureParameterName, int*)"/>
        public static unsafe void TexParameterIivEXT(TextureTarget target, TextureParameterName pname, ReadOnlySpan<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                TexParameterIivEXT(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="TexParameterIivEXT(TextureTarget, TextureParameterName, int*)"/>
        public static unsafe void TexParameterIivEXT(TextureTarget target, TextureParameterName pname, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                TexParameterIivEXT(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="TexParameterIivEXT(TextureTarget, TextureParameterName, int*)"/>
        public static unsafe void TexParameterIivEXT(TextureTarget target, TextureParameterName pname, ref readonly int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                TexParameterIivEXT(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="TexParameterIuivEXT(TextureTarget, TextureParameterName, uint*)"/>
        public static unsafe void TexParameterIuivEXT(TextureTarget target, TextureParameterName pname, ReadOnlySpan<uint> parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                TexParameterIuivEXT(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="TexParameterIuivEXT(TextureTarget, TextureParameterName, uint*)"/>
        public static unsafe void TexParameterIuivEXT(TextureTarget target, TextureParameterName pname, uint[] parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                TexParameterIuivEXT(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="TexParameterIuivEXT(TextureTarget, TextureParameterName, uint*)"/>
        public static unsafe void TexParameterIuivEXT(TextureTarget target, TextureParameterName pname, ref readonly uint parameters)
        {
            fixed (uint* parameters_ptr = &parameters)
            {
                TexParameterIuivEXT(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="TexStorageAttribs2DEXT(TextureTarget, int, SizedInternalFormat, int, int, TexStorageAttribs*)"/>
        public static unsafe void TexStorageAttribs2DEXT(TextureTarget target, int levels, SizedInternalFormat internalformat, int width, int height, ReadOnlySpan<TexStorageAttribs> attrib_list)
        {
            fixed (TexStorageAttribs* attrib_list_ptr = attrib_list)
            {
                TexStorageAttribs2DEXT(target, levels, internalformat, width, height, attrib_list_ptr);
            }
        }
        /// <inheritdoc cref="TexStorageAttribs2DEXT(TextureTarget, int, SizedInternalFormat, int, int, TexStorageAttribs*)"/>
        public static unsafe void TexStorageAttribs2DEXT(TextureTarget target, int levels, SizedInternalFormat internalformat, int width, int height, TexStorageAttribs[] attrib_list)
        {
            fixed (TexStorageAttribs* attrib_list_ptr = attrib_list)
            {
                TexStorageAttribs2DEXT(target, levels, internalformat, width, height, attrib_list_ptr);
            }
        }
        /// <inheritdoc cref="TexStorageAttribs2DEXT(TextureTarget, int, SizedInternalFormat, int, int, TexStorageAttribs*)"/>
        public static unsafe void TexStorageAttribs2DEXT(TextureTarget target, int levels, SizedInternalFormat internalformat, int width, int height, ref readonly TexStorageAttribs attrib_list)
        {
            fixed (TexStorageAttribs* attrib_list_ptr = &attrib_list)
            {
                TexStorageAttribs2DEXT(target, levels, internalformat, width, height, attrib_list_ptr);
            }
        }
        /// <inheritdoc cref="TexStorageAttribs3DEXT(TextureTarget, int, SizedInternalFormat, int, int, int, TexStorageAttribs*)"/>
        public static unsafe void TexStorageAttribs3DEXT(TextureTarget target, int levels, SizedInternalFormat internalformat, int width, int height, int depth, ReadOnlySpan<TexStorageAttribs> attrib_list)
        {
            fixed (TexStorageAttribs* attrib_list_ptr = attrib_list)
            {
                TexStorageAttribs3DEXT(target, levels, internalformat, width, height, depth, attrib_list_ptr);
            }
        }
        /// <inheritdoc cref="TexStorageAttribs3DEXT(TextureTarget, int, SizedInternalFormat, int, int, int, TexStorageAttribs*)"/>
        public static unsafe void TexStorageAttribs3DEXT(TextureTarget target, int levels, SizedInternalFormat internalformat, int width, int height, int depth, TexStorageAttribs[] attrib_list)
        {
            fixed (TexStorageAttribs* attrib_list_ptr = attrib_list)
            {
                TexStorageAttribs3DEXT(target, levels, internalformat, width, height, depth, attrib_list_ptr);
            }
        }
        /// <inheritdoc cref="TexStorageAttribs3DEXT(TextureTarget, int, SizedInternalFormat, int, int, int, TexStorageAttribs*)"/>
        public static unsafe void TexStorageAttribs3DEXT(TextureTarget target, int levels, SizedInternalFormat internalformat, int width, int height, int depth, ref readonly TexStorageAttribs attrib_list)
        {
            fixed (TexStorageAttribs* attrib_list_ptr = &attrib_list)
            {
                TexStorageAttribs3DEXT(target, levels, internalformat, width, height, depth, attrib_list_ptr);
            }
        }
        /// <inheritdoc cref="WaitSemaphoreEXT(uint, uint, int*, uint, int*, TextureLayout*)"/>
        public static unsafe void WaitSemaphoreEXT(uint semaphore, uint numBufferBarriers, ReadOnlySpan<int> buffers, uint numTextureBarriers, ReadOnlySpan<int> textures, ReadOnlySpan<TextureLayout> srcLayouts)
        {
            fixed (TextureLayout* srcLayouts_ptr = srcLayouts)
            {
                fixed (int* textures_ptr = textures)
                {
                    fixed (int* buffers_ptr = buffers)
                    {
                        WaitSemaphoreEXT(semaphore, numBufferBarriers, buffers_ptr, numTextureBarriers, textures_ptr, srcLayouts_ptr);
                    }
                }
            }
        }
        /// <inheritdoc cref="WaitSemaphoreEXT(uint, uint, int*, uint, int*, TextureLayout*)"/>
        public static unsafe void WaitSemaphoreEXT(uint semaphore, uint numBufferBarriers, int[] buffers, uint numTextureBarriers, int[] textures, TextureLayout[] srcLayouts)
        {
            fixed (TextureLayout* srcLayouts_ptr = srcLayouts)
            {
                fixed (int* textures_ptr = textures)
                {
                    fixed (int* buffers_ptr = buffers)
                    {
                        WaitSemaphoreEXT(semaphore, numBufferBarriers, buffers_ptr, numTextureBarriers, textures_ptr, srcLayouts_ptr);
                    }
                }
            }
        }
        /// <inheritdoc cref="WaitSemaphoreEXT(uint, uint, int*, uint, int*, TextureLayout*)"/>
        public static unsafe void WaitSemaphoreEXT(uint semaphore, uint numBufferBarriers, ref readonly int buffers, uint numTextureBarriers, ref readonly int textures, ref readonly TextureLayout srcLayouts)
        {
            fixed (int* buffers_ptr = &buffers)
            fixed (int* textures_ptr = &textures)
            fixed (TextureLayout* srcLayouts_ptr = &srcLayouts)
            {
                WaitSemaphoreEXT(semaphore, numBufferBarriers, buffers_ptr, numTextureBarriers, textures_ptr, srcLayouts_ptr);
            }
        }
        /// <inheritdoc cref="WindowRectanglesEXT(All, int, int*)"/>
        public static unsafe void WindowRectanglesEXT(All mode, int count, ReadOnlySpan<int> box)
        {
            fixed (int* box_ptr = box)
            {
                WindowRectanglesEXT(mode, count, box_ptr);
            }
        }
        /// <inheritdoc cref="WindowRectanglesEXT(All, int, int*)"/>
        public static unsafe void WindowRectanglesEXT(All mode, int count, int[] box)
        {
            fixed (int* box_ptr = box)
            {
                WindowRectanglesEXT(mode, count, box_ptr);
            }
        }
        /// <inheritdoc cref="WindowRectanglesEXT(All, int, int*)"/>
        public static unsafe void WindowRectanglesEXT(All mode, int count, ref readonly int box)
        {
            fixed (int* box_ptr = &box)
            {
                WindowRectanglesEXT(mode, count, box_ptr);
            }
        }
    }
    public static unsafe partial class IMG
    {
        /// <inheritdoc cref="ProgramUniformHandleui64vIMG(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniformHandleui64vIMG(int program, int location, int count, ReadOnlySpan<ulong> values)
        {
            fixed (ulong* values_ptr = values)
            {
                ProgramUniformHandleui64vIMG(program, location, count, values_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformHandleui64vIMG(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniformHandleui64vIMG(int program, int location, int count, ulong[] values)
        {
            fixed (ulong* values_ptr = values)
            {
                ProgramUniformHandleui64vIMG(program, location, count, values_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformHandleui64vIMG(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniformHandleui64vIMG(int program, int location, int count, ref readonly ulong values)
        {
            fixed (ulong* values_ptr = &values)
            {
                ProgramUniformHandleui64vIMG(program, location, count, values_ptr);
            }
        }
        /// <inheritdoc cref="UniformHandleui64vIMG(int, int, ulong*)"/>
        public static unsafe void UniformHandleui64vIMG(int location, int count, ReadOnlySpan<ulong> value)
        {
            fixed (ulong* value_ptr = value)
            {
                UniformHandleui64vIMG(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformHandleui64vIMG(int, int, ulong*)"/>
        public static unsafe void UniformHandleui64vIMG(int location, int count, ulong[] value)
        {
            fixed (ulong* value_ptr = value)
            {
                UniformHandleui64vIMG(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformHandleui64vIMG(int, int, ulong*)"/>
        public static unsafe void UniformHandleui64vIMG(int location, int count, ref readonly ulong value)
        {
            fixed (ulong* value_ptr = &value)
            {
                UniformHandleui64vIMG(location, count, value_ptr);
            }
        }
    }
    public static unsafe partial class INTEL
    {
        /// <inheritdoc cref="CreatePerfQueryINTEL(uint, int*)"/>
        public static unsafe void CreatePerfQueryINTEL(uint queryId, Span<int> queryHandle)
        {
            fixed (int* queryHandle_ptr = queryHandle)
            {
                CreatePerfQueryINTEL(queryId, queryHandle_ptr);
            }
        }
        /// <inheritdoc cref="CreatePerfQueryINTEL(uint, int*)"/>
        public static unsafe void CreatePerfQueryINTEL(uint queryId, int[] queryHandle)
        {
            fixed (int* queryHandle_ptr = queryHandle)
            {
                CreatePerfQueryINTEL(queryId, queryHandle_ptr);
            }
        }
        /// <inheritdoc cref="CreatePerfQueryINTEL(uint, int*)"/>
        public static unsafe void CreatePerfQueryINTEL(uint queryId, ref int queryHandle)
        {
            fixed (int* queryHandle_ptr = &queryHandle)
            {
                CreatePerfQueryINTEL(queryId, queryHandle_ptr);
            }
        }
        /// <inheritdoc cref="GetFirstPerfQueryIdINTEL(uint*)"/>
        public static unsafe void GetFirstPerfQueryIdINTEL(Span<uint> queryId)
        {
            fixed (uint* queryId_ptr = queryId)
            {
                GetFirstPerfQueryIdINTEL(queryId_ptr);
            }
        }
        /// <inheritdoc cref="GetFirstPerfQueryIdINTEL(uint*)"/>
        public static unsafe void GetFirstPerfQueryIdINTEL(uint[] queryId)
        {
            fixed (uint* queryId_ptr = queryId)
            {
                GetFirstPerfQueryIdINTEL(queryId_ptr);
            }
        }
        /// <inheritdoc cref="GetFirstPerfQueryIdINTEL(uint*)"/>
        public static unsafe void GetFirstPerfQueryIdINTEL(ref uint queryId)
        {
            fixed (uint* queryId_ptr = &queryId)
            {
                GetFirstPerfQueryIdINTEL(queryId_ptr);
            }
        }
        /// <inheritdoc cref="GetNextPerfQueryIdINTEL(uint, uint*)"/>
        public static unsafe void GetNextPerfQueryIdINTEL(uint queryId, Span<uint> nextQueryId)
        {
            fixed (uint* nextQueryId_ptr = nextQueryId)
            {
                GetNextPerfQueryIdINTEL(queryId, nextQueryId_ptr);
            }
        }
        /// <inheritdoc cref="GetNextPerfQueryIdINTEL(uint, uint*)"/>
        public static unsafe void GetNextPerfQueryIdINTEL(uint queryId, uint[] nextQueryId)
        {
            fixed (uint* nextQueryId_ptr = nextQueryId)
            {
                GetNextPerfQueryIdINTEL(queryId, nextQueryId_ptr);
            }
        }
        /// <inheritdoc cref="GetNextPerfQueryIdINTEL(uint, uint*)"/>
        public static unsafe void GetNextPerfQueryIdINTEL(uint queryId, ref uint nextQueryId)
        {
            fixed (uint* nextQueryId_ptr = &nextQueryId)
            {
                GetNextPerfQueryIdINTEL(queryId, nextQueryId_ptr);
            }
        }
        /// <inheritdoc cref="GetPerfCounterInfoINTEL(uint, uint, uint, byte*, uint, byte*, uint*, uint*, uint*, uint*, ulong*)"/>
        public static unsafe void GetPerfCounterInfoINTEL(uint queryId, uint counterId, uint counterNameLength, out string counterName, uint counterDescLength, out string counterDesc, Span<uint> counterOffset, Span<uint> counterDataSize, Span<uint> counterTypeEnum, Span<uint> counterDataTypeEnum, Span<ulong> rawCounterMaxValue)
        {
            fixed (ulong* rawCounterMaxValue_ptr = rawCounterMaxValue)
            {
                fixed (uint* counterDataTypeEnum_ptr = counterDataTypeEnum)
                {
                    fixed (uint* counterTypeEnum_ptr = counterTypeEnum)
                    {
                        fixed (uint* counterDataSize_ptr = counterDataSize)
                        {
                            fixed (uint* counterOffset_ptr = counterOffset)
                            {
                                var counterName_ptr = (byte*)Marshal.AllocCoTaskMem((int)counterNameLength);
                                var counterDesc_ptr = (byte*)Marshal.AllocCoTaskMem((int)counterDescLength);
                                GetPerfCounterInfoINTEL(queryId, counterId, counterNameLength, counterName_ptr, counterDescLength, counterDesc_ptr, counterOffset_ptr, counterDataSize_ptr, counterTypeEnum_ptr, counterDataTypeEnum_ptr, rawCounterMaxValue_ptr);
                                counterDesc = Marshal.PtrToStringUTF8((IntPtr)counterDesc_ptr)!;
                                Marshal.FreeCoTaskMem((IntPtr)counterDesc_ptr);
                                counterName = Marshal.PtrToStringUTF8((IntPtr)counterName_ptr)!;
                                Marshal.FreeCoTaskMem((IntPtr)counterName_ptr);
                            }
                        }
                    }
                }
            }
        }
        /// <inheritdoc cref="GetPerfCounterInfoINTEL(uint, uint, uint, byte*, uint, byte*, uint*, uint*, uint*, uint*, ulong*)"/>
        public static unsafe void GetPerfCounterInfoINTEL(uint queryId, uint counterId, uint counterNameLength, out string counterName, uint counterDescLength, out string counterDesc, uint[] counterOffset, uint[] counterDataSize, uint[] counterTypeEnum, uint[] counterDataTypeEnum, ulong[] rawCounterMaxValue)
        {
            fixed (ulong* rawCounterMaxValue_ptr = rawCounterMaxValue)
            {
                fixed (uint* counterDataTypeEnum_ptr = counterDataTypeEnum)
                {
                    fixed (uint* counterTypeEnum_ptr = counterTypeEnum)
                    {
                        fixed (uint* counterDataSize_ptr = counterDataSize)
                        {
                            fixed (uint* counterOffset_ptr = counterOffset)
                            {
                                var counterName_ptr = (byte*)Marshal.AllocCoTaskMem((int)counterNameLength);
                                var counterDesc_ptr = (byte*)Marshal.AllocCoTaskMem((int)counterDescLength);
                                GetPerfCounterInfoINTEL(queryId, counterId, counterNameLength, counterName_ptr, counterDescLength, counterDesc_ptr, counterOffset_ptr, counterDataSize_ptr, counterTypeEnum_ptr, counterDataTypeEnum_ptr, rawCounterMaxValue_ptr);
                                counterDesc = Marshal.PtrToStringUTF8((IntPtr)counterDesc_ptr)!;
                                Marshal.FreeCoTaskMem((IntPtr)counterDesc_ptr);
                                counterName = Marshal.PtrToStringUTF8((IntPtr)counterName_ptr)!;
                                Marshal.FreeCoTaskMem((IntPtr)counterName_ptr);
                            }
                        }
                    }
                }
            }
        }
        /// <inheritdoc cref="GetPerfCounterInfoINTEL(uint, uint, uint, byte*, uint, byte*, uint*, uint*, uint*, uint*, ulong*)"/>
        public static unsafe void GetPerfCounterInfoINTEL(uint queryId, uint counterId, uint counterNameLength, out string counterName, uint counterDescLength, out string counterDesc, ref uint counterOffset, ref uint counterDataSize, ref uint counterTypeEnum, ref uint counterDataTypeEnum, ref ulong rawCounterMaxValue)
        {
            fixed (uint* counterOffset_ptr = &counterOffset)
            fixed (uint* counterDataSize_ptr = &counterDataSize)
            fixed (uint* counterTypeEnum_ptr = &counterTypeEnum)
            fixed (uint* counterDataTypeEnum_ptr = &counterDataTypeEnum)
            fixed (ulong* rawCounterMaxValue_ptr = &rawCounterMaxValue)
            {
                var counterName_ptr = (byte*)Marshal.AllocCoTaskMem((int)counterNameLength);
                var counterDesc_ptr = (byte*)Marshal.AllocCoTaskMem((int)counterDescLength);
                GetPerfCounterInfoINTEL(queryId, counterId, counterNameLength, counterName_ptr, counterDescLength, counterDesc_ptr, counterOffset_ptr, counterDataSize_ptr, counterTypeEnum_ptr, counterDataTypeEnum_ptr, rawCounterMaxValue_ptr);
                counterDesc = Marshal.PtrToStringUTF8((IntPtr)counterDesc_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)counterDesc_ptr);
                counterName = Marshal.PtrToStringUTF8((IntPtr)counterName_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)counterName_ptr);
            }
        }
        /// <inheritdoc cref="GetPerfQueryDataINTEL(int, PerfQueryDataFlags, int, void*, uint*)"/>
        public static unsafe void GetPerfQueryDataINTEL(int queryHandle, PerfQueryDataFlags flags, int dataSize, IntPtr data, Span<uint> bytesWritten)
        {
            fixed (uint* bytesWritten_ptr = bytesWritten)
            {
                void* data_vptr = (void*)data;
                GetPerfQueryDataINTEL(queryHandle, flags, dataSize, data_vptr, bytesWritten_ptr);
            }
        }
        /// <inheritdoc cref="GetPerfQueryDataINTEL(int, PerfQueryDataFlags, int, void*, uint*)"/>
        public static unsafe void GetPerfQueryDataINTEL(int queryHandle, PerfQueryDataFlags flags, int dataSize, IntPtr data, uint[] bytesWritten)
        {
            fixed (uint* bytesWritten_ptr = bytesWritten)
            {
                void* data_vptr = (void*)data;
                GetPerfQueryDataINTEL(queryHandle, flags, dataSize, data_vptr, bytesWritten_ptr);
            }
        }
        /// <inheritdoc cref="GetPerfQueryDataINTEL(int, PerfQueryDataFlags, int, void*, uint*)"/>
        public static unsafe void GetPerfQueryDataINTEL(int queryHandle, PerfQueryDataFlags flags, int dataSize, IntPtr data, ref uint bytesWritten)
        {
            fixed (uint* bytesWritten_ptr = &bytesWritten)
            {
                void* data_vptr = (void*)data;
                GetPerfQueryDataINTEL(queryHandle, flags, dataSize, data_vptr, bytesWritten_ptr);
            }
        }
        /// <inheritdoc cref="GetPerfQueryDataINTEL(int, PerfQueryDataFlags, int, void*, uint*)"/>
        public static unsafe void GetPerfQueryDataINTEL<T1>(int queryHandle, PerfQueryDataFlags flags, int dataSize, Span<T1> data, Span<uint> bytesWritten)
            where T1 : unmanaged
        {
            fixed (uint* bytesWritten_ptr = bytesWritten)
            {
                fixed (void* data_ptr = data)
                {
                    GetPerfQueryDataINTEL(queryHandle, flags, dataSize, data_ptr, bytesWritten_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetPerfQueryDataINTEL(int, PerfQueryDataFlags, int, void*, uint*)"/>
        public static unsafe void GetPerfQueryDataINTEL<T1>(int queryHandle, PerfQueryDataFlags flags, int dataSize, T1[] data, uint[] bytesWritten)
            where T1 : unmanaged
        {
            fixed (uint* bytesWritten_ptr = bytesWritten)
            {
                fixed (void* data_ptr = data)
                {
                    GetPerfQueryDataINTEL(queryHandle, flags, dataSize, data_ptr, bytesWritten_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetPerfQueryDataINTEL(int, PerfQueryDataFlags, int, void*, uint*)"/>
        public static unsafe void GetPerfQueryDataINTEL<T1>(int queryHandle, PerfQueryDataFlags flags, int dataSize, ref T1 data, ref uint bytesWritten)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = &data)
            fixed (uint* bytesWritten_ptr = &bytesWritten)
            {
                GetPerfQueryDataINTEL(queryHandle, flags, dataSize, data_ptr, bytesWritten_ptr);
            }
        }
        /// <inheritdoc cref="GetPerfQueryIdByNameINTEL(byte*, uint*)"/>
        public static unsafe void GetPerfQueryIdByNameINTEL(byte* queryName, Span<uint> queryId)
        {
            fixed (uint* queryId_ptr = queryId)
            {
                GetPerfQueryIdByNameINTEL(queryName, queryId_ptr);
            }
        }
        /// <inheritdoc cref="GetPerfQueryIdByNameINTEL(byte*, uint*)"/>
        public static unsafe void GetPerfQueryIdByNameINTEL(byte* queryName, uint[] queryId)
        {
            fixed (uint* queryId_ptr = queryId)
            {
                GetPerfQueryIdByNameINTEL(queryName, queryId_ptr);
            }
        }
        /// <inheritdoc cref="GetPerfQueryIdByNameINTEL(byte*, uint*)"/>
        public static unsafe void GetPerfQueryIdByNameINTEL(byte* queryName, ref uint queryId)
        {
            fixed (uint* queryId_ptr = &queryId)
            {
                GetPerfQueryIdByNameINTEL(queryName, queryId_ptr);
            }
        }
        /// <inheritdoc cref="GetPerfQueryInfoINTEL(uint, uint, byte*, uint*, uint*, uint*, PerformanceQueryCapsMaskINTEL*)"/>
        public static unsafe void GetPerfQueryInfoINTEL(uint queryId, uint queryNameLength, out string queryName, Span<uint> dataSize, Span<uint> noCounters, Span<uint> noInstances, Span<PerformanceQueryCapsMaskINTEL> capsMask)
        {
            fixed (PerformanceQueryCapsMaskINTEL* capsMask_ptr = capsMask)
            {
                fixed (uint* noInstances_ptr = noInstances)
                {
                    fixed (uint* noCounters_ptr = noCounters)
                    {
                        fixed (uint* dataSize_ptr = dataSize)
                        {
                            var queryName_ptr = (byte*)Marshal.AllocCoTaskMem((int)queryNameLength);
                            GetPerfQueryInfoINTEL(queryId, queryNameLength, queryName_ptr, dataSize_ptr, noCounters_ptr, noInstances_ptr, capsMask_ptr);
                            queryName = Marshal.PtrToStringUTF8((IntPtr)queryName_ptr)!;
                            Marshal.FreeCoTaskMem((IntPtr)queryName_ptr);
                        }
                    }
                }
            }
        }
        /// <inheritdoc cref="GetPerfQueryInfoINTEL(uint, uint, byte*, uint*, uint*, uint*, PerformanceQueryCapsMaskINTEL*)"/>
        public static unsafe void GetPerfQueryInfoINTEL(uint queryId, uint queryNameLength, out string queryName, uint[] dataSize, uint[] noCounters, uint[] noInstances, PerformanceQueryCapsMaskINTEL[] capsMask)
        {
            fixed (PerformanceQueryCapsMaskINTEL* capsMask_ptr = capsMask)
            {
                fixed (uint* noInstances_ptr = noInstances)
                {
                    fixed (uint* noCounters_ptr = noCounters)
                    {
                        fixed (uint* dataSize_ptr = dataSize)
                        {
                            var queryName_ptr = (byte*)Marshal.AllocCoTaskMem((int)queryNameLength);
                            GetPerfQueryInfoINTEL(queryId, queryNameLength, queryName_ptr, dataSize_ptr, noCounters_ptr, noInstances_ptr, capsMask_ptr);
                            queryName = Marshal.PtrToStringUTF8((IntPtr)queryName_ptr)!;
                            Marshal.FreeCoTaskMem((IntPtr)queryName_ptr);
                        }
                    }
                }
            }
        }
        /// <inheritdoc cref="GetPerfQueryInfoINTEL(uint, uint, byte*, uint*, uint*, uint*, PerformanceQueryCapsMaskINTEL*)"/>
        public static unsafe void GetPerfQueryInfoINTEL(uint queryId, uint queryNameLength, out string queryName, ref uint dataSize, ref uint noCounters, ref uint noInstances, ref PerformanceQueryCapsMaskINTEL capsMask)
        {
            fixed (uint* dataSize_ptr = &dataSize)
            fixed (uint* noCounters_ptr = &noCounters)
            fixed (uint* noInstances_ptr = &noInstances)
            fixed (PerformanceQueryCapsMaskINTEL* capsMask_ptr = &capsMask)
            {
                var queryName_ptr = (byte*)Marshal.AllocCoTaskMem((int)queryNameLength);
                GetPerfQueryInfoINTEL(queryId, queryNameLength, queryName_ptr, dataSize_ptr, noCounters_ptr, noInstances_ptr, capsMask_ptr);
                queryName = Marshal.PtrToStringUTF8((IntPtr)queryName_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)queryName_ptr);
            }
        }
    }
    public static unsafe partial class KHR
    {
        /// <inheritdoc cref="DebugMessageCallback(IntPtr, void*)"/>
        public static unsafe void DebugMessageCallback(GLDebugProc callback, IntPtr userParam)
        {
            void* userParam_vptr = (void*)userParam;
            IntPtr callback_ptr = Marshal.GetFunctionPointerForDelegate(callback);
            DebugMessageCallback(callback_ptr, userParam_vptr);
        }
        /// <inheritdoc cref="DebugMessageCallback(IntPtr, void*)"/>
        public static unsafe void DebugMessageCallback<T1>(GLDebugProc callback, ReadOnlySpan<T1> userParam)
            where T1 : unmanaged
        {
            fixed (void* userParam_ptr = userParam)
            {
                IntPtr callback_ptr = Marshal.GetFunctionPointerForDelegate(callback);
                DebugMessageCallback(callback_ptr, userParam_ptr);
            }
        }
        /// <inheritdoc cref="DebugMessageCallback(IntPtr, void*)"/>
        public static unsafe void DebugMessageCallback<T1>(GLDebugProc callback, T1[] userParam)
            where T1 : unmanaged
        {
            fixed (void* userParam_ptr = userParam)
            {
                IntPtr callback_ptr = Marshal.GetFunctionPointerForDelegate(callback);
                DebugMessageCallback(callback_ptr, userParam_ptr);
            }
        }
        /// <inheritdoc cref="DebugMessageCallback(IntPtr, void*)"/>
        public static unsafe void DebugMessageCallback<T1>(GLDebugProc callback, ref readonly T1 userParam)
            where T1 : unmanaged
        {
            fixed (void* userParam_ptr = &userParam)
            {
                IntPtr callback_ptr = Marshal.GetFunctionPointerForDelegate(callback);
                DebugMessageCallback(callback_ptr, userParam_ptr);
            }
        }
        /// <inheritdoc cref="DebugMessageCallbackKHR(IntPtr, void*)"/>
        public static unsafe void DebugMessageCallbackKHR(GLDebugProcKHR callback, IntPtr userParam)
        {
            void* userParam_vptr = (void*)userParam;
            IntPtr callback_ptr = Marshal.GetFunctionPointerForDelegate(callback);
            DebugMessageCallbackKHR(callback_ptr, userParam_vptr);
        }
        /// <inheritdoc cref="DebugMessageCallbackKHR(IntPtr, void*)"/>
        public static unsafe void DebugMessageCallbackKHR<T1>(GLDebugProcKHR callback, ReadOnlySpan<T1> userParam)
            where T1 : unmanaged
        {
            fixed (void* userParam_ptr = userParam)
            {
                IntPtr callback_ptr = Marshal.GetFunctionPointerForDelegate(callback);
                DebugMessageCallbackKHR(callback_ptr, userParam_ptr);
            }
        }
        /// <inheritdoc cref="DebugMessageCallbackKHR(IntPtr, void*)"/>
        public static unsafe void DebugMessageCallbackKHR<T1>(GLDebugProcKHR callback, T1[] userParam)
            where T1 : unmanaged
        {
            fixed (void* userParam_ptr = userParam)
            {
                IntPtr callback_ptr = Marshal.GetFunctionPointerForDelegate(callback);
                DebugMessageCallbackKHR(callback_ptr, userParam_ptr);
            }
        }
        /// <inheritdoc cref="DebugMessageCallbackKHR(IntPtr, void*)"/>
        public static unsafe void DebugMessageCallbackKHR<T1>(GLDebugProcKHR callback, ref readonly T1 userParam)
            where T1 : unmanaged
        {
            fixed (void* userParam_ptr = &userParam)
            {
                IntPtr callback_ptr = Marshal.GetFunctionPointerForDelegate(callback);
                DebugMessageCallbackKHR(callback_ptr, userParam_ptr);
            }
        }
        /// <inheritdoc cref="DebugMessageControl(DebugSource, DebugType, DebugSeverity, int, uint*, bool)"/>
        public static unsafe void DebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, int count, ReadOnlySpan<uint> ids, bool enabled)
        {
            fixed (uint* ids_ptr = ids)
            {
                DebugMessageControl(source, type, severity, count, ids_ptr, enabled);
            }
        }
        /// <inheritdoc cref="DebugMessageControl(DebugSource, DebugType, DebugSeverity, int, uint*, bool)"/>
        public static unsafe void DebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, int count, uint[] ids, bool enabled)
        {
            fixed (uint* ids_ptr = ids)
            {
                DebugMessageControl(source, type, severity, count, ids_ptr, enabled);
            }
        }
        /// <inheritdoc cref="DebugMessageControl(DebugSource, DebugType, DebugSeverity, int, uint*, bool)"/>
        public static unsafe void DebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, int count, ref readonly uint ids, bool enabled)
        {
            fixed (uint* ids_ptr = &ids)
            {
                DebugMessageControl(source, type, severity, count, ids_ptr, enabled);
            }
        }
        /// <inheritdoc cref="DebugMessageControlKHR(DebugSource, DebugType, DebugSeverity, int, uint*, bool)"/>
        public static unsafe void DebugMessageControlKHR(DebugSource source, DebugType type, DebugSeverity severity, int count, ReadOnlySpan<uint> ids, bool enabled)
        {
            fixed (uint* ids_ptr = ids)
            {
                DebugMessageControlKHR(source, type, severity, count, ids_ptr, enabled);
            }
        }
        /// <inheritdoc cref="DebugMessageControlKHR(DebugSource, DebugType, DebugSeverity, int, uint*, bool)"/>
        public static unsafe void DebugMessageControlKHR(DebugSource source, DebugType type, DebugSeverity severity, int count, uint[] ids, bool enabled)
        {
            fixed (uint* ids_ptr = ids)
            {
                DebugMessageControlKHR(source, type, severity, count, ids_ptr, enabled);
            }
        }
        /// <inheritdoc cref="DebugMessageControlKHR(DebugSource, DebugType, DebugSeverity, int, uint*, bool)"/>
        public static unsafe void DebugMessageControlKHR(DebugSource source, DebugType type, DebugSeverity severity, int count, ref readonly uint ids, bool enabled)
        {
            fixed (uint* ids_ptr = &ids)
            {
                DebugMessageControlKHR(source, type, severity, count, ids_ptr, enabled);
            }
        }
        /// <inheritdoc cref="DebugMessageInsert(DebugSource, DebugType, uint, DebugSeverity, int, byte*)"/>
        public static unsafe void DebugMessageInsert(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, string buf)
        {
            byte* buf_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(buf);
            DebugMessageInsert(source, type, id, severity, length, buf_ptr);
            Marshal.FreeCoTaskMem((IntPtr)buf_ptr);
        }
        /// <inheritdoc cref="DebugMessageInsertKHR(DebugSource, DebugType, uint, DebugSeverity, int, byte*)"/>
        public static unsafe void DebugMessageInsertKHR(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, string buf)
        {
            byte* buf_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(buf);
            DebugMessageInsertKHR(source, type, id, severity, length, buf_ptr);
            Marshal.FreeCoTaskMem((IntPtr)buf_ptr);
        }
        /// <inheritdoc cref="GetDebugMessageLog(uint, int, DebugSource*, DebugType*, uint*, DebugSeverity*, int*, byte*)"/>
        public static unsafe uint GetDebugMessageLog(uint count, int bufSize, Span<DebugSource> sources, Span<DebugType> types, Span<uint> ids, Span<DebugSeverity> severities, Span<int> lengths, out string messageLog)
        {
            uint returnValue;
            fixed (int* lengths_ptr = lengths)
            {
                fixed (DebugSeverity* severities_ptr = severities)
                {
                    fixed (uint* ids_ptr = ids)
                    {
                        fixed (DebugType* types_ptr = types)
                        {
                            fixed (DebugSource* sources_ptr = sources)
                            {
                                var messageLog_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                                returnValue = GetDebugMessageLog(count, bufSize, sources_ptr, types_ptr, ids_ptr, severities_ptr, lengths_ptr, messageLog_ptr);
                                messageLog = Marshal.PtrToStringUTF8((IntPtr)messageLog_ptr)!;
                                Marshal.FreeCoTaskMem((IntPtr)messageLog_ptr);
                            }
                        }
                    }
                }
            }
            return returnValue;
        }
        /// <inheritdoc cref="GetDebugMessageLog(uint, int, DebugSource*, DebugType*, uint*, DebugSeverity*, int*, byte*)"/>
        public static unsafe uint GetDebugMessageLog(uint count, int bufSize, DebugSource[] sources, DebugType[] types, uint[] ids, DebugSeverity[] severities, int[] lengths, out string messageLog)
        {
            uint returnValue;
            fixed (int* lengths_ptr = lengths)
            {
                fixed (DebugSeverity* severities_ptr = severities)
                {
                    fixed (uint* ids_ptr = ids)
                    {
                        fixed (DebugType* types_ptr = types)
                        {
                            fixed (DebugSource* sources_ptr = sources)
                            {
                                var messageLog_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                                returnValue = GetDebugMessageLog(count, bufSize, sources_ptr, types_ptr, ids_ptr, severities_ptr, lengths_ptr, messageLog_ptr);
                                messageLog = Marshal.PtrToStringUTF8((IntPtr)messageLog_ptr)!;
                                Marshal.FreeCoTaskMem((IntPtr)messageLog_ptr);
                            }
                        }
                    }
                }
            }
            return returnValue;
        }
        /// <inheritdoc cref="GetDebugMessageLog(uint, int, DebugSource*, DebugType*, uint*, DebugSeverity*, int*, byte*)"/>
        public static unsafe uint GetDebugMessageLog(uint count, int bufSize, ref DebugSource sources, ref DebugType types, ref uint ids, ref DebugSeverity severities, ref int lengths, out string messageLog)
        {
            uint returnValue;
            fixed (DebugSource* sources_ptr = &sources)
            fixed (DebugType* types_ptr = &types)
            fixed (uint* ids_ptr = &ids)
            fixed (DebugSeverity* severities_ptr = &severities)
            fixed (int* lengths_ptr = &lengths)
            {
                var messageLog_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                returnValue = GetDebugMessageLog(count, bufSize, sources_ptr, types_ptr, ids_ptr, severities_ptr, lengths_ptr, messageLog_ptr);
                messageLog = Marshal.PtrToStringUTF8((IntPtr)messageLog_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)messageLog_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="GetDebugMessageLogKHR(uint, int, DebugSource*, DebugType*, uint*, DebugSeverity*, int*, byte*)"/>
        public static unsafe uint GetDebugMessageLogKHR(uint count, int bufSize, Span<DebugSource> sources, Span<DebugType> types, Span<uint> ids, Span<DebugSeverity> severities, Span<int> lengths, out string messageLog)
        {
            uint returnValue;
            fixed (int* lengths_ptr = lengths)
            {
                fixed (DebugSeverity* severities_ptr = severities)
                {
                    fixed (uint* ids_ptr = ids)
                    {
                        fixed (DebugType* types_ptr = types)
                        {
                            fixed (DebugSource* sources_ptr = sources)
                            {
                                var messageLog_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                                returnValue = GetDebugMessageLogKHR(count, bufSize, sources_ptr, types_ptr, ids_ptr, severities_ptr, lengths_ptr, messageLog_ptr);
                                messageLog = Marshal.PtrToStringUTF8((IntPtr)messageLog_ptr)!;
                                Marshal.FreeCoTaskMem((IntPtr)messageLog_ptr);
                            }
                        }
                    }
                }
            }
            return returnValue;
        }
        /// <inheritdoc cref="GetDebugMessageLogKHR(uint, int, DebugSource*, DebugType*, uint*, DebugSeverity*, int*, byte*)"/>
        public static unsafe uint GetDebugMessageLogKHR(uint count, int bufSize, DebugSource[] sources, DebugType[] types, uint[] ids, DebugSeverity[] severities, int[] lengths, out string messageLog)
        {
            uint returnValue;
            fixed (int* lengths_ptr = lengths)
            {
                fixed (DebugSeverity* severities_ptr = severities)
                {
                    fixed (uint* ids_ptr = ids)
                    {
                        fixed (DebugType* types_ptr = types)
                        {
                            fixed (DebugSource* sources_ptr = sources)
                            {
                                var messageLog_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                                returnValue = GetDebugMessageLogKHR(count, bufSize, sources_ptr, types_ptr, ids_ptr, severities_ptr, lengths_ptr, messageLog_ptr);
                                messageLog = Marshal.PtrToStringUTF8((IntPtr)messageLog_ptr)!;
                                Marshal.FreeCoTaskMem((IntPtr)messageLog_ptr);
                            }
                        }
                    }
                }
            }
            return returnValue;
        }
        /// <inheritdoc cref="GetDebugMessageLogKHR(uint, int, DebugSource*, DebugType*, uint*, DebugSeverity*, int*, byte*)"/>
        public static unsafe uint GetDebugMessageLogKHR(uint count, int bufSize, ref DebugSource sources, ref DebugType types, ref uint ids, ref DebugSeverity severities, ref int lengths, out string messageLog)
        {
            uint returnValue;
            fixed (DebugSource* sources_ptr = &sources)
            fixed (DebugType* types_ptr = &types)
            fixed (uint* ids_ptr = &ids)
            fixed (DebugSeverity* severities_ptr = &severities)
            fixed (int* lengths_ptr = &lengths)
            {
                var messageLog_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                returnValue = GetDebugMessageLogKHR(count, bufSize, sources_ptr, types_ptr, ids_ptr, severities_ptr, lengths_ptr, messageLog_ptr);
                messageLog = Marshal.PtrToStringUTF8((IntPtr)messageLog_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)messageLog_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="GetnUniformfv(int, int, int, float*)"/>
        public static unsafe void GetnUniformf(int program, int location, int bufSize, Span<float> parameters)
        {
            fixed (float* parameters_ptr = parameters)
            {
                GetnUniformfv(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformfv(int, int, int, float*)"/>
        public static unsafe void GetnUniformf(int program, int location, int bufSize, float[] parameters)
        {
            fixed (float* parameters_ptr = parameters)
            {
                GetnUniformfv(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformfv(int, int, int, float*)"/>
        public static unsafe void GetnUniformf(int program, int location, int bufSize, ref float parameters)
        {
            fixed (float* parameters_ptr = &parameters)
            {
                GetnUniformfv(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformfvKHR(int, int, int, float*)"/>
        public static unsafe void GetnUniformfvKHR(int program, int location, int bufSize, Span<float> parameters)
        {
            fixed (float* parameters_ptr = parameters)
            {
                GetnUniformfvKHR(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformfvKHR(int, int, int, float*)"/>
        public static unsafe void GetnUniformfvKHR(int program, int location, int bufSize, float[] parameters)
        {
            fixed (float* parameters_ptr = parameters)
            {
                GetnUniformfvKHR(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformfvKHR(int, int, int, float*)"/>
        public static unsafe void GetnUniformfvKHR(int program, int location, int bufSize, ref float parameters)
        {
            fixed (float* parameters_ptr = &parameters)
            {
                GetnUniformfvKHR(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformiv(int, int, int, int*)"/>
        public static unsafe void GetnUniformi(int program, int location, int bufSize, Span<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetnUniformiv(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformiv(int, int, int, int*)"/>
        public static unsafe void GetnUniformi(int program, int location, int bufSize, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetnUniformiv(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformiv(int, int, int, int*)"/>
        public static unsafe void GetnUniformi(int program, int location, int bufSize, ref int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                GetnUniformiv(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformivKHR(int, int, int, int*)"/>
        public static unsafe void GetnUniformivKHR(int program, int location, int bufSize, Span<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetnUniformivKHR(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformivKHR(int, int, int, int*)"/>
        public static unsafe void GetnUniformivKHR(int program, int location, int bufSize, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetnUniformivKHR(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformivKHR(int, int, int, int*)"/>
        public static unsafe void GetnUniformivKHR(int program, int location, int bufSize, ref int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                GetnUniformivKHR(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformuiv(int, int, int, uint*)"/>
        public static unsafe void GetnUniformui(int program, int location, int bufSize, Span<uint> parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                GetnUniformuiv(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformuiv(int, int, int, uint*)"/>
        public static unsafe void GetnUniformui(int program, int location, int bufSize, uint[] parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                GetnUniformuiv(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformuiv(int, int, int, uint*)"/>
        public static unsafe void GetnUniformui(int program, int location, int bufSize, ref uint parameters)
        {
            fixed (uint* parameters_ptr = &parameters)
            {
                GetnUniformuiv(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformuivKHR(int, int, int, uint*)"/>
        public static unsafe void GetnUniformuivKHR(int program, int location, int bufSize, Span<uint> parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                GetnUniformuivKHR(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformuivKHR(int, int, int, uint*)"/>
        public static unsafe void GetnUniformuivKHR(int program, int location, int bufSize, uint[] parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                GetnUniformuivKHR(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetnUniformuivKHR(int, int, int, uint*)"/>
        public static unsafe void GetnUniformuivKHR(int program, int location, int bufSize, ref uint parameters)
        {
            fixed (uint* parameters_ptr = &parameters)
            {
                GetnUniformuivKHR(program, location, bufSize, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetObjectLabel(ObjectIdentifier, uint, int, int*, byte*)"/>
        public static unsafe string GetObjectLabel(ObjectIdentifier identifier, uint name, int bufSize, out int length)
        {
            string label;
            fixed (int* length_ptr = &length)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetObjectLabel(identifier, name, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
            return label;
        }
        /// <inheritdoc cref="GetObjectLabel(ObjectIdentifier, uint, int, int*, byte*)"/>
        public static unsafe void GetObjectLabel(ObjectIdentifier identifier, uint name, int bufSize, out int length, out string label)
        {
            fixed (int* length_ptr = &length)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetObjectLabel(identifier, name, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
        }
        /// <inheritdoc cref="GetObjectLabelKHR(All, uint, int, int*, byte*)"/>
        public static unsafe string GetObjectLabelKHR(All identifier, uint name, int bufSize, out int length)
        {
            string label;
            fixed (int* length_ptr = &length)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetObjectLabelKHR(identifier, name, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
            return label;
        }
        /// <inheritdoc cref="GetObjectLabelKHR(All, uint, int, int*, byte*)"/>
        public static unsafe void GetObjectLabelKHR(All identifier, uint name, int bufSize, out int length, out string label)
        {
            fixed (int* length_ptr = &length)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetObjectLabelKHR(identifier, name, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
        }
        /// <inheritdoc cref="GetObjectPtrLabel(void*, int, int*, byte*)"/>
        public static unsafe string GetObjectPtrLabel(IntPtr ptr, int bufSize, out int length)
        {
            string label;
            fixed (int* length_ptr = &length)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                void* ptr_vptr = (void*)ptr;
                GetObjectPtrLabel(ptr_vptr, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
            return label;
        }
        /// <inheritdoc cref="GetObjectPtrLabel(void*, int, int*, byte*)"/>
        public static unsafe void GetObjectPtrLabel(IntPtr ptr, int bufSize, out int length, out string label)
        {
            fixed (int* length_ptr = &length)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                void* ptr_vptr = (void*)ptr;
                GetObjectPtrLabel(ptr_vptr, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
        }
        /// <inheritdoc cref="GetObjectPtrLabel(void*, int, int*, byte*)"/>
        public static unsafe string GetObjectPtrLabel<T1>(ReadOnlySpan<T1> ptr, int bufSize, out int length)
            where T1 : unmanaged
        {
            string label;
            fixed (int* length_ptr = &length)
            {
                fixed (void* ptr_ptr = ptr)
                {
                    var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                    GetObjectPtrLabel(ptr_ptr, bufSize, length_ptr, label_ptr);
                    label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                    Marshal.FreeCoTaskMem((IntPtr)label_ptr);
                }
            }
            return label;
        }
        /// <inheritdoc cref="GetObjectPtrLabel(void*, int, int*, byte*)"/>
        public static unsafe void GetObjectPtrLabel<T1>(ReadOnlySpan<T1> ptr, int bufSize, out int length, out string label)
            where T1 : unmanaged
        {
            fixed (int* length_ptr = &length)
            {
                fixed (void* ptr_ptr = ptr)
                {
                    var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                    GetObjectPtrLabel(ptr_ptr, bufSize, length_ptr, label_ptr);
                    label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                    Marshal.FreeCoTaskMem((IntPtr)label_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetObjectPtrLabel(void*, int, int*, byte*)"/>
        public static unsafe string GetObjectPtrLabel<T1>(T1[] ptr, int bufSize, out int length)
            where T1 : unmanaged
        {
            string label;
            fixed (int* length_ptr = &length)
            {
                fixed (void* ptr_ptr = ptr)
                {
                    var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                    GetObjectPtrLabel(ptr_ptr, bufSize, length_ptr, label_ptr);
                    label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                    Marshal.FreeCoTaskMem((IntPtr)label_ptr);
                }
            }
            return label;
        }
        /// <inheritdoc cref="GetObjectPtrLabel(void*, int, int*, byte*)"/>
        public static unsafe void GetObjectPtrLabel<T1>(T1[] ptr, int bufSize, out int length, out string label)
            where T1 : unmanaged
        {
            fixed (int* length_ptr = &length)
            {
                fixed (void* ptr_ptr = ptr)
                {
                    var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                    GetObjectPtrLabel(ptr_ptr, bufSize, length_ptr, label_ptr);
                    label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                    Marshal.FreeCoTaskMem((IntPtr)label_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetObjectPtrLabel(void*, int, int*, byte*)"/>
        public static unsafe string GetObjectPtrLabel<T1>(ref readonly T1 ptr, int bufSize, out int length)
            where T1 : unmanaged
        {
            string label;
            fixed (void* ptr_ptr = &ptr)
            fixed (int* length_ptr = &length)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetObjectPtrLabel(ptr_ptr, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
            return label;
        }
        /// <inheritdoc cref="GetObjectPtrLabel(void*, int, int*, byte*)"/>
        public static unsafe void GetObjectPtrLabel<T1>(ref readonly T1 ptr, int bufSize, out int length, out string label)
            where T1 : unmanaged
        {
            fixed (void* ptr_ptr = &ptr)
            fixed (int* length_ptr = &length)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetObjectPtrLabel(ptr_ptr, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
        }
        /// <inheritdoc cref="GetObjectPtrLabelKHR(void*, int, int*, byte*)"/>
        public static unsafe string GetObjectPtrLabelKHR(IntPtr ptr, int bufSize, out int length)
        {
            string label;
            fixed (int* length_ptr = &length)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                void* ptr_vptr = (void*)ptr;
                GetObjectPtrLabelKHR(ptr_vptr, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
            return label;
        }
        /// <inheritdoc cref="GetObjectPtrLabelKHR(void*, int, int*, byte*)"/>
        public static unsafe void GetObjectPtrLabelKHR(IntPtr ptr, int bufSize, out int length, out string label)
        {
            fixed (int* length_ptr = &length)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                void* ptr_vptr = (void*)ptr;
                GetObjectPtrLabelKHR(ptr_vptr, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
        }
        /// <inheritdoc cref="GetObjectPtrLabelKHR(void*, int, int*, byte*)"/>
        public static unsafe string GetObjectPtrLabelKHR<T1>(ReadOnlySpan<T1> ptr, int bufSize, out int length)
            where T1 : unmanaged
        {
            string label;
            fixed (int* length_ptr = &length)
            {
                fixed (void* ptr_ptr = ptr)
                {
                    var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                    GetObjectPtrLabelKHR(ptr_ptr, bufSize, length_ptr, label_ptr);
                    label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                    Marshal.FreeCoTaskMem((IntPtr)label_ptr);
                }
            }
            return label;
        }
        /// <inheritdoc cref="GetObjectPtrLabelKHR(void*, int, int*, byte*)"/>
        public static unsafe void GetObjectPtrLabelKHR<T1>(ReadOnlySpan<T1> ptr, int bufSize, out int length, out string label)
            where T1 : unmanaged
        {
            fixed (int* length_ptr = &length)
            {
                fixed (void* ptr_ptr = ptr)
                {
                    var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                    GetObjectPtrLabelKHR(ptr_ptr, bufSize, length_ptr, label_ptr);
                    label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                    Marshal.FreeCoTaskMem((IntPtr)label_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetObjectPtrLabelKHR(void*, int, int*, byte*)"/>
        public static unsafe string GetObjectPtrLabelKHR<T1>(T1[] ptr, int bufSize, out int length)
            where T1 : unmanaged
        {
            string label;
            fixed (int* length_ptr = &length)
            {
                fixed (void* ptr_ptr = ptr)
                {
                    var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                    GetObjectPtrLabelKHR(ptr_ptr, bufSize, length_ptr, label_ptr);
                    label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                    Marshal.FreeCoTaskMem((IntPtr)label_ptr);
                }
            }
            return label;
        }
        /// <inheritdoc cref="GetObjectPtrLabelKHR(void*, int, int*, byte*)"/>
        public static unsafe void GetObjectPtrLabelKHR<T1>(T1[] ptr, int bufSize, out int length, out string label)
            where T1 : unmanaged
        {
            fixed (int* length_ptr = &length)
            {
                fixed (void* ptr_ptr = ptr)
                {
                    var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                    GetObjectPtrLabelKHR(ptr_ptr, bufSize, length_ptr, label_ptr);
                    label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                    Marshal.FreeCoTaskMem((IntPtr)label_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetObjectPtrLabelKHR(void*, int, int*, byte*)"/>
        public static unsafe string GetObjectPtrLabelKHR<T1>(ref readonly T1 ptr, int bufSize, out int length)
            where T1 : unmanaged
        {
            string label;
            fixed (void* ptr_ptr = &ptr)
            fixed (int* length_ptr = &length)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetObjectPtrLabelKHR(ptr_ptr, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
            return label;
        }
        /// <inheritdoc cref="GetObjectPtrLabelKHR(void*, int, int*, byte*)"/>
        public static unsafe void GetObjectPtrLabelKHR<T1>(ref readonly T1 ptr, int bufSize, out int length, out string label)
            where T1 : unmanaged
        {
            fixed (void* ptr_ptr = &ptr)
            fixed (int* length_ptr = &length)
            {
                var label_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetObjectPtrLabelKHR(ptr_ptr, bufSize, length_ptr, label_ptr);
                label = Marshal.PtrToStringUTF8((IntPtr)label_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
        }
        /// <inheritdoc cref="GetPointerv(GetPointervPName, void**)"/>
        public static unsafe void GetPointer(GetPointervPName pname, void** parameters)
        {
            GetPointerv(pname, parameters);
        }
        /// <inheritdoc cref="ObjectLabel(ObjectIdentifier, uint, int, byte*)"/>
        public static unsafe void ObjectLabel(ObjectIdentifier identifier, uint name, int length, string label)
        {
            byte* label_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(label);
            ObjectLabel(identifier, name, length, label_ptr);
            Marshal.FreeCoTaskMem((IntPtr)label_ptr);
        }
        /// <inheritdoc cref="ObjectLabelKHR(ObjectIdentifier, uint, int, byte*)"/>
        public static unsafe void ObjectLabelKHR(ObjectIdentifier identifier, uint name, int length, string label)
        {
            byte* label_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(label);
            ObjectLabelKHR(identifier, name, length, label_ptr);
            Marshal.FreeCoTaskMem((IntPtr)label_ptr);
        }
        /// <inheritdoc cref="ObjectPtrLabel(void*, int, byte*)"/>
        public static unsafe void ObjectPtrLabel(IntPtr ptr, int length, string label)
        {
            byte* label_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(label);
            void* ptr_vptr = (void*)ptr;
            ObjectPtrLabel(ptr_vptr, length, label_ptr);
            Marshal.FreeCoTaskMem((IntPtr)label_ptr);
        }
        /// <inheritdoc cref="ObjectPtrLabel(void*, int, byte*)"/>
        public static unsafe void ObjectPtrLabel<T1>(ReadOnlySpan<T1> ptr, int length, string label)
            where T1 : unmanaged
        {
            fixed (void* ptr_ptr = ptr)
            {
                byte* label_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(label);
                ObjectPtrLabel(ptr_ptr, length, label_ptr);
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
        }
        /// <inheritdoc cref="ObjectPtrLabel(void*, int, byte*)"/>
        public static unsafe void ObjectPtrLabel<T1>(T1[] ptr, int length, string label)
            where T1 : unmanaged
        {
            fixed (void* ptr_ptr = ptr)
            {
                byte* label_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(label);
                ObjectPtrLabel(ptr_ptr, length, label_ptr);
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
        }
        /// <inheritdoc cref="ObjectPtrLabel(void*, int, byte*)"/>
        public static unsafe void ObjectPtrLabel<T1>(ref readonly T1 ptr, int length, string label)
            where T1 : unmanaged
        {
            fixed (void* ptr_ptr = &ptr)
            {
                byte* label_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(label);
                ObjectPtrLabel(ptr_ptr, length, label_ptr);
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
        }
        /// <inheritdoc cref="ObjectPtrLabelKHR(void*, int, byte*)"/>
        public static unsafe void ObjectPtrLabelKHR(IntPtr ptr, int length, string label)
        {
            byte* label_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(label);
            void* ptr_vptr = (void*)ptr;
            ObjectPtrLabelKHR(ptr_vptr, length, label_ptr);
            Marshal.FreeCoTaskMem((IntPtr)label_ptr);
        }
        /// <inheritdoc cref="ObjectPtrLabelKHR(void*, int, byte*)"/>
        public static unsafe void ObjectPtrLabelKHR<T1>(ReadOnlySpan<T1> ptr, int length, string label)
            where T1 : unmanaged
        {
            fixed (void* ptr_ptr = ptr)
            {
                byte* label_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(label);
                ObjectPtrLabelKHR(ptr_ptr, length, label_ptr);
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
        }
        /// <inheritdoc cref="ObjectPtrLabelKHR(void*, int, byte*)"/>
        public static unsafe void ObjectPtrLabelKHR<T1>(T1[] ptr, int length, string label)
            where T1 : unmanaged
        {
            fixed (void* ptr_ptr = ptr)
            {
                byte* label_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(label);
                ObjectPtrLabelKHR(ptr_ptr, length, label_ptr);
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
        }
        /// <inheritdoc cref="ObjectPtrLabelKHR(void*, int, byte*)"/>
        public static unsafe void ObjectPtrLabelKHR<T1>(ref readonly T1 ptr, int length, string label)
            where T1 : unmanaged
        {
            fixed (void* ptr_ptr = &ptr)
            {
                byte* label_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(label);
                ObjectPtrLabelKHR(ptr_ptr, length, label_ptr);
                Marshal.FreeCoTaskMem((IntPtr)label_ptr);
            }
        }
        /// <inheritdoc cref="PushDebugGroup(DebugSource, uint, int, byte*)"/>
        public static unsafe void PushDebugGroup(DebugSource source, uint id, int length, string message)
        {
            byte* message_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(message);
            PushDebugGroup(source, id, length, message_ptr);
            Marshal.FreeCoTaskMem((IntPtr)message_ptr);
        }
        /// <inheritdoc cref="PushDebugGroupKHR(DebugSource, uint, int, byte*)"/>
        public static unsafe void PushDebugGroupKHR(DebugSource source, uint id, int length, string message)
        {
            byte* message_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(message);
            PushDebugGroupKHR(source, id, length, message_ptr);
            Marshal.FreeCoTaskMem((IntPtr)message_ptr);
        }
        /// <inheritdoc cref="ReadnPixels(int, int, int, int, PixelFormat, PixelType, int, void*)"/>
        public static unsafe void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, IntPtr data)
        {
            void* data_vptr = (void*)data;
            ReadnPixels(x, y, width, height, format, type, bufSize, data_vptr);
        }
        /// <inheritdoc cref="ReadnPixels(int, int, int, int, PixelFormat, PixelType, int, void*)"/>
        public static unsafe void ReadnPixels<T1>(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, Span<T1> data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                ReadnPixels(x, y, width, height, format, type, bufSize, data_ptr);
            }
        }
        /// <inheritdoc cref="ReadnPixels(int, int, int, int, PixelFormat, PixelType, int, void*)"/>
        public static unsafe void ReadnPixels<T1>(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, T1[] data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                ReadnPixels(x, y, width, height, format, type, bufSize, data_ptr);
            }
        }
        /// <inheritdoc cref="ReadnPixels(int, int, int, int, PixelFormat, PixelType, int, void*)"/>
        public static unsafe void ReadnPixels<T1>(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, ref T1 data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = &data)
            {
                ReadnPixels(x, y, width, height, format, type, bufSize, data_ptr);
            }
        }
        /// <inheritdoc cref="ReadnPixelsKHR(int, int, int, int, PixelFormat, PixelType, int, void*)"/>
        public static unsafe void ReadnPixelsKHR(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, IntPtr data)
        {
            void* data_vptr = (void*)data;
            ReadnPixelsKHR(x, y, width, height, format, type, bufSize, data_vptr);
        }
        /// <inheritdoc cref="ReadnPixelsKHR(int, int, int, int, PixelFormat, PixelType, int, void*)"/>
        public static unsafe void ReadnPixelsKHR<T1>(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, Span<T1> data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                ReadnPixelsKHR(x, y, width, height, format, type, bufSize, data_ptr);
            }
        }
        /// <inheritdoc cref="ReadnPixelsKHR(int, int, int, int, PixelFormat, PixelType, int, void*)"/>
        public static unsafe void ReadnPixelsKHR<T1>(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, T1[] data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                ReadnPixelsKHR(x, y, width, height, format, type, bufSize, data_ptr);
            }
        }
        /// <inheritdoc cref="ReadnPixelsKHR(int, int, int, int, PixelFormat, PixelType, int, void*)"/>
        public static unsafe void ReadnPixelsKHR<T1>(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, ref T1 data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = &data)
            {
                ReadnPixelsKHR(x, y, width, height, format, type, bufSize, data_ptr);
            }
        }
    }
    public static unsafe partial class MESA
    {
        /// <inheritdoc cref="DeleteSamplers(int, int*)"/>
        public static unsafe void DeleteSampler(int sampler)
        {
            int count = 1;
            int* samplers_handle = &sampler;
            DeleteSamplers(count, samplers_handle);
        }
        /// <inheritdoc cref="DeleteSamplers(int, int*)"/>
        public static unsafe void DeleteSamplers(int count, ReadOnlySpan<int> samplers)
        {
            fixed (int* samplers_ptr = samplers)
            {
                DeleteSamplers(count, samplers_ptr);
            }
        }
        /// <inheritdoc cref="DeleteSamplers(int, int*)"/>
        public static unsafe void DeleteSamplers(int count, int[] samplers)
        {
            fixed (int* samplers_ptr = samplers)
            {
                DeleteSamplers(count, samplers_ptr);
            }
        }
        /// <inheritdoc cref="DeleteSamplers(int, int*)"/>
        public static unsafe void DeleteSamplers(int count, ref readonly int samplers)
        {
            fixed (int* samplers_ptr = &samplers)
            {
                DeleteSamplers(count, samplers_ptr);
            }
        }
        /// <inheritdoc cref="GenSamplers(int, int*)"/>
        public static unsafe int GenSampler()
        {
            int count = 1;
            Unsafe.SkipInit(out int sampler);
            int* samplers_handle = &sampler;
            GenSamplers(count, samplers_handle);
            return sampler;
        }
        /// <inheritdoc cref="GenSamplers(int, int*)"/>
        public static unsafe void GenSampler(out int sampler)
        {
            int count = 1;
            Unsafe.SkipInit(out sampler);
            fixed(int* samplers_handle = &sampler)
            {
                GenSamplers(count, samplers_handle);
            }
        }
        /// <inheritdoc cref="GenSamplers(int, int*)"/>
        public static unsafe void GenSamplers(int count, Span<int> samplers)
        {
            fixed (int* samplers_ptr = samplers)
            {
                GenSamplers(count, samplers_ptr);
            }
        }
        /// <inheritdoc cref="GenSamplers(int, int*)"/>
        public static unsafe void GenSamplers(int count, int[] samplers)
        {
            fixed (int* samplers_ptr = samplers)
            {
                GenSamplers(count, samplers_ptr);
            }
        }
        /// <inheritdoc cref="GenSamplers(int, int*)"/>
        public static unsafe void GenSamplers(int count, ref int samplers)
        {
            fixed (int* samplers_ptr = &samplers)
            {
                GenSamplers(count, samplers_ptr);
            }
        }
        /// <inheritdoc cref="GetFramebufferParameterivMESA(FramebufferTarget, FramebufferAttachmentParameterName, int*)"/>
        public static unsafe void GetFramebufferParameterivMESA(FramebufferTarget target, FramebufferAttachmentParameterName pname, Span<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetFramebufferParameterivMESA(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetFramebufferParameterivMESA(FramebufferTarget, FramebufferAttachmentParameterName, int*)"/>
        public static unsafe void GetFramebufferParameterivMESA(FramebufferTarget target, FramebufferAttachmentParameterName pname, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetFramebufferParameterivMESA(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetFramebufferParameterivMESA(FramebufferTarget, FramebufferAttachmentParameterName, int*)"/>
        public static unsafe int GetFramebufferParameterivMESA(FramebufferTarget target, FramebufferAttachmentParameterName pname)
        {
            int parameters;
            int* parameters_ptr = &parameters;
            {
                GetFramebufferParameterivMESA(target, pname, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetFramebufferParameterivMESA(FramebufferTarget, FramebufferAttachmentParameterName, int*)"/>
        public static unsafe void GetFramebufferParameterivMESA(FramebufferTarget target, FramebufferAttachmentParameterName pname, out int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                GetFramebufferParameterivMESA(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameterfv(int, SamplerParameterF, float*)"/>
        public static unsafe void GetSamplerParameterf(int sampler, SamplerParameterF pname, Span<float> parameters)
        {
            fixed (float* parameters_ptr = parameters)
            {
                GetSamplerParameterfv(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameterfv(int, SamplerParameterF, float*)"/>
        public static unsafe void GetSamplerParameterf(int sampler, SamplerParameterF pname, float[] parameters)
        {
            fixed (float* parameters_ptr = parameters)
            {
                GetSamplerParameterfv(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameterfv(int, SamplerParameterF, float*)"/>
        public static unsafe float GetSamplerParameterf(int sampler, SamplerParameterF pname)
        {
            float parameters;
            float* parameters_ptr = &parameters;
            {
                GetSamplerParameterfv(sampler, pname, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetSamplerParameterfv(int, SamplerParameterF, float*)"/>
        public static unsafe void GetSamplerParameterf(int sampler, SamplerParameterF pname, out float parameters)
        {
            fixed (float* parameters_ptr = &parameters)
            {
                GetSamplerParameterfv(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameteriv(int, SamplerParameterI, int*)"/>
        public static unsafe void GetSamplerParameteri(int sampler, SamplerParameterI pname, Span<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetSamplerParameteriv(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameteriv(int, SamplerParameterI, int*)"/>
        public static unsafe void GetSamplerParameteri(int sampler, SamplerParameterI pname, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetSamplerParameteriv(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameteriv(int, SamplerParameterI, int*)"/>
        public static unsafe int GetSamplerParameteri(int sampler, SamplerParameterI pname)
        {
            int parameters;
            int* parameters_ptr = &parameters;
            {
                GetSamplerParameteriv(sampler, pname, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetSamplerParameteriv(int, SamplerParameterI, int*)"/>
        public static unsafe void GetSamplerParameteri(int sampler, SamplerParameterI pname, out int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                GetSamplerParameteriv(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="SamplerParameterfv(int, SamplerParameterF, float*)"/>
        public static unsafe void SamplerParameterf(int sampler, SamplerParameterF pname, ReadOnlySpan<float> param)
        {
            fixed (float* param_ptr = param)
            {
                SamplerParameterfv(sampler, pname, param_ptr);
            }
        }
        /// <inheritdoc cref="SamplerParameterfv(int, SamplerParameterF, float*)"/>
        public static unsafe void SamplerParameterf(int sampler, SamplerParameterF pname, float[] param)
        {
            fixed (float* param_ptr = param)
            {
                SamplerParameterfv(sampler, pname, param_ptr);
            }
        }
        /// <inheritdoc cref="SamplerParameterfv(int, SamplerParameterF, float*)"/>
        public static unsafe void SamplerParameterf(int sampler, SamplerParameterF pname, ref readonly float param)
        {
            fixed (float* param_ptr = &param)
            {
                SamplerParameterfv(sampler, pname, param_ptr);
            }
        }
        /// <inheritdoc cref="SamplerParameteriv(int, SamplerParameterI, int*)"/>
        public static unsafe void SamplerParameteri(int sampler, SamplerParameterI pname, ReadOnlySpan<int> param)
        {
            fixed (int* param_ptr = param)
            {
                SamplerParameteriv(sampler, pname, param_ptr);
            }
        }
        /// <inheritdoc cref="SamplerParameteriv(int, SamplerParameterI, int*)"/>
        public static unsafe void SamplerParameteri(int sampler, SamplerParameterI pname, int[] param)
        {
            fixed (int* param_ptr = param)
            {
                SamplerParameteriv(sampler, pname, param_ptr);
            }
        }
        /// <inheritdoc cref="SamplerParameteriv(int, SamplerParameterI, int*)"/>
        public static unsafe void SamplerParameteri(int sampler, SamplerParameterI pname, ref readonly int param)
        {
            fixed (int* param_ptr = &param)
            {
                SamplerParameteriv(sampler, pname, param_ptr);
            }
        }
    }
    public static unsafe partial class NV
    {
        /// <inheritdoc cref="CoverageModulationTableNV(int, float*)"/>
        public static unsafe void CoverageModulationTableNV(int n, ReadOnlySpan<float> v)
        {
            fixed (float* v_ptr = v)
            {
                CoverageModulationTableNV(n, v_ptr);
            }
        }
        /// <inheritdoc cref="CoverageModulationTableNV(int, float*)"/>
        public static unsafe void CoverageModulationTableNV(int n, float[] v)
        {
            fixed (float* v_ptr = v)
            {
                CoverageModulationTableNV(n, v_ptr);
            }
        }
        /// <inheritdoc cref="CoverageModulationTableNV(int, float*)"/>
        public static unsafe void CoverageModulationTableNV(int n, ref readonly float v)
        {
            fixed (float* v_ptr = &v)
            {
                CoverageModulationTableNV(n, v_ptr);
            }
        }
        /// <inheritdoc cref="CoverFillPathInstancedNV(int, PathElementType, void*, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void CoverFillPathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, InstancedPathCoverMode coverMode, PathTransformType transformType, ReadOnlySpan<float> transformValues)
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                void* paths_vptr = (void*)paths;
                CoverFillPathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, coverMode, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="CoverFillPathInstancedNV(int, PathElementType, void*, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void CoverFillPathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, InstancedPathCoverMode coverMode, PathTransformType transformType, float[] transformValues)
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                void* paths_vptr = (void*)paths;
                CoverFillPathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, coverMode, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="CoverFillPathInstancedNV(int, PathElementType, void*, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void CoverFillPathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, InstancedPathCoverMode coverMode, PathTransformType transformType, ref readonly float transformValues)
        {
            fixed (float* transformValues_ptr = &transformValues)
            {
                void* paths_vptr = (void*)paths;
                CoverFillPathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, coverMode, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="CoverFillPathInstancedNV(int, PathElementType, void*, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void CoverFillPathInstancedNV<T1>(int numPaths, PathElementType pathNameType, ReadOnlySpan<T1> paths, uint pathBase, InstancedPathCoverMode coverMode, PathTransformType transformType, ReadOnlySpan<float> transformValues)
            where T1 : unmanaged
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                fixed (void* paths_ptr = paths)
                {
                    CoverFillPathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, coverMode, transformType, transformValues_ptr);
                }
            }
        }
        /// <inheritdoc cref="CoverFillPathInstancedNV(int, PathElementType, void*, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void CoverFillPathInstancedNV<T1>(int numPaths, PathElementType pathNameType, T1[] paths, uint pathBase, InstancedPathCoverMode coverMode, PathTransformType transformType, float[] transformValues)
            where T1 : unmanaged
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                fixed (void* paths_ptr = paths)
                {
                    CoverFillPathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, coverMode, transformType, transformValues_ptr);
                }
            }
        }
        /// <inheritdoc cref="CoverFillPathInstancedNV(int, PathElementType, void*, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void CoverFillPathInstancedNV<T1>(int numPaths, PathElementType pathNameType, ref readonly T1 paths, uint pathBase, InstancedPathCoverMode coverMode, PathTransformType transformType, ref readonly float transformValues)
            where T1 : unmanaged
        {
            fixed (void* paths_ptr = &paths)
            fixed (float* transformValues_ptr = &transformValues)
            {
                CoverFillPathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, coverMode, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="CoverStrokePathInstancedNV(int, PathElementType, void*, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void CoverStrokePathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, InstancedPathCoverMode coverMode, PathTransformType transformType, ReadOnlySpan<float> transformValues)
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                void* paths_vptr = (void*)paths;
                CoverStrokePathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, coverMode, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="CoverStrokePathInstancedNV(int, PathElementType, void*, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void CoverStrokePathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, InstancedPathCoverMode coverMode, PathTransformType transformType, float[] transformValues)
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                void* paths_vptr = (void*)paths;
                CoverStrokePathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, coverMode, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="CoverStrokePathInstancedNV(int, PathElementType, void*, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void CoverStrokePathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, InstancedPathCoverMode coverMode, PathTransformType transformType, ref readonly float transformValues)
        {
            fixed (float* transformValues_ptr = &transformValues)
            {
                void* paths_vptr = (void*)paths;
                CoverStrokePathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, coverMode, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="CoverStrokePathInstancedNV(int, PathElementType, void*, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void CoverStrokePathInstancedNV<T1>(int numPaths, PathElementType pathNameType, ReadOnlySpan<T1> paths, uint pathBase, InstancedPathCoverMode coverMode, PathTransformType transformType, ReadOnlySpan<float> transformValues)
            where T1 : unmanaged
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                fixed (void* paths_ptr = paths)
                {
                    CoverStrokePathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, coverMode, transformType, transformValues_ptr);
                }
            }
        }
        /// <inheritdoc cref="CoverStrokePathInstancedNV(int, PathElementType, void*, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void CoverStrokePathInstancedNV<T1>(int numPaths, PathElementType pathNameType, T1[] paths, uint pathBase, InstancedPathCoverMode coverMode, PathTransformType transformType, float[] transformValues)
            where T1 : unmanaged
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                fixed (void* paths_ptr = paths)
                {
                    CoverStrokePathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, coverMode, transformType, transformValues_ptr);
                }
            }
        }
        /// <inheritdoc cref="CoverStrokePathInstancedNV(int, PathElementType, void*, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void CoverStrokePathInstancedNV<T1>(int numPaths, PathElementType pathNameType, ref readonly T1 paths, uint pathBase, InstancedPathCoverMode coverMode, PathTransformType transformType, ref readonly float transformValues)
            where T1 : unmanaged
        {
            fixed (void* paths_ptr = &paths)
            fixed (float* transformValues_ptr = &transformValues)
            {
                CoverStrokePathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, coverMode, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="CreateSemaphoresNV(int, uint*)"/>
        public static unsafe void CreateSemaphoresNV(int n, Span<uint> semaphores)
        {
            fixed (uint* semaphores_ptr = semaphores)
            {
                CreateSemaphoresNV(n, semaphores_ptr);
            }
        }
        /// <inheritdoc cref="CreateSemaphoresNV(int, uint*)"/>
        public static unsafe void CreateSemaphoresNV(int n, uint[] semaphores)
        {
            fixed (uint* semaphores_ptr = semaphores)
            {
                CreateSemaphoresNV(n, semaphores_ptr);
            }
        }
        /// <inheritdoc cref="CreateSemaphoresNV(int, uint*)"/>
        public static unsafe void CreateSemaphoresNV(int n, ref uint semaphores)
        {
            fixed (uint* semaphores_ptr = &semaphores)
            {
                CreateSemaphoresNV(n, semaphores_ptr);
            }
        }
        /// <inheritdoc cref="DeleteFencesNV(int, uint*)"/>
        public static unsafe void DeleteFencesNV(int n, ReadOnlySpan<uint> fences)
        {
            fixed (uint* fences_ptr = fences)
            {
                DeleteFencesNV(n, fences_ptr);
            }
        }
        /// <inheritdoc cref="DeleteFencesNV(int, uint*)"/>
        public static unsafe void DeleteFencesNV(int n, uint[] fences)
        {
            fixed (uint* fences_ptr = fences)
            {
                DeleteFencesNV(n, fences_ptr);
            }
        }
        /// <inheritdoc cref="DeleteFencesNV(int, uint*)"/>
        public static unsafe void DeleteFencesNV(int n, ref readonly uint fences)
        {
            fixed (uint* fences_ptr = &fences)
            {
                DeleteFencesNV(n, fences_ptr);
            }
        }
        /// <inheritdoc cref="DepthRangeArrayfvNV(uint, int, float*)"/>
        public static unsafe void DepthRangeArrayfvNV(uint first, int count, ReadOnlySpan<float> v)
        {
            fixed (float* v_ptr = v)
            {
                DepthRangeArrayfvNV(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="DepthRangeArrayfvNV(uint, int, float*)"/>
        public static unsafe void DepthRangeArrayfvNV(uint first, int count, float[] v)
        {
            fixed (float* v_ptr = v)
            {
                DepthRangeArrayfvNV(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="DepthRangeArrayfvNV(uint, int, float*)"/>
        public static unsafe void DepthRangeArrayfvNV(uint first, int count, ref readonly float v)
        {
            fixed (float* v_ptr = &v)
            {
                DepthRangeArrayfvNV(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="DrawBuffersNV(int, All*)"/>
        public static unsafe void DrawBuffersNV(int n, ReadOnlySpan<All> bufs)
        {
            fixed (All* bufs_ptr = bufs)
            {
                DrawBuffersNV(n, bufs_ptr);
            }
        }
        /// <inheritdoc cref="DrawBuffersNV(int, All*)"/>
        public static unsafe void DrawBuffersNV(int n, All[] bufs)
        {
            fixed (All* bufs_ptr = bufs)
            {
                DrawBuffersNV(n, bufs_ptr);
            }
        }
        /// <inheritdoc cref="DrawBuffersNV(int, All*)"/>
        public static unsafe void DrawBuffersNV(int n, ref readonly All bufs)
        {
            fixed (All* bufs_ptr = &bufs)
            {
                DrawBuffersNV(n, bufs_ptr);
            }
        }
        /// <inheritdoc cref="DrawElementsInstancedNV(PrimitiveType, int, DrawElementsType, void*, int)"/>
        public static unsafe void DrawElementsInstancedNV(PrimitiveType mode, int count, DrawElementsType type, nint offset, int primcount)
        {
            void* indices = (void*)offset;
            DrawElementsInstancedNV(mode, count, type, indices, primcount);
        }
        /// <inheritdoc cref="FramebufferSampleLocationsfvNV(FramebufferTarget, uint, int, float*)"/>
        public static unsafe void FramebufferSampleLocationsfvNV(FramebufferTarget target, uint start, int count, ReadOnlySpan<float> v)
        {
            fixed (float* v_ptr = v)
            {
                FramebufferSampleLocationsfvNV(target, start, count, v_ptr);
            }
        }
        /// <inheritdoc cref="FramebufferSampleLocationsfvNV(FramebufferTarget, uint, int, float*)"/>
        public static unsafe void FramebufferSampleLocationsfvNV(FramebufferTarget target, uint start, int count, float[] v)
        {
            fixed (float* v_ptr = v)
            {
                FramebufferSampleLocationsfvNV(target, start, count, v_ptr);
            }
        }
        /// <inheritdoc cref="FramebufferSampleLocationsfvNV(FramebufferTarget, uint, int, float*)"/>
        public static unsafe void FramebufferSampleLocationsfvNV(FramebufferTarget target, uint start, int count, ref readonly float v)
        {
            fixed (float* v_ptr = &v)
            {
                FramebufferSampleLocationsfvNV(target, start, count, v_ptr);
            }
        }
        /// <inheritdoc cref="GenFencesNV(int, uint*)"/>
        public static unsafe void GenFencesNV(int n, Span<uint> fences)
        {
            fixed (uint* fences_ptr = fences)
            {
                GenFencesNV(n, fences_ptr);
            }
        }
        /// <inheritdoc cref="GenFencesNV(int, uint*)"/>
        public static unsafe void GenFencesNV(int n, uint[] fences)
        {
            fixed (uint* fences_ptr = fences)
            {
                GenFencesNV(n, fences_ptr);
            }
        }
        /// <inheritdoc cref="GenFencesNV(int, uint*)"/>
        public static unsafe void GenFencesNV(int n, ref uint fences)
        {
            fixed (uint* fences_ptr = &fences)
            {
                GenFencesNV(n, fences_ptr);
            }
        }
        /// <inheritdoc cref="GetCoverageModulationTableNV(int, float*)"/>
        public static unsafe void GetCoverageModulationTableNV(int bufSize, Span<float> v)
        {
            fixed (float* v_ptr = v)
            {
                GetCoverageModulationTableNV(bufSize, v_ptr);
            }
        }
        /// <inheritdoc cref="GetCoverageModulationTableNV(int, float*)"/>
        public static unsafe void GetCoverageModulationTableNV(int bufSize, float[] v)
        {
            fixed (float* v_ptr = v)
            {
                GetCoverageModulationTableNV(bufSize, v_ptr);
            }
        }
        /// <inheritdoc cref="GetCoverageModulationTableNV(int, float*)"/>
        public static unsafe void GetCoverageModulationTableNV(int bufSize, ref float v)
        {
            fixed (float* v_ptr = &v)
            {
                GetCoverageModulationTableNV(bufSize, v_ptr);
            }
        }
        /// <inheritdoc cref="GetFenceivNV(uint, FenceParameterNameNV, int*)"/>
        public static unsafe void GetFenceivNV(uint fence, FenceParameterNameNV pname, Span<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetFenceivNV(fence, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetFenceivNV(uint, FenceParameterNameNV, int*)"/>
        public static unsafe void GetFenceivNV(uint fence, FenceParameterNameNV pname, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetFenceivNV(fence, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetFenceivNV(uint, FenceParameterNameNV, int*)"/>
        public static unsafe int GetFenceivNV(uint fence, FenceParameterNameNV pname)
        {
            int parameters;
            int* parameters_ptr = &parameters;
            {
                GetFenceivNV(fence, pname, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetFenceivNV(uint, FenceParameterNameNV, int*)"/>
        public static unsafe void GetFenceivNV(uint fence, FenceParameterNameNV pname, out int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                GetFenceivNV(fence, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetFloati_vNV(GetPName, uint, float*)"/>
        public static unsafe void GetFloati_vNV(GetPName target, uint index, Span<float> data)
        {
            fixed (float* data_ptr = data)
            {
                GetFloati_vNV(target, index, data_ptr);
            }
        }
        /// <inheritdoc cref="GetFloati_vNV(GetPName, uint, float*)"/>
        public static unsafe void GetFloati_vNV(GetPName target, uint index, float[] data)
        {
            fixed (float* data_ptr = data)
            {
                GetFloati_vNV(target, index, data_ptr);
            }
        }
        /// <inheritdoc cref="GetFloati_vNV(GetPName, uint, float*)"/>
        public static unsafe float GetFloati_vNV(GetPName target, uint index)
        {
            float data;
            float* data_ptr = &data;
            {
                GetFloati_vNV(target, index, data_ptr);
            }
            return data;
        }
        /// <inheritdoc cref="GetFloati_vNV(GetPName, uint, float*)"/>
        public static unsafe void GetFloati_vNV(GetPName target, uint index, out float data)
        {
            fixed (float* data_ptr = &data)
            {
                GetFloati_vNV(target, index, data_ptr);
            }
        }
        /// <inheritdoc cref="GetInternalformatSampleivNV(TextureTarget, InternalFormat, int, InternalFormatPName, int, int*)"/>
        public static unsafe void GetInternalformatSampleivNV(TextureTarget target, InternalFormat internalformat, int samples, InternalFormatPName pname, int count, Span<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetInternalformatSampleivNV(target, internalformat, samples, pname, count, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetInternalformatSampleivNV(TextureTarget, InternalFormat, int, InternalFormatPName, int, int*)"/>
        public static unsafe void GetInternalformatSampleivNV(TextureTarget target, InternalFormat internalformat, int samples, InternalFormatPName pname, int count, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetInternalformatSampleivNV(target, internalformat, samples, pname, count, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetInternalformatSampleivNV(TextureTarget, InternalFormat, int, InternalFormatPName, int, int*)"/>
        public static unsafe void GetInternalformatSampleivNV(TextureTarget target, InternalFormat internalformat, int samples, InternalFormatPName pname, int count, ref int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                GetInternalformatSampleivNV(target, internalformat, samples, pname, count, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetMemoryObjectDetachedResourcesuivNV(uint, All, int, int, uint*)"/>
        public static unsafe void GetMemoryObjectDetachedResourcesuivNV(uint memory, All pname, int first, int count, Span<uint> parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                GetMemoryObjectDetachedResourcesuivNV(memory, pname, first, count, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetMemoryObjectDetachedResourcesuivNV(uint, All, int, int, uint*)"/>
        public static unsafe void GetMemoryObjectDetachedResourcesuivNV(uint memory, All pname, int first, int count, uint[] parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                GetMemoryObjectDetachedResourcesuivNV(memory, pname, first, count, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetMemoryObjectDetachedResourcesuivNV(uint, All, int, int, uint*)"/>
        public static unsafe void GetMemoryObjectDetachedResourcesuivNV(uint memory, All pname, int first, int count, ref uint parameters)
        {
            fixed (uint* parameters_ptr = &parameters)
            {
                GetMemoryObjectDetachedResourcesuivNV(memory, pname, first, count, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetPathColorGenfvNV(PathColor, PathGenMode, float*)"/>
        public static unsafe void GetPathColorGenfvNV(PathColor color, PathGenMode pname, Span<float> value)
        {
            fixed (float* value_ptr = value)
            {
                GetPathColorGenfvNV(color, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetPathColorGenfvNV(PathColor, PathGenMode, float*)"/>
        public static unsafe void GetPathColorGenfvNV(PathColor color, PathGenMode pname, float[] value)
        {
            fixed (float* value_ptr = value)
            {
                GetPathColorGenfvNV(color, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetPathColorGenfvNV(PathColor, PathGenMode, float*)"/>
        public static unsafe float GetPathColorGenfvNV(PathColor color, PathGenMode pname)
        {
            float value;
            float* value_ptr = &value;
            {
                GetPathColorGenfvNV(color, pname, value_ptr);
            }
            return value;
        }
        /// <inheritdoc cref="GetPathColorGenfvNV(PathColor, PathGenMode, float*)"/>
        public static unsafe void GetPathColorGenfvNV(PathColor color, PathGenMode pname, out float value)
        {
            fixed (float* value_ptr = &value)
            {
                GetPathColorGenfvNV(color, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetPathColorGenivNV(PathColor, PathGenMode, int*)"/>
        public static unsafe void GetPathColorGenivNV(PathColor color, PathGenMode pname, Span<int> value)
        {
            fixed (int* value_ptr = value)
            {
                GetPathColorGenivNV(color, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetPathColorGenivNV(PathColor, PathGenMode, int*)"/>
        public static unsafe void GetPathColorGenivNV(PathColor color, PathGenMode pname, int[] value)
        {
            fixed (int* value_ptr = value)
            {
                GetPathColorGenivNV(color, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetPathColorGenivNV(PathColor, PathGenMode, int*)"/>
        public static unsafe int GetPathColorGenivNV(PathColor color, PathGenMode pname)
        {
            int value;
            int* value_ptr = &value;
            {
                GetPathColorGenivNV(color, pname, value_ptr);
            }
            return value;
        }
        /// <inheritdoc cref="GetPathColorGenivNV(PathColor, PathGenMode, int*)"/>
        public static unsafe void GetPathColorGenivNV(PathColor color, PathGenMode pname, out int value)
        {
            fixed (int* value_ptr = &value)
            {
                GetPathColorGenivNV(color, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetPathCommandsNV(uint, byte*)"/>
        public static unsafe void GetPathCommandsNV(uint path, Span<byte> commands)
        {
            fixed (byte* commands_ptr = commands)
            {
                GetPathCommandsNV(path, commands_ptr);
            }
        }
        /// <inheritdoc cref="GetPathCommandsNV(uint, byte*)"/>
        public static unsafe void GetPathCommandsNV(uint path, byte[] commands)
        {
            fixed (byte* commands_ptr = commands)
            {
                GetPathCommandsNV(path, commands_ptr);
            }
        }
        /// <inheritdoc cref="GetPathCommandsNV(uint, byte*)"/>
        public static unsafe byte GetPathCommandsNV(uint path)
        {
            byte commands;
            byte* commands_ptr = &commands;
            {
                GetPathCommandsNV(path, commands_ptr);
            }
            return commands;
        }
        /// <inheritdoc cref="GetPathCommandsNV(uint, byte*)"/>
        public static unsafe void GetPathCommandsNV(uint path, out byte commands)
        {
            fixed (byte* commands_ptr = &commands)
            {
                GetPathCommandsNV(path, commands_ptr);
            }
        }
        /// <inheritdoc cref="GetPathCoordsNV(uint, float*)"/>
        public static unsafe void GetPathCoordsNV(uint path, Span<float> coords)
        {
            fixed (float* coords_ptr = coords)
            {
                GetPathCoordsNV(path, coords_ptr);
            }
        }
        /// <inheritdoc cref="GetPathCoordsNV(uint, float*)"/>
        public static unsafe void GetPathCoordsNV(uint path, float[] coords)
        {
            fixed (float* coords_ptr = coords)
            {
                GetPathCoordsNV(path, coords_ptr);
            }
        }
        /// <inheritdoc cref="GetPathCoordsNV(uint, float*)"/>
        public static unsafe float GetPathCoordsNV(uint path)
        {
            float coords;
            float* coords_ptr = &coords;
            {
                GetPathCoordsNV(path, coords_ptr);
            }
            return coords;
        }
        /// <inheritdoc cref="GetPathCoordsNV(uint, float*)"/>
        public static unsafe void GetPathCoordsNV(uint path, out float coords)
        {
            fixed (float* coords_ptr = &coords)
            {
                GetPathCoordsNV(path, coords_ptr);
            }
        }
        /// <inheritdoc cref="GetPathDashArrayNV(uint, float*)"/>
        public static unsafe void GetPathDashArrayNV(uint path, Span<float> dashArray)
        {
            fixed (float* dashArray_ptr = dashArray)
            {
                GetPathDashArrayNV(path, dashArray_ptr);
            }
        }
        /// <inheritdoc cref="GetPathDashArrayNV(uint, float*)"/>
        public static unsafe void GetPathDashArrayNV(uint path, float[] dashArray)
        {
            fixed (float* dashArray_ptr = dashArray)
            {
                GetPathDashArrayNV(path, dashArray_ptr);
            }
        }
        /// <inheritdoc cref="GetPathDashArrayNV(uint, float*)"/>
        public static unsafe float GetPathDashArrayNV(uint path)
        {
            float dashArray;
            float* dashArray_ptr = &dashArray;
            {
                GetPathDashArrayNV(path, dashArray_ptr);
            }
            return dashArray;
        }
        /// <inheritdoc cref="GetPathDashArrayNV(uint, float*)"/>
        public static unsafe void GetPathDashArrayNV(uint path, out float dashArray)
        {
            fixed (float* dashArray_ptr = &dashArray)
            {
                GetPathDashArrayNV(path, dashArray_ptr);
            }
        }
        /// <inheritdoc cref="GetPathMetricRangeNV(PathMetricMask, uint, int, int, float*)"/>
        public static unsafe void GetPathMetricRangeNV(PathMetricMask metricQueryMask, uint firstPathName, int numPaths, int stride, Span<float> metrics)
        {
            fixed (float* metrics_ptr = metrics)
            {
                GetPathMetricRangeNV(metricQueryMask, firstPathName, numPaths, stride, metrics_ptr);
            }
        }
        /// <inheritdoc cref="GetPathMetricRangeNV(PathMetricMask, uint, int, int, float*)"/>
        public static unsafe void GetPathMetricRangeNV(PathMetricMask metricQueryMask, uint firstPathName, int numPaths, int stride, float[] metrics)
        {
            fixed (float* metrics_ptr = metrics)
            {
                GetPathMetricRangeNV(metricQueryMask, firstPathName, numPaths, stride, metrics_ptr);
            }
        }
        /// <inheritdoc cref="GetPathMetricRangeNV(PathMetricMask, uint, int, int, float*)"/>
        public static unsafe float GetPathMetricRangeNV(PathMetricMask metricQueryMask, uint firstPathName, int numPaths, int stride)
        {
            float metrics;
            float* metrics_ptr = &metrics;
            {
                GetPathMetricRangeNV(metricQueryMask, firstPathName, numPaths, stride, metrics_ptr);
            }
            return metrics;
        }
        /// <inheritdoc cref="GetPathMetricRangeNV(PathMetricMask, uint, int, int, float*)"/>
        public static unsafe void GetPathMetricRangeNV(PathMetricMask metricQueryMask, uint firstPathName, int numPaths, int stride, out float metrics)
        {
            fixed (float* metrics_ptr = &metrics)
            {
                GetPathMetricRangeNV(metricQueryMask, firstPathName, numPaths, stride, metrics_ptr);
            }
        }
        /// <inheritdoc cref="GetPathMetricsNV(PathMetricMask, int, PathElementType, void*, uint, int, float*)"/>
        public static unsafe void GetPathMetricsNV(PathMetricMask metricQueryMask, int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, int stride, Span<float> metrics)
        {
            fixed (float* metrics_ptr = metrics)
            {
                void* paths_vptr = (void*)paths;
                GetPathMetricsNV(metricQueryMask, numPaths, pathNameType, paths_vptr, pathBase, stride, metrics_ptr);
            }
        }
        /// <inheritdoc cref="GetPathMetricsNV(PathMetricMask, int, PathElementType, void*, uint, int, float*)"/>
        public static unsafe void GetPathMetricsNV(PathMetricMask metricQueryMask, int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, int stride, float[] metrics)
        {
            fixed (float* metrics_ptr = metrics)
            {
                void* paths_vptr = (void*)paths;
                GetPathMetricsNV(metricQueryMask, numPaths, pathNameType, paths_vptr, pathBase, stride, metrics_ptr);
            }
        }
        /// <inheritdoc cref="GetPathMetricsNV(PathMetricMask, int, PathElementType, void*, uint, int, float*)"/>
        public static unsafe float GetPathMetricsNV(PathMetricMask metricQueryMask, int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, int stride)
        {
            float metrics;
            float* metrics_ptr = &metrics;
            {
                void* paths_vptr = (void*)paths;
                GetPathMetricsNV(metricQueryMask, numPaths, pathNameType, paths_vptr, pathBase, stride, metrics_ptr);
            }
            return metrics;
        }
        /// <inheritdoc cref="GetPathMetricsNV(PathMetricMask, int, PathElementType, void*, uint, int, float*)"/>
        public static unsafe void GetPathMetricsNV(PathMetricMask metricQueryMask, int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, int stride, out float metrics)
        {
            fixed (float* metrics_ptr = &metrics)
            {
                void* paths_vptr = (void*)paths;
                GetPathMetricsNV(metricQueryMask, numPaths, pathNameType, paths_vptr, pathBase, stride, metrics_ptr);
            }
        }
        /// <inheritdoc cref="GetPathMetricsNV(PathMetricMask, int, PathElementType, void*, uint, int, float*)"/>
        public static unsafe void GetPathMetricsNV<T1>(PathMetricMask metricQueryMask, int numPaths, PathElementType pathNameType, ReadOnlySpan<T1> paths, uint pathBase, int stride, Span<float> metrics)
            where T1 : unmanaged
        {
            fixed (float* metrics_ptr = metrics)
            {
                fixed (void* paths_ptr = paths)
                {
                    GetPathMetricsNV(metricQueryMask, numPaths, pathNameType, paths_ptr, pathBase, stride, metrics_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetPathMetricsNV(PathMetricMask, int, PathElementType, void*, uint, int, float*)"/>
        public static unsafe void GetPathMetricsNV<T1>(PathMetricMask metricQueryMask, int numPaths, PathElementType pathNameType, T1[] paths, uint pathBase, int stride, float[] metrics)
            where T1 : unmanaged
        {
            fixed (float* metrics_ptr = metrics)
            {
                fixed (void* paths_ptr = paths)
                {
                    GetPathMetricsNV(metricQueryMask, numPaths, pathNameType, paths_ptr, pathBase, stride, metrics_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetPathMetricsNV(PathMetricMask, int, PathElementType, void*, uint, int, float*)"/>
        public static unsafe float GetPathMetricsNV<T1>(PathMetricMask metricQueryMask, int numPaths, PathElementType pathNameType, ref readonly T1 paths, uint pathBase, int stride)
            where T1 : unmanaged
        {
            float metrics;
            float* metrics_ptr = &metrics;
            fixed (void* paths_ptr = &paths)
            {
                GetPathMetricsNV(metricQueryMask, numPaths, pathNameType, paths_ptr, pathBase, stride, metrics_ptr);
            }
            return metrics;
        }
        /// <inheritdoc cref="GetPathMetricsNV(PathMetricMask, int, PathElementType, void*, uint, int, float*)"/>
        public static unsafe void GetPathMetricsNV<T1>(PathMetricMask metricQueryMask, int numPaths, PathElementType pathNameType, ref readonly T1 paths, uint pathBase, int stride, out float metrics)
            where T1 : unmanaged
        {
            fixed (void* paths_ptr = &paths)
            fixed (float* metrics_ptr = &metrics)
            {
                GetPathMetricsNV(metricQueryMask, numPaths, pathNameType, paths_ptr, pathBase, stride, metrics_ptr);
            }
        }
        /// <inheritdoc cref="GetPathParameterfvNV(uint, PathParameter, float*)"/>
        public static unsafe void GetPathParameterfvNV(uint path, PathParameter pname, Span<float> value)
        {
            fixed (float* value_ptr = value)
            {
                GetPathParameterfvNV(path, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetPathParameterfvNV(uint, PathParameter, float*)"/>
        public static unsafe void GetPathParameterfvNV(uint path, PathParameter pname, float[] value)
        {
            fixed (float* value_ptr = value)
            {
                GetPathParameterfvNV(path, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetPathParameterfvNV(uint, PathParameter, float*)"/>
        public static unsafe void GetPathParameterfvNV(uint path, PathParameter pname, ref float value)
        {
            fixed (float* value_ptr = &value)
            {
                GetPathParameterfvNV(path, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetPathParameterivNV(uint, PathParameter, int*)"/>
        public static unsafe void GetPathParameterivNV(uint path, PathParameter pname, Span<int> value)
        {
            fixed (int* value_ptr = value)
            {
                GetPathParameterivNV(path, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetPathParameterivNV(uint, PathParameter, int*)"/>
        public static unsafe void GetPathParameterivNV(uint path, PathParameter pname, int[] value)
        {
            fixed (int* value_ptr = value)
            {
                GetPathParameterivNV(path, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetPathParameterivNV(uint, PathParameter, int*)"/>
        public static unsafe void GetPathParameterivNV(uint path, PathParameter pname, ref int value)
        {
            fixed (int* value_ptr = &value)
            {
                GetPathParameterivNV(path, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetPathSpacingNV(PathListMode, int, PathElementType, void*, uint, float, float, PathTransformType, float*)"/>
        public static unsafe void GetPathSpacingNV(PathListMode pathListMode, int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, float advanceScale, float kerningScale, PathTransformType transformType, Span<float> returnedSpacing)
        {
            fixed (float* returnedSpacing_ptr = returnedSpacing)
            {
                void* paths_vptr = (void*)paths;
                GetPathSpacingNV(pathListMode, numPaths, pathNameType, paths_vptr, pathBase, advanceScale, kerningScale, transformType, returnedSpacing_ptr);
            }
        }
        /// <inheritdoc cref="GetPathSpacingNV(PathListMode, int, PathElementType, void*, uint, float, float, PathTransformType, float*)"/>
        public static unsafe void GetPathSpacingNV(PathListMode pathListMode, int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, float advanceScale, float kerningScale, PathTransformType transformType, float[] returnedSpacing)
        {
            fixed (float* returnedSpacing_ptr = returnedSpacing)
            {
                void* paths_vptr = (void*)paths;
                GetPathSpacingNV(pathListMode, numPaths, pathNameType, paths_vptr, pathBase, advanceScale, kerningScale, transformType, returnedSpacing_ptr);
            }
        }
        /// <inheritdoc cref="GetPathSpacingNV(PathListMode, int, PathElementType, void*, uint, float, float, PathTransformType, float*)"/>
        public static unsafe float GetPathSpacingNV(PathListMode pathListMode, int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, float advanceScale, float kerningScale, PathTransformType transformType)
        {
            float returnedSpacing;
            float* returnedSpacing_ptr = &returnedSpacing;
            {
                void* paths_vptr = (void*)paths;
                GetPathSpacingNV(pathListMode, numPaths, pathNameType, paths_vptr, pathBase, advanceScale, kerningScale, transformType, returnedSpacing_ptr);
            }
            return returnedSpacing;
        }
        /// <inheritdoc cref="GetPathSpacingNV(PathListMode, int, PathElementType, void*, uint, float, float, PathTransformType, float*)"/>
        public static unsafe void GetPathSpacingNV(PathListMode pathListMode, int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, float advanceScale, float kerningScale, PathTransformType transformType, out float returnedSpacing)
        {
            fixed (float* returnedSpacing_ptr = &returnedSpacing)
            {
                void* paths_vptr = (void*)paths;
                GetPathSpacingNV(pathListMode, numPaths, pathNameType, paths_vptr, pathBase, advanceScale, kerningScale, transformType, returnedSpacing_ptr);
            }
        }
        /// <inheritdoc cref="GetPathSpacingNV(PathListMode, int, PathElementType, void*, uint, float, float, PathTransformType, float*)"/>
        public static unsafe void GetPathSpacingNV<T1>(PathListMode pathListMode, int numPaths, PathElementType pathNameType, ReadOnlySpan<T1> paths, uint pathBase, float advanceScale, float kerningScale, PathTransformType transformType, Span<float> returnedSpacing)
            where T1 : unmanaged
        {
            fixed (float* returnedSpacing_ptr = returnedSpacing)
            {
                fixed (void* paths_ptr = paths)
                {
                    GetPathSpacingNV(pathListMode, numPaths, pathNameType, paths_ptr, pathBase, advanceScale, kerningScale, transformType, returnedSpacing_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetPathSpacingNV(PathListMode, int, PathElementType, void*, uint, float, float, PathTransformType, float*)"/>
        public static unsafe void GetPathSpacingNV<T1>(PathListMode pathListMode, int numPaths, PathElementType pathNameType, T1[] paths, uint pathBase, float advanceScale, float kerningScale, PathTransformType transformType, float[] returnedSpacing)
            where T1 : unmanaged
        {
            fixed (float* returnedSpacing_ptr = returnedSpacing)
            {
                fixed (void* paths_ptr = paths)
                {
                    GetPathSpacingNV(pathListMode, numPaths, pathNameType, paths_ptr, pathBase, advanceScale, kerningScale, transformType, returnedSpacing_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetPathSpacingNV(PathListMode, int, PathElementType, void*, uint, float, float, PathTransformType, float*)"/>
        public static unsafe float GetPathSpacingNV<T1>(PathListMode pathListMode, int numPaths, PathElementType pathNameType, ref readonly T1 paths, uint pathBase, float advanceScale, float kerningScale, PathTransformType transformType)
            where T1 : unmanaged
        {
            float returnedSpacing;
            float* returnedSpacing_ptr = &returnedSpacing;
            fixed (void* paths_ptr = &paths)
            {
                GetPathSpacingNV(pathListMode, numPaths, pathNameType, paths_ptr, pathBase, advanceScale, kerningScale, transformType, returnedSpacing_ptr);
            }
            return returnedSpacing;
        }
        /// <inheritdoc cref="GetPathSpacingNV(PathListMode, int, PathElementType, void*, uint, float, float, PathTransformType, float*)"/>
        public static unsafe void GetPathSpacingNV<T1>(PathListMode pathListMode, int numPaths, PathElementType pathNameType, ref readonly T1 paths, uint pathBase, float advanceScale, float kerningScale, PathTransformType transformType, out float returnedSpacing)
            where T1 : unmanaged
        {
            fixed (void* paths_ptr = &paths)
            fixed (float* returnedSpacing_ptr = &returnedSpacing)
            {
                GetPathSpacingNV(pathListMode, numPaths, pathNameType, paths_ptr, pathBase, advanceScale, kerningScale, transformType, returnedSpacing_ptr);
            }
        }
        /// <inheritdoc cref="GetPathTexGenfvNV(TextureUnit, PathGenMode, float*)"/>
        public static unsafe void GetPathTexGenfvNV(TextureUnit texCoordSet, PathGenMode pname, Span<float> value)
        {
            fixed (float* value_ptr = value)
            {
                GetPathTexGenfvNV(texCoordSet, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetPathTexGenfvNV(TextureUnit, PathGenMode, float*)"/>
        public static unsafe void GetPathTexGenfvNV(TextureUnit texCoordSet, PathGenMode pname, float[] value)
        {
            fixed (float* value_ptr = value)
            {
                GetPathTexGenfvNV(texCoordSet, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetPathTexGenfvNV(TextureUnit, PathGenMode, float*)"/>
        public static unsafe float GetPathTexGenfvNV(TextureUnit texCoordSet, PathGenMode pname)
        {
            float value;
            float* value_ptr = &value;
            {
                GetPathTexGenfvNV(texCoordSet, pname, value_ptr);
            }
            return value;
        }
        /// <inheritdoc cref="GetPathTexGenfvNV(TextureUnit, PathGenMode, float*)"/>
        public static unsafe void GetPathTexGenfvNV(TextureUnit texCoordSet, PathGenMode pname, out float value)
        {
            fixed (float* value_ptr = &value)
            {
                GetPathTexGenfvNV(texCoordSet, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetPathTexGenivNV(TextureUnit, PathGenMode, int*)"/>
        public static unsafe void GetPathTexGenivNV(TextureUnit texCoordSet, PathGenMode pname, Span<int> value)
        {
            fixed (int* value_ptr = value)
            {
                GetPathTexGenivNV(texCoordSet, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetPathTexGenivNV(TextureUnit, PathGenMode, int*)"/>
        public static unsafe void GetPathTexGenivNV(TextureUnit texCoordSet, PathGenMode pname, int[] value)
        {
            fixed (int* value_ptr = value)
            {
                GetPathTexGenivNV(texCoordSet, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetPathTexGenivNV(TextureUnit, PathGenMode, int*)"/>
        public static unsafe int GetPathTexGenivNV(TextureUnit texCoordSet, PathGenMode pname)
        {
            int value;
            int* value_ptr = &value;
            {
                GetPathTexGenivNV(texCoordSet, pname, value_ptr);
            }
            return value;
        }
        /// <inheritdoc cref="GetPathTexGenivNV(TextureUnit, PathGenMode, int*)"/>
        public static unsafe void GetPathTexGenivNV(TextureUnit texCoordSet, PathGenMode pname, out int value)
        {
            fixed (int* value_ptr = &value)
            {
                GetPathTexGenivNV(texCoordSet, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="GetProgramResourcefvNV(int, ProgramInterface, uint, int, All*, int, int*, float*)"/>
        public static unsafe void GetProgramResourcefvNV(int program, ProgramInterface programInterface, uint index, int propCount, ReadOnlySpan<All> props, int count, out int length, Span<float> parameters)
        {
            fixed (int* length_ptr = &length)
            {
                fixed (float* parameters_ptr = parameters)
                {
                    fixed (All* props_ptr = props)
                    {
                        GetProgramResourcefvNV(program, programInterface, index, propCount, props_ptr, count, length_ptr, parameters_ptr);
                    }
                }
            }
        }
        /// <inheritdoc cref="GetProgramResourcefvNV(int, ProgramInterface, uint, int, All*, int, int*, float*)"/>
        public static unsafe void GetProgramResourcefvNV(int program, ProgramInterface programInterface, uint index, int propCount, All[] props, int count, out int length, float[] parameters)
        {
            fixed (int* length_ptr = &length)
            {
                fixed (float* parameters_ptr = parameters)
                {
                    fixed (All* props_ptr = props)
                    {
                        GetProgramResourcefvNV(program, programInterface, index, propCount, props_ptr, count, length_ptr, parameters_ptr);
                    }
                }
            }
        }
        /// <inheritdoc cref="GetProgramResourcefvNV(int, ProgramInterface, uint, int, All*, int, int*, float*)"/>
        public static unsafe void GetProgramResourcefvNV(int program, ProgramInterface programInterface, uint index, int propCount, ref readonly All props, int count, out int length, ref float parameters)
        {
            fixed (All* props_ptr = &props)
            fixed (int* length_ptr = &length)
            fixed (float* parameters_ptr = &parameters)
            {
                GetProgramResourcefvNV(program, programInterface, index, propCount, props_ptr, count, length_ptr, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSemaphoreParameterivNV(uint, SemaphoreParameterName, int*)"/>
        public static unsafe void GetSemaphoreParameterivNV(uint semaphore, SemaphoreParameterName pname, Span<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetSemaphoreParameterivNV(semaphore, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSemaphoreParameterivNV(uint, SemaphoreParameterName, int*)"/>
        public static unsafe void GetSemaphoreParameterivNV(uint semaphore, SemaphoreParameterName pname, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetSemaphoreParameterivNV(semaphore, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSemaphoreParameterivNV(uint, SemaphoreParameterName, int*)"/>
        public static unsafe void GetSemaphoreParameterivNV(uint semaphore, SemaphoreParameterName pname, ref int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                GetSemaphoreParameterivNV(semaphore, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetShadingRateImagePaletteNV(uint, uint, All*)"/>
        public static unsafe All GetShadingRateImagePaletteNV(uint viewport, uint entry)
        {
            All rate;
            All* rate_ptr = &rate;
            {
                GetShadingRateImagePaletteNV(viewport, entry, rate_ptr);
            }
            return rate;
        }
        /// <inheritdoc cref="GetShadingRateImagePaletteNV(uint, uint, All*)"/>
        public static unsafe void GetShadingRateImagePaletteNV(uint viewport, uint entry, out All rate)
        {
            fixed (All* rate_ptr = &rate)
            {
                GetShadingRateImagePaletteNV(viewport, entry, rate_ptr);
            }
        }
        /// <inheritdoc cref="GetShadingRateSampleLocationivNV(All, uint, uint, int*)"/>
        public static unsafe void GetShadingRateSampleLocationivNV(All rate, uint samples, uint index, Span<int> location)
        {
            fixed (int* location_ptr = location)
            {
                GetShadingRateSampleLocationivNV(rate, samples, index, location_ptr);
            }
        }
        /// <inheritdoc cref="GetShadingRateSampleLocationivNV(All, uint, uint, int*)"/>
        public static unsafe void GetShadingRateSampleLocationivNV(All rate, uint samples, uint index, int[] location)
        {
            fixed (int* location_ptr = location)
            {
                GetShadingRateSampleLocationivNV(rate, samples, index, location_ptr);
            }
        }
        /// <inheritdoc cref="GetShadingRateSampleLocationivNV(All, uint, uint, int*)"/>
        public static unsafe void GetShadingRateSampleLocationivNV(All rate, uint samples, uint index, ref int location)
        {
            fixed (int* location_ptr = &location)
            {
                GetShadingRateSampleLocationivNV(rate, samples, index, location_ptr);
            }
        }
        /// <inheritdoc cref="GetUniformi64vNV(int, int, long*)"/>
        public static unsafe void GetUniformi64vNV(int program, int location, Span<long> parameters)
        {
            fixed (long* parameters_ptr = parameters)
            {
                GetUniformi64vNV(program, location, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetUniformi64vNV(int, int, long*)"/>
        public static unsafe void GetUniformi64vNV(int program, int location, long[] parameters)
        {
            fixed (long* parameters_ptr = parameters)
            {
                GetUniformi64vNV(program, location, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetUniformi64vNV(int, int, long*)"/>
        public static unsafe long GetUniformi64vNV(int program, int location)
        {
            long parameters;
            long* parameters_ptr = &parameters;
            {
                GetUniformi64vNV(program, location, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetUniformi64vNV(int, int, long*)"/>
        public static unsafe void GetUniformi64vNV(int program, int location, out long parameters)
        {
            fixed (long* parameters_ptr = &parameters)
            {
                GetUniformi64vNV(program, location, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetVkProcAddrNV(byte*)"/>
        public static unsafe IntPtr GetVkProcAddrNV(string name)
        {
            byte* name_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(name);
            var returnValue = GetVkProcAddrNV(name_ptr);
            Marshal.FreeCoTaskMem((IntPtr)name_ptr);
            return returnValue;
        }
        /// <inheritdoc cref="MatrixLoad3x2fNV(All, float*)"/>
        public static unsafe void MatrixLoad3x2fNV(All matrixMode, ReadOnlySpan<float> m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixLoad3x2fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoad3x2fNV(All, float*)"/>
        public static unsafe void MatrixLoad3x2fNV(All matrixMode, float[] m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixLoad3x2fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoad3x2fNV(All, float*)"/>
        public static unsafe void MatrixLoad3x2fNV(All matrixMode, ref readonly float m)
        {
            fixed (float* m_ptr = &m)
            {
                MatrixLoad3x2fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoad3x3fNV(All, float*)"/>
        public static unsafe void MatrixLoad3x3fNV(All matrixMode, ReadOnlySpan<float> m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixLoad3x3fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoad3x3fNV(All, float*)"/>
        public static unsafe void MatrixLoad3x3fNV(All matrixMode, float[] m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixLoad3x3fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoad3x3fNV(All, float*)"/>
        public static unsafe void MatrixLoad3x3fNV(All matrixMode, ref readonly float m)
        {
            fixed (float* m_ptr = &m)
            {
                MatrixLoad3x3fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoaddEXT(MatrixMode, double*)"/>
        public static unsafe void MatrixLoaddEXT(MatrixMode mode, ReadOnlySpan<double> m)
        {
            fixed (double* m_ptr = m)
            {
                MatrixLoaddEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoaddEXT(MatrixMode, double*)"/>
        public static unsafe void MatrixLoaddEXT(MatrixMode mode, double[] m)
        {
            fixed (double* m_ptr = m)
            {
                MatrixLoaddEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoaddEXT(MatrixMode, double*)"/>
        public static unsafe void MatrixLoaddEXT(MatrixMode mode, ref readonly double m)
        {
            fixed (double* m_ptr = &m)
            {
                MatrixLoaddEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoadfEXT(MatrixMode, float*)"/>
        public static unsafe void MatrixLoadfEXT(MatrixMode mode, ReadOnlySpan<float> m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixLoadfEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoadfEXT(MatrixMode, float*)"/>
        public static unsafe void MatrixLoadfEXT(MatrixMode mode, float[] m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixLoadfEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoadfEXT(MatrixMode, float*)"/>
        public static unsafe void MatrixLoadfEXT(MatrixMode mode, ref readonly float m)
        {
            fixed (float* m_ptr = &m)
            {
                MatrixLoadfEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoadTranspose3x3fNV(All, float*)"/>
        public static unsafe void MatrixLoadTranspose3x3fNV(All matrixMode, ReadOnlySpan<float> m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixLoadTranspose3x3fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoadTranspose3x3fNV(All, float*)"/>
        public static unsafe void MatrixLoadTranspose3x3fNV(All matrixMode, float[] m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixLoadTranspose3x3fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoadTranspose3x3fNV(All, float*)"/>
        public static unsafe void MatrixLoadTranspose3x3fNV(All matrixMode, ref readonly float m)
        {
            fixed (float* m_ptr = &m)
            {
                MatrixLoadTranspose3x3fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoadTransposedEXT(MatrixMode, double*)"/>
        public static unsafe void MatrixLoadTransposedEXT(MatrixMode mode, ReadOnlySpan<double> m)
        {
            fixed (double* m_ptr = m)
            {
                MatrixLoadTransposedEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoadTransposedEXT(MatrixMode, double*)"/>
        public static unsafe void MatrixLoadTransposedEXT(MatrixMode mode, double[] m)
        {
            fixed (double* m_ptr = m)
            {
                MatrixLoadTransposedEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoadTransposedEXT(MatrixMode, double*)"/>
        public static unsafe void MatrixLoadTransposedEXT(MatrixMode mode, ref readonly double m)
        {
            fixed (double* m_ptr = &m)
            {
                MatrixLoadTransposedEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoadTransposefEXT(MatrixMode, float*)"/>
        public static unsafe void MatrixLoadTransposefEXT(MatrixMode mode, ReadOnlySpan<float> m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixLoadTransposefEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoadTransposefEXT(MatrixMode, float*)"/>
        public static unsafe void MatrixLoadTransposefEXT(MatrixMode mode, float[] m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixLoadTransposefEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixLoadTransposefEXT(MatrixMode, float*)"/>
        public static unsafe void MatrixLoadTransposefEXT(MatrixMode mode, ref readonly float m)
        {
            fixed (float* m_ptr = &m)
            {
                MatrixLoadTransposefEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMult3x2fNV(All, float*)"/>
        public static unsafe void MatrixMult3x2fNV(All matrixMode, ReadOnlySpan<float> m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixMult3x2fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMult3x2fNV(All, float*)"/>
        public static unsafe void MatrixMult3x2fNV(All matrixMode, float[] m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixMult3x2fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMult3x2fNV(All, float*)"/>
        public static unsafe void MatrixMult3x2fNV(All matrixMode, ref readonly float m)
        {
            fixed (float* m_ptr = &m)
            {
                MatrixMult3x2fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMult3x3fNV(All, float*)"/>
        public static unsafe void MatrixMult3x3fNV(All matrixMode, ReadOnlySpan<float> m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixMult3x3fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMult3x3fNV(All, float*)"/>
        public static unsafe void MatrixMult3x3fNV(All matrixMode, float[] m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixMult3x3fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMult3x3fNV(All, float*)"/>
        public static unsafe void MatrixMult3x3fNV(All matrixMode, ref readonly float m)
        {
            fixed (float* m_ptr = &m)
            {
                MatrixMult3x3fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMultdEXT(MatrixMode, double*)"/>
        public static unsafe void MatrixMultdEXT(MatrixMode mode, ReadOnlySpan<double> m)
        {
            fixed (double* m_ptr = m)
            {
                MatrixMultdEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMultdEXT(MatrixMode, double*)"/>
        public static unsafe void MatrixMultdEXT(MatrixMode mode, double[] m)
        {
            fixed (double* m_ptr = m)
            {
                MatrixMultdEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMultdEXT(MatrixMode, double*)"/>
        public static unsafe void MatrixMultdEXT(MatrixMode mode, ref readonly double m)
        {
            fixed (double* m_ptr = &m)
            {
                MatrixMultdEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMultfEXT(MatrixMode, float*)"/>
        public static unsafe void MatrixMultfEXT(MatrixMode mode, ReadOnlySpan<float> m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixMultfEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMultfEXT(MatrixMode, float*)"/>
        public static unsafe void MatrixMultfEXT(MatrixMode mode, float[] m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixMultfEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMultfEXT(MatrixMode, float*)"/>
        public static unsafe void MatrixMultfEXT(MatrixMode mode, ref readonly float m)
        {
            fixed (float* m_ptr = &m)
            {
                MatrixMultfEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMultTranspose3x3fNV(All, float*)"/>
        public static unsafe void MatrixMultTranspose3x3fNV(All matrixMode, ReadOnlySpan<float> m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixMultTranspose3x3fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMultTranspose3x3fNV(All, float*)"/>
        public static unsafe void MatrixMultTranspose3x3fNV(All matrixMode, float[] m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixMultTranspose3x3fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMultTranspose3x3fNV(All, float*)"/>
        public static unsafe void MatrixMultTranspose3x3fNV(All matrixMode, ref readonly float m)
        {
            fixed (float* m_ptr = &m)
            {
                MatrixMultTranspose3x3fNV(matrixMode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMultTransposedEXT(MatrixMode, double*)"/>
        public static unsafe void MatrixMultTransposedEXT(MatrixMode mode, ReadOnlySpan<double> m)
        {
            fixed (double* m_ptr = m)
            {
                MatrixMultTransposedEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMultTransposedEXT(MatrixMode, double*)"/>
        public static unsafe void MatrixMultTransposedEXT(MatrixMode mode, double[] m)
        {
            fixed (double* m_ptr = m)
            {
                MatrixMultTransposedEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMultTransposedEXT(MatrixMode, double*)"/>
        public static unsafe void MatrixMultTransposedEXT(MatrixMode mode, ref readonly double m)
        {
            fixed (double* m_ptr = &m)
            {
                MatrixMultTransposedEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMultTransposefEXT(MatrixMode, float*)"/>
        public static unsafe void MatrixMultTransposefEXT(MatrixMode mode, ReadOnlySpan<float> m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixMultTransposefEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMultTransposefEXT(MatrixMode, float*)"/>
        public static unsafe void MatrixMultTransposefEXT(MatrixMode mode, float[] m)
        {
            fixed (float* m_ptr = m)
            {
                MatrixMultTransposefEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="MatrixMultTransposefEXT(MatrixMode, float*)"/>
        public static unsafe void MatrixMultTransposefEXT(MatrixMode mode, ref readonly float m)
        {
            fixed (float* m_ptr = &m)
            {
                MatrixMultTransposefEXT(mode, m_ptr);
            }
        }
        /// <inheritdoc cref="NamedFramebufferSampleLocationsfvNV(int, uint, int, float*)"/>
        public static unsafe void NamedFramebufferSampleLocationsfvNV(int framebuffer, uint start, int count, ReadOnlySpan<float> v)
        {
            fixed (float* v_ptr = v)
            {
                NamedFramebufferSampleLocationsfvNV(framebuffer, start, count, v_ptr);
            }
        }
        /// <inheritdoc cref="NamedFramebufferSampleLocationsfvNV(int, uint, int, float*)"/>
        public static unsafe void NamedFramebufferSampleLocationsfvNV(int framebuffer, uint start, int count, float[] v)
        {
            fixed (float* v_ptr = v)
            {
                NamedFramebufferSampleLocationsfvNV(framebuffer, start, count, v_ptr);
            }
        }
        /// <inheritdoc cref="NamedFramebufferSampleLocationsfvNV(int, uint, int, float*)"/>
        public static unsafe void NamedFramebufferSampleLocationsfvNV(int framebuffer, uint start, int count, ref readonly float v)
        {
            fixed (float* v_ptr = &v)
            {
                NamedFramebufferSampleLocationsfvNV(framebuffer, start, count, v_ptr);
            }
        }
        /// <inheritdoc cref="PathColorGenNV(PathColor, PathGenMode, PathColorFormat, float*)"/>
        public static unsafe void PathColorGenNV(PathColor color, PathGenMode genMode, PathColorFormat colorFormat, ReadOnlySpan<float> coeffs)
        {
            fixed (float* coeffs_ptr = coeffs)
            {
                PathColorGenNV(color, genMode, colorFormat, coeffs_ptr);
            }
        }
        /// <inheritdoc cref="PathColorGenNV(PathColor, PathGenMode, PathColorFormat, float*)"/>
        public static unsafe void PathColorGenNV(PathColor color, PathGenMode genMode, PathColorFormat colorFormat, float[] coeffs)
        {
            fixed (float* coeffs_ptr = coeffs)
            {
                PathColorGenNV(color, genMode, colorFormat, coeffs_ptr);
            }
        }
        /// <inheritdoc cref="PathColorGenNV(PathColor, PathGenMode, PathColorFormat, float*)"/>
        public static unsafe void PathColorGenNV(PathColor color, PathGenMode genMode, PathColorFormat colorFormat, ref readonly float coeffs)
        {
            fixed (float* coeffs_ptr = &coeffs)
            {
                PathColorGenNV(color, genMode, colorFormat, coeffs_ptr);
            }
        }
        /// <inheritdoc cref="PathCommandsNV(uint, int, byte*, int, PathCoordType, void*)"/>
        public static unsafe void PathCommandsNV(uint path, int numCommands, ReadOnlySpan<byte> commands, int numCoords, PathCoordType coordType, IntPtr coords)
        {
            fixed (byte* commands_ptr = commands)
            {
                void* coords_vptr = (void*)coords;
                PathCommandsNV(path, numCommands, commands_ptr, numCoords, coordType, coords_vptr);
            }
        }
        /// <inheritdoc cref="PathCommandsNV(uint, int, byte*, int, PathCoordType, void*)"/>
        public static unsafe void PathCommandsNV(uint path, int numCommands, byte[] commands, int numCoords, PathCoordType coordType, IntPtr coords)
        {
            fixed (byte* commands_ptr = commands)
            {
                void* coords_vptr = (void*)coords;
                PathCommandsNV(path, numCommands, commands_ptr, numCoords, coordType, coords_vptr);
            }
        }
        /// <inheritdoc cref="PathCommandsNV(uint, int, byte*, int, PathCoordType, void*)"/>
        public static unsafe void PathCommandsNV(uint path, int numCommands, ref readonly byte commands, int numCoords, PathCoordType coordType, IntPtr coords)
        {
            fixed (byte* commands_ptr = &commands)
            {
                void* coords_vptr = (void*)coords;
                PathCommandsNV(path, numCommands, commands_ptr, numCoords, coordType, coords_vptr);
            }
        }
        /// <inheritdoc cref="PathCommandsNV(uint, int, byte*, int, PathCoordType, void*)"/>
        public static unsafe void PathCommandsNV<T1>(uint path, int numCommands, ReadOnlySpan<byte> commands, int numCoords, PathCoordType coordType, ReadOnlySpan<T1> coords)
            where T1 : unmanaged
        {
            fixed (void* coords_ptr = coords)
            {
                fixed (byte* commands_ptr = commands)
                {
                    PathCommandsNV(path, numCommands, commands_ptr, numCoords, coordType, coords_ptr);
                }
            }
        }
        /// <inheritdoc cref="PathCommandsNV(uint, int, byte*, int, PathCoordType, void*)"/>
        public static unsafe void PathCommandsNV<T1>(uint path, int numCommands, byte[] commands, int numCoords, PathCoordType coordType, T1[] coords)
            where T1 : unmanaged
        {
            fixed (void* coords_ptr = coords)
            {
                fixed (byte* commands_ptr = commands)
                {
                    PathCommandsNV(path, numCommands, commands_ptr, numCoords, coordType, coords_ptr);
                }
            }
        }
        /// <inheritdoc cref="PathCommandsNV(uint, int, byte*, int, PathCoordType, void*)"/>
        public static unsafe void PathCommandsNV<T1>(uint path, int numCommands, ref readonly byte commands, int numCoords, PathCoordType coordType, ref readonly T1 coords)
            where T1 : unmanaged
        {
            fixed (byte* commands_ptr = &commands)
            fixed (void* coords_ptr = &coords)
            {
                PathCommandsNV(path, numCommands, commands_ptr, numCoords, coordType, coords_ptr);
            }
        }
        /// <inheritdoc cref="PathCoordsNV(uint, int, PathCoordType, void*)"/>
        public static unsafe void PathCoordsNV(uint path, int numCoords, PathCoordType coordType, IntPtr coords)
        {
            void* coords_vptr = (void*)coords;
            PathCoordsNV(path, numCoords, coordType, coords_vptr);
        }
        /// <inheritdoc cref="PathCoordsNV(uint, int, PathCoordType, void*)"/>
        public static unsafe void PathCoordsNV<T1>(uint path, int numCoords, PathCoordType coordType, ReadOnlySpan<T1> coords)
            where T1 : unmanaged
        {
            fixed (void* coords_ptr = coords)
            {
                PathCoordsNV(path, numCoords, coordType, coords_ptr);
            }
        }
        /// <inheritdoc cref="PathCoordsNV(uint, int, PathCoordType, void*)"/>
        public static unsafe void PathCoordsNV<T1>(uint path, int numCoords, PathCoordType coordType, T1[] coords)
            where T1 : unmanaged
        {
            fixed (void* coords_ptr = coords)
            {
                PathCoordsNV(path, numCoords, coordType, coords_ptr);
            }
        }
        /// <inheritdoc cref="PathCoordsNV(uint, int, PathCoordType, void*)"/>
        public static unsafe void PathCoordsNV<T1>(uint path, int numCoords, PathCoordType coordType, ref readonly T1 coords)
            where T1 : unmanaged
        {
            fixed (void* coords_ptr = &coords)
            {
                PathCoordsNV(path, numCoords, coordType, coords_ptr);
            }
        }
        /// <inheritdoc cref="PathDashArrayNV(uint, int, float*)"/>
        public static unsafe void PathDashArrayNV(uint path, int dashCount, ReadOnlySpan<float> dashArray)
        {
            fixed (float* dashArray_ptr = dashArray)
            {
                PathDashArrayNV(path, dashCount, dashArray_ptr);
            }
        }
        /// <inheritdoc cref="PathDashArrayNV(uint, int, float*)"/>
        public static unsafe void PathDashArrayNV(uint path, int dashCount, float[] dashArray)
        {
            fixed (float* dashArray_ptr = dashArray)
            {
                PathDashArrayNV(path, dashCount, dashArray_ptr);
            }
        }
        /// <inheritdoc cref="PathDashArrayNV(uint, int, float*)"/>
        public static unsafe void PathDashArrayNV(uint path, int dashCount, ref readonly float dashArray)
        {
            fixed (float* dashArray_ptr = &dashArray)
            {
                PathDashArrayNV(path, dashCount, dashArray_ptr);
            }
        }
        /// <inheritdoc cref="PathGlyphIndexArrayNV(uint, All, void*, PathFontStyle, uint, int, uint, float)"/>
        public static unsafe All PathGlyphIndexArrayNV(uint firstPathName, All fontTarget, IntPtr fontName, PathFontStyle fontStyle, uint firstGlyphIndex, int numGlyphs, uint pathParameterTemplate, float emScale)
        {
            void* fontName_vptr = (void*)fontName;
            var returnValue = PathGlyphIndexArrayNV(firstPathName, fontTarget, fontName_vptr, fontStyle, firstGlyphIndex, numGlyphs, pathParameterTemplate, emScale);
            return returnValue;
        }
        /// <inheritdoc cref="PathGlyphIndexArrayNV(uint, All, void*, PathFontStyle, uint, int, uint, float)"/>
        public static unsafe All PathGlyphIndexArrayNV<T1>(uint firstPathName, All fontTarget, ReadOnlySpan<T1> fontName, PathFontStyle fontStyle, uint firstGlyphIndex, int numGlyphs, uint pathParameterTemplate, float emScale)
            where T1 : unmanaged
        {
            All returnValue;
            fixed (void* fontName_ptr = fontName)
            {
                returnValue = PathGlyphIndexArrayNV(firstPathName, fontTarget, fontName_ptr, fontStyle, firstGlyphIndex, numGlyphs, pathParameterTemplate, emScale);
            }
            return returnValue;
        }
        /// <inheritdoc cref="PathGlyphIndexArrayNV(uint, All, void*, PathFontStyle, uint, int, uint, float)"/>
        public static unsafe All PathGlyphIndexArrayNV<T1>(uint firstPathName, All fontTarget, T1[] fontName, PathFontStyle fontStyle, uint firstGlyphIndex, int numGlyphs, uint pathParameterTemplate, float emScale)
            where T1 : unmanaged
        {
            All returnValue;
            fixed (void* fontName_ptr = fontName)
            {
                returnValue = PathGlyphIndexArrayNV(firstPathName, fontTarget, fontName_ptr, fontStyle, firstGlyphIndex, numGlyphs, pathParameterTemplate, emScale);
            }
            return returnValue;
        }
        /// <inheritdoc cref="PathGlyphIndexArrayNV(uint, All, void*, PathFontStyle, uint, int, uint, float)"/>
        public static unsafe All PathGlyphIndexArrayNV<T1>(uint firstPathName, All fontTarget, ref readonly T1 fontName, PathFontStyle fontStyle, uint firstGlyphIndex, int numGlyphs, uint pathParameterTemplate, float emScale)
            where T1 : unmanaged
        {
            All returnValue;
            fixed (void* fontName_ptr = &fontName)
            {
                returnValue = PathGlyphIndexArrayNV(firstPathName, fontTarget, fontName_ptr, fontStyle, firstGlyphIndex, numGlyphs, pathParameterTemplate, emScale);
            }
            return returnValue;
        }
        /// <inheritdoc cref="PathGlyphIndexRangeNV(All, void*, PathFontStyle, uint, float, uint*)"/>
        public static unsafe All PathGlyphIndexRangeNV(All fontTarget, IntPtr fontName, PathFontStyle fontStyle, uint pathParameterTemplate, float emScale, Span<uint> baseAndCount)
        {
            All returnValue;
            fixed (uint* baseAndCount_ptr = baseAndCount)
            {
                void* fontName_vptr = (void*)fontName;
                returnValue = PathGlyphIndexRangeNV(fontTarget, fontName_vptr, fontStyle, pathParameterTemplate, emScale, baseAndCount_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="PathGlyphIndexRangeNV(All, void*, PathFontStyle, uint, float, uint*)"/>
        public static unsafe All PathGlyphIndexRangeNV(All fontTarget, IntPtr fontName, PathFontStyle fontStyle, uint pathParameterTemplate, float emScale, uint[] baseAndCount)
        {
            All returnValue;
            fixed (uint* baseAndCount_ptr = baseAndCount)
            {
                void* fontName_vptr = (void*)fontName;
                returnValue = PathGlyphIndexRangeNV(fontTarget, fontName_vptr, fontStyle, pathParameterTemplate, emScale, baseAndCount_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="PathGlyphIndexRangeNV(All, void*, PathFontStyle, uint, float, uint*)"/>
        public static unsafe All PathGlyphIndexRangeNV(All fontTarget, IntPtr fontName, PathFontStyle fontStyle, uint pathParameterTemplate, float emScale, ref uint baseAndCount)
        {
            All returnValue;
            fixed (uint* baseAndCount_ptr = &baseAndCount)
            {
                void* fontName_vptr = (void*)fontName;
                returnValue = PathGlyphIndexRangeNV(fontTarget, fontName_vptr, fontStyle, pathParameterTemplate, emScale, baseAndCount_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="PathGlyphIndexRangeNV(All, void*, PathFontStyle, uint, float, uint*)"/>
        public static unsafe All PathGlyphIndexRangeNV<T1>(All fontTarget, ReadOnlySpan<T1> fontName, PathFontStyle fontStyle, uint pathParameterTemplate, float emScale, Span<uint> baseAndCount)
            where T1 : unmanaged
        {
            All returnValue;
            fixed (uint* baseAndCount_ptr = baseAndCount)
            {
                fixed (void* fontName_ptr = fontName)
                {
                    returnValue = PathGlyphIndexRangeNV(fontTarget, fontName_ptr, fontStyle, pathParameterTemplate, emScale, baseAndCount_ptr);
                }
            }
            return returnValue;
        }
        /// <inheritdoc cref="PathGlyphIndexRangeNV(All, void*, PathFontStyle, uint, float, uint*)"/>
        public static unsafe All PathGlyphIndexRangeNV<T1>(All fontTarget, T1[] fontName, PathFontStyle fontStyle, uint pathParameterTemplate, float emScale, uint[] baseAndCount)
            where T1 : unmanaged
        {
            All returnValue;
            fixed (uint* baseAndCount_ptr = baseAndCount)
            {
                fixed (void* fontName_ptr = fontName)
                {
                    returnValue = PathGlyphIndexRangeNV(fontTarget, fontName_ptr, fontStyle, pathParameterTemplate, emScale, baseAndCount_ptr);
                }
            }
            return returnValue;
        }
        /// <inheritdoc cref="PathGlyphIndexRangeNV(All, void*, PathFontStyle, uint, float, uint*)"/>
        public static unsafe All PathGlyphIndexRangeNV<T1>(All fontTarget, ref readonly T1 fontName, PathFontStyle fontStyle, uint pathParameterTemplate, float emScale, ref uint baseAndCount)
            where T1 : unmanaged
        {
            All returnValue;
            fixed (void* fontName_ptr = &fontName)
            fixed (uint* baseAndCount_ptr = &baseAndCount)
            {
                returnValue = PathGlyphIndexRangeNV(fontTarget, fontName_ptr, fontStyle, pathParameterTemplate, emScale, baseAndCount_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="PathGlyphRangeNV(uint, PathFontTarget, void*, PathFontStyle, uint, int, PathHandleMissingGlyphs, uint, float)"/>
        public static unsafe void PathGlyphRangeNV(uint firstPathName, PathFontTarget fontTarget, IntPtr fontName, PathFontStyle fontStyle, uint firstGlyph, int numGlyphs, PathHandleMissingGlyphs handleMissingGlyphs, uint pathParameterTemplate, float emScale)
        {
            void* fontName_vptr = (void*)fontName;
            PathGlyphRangeNV(firstPathName, fontTarget, fontName_vptr, fontStyle, firstGlyph, numGlyphs, handleMissingGlyphs, pathParameterTemplate, emScale);
        }
        /// <inheritdoc cref="PathGlyphRangeNV(uint, PathFontTarget, void*, PathFontStyle, uint, int, PathHandleMissingGlyphs, uint, float)"/>
        public static unsafe void PathGlyphRangeNV<T1>(uint firstPathName, PathFontTarget fontTarget, ReadOnlySpan<T1> fontName, PathFontStyle fontStyle, uint firstGlyph, int numGlyphs, PathHandleMissingGlyphs handleMissingGlyphs, uint pathParameterTemplate, float emScale)
            where T1 : unmanaged
        {
            fixed (void* fontName_ptr = fontName)
            {
                PathGlyphRangeNV(firstPathName, fontTarget, fontName_ptr, fontStyle, firstGlyph, numGlyphs, handleMissingGlyphs, pathParameterTemplate, emScale);
            }
        }
        /// <inheritdoc cref="PathGlyphRangeNV(uint, PathFontTarget, void*, PathFontStyle, uint, int, PathHandleMissingGlyphs, uint, float)"/>
        public static unsafe void PathGlyphRangeNV<T1>(uint firstPathName, PathFontTarget fontTarget, T1[] fontName, PathFontStyle fontStyle, uint firstGlyph, int numGlyphs, PathHandleMissingGlyphs handleMissingGlyphs, uint pathParameterTemplate, float emScale)
            where T1 : unmanaged
        {
            fixed (void* fontName_ptr = fontName)
            {
                PathGlyphRangeNV(firstPathName, fontTarget, fontName_ptr, fontStyle, firstGlyph, numGlyphs, handleMissingGlyphs, pathParameterTemplate, emScale);
            }
        }
        /// <inheritdoc cref="PathGlyphRangeNV(uint, PathFontTarget, void*, PathFontStyle, uint, int, PathHandleMissingGlyphs, uint, float)"/>
        public static unsafe void PathGlyphRangeNV<T1>(uint firstPathName, PathFontTarget fontTarget, ref readonly T1 fontName, PathFontStyle fontStyle, uint firstGlyph, int numGlyphs, PathHandleMissingGlyphs handleMissingGlyphs, uint pathParameterTemplate, float emScale)
            where T1 : unmanaged
        {
            fixed (void* fontName_ptr = &fontName)
            {
                PathGlyphRangeNV(firstPathName, fontTarget, fontName_ptr, fontStyle, firstGlyph, numGlyphs, handleMissingGlyphs, pathParameterTemplate, emScale);
            }
        }
        /// <inheritdoc cref="PathGlyphsNV(uint, PathFontTarget, void*, PathFontStyle, int, PathElementType, void*, PathHandleMissingGlyphs, uint, float)"/>
        public static unsafe void PathGlyphsNV(uint firstPathName, PathFontTarget fontTarget, IntPtr fontName, PathFontStyle fontStyle, int numGlyphs, PathElementType type, IntPtr charcodes, PathHandleMissingGlyphs handleMissingGlyphs, uint pathParameterTemplate, float emScale)
        {
            void* fontName_vptr = (void*)fontName;
            void* charcodes_vptr = (void*)charcodes;
            PathGlyphsNV(firstPathName, fontTarget, fontName_vptr, fontStyle, numGlyphs, type, charcodes_vptr, handleMissingGlyphs, pathParameterTemplate, emScale);
        }
        /// <inheritdoc cref="PathGlyphsNV(uint, PathFontTarget, void*, PathFontStyle, int, PathElementType, void*, PathHandleMissingGlyphs, uint, float)"/>
        public static unsafe void PathGlyphsNV<T1, T2>(uint firstPathName, PathFontTarget fontTarget, ReadOnlySpan<T1> fontName, PathFontStyle fontStyle, int numGlyphs, PathElementType type, ReadOnlySpan<T2> charcodes, PathHandleMissingGlyphs handleMissingGlyphs, uint pathParameterTemplate, float emScale)
            where T1 : unmanaged
            where T2 : unmanaged
        {
            fixed (void* charcodes_ptr = charcodes)
            {
                fixed (void* fontName_ptr = fontName)
                {
                    PathGlyphsNV(firstPathName, fontTarget, fontName_ptr, fontStyle, numGlyphs, type, charcodes_ptr, handleMissingGlyphs, pathParameterTemplate, emScale);
                }
            }
        }
        /// <inheritdoc cref="PathGlyphsNV(uint, PathFontTarget, void*, PathFontStyle, int, PathElementType, void*, PathHandleMissingGlyphs, uint, float)"/>
        public static unsafe void PathGlyphsNV<T1, T2>(uint firstPathName, PathFontTarget fontTarget, T1[] fontName, PathFontStyle fontStyle, int numGlyphs, PathElementType type, T2[] charcodes, PathHandleMissingGlyphs handleMissingGlyphs, uint pathParameterTemplate, float emScale)
            where T1 : unmanaged
            where T2 : unmanaged
        {
            fixed (void* charcodes_ptr = charcodes)
            {
                fixed (void* fontName_ptr = fontName)
                {
                    PathGlyphsNV(firstPathName, fontTarget, fontName_ptr, fontStyle, numGlyphs, type, charcodes_ptr, handleMissingGlyphs, pathParameterTemplate, emScale);
                }
            }
        }
        /// <inheritdoc cref="PathGlyphsNV(uint, PathFontTarget, void*, PathFontStyle, int, PathElementType, void*, PathHandleMissingGlyphs, uint, float)"/>
        public static unsafe void PathGlyphsNV<T1, T2>(uint firstPathName, PathFontTarget fontTarget, ref readonly T1 fontName, PathFontStyle fontStyle, int numGlyphs, PathElementType type, ref readonly T2 charcodes, PathHandleMissingGlyphs handleMissingGlyphs, uint pathParameterTemplate, float emScale)
            where T1 : unmanaged
            where T2 : unmanaged
        {
            fixed (void* fontName_ptr = &fontName)
            fixed (void* charcodes_ptr = &charcodes)
            {
                PathGlyphsNV(firstPathName, fontTarget, fontName_ptr, fontStyle, numGlyphs, type, charcodes_ptr, handleMissingGlyphs, pathParameterTemplate, emScale);
            }
        }
        /// <inheritdoc cref="PathMemoryGlyphIndexArrayNV(uint, All, nint, void*, int, uint, int, uint, float)"/>
        public static unsafe All PathMemoryGlyphIndexArrayNV(uint firstPathName, All fontTarget, nint fontSize, IntPtr fontData, int faceIndex, uint firstGlyphIndex, int numGlyphs, uint pathParameterTemplate, float emScale)
        {
            void* fontData_vptr = (void*)fontData;
            var returnValue = PathMemoryGlyphIndexArrayNV(firstPathName, fontTarget, fontSize, fontData_vptr, faceIndex, firstGlyphIndex, numGlyphs, pathParameterTemplate, emScale);
            return returnValue;
        }
        /// <inheritdoc cref="PathMemoryGlyphIndexArrayNV(uint, All, nint, void*, int, uint, int, uint, float)"/>
        public static unsafe All PathMemoryGlyphIndexArrayNV<T1>(uint firstPathName, All fontTarget, nint fontSize, ReadOnlySpan<T1> fontData, int faceIndex, uint firstGlyphIndex, int numGlyphs, uint pathParameterTemplate, float emScale)
            where T1 : unmanaged
        {
            All returnValue;
            fixed (void* fontData_ptr = fontData)
            {
                returnValue = PathMemoryGlyphIndexArrayNV(firstPathName, fontTarget, fontSize, fontData_ptr, faceIndex, firstGlyphIndex, numGlyphs, pathParameterTemplate, emScale);
            }
            return returnValue;
        }
        /// <inheritdoc cref="PathMemoryGlyphIndexArrayNV(uint, All, nint, void*, int, uint, int, uint, float)"/>
        public static unsafe All PathMemoryGlyphIndexArrayNV<T1>(uint firstPathName, All fontTarget, nint fontSize, T1[] fontData, int faceIndex, uint firstGlyphIndex, int numGlyphs, uint pathParameterTemplate, float emScale)
            where T1 : unmanaged
        {
            All returnValue;
            fixed (void* fontData_ptr = fontData)
            {
                returnValue = PathMemoryGlyphIndexArrayNV(firstPathName, fontTarget, fontSize, fontData_ptr, faceIndex, firstGlyphIndex, numGlyphs, pathParameterTemplate, emScale);
            }
            return returnValue;
        }
        /// <inheritdoc cref="PathMemoryGlyphIndexArrayNV(uint, All, nint, void*, int, uint, int, uint, float)"/>
        public static unsafe All PathMemoryGlyphIndexArrayNV<T1>(uint firstPathName, All fontTarget, nint fontSize, ref readonly T1 fontData, int faceIndex, uint firstGlyphIndex, int numGlyphs, uint pathParameterTemplate, float emScale)
            where T1 : unmanaged
        {
            All returnValue;
            fixed (void* fontData_ptr = &fontData)
            {
                returnValue = PathMemoryGlyphIndexArrayNV(firstPathName, fontTarget, fontSize, fontData_ptr, faceIndex, firstGlyphIndex, numGlyphs, pathParameterTemplate, emScale);
            }
            return returnValue;
        }
        /// <inheritdoc cref="PathParameterfvNV(uint, PathParameter, float*)"/>
        public static unsafe void PathParameterfvNV(uint path, PathParameter pname, ReadOnlySpan<float> value)
        {
            fixed (float* value_ptr = value)
            {
                PathParameterfvNV(path, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="PathParameterfvNV(uint, PathParameter, float*)"/>
        public static unsafe void PathParameterfvNV(uint path, PathParameter pname, float[] value)
        {
            fixed (float* value_ptr = value)
            {
                PathParameterfvNV(path, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="PathParameterfvNV(uint, PathParameter, float*)"/>
        public static unsafe void PathParameterfvNV(uint path, PathParameter pname, ref readonly float value)
        {
            fixed (float* value_ptr = &value)
            {
                PathParameterfvNV(path, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="PathParameterivNV(uint, PathParameter, int*)"/>
        public static unsafe void PathParameterivNV(uint path, PathParameter pname, ReadOnlySpan<int> value)
        {
            fixed (int* value_ptr = value)
            {
                PathParameterivNV(path, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="PathParameterivNV(uint, PathParameter, int*)"/>
        public static unsafe void PathParameterivNV(uint path, PathParameter pname, int[] value)
        {
            fixed (int* value_ptr = value)
            {
                PathParameterivNV(path, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="PathParameterivNV(uint, PathParameter, int*)"/>
        public static unsafe void PathParameterivNV(uint path, PathParameter pname, ref readonly int value)
        {
            fixed (int* value_ptr = &value)
            {
                PathParameterivNV(path, pname, value_ptr);
            }
        }
        /// <inheritdoc cref="PathStringNV(uint, PathStringFormat, int, void*)"/>
        public static unsafe void PathStringNV(uint path, PathStringFormat format, int length, IntPtr pathString)
        {
            void* pathString_vptr = (void*)pathString;
            PathStringNV(path, format, length, pathString_vptr);
        }
        /// <inheritdoc cref="PathStringNV(uint, PathStringFormat, int, void*)"/>
        public static unsafe void PathStringNV<T1>(uint path, PathStringFormat format, int length, ReadOnlySpan<T1> pathString)
            where T1 : unmanaged
        {
            fixed (void* pathString_ptr = pathString)
            {
                PathStringNV(path, format, length, pathString_ptr);
            }
        }
        /// <inheritdoc cref="PathStringNV(uint, PathStringFormat, int, void*)"/>
        public static unsafe void PathStringNV<T1>(uint path, PathStringFormat format, int length, T1[] pathString)
            where T1 : unmanaged
        {
            fixed (void* pathString_ptr = pathString)
            {
                PathStringNV(path, format, length, pathString_ptr);
            }
        }
        /// <inheritdoc cref="PathStringNV(uint, PathStringFormat, int, void*)"/>
        public static unsafe void PathStringNV<T1>(uint path, PathStringFormat format, int length, ref readonly T1 pathString)
            where T1 : unmanaged
        {
            fixed (void* pathString_ptr = &pathString)
            {
                PathStringNV(path, format, length, pathString_ptr);
            }
        }
        /// <inheritdoc cref="PathSubCommandsNV(uint, int, int, int, byte*, int, PathCoordType, void*)"/>
        public static unsafe void PathSubCommandsNV(uint path, int commandStart, int commandsToDelete, int numCommands, ReadOnlySpan<byte> commands, int numCoords, PathCoordType coordType, IntPtr coords)
        {
            fixed (byte* commands_ptr = commands)
            {
                void* coords_vptr = (void*)coords;
                PathSubCommandsNV(path, commandStart, commandsToDelete, numCommands, commands_ptr, numCoords, coordType, coords_vptr);
            }
        }
        /// <inheritdoc cref="PathSubCommandsNV(uint, int, int, int, byte*, int, PathCoordType, void*)"/>
        public static unsafe void PathSubCommandsNV(uint path, int commandStart, int commandsToDelete, int numCommands, byte[] commands, int numCoords, PathCoordType coordType, IntPtr coords)
        {
            fixed (byte* commands_ptr = commands)
            {
                void* coords_vptr = (void*)coords;
                PathSubCommandsNV(path, commandStart, commandsToDelete, numCommands, commands_ptr, numCoords, coordType, coords_vptr);
            }
        }
        /// <inheritdoc cref="PathSubCommandsNV(uint, int, int, int, byte*, int, PathCoordType, void*)"/>
        public static unsafe void PathSubCommandsNV(uint path, int commandStart, int commandsToDelete, int numCommands, ref readonly byte commands, int numCoords, PathCoordType coordType, IntPtr coords)
        {
            fixed (byte* commands_ptr = &commands)
            {
                void* coords_vptr = (void*)coords;
                PathSubCommandsNV(path, commandStart, commandsToDelete, numCommands, commands_ptr, numCoords, coordType, coords_vptr);
            }
        }
        /// <inheritdoc cref="PathSubCommandsNV(uint, int, int, int, byte*, int, PathCoordType, void*)"/>
        public static unsafe void PathSubCommandsNV<T1>(uint path, int commandStart, int commandsToDelete, int numCommands, ReadOnlySpan<byte> commands, int numCoords, PathCoordType coordType, ReadOnlySpan<T1> coords)
            where T1 : unmanaged
        {
            fixed (void* coords_ptr = coords)
            {
                fixed (byte* commands_ptr = commands)
                {
                    PathSubCommandsNV(path, commandStart, commandsToDelete, numCommands, commands_ptr, numCoords, coordType, coords_ptr);
                }
            }
        }
        /// <inheritdoc cref="PathSubCommandsNV(uint, int, int, int, byte*, int, PathCoordType, void*)"/>
        public static unsafe void PathSubCommandsNV<T1>(uint path, int commandStart, int commandsToDelete, int numCommands, byte[] commands, int numCoords, PathCoordType coordType, T1[] coords)
            where T1 : unmanaged
        {
            fixed (void* coords_ptr = coords)
            {
                fixed (byte* commands_ptr = commands)
                {
                    PathSubCommandsNV(path, commandStart, commandsToDelete, numCommands, commands_ptr, numCoords, coordType, coords_ptr);
                }
            }
        }
        /// <inheritdoc cref="PathSubCommandsNV(uint, int, int, int, byte*, int, PathCoordType, void*)"/>
        public static unsafe void PathSubCommandsNV<T1>(uint path, int commandStart, int commandsToDelete, int numCommands, ref readonly byte commands, int numCoords, PathCoordType coordType, ref readonly T1 coords)
            where T1 : unmanaged
        {
            fixed (byte* commands_ptr = &commands)
            fixed (void* coords_ptr = &coords)
            {
                PathSubCommandsNV(path, commandStart, commandsToDelete, numCommands, commands_ptr, numCoords, coordType, coords_ptr);
            }
        }
        /// <inheritdoc cref="PathSubCoordsNV(uint, int, int, PathCoordType, void*)"/>
        public static unsafe void PathSubCoordsNV(uint path, int coordStart, int numCoords, PathCoordType coordType, IntPtr coords)
        {
            void* coords_vptr = (void*)coords;
            PathSubCoordsNV(path, coordStart, numCoords, coordType, coords_vptr);
        }
        /// <inheritdoc cref="PathSubCoordsNV(uint, int, int, PathCoordType, void*)"/>
        public static unsafe void PathSubCoordsNV<T1>(uint path, int coordStart, int numCoords, PathCoordType coordType, ReadOnlySpan<T1> coords)
            where T1 : unmanaged
        {
            fixed (void* coords_ptr = coords)
            {
                PathSubCoordsNV(path, coordStart, numCoords, coordType, coords_ptr);
            }
        }
        /// <inheritdoc cref="PathSubCoordsNV(uint, int, int, PathCoordType, void*)"/>
        public static unsafe void PathSubCoordsNV<T1>(uint path, int coordStart, int numCoords, PathCoordType coordType, T1[] coords)
            where T1 : unmanaged
        {
            fixed (void* coords_ptr = coords)
            {
                PathSubCoordsNV(path, coordStart, numCoords, coordType, coords_ptr);
            }
        }
        /// <inheritdoc cref="PathSubCoordsNV(uint, int, int, PathCoordType, void*)"/>
        public static unsafe void PathSubCoordsNV<T1>(uint path, int coordStart, int numCoords, PathCoordType coordType, ref readonly T1 coords)
            where T1 : unmanaged
        {
            fixed (void* coords_ptr = &coords)
            {
                PathSubCoordsNV(path, coordStart, numCoords, coordType, coords_ptr);
            }
        }
        /// <inheritdoc cref="PathTexGenNV(PathColor, PathGenMode, int, float*)"/>
        public static unsafe void PathTexGenNV(PathColor texCoordSet, PathGenMode genMode, int components, ReadOnlySpan<float> coeffs)
        {
            fixed (float* coeffs_ptr = coeffs)
            {
                PathTexGenNV(texCoordSet, genMode, components, coeffs_ptr);
            }
        }
        /// <inheritdoc cref="PathTexGenNV(PathColor, PathGenMode, int, float*)"/>
        public static unsafe void PathTexGenNV(PathColor texCoordSet, PathGenMode genMode, int components, float[] coeffs)
        {
            fixed (float* coeffs_ptr = coeffs)
            {
                PathTexGenNV(texCoordSet, genMode, components, coeffs_ptr);
            }
        }
        /// <inheritdoc cref="PathTexGenNV(PathColor, PathGenMode, int, float*)"/>
        public static unsafe void PathTexGenNV(PathColor texCoordSet, PathGenMode genMode, int components, ref readonly float coeffs)
        {
            fixed (float* coeffs_ptr = &coeffs)
            {
                PathTexGenNV(texCoordSet, genMode, components, coeffs_ptr);
            }
        }
        /// <inheritdoc cref="PointAlongPathNV(uint, int, int, float, float*, float*, float*, float*)"/>
        public static unsafe bool PointAlongPathNV(uint path, int startSegment, int numSegments, float distance, out float x, out float y, out float tangentX, out float tangentY)
        {
            bool returnValue;
            fixed (float* x_ptr = &x)
            fixed (float* y_ptr = &y)
            fixed (float* tangentX_ptr = &tangentX)
            fixed (float* tangentY_ptr = &tangentY)
            {
                returnValue = PointAlongPathNV(path, startSegment, numSegments, distance, x_ptr, y_ptr, tangentX_ptr, tangentY_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="ProgramPathFragmentInputGenNV(int, int, All, int, float*)"/>
        public static unsafe void ProgramPathFragmentInputGenNV(int program, int location, All genMode, int components, ReadOnlySpan<float> coeffs)
        {
            fixed (float* coeffs_ptr = coeffs)
            {
                ProgramPathFragmentInputGenNV(program, location, genMode, components, coeffs_ptr);
            }
        }
        /// <inheritdoc cref="ProgramPathFragmentInputGenNV(int, int, All, int, float*)"/>
        public static unsafe void ProgramPathFragmentInputGenNV(int program, int location, All genMode, int components, float[] coeffs)
        {
            fixed (float* coeffs_ptr = coeffs)
            {
                ProgramPathFragmentInputGenNV(program, location, genMode, components, coeffs_ptr);
            }
        }
        /// <inheritdoc cref="ProgramPathFragmentInputGenNV(int, int, All, int, float*)"/>
        public static unsafe void ProgramPathFragmentInputGenNV(int program, int location, All genMode, int components, ref readonly float coeffs)
        {
            fixed (float* coeffs_ptr = &coeffs)
            {
                ProgramPathFragmentInputGenNV(program, location, genMode, components, coeffs_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform1i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform1i64vNV(int program, int location, int count, ref readonly long value)
        {
            fixed (long* tmp_value = &value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform1i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform1ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform1ui64vNV(int program, int location, int count, ref readonly ulong value)
        {
            fixed (ulong* tmp_value = &value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform1ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform2i64vNV(int program, int location, int count, ref readonly Vector2 value)
        {
            fixed (Vector2* tmp_value = &value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform2i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform2i64vNV(int program, int location, int count, ReadOnlySpan<Vector2> value)
        {
            fixed (Vector2* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform2i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform2i64vNV(int program, int location, int count, Vector2[] value)
        {
            fixed (Vector2* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform2i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform2i64vNV(int program, int location, int count, ref readonly System.Numerics.Vector2 value)
        {
            fixed (System.Numerics.Vector2* tmp_value = &value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform2i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform2i64vNV(int program, int location, int count, ReadOnlySpan<System.Numerics.Vector2> value)
        {
            fixed (System.Numerics.Vector2* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform2i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform2i64vNV(int program, int location, int count, System.Numerics.Vector2[] value)
        {
            fixed (System.Numerics.Vector2* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform2i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform2ui64vNV(int program, int location, int count, ref readonly Vector2 value)
        {
            fixed (Vector2* tmp_value = &value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform2ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform2ui64vNV(int program, int location, int count, ReadOnlySpan<Vector2> value)
        {
            fixed (Vector2* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform2ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform2ui64vNV(int program, int location, int count, Vector2[] value)
        {
            fixed (Vector2* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform2ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform2ui64vNV(int program, int location, int count, ref readonly System.Numerics.Vector2 value)
        {
            fixed (System.Numerics.Vector2* tmp_value = &value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform2ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform2ui64vNV(int program, int location, int count, ReadOnlySpan<System.Numerics.Vector2> value)
        {
            fixed (System.Numerics.Vector2* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform2ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform2ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform2ui64vNV(int program, int location, int count, System.Numerics.Vector2[] value)
        {
            fixed (System.Numerics.Vector2* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform2ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform3i64vNV(int program, int location, int count, ref readonly Vector3 value)
        {
            fixed (Vector3* tmp_value = &value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform3i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform3i64vNV(int program, int location, int count, ReadOnlySpan<Vector3> value)
        {
            fixed (Vector3* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform3i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform3i64vNV(int program, int location, int count, Vector3[] value)
        {
            fixed (Vector3* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform3i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform3i64vNV(int program, int location, int count, ref readonly System.Numerics.Vector3 value)
        {
            fixed (System.Numerics.Vector3* tmp_value = &value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform3i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform3i64vNV(int program, int location, int count, ReadOnlySpan<System.Numerics.Vector3> value)
        {
            fixed (System.Numerics.Vector3* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform3i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform3i64vNV(int program, int location, int count, System.Numerics.Vector3[] value)
        {
            fixed (System.Numerics.Vector3* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform3i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform3ui64vNV(int program, int location, int count, ref readonly Vector3 value)
        {
            fixed (Vector3* tmp_value = &value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform3ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform3ui64vNV(int program, int location, int count, ReadOnlySpan<Vector3> value)
        {
            fixed (Vector3* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform3ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform3ui64vNV(int program, int location, int count, Vector3[] value)
        {
            fixed (Vector3* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform3ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform3ui64vNV(int program, int location, int count, ref readonly System.Numerics.Vector3 value)
        {
            fixed (System.Numerics.Vector3* tmp_value = &value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform3ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform3ui64vNV(int program, int location, int count, ReadOnlySpan<System.Numerics.Vector3> value)
        {
            fixed (System.Numerics.Vector3* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform3ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform3ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform3ui64vNV(int program, int location, int count, System.Numerics.Vector3[] value)
        {
            fixed (System.Numerics.Vector3* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform3ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform4i64vNV(int program, int location, int count, ref readonly Vector4 value)
        {
            fixed (Vector4* tmp_value = &value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform4i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform4i64vNV(int program, int location, int count, ReadOnlySpan<Vector4> value)
        {
            fixed (Vector4* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform4i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform4i64vNV(int program, int location, int count, Vector4[] value)
        {
            fixed (Vector4* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform4i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform4i64vNV(int program, int location, int count, ref readonly System.Numerics.Vector4 value)
        {
            fixed (System.Numerics.Vector4* tmp_value = &value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform4i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform4i64vNV(int program, int location, int count, ReadOnlySpan<System.Numerics.Vector4> value)
        {
            fixed (System.Numerics.Vector4* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform4i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4i64vNV(int, int, int, long*)"/>
        public static unsafe void ProgramUniform4i64vNV(int program, int location, int count, System.Numerics.Vector4[] value)
        {
            fixed (System.Numerics.Vector4* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                ProgramUniform4i64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform4ui64vNV(int program, int location, int count, ref readonly Vector4 value)
        {
            fixed (Vector4* tmp_value = &value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform4ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform4ui64vNV(int program, int location, int count, ReadOnlySpan<Vector4> value)
        {
            fixed (Vector4* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform4ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform4ui64vNV(int program, int location, int count, Vector4[] value)
        {
            fixed (Vector4* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform4ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform4ui64vNV(int program, int location, int count, ref readonly System.Numerics.Vector4 value)
        {
            fixed (System.Numerics.Vector4* tmp_value = &value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform4ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform4ui64vNV(int program, int location, int count, ReadOnlySpan<System.Numerics.Vector4> value)
        {
            fixed (System.Numerics.Vector4* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform4ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniform4ui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniform4ui64vNV(int program, int location, int count, System.Numerics.Vector4[] value)
        {
            fixed (System.Numerics.Vector4* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                ProgramUniform4ui64vNV(program, location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformHandleui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniformHandleui64vNV(int program, int location, int count, ReadOnlySpan<ulong> values)
        {
            fixed (ulong* values_ptr = values)
            {
                ProgramUniformHandleui64vNV(program, location, count, values_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformHandleui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniformHandleui64vNV(int program, int location, int count, ulong[] values)
        {
            fixed (ulong* values_ptr = values)
            {
                ProgramUniformHandleui64vNV(program, location, count, values_ptr);
            }
        }
        /// <inheritdoc cref="ProgramUniformHandleui64vNV(int, int, int, ulong*)"/>
        public static unsafe void ProgramUniformHandleui64vNV(int program, int location, int count, ref readonly ulong values)
        {
            fixed (ulong* values_ptr = &values)
            {
                ProgramUniformHandleui64vNV(program, location, count, values_ptr);
            }
        }
        /// <inheritdoc cref="ScissorArrayvNV(uint, int, int*)"/>
        public static unsafe void ScissorArrayvNV(uint first, int count, ReadOnlySpan<int> v)
        {
            fixed (int* v_ptr = v)
            {
                ScissorArrayvNV(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="ScissorArrayvNV(uint, int, int*)"/>
        public static unsafe void ScissorArrayvNV(uint first, int count, int[] v)
        {
            fixed (int* v_ptr = v)
            {
                ScissorArrayvNV(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="ScissorArrayvNV(uint, int, int*)"/>
        public static unsafe void ScissorArrayvNV(uint first, int count, ref readonly int v)
        {
            fixed (int* v_ptr = &v)
            {
                ScissorArrayvNV(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="ScissorExclusiveArrayvNV(uint, int, int*)"/>
        public static unsafe void ScissorExclusiveArrayvNV(uint first, int count, ReadOnlySpan<int> v)
        {
            fixed (int* v_ptr = v)
            {
                ScissorExclusiveArrayvNV(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="ScissorExclusiveArrayvNV(uint, int, int*)"/>
        public static unsafe void ScissorExclusiveArrayvNV(uint first, int count, int[] v)
        {
            fixed (int* v_ptr = v)
            {
                ScissorExclusiveArrayvNV(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="ScissorExclusiveArrayvNV(uint, int, int*)"/>
        public static unsafe void ScissorExclusiveArrayvNV(uint first, int count, ref readonly int v)
        {
            fixed (int* v_ptr = &v)
            {
                ScissorExclusiveArrayvNV(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="ScissorIndexedvNV(uint, int*)"/>
        public static unsafe void ScissorIndexedvNV(uint index, ReadOnlySpan<int> v)
        {
            fixed (int* v_ptr = v)
            {
                ScissorIndexedvNV(index, v_ptr);
            }
        }
        /// <inheritdoc cref="ScissorIndexedvNV(uint, int*)"/>
        public static unsafe void ScissorIndexedvNV(uint index, int[] v)
        {
            fixed (int* v_ptr = v)
            {
                ScissorIndexedvNV(index, v_ptr);
            }
        }
        /// <inheritdoc cref="ScissorIndexedvNV(uint, int*)"/>
        public static unsafe void ScissorIndexedvNV(uint index, ref readonly int v)
        {
            fixed (int* v_ptr = &v)
            {
                ScissorIndexedvNV(index, v_ptr);
            }
        }
        /// <inheritdoc cref="SemaphoreParameterivNV(uint, SemaphoreParameterName, int*)"/>
        public static unsafe void SemaphoreParameterivNV(uint semaphore, SemaphoreParameterName pname, ReadOnlySpan<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                SemaphoreParameterivNV(semaphore, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="SemaphoreParameterivNV(uint, SemaphoreParameterName, int*)"/>
        public static unsafe void SemaphoreParameterivNV(uint semaphore, SemaphoreParameterName pname, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                SemaphoreParameterivNV(semaphore, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="SemaphoreParameterivNV(uint, SemaphoreParameterName, int*)"/>
        public static unsafe void SemaphoreParameterivNV(uint semaphore, SemaphoreParameterName pname, ref readonly int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                SemaphoreParameterivNV(semaphore, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="ShadingRateImagePaletteNV(uint, uint, int, All*)"/>
        public static unsafe void ShadingRateImagePaletteNV(uint viewport, uint first, int count, ReadOnlySpan<All> rates)
        {
            fixed (All* rates_ptr = rates)
            {
                ShadingRateImagePaletteNV(viewport, first, count, rates_ptr);
            }
        }
        /// <inheritdoc cref="ShadingRateImagePaletteNV(uint, uint, int, All*)"/>
        public static unsafe void ShadingRateImagePaletteNV(uint viewport, uint first, int count, All[] rates)
        {
            fixed (All* rates_ptr = rates)
            {
                ShadingRateImagePaletteNV(viewport, first, count, rates_ptr);
            }
        }
        /// <inheritdoc cref="ShadingRateImagePaletteNV(uint, uint, int, All*)"/>
        public static unsafe void ShadingRateImagePaletteNV(uint viewport, uint first, int count, ref readonly All rates)
        {
            fixed (All* rates_ptr = &rates)
            {
                ShadingRateImagePaletteNV(viewport, first, count, rates_ptr);
            }
        }
        /// <inheritdoc cref="ShadingRateSampleOrderCustomNV(All, uint, int*)"/>
        public static unsafe void ShadingRateSampleOrderCustomNV(All rate, uint samples, ReadOnlySpan<int> locations)
        {
            fixed (int* locations_ptr = locations)
            {
                ShadingRateSampleOrderCustomNV(rate, samples, locations_ptr);
            }
        }
        /// <inheritdoc cref="ShadingRateSampleOrderCustomNV(All, uint, int*)"/>
        public static unsafe void ShadingRateSampleOrderCustomNV(All rate, uint samples, int[] locations)
        {
            fixed (int* locations_ptr = locations)
            {
                ShadingRateSampleOrderCustomNV(rate, samples, locations_ptr);
            }
        }
        /// <inheritdoc cref="ShadingRateSampleOrderCustomNV(All, uint, int*)"/>
        public static unsafe void ShadingRateSampleOrderCustomNV(All rate, uint samples, ref readonly int locations)
        {
            fixed (int* locations_ptr = &locations)
            {
                ShadingRateSampleOrderCustomNV(rate, samples, locations_ptr);
            }
        }
        /// <inheritdoc cref="StencilFillPathInstancedNV(int, PathElementType, void*, uint, PathFillMode, uint, PathTransformType, float*)"/>
        public static unsafe void StencilFillPathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, PathFillMode fillMode, uint mask, PathTransformType transformType, ReadOnlySpan<float> transformValues)
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                void* paths_vptr = (void*)paths;
                StencilFillPathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, fillMode, mask, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="StencilFillPathInstancedNV(int, PathElementType, void*, uint, PathFillMode, uint, PathTransformType, float*)"/>
        public static unsafe void StencilFillPathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, PathFillMode fillMode, uint mask, PathTransformType transformType, float[] transformValues)
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                void* paths_vptr = (void*)paths;
                StencilFillPathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, fillMode, mask, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="StencilFillPathInstancedNV(int, PathElementType, void*, uint, PathFillMode, uint, PathTransformType, float*)"/>
        public static unsafe void StencilFillPathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, PathFillMode fillMode, uint mask, PathTransformType transformType, ref readonly float transformValues)
        {
            fixed (float* transformValues_ptr = &transformValues)
            {
                void* paths_vptr = (void*)paths;
                StencilFillPathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, fillMode, mask, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="StencilFillPathInstancedNV(int, PathElementType, void*, uint, PathFillMode, uint, PathTransformType, float*)"/>
        public static unsafe void StencilFillPathInstancedNV<T1>(int numPaths, PathElementType pathNameType, ReadOnlySpan<T1> paths, uint pathBase, PathFillMode fillMode, uint mask, PathTransformType transformType, ReadOnlySpan<float> transformValues)
            where T1 : unmanaged
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                fixed (void* paths_ptr = paths)
                {
                    StencilFillPathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, fillMode, mask, transformType, transformValues_ptr);
                }
            }
        }
        /// <inheritdoc cref="StencilFillPathInstancedNV(int, PathElementType, void*, uint, PathFillMode, uint, PathTransformType, float*)"/>
        public static unsafe void StencilFillPathInstancedNV<T1>(int numPaths, PathElementType pathNameType, T1[] paths, uint pathBase, PathFillMode fillMode, uint mask, PathTransformType transformType, float[] transformValues)
            where T1 : unmanaged
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                fixed (void* paths_ptr = paths)
                {
                    StencilFillPathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, fillMode, mask, transformType, transformValues_ptr);
                }
            }
        }
        /// <inheritdoc cref="StencilFillPathInstancedNV(int, PathElementType, void*, uint, PathFillMode, uint, PathTransformType, float*)"/>
        public static unsafe void StencilFillPathInstancedNV<T1>(int numPaths, PathElementType pathNameType, ref readonly T1 paths, uint pathBase, PathFillMode fillMode, uint mask, PathTransformType transformType, ref readonly float transformValues)
            where T1 : unmanaged
        {
            fixed (void* paths_ptr = &paths)
            fixed (float* transformValues_ptr = &transformValues)
            {
                StencilFillPathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, fillMode, mask, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="StencilStrokePathInstancedNV(int, PathElementType, void*, uint, int, uint, PathTransformType, float*)"/>
        public static unsafe void StencilStrokePathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, int reference, uint mask, PathTransformType transformType, ReadOnlySpan<float> transformValues)
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                void* paths_vptr = (void*)paths;
                StencilStrokePathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, reference, mask, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="StencilStrokePathInstancedNV(int, PathElementType, void*, uint, int, uint, PathTransformType, float*)"/>
        public static unsafe void StencilStrokePathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, int reference, uint mask, PathTransformType transformType, float[] transformValues)
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                void* paths_vptr = (void*)paths;
                StencilStrokePathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, reference, mask, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="StencilStrokePathInstancedNV(int, PathElementType, void*, uint, int, uint, PathTransformType, float*)"/>
        public static unsafe void StencilStrokePathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, int reference, uint mask, PathTransformType transformType, ref readonly float transformValues)
        {
            fixed (float* transformValues_ptr = &transformValues)
            {
                void* paths_vptr = (void*)paths;
                StencilStrokePathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, reference, mask, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="StencilStrokePathInstancedNV(int, PathElementType, void*, uint, int, uint, PathTransformType, float*)"/>
        public static unsafe void StencilStrokePathInstancedNV<T1>(int numPaths, PathElementType pathNameType, ReadOnlySpan<T1> paths, uint pathBase, int reference, uint mask, PathTransformType transformType, ReadOnlySpan<float> transformValues)
            where T1 : unmanaged
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                fixed (void* paths_ptr = paths)
                {
                    StencilStrokePathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, reference, mask, transformType, transformValues_ptr);
                }
            }
        }
        /// <inheritdoc cref="StencilStrokePathInstancedNV(int, PathElementType, void*, uint, int, uint, PathTransformType, float*)"/>
        public static unsafe void StencilStrokePathInstancedNV<T1>(int numPaths, PathElementType pathNameType, T1[] paths, uint pathBase, int reference, uint mask, PathTransformType transformType, float[] transformValues)
            where T1 : unmanaged
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                fixed (void* paths_ptr = paths)
                {
                    StencilStrokePathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, reference, mask, transformType, transformValues_ptr);
                }
            }
        }
        /// <inheritdoc cref="StencilStrokePathInstancedNV(int, PathElementType, void*, uint, int, uint, PathTransformType, float*)"/>
        public static unsafe void StencilStrokePathInstancedNV<T1>(int numPaths, PathElementType pathNameType, ref readonly T1 paths, uint pathBase, int reference, uint mask, PathTransformType transformType, ref readonly float transformValues)
            where T1 : unmanaged
        {
            fixed (void* paths_ptr = &paths)
            fixed (float* transformValues_ptr = &transformValues)
            {
                StencilStrokePathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, reference, mask, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="StencilThenCoverFillPathInstancedNV(int, PathElementType, void*, uint, PathFillMode, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void StencilThenCoverFillPathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, PathFillMode fillMode, uint mask, InstancedPathCoverMode coverMode, PathTransformType transformType, ReadOnlySpan<float> transformValues)
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                void* paths_vptr = (void*)paths;
                StencilThenCoverFillPathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, fillMode, mask, coverMode, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="StencilThenCoverFillPathInstancedNV(int, PathElementType, void*, uint, PathFillMode, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void StencilThenCoverFillPathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, PathFillMode fillMode, uint mask, InstancedPathCoverMode coverMode, PathTransformType transformType, float[] transformValues)
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                void* paths_vptr = (void*)paths;
                StencilThenCoverFillPathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, fillMode, mask, coverMode, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="StencilThenCoverFillPathInstancedNV(int, PathElementType, void*, uint, PathFillMode, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void StencilThenCoverFillPathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, PathFillMode fillMode, uint mask, InstancedPathCoverMode coverMode, PathTransformType transformType, ref readonly float transformValues)
        {
            fixed (float* transformValues_ptr = &transformValues)
            {
                void* paths_vptr = (void*)paths;
                StencilThenCoverFillPathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, fillMode, mask, coverMode, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="StencilThenCoverFillPathInstancedNV(int, PathElementType, void*, uint, PathFillMode, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void StencilThenCoverFillPathInstancedNV<T1>(int numPaths, PathElementType pathNameType, ReadOnlySpan<T1> paths, uint pathBase, PathFillMode fillMode, uint mask, InstancedPathCoverMode coverMode, PathTransformType transformType, ReadOnlySpan<float> transformValues)
            where T1 : unmanaged
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                fixed (void* paths_ptr = paths)
                {
                    StencilThenCoverFillPathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, fillMode, mask, coverMode, transformType, transformValues_ptr);
                }
            }
        }
        /// <inheritdoc cref="StencilThenCoverFillPathInstancedNV(int, PathElementType, void*, uint, PathFillMode, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void StencilThenCoverFillPathInstancedNV<T1>(int numPaths, PathElementType pathNameType, T1[] paths, uint pathBase, PathFillMode fillMode, uint mask, InstancedPathCoverMode coverMode, PathTransformType transformType, float[] transformValues)
            where T1 : unmanaged
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                fixed (void* paths_ptr = paths)
                {
                    StencilThenCoverFillPathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, fillMode, mask, coverMode, transformType, transformValues_ptr);
                }
            }
        }
        /// <inheritdoc cref="StencilThenCoverFillPathInstancedNV(int, PathElementType, void*, uint, PathFillMode, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void StencilThenCoverFillPathInstancedNV<T1>(int numPaths, PathElementType pathNameType, ref readonly T1 paths, uint pathBase, PathFillMode fillMode, uint mask, InstancedPathCoverMode coverMode, PathTransformType transformType, ref readonly float transformValues)
            where T1 : unmanaged
        {
            fixed (void* paths_ptr = &paths)
            fixed (float* transformValues_ptr = &transformValues)
            {
                StencilThenCoverFillPathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, fillMode, mask, coverMode, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="StencilThenCoverStrokePathInstancedNV(int, PathElementType, void*, uint, int, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void StencilThenCoverStrokePathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, int reference, uint mask, InstancedPathCoverMode coverMode, PathTransformType transformType, ReadOnlySpan<float> transformValues)
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                void* paths_vptr = (void*)paths;
                StencilThenCoverStrokePathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, reference, mask, coverMode, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="StencilThenCoverStrokePathInstancedNV(int, PathElementType, void*, uint, int, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void StencilThenCoverStrokePathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, int reference, uint mask, InstancedPathCoverMode coverMode, PathTransformType transformType, float[] transformValues)
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                void* paths_vptr = (void*)paths;
                StencilThenCoverStrokePathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, reference, mask, coverMode, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="StencilThenCoverStrokePathInstancedNV(int, PathElementType, void*, uint, int, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void StencilThenCoverStrokePathInstancedNV(int numPaths, PathElementType pathNameType, IntPtr paths, uint pathBase, int reference, uint mask, InstancedPathCoverMode coverMode, PathTransformType transformType, ref readonly float transformValues)
        {
            fixed (float* transformValues_ptr = &transformValues)
            {
                void* paths_vptr = (void*)paths;
                StencilThenCoverStrokePathInstancedNV(numPaths, pathNameType, paths_vptr, pathBase, reference, mask, coverMode, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="StencilThenCoverStrokePathInstancedNV(int, PathElementType, void*, uint, int, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void StencilThenCoverStrokePathInstancedNV<T1>(int numPaths, PathElementType pathNameType, ReadOnlySpan<T1> paths, uint pathBase, int reference, uint mask, InstancedPathCoverMode coverMode, PathTransformType transformType, ReadOnlySpan<float> transformValues)
            where T1 : unmanaged
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                fixed (void* paths_ptr = paths)
                {
                    StencilThenCoverStrokePathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, reference, mask, coverMode, transformType, transformValues_ptr);
                }
            }
        }
        /// <inheritdoc cref="StencilThenCoverStrokePathInstancedNV(int, PathElementType, void*, uint, int, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void StencilThenCoverStrokePathInstancedNV<T1>(int numPaths, PathElementType pathNameType, T1[] paths, uint pathBase, int reference, uint mask, InstancedPathCoverMode coverMode, PathTransformType transformType, float[] transformValues)
            where T1 : unmanaged
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                fixed (void* paths_ptr = paths)
                {
                    StencilThenCoverStrokePathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, reference, mask, coverMode, transformType, transformValues_ptr);
                }
            }
        }
        /// <inheritdoc cref="StencilThenCoverStrokePathInstancedNV(int, PathElementType, void*, uint, int, uint, InstancedPathCoverMode, PathTransformType, float*)"/>
        public static unsafe void StencilThenCoverStrokePathInstancedNV<T1>(int numPaths, PathElementType pathNameType, ref readonly T1 paths, uint pathBase, int reference, uint mask, InstancedPathCoverMode coverMode, PathTransformType transformType, ref readonly float transformValues)
            where T1 : unmanaged
        {
            fixed (void* paths_ptr = &paths)
            fixed (float* transformValues_ptr = &transformValues)
            {
                StencilThenCoverStrokePathInstancedNV(numPaths, pathNameType, paths_ptr, pathBase, reference, mask, coverMode, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="TransformPathNV(uint, uint, PathTransformType, float*)"/>
        public static unsafe void TransformPathNV(uint resultPath, uint srcPath, PathTransformType transformType, ReadOnlySpan<float> transformValues)
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                TransformPathNV(resultPath, srcPath, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="TransformPathNV(uint, uint, PathTransformType, float*)"/>
        public static unsafe void TransformPathNV(uint resultPath, uint srcPath, PathTransformType transformType, float[] transformValues)
        {
            fixed (float* transformValues_ptr = transformValues)
            {
                TransformPathNV(resultPath, srcPath, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="TransformPathNV(uint, uint, PathTransformType, float*)"/>
        public static unsafe void TransformPathNV(uint resultPath, uint srcPath, PathTransformType transformType, ref readonly float transformValues)
        {
            fixed (float* transformValues_ptr = &transformValues)
            {
                TransformPathNV(resultPath, srcPath, transformType, transformValues_ptr);
            }
        }
        /// <inheritdoc cref="Uniform1i64vNV(int, int, long*)"/>
        public static unsafe void Uniform1i64vNV(int location, int count, ref readonly long value)
        {
            fixed (long* tmp_value = &value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform1i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform1i64vNV(int, int, long*)"/>
        public static unsafe void Uniform1i64vNV(int location, int count, ReadOnlySpan<long> value)
        {
            fixed (long* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform1i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform1i64vNV(int, int, long*)"/>
        public static unsafe void Uniform1i64vNV(int location, int count, long[] value)
        {
            fixed (long* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform1i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform1ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform1ui64vNV(int location, int count, ref readonly ulong value)
        {
            fixed (ulong* tmp_value = &value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform1ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform1ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform1ui64vNV(int location, int count, ReadOnlySpan<ulong> value)
        {
            fixed (ulong* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform1ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform1ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform1ui64vNV(int location, int count, ulong[] value)
        {
            fixed (ulong* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform1ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform2i64vNV(int, int, long*)"/>
        public static unsafe void Uniform2i64vNV(int location, int count, ref readonly Vector2 value)
        {
            fixed (Vector2* tmp_value = &value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform2i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform2i64vNV(int, int, long*)"/>
        public static unsafe void Uniform2i64vNV(int location, int count, ReadOnlySpan<Vector2> value)
        {
            fixed (Vector2* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform2i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform2i64vNV(int, int, long*)"/>
        public static unsafe void Uniform2i64vNV(int location, int count, Vector2[] value)
        {
            fixed (Vector2* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform2i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform2i64vNV(int, int, long*)"/>
        public static unsafe void Uniform2i64vNV(int location, int count, ref readonly System.Numerics.Vector2 value)
        {
            fixed (System.Numerics.Vector2* tmp_value = &value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform2i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform2i64vNV(int, int, long*)"/>
        public static unsafe void Uniform2i64vNV(int location, int count, ReadOnlySpan<System.Numerics.Vector2> value)
        {
            fixed (System.Numerics.Vector2* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform2i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform2i64vNV(int, int, long*)"/>
        public static unsafe void Uniform2i64vNV(int location, int count, System.Numerics.Vector2[] value)
        {
            fixed (System.Numerics.Vector2* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform2i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform2ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform2ui64vNV(int location, int count, ref readonly Vector2 value)
        {
            fixed (Vector2* tmp_value = &value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform2ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform2ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform2ui64vNV(int location, int count, ReadOnlySpan<Vector2> value)
        {
            fixed (Vector2* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform2ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform2ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform2ui64vNV(int location, int count, Vector2[] value)
        {
            fixed (Vector2* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform2ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform2ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform2ui64vNV(int location, int count, ref readonly System.Numerics.Vector2 value)
        {
            fixed (System.Numerics.Vector2* tmp_value = &value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform2ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform2ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform2ui64vNV(int location, int count, ReadOnlySpan<System.Numerics.Vector2> value)
        {
            fixed (System.Numerics.Vector2* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform2ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform2ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform2ui64vNV(int location, int count, System.Numerics.Vector2[] value)
        {
            fixed (System.Numerics.Vector2* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform2ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform3i64vNV(int, int, long*)"/>
        public static unsafe void Uniform3i64vNV(int location, int count, ref readonly Vector3 value)
        {
            fixed (Vector3* tmp_value = &value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform3i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform3i64vNV(int, int, long*)"/>
        public static unsafe void Uniform3i64vNV(int location, int count, ReadOnlySpan<Vector3> value)
        {
            fixed (Vector3* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform3i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform3i64vNV(int, int, long*)"/>
        public static unsafe void Uniform3i64vNV(int location, int count, Vector3[] value)
        {
            fixed (Vector3* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform3i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform3i64vNV(int, int, long*)"/>
        public static unsafe void Uniform3i64vNV(int location, int count, ref readonly System.Numerics.Vector3 value)
        {
            fixed (System.Numerics.Vector3* tmp_value = &value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform3i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform3i64vNV(int, int, long*)"/>
        public static unsafe void Uniform3i64vNV(int location, int count, ReadOnlySpan<System.Numerics.Vector3> value)
        {
            fixed (System.Numerics.Vector3* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform3i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform3i64vNV(int, int, long*)"/>
        public static unsafe void Uniform3i64vNV(int location, int count, System.Numerics.Vector3[] value)
        {
            fixed (System.Numerics.Vector3* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform3i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform3ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform3ui64vNV(int location, int count, ref readonly Vector3 value)
        {
            fixed (Vector3* tmp_value = &value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform3ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform3ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform3ui64vNV(int location, int count, ReadOnlySpan<Vector3> value)
        {
            fixed (Vector3* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform3ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform3ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform3ui64vNV(int location, int count, Vector3[] value)
        {
            fixed (Vector3* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform3ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform3ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform3ui64vNV(int location, int count, ref readonly System.Numerics.Vector3 value)
        {
            fixed (System.Numerics.Vector3* tmp_value = &value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform3ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform3ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform3ui64vNV(int location, int count, ReadOnlySpan<System.Numerics.Vector3> value)
        {
            fixed (System.Numerics.Vector3* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform3ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform3ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform3ui64vNV(int location, int count, System.Numerics.Vector3[] value)
        {
            fixed (System.Numerics.Vector3* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform3ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform4i64vNV(int, int, long*)"/>
        public static unsafe void Uniform4i64vNV(int location, int count, ref readonly Vector4 value)
        {
            fixed (Vector4* tmp_value = &value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform4i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform4i64vNV(int, int, long*)"/>
        public static unsafe void Uniform4i64vNV(int location, int count, ReadOnlySpan<Vector4> value)
        {
            fixed (Vector4* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform4i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform4i64vNV(int, int, long*)"/>
        public static unsafe void Uniform4i64vNV(int location, int count, Vector4[] value)
        {
            fixed (Vector4* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform4i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform4i64vNV(int, int, long*)"/>
        public static unsafe void Uniform4i64vNV(int location, int count, ref readonly System.Numerics.Vector4 value)
        {
            fixed (System.Numerics.Vector4* tmp_value = &value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform4i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform4i64vNV(int, int, long*)"/>
        public static unsafe void Uniform4i64vNV(int location, int count, ReadOnlySpan<System.Numerics.Vector4> value)
        {
            fixed (System.Numerics.Vector4* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform4i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform4i64vNV(int, int, long*)"/>
        public static unsafe void Uniform4i64vNV(int location, int count, System.Numerics.Vector4[] value)
        {
            fixed (System.Numerics.Vector4* tmp_value = value)
            {
                long* value_ptr = (long*)tmp_value;
                Uniform4i64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform4ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform4ui64vNV(int location, int count, ref readonly Vector4 value)
        {
            fixed (Vector4* tmp_value = &value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform4ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform4ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform4ui64vNV(int location, int count, ReadOnlySpan<Vector4> value)
        {
            fixed (Vector4* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform4ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform4ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform4ui64vNV(int location, int count, Vector4[] value)
        {
            fixed (Vector4* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform4ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform4ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform4ui64vNV(int location, int count, ref readonly System.Numerics.Vector4 value)
        {
            fixed (System.Numerics.Vector4* tmp_value = &value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform4ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform4ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform4ui64vNV(int location, int count, ReadOnlySpan<System.Numerics.Vector4> value)
        {
            fixed (System.Numerics.Vector4* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform4ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="Uniform4ui64vNV(int, int, ulong*)"/>
        public static unsafe void Uniform4ui64vNV(int location, int count, System.Numerics.Vector4[] value)
        {
            fixed (System.Numerics.Vector4* tmp_value = value)
            {
                ulong* value_ptr = (ulong*)tmp_value;
                Uniform4ui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformHandleui64vNV(int, int, ulong*)"/>
        public static unsafe void UniformHandleui64vNV(int location, int count, ReadOnlySpan<ulong> value)
        {
            fixed (ulong* value_ptr = value)
            {
                UniformHandleui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformHandleui64vNV(int, int, ulong*)"/>
        public static unsafe void UniformHandleui64vNV(int location, int count, ulong[] value)
        {
            fixed (ulong* value_ptr = value)
            {
                UniformHandleui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformHandleui64vNV(int, int, ulong*)"/>
        public static unsafe void UniformHandleui64vNV(int location, int count, ref readonly ulong value)
        {
            fixed (ulong* value_ptr = &value)
            {
                UniformHandleui64vNV(location, count, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix2x3fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix2x3fvNV(int location, int count, bool transpose, ref readonly Matrix2x3 value)
        {
            fixed (Matrix2x3* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix2x3fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix2x3fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix2x3fvNV(int location, int count, bool transpose, ReadOnlySpan<Matrix2x3> value)
        {
            fixed (Matrix2x3* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix2x3fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix2x3fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix2x3fvNV(int location, int count, bool transpose, Matrix2x3[] value)
        {
            fixed (Matrix2x3* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix2x3fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix2x4fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix2x4fvNV(int location, int count, bool transpose, ref readonly Matrix2x4 value)
        {
            fixed (Matrix2x4* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix2x4fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix2x4fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix2x4fvNV(int location, int count, bool transpose, ReadOnlySpan<Matrix2x4> value)
        {
            fixed (Matrix2x4* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix2x4fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix2x4fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix2x4fvNV(int location, int count, bool transpose, Matrix2x4[] value)
        {
            fixed (Matrix2x4* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix2x4fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix3x2fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix3x2fvNV(int location, int count, bool transpose, ref readonly Matrix3x2 value)
        {
            fixed (Matrix3x2* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix3x2fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix3x2fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix3x2fvNV(int location, int count, bool transpose, ReadOnlySpan<Matrix3x2> value)
        {
            fixed (Matrix3x2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix3x2fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix3x2fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix3x2fvNV(int location, int count, bool transpose, Matrix3x2[] value)
        {
            fixed (Matrix3x2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix3x2fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix3x2fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix3x2fvNV(int location, int count, bool transpose, ref readonly System.Numerics.Matrix3x2 value)
        {
            fixed (System.Numerics.Matrix3x2* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix3x2fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix3x2fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix3x2fvNV(int location, int count, bool transpose, ReadOnlySpan<System.Numerics.Matrix3x2> value)
        {
            fixed (System.Numerics.Matrix3x2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix3x2fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix3x2fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix3x2fvNV(int location, int count, bool transpose, System.Numerics.Matrix3x2[] value)
        {
            fixed (System.Numerics.Matrix3x2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix3x2fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix3x4fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix3x4fvNV(int location, int count, bool transpose, ref readonly Matrix3x4 value)
        {
            fixed (Matrix3x4* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix3x4fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix3x4fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix3x4fvNV(int location, int count, bool transpose, ReadOnlySpan<Matrix3x4> value)
        {
            fixed (Matrix3x4* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix3x4fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix3x4fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix3x4fvNV(int location, int count, bool transpose, Matrix3x4[] value)
        {
            fixed (Matrix3x4* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix3x4fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix4x2fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix4x2fvNV(int location, int count, bool transpose, ref readonly Matrix4x2 value)
        {
            fixed (Matrix4x2* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix4x2fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix4x2fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix4x2fvNV(int location, int count, bool transpose, ReadOnlySpan<Matrix4x2> value)
        {
            fixed (Matrix4x2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix4x2fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix4x2fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix4x2fvNV(int location, int count, bool transpose, Matrix4x2[] value)
        {
            fixed (Matrix4x2* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix4x2fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix4x3fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix4x3fvNV(int location, int count, bool transpose, ref readonly Matrix4x3 value)
        {
            fixed (Matrix4x3* tmp_value = &value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix4x3fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix4x3fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix4x3fvNV(int location, int count, bool transpose, ReadOnlySpan<Matrix4x3> value)
        {
            fixed (Matrix4x3* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix4x3fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="UniformMatrix4x3fvNV(int, int, bool, float*)"/>
        public static unsafe void UniformMatrix4x3fvNV(int location, int count, bool transpose, Matrix4x3[] value)
        {
            fixed (Matrix4x3* tmp_value = value)
            {
                float* value_ptr = (float*)tmp_value;
                UniformMatrix4x3fvNV(location, count, transpose, value_ptr);
            }
        }
        /// <inheritdoc cref="ViewportArrayvNV(uint, int, float*)"/>
        public static unsafe void ViewportArrayvNV(uint first, int count, ReadOnlySpan<float> v)
        {
            fixed (float* v_ptr = v)
            {
                ViewportArrayvNV(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="ViewportArrayvNV(uint, int, float*)"/>
        public static unsafe void ViewportArrayvNV(uint first, int count, float[] v)
        {
            fixed (float* v_ptr = v)
            {
                ViewportArrayvNV(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="ViewportArrayvNV(uint, int, float*)"/>
        public static unsafe void ViewportArrayvNV(uint first, int count, ref readonly float v)
        {
            fixed (float* v_ptr = &v)
            {
                ViewportArrayvNV(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="ViewportIndexedfvNV(uint, float*)"/>
        public static unsafe void ViewportIndexedfvNV(uint index, ReadOnlySpan<float> v)
        {
            fixed (float* v_ptr = v)
            {
                ViewportIndexedfvNV(index, v_ptr);
            }
        }
        /// <inheritdoc cref="ViewportIndexedfvNV(uint, float*)"/>
        public static unsafe void ViewportIndexedfvNV(uint index, float[] v)
        {
            fixed (float* v_ptr = v)
            {
                ViewportIndexedfvNV(index, v_ptr);
            }
        }
        /// <inheritdoc cref="ViewportIndexedfvNV(uint, float*)"/>
        public static unsafe void ViewportIndexedfvNV(uint index, ref readonly float v)
        {
            fixed (float* v_ptr = &v)
            {
                ViewportIndexedfvNV(index, v_ptr);
            }
        }
        /// <inheritdoc cref="WeightPathsNV(uint, int, uint*, float*)"/>
        public static unsafe void WeightPathsNV(uint resultPath, int numPaths, ReadOnlySpan<uint> paths, ReadOnlySpan<float> weights)
        {
            fixed (float* weights_ptr = weights)
            {
                fixed (uint* paths_ptr = paths)
                {
                    WeightPathsNV(resultPath, numPaths, paths_ptr, weights_ptr);
                }
            }
        }
        /// <inheritdoc cref="WeightPathsNV(uint, int, uint*, float*)"/>
        public static unsafe void WeightPathsNV(uint resultPath, int numPaths, uint[] paths, float[] weights)
        {
            fixed (float* weights_ptr = weights)
            {
                fixed (uint* paths_ptr = paths)
                {
                    WeightPathsNV(resultPath, numPaths, paths_ptr, weights_ptr);
                }
            }
        }
        /// <inheritdoc cref="WeightPathsNV(uint, int, uint*, float*)"/>
        public static unsafe void WeightPathsNV(uint resultPath, int numPaths, ref readonly uint paths, ref readonly float weights)
        {
            fixed (uint* paths_ptr = &paths)
            fixed (float* weights_ptr = &weights)
            {
                WeightPathsNV(resultPath, numPaths, paths_ptr, weights_ptr);
            }
        }
    }
    public static unsafe partial class OES
    {
        /// <inheritdoc cref="CompressedTexImage3DOES(TextureTarget, int, InternalFormat, int, int, int, int, int, void*)"/>
        public static unsafe void CompressedTexImage3DOES(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, int imageSize, IntPtr data)
        {
            void* data_vptr = (void*)data;
            CompressedTexImage3DOES(target, level, internalformat, width, height, depth, border, imageSize, data_vptr);
        }
        /// <inheritdoc cref="CompressedTexImage3DOES(TextureTarget, int, InternalFormat, int, int, int, int, int, void*)"/>
        public static unsafe void CompressedTexImage3DOES<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, int imageSize, ReadOnlySpan<T1> data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                CompressedTexImage3DOES(target, level, internalformat, width, height, depth, border, imageSize, data_ptr);
            }
        }
        /// <inheritdoc cref="CompressedTexImage3DOES(TextureTarget, int, InternalFormat, int, int, int, int, int, void*)"/>
        public static unsafe void CompressedTexImage3DOES<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, int imageSize, T1[] data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                CompressedTexImage3DOES(target, level, internalformat, width, height, depth, border, imageSize, data_ptr);
            }
        }
        /// <inheritdoc cref="CompressedTexImage3DOES(TextureTarget, int, InternalFormat, int, int, int, int, int, void*)"/>
        public static unsafe void CompressedTexImage3DOES<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, int imageSize, ref readonly T1 data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = &data)
            {
                CompressedTexImage3DOES(target, level, internalformat, width, height, depth, border, imageSize, data_ptr);
            }
        }
        /// <inheritdoc cref="CompressedTexSubImage3DOES(TextureTarget, int, int, int, int, int, int, int, InternalFormat, int, void*)"/>
        public static unsafe void CompressedTexSubImage3DOES(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, IntPtr data)
        {
            void* data_vptr = (void*)data;
            CompressedTexSubImage3DOES(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data_vptr);
        }
        /// <inheritdoc cref="CompressedTexSubImage3DOES(TextureTarget, int, int, int, int, int, int, int, InternalFormat, int, void*)"/>
        public static unsafe void CompressedTexSubImage3DOES<T1>(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, ReadOnlySpan<T1> data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                CompressedTexSubImage3DOES(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data_ptr);
            }
        }
        /// <inheritdoc cref="CompressedTexSubImage3DOES(TextureTarget, int, int, int, int, int, int, int, InternalFormat, int, void*)"/>
        public static unsafe void CompressedTexSubImage3DOES<T1>(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, T1[] data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = data)
            {
                CompressedTexSubImage3DOES(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data_ptr);
            }
        }
        /// <inheritdoc cref="CompressedTexSubImage3DOES(TextureTarget, int, int, int, int, int, int, int, InternalFormat, int, void*)"/>
        public static unsafe void CompressedTexSubImage3DOES<T1>(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, ref readonly T1 data)
            where T1 : unmanaged
        {
            fixed (void* data_ptr = &data)
            {
                CompressedTexSubImage3DOES(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data_ptr);
            }
        }
        /// <inheritdoc cref="DeleteVertexArraysOES(int, int*)"/>
        public static unsafe void DeleteVertexArraysOES(int n, ReadOnlySpan<int> arrays)
        {
            fixed (int* arrays_ptr = arrays)
            {
                DeleteVertexArraysOES(n, arrays_ptr);
            }
        }
        /// <inheritdoc cref="DeleteVertexArraysOES(int, int*)"/>
        public static unsafe void DeleteVertexArraysOES(int n, int[] arrays)
        {
            fixed (int* arrays_ptr = arrays)
            {
                DeleteVertexArraysOES(n, arrays_ptr);
            }
        }
        /// <inheritdoc cref="DeleteVertexArraysOES(int, int*)"/>
        public static unsafe void DeleteVertexArraysOES(int n, ref readonly int arrays)
        {
            fixed (int* arrays_ptr = &arrays)
            {
                DeleteVertexArraysOES(n, arrays_ptr);
            }
        }
        /// <inheritdoc cref="DepthRangeArrayfvOES(uint, int, float*)"/>
        public static unsafe void DepthRangeArrayfvOES(uint first, int count, ReadOnlySpan<float> v)
        {
            fixed (float* v_ptr = v)
            {
                DepthRangeArrayfvOES(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="DepthRangeArrayfvOES(uint, int, float*)"/>
        public static unsafe void DepthRangeArrayfvOES(uint first, int count, float[] v)
        {
            fixed (float* v_ptr = v)
            {
                DepthRangeArrayfvOES(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="DepthRangeArrayfvOES(uint, int, float*)"/>
        public static unsafe void DepthRangeArrayfvOES(uint first, int count, ref readonly float v)
        {
            fixed (float* v_ptr = &v)
            {
                DepthRangeArrayfvOES(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="DrawElementsBaseVertexOES(PrimitiveType, int, DrawElementsType, void*, int)"/>
        public static unsafe void DrawElementsBaseVertexOES(PrimitiveType mode, int count, DrawElementsType type, nint offset, int basevertex)
        {
            void* indices = (void*)offset;
            DrawElementsBaseVertexOES(mode, count, type, indices, basevertex);
        }
        /// <inheritdoc cref="DrawElementsInstancedBaseVertexOES(PrimitiveType, int, DrawElementsType, void*, int, int)"/>
        public static unsafe void DrawElementsInstancedBaseVertexOES(PrimitiveType mode, int count, DrawElementsType type, nint offset, int instancecount, int basevertex)
        {
            void* indices = (void*)offset;
            DrawElementsInstancedBaseVertexOES(mode, count, type, indices, instancecount, basevertex);
        }
        /// <inheritdoc cref="DrawRangeElementsBaseVertexOES(PrimitiveType, uint, uint, int, DrawElementsType, void*, int)"/>
        public static unsafe void DrawRangeElementsBaseVertexOES(PrimitiveType mode, uint start, uint end, int count, DrawElementsType type, nint offset, int basevertex)
        {
            void* indices = (void*)offset;
            DrawRangeElementsBaseVertexOES(mode, start, end, count, type, indices, basevertex);
        }
        /// <inheritdoc cref="EGLImageTargetRenderbufferStorageOES(All, void*)"/>
        public static unsafe void EGLImageTargetRenderbufferStorageOES(All target, IntPtr image)
        {
            void* image_vptr = (void*)image;
            EGLImageTargetRenderbufferStorageOES(target, image_vptr);
        }
        /// <inheritdoc cref="EGLImageTargetRenderbufferStorageOES(All, void*)"/>
        public static unsafe void EGLImageTargetRenderbufferStorageOES<T1>(All target, Span<T1> image)
            where T1 : unmanaged
        {
            fixed (void* image_ptr = image)
            {
                EGLImageTargetRenderbufferStorageOES(target, image_ptr);
            }
        }
        /// <inheritdoc cref="EGLImageTargetRenderbufferStorageOES(All, void*)"/>
        public static unsafe void EGLImageTargetRenderbufferStorageOES<T1>(All target, T1[] image)
            where T1 : unmanaged
        {
            fixed (void* image_ptr = image)
            {
                EGLImageTargetRenderbufferStorageOES(target, image_ptr);
            }
        }
        /// <inheritdoc cref="EGLImageTargetRenderbufferStorageOES(All, void*)"/>
        public static unsafe void EGLImageTargetRenderbufferStorageOES<T1>(All target, ref T1 image)
            where T1 : unmanaged
        {
            fixed (void* image_ptr = &image)
            {
                EGLImageTargetRenderbufferStorageOES(target, image_ptr);
            }
        }
        /// <inheritdoc cref="EGLImageTargetTexture2DOES(All, void*)"/>
        public static unsafe void EGLImageTargetTexture2DOES(All target, IntPtr image)
        {
            void* image_vptr = (void*)image;
            EGLImageTargetTexture2DOES(target, image_vptr);
        }
        /// <inheritdoc cref="EGLImageTargetTexture2DOES(All, void*)"/>
        public static unsafe void EGLImageTargetTexture2DOES<T1>(All target, Span<T1> image)
            where T1 : unmanaged
        {
            fixed (void* image_ptr = image)
            {
                EGLImageTargetTexture2DOES(target, image_ptr);
            }
        }
        /// <inheritdoc cref="EGLImageTargetTexture2DOES(All, void*)"/>
        public static unsafe void EGLImageTargetTexture2DOES<T1>(All target, T1[] image)
            where T1 : unmanaged
        {
            fixed (void* image_ptr = image)
            {
                EGLImageTargetTexture2DOES(target, image_ptr);
            }
        }
        /// <inheritdoc cref="EGLImageTargetTexture2DOES(All, void*)"/>
        public static unsafe void EGLImageTargetTexture2DOES<T1>(All target, ref T1 image)
            where T1 : unmanaged
        {
            fixed (void* image_ptr = &image)
            {
                EGLImageTargetTexture2DOES(target, image_ptr);
            }
        }
        /// <inheritdoc cref="GenVertexArraysOES(int, int*)"/>
        public static unsafe void GenVertexArraysOES(int n, Span<int> arrays)
        {
            fixed (int* arrays_ptr = arrays)
            {
                GenVertexArraysOES(n, arrays_ptr);
            }
        }
        /// <inheritdoc cref="GenVertexArraysOES(int, int*)"/>
        public static unsafe void GenVertexArraysOES(int n, int[] arrays)
        {
            fixed (int* arrays_ptr = arrays)
            {
                GenVertexArraysOES(n, arrays_ptr);
            }
        }
        /// <inheritdoc cref="GenVertexArraysOES(int, int*)"/>
        public static unsafe void GenVertexArraysOES(int n, ref int arrays)
        {
            fixed (int* arrays_ptr = &arrays)
            {
                GenVertexArraysOES(n, arrays_ptr);
            }
        }
        /// <inheritdoc cref="GetFloati_vOES(GetPName, uint, float*)"/>
        public static unsafe void GetFloati_vOES(GetPName target, uint index, Span<float> data)
        {
            fixed (float* data_ptr = data)
            {
                GetFloati_vOES(target, index, data_ptr);
            }
        }
        /// <inheritdoc cref="GetFloati_vOES(GetPName, uint, float*)"/>
        public static unsafe void GetFloati_vOES(GetPName target, uint index, float[] data)
        {
            fixed (float* data_ptr = data)
            {
                GetFloati_vOES(target, index, data_ptr);
            }
        }
        /// <inheritdoc cref="GetFloati_vOES(GetPName, uint, float*)"/>
        public static unsafe float GetFloati_vOES(GetPName target, uint index)
        {
            float data;
            float* data_ptr = &data;
            {
                GetFloati_vOES(target, index, data_ptr);
            }
            return data;
        }
        /// <inheritdoc cref="GetFloati_vOES(GetPName, uint, float*)"/>
        public static unsafe void GetFloati_vOES(GetPName target, uint index, out float data)
        {
            fixed (float* data_ptr = &data)
            {
                GetFloati_vOES(target, index, data_ptr);
            }
        }
        /// <inheritdoc cref="GetProgramBinaryOES(int, int, int*, All*, void*)"/>
        public static unsafe void GetProgramBinaryOES(int program, int bufSize, out int length, out All binaryFormat, IntPtr binary)
        {
            fixed (int* length_ptr = &length)
            fixed (All* binaryFormat_ptr = &binaryFormat)
            {
                void* binary_vptr = (void*)binary;
                GetProgramBinaryOES(program, bufSize, length_ptr, binaryFormat_ptr, binary_vptr);
            }
        }
        /// <inheritdoc cref="GetProgramBinaryOES(int, int, int*, All*, void*)"/>
        public static unsafe void GetProgramBinaryOES<T1>(int program, int bufSize, out int length, out All binaryFormat, Span<T1> binary)
            where T1 : unmanaged
        {
            fixed (int* length_ptr = &length)
            fixed (All* binaryFormat_ptr = &binaryFormat)
            {
                fixed (void* binary_ptr = binary)
                {
                    GetProgramBinaryOES(program, bufSize, length_ptr, binaryFormat_ptr, binary_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetProgramBinaryOES(int, int, int*, All*, void*)"/>
        public static unsafe void GetProgramBinaryOES<T1>(int program, int bufSize, out int length, out All binaryFormat, T1[] binary)
            where T1 : unmanaged
        {
            fixed (int* length_ptr = &length)
            fixed (All* binaryFormat_ptr = &binaryFormat)
            {
                fixed (void* binary_ptr = binary)
                {
                    GetProgramBinaryOES(program, bufSize, length_ptr, binaryFormat_ptr, binary_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetProgramBinaryOES(int, int, int*, All*, void*)"/>
        public static unsafe void GetProgramBinaryOES<T1>(int program, int bufSize, out int length, out All binaryFormat, ref T1 binary)
            where T1 : unmanaged
        {
            fixed (int* length_ptr = &length)
            fixed (All* binaryFormat_ptr = &binaryFormat)
            fixed (void* binary_ptr = &binary)
            {
                GetProgramBinaryOES(program, bufSize, length_ptr, binaryFormat_ptr, binary_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameterIivOES(int, SamplerParameterI, int*)"/>
        public static unsafe void GetSamplerParameterIivOES(int sampler, SamplerParameterI pname, Span<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetSamplerParameterIivOES(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameterIivOES(int, SamplerParameterI, int*)"/>
        public static unsafe void GetSamplerParameterIivOES(int sampler, SamplerParameterI pname, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetSamplerParameterIivOES(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameterIivOES(int, SamplerParameterI, int*)"/>
        public static unsafe int GetSamplerParameterIivOES(int sampler, SamplerParameterI pname)
        {
            int parameters;
            int* parameters_ptr = &parameters;
            {
                GetSamplerParameterIivOES(sampler, pname, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetSamplerParameterIivOES(int, SamplerParameterI, int*)"/>
        public static unsafe void GetSamplerParameterIivOES(int sampler, SamplerParameterI pname, out int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                GetSamplerParameterIivOES(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameterIuivOES(int, SamplerParameterI, uint*)"/>
        public static unsafe void GetSamplerParameterIuivOES(int sampler, SamplerParameterI pname, Span<uint> parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                GetSamplerParameterIuivOES(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameterIuivOES(int, SamplerParameterI, uint*)"/>
        public static unsafe void GetSamplerParameterIuivOES(int sampler, SamplerParameterI pname, uint[] parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                GetSamplerParameterIuivOES(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetSamplerParameterIuivOES(int, SamplerParameterI, uint*)"/>
        public static unsafe uint GetSamplerParameterIuivOES(int sampler, SamplerParameterI pname)
        {
            uint parameters;
            uint* parameters_ptr = &parameters;
            {
                GetSamplerParameterIuivOES(sampler, pname, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetSamplerParameterIuivOES(int, SamplerParameterI, uint*)"/>
        public static unsafe void GetSamplerParameterIuivOES(int sampler, SamplerParameterI pname, out uint parameters)
        {
            fixed (uint* parameters_ptr = &parameters)
            {
                GetSamplerParameterIuivOES(sampler, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetTexParameterIivOES(TextureTarget, GetTextureParameter, int*)"/>
        public static unsafe void GetTexParameterIivOES(TextureTarget target, GetTextureParameter pname, Span<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetTexParameterIivOES(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetTexParameterIivOES(TextureTarget, GetTextureParameter, int*)"/>
        public static unsafe void GetTexParameterIivOES(TextureTarget target, GetTextureParameter pname, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                GetTexParameterIivOES(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetTexParameterIivOES(TextureTarget, GetTextureParameter, int*)"/>
        public static unsafe int GetTexParameterIivOES(TextureTarget target, GetTextureParameter pname)
        {
            int parameters;
            int* parameters_ptr = &parameters;
            {
                GetTexParameterIivOES(target, pname, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetTexParameterIivOES(TextureTarget, GetTextureParameter, int*)"/>
        public static unsafe void GetTexParameterIivOES(TextureTarget target, GetTextureParameter pname, out int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                GetTexParameterIivOES(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetTexParameterIuivOES(TextureTarget, GetTextureParameter, uint*)"/>
        public static unsafe void GetTexParameterIuivOES(TextureTarget target, GetTextureParameter pname, Span<uint> parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                GetTexParameterIuivOES(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetTexParameterIuivOES(TextureTarget, GetTextureParameter, uint*)"/>
        public static unsafe void GetTexParameterIuivOES(TextureTarget target, GetTextureParameter pname, uint[] parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                GetTexParameterIuivOES(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="GetTexParameterIuivOES(TextureTarget, GetTextureParameter, uint*)"/>
        public static unsafe uint GetTexParameterIuivOES(TextureTarget target, GetTextureParameter pname)
        {
            uint parameters;
            uint* parameters_ptr = &parameters;
            {
                GetTexParameterIuivOES(target, pname, parameters_ptr);
            }
            return parameters;
        }
        /// <inheritdoc cref="GetTexParameterIuivOES(TextureTarget, GetTextureParameter, uint*)"/>
        public static unsafe void GetTexParameterIuivOES(TextureTarget target, GetTextureParameter pname, out uint parameters)
        {
            fixed (uint* parameters_ptr = &parameters)
            {
                GetTexParameterIuivOES(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="MultiDrawElementsBaseVertexEXT(PrimitiveType, int*, DrawElementsType, void**, int, int*)"/>
        public static unsafe void MultiDrawElementsBaseVertexEXT(PrimitiveType mode, ReadOnlySpan<int> count, DrawElementsType type, void** indices, int drawcount, ReadOnlySpan<int> basevertex)
        {
            fixed (int* basevertex_ptr = basevertex)
            {
                fixed (int* count_ptr = count)
                {
                    MultiDrawElementsBaseVertexEXT(mode, count_ptr, type, indices, drawcount, basevertex_ptr);
                }
            }
        }
        /// <inheritdoc cref="MultiDrawElementsBaseVertexEXT(PrimitiveType, int*, DrawElementsType, void**, int, int*)"/>
        public static unsafe void MultiDrawElementsBaseVertexEXT(PrimitiveType mode, int[] count, DrawElementsType type, void** indices, int drawcount, int[] basevertex)
        {
            fixed (int* basevertex_ptr = basevertex)
            {
                fixed (int* count_ptr = count)
                {
                    MultiDrawElementsBaseVertexEXT(mode, count_ptr, type, indices, drawcount, basevertex_ptr);
                }
            }
        }
        /// <inheritdoc cref="MultiDrawElementsBaseVertexEXT(PrimitiveType, int*, DrawElementsType, void**, int, int*)"/>
        public static unsafe void MultiDrawElementsBaseVertexEXT(PrimitiveType mode, ref readonly int count, DrawElementsType type, void** indices, int drawcount, ref readonly int basevertex)
        {
            fixed (int* count_ptr = &count)
            fixed (int* basevertex_ptr = &basevertex)
            {
                MultiDrawElementsBaseVertexEXT(mode, count_ptr, type, indices, drawcount, basevertex_ptr);
            }
        }
        /// <inheritdoc cref="ProgramBinaryOES(int, All, void*, int)"/>
        public static unsafe void ProgramBinaryOES(int program, All binaryFormat, IntPtr binary, int length)
        {
            void* binary_vptr = (void*)binary;
            ProgramBinaryOES(program, binaryFormat, binary_vptr, length);
        }
        /// <inheritdoc cref="ProgramBinaryOES(int, All, void*, int)"/>
        public static unsafe void ProgramBinaryOES<T1>(int program, All binaryFormat, ReadOnlySpan<T1> binary, int length)
            where T1 : unmanaged
        {
            fixed (void* binary_ptr = binary)
            {
                ProgramBinaryOES(program, binaryFormat, binary_ptr, length);
            }
        }
        /// <inheritdoc cref="ProgramBinaryOES(int, All, void*, int)"/>
        public static unsafe void ProgramBinaryOES<T1>(int program, All binaryFormat, T1[] binary, int length)
            where T1 : unmanaged
        {
            fixed (void* binary_ptr = binary)
            {
                ProgramBinaryOES(program, binaryFormat, binary_ptr, length);
            }
        }
        /// <inheritdoc cref="ProgramBinaryOES(int, All, void*, int)"/>
        public static unsafe void ProgramBinaryOES<T1>(int program, All binaryFormat, ref readonly T1 binary, int length)
            where T1 : unmanaged
        {
            fixed (void* binary_ptr = &binary)
            {
                ProgramBinaryOES(program, binaryFormat, binary_ptr, length);
            }
        }
        /// <inheritdoc cref="SamplerParameterIivOES(int, SamplerParameterI, int*)"/>
        public static unsafe void SamplerParameterIivOES(int sampler, SamplerParameterI pname, ReadOnlySpan<int> param)
        {
            fixed (int* param_ptr = param)
            {
                SamplerParameterIivOES(sampler, pname, param_ptr);
            }
        }
        /// <inheritdoc cref="SamplerParameterIivOES(int, SamplerParameterI, int*)"/>
        public static unsafe void SamplerParameterIivOES(int sampler, SamplerParameterI pname, int[] param)
        {
            fixed (int* param_ptr = param)
            {
                SamplerParameterIivOES(sampler, pname, param_ptr);
            }
        }
        /// <inheritdoc cref="SamplerParameterIivOES(int, SamplerParameterI, int*)"/>
        public static unsafe void SamplerParameterIivOES(int sampler, SamplerParameterI pname, ref readonly int param)
        {
            fixed (int* param_ptr = &param)
            {
                SamplerParameterIivOES(sampler, pname, param_ptr);
            }
        }
        /// <inheritdoc cref="SamplerParameterIuivOES(int, SamplerParameterI, uint*)"/>
        public static unsafe void SamplerParameterIuivOES(int sampler, SamplerParameterI pname, ReadOnlySpan<uint> param)
        {
            fixed (uint* param_ptr = param)
            {
                SamplerParameterIuivOES(sampler, pname, param_ptr);
            }
        }
        /// <inheritdoc cref="SamplerParameterIuivOES(int, SamplerParameterI, uint*)"/>
        public static unsafe void SamplerParameterIuivOES(int sampler, SamplerParameterI pname, uint[] param)
        {
            fixed (uint* param_ptr = param)
            {
                SamplerParameterIuivOES(sampler, pname, param_ptr);
            }
        }
        /// <inheritdoc cref="SamplerParameterIuivOES(int, SamplerParameterI, uint*)"/>
        public static unsafe void SamplerParameterIuivOES(int sampler, SamplerParameterI pname, ref readonly uint param)
        {
            fixed (uint* param_ptr = &param)
            {
                SamplerParameterIuivOES(sampler, pname, param_ptr);
            }
        }
        /// <inheritdoc cref="ScissorArrayvOES(uint, int, int*)"/>
        public static unsafe void ScissorArrayvOES(uint first, int count, ReadOnlySpan<int> v)
        {
            fixed (int* v_ptr = v)
            {
                ScissorArrayvOES(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="ScissorArrayvOES(uint, int, int*)"/>
        public static unsafe void ScissorArrayvOES(uint first, int count, int[] v)
        {
            fixed (int* v_ptr = v)
            {
                ScissorArrayvOES(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="ScissorArrayvOES(uint, int, int*)"/>
        public static unsafe void ScissorArrayvOES(uint first, int count, ref readonly int v)
        {
            fixed (int* v_ptr = &v)
            {
                ScissorArrayvOES(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="ScissorIndexedvOES(uint, int*)"/>
        public static unsafe void ScissorIndexedvOES(uint index, ReadOnlySpan<int> v)
        {
            fixed (int* v_ptr = v)
            {
                ScissorIndexedvOES(index, v_ptr);
            }
        }
        /// <inheritdoc cref="ScissorIndexedvOES(uint, int*)"/>
        public static unsafe void ScissorIndexedvOES(uint index, int[] v)
        {
            fixed (int* v_ptr = v)
            {
                ScissorIndexedvOES(index, v_ptr);
            }
        }
        /// <inheritdoc cref="ScissorIndexedvOES(uint, int*)"/>
        public static unsafe void ScissorIndexedvOES(uint index, ref readonly int v)
        {
            fixed (int* v_ptr = &v)
            {
                ScissorIndexedvOES(index, v_ptr);
            }
        }
        /// <inheritdoc cref="TexImage3DOES(TextureTarget, int, InternalFormat, int, int, int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void TexImage3DOES(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, IntPtr pixels)
        {
            void* pixels_vptr = (void*)pixels;
            TexImage3DOES(target, level, internalformat, width, height, depth, border, format, type, pixels_vptr);
        }
        /// <inheritdoc cref="TexImage3DOES(TextureTarget, int, InternalFormat, int, int, int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void TexImage3DOES<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, ReadOnlySpan<T1> pixels)
            where T1 : unmanaged
        {
            fixed (void* pixels_ptr = pixels)
            {
                TexImage3DOES(target, level, internalformat, width, height, depth, border, format, type, pixels_ptr);
            }
        }
        /// <inheritdoc cref="TexImage3DOES(TextureTarget, int, InternalFormat, int, int, int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void TexImage3DOES<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, T1[] pixels)
            where T1 : unmanaged
        {
            fixed (void* pixels_ptr = pixels)
            {
                TexImage3DOES(target, level, internalformat, width, height, depth, border, format, type, pixels_ptr);
            }
        }
        /// <inheritdoc cref="TexImage3DOES(TextureTarget, int, InternalFormat, int, int, int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void TexImage3DOES<T1>(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, ref readonly T1 pixels)
            where T1 : unmanaged
        {
            fixed (void* pixels_ptr = &pixels)
            {
                TexImage3DOES(target, level, internalformat, width, height, depth, border, format, type, pixels_ptr);
            }
        }
        /// <inheritdoc cref="TexParameterIivOES(TextureTarget, TextureParameterName, int*)"/>
        public static unsafe void TexParameterIivOES(TextureTarget target, TextureParameterName pname, ReadOnlySpan<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                TexParameterIivOES(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="TexParameterIivOES(TextureTarget, TextureParameterName, int*)"/>
        public static unsafe void TexParameterIivOES(TextureTarget target, TextureParameterName pname, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                TexParameterIivOES(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="TexParameterIivOES(TextureTarget, TextureParameterName, int*)"/>
        public static unsafe void TexParameterIivOES(TextureTarget target, TextureParameterName pname, ref readonly int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                TexParameterIivOES(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="TexParameterIuivOES(TextureTarget, TextureParameterName, uint*)"/>
        public static unsafe void TexParameterIuivOES(TextureTarget target, TextureParameterName pname, ReadOnlySpan<uint> parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                TexParameterIuivOES(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="TexParameterIuivOES(TextureTarget, TextureParameterName, uint*)"/>
        public static unsafe void TexParameterIuivOES(TextureTarget target, TextureParameterName pname, uint[] parameters)
        {
            fixed (uint* parameters_ptr = parameters)
            {
                TexParameterIuivOES(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="TexParameterIuivOES(TextureTarget, TextureParameterName, uint*)"/>
        public static unsafe void TexParameterIuivOES(TextureTarget target, TextureParameterName pname, ref readonly uint parameters)
        {
            fixed (uint* parameters_ptr = &parameters)
            {
                TexParameterIuivOES(target, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="TexSubImage3DOES(TextureTarget, int, int, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void TexSubImage3DOES(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, IntPtr pixels)
        {
            void* pixels_vptr = (void*)pixels;
            TexSubImage3DOES(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels_vptr);
        }
        /// <inheritdoc cref="TexSubImage3DOES(TextureTarget, int, int, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void TexSubImage3DOES<T1>(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, ReadOnlySpan<T1> pixels)
            where T1 : unmanaged
        {
            fixed (void* pixels_ptr = pixels)
            {
                TexSubImage3DOES(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels_ptr);
            }
        }
        /// <inheritdoc cref="TexSubImage3DOES(TextureTarget, int, int, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void TexSubImage3DOES<T1>(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, T1[] pixels)
            where T1 : unmanaged
        {
            fixed (void* pixels_ptr = pixels)
            {
                TexSubImage3DOES(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels_ptr);
            }
        }
        /// <inheritdoc cref="TexSubImage3DOES(TextureTarget, int, int, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void TexSubImage3DOES<T1>(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, ref readonly T1 pixels)
            where T1 : unmanaged
        {
            fixed (void* pixels_ptr = &pixels)
            {
                TexSubImage3DOES(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels_ptr);
            }
        }
        /// <inheritdoc cref="ViewportArrayvOES(uint, int, float*)"/>
        public static unsafe void ViewportArrayvOES(uint first, int count, ReadOnlySpan<float> v)
        {
            fixed (float* v_ptr = v)
            {
                ViewportArrayvOES(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="ViewportArrayvOES(uint, int, float*)"/>
        public static unsafe void ViewportArrayvOES(uint first, int count, float[] v)
        {
            fixed (float* v_ptr = v)
            {
                ViewportArrayvOES(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="ViewportArrayvOES(uint, int, float*)"/>
        public static unsafe void ViewportArrayvOES(uint first, int count, ref readonly float v)
        {
            fixed (float* v_ptr = &v)
            {
                ViewportArrayvOES(first, count, v_ptr);
            }
        }
        /// <inheritdoc cref="ViewportIndexedfvOES(uint, float*)"/>
        public static unsafe void ViewportIndexedfvOES(uint index, ReadOnlySpan<float> v)
        {
            fixed (float* v_ptr = v)
            {
                ViewportIndexedfvOES(index, v_ptr);
            }
        }
        /// <inheritdoc cref="ViewportIndexedfvOES(uint, float*)"/>
        public static unsafe void ViewportIndexedfvOES(uint index, float[] v)
        {
            fixed (float* v_ptr = v)
            {
                ViewportIndexedfvOES(index, v_ptr);
            }
        }
        /// <inheritdoc cref="ViewportIndexedfvOES(uint, float*)"/>
        public static unsafe void ViewportIndexedfvOES(uint index, ref readonly float v)
        {
            fixed (float* v_ptr = &v)
            {
                ViewportIndexedfvOES(index, v_ptr);
            }
        }
    }
    public static unsafe partial class OVR
    {
    }
    public static unsafe partial class QCOM
    {
        /// <inheritdoc cref="ExtGetBuffersQCOM(int*, int, int*)"/>
        public static unsafe int ExtGetBuffersQCOM(Span<int> buffers, int maxBuffers)
        {
            int numBuffers;
            int* numBuffers_ptr = &numBuffers;
            {
                fixed (int* buffers_ptr = buffers)
                {
                    ExtGetBuffersQCOM(buffers_ptr, maxBuffers, numBuffers_ptr);
                }
            }
            return numBuffers;
        }
        /// <inheritdoc cref="ExtGetBuffersQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetBuffersQCOM(Span<int> buffers, int maxBuffers, out int numBuffers)
        {
            fixed (int* numBuffers_ptr = &numBuffers)
            {
                fixed (int* buffers_ptr = buffers)
                {
                    ExtGetBuffersQCOM(buffers_ptr, maxBuffers, numBuffers_ptr);
                }
            }
        }
        /// <inheritdoc cref="ExtGetBuffersQCOM(int*, int, int*)"/>
        public static unsafe int ExtGetBuffersQCOM(int[] buffers, int maxBuffers)
        {
            int numBuffers;
            int* numBuffers_ptr = &numBuffers;
            {
                fixed (int* buffers_ptr = buffers)
                {
                    ExtGetBuffersQCOM(buffers_ptr, maxBuffers, numBuffers_ptr);
                }
            }
            return numBuffers;
        }
        /// <inheritdoc cref="ExtGetBuffersQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetBuffersQCOM(int[] buffers, int maxBuffers, out int numBuffers)
        {
            fixed (int* numBuffers_ptr = &numBuffers)
            {
                fixed (int* buffers_ptr = buffers)
                {
                    ExtGetBuffersQCOM(buffers_ptr, maxBuffers, numBuffers_ptr);
                }
            }
        }
        /// <inheritdoc cref="ExtGetBuffersQCOM(int*, int, int*)"/>
        public static unsafe int ExtGetBuffersQCOM(ref int buffers, int maxBuffers)
        {
            int numBuffers;
            int* numBuffers_ptr = &numBuffers;
            fixed (int* buffers_ptr = &buffers)
            {
                ExtGetBuffersQCOM(buffers_ptr, maxBuffers, numBuffers_ptr);
            }
            return numBuffers;
        }
        /// <inheritdoc cref="ExtGetBuffersQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetBuffersQCOM(ref int buffers, int maxBuffers, out int numBuffers)
        {
            fixed (int* buffers_ptr = &buffers)
            fixed (int* numBuffers_ptr = &numBuffers)
            {
                ExtGetBuffersQCOM(buffers_ptr, maxBuffers, numBuffers_ptr);
            }
        }
        /// <inheritdoc cref="ExtGetFramebuffersQCOM(int*, int, int*)"/>
        public static unsafe int ExtGetFramebuffersQCOM(Span<int> framebuffers, int maxFramebuffers)
        {
            int numFramebuffers;
            int* numFramebuffers_ptr = &numFramebuffers;
            {
                fixed (int* framebuffers_ptr = framebuffers)
                {
                    ExtGetFramebuffersQCOM(framebuffers_ptr, maxFramebuffers, numFramebuffers_ptr);
                }
            }
            return numFramebuffers;
        }
        /// <inheritdoc cref="ExtGetFramebuffersQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetFramebuffersQCOM(Span<int> framebuffers, int maxFramebuffers, out int numFramebuffers)
        {
            fixed (int* numFramebuffers_ptr = &numFramebuffers)
            {
                fixed (int* framebuffers_ptr = framebuffers)
                {
                    ExtGetFramebuffersQCOM(framebuffers_ptr, maxFramebuffers, numFramebuffers_ptr);
                }
            }
        }
        /// <inheritdoc cref="ExtGetFramebuffersQCOM(int*, int, int*)"/>
        public static unsafe int ExtGetFramebuffersQCOM(int[] framebuffers, int maxFramebuffers)
        {
            int numFramebuffers;
            int* numFramebuffers_ptr = &numFramebuffers;
            {
                fixed (int* framebuffers_ptr = framebuffers)
                {
                    ExtGetFramebuffersQCOM(framebuffers_ptr, maxFramebuffers, numFramebuffers_ptr);
                }
            }
            return numFramebuffers;
        }
        /// <inheritdoc cref="ExtGetFramebuffersQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetFramebuffersQCOM(int[] framebuffers, int maxFramebuffers, out int numFramebuffers)
        {
            fixed (int* numFramebuffers_ptr = &numFramebuffers)
            {
                fixed (int* framebuffers_ptr = framebuffers)
                {
                    ExtGetFramebuffersQCOM(framebuffers_ptr, maxFramebuffers, numFramebuffers_ptr);
                }
            }
        }
        /// <inheritdoc cref="ExtGetFramebuffersQCOM(int*, int, int*)"/>
        public static unsafe int ExtGetFramebuffersQCOM(ref int framebuffers, int maxFramebuffers)
        {
            int numFramebuffers;
            int* numFramebuffers_ptr = &numFramebuffers;
            fixed (int* framebuffers_ptr = &framebuffers)
            {
                ExtGetFramebuffersQCOM(framebuffers_ptr, maxFramebuffers, numFramebuffers_ptr);
            }
            return numFramebuffers;
        }
        /// <inheritdoc cref="ExtGetFramebuffersQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetFramebuffersQCOM(ref int framebuffers, int maxFramebuffers, out int numFramebuffers)
        {
            fixed (int* framebuffers_ptr = &framebuffers)
            fixed (int* numFramebuffers_ptr = &numFramebuffers)
            {
                ExtGetFramebuffersQCOM(framebuffers_ptr, maxFramebuffers, numFramebuffers_ptr);
            }
        }
        /// <inheritdoc cref="ExtGetProgramBinarySourceQCOM(int, ShaderType, byte*, int*)"/>
        public static unsafe void ExtGetProgramBinarySourceQCOM(int program, ShaderType shadertype, out string source, Span<int> length)
        {
            fixed (int* length_ptr = length)
            {
                var source_ptr = (byte*)Marshal.AllocCoTaskMem(*length_ptr);
                ExtGetProgramBinarySourceQCOM(program, shadertype, source_ptr, length_ptr);
                source = Marshal.PtrToStringUTF8((IntPtr)source_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)source_ptr);
            }
        }
        /// <inheritdoc cref="ExtGetProgramBinarySourceQCOM(int, ShaderType, byte*, int*)"/>
        public static unsafe void ExtGetProgramBinarySourceQCOM(int program, ShaderType shadertype, out string source, int[] length)
        {
            fixed (int* length_ptr = length)
            {
                var source_ptr = (byte*)Marshal.AllocCoTaskMem(*length_ptr);
                ExtGetProgramBinarySourceQCOM(program, shadertype, source_ptr, length_ptr);
                source = Marshal.PtrToStringUTF8((IntPtr)source_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)source_ptr);
            }
        }
        /// <inheritdoc cref="ExtGetProgramBinarySourceQCOM(int, ShaderType, byte*, int*)"/>
        public static unsafe void ExtGetProgramBinarySourceQCOM(int program, ShaderType shadertype, out string source, ref int length)
        {
            fixed (int* length_ptr = &length)
            {
                var source_ptr = (byte*)Marshal.AllocCoTaskMem(*length_ptr);
                ExtGetProgramBinarySourceQCOM(program, shadertype, source_ptr, length_ptr);
                source = Marshal.PtrToStringUTF8((IntPtr)source_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)source_ptr);
            }
        }
        /// <inheritdoc cref="ExtGetProgramsQCOM(int*, int, int*)"/>
        public static unsafe int ExtGetProgramsQCOM(Span<int> programs, int maxPrograms)
        {
            int numPrograms;
            int* numPrograms_ptr = &numPrograms;
            {
                fixed (int* programs_ptr = programs)
                {
                    ExtGetProgramsQCOM(programs_ptr, maxPrograms, numPrograms_ptr);
                }
            }
            return numPrograms;
        }
        /// <inheritdoc cref="ExtGetProgramsQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetProgramsQCOM(Span<int> programs, int maxPrograms, out int numPrograms)
        {
            fixed (int* numPrograms_ptr = &numPrograms)
            {
                fixed (int* programs_ptr = programs)
                {
                    ExtGetProgramsQCOM(programs_ptr, maxPrograms, numPrograms_ptr);
                }
            }
        }
        /// <inheritdoc cref="ExtGetProgramsQCOM(int*, int, int*)"/>
        public static unsafe int ExtGetProgramsQCOM(int[] programs, int maxPrograms)
        {
            int numPrograms;
            int* numPrograms_ptr = &numPrograms;
            {
                fixed (int* programs_ptr = programs)
                {
                    ExtGetProgramsQCOM(programs_ptr, maxPrograms, numPrograms_ptr);
                }
            }
            return numPrograms;
        }
        /// <inheritdoc cref="ExtGetProgramsQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetProgramsQCOM(int[] programs, int maxPrograms, out int numPrograms)
        {
            fixed (int* numPrograms_ptr = &numPrograms)
            {
                fixed (int* programs_ptr = programs)
                {
                    ExtGetProgramsQCOM(programs_ptr, maxPrograms, numPrograms_ptr);
                }
            }
        }
        /// <inheritdoc cref="ExtGetProgramsQCOM(int*, int, int*)"/>
        public static unsafe int ExtGetProgramsQCOM(ref int programs, int maxPrograms)
        {
            int numPrograms;
            int* numPrograms_ptr = &numPrograms;
            fixed (int* programs_ptr = &programs)
            {
                ExtGetProgramsQCOM(programs_ptr, maxPrograms, numPrograms_ptr);
            }
            return numPrograms;
        }
        /// <inheritdoc cref="ExtGetProgramsQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetProgramsQCOM(ref int programs, int maxPrograms, out int numPrograms)
        {
            fixed (int* programs_ptr = &programs)
            fixed (int* numPrograms_ptr = &numPrograms)
            {
                ExtGetProgramsQCOM(programs_ptr, maxPrograms, numPrograms_ptr);
            }
        }
        /// <inheritdoc cref="ExtGetRenderbuffersQCOM(int*, int, int*)"/>
        public static unsafe int ExtGetRenderbuffersQCOM(Span<int> renderbuffers, int maxRenderbuffers)
        {
            int numRenderbuffers;
            int* numRenderbuffers_ptr = &numRenderbuffers;
            {
                fixed (int* renderbuffers_ptr = renderbuffers)
                {
                    ExtGetRenderbuffersQCOM(renderbuffers_ptr, maxRenderbuffers, numRenderbuffers_ptr);
                }
            }
            return numRenderbuffers;
        }
        /// <inheritdoc cref="ExtGetRenderbuffersQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetRenderbuffersQCOM(Span<int> renderbuffers, int maxRenderbuffers, out int numRenderbuffers)
        {
            fixed (int* numRenderbuffers_ptr = &numRenderbuffers)
            {
                fixed (int* renderbuffers_ptr = renderbuffers)
                {
                    ExtGetRenderbuffersQCOM(renderbuffers_ptr, maxRenderbuffers, numRenderbuffers_ptr);
                }
            }
        }
        /// <inheritdoc cref="ExtGetRenderbuffersQCOM(int*, int, int*)"/>
        public static unsafe int ExtGetRenderbuffersQCOM(int[] renderbuffers, int maxRenderbuffers)
        {
            int numRenderbuffers;
            int* numRenderbuffers_ptr = &numRenderbuffers;
            {
                fixed (int* renderbuffers_ptr = renderbuffers)
                {
                    ExtGetRenderbuffersQCOM(renderbuffers_ptr, maxRenderbuffers, numRenderbuffers_ptr);
                }
            }
            return numRenderbuffers;
        }
        /// <inheritdoc cref="ExtGetRenderbuffersQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetRenderbuffersQCOM(int[] renderbuffers, int maxRenderbuffers, out int numRenderbuffers)
        {
            fixed (int* numRenderbuffers_ptr = &numRenderbuffers)
            {
                fixed (int* renderbuffers_ptr = renderbuffers)
                {
                    ExtGetRenderbuffersQCOM(renderbuffers_ptr, maxRenderbuffers, numRenderbuffers_ptr);
                }
            }
        }
        /// <inheritdoc cref="ExtGetRenderbuffersQCOM(int*, int, int*)"/>
        public static unsafe int ExtGetRenderbuffersQCOM(ref int renderbuffers, int maxRenderbuffers)
        {
            int numRenderbuffers;
            int* numRenderbuffers_ptr = &numRenderbuffers;
            fixed (int* renderbuffers_ptr = &renderbuffers)
            {
                ExtGetRenderbuffersQCOM(renderbuffers_ptr, maxRenderbuffers, numRenderbuffers_ptr);
            }
            return numRenderbuffers;
        }
        /// <inheritdoc cref="ExtGetRenderbuffersQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetRenderbuffersQCOM(ref int renderbuffers, int maxRenderbuffers, out int numRenderbuffers)
        {
            fixed (int* renderbuffers_ptr = &renderbuffers)
            fixed (int* numRenderbuffers_ptr = &numRenderbuffers)
            {
                ExtGetRenderbuffersQCOM(renderbuffers_ptr, maxRenderbuffers, numRenderbuffers_ptr);
            }
        }
        /// <inheritdoc cref="ExtGetShadersQCOM(int*, int, int*)"/>
        public static unsafe int ExtGetShadersQCOM(Span<int> shaders, int maxShaders)
        {
            int numShaders;
            int* numShaders_ptr = &numShaders;
            {
                fixed (int* shaders_ptr = shaders)
                {
                    ExtGetShadersQCOM(shaders_ptr, maxShaders, numShaders_ptr);
                }
            }
            return numShaders;
        }
        /// <inheritdoc cref="ExtGetShadersQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetShadersQCOM(Span<int> shaders, int maxShaders, out int numShaders)
        {
            fixed (int* numShaders_ptr = &numShaders)
            {
                fixed (int* shaders_ptr = shaders)
                {
                    ExtGetShadersQCOM(shaders_ptr, maxShaders, numShaders_ptr);
                }
            }
        }
        /// <inheritdoc cref="ExtGetShadersQCOM(int*, int, int*)"/>
        public static unsafe int ExtGetShadersQCOM(int[] shaders, int maxShaders)
        {
            int numShaders;
            int* numShaders_ptr = &numShaders;
            {
                fixed (int* shaders_ptr = shaders)
                {
                    ExtGetShadersQCOM(shaders_ptr, maxShaders, numShaders_ptr);
                }
            }
            return numShaders;
        }
        /// <inheritdoc cref="ExtGetShadersQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetShadersQCOM(int[] shaders, int maxShaders, out int numShaders)
        {
            fixed (int* numShaders_ptr = &numShaders)
            {
                fixed (int* shaders_ptr = shaders)
                {
                    ExtGetShadersQCOM(shaders_ptr, maxShaders, numShaders_ptr);
                }
            }
        }
        /// <inheritdoc cref="ExtGetShadersQCOM(int*, int, int*)"/>
        public static unsafe int ExtGetShadersQCOM(ref int shaders, int maxShaders)
        {
            int numShaders;
            int* numShaders_ptr = &numShaders;
            fixed (int* shaders_ptr = &shaders)
            {
                ExtGetShadersQCOM(shaders_ptr, maxShaders, numShaders_ptr);
            }
            return numShaders;
        }
        /// <inheritdoc cref="ExtGetShadersQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetShadersQCOM(ref int shaders, int maxShaders, out int numShaders)
        {
            fixed (int* shaders_ptr = &shaders)
            fixed (int* numShaders_ptr = &numShaders)
            {
                ExtGetShadersQCOM(shaders_ptr, maxShaders, numShaders_ptr);
            }
        }
        /// <inheritdoc cref="ExtGetTexLevelParameterivQCOM(int, All, int, All, int*)"/>
        public static unsafe void ExtGetTexLevelParameterivQCOM(int texture, All face, int level, All pname, Span<int> parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                ExtGetTexLevelParameterivQCOM(texture, face, level, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="ExtGetTexLevelParameterivQCOM(int, All, int, All, int*)"/>
        public static unsafe void ExtGetTexLevelParameterivQCOM(int texture, All face, int level, All pname, int[] parameters)
        {
            fixed (int* parameters_ptr = parameters)
            {
                ExtGetTexLevelParameterivQCOM(texture, face, level, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="ExtGetTexLevelParameterivQCOM(int, All, int, All, int*)"/>
        public static unsafe void ExtGetTexLevelParameterivQCOM(int texture, All face, int level, All pname, ref int parameters)
        {
            fixed (int* parameters_ptr = &parameters)
            {
                ExtGetTexLevelParameterivQCOM(texture, face, level, pname, parameters_ptr);
            }
        }
        /// <inheritdoc cref="ExtGetTexSubImageQCOM(All, int, int, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void ExtGetTexSubImageQCOM(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, IntPtr texels)
        {
            void* texels_vptr = (void*)texels;
            ExtGetTexSubImageQCOM(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, texels_vptr);
        }
        /// <inheritdoc cref="ExtGetTexSubImageQCOM(All, int, int, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void ExtGetTexSubImageQCOM<T1>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, Span<T1> texels)
            where T1 : unmanaged
        {
            fixed (void* texels_ptr = texels)
            {
                ExtGetTexSubImageQCOM(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, texels_ptr);
            }
        }
        /// <inheritdoc cref="ExtGetTexSubImageQCOM(All, int, int, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void ExtGetTexSubImageQCOM<T1>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, T1[] texels)
            where T1 : unmanaged
        {
            fixed (void* texels_ptr = texels)
            {
                ExtGetTexSubImageQCOM(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, texels_ptr);
            }
        }
        /// <inheritdoc cref="ExtGetTexSubImageQCOM(All, int, int, int, int, int, int, int, PixelFormat, PixelType, void*)"/>
        public static unsafe void ExtGetTexSubImageQCOM<T1>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, ref T1 texels)
            where T1 : unmanaged
        {
            fixed (void* texels_ptr = &texels)
            {
                ExtGetTexSubImageQCOM(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, texels_ptr);
            }
        }
        /// <inheritdoc cref="ExtGetTexturesQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetTexturesQCOM(Span<int> textures, int maxTextures, Span<int> numTextures)
        {
            fixed (int* numTextures_ptr = numTextures)
            {
                fixed (int* textures_ptr = textures)
                {
                    ExtGetTexturesQCOM(textures_ptr, maxTextures, numTextures_ptr);
                }
            }
        }
        /// <inheritdoc cref="ExtGetTexturesQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetTexturesQCOM(int[] textures, int maxTextures, int[] numTextures)
        {
            fixed (int* numTextures_ptr = numTextures)
            {
                fixed (int* textures_ptr = textures)
                {
                    ExtGetTexturesQCOM(textures_ptr, maxTextures, numTextures_ptr);
                }
            }
        }
        /// <inheritdoc cref="ExtGetTexturesQCOM(int*, int, int*)"/>
        public static unsafe void ExtGetTexturesQCOM(ref int textures, int maxTextures, ref int numTextures)
        {
            fixed (int* textures_ptr = &textures)
            fixed (int* numTextures_ptr = &numTextures)
            {
                ExtGetTexturesQCOM(textures_ptr, maxTextures, numTextures_ptr);
            }
        }
        /// <inheritdoc cref="FramebufferFoveationConfigQCOM(int, uint, uint, uint, uint*)"/>
        public static unsafe uint FramebufferFoveationConfigQCOM(int framebuffer, uint numLayers, uint focalPointsPerLayer, uint requestedFeatures)
        {
            uint providedFeatures;
            uint* providedFeatures_ptr = &providedFeatures;
            {
                FramebufferFoveationConfigQCOM(framebuffer, numLayers, focalPointsPerLayer, requestedFeatures, providedFeatures_ptr);
            }
            return providedFeatures;
        }
        /// <inheritdoc cref="FramebufferFoveationConfigQCOM(int, uint, uint, uint, uint*)"/>
        public static unsafe void FramebufferFoveationConfigQCOM(int framebuffer, uint numLayers, uint focalPointsPerLayer, uint requestedFeatures, out uint providedFeatures)
        {
            fixed (uint* providedFeatures_ptr = &providedFeatures)
            {
                FramebufferFoveationConfigQCOM(framebuffer, numLayers, focalPointsPerLayer, requestedFeatures, providedFeatures_ptr);
            }
        }
        /// <inheritdoc cref="GetDriverControlsQCOM(int*, int, uint*)"/>
        public static unsafe void GetDriverControlsQCOM(Span<int> num, int size, Span<uint> driverControls)
        {
            fixed (uint* driverControls_ptr = driverControls)
            {
                fixed (int* num_ptr = num)
                {
                    GetDriverControlsQCOM(num_ptr, size, driverControls_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetDriverControlsQCOM(int*, int, uint*)"/>
        public static unsafe void GetDriverControlsQCOM(int[] num, int size, uint[] driverControls)
        {
            fixed (uint* driverControls_ptr = driverControls)
            {
                fixed (int* num_ptr = num)
                {
                    GetDriverControlsQCOM(num_ptr, size, driverControls_ptr);
                }
            }
        }
        /// <inheritdoc cref="GetDriverControlsQCOM(int*, int, uint*)"/>
        public static unsafe void GetDriverControlsQCOM(ref int num, int size, ref uint driverControls)
        {
            fixed (int* num_ptr = &num)
            fixed (uint* driverControls_ptr = &driverControls)
            {
                GetDriverControlsQCOM(num_ptr, size, driverControls_ptr);
            }
        }
        /// <inheritdoc cref="GetDriverControlStringQCOM(uint, int, int*, byte*)"/>
        public static unsafe string GetDriverControlStringQCOM(uint driverControl, int bufSize, Span<int> length)
        {
            string driverControlString;
            fixed (int* length_ptr = length)
            {
                var driverControlString_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetDriverControlStringQCOM(driverControl, bufSize, length_ptr, driverControlString_ptr);
                driverControlString = Marshal.PtrToStringUTF8((IntPtr)driverControlString_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)driverControlString_ptr);
            }
            return driverControlString;
        }
        /// <inheritdoc cref="GetDriverControlStringQCOM(uint, int, int*, byte*)"/>
        public static unsafe void GetDriverControlStringQCOM(uint driverControl, int bufSize, Span<int> length, out string driverControlString)
        {
            fixed (int* length_ptr = length)
            {
                var driverControlString_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetDriverControlStringQCOM(driverControl, bufSize, length_ptr, driverControlString_ptr);
                driverControlString = Marshal.PtrToStringUTF8((IntPtr)driverControlString_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)driverControlString_ptr);
            }
        }
        /// <inheritdoc cref="GetDriverControlStringQCOM(uint, int, int*, byte*)"/>
        public static unsafe string GetDriverControlStringQCOM(uint driverControl, int bufSize, int[] length)
        {
            string driverControlString;
            fixed (int* length_ptr = length)
            {
                var driverControlString_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetDriverControlStringQCOM(driverControl, bufSize, length_ptr, driverControlString_ptr);
                driverControlString = Marshal.PtrToStringUTF8((IntPtr)driverControlString_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)driverControlString_ptr);
            }
            return driverControlString;
        }
        /// <inheritdoc cref="GetDriverControlStringQCOM(uint, int, int*, byte*)"/>
        public static unsafe void GetDriverControlStringQCOM(uint driverControl, int bufSize, int[] length, out string driverControlString)
        {
            fixed (int* length_ptr = length)
            {
                var driverControlString_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetDriverControlStringQCOM(driverControl, bufSize, length_ptr, driverControlString_ptr);
                driverControlString = Marshal.PtrToStringUTF8((IntPtr)driverControlString_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)driverControlString_ptr);
            }
        }
        /// <inheritdoc cref="GetDriverControlStringQCOM(uint, int, int*, byte*)"/>
        public static unsafe string GetDriverControlStringQCOM(uint driverControl, int bufSize, ref int length)
        {
            string driverControlString;
            fixed (int* length_ptr = &length)
            {
                var driverControlString_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetDriverControlStringQCOM(driverControl, bufSize, length_ptr, driverControlString_ptr);
                driverControlString = Marshal.PtrToStringUTF8((IntPtr)driverControlString_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)driverControlString_ptr);
            }
            return driverControlString;
        }
        /// <inheritdoc cref="GetDriverControlStringQCOM(uint, int, int*, byte*)"/>
        public static unsafe void GetDriverControlStringQCOM(uint driverControl, int bufSize, ref int length, out string driverControlString)
        {
            fixed (int* length_ptr = &length)
            {
                var driverControlString_ptr = (byte*)Marshal.AllocCoTaskMem(bufSize);
                GetDriverControlStringQCOM(driverControl, bufSize, length_ptr, driverControlString_ptr);
                driverControlString = Marshal.PtrToStringUTF8((IntPtr)driverControlString_ptr)!;
                Marshal.FreeCoTaskMem((IntPtr)driverControlString_ptr);
            }
        }
    }
}