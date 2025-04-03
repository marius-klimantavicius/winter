using System;
using System.Buffers;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using FontStashSharp;
using NvgSharp;
using OpenTK.Mathematics;
using OpenTK.Platform;

namespace Marius.Winter.Forms;

public class TextBox : Widget
{
    protected bool _isControlKeyboardInput;

    protected bool _isEditable;
    protected bool _isSpinnable;
    protected bool _isCommitted;
    protected string _value;
    protected string _defaultValue;
    protected TextAlignment _textAlignment;
    protected string _units;
    protected Regex? _format;
    protected int _unitsImage;
    protected bool _isValidFormat;
    protected StringBuilder _valueTemporary;
    protected string _placeholder;
    protected int _cursorPosition;
    protected int _selectionPosition;
    protected Vector2i _mousePosition;
    protected Vector2i _mouseDownPosition;
    protected Vector2i _mouseDragPosition;
    protected KeyModifier _mouseDownModifier;
    protected float _textOffset;
    protected long _lastClick;

    public event Func<TextBox, string, bool>? Changed;

    public bool IsEditable
    {
        get => _isEditable;
        set
        {
            _isEditable = value;
            Cursor = _isEditable ? Cursor.IBeam : Cursor.Arrow;
        }
    }

    public bool IsSpinnable
    {
        get => _isSpinnable;
        set => _isSpinnable = value;
    }

    public virtual string Value
    {
        get => _value;
        set => _value = value;
    }

    public string DefaultValue
    {
        get => _defaultValue;
        set => _defaultValue = value;
    }

    public TextAlignment Alignment
    {
        get => _textAlignment;
        set => _textAlignment = value;
    }

    public string Units
    {
        get => _units;
        set => _units = value;
    }

    public int UnitsImage
    {
        get => _unitsImage;
        set => _unitsImage = value;
    }

    public Regex? Format
    {
        get => _format;
        set => _format = value;
    }

    public string Placeholder
    {
        get => _placeholder;
        set => _placeholder = value;
    }

    public override Theme Theme
    {
        get => base.Theme;
        set
        {
            base.Theme = value;
            _fontSize = _theme.TextBoxFontSize;
        }
    }

    public TextBox(Widget? parent, string value = "")
        : base(parent)
    {
        _isEditable = true;
        _isSpinnable = false;
        _isCommitted = true;
        _value = value;
        _defaultValue = "";
        _textAlignment = TextAlignment.Left;
        _units = "";
        _format = null;
        _unitsImage = -1;
        _isValidFormat = true;
        _valueTemporary = new StringBuilder(value);
        _cursorPosition = -1;
        _selectionPosition = -1;
        _mousePosition = new Vector2i(-1, -1);
        _mouseDownPosition = new Vector2i(-1, -1);
        _mouseDragPosition = new Vector2i(-1, -1);
        _mouseDownModifier = 0;
        _textOffset = 0;
        _lastClick = 0;
        _placeholder = "";

        _fontSize = _theme.TextBoxFontSize;
    }

    public override Vector2i GetPreferredSize(NvgContext context)
    {
        var size = new Vector2i(0, (int)(FontSize * 1.4f));
        var font = _theme.FontSansRegular.GetFont(FontSize);
        var uw = 0f;
        if (_unitsImage > 0)
        {
            throw new NotImplementedException();
            // int w, h;
            // ctx.ImageSize( _unitsImage, &w, &h);
            // float uh = size[1] * 0.4f;
            // uw = w * uh / h;
        }
        else if (!string.IsNullOrEmpty(_units))
        {
            uw = font.MeasureString(_units).X;
        }

        float sw = 0;
        if (_isSpinnable)
        {
            sw = 14.0f;
        }

        var ts = font.MeasureString(_value).X;
        size[0] = (int)(size[1] + ts + uw + sw);
        return size;
    }

