using System;
using System.Drawing;
using NvgSharp;
using OpenTK.Mathematics;
using OpenTK.Platform;

namespace Marius.Winter.Forms;

public class ScrollBar : Widget
{
    protected int _sliderPreferredSide;
    protected float _offset;
    protected ScrollBarAlignment _alignment;

    public float Offset
    {
        get => _offset;
        set => _offset = value;
    }

    public ScrollBarAlignment Alignment
    {
        get => _alignment;
        set => _alignment = value;
    }

    public event Action<ScrollBar, float>? Scroll;

    public ScrollBar(Widget parent, ScrollBarAlignment alignment = ScrollBarAlignment.VerticalRight)
        : base(parent)
    {
        _sliderPreferredSide = 1;
        _offset = 0;
        _alignment = alignment;
    }

    public override void PerformLayout(NvgContext context)
    {
        base.PerformLayout(context);

        var p = Parent;
        if (p == null)
            return;

        if (_alignment == ScrollBarAlignment.VerticalLeft || _alignment == ScrollBarAlignment.VerticalRight)
        {
            Size = new Vector2i(12, p.Height);
            if (_alignment == ScrollBarAlignment.VerticalRight)
                Position = new Vector2i(p.Width - 6, 0);
            else
                Position = new Vector2i(0, 0);

            _sliderPreferredSide = Height * 3;
        }
        else
        {
            Size = new Vector2i(p.Width, 12);
            if (_alignment == ScrollBarAlignment.HorizontalBottom)
                Position = new Vector2i(0, p.Height - 6);
            else
                Position = new Vector2i(0, 0);

            _sliderPreferredSide = Width * 3;
        }
    }

    public override Vector2i GetPreferredSize(NvgContext context)
    {
        if (Parent == null)
            return new Vector2i(12, 12);

        if (_alignment == ScrollBarAlignment.VerticalLeft || _alignment == ScrollBarAlignment.VerticalRight)
            return new Vector2i(12, Parent.Height);

        return new Vector2i(Parent.Width, 12);
    }

    public override bool OnMouseDrag(Vector2i position, Vector2i relative, int mouseState, KeyModifier modifiers)
    {
        if (_alignment == ScrollBarAlignment.VerticalLeft || _alignment == ScrollBarAlignment.VerticalRight)
        {
            if (_sliderPreferredSide > _size.Y)
            {
                var scrollh = Height * Math.Min(1.0f, Height / (float)_sliderPreferredSide);

                _offset = Math.Max(0.0f, Math.Min(1.0f, _offset + relative.Y / (_size.Y - 8 - scrollh)));
                Scroll?.Invoke(this, _offset);
                return true;
            }
        }
        else if (_alignment == ScrollBarAlignment.HorizontalBottom || _alignment == ScrollBarAlignment.HorizontalTop)
        {
            if (_sliderPreferredSide > _size.X)
            {
                var scrollw = Width * Math.Min(1.0f, Width / (float)_sliderPreferredSide);

                _offset = Math.Max(0.0f, Math.Min(1.0f, _offset + relative.X / (_size.X - 8 - scrollw)));
                Scroll?.Invoke(this, _offset);
                return true;
            }
        }

        return base.OnMouseDrag(position, relative, mouseState, modifiers);
    }

    public override bool OnScroll(Vector2i position, Vector2 distance, Vector2 relative)
    {
        if (_alignment == ScrollBarAlignment.VerticalLeft || _alignment == ScrollBarAlignment.VerticalRight)
        {
            if (_sliderPreferredSide > _size.Y)
            {
                var scrollAmount = relative.Y * (_size.Y / 20.0f);
                var scrollh = Height * Math.Min(1.0f, Height / (float)_sliderPreferredSide);

                _offset = Math.Max(0.0f, Math.Min(1.0f,
                    _offset - scrollAmount / (_size.Y - 8 - scrollh)));
                Scroll?.Invoke(this, _offset);
                return true;
            }
        }
        else if (_alignment == ScrollBarAlignment.HorizontalBottom || _alignment == ScrollBarAlignment.HorizontalTop)
        {
            if (_sliderPreferredSide > _size.X)
            {
                var scrollAmount = relative.Y * (_size.X / 20.0f);
                var scrollw = Width * Math.Min(1.0f, Width / (float)_sliderPreferredSide);

                _offset = Math.Max(0.0f, Math.Min(1.0f, _offset - scrollAmount / (_size.X - 8 - scrollw)));
                Scroll?.Invoke(this, _offset);
                return true;
            }

            return true;
        }

        return base.OnScroll(position, distance, relative);
    }

