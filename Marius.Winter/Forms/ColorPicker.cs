using System;
using System.Drawing;
using OpenTK.Mathematics;

namespace Marius.Winter.Forms;

public class ColorPicker : PopupButton
{
    protected ColorWheel _colorWheel;
    protected Button _pickButton;
    protected Button _resetButton;

    public event Action<ColorPicker, Color>? Changing;
    public event Action<ColorPicker, Color>? Changed;

    public string PickButtonCaption
    {
        get => _pickButton.Caption;
        set => _pickButton.Caption = value;
    }

    public string ResetButtonCaption
    {
        get => _resetButton.Caption;
        set => _resetButton.Caption = value;
    }

    public Color Color
    {
        get => BackgroundColor;
        set
        {
            if (!_isPressed)
            {
                Color fg = value.ContrastingColor();
                BackgroundColor = value;
                TextColor = fg;
                _colorWheel.Color = value;

                _pickButton.BackgroundColor = value;
                _pickButton.TextColor = fg;

                _resetButton.BackgroundColor = value;
                _resetButton.TextColor = fg;

            }
        }
    }

    public ColorPicker(Widget? parent, Color? color = null, string caption = "", FontIcon? buttonIcon = null)
        : base(parent, caption, buttonIcon)
    {
        BackgroundColor = color.GetValueOrDefault(Color.Red);

        var popup = Popup;
        popup.Layout = new GroupLayout();

        _colorWheel = new ColorWheel(popup, color);

        _pickButton = new Button(popup, "Pick")
        {
            BackgroundColor = color.GetValueOrDefault(Color.Red),
            TextColor = color.GetValueOrDefault(Color.Red).ContrastingColor(),
            FixedSize = new Vector2i(100, 20),
        };

        _resetButton = new Button(popup, "Reset")
        {
            BackgroundColor = color.GetValueOrDefault(Color.Red),
            TextColor = color.GetValueOrDefault(Color.Red).ContrastingColor(),
            FixedSize = new Vector2i(100, 20),
        };

        Toggled += (_, _) =>
        {
            if (_pickButton.IsPressed)
            {
                Color = BackgroundColor;
                Changed?.Invoke(this, BackgroundColor);
            }
        };

        _colorWheel.Changed += (_, value) =>
        {
            _pickButton.BackgroundColor = value;
            _pickButton.TextColor = value.ContrastingColor();
            Changing?.Invoke(this, value);
        };

        _pickButton.Clicked += _ =>
        {
            if (_isPressed)
            {
                var value = _colorWheel.Color;
                IsPressed = false;
                Color = value;
                Changed?.Invoke(this, value);
            }
        };

        _resetButton.Clicked += _ =>
        {
            var bg = _resetButton.BackgroundColor;
            var fg = _resetButton.TextColor;

            _colorWheel.Color = bg;
            _pickButton.BackgroundColor = bg;
            _pickButton.TextColor = fg;

            Changing?.Invoke(this, bg);
            Changed?.Invoke(this, bg);
        };
    }
}

internal static class ColorExtensions
{
    public static Color ContrastingColor(this Color color)
    {
        var luminance = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255f;
        return luminance > 0.5 ? Color.Black : Color.White;
    }
}