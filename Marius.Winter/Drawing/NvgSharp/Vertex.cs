using System.Runtime.InteropServices;
using System.Numerics;

namespace NvgSharp;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Vertex
{
    public Vector2 Position;
    public Vector2 TextureCoordinate;

    public Vertex(float x, float y, float u, float v)
    {
        Position.X = x;
        Position.Y = y;
        TextureCoordinate.X = u;
        TextureCoordinate.Y = v;
    }
}