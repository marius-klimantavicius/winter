using System;
using System.Collections.Generic;
using NvgSharp;
using OpenTK.Mathematics;

namespace Marius.Winter.Forms;

public class GridLayout : Layout
{
    protected Orientation _orientation;
    protected Alignment _defaultAlignment0;
    protected Alignment _defaultAlignment1;
    protected List<Alignment> _alignment0 = new List<Alignment>();
    protected List<Alignment> _alignment1 = new List<Alignment>();
    protected int _resolution;
    protected Vector2i _spacing;
    protected int _margin;

    public Orientation Orientation
    {
        get => _orientation;
        set => _orientation = value;
    }

    public int Resolution
    {
        get => _resolution;
        set => _resolution = value;
    }

    public Vector2i Spacing
    {
        get => _spacing;
        set => _spacing = value;
    }

    public int Margin
    {
        get => _margin;
        set => _margin = value;
    }

    public GridLayout(Orientation orientation = Orientation.Horizontal, int resolution = 2, Alignment alignment = Alignment.Middle, int margin = 0, int spacing = 0)
    {
        _orientation = orientation;
        _resolution = resolution;
        _defaultAlignment0 = _defaultAlignment1 = alignment;
        _margin = margin;
        _spacing = new Vector2i(spacing);
    }

    public Alignment GetAlignment(int axis, int item)
    {
        if (axis == 0)
        {
            if (item < _alignment0.Count)
                return _alignment0[item];

            return _defaultAlignment0;
        }

        if (item < _alignment1.Count)
            return _alignment1[item];

        return _defaultAlignment1;
    }

    public void SetColumnAlignment(Alignment alignment)
    {
        _defaultAlignment0 = alignment;
    }

    public void SetColumnAlignment(List<Alignment> alignment)
    {
        _alignment0 = alignment;
    }

    public void SetRowAlignment(Alignment alignment)
    {
        _defaultAlignment1 = alignment;
    }

    public void SetRowAlignment(List<Alignment> alignment)
    {
        _alignment1 = alignment;
    }

    public override Vector2i GetPreferredSize(NvgContext context, Widget widget)
    {
        var grid = new GridArray();
        try
        {
            ComputeLayout(context, widget, ref grid);

            var size = new Vector2i(
                2 * _margin + grid.Sum(0) + Math.Max(grid[0].Length - 1, 0) * _spacing.X,
                2 * _margin + grid.Sum(1) + Math.Max(grid[1].Length - 1, 0) * _spacing.Y
            );

            if (widget is Window window && !string.IsNullOrEmpty(window.Title))
                size.Y += widget.Theme.WindowHeaderHeight - _margin / 2;

            return size;
        }
        finally
        {
            grid.Dispose();
        }
    }

