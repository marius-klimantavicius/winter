using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Hebron.Runtime;

internal readonly ref struct UnsafeSpan<T>
{
    private readonly ref T _start;

    public ref T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref Unsafe.Add(ref _start, index);
    }

    public bool IsNull => Unsafe.IsNullRef(ref _start);

    public UnsafeSpan(int length)
    {
        _start = ref MemoryMarshal.GetArrayDataReference(new T[length]);
    }

    public UnsafeSpan(ref T start)
    {
        _start = ref start;
    }

    public UnsafeSpan(T[]? array)
    {
        if (array == null)
            _start = ref Unsafe.NullRef<T>();
        else
            _start = ref MemoryMarshal.GetArrayDataReference(array);
    }

    public static implicit operator UnsafeSpan<T>(T[] array) => new UnsafeSpan<T>(array);

    public static UnsafeSpan<T> operator +(UnsafeSpan<T> span, int offset) => new UnsafeSpan<T>(ref Unsafe.Add(ref span._start, offset));

    public Span<T> AsSpan(int length) => MemoryMarshal.CreateSpan(ref _start, length);

    public Span<T> AsSpan(int offset, int length) => MemoryMarshal.CreateSpan(ref Unsafe.Add(ref _start, offset), length);
}