    public override void Draw(NvgContext context)
    {
        var bg = context.BoxGradient(
            _position.X + 1, _position.Y + 1 + 1.0f, _size.X - 2, _size.Y - 2,
            3, 4, Color.FromArgb(32, 255, 255, 255), Color.FromArgb(32, 32, 32, 32));
        var fg1 = context.BoxGradient(
            _position.X + 1, _position.Y + 1 + 1.0f, _size.X - 2, _size.Y - 2,
            3, 4, Color.FromArgb(32, 100, 100, 100), Color.FromArgb(32, 32, 32, 32));
        var fg2 = context.BoxGradient(
            _position.X + 1, _position.Y + 1 + 1.0f, _size.X - 2, _size.Y - 2,
            3, 4, Color.FromArgb(100, 255, 0, 0), Color.FromArgb(50, 255, 0, 0));

        context.BeginPath();
        context.RoundedRect(_position.X + 1, _position.Y + 1 + 1.0f, _size.X - 2, _size.Y - 2, 3);

        if (_isEditable && IsFocused)
            context.FillPaint(_isValidFormat ? fg1 : fg2);
        else if (_isSpinnable && _mouseDownPosition.X != -1)
            context.FillPaint(fg1);
        else
            context.FillPaint(bg);

        context.Fill();

        context.BeginPath();
        context.RoundedRect(_position.X + 0.5f, _position.Y + 0.5f, _size.X - 1, _size.Y - 1, 2.5f);
        context.StrokeColor(Color.FromArgb(48, 0, 0, 0));
        context.Stroke();

        var sansFont = _theme.FontSansRegular.GetFont(FontSize);
        var textPosition = new Vector2(_position.X, _position.Y + _size.Y / 2.0f + 1);

        var xSpacing = _size.Y * 0.3f;
        var unitWidth = 0f;
        if (_unitsImage > 0)
        {
            throw new NotImplementedException();
            // int w, h;
            // ctx.ImageSize(_unitsImage, &w, &h);
            // float unit_height = _size.Y * 0.4f;
            // unit_width = w * unit_height / h;
            // var img_paint = ctx.ImagePattern(
            //     _position.X + _size.X - x_spacing - unit_width,
            //     draw_pos.Y - unit_height/ 2.0f, unit_width, unit_height, 0,
            //     _unitsImage, _isEnabled ? 0.7f : 0.35f);
            // ctx.BeginPath();
            // ctx.Rect(_position.X + _size.X - x_spacing - unit_width,
            //     draw_pos.Y - unit_height/ 2.0f, unit_width, unit_height);
            // ctx.FillPaint(img_paint);
            // ctx.Fill();
            // unit_width += 2;
        }
        else if (!string.IsNullOrEmpty(_units))
        {
            unitWidth = sansFont.MeasureString(_units).X;
            context.FillColor(Color.FromArgb(_isEnabled ? 64 : 32, 255, 255, 255));
            context.TextAligned(sansFont, _units, _position.X + _size.X - xSpacing, textPosition.Y, TextHorizontalAlignment.Right, TextVerticalAlignment.Center);
            unitWidth += 2;
        }

        var spinArrowsWidth = 0.0f;
        if (_isSpinnable && !IsFocused)
        {
            spinArrowsWidth = 14.0f;

            var iconFontSize = (_fontSize < 0 ? _theme.ButtonFontSize : _fontSize) * IconScale;
            var spinning = _mouseDownPosition.X != -1;

            /* up button */
            {
                var hover = _isMouseOver && GetSpinArea(_mousePosition) == SpinArea.Top;
                context.FillColor(_isEnabled && (hover || spinning) ? _theme.TextColor : _theme.DisabledTextColor);
                var iconPosition = new Vector2(_position.X + 4.0f, _position.Y + _size.Y / 2.0f - xSpacing / 2.0f);

                var icon = _theme.TextBoxUpIcon;
                var iconsFont = icon.IconFont.GetFont(iconFontSize);
                context.TextAligned(iconsFont, icon.IconText, iconPosition.X, iconPosition.Y, TextHorizontalAlignment.Left, TextVerticalAlignment.Center);
            }

            /* down button */
            {
                var hover = _isMouseOver && GetSpinArea(_mousePosition) == SpinArea.Bottom;
                context.FillColor(_isEnabled && (hover || spinning) ? _theme.TextColor : _theme.DisabledTextColor);
                var iconPosition = new Vector2(_position.X + 4.0f, _position.Y + _size.Y / 2.0f + xSpacing / 2.0f + 1.5f);

                var icon = _theme.TextBoxDownIcon;
                var iconsFont = icon.IconFont.GetFont(iconFontSize);
                context.TextAligned(iconsFont, icon.IconText, iconPosition.X, iconPosition.Y, TextHorizontalAlignment.Left, TextVerticalAlignment.Center);
            }
        }

        var verticalAlignment = TextVerticalAlignment.Center;
        var horizontalAlignment = TextHorizontalAlignment.Left;
        switch (_textAlignment)
        {
            case TextAlignment.Left:
                horizontalAlignment = TextHorizontalAlignment.Left;
                textPosition.X += (int)(xSpacing + spinArrowsWidth);
                break;
            case TextAlignment.Right:
                horizontalAlignment = TextHorizontalAlignment.Right;
                textPosition.X += (int)(_size.X - unitWidth - xSpacing);
                break;
            case TextAlignment.Center:
                horizontalAlignment = TextHorizontalAlignment.Center;
                textPosition.X += (int)(_size.X / 2.0f);
                break;
        }

        context.FillColor(_isEnabled && (!_isCommitted || !string.IsNullOrEmpty(_value)) ? _theme.TextColor : _theme.DisabledTextColor);

        // clip visible text area
        var clipX = _position.X + xSpacing + spinArrowsWidth - 1.0f;
        var clipY = _position.Y + 1.0f;
        var clipWidth = _size.X - unitWidth - spinArrowsWidth - 2 * xSpacing + 2.0f;
        var clipHeight = _size.Y - 3.0f;

        context.SaveState();
        context.IntersectScissor(clipX, clipY, clipWidth, clipHeight);

        var oldDrawPosition = new Vector2(textPosition.X, textPosition.Y);
        textPosition.X += (int)_textOffset;

        if (_isCommitted)
        {
            context.TextAligned(sansFont, string.IsNullOrEmpty(_value) ? _placeholder : _value, textPosition.X, textPosition.Y, horizontalAlignment, verticalAlignment);
        }
        else
        {
            var textBound = sansFont.MeasureString(_valueTemporary);
            var lineHeight = textBound.Y;
            if (lineHeight == 0)
                lineHeight = FontSize;

            var alignedPosition = textPosition;
            context.ApplyAlignment(ref alignedPosition, textBound, sansFont, horizontalAlignment, verticalAlignment);

            // find cursor positions
            Span<Glyph> glyphStorage = stackalloc Glyph[1024];
            var glyphs = GetGlyphs(sansFont, _valueTemporary, alignedPosition, glyphStorage);
            UpdateCursor(context, alignedPosition.X + textBound.X, glyphs);

            // compute text offset
            var prevCursorPosition = _cursorPosition > 0 ? _cursorPosition - 1 : 0;
            var nextCursorPosition = _cursorPosition < glyphs.Length ? _cursorPosition + 1 : glyphs.Length;
            var prevCursorX = CursorIndexToPosition(prevCursorPosition, alignedPosition.X + textBound.X, glyphs);
            var nextCursorX = CursorIndexToPosition(nextCursorPosition, alignedPosition.X + textBound.X, glyphs);

            if (nextCursorX > clipX + clipWidth)
                _textOffset -= nextCursorX - (clipX + clipWidth) + 1;
            if (prevCursorX < clipX)
                _textOffset += clipX - prevCursorX + 1;

            alignedPosition.X = oldDrawPosition.X + _textOffset;
            alignedPosition.Y = oldDrawPosition.Y;

            // draw text with offset
            context.ApplyAlignment(ref alignedPosition, textBound, sansFont, horizontalAlignment, verticalAlignment);
            context.Text(sansFont, _valueTemporary, alignedPosition.X, alignedPosition.Y);

            // recompute cursor positions
            glyphs = GetGlyphs(sansFont, _valueTemporary, alignedPosition, glyphStorage);

            if (_cursorPosition > -1)
            {
                var caretX = 0f;
                if (_selectionPosition > -1)
                {
                    caretX = CursorIndexToPosition(_cursorPosition, alignedPosition.X + textBound.X, glyphs);
                    var selX = CursorIndexToPosition(_selectionPosition, alignedPosition.X + textBound.X, glyphs);

                    if (caretX > selX)
                        Swap(ref caretX, ref selX);

                    // draw selection
                    context.BeginPath();
                    context.FillColor(Color.FromArgb(80, 255, 255, 255));
                    context.Rect(caretX, oldDrawPosition.Y - lineHeight / 2.0f, selX - caretX, lineHeight);
                    context.Fill();
                }

                caretX = CursorIndexToPosition(_cursorPosition, alignedPosition.X + textBound.X, glyphs);

                // draw cursor
                context.BeginPath();
                context.MoveTo(caretX, oldDrawPosition.Y - lineHeight / 2.0f);
                context.LineTo(caretX, oldDrawPosition.Y + lineHeight / 2.0f);
                context.StrokeColor(Color.FromArgb(255, 255, 192, 0));
                context.StrokeWidth(1.0f);
                context.Stroke();
            }
        }

        context.RestoreState();

        base.Draw(context);

        return;

        static Span<Glyph> GetGlyphs(SpriteFontBase font, StringBuilder text, Vector2 position, Span<Glyph> storage)
        {
            var glyphCount = 0;
            foreach (var item in font.GetGlyphs(text, position))
            {
                if (glyphCount >= storage.Length)
                    break;

                storage[glyphCount++] = item;
            }

            return storage.Slice(0, glyphCount);
        }
    }

