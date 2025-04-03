using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NvgSharp;
using OpenTK.Mathematics;

namespace Marius.Winter.Forms;

public class AdvancedGridLayout : Layout
{
    private readonly ConditionalWeakTable<Widget, Anchor> _anchors = new ConditionalWeakTable<Widget, Anchor>();

    protected readonly List<int> _columns;
    protected readonly List<int> _rows;
    protected readonly List<float> _columnStretch;
    protected readonly List<float> _rowStretch;

    protected int _margin;

    public int Margin
    {
        get => _margin;
        set => _margin = value;
    }

    public int ColumnCount => _columns.Count;
    public int RowCount => _rows.Count;

    public AdvancedGridLayout(List<int> columns, List<int> rows)
    {
        _columns = new List<int>(columns);
        _rows = new List<int>(rows);

        _columnStretch = new List<float>(columns.Count);
        for (var i = 0; i < _columns.Count; i++)
            _columnStretch.Add(0);

        _rowStretch = new List<float>(rows.Count);
        for (var i = 0; i < _rows.Count; i++)
            _rowStretch.Add(0);
    }

    public void SetRowStretch(int row, float stretch) => _rowStretch[row] = stretch;
    public void SetColumnStretch(int column, float stretch) => _columnStretch[column] = stretch;

    public void SetAnchor(Widget widget, int column, int row, int columnSpan = 1, int rowSpan = 1, Alignment horizontal = Alignment.Fill, Alignment vertical = Alignment.Fill)
    {
        var anchor = _anchors.GetOrCreateValue(widget)!;
        anchor.Column = column;
        anchor.Row = row;
        anchor.ColumnSpan = columnSpan;
        anchor.RowSpan = rowSpan;
        anchor.ColumnAlignment = horizontal;
        anchor.RowAlignment = vertical;
    }

    public void AppendRow(int size, float stretch)
    {
        _rows.Add(size);
        _rowStretch.Add(stretch);
    }

    public void AppendColumn(int size, float stretch)
    {
        _columns.Add(size);
        _columnStretch.Add(stretch);
    }

    public override Vector2i GetPreferredSize(NvgContext ctx, Widget widget)
    {
        var grid = new GridArray();
        try
        {
            ComputeLayout(ctx, widget, ref grid);

            var size = new Vector2i(grid.Sum(0), grid.Sum(1));

            var extra = new Vector2i(2 * _margin);
            if (widget is Window window && !string.IsNullOrEmpty(window.Title))
                extra[1] += widget.Theme.WindowHeaderHeight - _margin / 2;

            return size + extra;
        }
        finally
        {
            grid.Dispose();
        }
    }

    public override void PerformLayout(NvgContext ctx, Widget widget)
    {
        var grid = new GridArray();
        try
        {
            ComputeLayout(ctx, widget, ref grid);

            grid.InsertAt(0, 0, _margin);
            if (widget is Window window && !string.IsNullOrEmpty(window.Title))
                grid.InsertAt(1, 0, widget.Theme.WindowHeaderHeight + _margin / 2);
            else
                grid.InsertAt(1, 0, _margin);

            for (var axis = 0; axis < 2; ++axis)
            {
                var axisArray = grid[axis];
                for (var i = 1; i < axisArray.Length; ++i)
                    axisArray[i] += axisArray[i - 1];

                foreach (var w in widget.Children)
                {
                    if (!w.IsVisible || w is Window)
                        continue;

                    if (!_anchors.TryGetValue(w, out var anchor) || anchor == null)
                        throw new Exception("Widget was not registered with the grid layout!");

                    var itemPosition = axisArray[anchor.Position[axis]];
                    var index = anchor.Position[axis] + anchor.Size[axis];
                    var cellSize = axisArray[index] - itemPosition;
                    var ps = w.GetPreferredSize(ctx)[axis];
                    var fs = w.FixedSize[axis];
                    var targetSize = fs != 0 ? fs : ps;

                    switch (anchor.Alignment[axis])
                    {
                        case Alignment.Minimum:
                            break;
                        case Alignment.Middle:
                            itemPosition += (cellSize - targetSize) / 2;
                            break;
                        case Alignment.Maximum:
                            itemPosition += cellSize - targetSize;
                            break;
                        case Alignment.Fill:
                            targetSize = fs != 0 ? fs : cellSize;
                            break;
                    }

                    var pos = w.Position;
                    var size = w.Size;
                    pos[axis] = itemPosition;
                    size[axis] = targetSize;
                    w.Position = pos;
                    w.Size = size;
                    w.PerformLayout(ctx);
                }
            }
        }
        finally
        {
            grid.Dispose();
        }
    }

