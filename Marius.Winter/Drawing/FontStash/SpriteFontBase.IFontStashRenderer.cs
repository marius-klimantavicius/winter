﻿using FontStashSharp.Interfaces;
using System.Text;
using System;
using System.Numerics;
using Matrix = System.Numerics.Matrix3x2;
using Color = FontStashSharp.FSColor;

namespace FontStashSharp;

partial class SpriteFontBase
{
    private void RenderStyle(IFontStashRenderer renderer, TextStyle textStyle, Vector2 pos,
        int lineHeight, int ascent, Color color, ref Matrix transformation, float rotation, Vector2 scale, float layerDepth)
    {
        if (textStyle == TextStyle.None || pos.X == 0)
        {
            return;
        }

        var white = GetWhite(renderer.TextureManager);
        var start = Vector2.Zero;
        if (textStyle == TextStyle.Strikethrough)
        {
            start.Y = pos.Y - ascent + lineHeight / 2 - (FontSystemDefaults.TextStyleLineHeight / 2) * RenderFontSizeMultiplicator;
        }
        else
        {
            start.Y = pos.Y + RenderFontSizeMultiplicator;
        }

        start = start.Transform(ref transformation);

        scale.X *= pos.X;
        scale.Y *= (FontSystemDefaults.TextStyleLineHeight * RenderFontSizeMultiplicator);

        renderer.Draw(white, start, null, color, rotation, scale, layerDepth);
    }

    private float DrawText(IFontStashRenderer renderer, TextColorSource source, Vector2 position,
        float rotation, Vector2 origin, Vector2? sourceScale,
        float layerDepth, float characterSpacing, float lineSpacing,
        TextStyle textStyle, FontSystemEffect effect, int effectAmount)
    {
        if (renderer == null)
        {
            throw new ArgumentNullException(nameof(renderer));
        }

        if (renderer.TextureManager == null)
        {
            throw new ArgumentNullException("renderer.TextureManager can't be null.");
        }

        if (source.IsNull) return 0.0f;

        var scale = sourceScale ?? Utility.DefaultScale;
        Prepare(position, rotation, origin, ref scale, out var transformation);

        PreDraw(source.TextSource, effect, effectAmount, out var ascent, out var lineHeight);

        var pos = new Vector2(0, ascent);

        FontGlyph prevGlyph = null;
        Color? firstColor = null;
        while (true)
        {
            if (!source.GetNextCodepoint(out var codepoint))
                break;

            if (codepoint == '\n')
            {
                if (textStyle != TextStyle.None && firstColor != null)
                {
                    RenderStyle(renderer, textStyle, pos,
                        lineHeight, ascent, firstColor.Value, ref transformation,
                        rotation, scale, layerDepth);
                }

                pos.X = 0.0f;
                pos.Y += lineHeight + lineSpacing;
                prevGlyph = null;
                continue;
            }

            var glyph = GetGlyph(renderer.TextureManager, codepoint, effect, effectAmount);
            if (glyph == null)
            {
                continue;
            }

            if (prevGlyph != null)
            {
                pos.X += characterSpacing;
                pos.X += GetKerning(glyph, prevGlyph);
            }

            if (!glyph.IsEmpty)
            {
                var color = source.GetNextColor();
                firstColor = color;

                var p = pos + new Vector2(glyph.RenderOffset.X, glyph.RenderOffset.Y);
                p = p.Transform(ref transformation);

                renderer.Draw(glyph.Texture,
                    p,
                    glyph.TextureRectangle,
                    color,
                    rotation,
                    scale,
                    layerDepth);
            }

            pos.X += glyph.XAdvance;
            prevGlyph = glyph;
        }

        if (textStyle != TextStyle.None && firstColor != null)
        {
            RenderStyle(renderer, textStyle, pos,
                lineHeight, ascent, firstColor.Value, ref transformation,
                rotation, scale, layerDepth);
        }

        return position.X + pos.X;
    }

    /// <summary>
    /// Draws a text
    /// </summary>
    /// <param name="renderer">A renderer</param>
    /// <param name="text">The text which will be drawn</param>
    /// <param name="position">The drawing location on screen</param>
    /// <param name="color">A color mask</param>
    /// <param name="rotation">A rotation of this text in radians</param>
    /// <param name="origin">Center of the rotation</param>
    /// <param name="scale">A scaling of this text. Null means the scaling is (1, 1)</param>
    /// <param name="layerDepth">A depth of the layer of this string</param>
    /// <param name="characterSpacing">A character spacing</param>
    /// <param name="lineSpacing">A line spacing</param>
    public float DrawText(IFontStashRenderer renderer, string text, Vector2 position, Color color,
        float rotation = 0, Vector2 origin = default(Vector2), Vector2? scale = null,
        float layerDepth = 0.0f, float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        TextStyle textStyle = TextStyle.None, FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0) =>
        DrawText(renderer, new TextColorSource(text, color), position, rotation, origin, scale,
            layerDepth, characterSpacing, lineSpacing, textStyle, effect, effectAmount);

