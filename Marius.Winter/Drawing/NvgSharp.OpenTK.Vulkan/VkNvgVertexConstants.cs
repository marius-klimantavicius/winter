using System.Runtime.InteropServices;

namespace NvgSharp.OpenTK.Vulkan;

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct VkNvgVertexConstants
{
    public fixed float ViewSize[2];
    public uint UniformOffset;
}