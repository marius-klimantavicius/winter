using System.Text;
using FontStashSharp.Interfaces;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using Matrix = System.Numerics.Matrix3x2;
using Texture2D = System.Object;

namespace FontStashSharp;

public abstract partial class SpriteFontBase
{
    private static Texture2D? _white;

    /// <summary>
    /// Font Size
    /// </summary>
    public float FontSize { get; private set; }

    /// <summary>
    /// Line Height in pixels
    /// </summary>
    public int LineHeight { get; private set; }

    protected float RenderFontSizeMultiplicator { get; set; } = 1f;

    protected SpriteFontBase(float fontSize, int lineHeight)
    {
        FontSize = fontSize;
        LineHeight = lineHeight;
    }

    protected internal abstract FontGlyph? GetGlyph(ITexture2DManager? device, int codepoint, FontSystemEffect effect, int effectAmount);

    internal abstract void PreDraw(TextSource str, FontSystemEffect effect, int effectAmount, out int ascent, out int lineHeight);

    private void Prepare(Vector2 position, float rotation, Vector2 origin, ref Vector2 scale, out Matrix transformation)
    {
        scale /= RenderFontSizeMultiplicator;

        Utility.BuildTransform(position, rotation, origin, scale, out transformation);
    }

    internal virtual Bounds InternalTextBounds(TextSource source, Vector2 position,
        float characterSpacing, float lineSpacing,
        FontSystemEffect effect, int effectAmount)
    {
        if (source.IsNull) return Bounds.Empty;

        PreDraw(source, effect, effectAmount, out var ascent, out var lineHeight);

        var x = position.X;
        var y = position.Y;
        y += ascent;

        float maxx, maxy;
        var minx = maxx = x;
        var miny = maxy = y;
        float startx = x;

        FontGlyph prevGlyph = null;

        while (true)
        {
            if (!source.GetNextCodepoint(out var codepoint))
                break;

            if (codepoint == '\n')
            {
                x = startx;
                y += lineHeight + lineSpacing;
                prevGlyph = null;
                continue;
            }

            var glyph = GetGlyph(null, codepoint, effect, effectAmount);
            if (glyph == null)
            {
                continue;
            }

            if (prevGlyph != null)
            {
                x += characterSpacing;
                x += GetKerning(glyph, prevGlyph);
            }

            var x0 = x + glyph.RenderOffset.X;
            if (x0 < minx)
                minx = x0;
            x += glyph.XAdvance;
            if (x > maxx)
                maxx = x;

            var y0 = y + glyph.RenderOffset.Y;
            var y1 = y0 + glyph.Size.Y;
            if (y0 < miny)
                miny = y0;
            if (y1 > maxy)
                maxy = y1;

            prevGlyph = glyph;
        }

        return new Bounds(minx, miny, maxx, maxy);
    }

    public Bounds TextBounds(string text, OpenTK.Mathematics.Vector2 position, OpenTK.Mathematics.Vector2? scale = null,
        float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0)
    {
        var bounds = InternalTextBounds(new TextSource(text), ToVector2(position), characterSpacing, lineSpacing, effect, effectAmount);

        var realScale = ToVector2(scale) ?? Utility.DefaultScale;
        bounds.ApplyScale(realScale / RenderFontSizeMultiplicator);
        return bounds;
    }

    public Bounds TextBounds(string text, OpenTK.Mathematics.Vector2i position, OpenTK.Mathematics.Vector2? scale = null,
        float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0)
    {
        var bounds = InternalTextBounds(new TextSource(text), ToVector2(position), characterSpacing, lineSpacing, effect, effectAmount);

        var realScale = ToVector2(scale) ?? Utility.DefaultScale;
        bounds.ApplyScale(realScale / RenderFontSizeMultiplicator);
        return bounds;
    }

    public Bounds TextBounds(string text, Vector2 position, Vector2? scale = null,
        float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0)
    {
        var bounds = InternalTextBounds(new TextSource(text), position, characterSpacing, lineSpacing, effect, effectAmount);

        var realScale = scale ?? Utility.DefaultScale;
        bounds.ApplyScale(realScale / RenderFontSizeMultiplicator);
        return bounds;
    }

