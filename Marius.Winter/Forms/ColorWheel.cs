using System;
using System.Drawing;
using NvgSharp;
using OpenTK.Mathematics;
using OpenTK.Platform;

namespace Marius.Winter.Forms;

public class ColorWheel : Widget
{
    private const float TOLERANCE = 0.000001f;

    protected float _hue;
    protected float _white;
    protected float _black;
    protected ColorWheelRegion _dragRegion;

    public event Action<ColorWheel, Color>? Changed;

    public Color Color
    {
        get
        {
            var rgb = FromHue(_hue);
            var black = Color.Black;
            var white = Color.White;
            var r = (int)(rgb.R * (1 - _white - _black) + black.R * _black + white.R * _white);
            var g = (int)(rgb.G * (1 - _white - _black) + black.G * _black + white.G * _white);
            var b = (int)(rgb.B * (1 - _white - _black) + black.B * _black + white.B * _white);
            var a = (int)(rgb.A * (1 - _white - _black) + black.A * _black + white.A * _white);
            return Color.FromArgb(a, r, g, b);
        }
        set
        {
            var r = value.R / 255f;
            var g = value.G / 255f;
            var b = value.B / 255f;

            var max = Math.Max(Math.Max(r, g), b);
            var min = Math.Min(Math.Min(r, g), b);
            if (Math.Abs(max - min) < TOLERANCE)
            {
                var l = 0.5f * (max + min);
                _hue = 0f;
                _black = 1f - l;
                _white = l;
            }
            else
            {
                var d = max - min;
                var h = 0f;

                if (Math.Abs(max - r) < TOLERANCE)
                    h = (g - b) / d + (g < b ? 6 : 0);
                else if (Math.Abs(max - g) < TOLERANCE)
                    h = (b - r) / d + 2;
                else
                    h = (r - g) / d + 4;

                h /= 6;

                var ch = FromHue(_hue);
                var max2 = Math.Max(ch.R / 255f, Math.Max(ch.G / 255f, ch.B / 255f));
                var min2 = Math.Min(ch.R / 255f, Math.Min(ch.G / 255f, ch.B / 255f));

                _white = (max * min2 - min * max2) / (min2 - max2);
                _black = (max + min2 + min * max2 - min - max * min2 - max2) / (min2 - max2);
                _hue = h;
            }
        }
    }

    public ColorWheel(Widget parent, Color? color = null)
        : base(parent)
    {
        Color = color.GetValueOrDefault(Color.Red);
    }

    public override Vector2i GetPreferredSize(NvgContext context)
    {
        return new Vector2i(100, 100);
    }

