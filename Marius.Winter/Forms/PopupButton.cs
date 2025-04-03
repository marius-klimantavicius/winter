using NvgSharp;
using OpenTK.Mathematics;

namespace Marius.Winter.Forms;

public class PopupButton : Button
{
    protected Popup _popup;
    protected FontIcon? _chevronIcon;

    public FontIcon? ChevronIcon
    {
        get => _chevronIcon;
        set => _chevronIcon = value;
    }

    public PopupSide Side
    {
        get => _popup.Side;
        set
        {
            if (_popup.Side == PopupSide.Right && _chevronIcon == _theme.PopupChevronRightIcon)
                _chevronIcon = _theme.PopupChevronLeftIcon;
            else if (_popup.Side == PopupSide.Left && _chevronIcon == _theme.PopupChevronLeftIcon)
                _chevronIcon = _theme.PopupChevronRightIcon;
            _popup.Side = value;
        }
    }

    public Popup Popup => _popup;

    public PopupButton(Widget? parent, string caption = "Untitled", FontIcon? buttonIcon = null)
        : base(parent, caption, buttonIcon)
    {
        _chevronIcon = _theme.PopupChevronRightIcon;
        Flags = ButtonFlags.ToggleButton | ButtonFlags.PopupButton;

        _popup = new Popup(Screen, Window)
        {
            Size = new Vector2i(320, 250),
            IsVisible = false,
        };

        _iconExtraScale = 0.8f;
    }

    public override Vector2i GetPreferredSize(NvgContext context)
    {
        return base.GetPreferredSize(context) + new Vector2i(15, 0);
    }

    public override void PerformLayout(NvgContext ctx)
    {
        base.PerformLayout(ctx);

        var parentWindow = Window;
        var anchorSize = _popup.AnchorSize;
        if (parentWindow != null)
        {
            var posY = AbsolutePosition.Y - parentWindow.Position.Y + _size.Y / 2;
            if (_popup.Side == PopupSide.Right)
                _popup.AnchorPosition = new Vector2i(parentWindow.Width + anchorSize, posY);
            else
                _popup.AnchorPosition = new Vector2i(-anchorSize, posY);
        }
        else
        {
            _popup.Position = AbsolutePosition + new Vector2i(Width + anchorSize + 1, _size.Y / 2 - anchorSize);
        }
    }

    public override void Draw(NvgContext ctx)
    {
        if (!_isEnabled && _isPressed)
            _isPressed = false;

        _popup.IsVisible = _isPressed;
        base.Draw(ctx);

        if (_chevronIcon != null)
        {
            var icon = _chevronIcon.IconText;
            var textColor = _textColor.A == 0 ? _theme.TextColor : _textColor;

            var iconFont = _theme.FontIcons.GetFont((_fontSize < 0 ? _theme.ButtonFontSize : _fontSize) * IconScale);

            ctx.FillColor(_isEnabled ? textColor : _theme.DisabledTextColor);

            var iw = iconFont.MeasureString(icon).X;
            var iconPos = new Vector2(0, _position.Y + _size.Y / 2.0f - 1);

            if (_popup.Side == PopupSide.Right)
                iconPos.X = _position.X + _size.X - iw - 8;
            else
                iconPos.X = _position.X + 8;

            ctx.TextAligned(iconFont, icon, iconPos.X, iconPos.Y, TextHorizontalAlignment.Left, TextVerticalAlignment.Center);
        }
    }
}