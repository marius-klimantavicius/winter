using System.Numerics;
using Texture2D = System.Object;
using System.Runtime.InteropServices;

namespace FontStashSharp.Interfaces;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct VertexPositionColorTexture
{
	/// <summary>
	/// Position
	/// </summary>
	public Vector3 Position;

	/// <summary>
	/// Color
	/// </summary>
	public FSColor Color;

	/// <summary>
	/// Texture Coordinate
	/// </summary>
	public Vector2 TextureCoordinate;
}

public interface IFontStashRenderer2
{
	ITexture2DManager TextureManager { get; }

	void DrawQuad(Texture2D texture, ref VertexPositionColorTexture topLeft, ref VertexPositionColorTexture topRight, ref VertexPositionColorTexture bottomLeft, ref VertexPositionColorTexture bottomRight);
}