    public override void PerformLayout(NvgContext context, Widget widget)
    {
        var fsW = widget.FixedSize;
        var h = 0;
        if (widget is Window window && !string.IsNullOrEmpty(window.Title))
            h = widget.Theme.WindowHeaderHeight;

        var containerSize = new Vector2i(
            fsW.X != 0 ? fsW.X : widget.Width,
            (fsW.Y != 0 ? fsW.Y : widget.Height) - h
        );

        /* Compute minimum row / column sizes */
        var grid = new GridArray();
        try
        {
            ComputeLayout(context, widget, ref grid);
            Span<int> dim = stackalloc int[2] { grid[0].Length, grid[1].Length };

            var extra = new Vector2i(0);
            if (widget is Window window2 && !string.IsNullOrEmpty(window2.Title))
                extra.Y += widget.Theme.WindowHeaderHeight - _margin / 2;

            /* Stretch to size provided by \c widget */
            for (var i = 0; i < 2; i++)
            {
                var gridSize = 2 * _margin + extra[i];
                foreach (var s in grid[i])
                {
                    gridSize += s;
                    if (i + 1 < dim[i])
                        gridSize += _spacing[i];
                }

                if (gridSize < containerSize[i])
                {
                    /* Re-distribute remaining space evenly */
                    var gap = containerSize[i] - gridSize;
                    var g = gap / dim[i];
                    var rest = gap - g * dim[i];
                    for (var j = 0; j < dim[i]; ++j)
                        grid[i][j] += g;
                    for (var j = 0; rest > 0 && j < dim[i]; --rest, ++j)
                        grid[i][j] += 1;
                }
            }

            int axis1 = (int)_orientation, axis2 = (axis1 + 1) % 2;
            var start = new Vector2i(_margin) + extra;

            var childrenCount = widget.Children.Count;
            var child = 0;

            var pos = start;
            for (var i2 = 0; i2 < dim[axis2]; i2++)
            {
                pos[axis1] = start[axis1];
                for (var i1 = 0; i1 < dim[axis1]; i1++)
                {
                    var w = default(Widget);
                    do
                    {
                        if (child >= childrenCount)
                            return;

                        w = widget.Children[child++];
                    } while (!w.IsVisible);

                    var ps = w.GetPreferredSize(context);
                    var fs = w.FixedSize;

                    var targetSize = new Vector2i(
                        fs.X != 0 ? fs.X : ps.X,
                        fs.Y != 0 ? fs.Y : ps.Y
                    );

                    var itemPosition = new Vector2i(pos.X, pos.Y);
                    for (var j = 0; j < 2; j++)
                    {
                        var axis = (axis1 + j) % 2;
                        var item = j == 0 ? i1 : i2;
                        var align = GetAlignment(axis, item);

                        switch (align)
                        {
                            case Alignment.Minimum:
                                break;
                            case Alignment.Middle:
                                itemPosition[axis] += (grid[axis][item] - targetSize[axis]) / 2;
                                break;
                            case Alignment.Maximum:
                                itemPosition[axis] += grid[axis][item] - targetSize[axis];
                                break;
                            case Alignment.Fill:
                                targetSize[axis] = fs[axis] != 0 ? fs[axis] : grid[axis][item];
                                break;
                        }
                    }

                    w.Position = itemPosition;
                    w.Size = targetSize;
                    w.PerformLayout(context);
                    pos[axis1] += grid[axis1][i1] + _spacing[axis1];
                }

                pos[axis2] += grid[axis2][i2] + _spacing[axis2];
            }
        }
        finally
        {
            grid.Dispose();
        }
    }

    protected void ComputeLayout(NvgContext context, Widget widget, ref GridArray grid)
    {
        var axis1 = (int)_orientation;
        var axis2 = (axis1 + 1) % 2;
        var childrenCount = widget.Children.Count;
        var visibleChildren = 0;
        foreach (var w in widget.Children)
            visibleChildren += w.IsVisible ? 1 : 0;

        Span<int> dim = stackalloc int[2];
        dim[axis1] = _resolution;
        dim[axis2] = (visibleChildren + _resolution - 1) / _resolution;

        grid.Reset(axis1, dim[axis1]);
        grid.Reset(axis2, dim[axis2]);

        var child = 0;
        for (var i2 = 0; i2 < dim[axis2]; i2++)
        {
            for (var i1 = 0; i1 < dim[axis1]; i1++)
            {
                var w = default(Widget);
                do
                {
                    if (child >= childrenCount)
                        return;

                    w = widget.Children[child++];
                } while (!w.IsVisible);

                var ps = w.GetPreferredSize(context);
                var fs = w.FixedSize;
                var targetSize = new Vector2i(
                    fs.X != 0 ? fs.X : ps.X,
                    fs.Y != 0 ? fs.Y : ps.Y
                );

                grid[axis1][i1] = Math.Max(grid[axis1][i1], targetSize[axis1]);
                grid[axis2][i2] = Math.Max(grid[axis2][i2], targetSize[axis2]);
            }
        }
    }
}