    /// <summary>
    /// Draws a text
    /// </summary>
    /// <param name="renderer">A renderer</param>
    /// <param name="text">The text which will be drawn</param>
    /// <param name="position">The drawing location on screen</param>
    /// <param name="colors">Colors of glyphs</param>
    /// <param name="rotation">A rotation of this text in radians</param>
    /// <param name="origin">Center of the rotation</param>
    /// <param name="scale">A scaling of this text. Null means the scaling is (1, 1)</param>
    /// <param name="layerDepth">A depth of the layer of this string</param>
    /// <param name="characterSpacing">A character spacing</param>
    /// <param name="lineSpacing">A line spacing</param>
    public float DrawText(IFontStashRenderer renderer, string text, Vector2 position, Color[] colors,
        float rotation = 0, Vector2 origin = default(Vector2), Vector2? scale = null,
        float layerDepth = 0.0f, float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        TextStyle textStyle = TextStyle.None, FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0) =>
        DrawText(renderer, new TextColorSource(text, colors), position, rotation, origin, scale, layerDepth,
            characterSpacing, lineSpacing, textStyle, effect, effectAmount);

    /// <summary>
    /// Draws a text
    /// </summary>
    /// <param name="renderer">A renderer</param>
    /// <param name="text">The text which will be drawn</param>
    /// <param name="position">The drawing location on screen</param>
    /// <param name="color">A color mask</param>
    /// <param name="rotation">A rotation of this text in radians</param>
    /// <param name="origin">Center of the rotation</param>
    /// <param name="scale">A scaling of this text. Null means the scaling is (1, 1)</param>
    /// <param name="layerDepth">A depth of the layer of this string</param>
    /// <param name="characterSpacing">A character spacing</param>
    /// <param name="lineSpacing">A line spacing</param>
    public float DrawText(IFontStashRenderer renderer, StringSegment text, Vector2 position, Color color,
        float rotation = 0, Vector2 origin = default(Vector2), Vector2? scale = null,
        float layerDepth = 0.0f, float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        TextStyle textStyle = TextStyle.None, FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0) =>
        DrawText(renderer, new TextColorSource(text, color), position, rotation, origin, scale, layerDepth,
            characterSpacing, lineSpacing, textStyle, effect, effectAmount);

    /// <summary>
    /// Draws a text
    /// </summary>
    /// <param name="renderer">A renderer</param>
    /// <param name="text">The text which will be drawn</param>
    /// <param name="position">The drawing location on screen</param>
    /// <param name="colors">Colors of glyphs</param>
    /// <param name="rotation">A rotation of this text in radians</param>
    /// <param name="origin">Center of the rotation</param>
    /// <param name="scale">A scaling of this text. Null means the scaling is (1, 1)</param>
    /// <param name="layerDepth">A depth of the layer of this string</param>
    /// <param name="characterSpacing">A character spacing</param>
    /// <param name="lineSpacing">A line spacing</param>
    public float DrawText(IFontStashRenderer renderer, StringSegment text, Vector2 position, Color[] colors,
        float rotation = 0, Vector2 origin = default(Vector2), Vector2? scale = null,
        float layerDepth = 0.0f, float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        TextStyle textStyle = TextStyle.None, FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0) =>
        DrawText(renderer, new TextColorSource(text, colors), position, rotation, origin, scale, layerDepth,
            characterSpacing, lineSpacing, textStyle, effect, effectAmount);

    /// <summary>
    /// Draws a text
    /// </summary>
    /// <param name="renderer">A renderer</param>
    /// <param name="text">The text which will be drawn</param>
    /// <param name="position">The drawing location on screen</param>
    /// <param name="color">A color mask</param>
    /// <param name="rotation">A rotation of this text in radians</param>
    /// <param name="origin">Center of the rotation</param>
    /// <param name="scale">A scaling of this text. Null means the scaling is (1, 1)</param>
    /// <param name="layerDepth">A depth of the layer of this string</param>
    /// <param name="characterSpacing">A character spacing</param>
    /// <param name="lineSpacing">A line spacing</param>
    public float DrawText(IFontStashRenderer renderer, StringBuilder text, Vector2 position, Color color,
        float rotation = 0, Vector2 origin = default(Vector2), Vector2? scale = null,
        float layerDepth = 0.0f, float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        TextStyle textStyle = TextStyle.None, FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0) =>
        DrawText(renderer, new TextColorSource(text, color), position, rotation, origin, scale, layerDepth,
            characterSpacing, lineSpacing, textStyle, effect, effectAmount);

    /// <summary>
    /// Draws a text
    /// </summary>
    /// <param name="renderer">A renderer</param>
    /// <param name="text">The text which will be drawn</param>
    /// <param name="position">The drawing location on screen</param>
    /// <param name="colors">Colors of glyphs</param>
    /// <param name="rotation">A rotation of this text in radians</param>
    /// <param name="origin">Center of the rotation</param>
    /// <param name="scale">A scaling of this text. Null means the scaling is (1, 1)</param>
    /// <param name="layerDepth">A depth of the layer of this string</param>
    /// <param name="characterSpacing">A character spacing</param>
    /// <param name="lineSpacing">A line spacing</param>
    public float DrawText(IFontStashRenderer renderer, StringBuilder text, Vector2 position, Color[] colors,
        float rotation = 0, Vector2 origin = default(Vector2), Vector2? scale = null,
        float layerDepth = 0.0f, float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        TextStyle textStyle = TextStyle.None, FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0) =>
        DrawText(renderer, new TextColorSource(text, colors), position, rotation, origin, scale, layerDepth,
            characterSpacing, lineSpacing, textStyle, effect, effectAmount);
}