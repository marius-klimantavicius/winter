using System;
using System.Collections.Generic;
using System.Drawing;
using FontStashSharp;
using NvgSharp;
using OpenTK.Mathematics;
using OpenTK.Platform;

namespace Marius.Winter.Forms;

public class Button : Widget
{
    protected string _caption;
    protected Icon? _icon;
    protected IconPosition _iconPosition;
    protected bool _isPressed;
    protected ButtonFlags _flags;
    protected Color _backgroundColor;
    protected Color _textColor;
    protected List<Button> _buttonGroup = new List<Button>();

    public string Caption
    {
        get => _caption;
        set => _caption = value;
    }

    public Color BackgroundColor
    {
        get => _backgroundColor;
        set => _backgroundColor = value;
    }

    public Color TextColor
    {
        get => _textColor;
        set => _textColor = value;
    }

    public Icon? Icon
    {
        get => _icon;
        set => _icon = value;
    }

    public ButtonFlags Flags
    {
        get => _flags;
        set => _flags = value;
    }

    public IconPosition IconPosition
    {
        get => _iconPosition;
        set => _iconPosition = value;
    }

    public bool Pressed
    {
        get => _isPressed;
        set => _isPressed = value;
    }

    public List<Button> ButtonGroup
    {
        get => _buttonGroup;
        set => _buttonGroup = value;
    }

    public event Action<Button>? Clicked;
    public event Action<Button, bool>? Toggled;

    public Button(Widget? parent, string caption = "", Icon? icon = null) : base(parent)
    {
        _caption = caption;
        _icon = icon;
        _iconPosition = IconPosition.LeftCentered;
        _isPressed = false;
        _flags = ButtonFlags.NormalButton;
        _backgroundColor = Color.FromArgb(0, 0, 0, 0);
        _textColor = Color.FromArgb(0, 0, 0, 0);
    }