    public override void Draw(NvgContext context)
    {
        base.Draw(context);

        if (!_isVisible)
            return;

        var x = _position.X;
        var y = _position.Y;
        var w = _size.X;
        var h = _size.Y;

        var hue = _hue;
        var paint = default(Paint);

        context.SaveState();

        var cx = x + w * 0.5f;
        var cy = y + h * 0.5f;
        var r1 = (w < h ? w : h) * 0.5f - 5.0f;
        var r0 = r1 * .75f;

        var aeps = 0.5f / r1; // half a pixel arc length in radians (2pi cancels out).

        var ax = 0f;
        var ay = 0f;
        var bx = 0f;
        var by = 0f;

        for (var i = 0; i < 6; i++)
        {
            var a0 = (float)(i / 6.0f * Math.PI * 2.0f - aeps);
            var a1 = (float)((i + 1.0f) / 6.0f * Math.PI * 2.0f + aeps);
            context.BeginPath();
            context.Arc(cx, cy, r0, a0, a1, Winding.ClockWise);
            context.Arc(cx, cy, r1, a1, a0, Winding.CounterClockWise);
            context.ClosePath();
            ax = (float)(cx + Math.Cos(a0) * (r0 + r1) * 0.5f);
            ay = (float)(cy + Math.Sin(a0) * (r0 + r1) * 0.5f);
            bx = (float)(cx + Math.Cos(a1) * (r0 + r1) * 0.5f);
            by = (float)(cy + Math.Sin(a1) * (r0 + r1) * 0.5f);
            paint = context.LinearGradient(ax, ay, bx, by,
                FromHsla((float)(a0 / (Math.PI * 2)), 1.0f, 0.55f, 255),
                FromHsla((float)(a1 / (Math.PI * 2)), 1.0f, 0.55f, 255));
            context.FillPaint(paint);
            context.Fill();
        }

        context.BeginPath();
        context.Circle(cx, cy, r0 - 0.5f);
        context.Circle(cx, cy, r1 + 0.5f);
        context.StrokeColor(Color.FromArgb(64, 0, 0, 0));
        context.StrokeWidth(1.0f);
        context.Stroke();

        // Selector
        context.SaveState();
        context.Translate(cx, cy);
        context.Rotate((float)(hue * Math.PI * 2));

        // Marker on
        var u = Math.Max(r1 / 50, 1.5f);
        u = Math.Min(u, 4f);
        context.StrokeWidth(u);
        context.BeginPath();
        context.Rect(r0 - 1, -2 * u, r1 - r0 + 2, 4 * u);
        context.StrokeColor(Color.FromArgb(192, 255, 255, 255));
        context.Stroke();

        paint = context.BoxGradient(r0 - 3, -5, r1 - r0 + 6, 10, 2, 4, Color.FromArgb(128, 0, 0, 0), Color.FromArgb(0, 0, 0, 0));
        context.BeginPath();
        context.Rect(r0 - 2 - 10, -4 - 10, r1 - r0 + 4 + 20, 8 + 20);
        context.Rect(r0 - 2, -4, r1 - r0 + 4, 8);
        context.PathWinding(Solidity.Hole);
        context.FillPaint(paint);
        context.Fill();

        // Center triangle
        var r = r0 - 6;
        ax = -0.5f * r;
        ay = (float)(0.5f * Math.Sqrt(3f) * r);
        bx = -0.5f * r;
        by = (float)(-0.5f * Math.Sqrt(3f) * r);
        context.BeginPath();
        context.MoveTo(r, 0);
        context.LineTo(ax, ay);
        context.LineTo(bx, by);
        context.ClosePath();
        paint = context.LinearGradient(r, 0, ax, ay, FromHsla(hue, 1.0f, 0.5f, 255), Color.FromArgb(255, 255, 255, 255));
        context.FillPaint(paint);
        context.Fill();
        paint = context.LinearGradient((r + ax) * 0.5f, (0 + ay) * 0.5f, bx, by, Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 0, 0, 0));
        context.FillPaint(paint);
        context.Fill();
        context.StrokeColor(Color.FromArgb(64, 0, 0, 0));
        context.Stroke();

        // Select circle on triangle
        var sx = r * (1 - _white - _black) + ax * _white + bx * _black;
        var sy = ay * _white + by * _black;

        context.StrokeWidth(u);
        context.BeginPath();
        context.Circle(sx, sy, 2 * u);
        context.StrokeColor(Color.FromArgb(192, 255, 255, 255));
        context.Stroke();

        context.RestoreState();

