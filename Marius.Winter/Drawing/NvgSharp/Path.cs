using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NvgSharp;

internal struct Path
{
    private static readonly NvgPoint[] Empty = Array.Empty<NvgPoint>();

    private NvgPoint[] _points;
    private int _itemsInUse;

    public bool Closed;
    public int FillOffset, FillCount;
    public int StrokeOffset, StrokeCount;
    public Winding Winding;
    public bool Convex;

    public ref NvgPoint this[int index]
    {
        get
        {
            if (index >= _itemsInUse)
                ThrowIndexOutOfBoundsException();

            return ref _points[index];
        }
    }

    public int Count => _itemsInUse;

    public ref NvgPoint FirstPoint => ref this[0];
    public ref NvgPoint LastPoint => ref this[_itemsInUse - 1];

    public Path()
    {
        _points = Empty;
    }
    
    public Span<NvgPoint> AsSpan() => _points.AsSpan(0, _itemsInUse);

    private void GrowBuffer(int desiredCapacity)
    {
        var newCapacity = Math.Max(desiredCapacity, 32);
        Debug.Assert(newCapacity > _points.Length);

        var newItems = ArrayPool<NvgPoint>.Shared.Rent(newCapacity);
        Array.Copy(_points, newItems, _itemsInUse);

        // Return the old buffer and start using the new buffer
        ReturnBuffer();
        _points = newItems;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)] // Just like System.Collections.Generic.List<T>
    public int Append(in NvgPoint item)
    {
        if (_itemsInUse == _points.Length)
            GrowBuffer(_points.Length * 2);

        var indexOfAppendedItem = _itemsInUse++;
        _points[indexOfAppendedItem] = item;
        return indexOfAppendedItem;
    }

    public void RemoveLast()
    {
        if (_itemsInUse == 0)
            ThrowIndexOutOfBoundsException();

        _itemsInUse--;
        _points[_itemsInUse] = default; // Release to GC
    }

    public void Clear()
    {
        ReturnBuffer();
        _points = Empty;
        _itemsInUse = 0;
    }

    private void ReturnBuffer()
    {
        if (!ReferenceEquals(_points, Empty))
        {
            Array.Clear(_points, 0, _itemsInUse);
            ArrayPool<NvgPoint>.Shared.Return(_points);
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void ThrowIndexOutOfBoundsException()
    {
        throw new ArgumentOutOfRangeException("index");
    }
}