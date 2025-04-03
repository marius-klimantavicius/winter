using System.Runtime.InteropServices;
using System.Numerics;

namespace NvgSharp;

[StructLayout(LayoutKind.Sequential)]
internal struct Scissor
{
    public Transform Transform;
    public Vector2 Extent;
}