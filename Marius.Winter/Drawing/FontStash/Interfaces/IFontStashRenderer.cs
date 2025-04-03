using System.Drawing;
using System.Numerics;
using Color = FontStashSharp.FSColor;
using Texture2D = System.Object;

namespace FontStashSharp.Interfaces;

public interface IFontStashRenderer
{
	ITexture2DManager TextureManager { get; }

	void Draw(Texture2D texture, Vector2 pos, Rectangle? src, Color color, float rotation, Vector2 scale, float depth);
}