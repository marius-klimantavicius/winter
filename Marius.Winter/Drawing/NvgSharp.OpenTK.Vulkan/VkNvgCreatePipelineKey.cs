using System.Runtime.InteropServices;
using OpenTK.Graphics.Vulkan;

namespace NvgSharp.OpenTK.Vulkan;

[StructLayout(LayoutKind.Sequential)]
internal struct VkNvgCreatePipelineKey
{
    public VkNvgStencilSetting StencilStroke;
    public bool StencilFill;
    public bool StencilTest;
    public bool EdgeAA;
    public VkPrimitiveTopology Topology;
    public VkColorComponentFlagBits ColorWriteMask; // set and compare independently
}