    protected virtual void ComputeLayout(NvgContext ctx, Widget widget, ref GridArray grid)
    {
        var fsW = widget.FixedSize;
        var containerSize = new Vector2i(
            fsW.X != 0 ? fsW.X : widget.Width,
            fsW.Y != 0 ? fsW.Y : widget.Height
        );

        var extra = new Vector2i(2 * _margin);
        if (widget is Window window && !string.IsNullOrEmpty(window.Title))
            extra[1] += widget.Theme.WindowHeaderHeight - _margin / 2;

        containerSize -= extra;

        for (var axis = 0; axis < 2; ++axis)
        {
            var sizes = axis == 0 ? _columns : _rows;
            var stretch = axis == 0 ? _columnStretch : _rowStretch;

            grid.Set(axis, sizes);
            var sizeGrid = grid[axis];

            for (var phase = 0; phase < 2; ++phase)
            {
                foreach (var (w, anchor) in _anchors)
                {
                    if (!w.IsVisible || w is Window)
                        continue;

                    if (anchor.Size[axis] == 1 != (phase == 0))
                        continue;

                    var ps = w.GetPreferredSize(ctx)[axis];
                    var fs = w.FixedSize[axis];
                    var targetSize = fs != 0 ? fs : ps;

                    if (anchor.Position[axis] + anchor.Size[axis] > sizeGrid.Length)
                        throw new Exception("Advanced grid layout: widget is out of bounds: {anchor}");

                    var currentSize = 0;
                    var totalStretch = 0f;
                    for (var i = anchor.Position[axis]; i < anchor.Position[axis] + anchor.Size[axis]; ++i)
                    {
                        if (sizes[i] == 0 && anchor.Size[axis] == 1)
                            sizeGrid[i] = Math.Max(sizeGrid[i], targetSize);
                        currentSize += sizeGrid[i];
                        totalStretch += stretch[i];
                    }

                    if (targetSize <= currentSize)
                        continue;

                    if (totalStretch == 0)
                        throw new Exception("Advanced grid layout: no space to place widget: {anchor}");

                    var amt = (targetSize - currentSize) / totalStretch;
                    for (var i = anchor.Position[axis]; i < anchor.Position[axis] + anchor.Size[axis]; ++i)
                        sizeGrid[i] += (int)Math.Round(amt * stretch[i]);
                }
            }

            var currentSize2 = GridArray.Sum(sizeGrid);
            var totalStretch2 = stretch.Sum();
            if (currentSize2 >= containerSize[axis] || totalStretch2 == 0)
                continue;

            var amt2 = (containerSize[axis] - currentSize2) / totalStretch2;
            for (var i = 0; i < sizeGrid.Length; ++i)
                sizeGrid[i] += (int)Math.Round(amt2 * stretch[i]);
        }
    }

    protected bool TryGetAnchor(Widget widget, out int x, out int y, out int w, out int h, out Alignment horizontal, out Alignment vertical)
    {
        if (!_anchors.TryGetValue(widget, out var value) || value == null)
        {
            x = 0;
            y = 0;
            w = 0;
            h = 0;
            horizontal = default;
            vertical = default;
            return false;
        }

        x = value.Column;
        y = value.Row;
        w = value.ColumnSpan;
        h = value.RowSpan;
        horizontal = value.ColumnAlignment;
        vertical = value.RowAlignment;
        return true;
    }

    private sealed class Anchor
    {
        public int Column;
        public int Row;
        public int ColumnSpan;
        public int RowSpan;
        public Alignment ColumnAlignment;
        public Alignment RowAlignment;

        public AxisValue<int> Position => new AxisValue<int>(ref Column, ref Row);
        public AxisValue<int> Size => new AxisValue<int>(ref ColumnSpan, ref RowSpan);
        public AxisValue<Alignment> Alignment => new AxisValue<Alignment>(ref ColumnAlignment, ref RowAlignment);

        public override string ToString()
        {
            return $"Format[pos=({Column}, {Row}), size=({ColumnSpan}, {RowSpan}), align=({ColumnAlignment}, {RowAlignment})]";
        }
    }

    private readonly ref struct AxisValue<T>
    {
        private readonly ref T _item0;
        private readonly ref T _item1;

        public ref T this[int axis]
        {
            get
            {
                if (axis == 0)
                    return ref _item0;
                if (axis == 1)
                    return ref _item1;

                ThrowIndexOutOfRangeException();
                return ref Unsafe.NullRef<T>();
            }
        }

        public AxisValue(ref T item0, ref T item1)
        {
            _item0 = ref item0;
            _item1 = ref item1;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void ThrowIndexOutOfRangeException() => throw new IndexOutOfRangeException("Index must be 0 or 1");
    }
}