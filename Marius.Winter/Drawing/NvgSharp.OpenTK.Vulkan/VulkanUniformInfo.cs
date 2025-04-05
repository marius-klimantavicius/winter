using System.Numerics;
using System.Runtime.InteropServices;

namespace NvgSharp.OpenTK.Vulkan;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct VulkanUniformInfo
{
    // std430 implies that vec3 is aligned to 16 bytes
    // which means that it is the same as 3 * vec4
    // this is why it is 12 floats instead of 9

    // mat3 scissorMat;
    public fixed float scissorMat[12];

    // mat3 paintMat;
    public fixed float paintMat[12];

    // vec4 innerCol;
    public Vector4 innerCol;

    // vec4 outerCol;
    public Vector4 outerCol;

    // vec2 scissorExt;
    public Vector2 scissorExt;

    // vec2 scissorScale;
    public Vector2 scissorScale;

    // vec2 extent;
    public Vector2 extent;

    // float radius;
    public float radius;

    // float feather;
    public float feather;

    // float strokeMult;
    public float strokeMult;

    // float strokeThr;
    public float strokeThr;

    // sampler2D image;
    public int texType;

    // vec4 imageSize;
    public RenderType type;

    public static void SetMatrix(float* dest, Matrix4x4 source)
    {
        dest[0] = source.M11;
        dest[1] = source.M12;
        dest[2] = 0;
        dest[3] = 0;
        dest[4] = source.M21;
        dest[5] = source.M22;
        dest[6] = 0;
        dest[7] = 0;
        dest[8] = source.M41;
        dest[9] = source.M42;
        dest[10] = 1;
        dest[11] = 0;
    }
}