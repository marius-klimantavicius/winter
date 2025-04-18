﻿using System;
using FontStashSharp.Interfaces;
using System.Drawing;
using Texture2D = System.Object;

namespace FontStashSharp;

public enum FontSystemEffect
{
	None,
	Blurry,
	Stroked,
}

public class FontSystemSettings
{
	private int _textureWidth = 1024, _textureHeight = 1024;
	private float _fontResolutionFactor = 1.0f;
	private int _kernelWidth = 0, _kernelHeight = 0;

	public int TextureWidth
	{
		get => _textureWidth;

		set
		{
			if (value <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(value));

			}

			_textureWidth = value;
		}
	}

	public int TextureHeight
	{
		get => _textureHeight;

		set
		{
			if (value <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(value));

			}

			_textureHeight = value;
		}
	}

	public bool PremultiplyAlpha { get; set; } = true;

	public GlyphRenderer GlyphRenderer { get; set; } = GlyphRenderers.Default;

	public float FontResolutionFactor
	{
		get => _fontResolutionFactor;
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(value), value, "This cannot be smaller than 0");
			}

			_fontResolutionFactor = value;
		}
	}

	public int KernelWidth
	{
		get => _kernelWidth;

		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(value), value, "This cannot be smaller than 0");
			}

			_kernelWidth = value;
		}
	}

	public int KernelHeight
	{
		get => _kernelHeight;

		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(value), value, "This cannot be smaller than 0");
			}

			_kernelHeight = value;
		}
	}

	public bool StbTrueTypeUseOldRasterizer { get; set; }

	/// <summary>
	/// Use existing texture for storing glyphs
	/// If this is set, then TextureWidth & TextureHeight are ignored
	/// </summary>
	public Texture2D ExistingTexture { get; set; }

	/// <summary>
	/// Defines rectangle of the used space in the ExistingTexture
	/// </summary>
	public Rectangle ExistingTextureUsedSpace { get; set; }

	/// <summary>
	/// Font Rasterizer. If set to null then default rasterizer(StbTrueTypeSharp) is used.
	/// </summary>
	public IFontLoader FontLoader { get; set; }

	public FontSystemSettings()
	{
		TextureWidth = FontSystemDefaults.TextureWidth;
		TextureHeight = FontSystemDefaults.TextureHeight;
		PremultiplyAlpha = FontSystemDefaults.PremultiplyAlpha;
		FontResolutionFactor = FontSystemDefaults.FontResolutionFactor;
		KernelWidth = FontSystemDefaults.KernelWidth;
		KernelHeight = FontSystemDefaults.KernelHeight;
		StbTrueTypeUseOldRasterizer = FontSystemDefaults.StbTrueTypeUseOldRasterizer;
		FontLoader = FontSystemDefaults.FontLoader;
	}

	public FontSystemSettings Clone()
	{
		return new FontSystemSettings
		{
			TextureWidth = TextureWidth,
			TextureHeight = TextureHeight,
			PremultiplyAlpha = PremultiplyAlpha,
			GlyphRenderer = GlyphRenderer,
			FontResolutionFactor = FontResolutionFactor,
			KernelWidth = KernelWidth,
			KernelHeight = KernelHeight,
			StbTrueTypeUseOldRasterizer = StbTrueTypeUseOldRasterizer,
			ExistingTexture = ExistingTexture,
			ExistingTextureUsedSpace = ExistingTextureUsedSpace,
			FontLoader = FontLoader,
		};
	}
}