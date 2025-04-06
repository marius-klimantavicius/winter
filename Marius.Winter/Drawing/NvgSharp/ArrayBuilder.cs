using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NvgSharp;

internal sealed class ArrayBuilder<T>
{
    private T[] _items;
    private int _itemsInUse;

    private static readonly T[] Empty = Array.Empty<T>();
    private readonly ArrayPool<T> _arrayPool;
    private readonly int _minCapacity;

    public int Count => _itemsInUse;
    public T[] Buffer => _items;

    public ref T this[int index]
    {
        get
        {
            if (index >= _itemsInUse)
                ThrowIndexOutOfBoundsException();

            return ref _items[index];
        }
    }

    public ArrayBuilder(int minCapacity = 32, ArrayPool<T>? arrayPool = null)
    {
        _arrayPool = arrayPool ?? ArrayPool<T>.Shared;
        _minCapacity = minCapacity;
        _items = Empty;
    }

    public Span<T> AsSpan() => _items.AsSpan(0, _itemsInUse);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] // Just like System.Collections.Generic.List<T>
    public int Append(in T item)
    {
        if (_itemsInUse == _items.Length) 
            GrowBuffer(_items.Length * 2);

        var indexOfAppendedItem = _itemsInUse++;
        _items[indexOfAppendedItem] = item;
        return indexOfAppendedItem;
    }

    internal int Append(T[] source, int startIndex, int length) => Append(source.AsSpan(startIndex, length));

    internal int Append(ReadOnlySpan<T> source)
    {
        var requiredCapacity = _itemsInUse + source.Length;
        if (_items.Length < requiredCapacity)
        {
            var candidateCapacity = Math.Max(_items.Length * 2, _minCapacity);
            while (candidateCapacity < requiredCapacity)
                candidateCapacity *= 2;

            GrowBuffer(candidateCapacity);
        }

        source.CopyTo(_items.AsSpan(_itemsInUse));
        var startIndexOfAppendedItems = _itemsInUse;
        _itemsInUse += source.Length;
        return startIndexOfAppendedItems;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Overwrite(int index, in T value)
    {
        if (index > _itemsInUse) 
            ThrowIndexOutOfBoundsException();

        _items[index] = value;
    }

    public void RemoveLast()
    {
        if (_itemsInUse == 0) 
            ThrowIndexOutOfBoundsException();

        _itemsInUse--;
        _items[_itemsInUse] = default; // Release to GC
    }

    public void InsertExpensive(int index, T value)
    {
        if (index > _itemsInUse)
            ThrowIndexOutOfBoundsException();

        if (_itemsInUse == _items.Length)
            GrowBuffer(_items.Length * 2);

        Array.Copy(_items, index, _items, index + 1, _itemsInUse - index);
        _itemsInUse++;

        _items[index] = value;
    }

    public void Clear()
    {
        ReturnBuffer();
        _items = Empty;
        _itemsInUse = 0;
    }

    private void GrowBuffer(int desiredCapacity)
    {
        var newCapacity = Math.Max(desiredCapacity, _minCapacity);
        Debug.Assert(newCapacity > _items.Length);

        var newItems = _arrayPool.Rent(newCapacity);
        Array.Copy(_items, newItems, _itemsInUse);

        // Return the old buffer and start using the new buffer
        ReturnBuffer();
        _items = newItems;
    }

    private void ReturnBuffer()
    {
        if (!ReferenceEquals(_items, Empty))
        {
            Array.Clear(_items, 0, _itemsInUse);
            _arrayPool.Return(_items);
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void ThrowIndexOutOfBoundsException()
    {
        throw new ArgumentOutOfRangeException("index");
    }
}