    public override void Draw(NvgContext context)
    {
        if (_alignment == ScrollBarAlignment.VerticalLeft || _alignment == ScrollBarAlignment.VerticalRight)
        {
            var scrollh = Height * Math.Min(1.0f, Height / (float)_sliderPreferredSide);

            if (_sliderPreferredSide <= _size.Y)
                return;

            var ww = _alignment == ScrollBarAlignment.VerticalLeft ? 0 : _size.X;
            var wx = _alignment == ScrollBarAlignment.VerticalLeft ? 0 : 12;
            var dx = _alignment == ScrollBarAlignment.VerticalLeft ? -2 : 0;
            var paint = context.BoxGradient(_position.X + ww - wx + 1,
                _position.Y + 4 + 1, 8, _size.Y - 8,
                3, 4, Color.FromArgb(32, 0, 0, 0), Color.FromArgb(92, 0, 0, 0));

            //body
            context.BeginPath();
            context.RoundedRect(_position.X + ww - wx + dx, _position.Y + 4, 8, _size.Y - 8, 3);
            context.FillPaint(paint);
            context.Fill();

            paint = context.BoxGradient(_position.X + ww - wx - 1,
                _position.Y + 4 + (_size.Y - 8 - scrollh) * _offset - 1, 8, scrollh,
                3, 4, Color.FromArgb(100, 220, 220, 220), Color.FromArgb(100, 128, 128, 128));

            //slider
            var sx = _alignment == ScrollBarAlignment.VerticalLeft ? -1 : 1;
            context.BeginPath();
            context.RoundedRect(_position.X + ww - wx + sx,
                _position.Y + 4 + 1 + (_size.Y - 8 - scrollh) * _offset, 8 - 2,
                scrollh - 2, 2);
            context.FillPaint(paint);
            context.Fill();
        }
        else if (_alignment == ScrollBarAlignment.HorizontalBottom || _alignment == ScrollBarAlignment.HorizontalTop)
        {
            var scrollw = Width * Math.Min(1.0f, Width / (float)_sliderPreferredSide);

            if (_sliderPreferredSide <= _size.X)
                return;

            var paint = context.BoxGradient(_position.X + 4 + 1,
                _position.Y + _size.Y - 12 + 1, _size.X - 8, 8,
                3, 4, Color.FromArgb(32, 0, 0, 0), Color.FromArgb(92, 0, 0, 0));

            context.BeginPath();
            context.RoundedRect(_position.X + 4, _position.Y + _size.Y - 12, _size.X - 8, 8, 3);
            context.FillPaint(paint);
            context.Fill();

            paint = context.BoxGradient(_position.X + 4 + (_size.X - 8 - scrollw) * _offset - 1,
                _position.Y + _size.Y - 12 - 1, scrollw, 9,
                3, 4, Color.FromArgb(100, 220, 220, 220), Color.FromArgb(100, 128, 128, 128));

            context.BeginPath();
            context.RoundedRect(_position.X + 4 + 1 + (_size.X - 8 - scrollw) * _offset,
                _position.Y + _size.Y - 12 + 1, scrollw - 2, 8 - 2, 2);
            context.FillPaint(paint);
            context.Fill();
        }

        base.Draw(context);
    }
}

public enum ScrollBarAlignment
{
    VerticalRight = 0,
    HorizontalBottom = 1,
    VerticalLeft = 2,
    HorizontalTop = 3,
}