        context.RestoreState();
    }

    public override bool OnMouseDown(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        base.OnMouseDown(position, button, modifiers);

        if (!_isEnabled || button != MouseButton.Button1)
            return false;

        _dragRegion = AdjustPosition(position, ColorWheelRegion.Both);
        return _dragRegion != ColorWheelRegion.None;
    }

    public override bool OnMouseUp(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        base.OnMouseUp(position, button, modifiers);

        if (!_isEnabled || button != MouseButton.Button1)
            return false;

        _dragRegion = ColorWheelRegion.None;
        return true;
    }

    public override bool OnMouseDrag(Vector2i position, Vector2i relative, int mouseState, KeyModifier modifiers)
    {
        var parentAbsolutePosition = Vector2i.Zero;
        if (_parent != null)
            parentAbsolutePosition = _parent.AbsolutePosition;

        return AdjustPosition(position - parentAbsolutePosition, _dragRegion) != ColorWheelRegion.None;
    }

    private ColorWheelRegion AdjustPosition(Vector2i position, ColorWheelRegion consideredRegions)
    {
        var x = (float)(position.X - _position.X);
        var y = (float)(position.Y - _position.Y);
        var w = (float)_size.X;
        var h = (float)_size.Y;

        var cx = w * 0.5f;
        var cy = h * 0.5f;
        var r1 = (w < h ? w : h) * 0.5f - 5.0f;
        var r0 = r1 * .75f;

        x -= cx;
        y -= cy;

        var mr = (float)Math.Sqrt(x * x + y * y);

        if ((consideredRegions & ColorWheelRegion.OuterCircle) != 0 &&
            ((mr >= r0 && mr <= r1) || (consideredRegions == ColorWheelRegion.OuterCircle)))
        {
            if ((consideredRegions & ColorWheelRegion.OuterCircle) == 0)
                return ColorWheelRegion.None;

            _hue = (float)Math.Atan(y / x);
            if (x < 0)
                _hue += (float)Math.PI;
            _hue /= (float)(2 * Math.PI);

            Changed?.Invoke(this, Color);

            return ColorWheelRegion.OuterCircle;
        }

        var a = (float)(-_hue * 2 * Math.PI);
        var sinA = (float)Math.Sin(a);
        var cosA = (float)Math.Cos(a);
        var xy = new Vector2(cosA * x - sinA * y, sinA * x + cosA * y);

        var r = r0 - 6;
        var l0 = (float)((r - xy.X + Math.Sqrt(3) * xy.Y) / (3 * r));
        var l1 = (float)((r - xy.X - Math.Sqrt(3) * xy.Y) / (3 * r));
        var l2 = 1 - l0 - l1;
        var triangleTest = l0 >= 0 && l0 <= 1f && l1 >= 0f && l1 <= 1f && l2 >= 0f && l2 <= 1f;

        if ((consideredRegions & ColorWheelRegion.InnerTriangle) != 0 &&
            (triangleTest || consideredRegions == ColorWheelRegion.InnerTriangle))
        {
            if ((consideredRegions & ColorWheelRegion.InnerTriangle) == 0)
                return ColorWheelRegion.None;

            l0 = Math.Min(Math.Max(0f, l0), 1f);
            l1 = Math.Min(Math.Max(0f, l1), 1f);
            l2 = Math.Min(Math.Max(0f, l2), 1f);
            var sum = l0 + l1 + l2;
            l0 /= sum;
            l1 /= sum;
            _white = l0;
            _black = l1;

            Changed?.Invoke(this, Color);
            return ColorWheelRegion.InnerTriangle;
        }

        return ColorWheelRegion.None;
    }

    private static Color FromHsla(float h, float s, float l, int a)
    {
        // Normalize hue to [0, 1]
        h %= 1.0f;
        if (h < 0.0f)
            h += 1.0f;

        var hsl = new Color3<Hsl>(h, s, l);
        var rgb = hsl.ToRgb();
        return Color.FromArgb(a, (int)(rgb.X * 255), (int)(rgb.Y * 255), (int)(rgb.Z * 255));
    }

    private static Color FromHue(float h)
    {
        // Normalize hue to [0, 1]
        h %= 1.0f;
        if (h < 0.0f)
            h += 1.0f;

        var hsv = new Color3<Hsv>(h, 1, 1);
        var rgb = hsv.ToRgb();
        return Color.FromArgb(255, (int)(rgb.X * 255), (int)(rgb.Y * 255), (int)(rgb.Z * 255));
    }

    [Flags]
    protected enum ColorWheelRegion
    {
        None = 0,
        InnerTriangle = 1,
        OuterCircle = 2,
        Both = 3,
    }
}