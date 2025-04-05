using OpenTK.Mathematics;

namespace Marius.Winter.Forms;

public abstract class BackendFactory
{
    public abstract Backend Create(Vector2i size, bool isFullScreen, bool resizable);
}