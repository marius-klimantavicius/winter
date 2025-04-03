using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace NvgSharp.OpenTK.OpenGL;

public partial class Shader : IDisposable
{
    private readonly int _handle;

    public Shader(Dictionary<string, string> defines)
    {
        var vertex = LoadShader(ShaderType.VertexShader, Vert, defines);
        var fragment = LoadShader(ShaderType.FragmentShader, Frag, defines);

        _handle = GL.CreateProgram();
        GLUtility.CheckError();

        GL.AttachShader(_handle, vertex);
        GLUtility.CheckError();

        GL.AttachShader(_handle, fragment);
        GLUtility.CheckError();

        GL.LinkProgram(_handle);
        GL.GetProgrami(_handle, ProgramProperty.LinkStatus, out var status);
        if (status == 0)
        {
            GL.GetProgramInfoLog(_handle, out var error);
            throw new Exception($"Program failed to link with error: {error}");
        }

        GL.DetachShader(_handle, vertex);
        GL.DetachShader(_handle, fragment);

        GL.DeleteShader(vertex);
        GL.DeleteShader(fragment);
    }

    public void Use()
    {
        GL.UseProgram(_handle);
        GLUtility.CheckError();
    }

    public void SetUniform(string name, int value)
    {
        var location = GL.GetUniformLocation(_handle, name);
        if (location == -1)
        {
            throw new Exception($"{name} uniform not found on shader.");
        }

        GL.Uniform1i(location, value);
        GLUtility.CheckError();
    }

    public void SetUniform(string name, float value)
    {
        var location = GL.GetUniformLocation(_handle, name);
        if (location == -1)
        {
            throw new Exception($"{name} uniform not found on shader.");
        }

        GL.Uniform1f(location, value);
        GLUtility.CheckError();
    }

    public void SetUniform(string name, Vector2 value)
    {
        var location = GL.GetUniformLocation(_handle, name);
        if (location == -1)
        {
            throw new Exception($"{name} uniform not found on shader.");
        }

        GL.Uniform2f(location, value.X, value.Y);
        GLUtility.CheckError();
    }

    public void SetUniform(string name, Vector4 value)
    {
        var location = GL.GetUniformLocation(_handle, name);
        if (location == -1)
        {
            throw new Exception($"{name} uniform not found on shader.");
        }

        GL.Uniform4f(location, value.X, value.Y, value.Z, value.W);
        GLUtility.CheckError();
    }

    public unsafe void SetUniform(string name, Matrix4x4 value)
    {
        var location = GL.GetUniformLocation(_handle, name);
        if (location == -1)
        {
            throw new Exception($"{name} uniform not found on shader.");
        }

        GL.UniformMatrix4fv(location, 1, false, (float*)&value);
        GLUtility.CheckError();
    }

    public void Dispose()
    {
        GL.DeleteProgram(_handle);
    }

    private int LoadShader(ShaderType type, string source, Dictionary<string, string>? defines)
    {
        var sb = new StringBuilder();

        if (defines != null)
        {
            foreach (var pair in defines)
                sb.Append("#define " + pair.Key + " " + pair.Value + "\n");
        }

        sb.Append(source);

        var handle = GL.CreateShader(type);
        GLUtility.CheckError();

        GL.ShaderSource(handle, sb.ToString());
        GLUtility.CheckError();

        GL.CompileShader(handle);
        GL.GetShaderInfoLog(handle, out var infoLog);
        if (!string.IsNullOrWhiteSpace(infoLog))
            throw new Exception($"Error compiling shader of type {type}, failed with error {infoLog}");

        return handle;
    }

    public int GetAttribLocation(string attribName)
    {
        var result = GL.GetAttribLocation(_handle, attribName);
        GLUtility.CheckError();
        return result;
    }
}