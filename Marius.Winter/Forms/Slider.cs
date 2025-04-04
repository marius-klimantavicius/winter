using System;
using System.Drawing;
using NvgSharp;
using OpenTK.Mathematics;
using OpenTK.Platform;

namespace Marius.Winter.Forms;

public class Slider : Widget
{
    private const float TOLERANCE = 0.000001f;

    protected float _value;
    protected float _minValue;
    protected float _maxValue;
    protected float _highlightMinValue;
    protected float _highlightMaxValue;
    protected Color _highlightColor;

    public event Action<Slider, float>? ValueChanging;
    public event Action<Slider, float>? ValueChanged;

    public float Value
    {
        get => _value;
        set => _value = value;
    }

    public Color HighlightColor
    {
        get => _highlightColor;
        set => _highlightColor = value;
    }

    public float MinValue
    {
        get => _minValue;
        set => _minValue = value;
    }

    public float MaxValue
    {
        get => _maxValue;
        set => _maxValue = value;
    }

    public float HighlightMinValue
    {
        get => _highlightMinValue;
        set => _highlightMinValue = value;
    }

    public float HighlightMaxValue
    {
        get => _highlightMaxValue;
        set => _highlightMaxValue = value;
    }

    public Slider(Widget? parent)
        : base(parent)
    {
        _value = 0;
        _minValue = 0;
        _maxValue = 0.1f;
        _highlightMinValue = 0;
        _highlightMaxValue = 0;
        _highlightColor = Color.FromArgb(70, 255, 80, 80);
    }

    public override Vector2i GetPreferredSize(NvgContext context)
    {
        return new Vector2i(70, 16);
    }

    public override void Draw(NvgContext context)
    {
        if (_size.Y == 0)
            return;

        var center = _position.ToVector2() + _size.ToVector2() * 0.5f;
        var kr = (float)(int)(_size.Y * 0.4f);
        var shadow = 3f;

        var startX = kr + shadow + _position.X;
        var widthX = _size.X - 2 * (kr + shadow);

        var knobPosition = new Vector2(startX + (_value - _minValue) / (_maxValue - _minValue) * widthX, center.Y + 0.5f);

        var bg = context.BoxGradient(startX, center.Y - 3 + 1, widthX, 6, 3, 3, MakeColor(0, _isEnabled ? 32 : 10), MakeColor(0, _isEnabled ? 128 : 210));

        context.BeginPath();
        context.RoundedRect(startX, center.Y - 3 + 1, widthX, 6, 2);
        context.FillPaint(bg);
        context.Fill();

        if (Math.Abs(_highlightMaxValue - _highlightMinValue) > TOLERANCE)
        {
            context.BeginPath();
            context.RoundedRect(startX + _highlightMinValue * _size.X, center.Y - shadow + 1, widthX * (_highlightMaxValue - _highlightMinValue), shadow * 2, 2);
            context.FillColor(_highlightColor);
            context.Fill();
        }

        var knobShadow = context.RadialGradient(knobPosition.X, knobPosition.Y, kr - shadow, kr + shadow, MakeColor(0, 64), _theme.Transparent);

        context.BeginPath();
        context.Rect(knobPosition.X - kr - 5, knobPosition.Y - kr - 5, kr * 2 + 10, kr * 2 + 10 + shadow);
        context.Circle(knobPosition.X, knobPosition.Y, kr);
        context.PathWinding(Solidity.Hole);
        context.FillPaint(knobShadow);
        context.Fill();

        var knob = context.LinearGradient(_position.X, center.Y - kr, _position.X, center.Y + kr, _theme.BorderLight, _theme.BorderMedium);
        var knobReverse = context.LinearGradient(_position.X, center.Y - kr, _position.X, center.Y + kr, _theme.BorderMedium, _theme.BorderLight);

        context.BeginPath();
        context.Circle(knobPosition.X, knobPosition.Y, kr);
        context.StrokeColor(_theme.BorderDark);
        context.FillPaint(knob);
        context.Stroke();
        context.Fill();
        context.BeginPath();
        context.Circle(knobPosition.X, knobPosition.Y, kr / 2);
        context.FillColor(MakeColor(150, _isEnabled ? 255 : 100));
        context.StrokePaint(knobReverse);
        context.Stroke();
        context.Fill();
    }

    public override bool OnMouseDrag(Vector2i position, Vector2i relative, int mouseState, KeyModifier modifiers)
    {
        if (!_isEnabled)
            return false;

        position -= AbsolutePosition;

        var kr = (float)(int)(_size.Y * 0.4f);
        const float shadow = 3f;
        var startX = kr + shadow - 1;
        var widthX = _size.X - 2 * (kr + shadow);

        var value = (position.X - startX) / widthX;
        var oldValue = _value;
        value = value * (_maxValue - _minValue) + _minValue;
        _value = Math.Min(Math.Max(value, _minValue), _maxValue);
        if (ValueChanging != null && Math.Abs(_value - oldValue) > TOLERANCE)
            ValueChanging(this, _value);
        return true;
    }

    public override bool OnMouseDown(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        return OnMouseButton(position, button, modifiers, true);
    }

    public override bool OnMouseUp(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        return OnMouseButton(position, button, modifiers, false);
    }

    protected bool OnMouseButton(Vector2i position, MouseButton button, KeyModifier modifiers, bool down)
    {
        if (!_isEnabled)
            return false;

        var kr = (float)(int)(_size.Y * 0.4f);
        const float shadow = 3f;
        var startX = kr + shadow + _position.X - 1;
        var widthX = _size.X - 2 * (kr + shadow);

        var value = (position.X - startX) / widthX;
        var oldValue = _value;
        value = value * (_maxValue - _minValue) + _minValue;
        _value = Math.Min(Math.Max(value, _minValue), _maxValue);

        if (ValueChanging != null && Math.Abs(_value - oldValue) > TOLERANCE)
            ValueChanging(this, _value);

        if (ValueChanged != null && !down)
            ValueChanged(this, _value);

        return true;
    }
}