    public override bool OnMouseEnter(Vector2i position, bool isMouseOver)
    {
        base.OnMouseEnter(position, isMouseOver);
        return true;
    }

    public override bool OnMouseDown(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        if (button == MouseButton.Button1 && !_isFocused)
        {
            if (!_isSpinnable || GetSpinArea(position) == SpinArea.None) /* not on scrolling arrows */
                RequestFocus();
        }

        if (_isEditable && IsFocused)
        {
            _mouseDownPosition = position;
            _mouseDownModifier = modifiers;

            var now = Stopwatch.GetTimestamp();
            var time = Stopwatch.GetElapsedTime(_lastClick, now);
            if (time.TotalSeconds < 0.25)
            {
                /* Double-click: select all text */
                _selectionPosition = 0;
                _cursorPosition = _valueTemporary.Length;
                _mouseDownPosition = new Vector2i(-1, -1);
            }

            _lastClick = now;

            return true;
        }

        if (_isSpinnable && !IsFocused)
        {
            if (GetSpinArea(position) == SpinArea.None)
            {
                _mouseDownPosition = position;
                _mouseDownModifier = modifiers;

                var now = Stopwatch.GetTimestamp();
                var time = Stopwatch.GetElapsedTime(_lastClick, now);
                if (time.TotalSeconds < 0.25)
                {
                    /* Double-click: reset to default value */
                    _value = _defaultValue;
                    if (Changed != null)
                        Changed(this, _value);

                    _mouseDownPosition = new Vector2i(-1, -1);
                }

                _lastClick = now;
            }
            else
            {
                _mouseDownPosition = new Vector2i(-1, -1);
                _mouseDragPosition = new Vector2i(-1, -1);
            }

            return true;
        }

        return false;
    }

