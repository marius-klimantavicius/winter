using OpenTK.Graphics.OpenGL;
using System;
using System.Runtime.InteropServices;

namespace NvgSharp.OpenTK.OpenGL;

public class BufferObject<T> : IDisposable where T : unmanaged
{
    private readonly int _handle;
    private readonly BufferTarget _bufferType;
    private readonly int _size;

    public int Size => _size;

    public unsafe BufferObject(int size, BufferTarget bufferType, bool isDynamic)
    {
        _bufferType = bufferType;
        _size = size;

        _handle = GL.GenBuffer();
        GLUtility.CheckError();

        Bind();

        var elementSizeInBytes = Marshal.SizeOf<T>();
        GL.BufferData(bufferType, size * elementSizeInBytes, IntPtr.Zero, isDynamic ? BufferUsage.StreamDraw : BufferUsage.StaticDraw);
        GLUtility.CheckError();
    }

    public void Bind()
    {
        GL.BindBuffer(_bufferType, _handle);
        GLUtility.CheckError();
    }

    public void Dispose()
    {
        GL.DeleteBuffer(_handle);
        GLUtility.CheckError();
    }

    public unsafe void SetData(ReadOnlySpan<T> data)
    {
        Bind();

        fixed (T* dataPtr = &data[0])
        {
            var elementSizeInBytes = sizeof(T);

            GL.BufferSubData(_bufferType, IntPtr.Zero, data.Length * elementSizeInBytes, new IntPtr(dataPtr));
            GLUtility.CheckError();
        }
    }
}