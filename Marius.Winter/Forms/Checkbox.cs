using System;
using System.Drawing;
using NvgSharp;
using OpenTK.Mathematics;
using OpenTK.Platform;

namespace Marius.Winter.Forms;

public class Checkbox : Widget
{
    protected string _caption;
    protected bool _isPressed;
    protected bool _isChecked;

    public event Action<Checkbox, bool>? CheckedChanged;

    public string Caption
    {
        get => _caption;
        set => _caption = value;
    }

    public bool IsPushed
    {
        get => _isPressed;
        set => _isPressed = value;
    }

    public bool IsChecked
    {
        get => _isChecked;
        set => _isChecked = value;
    }

    public Checkbox(Widget? parent, string caption, Action<Checkbox, bool>? onCheckedChanged = null) : base(parent)
    {
        _caption = caption;
        if (onCheckedChanged != null)
            CheckedChanged += onCheckedChanged;

        IconExtraScale = 1.2f;
    }

    public override bool OnMouseEnter(Vector2i position, bool isMouseOver)
    {
        base.OnMouseEnter(position, isMouseOver);
        return true;
    }

    public override bool OnMouseDown(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        base.OnMouseDown(position, button, modifiers);
        if (!IsEnabled)
            return false;

        if (button == MouseButton.Button1)
        {
            _isPressed = true;
            return true;
        }

        return false;
    }

    public override bool OnMouseUp(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        base.OnMouseUp(position, button, modifiers);
        if (!IsEnabled)
            return false;

        if (button == MouseButton.Button1)
        {
            if (_isPressed)
            {
                if (Contains(position))
                {
                    _isChecked = !_isChecked;
                    CheckedChanged?.Invoke(this, _isChecked);
                }

                _isPressed = false;
            }

            return true;
        }

        return false;
    }

    public override Vector2i GetPreferredSize(NvgContext context)
    {
        if (_fixedSize != Vector2i.Zero)
            return _fixedSize;

        var font = _theme!.FontSansRegular.GetFont(FontSize);
        var bounds = font.MeasureString(_caption);
        return new Vector2i((int)(bounds.X + 1.8f * FontSize), (int)(FontSize * 1.3f));
    }

    public override void Draw(NvgContext context)
    {
        base.Draw(context);

        var font = _theme!.FontSansRegular.GetFont(FontSize);
        context.FillColor(IsEnabled ? _theme!.TextColor : _theme!.DisabledTextColor);
        context.TextAligned(font, _caption, _position.X + 1.6f * FontSize, _position.Y + _size.Y * 0.5f, TextHorizontalAlignment.Left, TextVerticalAlignment.Center);

        var gradTop = Color.FromArgb(32, 0, 0, 0);
        var gradBot = Color.FromArgb(180, 0, 0, 0);
        if (_isPressed)
            gradTop = Color.FromArgb(100, 0, 0, 0);
        else if (_isEnabled && _isMouseOver)
            gradTop = Color.FromArgb(66, 0, 0, 0);

        var bg = context.BoxGradient(_position.X + 1.5f, _position.Y + 1.5f, _size.Y - 2.0f, _size.Y - 2.0f, 3, 3, gradTop, gradBot);

        context.BeginPath();
        context.RoundedRect(_position.X + 1.0f, _position.Y + 1.0f, _size.Y - 2.0f, _size.Y - 2.0f, 3);
        context.FillPaint(bg);
        context.Fill();

        if (_isChecked)
        {
            var fontSize = IconScale * _size.Y;
            var icon = _theme.CheckBoxIcon;
            var iconFont = icon.IconFont.GetFont(fontSize);
            context.FillColor(IsEnabled ? _theme.IconColor : _theme.DisabledTextColor);
            context.TextAligned(iconFont, icon.IconText, _position.X + _size.Y * 0.5f + 1, _position.Y + _size.Y * 0.5f, TextHorizontalAlignment.Center, TextVerticalAlignment.Center);
        }
    }
}