    public override bool OnMouseUp(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        if (_isEditable && IsFocused)
        {
            _mouseDownPosition = new Vector2i(-1, -1);
            _mouseDragPosition = new Vector2i(-1, -1);
            return true;
        }

        if (_isSpinnable && !IsFocused)
        {
            _mouseDownPosition = new Vector2i(-1, -1);
            _mouseDragPosition = new Vector2i(-1, -1);
            return true;
        }

        return false;
    }

    public override bool OnMouseMove(Vector2i position, Vector2i relative, int mouseState, KeyModifier modifiers)
    {
        _mousePosition = position;

        if (!_isEditable)
            Cursor = Cursor.Arrow;
        else if (_isSpinnable && !IsFocused && GetSpinArea(_mousePosition) != SpinArea.None) /* scrolling arrows */
            Cursor = Cursor.Hand;
        else
            Cursor = Cursor.IBeam;

        return _isEditable;
    }

    public override bool OnMouseDrag(Vector2i position, Vector2i relative, int mouseState, KeyModifier modifiers)
    {
        _mousePosition = position;
        _mouseDragPosition = position - AbsolutePosition;

        if (_isEditable && IsFocused)
            return true;

        return false;
    }

    public override bool OnFocus(bool isFocused)
    {
        base.OnFocus(isFocused);

        var backup = _value;
        if (_isEditable)
        {
            if (isFocused)
            {
                _valueTemporary.Clear();
                _valueTemporary.Append(_value);
                _isCommitted = false;
                _cursorPosition = 0;
            }
            else
            {
                if (_isValidFormat)
                {
                    if (_valueTemporary.Length == 0)
                        _value = _defaultValue;
                    else
                        _value = _valueTemporary.ToString();
                }

                if (Changed != null && Changed(this, _value))
                    _value = backup;

                _isValidFormat = true;
                _isCommitted = true;
                _cursorPosition = -1;
                _selectionPosition = -1;
                _textOffset = 0;
            }

            _isValidFormat = _valueTemporary.Length == 0 || CheckFormat(_valueTemporary, _format);
        }

        return true;
    }