    public Bounds TextBounds(StringBuilder text, Vector2 position, Vector2? scale = null,
        float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0)
    {
        var bounds = InternalTextBounds(new TextSource(text), position, characterSpacing, lineSpacing, effect, effectAmount);

        var realScale = scale ?? Utility.DefaultScale;
        bounds.ApplyScale(realScale / RenderFontSizeMultiplicator);
        return bounds;
    }

    public Bounds TextBounds(StringBuilder text, OpenTK.Mathematics.Vector2 position, OpenTK.Mathematics.Vector2? scale = null,
        float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0)
    {
        var bounds = InternalTextBounds(new TextSource(text), ToVector2(position), characterSpacing, lineSpacing, effect, effectAmount);

        var realScale = ToVector2(scale) ?? Utility.DefaultScale;
        bounds.ApplyScale(realScale / RenderFontSizeMultiplicator);
        return bounds;
    }

    public Bounds TextBounds(StringBuilder text, OpenTK.Mathematics.Vector2i position, OpenTK.Mathematics.Vector2? scale = null,
        float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0)
    {
        var bounds = InternalTextBounds(new TextSource(text), ToVector2(position), characterSpacing, lineSpacing, effect, effectAmount);

        var realScale = ToVector2(scale) ?? Utility.DefaultScale;
        bounds.ApplyScale(realScale / RenderFontSizeMultiplicator);
        return bounds;
    }

    private GlyphEnumerator GetGlyphs(TextSource source, Vector2 position, Vector2 origin, Vector2? sourceScale,
        float characterSpacing, float lineSpacing, FontSystemEffect effect, int effectAmount)
    {
        return new GlyphEnumerator(this, source, position, origin, sourceScale, characterSpacing, lineSpacing, effect, effectAmount);
    }

    public ref struct GlyphEnumerator
    {
        private readonly SpriteFontBase _font;
        private readonly float _characterSpacing;
        private readonly float _lineSpacing;
        private readonly FontSystemEffect _effect;
        private readonly int _effectAmount;
        private readonly Vector2 _scale;
        private readonly int _lineHeight;

        private TextSource _source;
        private FontGlyph? _prevGlyph;
        private Vector2 _pos;
        private int _index;
        private Matrix _transformation;

        public Glyph Current { get; private set; }

        public GlyphEnumerator GetEnumerator() => this;

        internal GlyphEnumerator(SpriteFontBase font, TextSource source, Vector2 position, Vector2 origin, Vector2? sourceScale,
            float characterSpacing, float lineSpacing, FontSystemEffect effect, int effectAmount)
        {
            _font = font;
            _source = source;
            _characterSpacing = characterSpacing;
            _lineSpacing = lineSpacing;
            _effect = effect;
            _effectAmount = effectAmount;

            _scale = sourceScale ?? Utility.DefaultScale;

            _font.Prepare(position, 0, origin, ref _scale, out _transformation);
            _font.PreDraw(source, effect, effectAmount, out var ascent, out _lineHeight);

            _pos = new Vector2(0, ascent);
            _index = 0;
        }

        public bool MoveNext()
        {
            if (_source.IsNull)
                return false;

            while (true)
            {
                if (!_source.GetNextCodepoint(out var codepoint))
                    break;

                var rect = new Rectangle((int)_pos.X, (int)_pos.Y - _font.LineHeight, 0, _font.LineHeight);
                var xAdvance = 0;
                if (codepoint == '\n')
                {
                    _pos.X = 0;
                    _pos.Y += _lineHeight + _lineSpacing;
                    _prevGlyph = null;
                }
                else
                {
                    var glyph = _font.GetGlyph(null, codepoint, _effect, _effectAmount);
                    if (glyph != null)
                    {
                        if (_prevGlyph != null)
                        {
                            _pos.X += _characterSpacing;
                            _pos.X += _font.GetKerning(glyph, _prevGlyph);
                        }

                        rect = glyph.RenderRectangle;
                        rect.Offset((int)_pos.X, (int)_pos.Y);

                        xAdvance = glyph.XAdvance;
                        _pos.X += xAdvance;
                        _prevGlyph = glyph;
                    }
                }

                // Apply transformation to rect
                var p = new Vector2(rect.X, rect.Y);
                p = p.Transform(ref _transformation);
                var s = new Vector2(rect.Width * _scale.X, rect.Height * _scale.Y);

                Current = new Glyph
                {
                    Index = _index,
                    Codepoint = codepoint,
                    Bounds = new Rectangle((int)p.X, (int)p.Y, (int)s.X, (int)s.Y),
                    XAdvance = (int)(xAdvance * _scale.X),
                };

                ++_index;
                return true;
            }

            return false;
        }
    }