    public override Vector2i GetPreferredSize(NvgContext context)
    {
        var fontSize = _fontSize == -1 ? _theme!.ButtonFontSize : _fontSize;
        var font = _theme!.FontSansBold.GetFont(fontSize);
        var tw = font.MeasureString(_caption).X;
        var iw = 0f;
        var ih = (float)fontSize;

        if (_icon != null)
        {
            if (_icon is FontIcon fontIcon)
            {
                ih *= IconScale;
                var iconFont = fontIcon.IconFont.GetFont(ih);
                iw = iconFont.MeasureString(fontIcon.IconText).X;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        return new Vector2i((int)(tw + iw) + 20, fontSize + 10);
    }

    public override bool OnMouseEnter(Vector2i position, bool isMouseOver)
    {
        base.OnMouseEnter(position, isMouseOver);
        return true;
    }

    public override bool OnMouseDown(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        base.OnMouseDown(position, button, modifiers);
        if (_isEnabled &&
            ((button == MouseButton.Button1 && (_flags & ButtonFlags.MenuButton) == 0) ||
                (button == MouseButton.Button2 && (_flags & ButtonFlags.MenuButton) != 0)))
        {
            var previousIsPressed = _isPressed;
            if (true)
            {
                if ((_flags & ButtonFlags.RadioButton) != 0)
                {
                    if (_buttonGroup.Count == 0 && Parent != null)
                    {
                        foreach (var widget in Parent.Children)
                        {
                            var b = widget as Button;
                            if (b != this && b != null && (b.Flags & ButtonFlags.RadioButton) != 0 && b._isPressed)
                            {
                                b._isPressed = false;
                                b.Toggled?.Invoke(b, false);
                            }
                        }
                    }
                    else
                    {
                        foreach (var b in _buttonGroup)
                        {
                            if (b != this && (b.Flags & ButtonFlags.RadioButton) != 0 && b._isPressed)
                            {
                                b._isPressed = false;
                                b.Toggled?.Invoke(b, false);
                            }
                        }
                    }
                }

                if ((_flags & ButtonFlags.PopupButton) != 0 && Parent != null)
                {
                    foreach (var widget in Parent.Children)
                    {
                        var b = widget as Button;
                        if (b != this && b != null && (b.Flags & ButtonFlags.PopupButton) != 0 && b._isPressed)
                        {
                            b._isPressed = false;
                            b.Toggled?.Invoke(b, false);
                        }
                    }
                    // TODO: implement
                    // if (this is PopupButton pb)
                    //     pb.Popup.RequestFocus();
                }

                if ((_flags & ButtonFlags.ToggleButton) != 0)
                    _isPressed = !_isPressed;
                else
                    _isPressed = true;
            }

            if (previousIsPressed != _isPressed && Toggled != null)
                Toggled?.Invoke(this, _isPressed);

            return true;
        }

        return false;
    }

    public override bool OnMouseUp(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        base.OnMouseUp(position, button, modifiers);
        if (_isEnabled &&
            ((button == MouseButton.Button1 && (_flags & ButtonFlags.MenuButton) == 0) ||
                (button == MouseButton.Button2 && (_flags & ButtonFlags.MenuButton) != 0)))
        {
            var previousIsPressed = _isPressed;
            if (_isPressed || (_flags & ButtonFlags.MenuButton) != 0)
            {
                if (Contains(position))
                    Clicked?.Invoke(this);

                if ((_flags & ButtonFlags.NormalButton) != 0)
                    _isPressed = false;
            }

            if (previousIsPressed != _isPressed && Toggled != null)
                Toggled?.Invoke(this, _isPressed);

            return true;
        }

        return false;
    }

    public override void Draw(NvgContext context)
    {
        var gradTop = _theme!.ButtonGradientTopUnfocused;
        var gradBot = _theme!.ButtonGradientBotUnfocused;

        if (_isPressed || (_isMouseOver && (_flags & ButtonFlags.MenuButton) != 0))
        {
            gradTop = _theme.ButtonGradientTopPushed;
            gradBot = _theme.ButtonGradientBotPushed;
        }
        else if (_isMouseOver && _isEnabled)
        {
            gradTop = _theme.ButtonGradientTopFocused;
            gradBot = _theme.ButtonGradientBotFocused;
        }

        context.BeginPath();

        context.RoundedRect(_position.X + 1, _position.Y + 1.0f, _size.X - 2, _size.Y - 2, _theme.ButtonCornerRadius - 1);

        if (_backgroundColor.A != 0)
        {
            context.FillColor(Color.FromArgb(255, _backgroundColor.R, _backgroundColor.G, _backgroundColor.B));
            context.Fill();

            if (_isPressed)
            {
                gradTop = Color.FromArgb(204, gradTop);
                gradBot = Color.FromArgb(204, gradBot);
            }
            else
            {
                var v = 255 - _backgroundColor.A;
                gradTop = Color.FromArgb(_isEnabled ? v : v / 2 + 128, gradTop);
                gradBot = Color.FromArgb(_isEnabled ? v : v / 2 + 128, gradBot);
            }
        }

        var bg = context.LinearGradient(_position.Y, _position.Y, _position.X, _position.Y + _size.Y, gradTop, gradBot);

        context.FillPaint(bg);
        context.Fill();

        context.BeginPath();
        context.StrokeWidth(1.0f);
        context.RoundedRect(_position.X + 0.5f, _position.Y + (_isPressed ? 0.5f : 1.5f), _size.X - 1, _size.Y - 1 - (_isPressed ? 0.0f : 1.0f), _theme.ButtonCornerRadius);
        context.StrokeColor(_theme.BorderLight);
        context.Stroke();

        context.BeginPath();
        context.RoundedRect(_position.X + 0.5f, _position.Y + 0.5f, _size.X - 1, _size.Y - 2, _theme.ButtonCornerRadius);
        context.StrokeColor(_theme.BorderDark);
        context.Stroke();

        var fontSize = _fontSize == -1 ? _theme.ButtonFontSize : _fontSize;
        var font = _theme.FontSansBold.GetFont(fontSize);
        var tw = font.MeasureString(_caption).X;

        var center = _position.ToVector2() + _size.ToVector2() / 2;
        var textPosition = new Vector2(center.X - tw / 2, center.Y - 1);
        var textColor = _textColor.A == 0 ? _theme.TextColor : _textColor;
        if (!_isEnabled)
            textColor = _theme.DisabledTextColor;

        if (_icon != null)
        {
            float iw, ih = fontSize;
            var iconFont = default(SpriteFontBase);
            var iconText = default(string);
            if (_icon is FontIcon fontIcon)
            {
                ih *= IconScale;
                iconFont = fontIcon.IconFont.GetFont(ih);
                iconText = fontIcon.IconText;
                iw = iconFont.MeasureString(iconText).X;
            }
            else
            {
                throw new NotImplementedException();
            }

            if (!string.IsNullOrEmpty(_caption))
                iw += _size.Y * 0.15f;

            context.FillColor(textColor);

            var iconPosition = center;
            iconPosition.Y -= 1;

            switch (_iconPosition)
            {
                case IconPosition.LeftCentered:
                    iconPosition.X -= (tw + iw) * 0.5f;
                    textPosition.X += iw * 0.5f;
                    break;
                case IconPosition.RightCentered:
                    textPosition.X -= iw * 0.5f;
                    iconPosition.X += tw * 0.5f;
                    break;
                case IconPosition.Left:
                    iconPosition.X = _position.X + 8;
                    break;
                case IconPosition.Right:
                    iconPosition.X = _position.X + _size.X - iw - 8;
                    break;
            }

            if (fontIcon != null)
            {
                context.TextAligned(iconFont, iconText, iconPosition.X, iconPosition.Y + 1, TextHorizontalAlignment.Left, TextVerticalAlignment.Center);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        context.FillColor(_theme.TextColorShadow);
        context.TextAligned(font, _caption, textPosition.X, textPosition.Y, TextHorizontalAlignment.Left, TextVerticalAlignment.Center);

        context.FillColor(textColor);
        context.TextAligned(font, _caption, textPosition.X, textPosition.Y + 1, TextHorizontalAlignment.Left, TextVerticalAlignment.Center);

        base.Draw(context);
    }
}