    public override bool OnKeyDown(Key key, Scancode scancode, KeyModifier modifiers, bool isRepeat)
    {
        if (modifiers.HasFlag(KeyModifier.Control) || key == Key.Delete || key == Key.Backspace || key == Key.KeypadEnter || key == Key.Return)
            _isControlKeyboardInput = true;
        else
            _isControlKeyboardInput = false;

        if (_isEditable && IsFocused)
        {
            if (key == Key.LeftArrow)
            {
                if (modifiers.HasFlag(KeyModifier.Shift))
                {
                    if (_selectionPosition == -1)
                        _selectionPosition = _cursorPosition;
                }
                else
                {
                    _selectionPosition = -1;
                }

                if (_cursorPosition > 0)
                {
                    if (modifiers.HasFlag(KeyModifier.Control))
                        _cursorPosition = 0;
                    else
                        _cursorPosition--;
                }
            }
            else if (key == Key.RightArrow)
            {
                if (modifiers.HasFlag(KeyModifier.Shift))
                {
                    if (_selectionPosition == -1)
                        _selectionPosition = _cursorPosition;
                }
                else
                {
                    _selectionPosition = -1;
                }

                if (_cursorPosition < _valueTemporary.Length)
                {
                    if (modifiers.HasFlag(KeyModifier.Control))
                        _cursorPosition = _valueTemporary.Length;
                    else
                        _cursorPosition++;
                }
            }
            else if (key == Key.Home)
            {
                if (modifiers.HasFlag(KeyModifier.Shift))
                {
                    if (_selectionPosition == -1)
                        _selectionPosition = _cursorPosition;
                }
                else
                {
                    _selectionPosition = -1;
                }

                _cursorPosition = 0;
            }
            else if (key == Key.End)
            {
                if (modifiers.HasFlag(KeyModifier.Shift))
                {
                    if (_selectionPosition == -1)
                        _selectionPosition = _cursorPosition;
                }
                else
                {
                    _selectionPosition = -1;
                }

                _cursorPosition = _valueTemporary.Length;
            }
            else if (key == Key.Backspace)
            {
                if (!DeleteSelection())
                {
                    if (_cursorPosition > 0)
                    {
                        if (modifiers.HasFlag(KeyModifier.Control))
                        {
                            var index = _valueTemporary.ToString().LastIndexOf(' ', _cursorPosition - 1);
                            if (index == -1)
                                index = 0;

                            _valueTemporary.Remove(index, _cursorPosition - index);
                            _cursorPosition = index;
                        }
                        else
                        {
                            _valueTemporary.Remove(_cursorPosition - 1, 1);
                            _cursorPosition--;
                        }
                    }
                }
            }
            else if (key == Key.Delete)
            {
                if (!DeleteSelection())
                {
                    if (_cursorPosition < _valueTemporary.Length)
                    {
                        if (modifiers.HasFlag(KeyModifier.Control))
                        {
                            var index = _valueTemporary.ToString().IndexOf(' ', _cursorPosition);
                            if (index == -1)
                                index = _valueTemporary.Length;
                            else
                                index++;

                            _valueTemporary.Remove(_cursorPosition, index - _cursorPosition);
                        }
                        else
                        {
                            _valueTemporary.Remove(_cursorPosition, 1);
                        }
                    }
                }
            }
            else if (key == Key.KeypadEnter || key == Key.Return)
            {
                if (!_isCommitted)
                    OnFocus(false);
            }
            else if (key == Key.A && modifiers.HasFlag(KeyModifier.Control))
            {
                _cursorPosition = _valueTemporary.Length;
                _selectionPosition = 0;
            }
            else if (key == Key.X && modifiers.HasFlag(KeyModifier.Control))
            {
                CopySelection();
                DeleteSelection();
            }
            else if (key == Key.C && modifiers.HasFlag(KeyModifier.Control))
            {
                CopySelection();
            }
            else if (key == Key.V && modifiers.HasFlag(KeyModifier.Control))
            {
                DeleteSelection();
                PasteFromClipboard();
            }

            _isValidFormat = _valueTemporary.Length == 0 || CheckFormat(_valueTemporary, _format);
            return true;
        }

        return false;
    }

    public override bool OnTextInput(string input)
    {
        if (string.IsNullOrEmpty(input) || _isControlKeyboardInput)
            return false;

        if (_isEditable && IsFocused)
        {
            DeleteSelection();

            _valueTemporary.Insert(_cursorPosition, input);
            _cursorPosition += input.Length;

            _isValidFormat = _valueTemporary.Length == 0 || CheckFormat(_valueTemporary, _format);
            return true;
        }

        return false;
    }