    public GlyphEnumerator GetGlyphs(string text, Vector2 position,
        Vector2 origin = default, Vector2? scale = null,
        float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0) =>
        GetGlyphs(new TextSource(text), position, origin, scale, characterSpacing, lineSpacing, effect, effectAmount);

    public GlyphEnumerator GetGlyphs(StringBuilder text, Vector2 position,
        Vector2 origin = default, Vector2? scale = null,
        float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0) =>
        GetGlyphs(new TextSource(text), position, origin, scale, characterSpacing, lineSpacing, effect, effectAmount);

    public GlyphEnumerator GetGlyphs(string text, OpenTK.Mathematics.Vector2i position,
        OpenTK.Mathematics.Vector2 origin = default, OpenTK.Mathematics.Vector2? scale = null,
        float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0) =>
        GetGlyphs(new TextSource(text), ToVector2(position), ToVector2(origin), ToVector2(scale), characterSpacing, lineSpacing, effect, effectAmount);

    public GlyphEnumerator GetGlyphs(StringBuilder text, OpenTK.Mathematics.Vector2 position,
        OpenTK.Mathematics.Vector2 origin = default, OpenTK.Mathematics.Vector2? scale = null,
        float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0) =>
        GetGlyphs(new TextSource(text), ToVector2(position), ToVector2(origin), ToVector2(scale), characterSpacing, lineSpacing, effect, effectAmount);

    public Vector2 MeasureString(string text, Vector2? scale = null,
        float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0)
    {
        var bounds = TextBounds(text, Utility.Vector2Zero, scale, characterSpacing, lineSpacing, effect, effectAmount);
        return new Vector2(bounds.X2, bounds.Y2);
    }

    public Vector2 MeasureString(StringBuilder text, Vector2? scale = null,
        float characterSpacing = 0.0f, float lineSpacing = 0.0f,
        FontSystemEffect effect = FontSystemEffect.None, int effectAmount = 0)
    {
        var bounds = TextBounds(text, Utility.Vector2Zero, scale, characterSpacing, lineSpacing, effect, effectAmount);
        return new Vector2(bounds.X2, bounds.Y2);
    }

    internal abstract float GetKerning(FontGlyph glyph, FontGlyph prevGlyph);

    public static Texture2D GetWhite(ITexture2DManager textureManager)
    {
        if (_white != null)
            return _white;

        _white = textureManager.CreateTexture(1, 1);
        textureManager.SetTextureData(_white, new Rectangle(0, 0, 1, 1), new byte[] { 255, 255, 255, 255 });

        return _white;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector2 ToVector2(OpenTK.Mathematics.Vector2i vector)
    {
        return new Vector2(vector.X, vector.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector2 ToVector2(OpenTK.Mathematics.Vector2 vector)
    {
        return new Vector2(vector.X, vector.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector2? ToVector2(OpenTK.Mathematics.Vector2i? vector)
    {
        if (vector == null)
            return null;

        return ToVector2(vector.GetValueOrDefault());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector2? ToVector2(OpenTK.Mathematics.Vector2? vector)
    {
        if (vector == null)
            return null;

        return ToVector2(vector.GetValueOrDefault());
    }
}