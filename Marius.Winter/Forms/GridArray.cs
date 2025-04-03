using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Marius.Winter.Forms;

public struct GridArray : IDisposable
{
    private int[] _item0;
    private int _item0Count;
    private int[] _item1;
    private int _item1Count;

    public Span<int> this[int axis]
    {
        get
        {
            if (axis == 0)
                return _item0.AsSpan(0, _item0Count);
            if (axis == 1)
                return _item1.AsSpan(0, _item1Count);

            ThrowIndexOutOfRangeException();
            return Span<int>.Empty;
        }
    }

    public void Set(int axis, List<int> value)
    {
        Reset(axis, value.Count);

        CollectionsMarshal.AsSpan(value).CopyTo(this[axis]);
    }

    public void InsertAt(int axis, int index, int value)
    {
        var count = this[axis].Length;
        Reset(axis, count + 1, false);
        
        var source = this[axis].Slice(0, count);
        var span = this[axis];
        source.Slice(index).CopyTo(span.Slice(index + 1));
        span[index] = value;
    }

    public void Dispose()
    {
        if (_item0 != null)
            ArrayPool<int>.Shared.Return(_item0);
        if (_item1 != null)
            ArrayPool<int>.Shared.Return(_item1);

        this = default;
    }

    public void Reset(int axis, int newCount, bool clear = true)
    {
        if (axis == 0)
            ResetArray(ref _item0, out _item0Count, newCount, clear);
        else if (axis == 1)
            ResetArray(ref _item1, out _item1Count, newCount, clear);
        else
            ThrowIndexOutOfRangeException();

        return;

        static void ResetArray(ref int[]? array, out int count, int newCount, bool clear)
        {
            array ??= ArrayPool<int>.Shared.Rent(newCount);
            if (array.Length < newCount)
            {
                var newArray = ArrayPool<int>.Shared.Rent(newCount);
                if (!clear)
                    array.AsSpan().CopyTo(newArray);

                ArrayPool<int>.Shared.Return(array);
                array = newArray;
            }

            if (clear)
                array.AsSpan(0, newCount).Clear();
            count = newCount;
        }
    }

    public int Sum(int axis)
    {
        var item = this[axis];
        if (item.Length == 1)
            return item[0];

        return Sum(item);
    }

    public static int Sum(ReadOnlySpan<int> array)
    {
        var result = 0;
        for (var i = 0; i < array.Length; i++)
            result += array[i];

        return result;
    }
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void ThrowIndexOutOfRangeException() => throw new IndexOutOfRangeException("Index out of range. Must be 0 or 1.");
}