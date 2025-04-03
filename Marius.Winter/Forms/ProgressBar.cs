using System;
using NvgSharp;
using OpenTK.Mathematics;

namespace Marius.Winter.Forms;

public class ProgressBar : Widget
{
    protected float _value;

    public float Value
    {
        get => _value;
        set => _value = value;
    }

    public ProgressBar(Widget? parent)
        : base(parent)
    {
        _value = 0;
    }

    public override Vector2i GetPreferredSize(NvgContext context)
    {
        return new Vector2i(70, 12);
    }

    public override void Draw(NvgContext context)
    {
        var paint = context.BoxGradient(
            _position.X + 1, _position.Y + 1,
            _size.X - 2, _size.Y, 3, 4, MakeColor(0, 32), MakeColor(0, 92));
        context.BeginPath();
        context.RoundedRect(_position.X, _position.Y, _size.X, _size.Y, 3);
        context.FillPaint(paint);
        context.Fill();

        var value = Math.Min(Math.Max(0.0f, _value), 1.0f);
        var barPosition = (int)Math.Round((_size.X - 2) * value);

        paint = context.BoxGradient(
            _position.X, _position.Y,
            barPosition + 1.5f, _size.Y - 1, 3, 4,
            MakeColor(220, 100), MakeColor(128, 100));

        context.BeginPath();
        context.RoundedRect(_position.X + 1, _position.Y + 1, barPosition, _size.Y - 2, 3);
        context.FillPaint(paint);
        context.Fill();

        base.Draw(context);
    }
}