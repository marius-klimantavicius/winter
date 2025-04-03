﻿using System.Diagnostics;
using System.Text;
using FontStashSharp;
using FontStashSharp.Interfaces;
using System.Numerics;
using System.Drawing;
using FontStashSharp.RichText;
using Texture2D = System.Object;
using Color = FontStashSharp.FSColor;

namespace NvgSharp;

public static class NvgText
{
    private class TextRenderer : IFontStashRenderer2, ITexture2DManager
    {
        private readonly NvgContext _context;
        internal int _lastVertexOffset;
        internal Texture2D? _lastTextTexture = null;

        public ITexture2DManager TextureManager => this;

        public object CreateTexture(int width, int height) => _context._renderer.CreateTexture(width, height);

        public Point GetTextureSize(object texture) => _context._renderer.GetTextureSize(texture);

        public void SetTextureData(object texture, Rectangle bounds, byte[] data) => _context._renderer.SetTextureData(texture, bounds, data);

        public TextRenderer(NvgContext context)
        {
            _context = context;
        }

        public void DrawQuad(Texture2D texture, ref VertexPositionColorTexture topLeft, ref VertexPositionColorTexture topRight,
            ref VertexPositionColorTexture bottomLeft, ref VertexPositionColorTexture bottomRight)
        {
            if (_lastTextTexture != null && _lastTextTexture != texture)
            {
                FlushText();
            }

            var state = _context._currentState;

            state.Transform.TransformPoint(out var px, out var py, topLeft.Position.X, topLeft.Position.Y);
            px = (int)px;
            py = (int)py;
            var newTopLeft = new Vertex(px, py, topLeft.TextureCoordinate.X, topLeft.TextureCoordinate.Y);

            state.Transform.TransformPoint(out px, out py, topRight.Position.X, topRight.Position.Y);
            px = (int)px;
            py = (int)py;
            var newTopRight = new Vertex(px, py, topRight.TextureCoordinate.X, topRight.TextureCoordinate.Y);

            state.Transform.TransformPoint(out px, out py, bottomRight.Position.X, bottomRight.Position.Y);
            px = (int)px;
            py = (int)py;
            var newBottomRight = new Vertex(px, py, bottomRight.TextureCoordinate.X, bottomRight.TextureCoordinate.Y);

            state.Transform.TransformPoint(out px, out py, bottomLeft.Position.X, bottomLeft.Position.Y);
            px = (int)px;
            py = (int)py;
            var newBottomLeft = new Vertex(px, py, bottomLeft.TextureCoordinate.X, bottomLeft.TextureCoordinate.Y);

            var renderCache = _context._renderCache;
            renderCache.AddVertex(newTopLeft);
            renderCache.AddVertex(newBottomRight);
            renderCache.AddVertex(newTopRight);
            renderCache.AddVertex(newTopLeft);
            renderCache.AddVertex(newBottomLeft);
            renderCache.AddVertex(newBottomRight);

            _lastTextTexture = texture;
        }

        private void FlushText()
        {
            var renderCache = _context._renderCache;
            if (_lastTextTexture == null || _lastVertexOffset == renderCache.VertexCount)
            {
                return;
            }

            var state = _context._currentState;
            var paint = state.Fill;
            paint.Image = _lastTextTexture;

            NvgContext.MultiplyAlpha(ref paint.InnerColor, state.Alpha);
            NvgContext.MultiplyAlpha(ref paint.OuterColor, state.Alpha);

            renderCache.RenderTriangles(ref paint, ref state.Scissor, _context._fringeWidth, _lastVertexOffset, renderCache.VertexCount - _lastVertexOffset);

            _lastVertexOffset = renderCache.VertexCount;
            _lastTextTexture = null;
        }

        public void Text(SpriteFontBase font, TextSource text, float x, float y, float layerDepth, float characterSpacing, float lineSpacing, FontSystemEffect effect, int effectAmount)
        {
            if (text.IsNull)
            {
                return;
            }

            _lastVertexOffset = _context._renderCache.VertexCount;

            if (text.StringText != null)
            {
                font.DrawText(this, text.StringText, new Vector2(x, y), Color.White,
                    layerDepth: layerDepth, characterSpacing: characterSpacing, lineSpacing: lineSpacing, effect: effect, effectAmount: effectAmount);
            }
            else
            {
                Debug.Assert(text.StringBuilderText != null);

                font.DrawText(this, text.StringBuilderText, new Vector2(x, y), Color.White,
                    layerDepth: layerDepth, characterSpacing: characterSpacing, lineSpacing: lineSpacing, effect: effect, effectAmount: effectAmount);
            }

            FlushText();
        }

        public void RichText(RichTextLayout richTextLayout, float x, float y)
        {
            _lastVertexOffset = _context._renderCache.VertexCount;

            richTextLayout.Draw(this, new Vector2(x, y), Color.White);
            FlushText();
        }
    }

    private static void Text(this NvgContext context, SpriteFontBase font, TextSource text, float x, float y,
        float layerDepth, float characterSpacing, float lineSpacing, FontSystemEffect effect, int effectAmount)
    {
        TextRenderer textRenderer;
        if (context._textRenderer == null)
        {
            textRenderer = new TextRenderer(context);
            context._textRenderer = textRenderer;
        }
        else
        {
            textRenderer = (TextRenderer)context._textRenderer;
        }

        textRenderer.Text(font, text, x, y, layerDepth, characterSpacing, lineSpacing, effect, effectAmount);
    }

    public static void Text(this NvgContext context, SpriteFontBase font, string text, float x, float y,
        float layerDepth = 0.0f, float characterSpacing = 0.0f, float lineSpacing = 0.0f, FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0) =>
        Text(context, font, new TextSource(text), x, y, layerDepth, characterSpacing, lineSpacing, effect, effectAmount);

    public static void Text(this NvgContext context, SpriteFontBase font, StringBuilder text, float x, float y,
        float layerDepth = 0.0f, float characterSpacing = 0.0f, float lineSpacing = 0.0f, FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0) =>
        Text(context, font, new TextSource(text), x, y, layerDepth, characterSpacing, lineSpacing, effect, effectAmount);

    public static void RichText(this NvgContext context, RichTextLayout richTextLayout, float x, float y)
    {
        TextRenderer textRenderer;
        if (context._textRenderer == null)
        {
            textRenderer = new TextRenderer(context);
            context._textRenderer = textRenderer;
        }
        else
        {
            textRenderer = (TextRenderer)context._textRenderer;
        }

        textRenderer.RichText(richTextLayout, x, y);
    }
}