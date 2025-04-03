using System.Drawing;

namespace FontStashSharp;

public struct Glyph
{
	public int Index;
	public int Codepoint;
	public Rectangle Bounds;
	public int XAdvance;
}