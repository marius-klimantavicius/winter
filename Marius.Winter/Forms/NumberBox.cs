using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using OpenTK.Mathematics;
using OpenTK.Platform;
using Vector2 = OpenTK.Mathematics.Vector2;

namespace Marius.Winter.Forms;

public partial class NumberBox<T> : TextBox
    where T : unmanaged, INumber<T>, IMinMaxValue<T>
{
    private readonly ConditionalWeakTable<Action<NumberBox<T>, T>, Func<TextBox, string, bool>> _changedTable = new ConditionalWeakTable<Action<NumberBox<T>, T>, Func<TextBox, string, bool>>();

    protected string? _numberFormat;
    protected T _mouseDownValue;
    protected T _valueIncrement;
    protected T _minValue;
    protected T _maxValue;

    public T ValueIncrement
    {
        get => _valueIncrement;
        set => _valueIncrement = value;
    }

    public T MinValue
    {
        get => _minValue;
        set => _minValue = value;
    }

    public T MaxValue
    {
        get => _maxValue;
        set => _maxValue = value;
    }

    public new T Value
    {
        get
        {
            var stringValue = base.Value;
            T.TryParse(stringValue, CultureInfo.CurrentCulture, out var parsedValue);
            return T.Clamp(parsedValue, _minValue, _maxValue);
        }
        set
        {
            var clampedValue = T.Clamp(value, _minValue, _maxValue);
            base.Value = clampedValue.ToString(_numberFormat, CultureInfo.CurrentCulture);
        }
    }

    public new event Action<NumberBox<T>, T>? Changed
    {
        add => base.Changed += GetEvent(value);
        remove => base.Changed -= GetEvent(value);
    }

    public NumberBox(Widget? parent, T value = default)
        : base(parent)
    {
        DefaultValue = "0";
        ValueIncrement = T.One;
        MinValue = T.MinValue;
        MaxValue = T.MaxValue;
        Value = value;
        IsSpinnable = false;

        var isFloat = !T.IsInteger(T.MinValue) || !T.IsInteger(T.One / T.CreateTruncating(2));
        if (isFloat)
        {
            ValueIncrement = T.One / T.CreateTruncating(10);
            unsafe
            {
                if (sizeof(T) == sizeof(float))
                    _numberFormat = "0.####";
                else
                    _numberFormat = "0.#######";
            }

            if (typeof(T) == typeof(decimal))
                Format = GenerateDecimalFormatRegex();
            else
                Format = GenerateFloatFormatRegex();
        }
        else
        {
            var isUnsignedSigned = T.MinValue >= T.Zero;
            if (isUnsignedSigned)
                Format = GenerateUIntFormatRegex();
            else
                Format = GenerateIntFormatRegex();
        }
    }

    public override bool OnMouseDown(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        if (_isEditable || _isSpinnable)
            _mouseDownValue = Value;

        var area = GetSpinArea(position);
        if (_isSpinnable && area != SpinArea.None && !IsFocused)
        {
            if (area == SpinArea.Top)
            {
                Value += _valueIncrement;
                RaiseChanged(_value);
            }
            else if (area == SpinArea.Bottom)
            {
                Value -= _valueIncrement;
                RaiseChanged(_value);
            }

            return true;
        }

        return base.OnMouseDown(position, button, modifiers);
    }

    public override bool OnMouseDrag(Vector2i position, Vector2i relative, int mouseState, KeyModifier modifiers)
    {
        if (base.OnMouseDrag(position, relative, mouseState, modifiers))
            return true;

        if (_isSpinnable && !IsFocused && mouseState == 1 << (int)MouseButton.Button2 && _mouseDownPosition.X != -1)
        {
            var valueDelta = T.CreateTruncating((position.X - _mouseDownPosition.X) / 10.0f);
            Value = _mouseDownValue + valueDelta * _valueIncrement;
            RaiseChanged(_value);
            return true;
        }

        return false;
    }

    public override bool OnScroll(Vector2i position, Vector2 distance, Vector2 relative)
    {
        if (base.OnScroll(position, distance, relative))
            return true;

        if (_isSpinnable && !IsFocused)
        {
            var valueDelta = T.CreateTruncating(relative.Y > 0 ? 1 : -1);
            Value += valueDelta * _valueIncrement;
            RaiseChanged(_value);
            return true;
        }

        return false;
    }

    protected Func<TextBox, string, bool> GetEvent(Action<NumberBox<T>, T>? action)
    {
        if (action == null)
            return static (_, _) => false;

        return _changedTable.GetValue(action, static key =>
        {
            return (textBox, str) =>
            {
                if (textBox is NumberBox<T> intBox)
                {
                    T.TryParse(str, CultureInfo.CurrentCulture, out var value);
                    intBox.Value = value;
                    key(intBox, value);
                    return true;
                }

                return false;
            };
        })!;
    }

    [GeneratedRegex(@"^\s*[-]?[0-9]*\s*$")]
    private static partial Regex GenerateIntFormatRegex();

    [GeneratedRegex(@"^\s*[0-9]*\s*$")]
    private static partial Regex GenerateUIntFormatRegex();

    [GeneratedRegex(@"^\s*[+-]?[0-9]*\.?[0-9]*([eE][-+]?[0-9]+)?\s*$")]
    private static partial Regex GenerateFloatFormatRegex();

    [GeneratedRegex(@"^\s*[+-]?[0-9]*\.?[0-9]*\s*$")]
    private static partial Regex GenerateDecimalFormatRegex();
}