using OpenTK.Mathematics;

namespace Marius.Winter.Forms;

public abstract class SurfaceFactory
{
    public abstract Surface Create(Vector2i size, bool isFullScreen, bool resizable);
}