    protected bool CheckFormat(StringBuilder input, Regex? format)
    {
        if (format == null)
            return true;

        if (input.Length == 0)
            return format.IsMatch(ReadOnlySpan<char>.Empty);

        if (input.Length < 256)
        {
            Span<char> span = stackalloc char[input.Length];
            input.CopyTo(0, span, input.Length);
            return format.IsMatch(span);
        }

        var array = ArrayPool<char>.Shared.Rent(input.Length);
        try
        {
            input.CopyTo(0, array, input.Length);
            return format.IsMatch(array.AsSpan(0, input.Length));
        }
        finally
        {
            ArrayPool<char>.Shared.Return(array);
        }
    }

    protected bool CopySelection()
    {
        if (_selectionPosition > -1)
        {
            var begin = _cursorPosition;
            var end = _selectionPosition;

            if (begin > end)
                Swap(ref begin, ref end);

            Toolkit.Clipboard.SetClipboardText(_valueTemporary.ToString(begin, end - begin));
            return true;
        }

        return false;
    }

    protected void PasteFromClipboard()
    {
        var value = Toolkit.Clipboard.GetClipboardText();
        if (!string.IsNullOrEmpty(value))
            _valueTemporary = _valueTemporary.Insert(_cursorPosition, value);
    }

    protected bool DeleteSelection()
    {
        if (_selectionPosition > -1)
        {
            var begin = _cursorPosition;
            var end = _selectionPosition;

            if (begin > end)
                Swap(ref begin, ref end);

            _valueTemporary = _valueTemporary.Remove(begin, end - begin);

            _cursorPosition = begin;
            _selectionPosition = -1;
            return true;
        }

        return false;
    }

    protected void UpdateCursor(NvgContext context, float lastX, Span<Glyph> glyphs)
    {
        if (_mouseDownPosition.X != -1)
        {
            if (_mouseDownModifier.HasFlag(KeyModifier.Shift))
            {
                if (_selectionPosition == -1)
                    _selectionPosition = _cursorPosition;
            }
            else
            {
                _selectionPosition = -1;
            }

            _cursorPosition = PositionToCursorIndex(_mouseDownPosition.X, lastX, glyphs);
            _mouseDownPosition = new Vector2i(-1, -1);
        }
        else if (_mouseDragPosition.X != -1)
        {
            if (_selectionPosition == -1)
                _selectionPosition = _cursorPosition;

            _cursorPosition = PositionToCursorIndex(_mouseDragPosition.X + _position.X, lastX, glyphs);
        }
        else
        {
            // set cursor to last character
            if (_cursorPosition < 0)
                _cursorPosition = glyphs.Length;
        }

        if (_cursorPosition == _selectionPosition)
            _selectionPosition = -1;
    }

    protected float CursorIndexToPosition(int index, float lastX, Span<Glyph> glyphs)
    {
        if (index == glyphs.Length)
            return lastX; // last character

        return glyphs[index].Bounds.X;
    }

    protected int PositionToCursorIndex(float posX, float lastX, Span<Glyph> glyphs)
    {
        var cursorId = 0;
        if (glyphs.IsEmpty)
            return cursorId;

        var caretX = glyphs[cursorId].Bounds.X;
        for (var j = 1; j < glyphs.Length; j++)
        {
            if (Math.Abs(caretX - posX) > Math.Abs(glyphs[j].Bounds.X - posX))
            {
                cursorId = j;
                caretX = glyphs[cursorId].Bounds.X;
            }
        }

        if (Math.Abs(caretX - posX) > Math.Abs(lastX - posX))
            cursorId = glyphs.Length;

        return cursorId;
    }

    protected SpinArea GetSpinArea(Vector2i position)
    {
        /* on scrolling arrows */
        if (0 <= position.X - _position.X && position.X - _position.X < 14.0f)
        {
            /* top part */
            if (_size.Y >= position.Y - _position.Y && position.Y - _position.Y <= _size.Y / 2.0f)
                return SpinArea.Top;

            /* bottom part */
            if (0.0f <= position.Y - _position.Y && position.Y - _position.Y > _size.Y / 2.0f)
                return SpinArea.Bottom;
        }

        return SpinArea.None;
    }

    protected void RaiseChanged(string value)
    {
        Changed?.Invoke(this, value);
    }

    private static void Swap<T>(ref T a, ref T b)
    {
        var temp = a;
        a = b;
        b = temp;
    }
}