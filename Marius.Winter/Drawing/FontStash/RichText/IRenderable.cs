using System.Drawing;
using System.Numerics;
using Color = FontStashSharp.FSColor;

namespace FontStashSharp.RichText;

public interface IRenderable
{
	Point Size { get; }

	void Draw(FSRenderContext context, Vector2 position, Color color);
}