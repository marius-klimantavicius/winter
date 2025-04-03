using FontStashSharp;
using System.Text;

namespace NvgSharp;

public enum TextHorizontalAlignment
{
    /// <summary>
    /// Default, align text horizontally to left
    /// </summary>
    Left,

    /// <summary>
    /// Align text horizontally to center
    /// </summary>
    Center,

    /// <summary>
    /// Align text horizontally to right
    /// </summary>
    Right,
}

public enum TextVerticalAlignment
{
    /// <summary>
    /// Default, Align text vertically to top
    /// </summary>
    Top,

    /// <summary>
    /// Align text vertically to middle
    /// </summary>
    Center,

    /// <summary>
    /// Align text vertically to bottom
    /// </summary>
    Bottom,
}

public static class NvgExtensions
{
    public static void TextAligned(this NvgContext context, SpriteFontBase font, string? text, float x, float y,
        TextHorizontalAlignment horizontalAlignment = TextHorizontalAlignment.Left, TextVerticalAlignment verticalAlignment = TextVerticalAlignment.Top,
        float layerDepth = 0.0f, float characterSpacing = 0.0f, float lineSpacing = 0.0f, FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0)
    {
        if (string.IsNullOrEmpty(text))
        {
            return;
        }

        if (horizontalAlignment != TextHorizontalAlignment.Left)
        {
            var sz = font.MeasureString(text);
            if (horizontalAlignment == TextHorizontalAlignment.Center)
            {
                x -= sz.X / 2.0f;
            }
            else if (horizontalAlignment == TextHorizontalAlignment.Right)
            {
                x -= sz.X;
            }
        }

        if (verticalAlignment == TextVerticalAlignment.Center)
        {
            y -= font.LineHeight / 2.0f;
        }
        else if (verticalAlignment == TextVerticalAlignment.Bottom)
        {
            y -= font.LineHeight;
        }

        context.Text(font, text, x, y, layerDepth, characterSpacing, lineSpacing, effect: effect, effectAmount: effectAmount);
    }

    public static void TextAligned(this NvgContext context, SpriteFontBase font, StringBuilder? text, float x, float y,
        TextHorizontalAlignment horizontalAlignment = TextHorizontalAlignment.Left, TextVerticalAlignment verticalAlignment = TextVerticalAlignment.Top,
        float layerDepth = 0.0f, float characterSpacing = 0.0f, float lineSpacing = 0.0f, FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0)
    {
        if (text == null || text.Length == 0)
        {
            return;
        }

        if (horizontalAlignment != TextHorizontalAlignment.Left)
        {
            var sz = font.MeasureString(text);
            if (horizontalAlignment == TextHorizontalAlignment.Center)
            {
                x -= sz.X / 2.0f;
            }
            else if (horizontalAlignment == TextHorizontalAlignment.Right)
            {
                x -= sz.X;
            }
        }

        if (verticalAlignment == TextVerticalAlignment.Center)
        {
            y -= font.LineHeight / 2.0f;
        }
        else if (verticalAlignment == TextVerticalAlignment.Bottom)
        {
            y -= font.LineHeight;
        }

        context.Text(font, text, x, y, layerDepth, characterSpacing, lineSpacing, effect: effect, effectAmount: effectAmount);
    }
    
    public static void ApplyAlignment(this NvgContext context, ref global::OpenTK.Mathematics.Vector2 position, System.Numerics.Vector2 sz, SpriteFontBase font, TextHorizontalAlignment horizontalAlignment, TextVerticalAlignment verticalAlignment)
    {
        if (horizontalAlignment != TextHorizontalAlignment.Left)
        {
            if (horizontalAlignment == TextHorizontalAlignment.Center)
                position.X -= sz.X / 2.0f;
            else if (horizontalAlignment == TextHorizontalAlignment.Right)
                position.X -= sz.X;
        }

        if (verticalAlignment == TextVerticalAlignment.Center)
            position.Y -= font.LineHeight / 2.0f;
        else if (verticalAlignment == TextVerticalAlignment.Bottom)
            position.Y -= font.LineHeight;
    }
    
    public static void ApplyAlignment(this NvgContext context, ref global::OpenTK.Mathematics.Vector2 position, string text, SpriteFontBase font, TextHorizontalAlignment horizontalAlignment, TextVerticalAlignment verticalAlignment)
    {
        var sz = font.MeasureString(text);
        ApplyAlignment(context, ref position, sz, font, horizontalAlignment, verticalAlignment);
    }
}