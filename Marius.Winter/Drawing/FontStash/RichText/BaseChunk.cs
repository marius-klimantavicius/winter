﻿using System.Drawing;
using Color = FontStashSharp.FSColor;
using System.Numerics;

namespace FontStashSharp.RichText;

public abstract class BaseChunk
{
	public abstract Point Size { get; }

	public int LineIndex { get; internal set; }
	public int ChunkIndex { get; internal set; }
	public int VerticalOffset { get; internal set; }
	public Color? Color { get; set; }

	protected BaseChunk()
	{
	}

	public abstract void Draw(FSRenderContext context, Vector2 position, Color color);
}