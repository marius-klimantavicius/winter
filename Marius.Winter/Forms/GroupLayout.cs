using System;
using NvgSharp;
using OpenTK.Mathematics;

namespace Marius.Winter.Forms;

public class GroupLayout : Layout
{
    protected int _margin;
    protected int _spacing;
    protected int _groupSpacing;
    protected int _groupIndent;

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

    public int GroupSpacing
    {
        get => _groupSpacing;
        set => _groupSpacing = value;
    }

    public int GroupIndent
    {
        get => _groupIndent;
        set => _groupIndent = value;
    }

    public GroupLayout(int margin = 15, int spacing = 5, int groupSpacing = 14, int groupIndent = 20)
    {
        _margin = margin;
        _spacing = spacing;
        _groupSpacing = groupSpacing;
        _groupIndent = groupIndent;
    }

    public override Vector2i GetPreferredSize(NvgContext ctx, Widget widget)
    {
        var height = _margin;
        var width = 2 * _margin;

        if (widget is Window window && !string.IsNullOrEmpty(window.Title))
            height += widget.Theme.WindowHeaderHeight - _margin / 2;

        var first = true;
        var indent = false;
        foreach (var child in widget.Children)
        {
            if (!child.IsVisible)
                continue;

            var label = child as Label;
            if (!first)
                height += label == null ? _spacing : _groupSpacing;
            first = false;

            var ps = child.GetPreferredSize(ctx);
            var fs = child.FixedSize;
            var targetSize = new Vector2i(
                fs.X != 0 ? fs.X : ps.X,
                fs.Y != 0 ? fs.Y : ps.Y
            );

            var indentCurrent = indent && label == null;
            height += targetSize.Y;
            width = Math.Max(width, targetSize.X + 2 * _margin + (indentCurrent ? _groupIndent : 0));

            if (label != null)
                indent = !string.IsNullOrEmpty(label.Caption);
        }

        height += _margin;
        return new Vector2i(width, height);
    }

    public override void PerformLayout(NvgContext ctx, Widget widget)
    {
        var height = _margin;
        var availableWidth = (widget.FixedWidth != 0 ? widget.FixedWidth : widget.Width) - 2 * _margin;

        if (widget is Window window && !string.IsNullOrEmpty(window.Title))
            height += widget.Theme.WindowHeaderHeight - _margin / 2;

        var first = true;
        var indent = false;
        foreach (var c in widget.Children)
        {
            if (!c.IsVisible)
                continue;

            var label = c as Label;
            if (!first)
                height += label == null ? _spacing : _groupSpacing;
            first = false;

            var indentCurrent = indent && label == null;
            var ps = new Vector2i(availableWidth - (indentCurrent ? _groupIndent : 0),
                c.GetPreferredSize(ctx).Y);
            var fs = c.FixedSize;

            var targetSize = new Vector2i(
                fs.X != 0 ? fs.X : ps.X,
                fs.Y != 0 ? fs.Y : ps.Y
            );

            c.Position = new Vector2i(_margin + (indentCurrent ? _groupIndent : 0), height);
            c.Size = targetSize;
            c.PerformLayout(ctx);

            height += targetSize.Y;

            if (label != null)
                indent = !string.IsNullOrEmpty(label.Caption);
        }
    }
}