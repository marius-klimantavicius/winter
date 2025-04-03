using System;
using NvgSharp;
using OpenTK.Mathematics;

namespace Marius.Winter.Forms;

public class BoxLayout : Layout
{
    protected Orientation _orientation;
    protected Alignment _alignment;
    protected int _margin;
    protected int _spacing;

    public Orientation Orientation
    {
        get => _orientation;
        set => _orientation = value;
    }

    public Alignment Alignment
    {
        get => _alignment;
        set => _alignment = value;
    }

    public int Margin
    {
        get => _margin;
        set => _margin = value;
    }

    public int Spacing
    {
        get => _spacing;
        set => _spacing = value;
    }

    public BoxLayout(Orientation orientation, Alignment alignment = Alignment.Middle, int margin = 0, int spacing = 0)
    {
        _orientation = orientation;
        _alignment = alignment;
        _margin = margin;
        _spacing = spacing;
    }

    public override Vector2i GetPreferredSize(NvgContext context, Widget widget)
    {
        var size = new Vector2i(2 * _margin);

        var yOffset = 0;
        if (widget is Window window && !string.IsNullOrEmpty(window.Title))
        {
            if (_orientation == Orientation.Vertical)
                size[1] += widget.Theme.WindowHeaderHeight - _margin / 2;
            else
                yOffset = widget.Theme.WindowHeaderHeight;
        }

        var first = true;
        var axis1 = (int)_orientation;
        var axis2 = ((int)_orientation + 1) % 2;
        foreach (var w in widget.Children)
        {
            if (!w.IsVisible)
                continue;

            if (first)
                first = false;
            else
                size[axis1] += _spacing;

            var ps = w.GetPreferredSize(context);
            var fs = w.FixedSize;
            var targetSize = new Vector2i(
                fs.X != 0 ? fs.X : ps.X,
                fs.Y != 0 ? fs.Y : ps.Y
            );

            size[axis1] += targetSize[axis1];
            size[axis2] = Math.Max(size[axis2], targetSize[axis2] + 2 * _margin);
            first = false;
        }

        return size + new Vector2i(0, yOffset);
    }

    public override void PerformLayout(NvgContext context, Widget widget)
    {
        var fsW = widget.FixedSize;
        var containerSize = new Vector2i(
            fsW.X != 0 ? fsW.X : widget.Width,
            fsW.Y != 0 ? fsW.Y : widget.Height
        );

        var axis1 = (int)_orientation;
        var axis2 = ((int)_orientation + 1) % 2;
        var position = _margin;
        var y_offset = 0;

        if (widget is Window window && !string.IsNullOrEmpty(window.Title))
        {
            if (_orientation == Orientation.Vertical)
            {
                position += widget.Theme.WindowHeaderHeight - _margin / 2;
            }
            else
            {
                y_offset = widget.Theme.WindowHeaderHeight;
                containerSize[1] -= y_offset;
            }
        }

        var first = true;
        foreach (var w in widget.Children)
        {
            if (!w.IsVisible)
                continue;

            if (first)
                first = false;
            else
                position += _spacing;

            var ps = w.GetPreferredSize(context);
            var fs = w.FixedSize;
            var targetSize = new Vector2i(
                fs.X != 0 ? fs.X : ps.X,
                fs.Y != 0 ? fs.Y : ps.Y
            );
            var pos = new Vector2i(0, y_offset)
            {
                [axis1] = position,
            };

            switch (_alignment)
            {
                case Alignment.Minimum:
                    pos[axis2] += _margin;
                    break;
                case Alignment.Middle:
                    pos[axis2] += (containerSize[axis2] - targetSize[axis2]) / 2;
                    break;
                case Alignment.Maximum:
                    pos[axis2] += containerSize[axis2] - targetSize[axis2] - _margin * 2;
                    break;
                case Alignment.Fill:
                    pos[axis2] += _margin;
                    targetSize[axis2] = fs[axis2] != 0 ? fs[axis2] : containerSize[axis2] - _margin * 2;
                    break;
            }

            w.Position = pos;
            w.Size = targetSize;
            w.PerformLayout(context);
            position += targetSize[axis1];
        }
    }
}