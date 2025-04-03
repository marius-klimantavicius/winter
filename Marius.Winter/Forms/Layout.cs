using NvgSharp;
using OpenTK.Mathematics;

namespace Marius.Winter.Forms;

public abstract class Layout
{
    public abstract Vector2i GetPreferredSize(NvgContext context, Widget widget);

    public abstract void PerformLayout(NvgContext context, Widget widget);
}