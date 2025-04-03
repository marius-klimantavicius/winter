using System;
using FontStashSharp;
using NvgSharp;
using OpenTK.Mathematics;
using OpenTK.Platform;
using Vector2 = System.Numerics.Vector2;

namespace Marius.Winter.Forms;

public class Window : Widget
{
    protected string _title;
    protected Widget? _buttonPanel;
    protected bool _isModal;
    protected bool _isDragging;

    public string Title
    {
        get => _title;
        set => _title = value;
    }

    public bool IsModal
    {
        get => _isModal;
        set => _isModal = value;
    }

    public Widget ButtonPanel => _buttonPanel ??= new Widget(this)
    {
        Layout = new BoxLayout(Orientation.Horizontal, Alignment.Middle, 0, 4),
    };

    public Window(Widget? parent, string title = "Untitled") : base(parent)
    {
        _title = title;
        _buttonPanel = null;
        _isModal = false;
        _isDragging = false;
    }

    public override Vector2i GetPreferredSize(NvgContext context)
    {
        if (_buttonPanel != null)
            _buttonPanel.IsVisible = false;

        var result = base.GetPreferredSize(context);
        if (_buttonPanel != null)
            _buttonPanel.IsVisible = true;

        var font = _theme!.FontSansBold.GetFont(18);
        var bounds = font.TextBounds(_title, new Vector2(0, 0));
        return new Vector2i(Math.Max(result.X, (int)(bounds.X2 - bounds.X) + 20), Math.Max(result.Y, (int)(bounds.Y2 - bounds.Y)));
    }

    public override void PerformLayout(NvgContext context)
    {
        if (_buttonPanel == null)
        {
            base.PerformLayout(context);
            return;
        }

        _buttonPanel.IsVisible = false;
        base.PerformLayout(context);

        foreach (var item in _buttonPanel.Children)
        {
            item.FixedSize = new Vector2i(22, 22);
            item.FontSize = 15;
        }

        _buttonPanel.IsVisible = true;
        _buttonPanel.Size = new Vector2i(Width, 22);

        var preferredWidth = _buttonPanel.GetPreferredSize(context).X;
        if (preferredWidth < Width)
            _buttonPanel.Size = new Vector2i(preferredWidth, 22);

        _buttonPanel.Position = new Vector2i(Width - (preferredWidth + 5), 3);
        _buttonPanel.PerformLayout(context);
    }

    public override void Draw(NvgContext context)
    {
        var ds = _theme.WindowDropShadowSize;
        var cr = _theme.WindowCornerRadius;
        var hh = _theme.WindowHeaderHeight;

        /* Draw window */
        context.SaveState();
        context.BeginPath();
        context.RoundedRect(_position.X, _position.Y, _size.X, _size.Y, cr);

        context.FillColor(_isMouseOver
            ? _theme.WindowFillFocused
            : _theme.WindowFillUnfocused);
        context.Fill();

        /* Draw a drop shadow */
        var shadowPaint = context.BoxGradient(
            _position.X, _position.Y, _size.X, _size.Y, cr * 2, ds * 2,
            _theme.DropShadow, _theme.Transparent);

        context.SaveState();
        context.ResetScissor();
        context.BeginPath();
        context.Rect(_position.X - ds, _position.Y - ds, _size.X + 2 * ds, _size.Y + 2 * ds);
        context.RoundedRect(_position.X, _position.Y, _size.X, _size.Y, cr);
        context.PathWinding(Solidity.Hole);
        context.FillPaint(shadowPaint);
        context.Fill();
        context.RestoreState();

        if (!string.IsNullOrEmpty(_title))
        {
            /* Draw header */
            var headerPaint = context.LinearGradient(
                _position.X, _position.Y, _position.X,
                _position.Y + hh,
                _theme.WindowHeaderGradientTop,
                _theme.WindowHeaderGradientBot);

            context.BeginPath();
            context.RoundedRect(_position.X, _position.Y, _size.X, hh, cr);

            context.FillPaint(headerPaint);
            context.Fill();

            context.BeginPath();
            context.RoundedRect(_position.X, _position.Y, _size.X, hh, cr);
            context.StrokeColor(_theme.WindowHeaderSepTop);

            context.SaveState();
            context.IntersectScissor(_position.X, _position.Y, _size.X, 0.5f);
            context.Stroke();
            context.RestoreState();

            context.BeginPath();
            context.MoveTo(_position.X + 0.5f, _position.Y + hh - 1.5f);
            context.LineTo(_position.X + _size.X - 0.5f, _position.Y + hh - 1.5f);
            context.StrokeColor(_theme.WindowHeaderSepBot);
            context.Stroke();

            var font = _theme.FontSansBold.GetFont(18);
            context.FillColor(_theme.DropShadow);
            context.TextAligned(font, _title, _position.X + _size.X / 2f, _position.Y + hh / 2f, TextHorizontalAlignment.Center, TextVerticalAlignment.Center, effect: FontSystemEffect.Blurry, effectAmount: 2);

            context.FillColor(_isFocused
                ? _theme.WindowTitleFocused
                : _theme.WindowTitleUnfocused);
            context.TextAligned(font, _title, _position.X + _size.X / 2f, _position.Y + hh / 2f - 1, TextHorizontalAlignment.Center, TextVerticalAlignment.Center);
        }

        context.RestoreState();
        base.Draw(context);
    }

    public void Dispose()
    {
        var widget = (Widget)this;
        while (widget.Parent != null)
            widget = widget.Parent;

        if (widget is Screen s)
            s.DisposeWindow(this);
    }

    public void Center()
    {
        var widget = (Widget)this;
        while (widget.Parent != null)
            widget = widget.Parent;

        if (widget is Screen s)
            s.CenterWindow(this);
    }

    public override bool OnMouseEnter(Vector2i position, bool isMouseOver)
    {
        base.OnMouseEnter(position, isMouseOver);
        return true;
    }

    public override bool OnMouseDrag(Vector2i position, Vector2i relative, int button, KeyModifier modifiers)
    {
        if (_isDragging && (button & (1 << (int)MouseButton.Button1)) != 0)
        {
            _position += relative;
            _position = Vector2i.ComponentMax(_position, Vector2i.Zero);
            if (Parent != null)
                _position = Vector2i.ComponentMin(_position, Parent.Size - _size);

            return true;
        }

        return false;
    }

    public override bool OnMouseDown(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        if (base.OnMouseDown(position, button, modifiers))
            return true;

        if (button == MouseButton.Button1)
        {
            _isDragging = position.Y - _position.Y < _theme.WindowHeaderHeight;
            return true;
        }

        return false;
    }

    public override bool OnMouseUp(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        if (base.OnMouseUp(position, button, modifiers))
            return true;

        if (button == MouseButton.Button1)
        {
            _isDragging = false;
            return true;
        }

        return false;
    }

    public override bool OnScroll(Vector2i position, OpenTK.Mathematics.Vector2 distance, OpenTK.Mathematics.Vector2 relative)
    {
        base.OnScroll(position, distance, relative);
        return true;
    }

    protected internal virtual void RefreshRelativePlacement()
    {
    }
}