using NvgSharp;
using OpenTK.Mathematics;

namespace Marius.Winter.Forms;

public class Popup : Window
{
    protected Window? _parentWindow;
    protected Vector2i _anchorPosition;
    protected int _anchorOffset;
    protected int _anchorSize;
    protected PopupSide _side;

    public Window? ParentWindow
    {
        get => _parentWindow;
        set => _parentWindow = value;
    }

    public Vector2i AnchorPosition
    {
        get => _anchorPosition;
        set => _anchorPosition = value;
    }

    public int AnchorOffset
    {
        get => _anchorOffset;
        set => _anchorOffset = value;
    }

    public int AnchorSize
    {
        get => _anchorSize;
        set => _anchorSize = value;
    }

    public PopupSide Side
    {
        get => _side;
        set => _side = value;
    }

    public Popup(Widget? parent, Window? parentWindow) : base(parent, "")
    {
        _parentWindow = parentWindow;
        _anchorPosition = Vector2i.Zero;
        _anchorOffset = 30;
        _anchorSize = 15;
        _side = PopupSide.Right;
    }

    public override void PerformLayout(NvgContext context)
    {
        if (_layout != null || _children.Count != 1)
        {
            base.PerformLayout(context);
        }
        else
        {
            _children[0].Position = new Vector2i(0);
            _children[0].Size = _size;
            _children[0].PerformLayout(context);
        }

        if (_side == PopupSide.Left)
            _anchorPosition.X -= Size.X;
    }

    public override void Draw(NvgContext context)
    {
        RefreshRelativePlacement();

        if (!_isVisible)
            return;

        var ds = _theme.WindowDropShadowSize;
        var cr = _theme.WindowCornerRadius;

        context.SaveState();
        context.ResetScissor();

        /* Draw a drop shadow */
        var shadowPaint = context.BoxGradient(
            _position.X, _position.Y, _size.X, _size.Y, cr * 2, ds * 2,
            _theme.DropShadow, _theme.Transparent);

        context.BeginPath();
        context.Rect(_position.X - ds, _position.Y - ds, _size.X + 2 * ds, _size.Y + 2 * ds);
        context.RoundedRect(_position.X, _position.Y, _size.X, _size.Y, cr);
        context.PathWinding(Solidity.Hole);
        context.FillPaint(shadowPaint);
        context.Fill();

        /* Draw window */
        context.BeginPath();
        context.RoundedRect(_position.X, _position.Y, _size.X, _size.Y, cr);

        var basis = _position + new Vector2i(0, _anchorOffset);
        var sign = -1;
        if (_side == PopupSide.Left)
        {
            basis.X += _size.X;
            sign = 1;
        }

        context.MoveTo(basis.X + _anchorSize * sign, basis.Y);
        context.LineTo(basis.X - 1 * sign, basis.Y - _anchorSize);
        context.LineTo(basis.X - 1 * sign, basis.Y + _anchorSize);

        context.FillColor(_theme.WindowPopup);
        context.Fill();
        context.RestoreState();

        base.Draw(context);
    }

    protected internal override void RefreshRelativePlacement()
    {
        if (_parentWindow == null)
            return;

        _parentWindow.RefreshRelativePlacement();
        _isVisible &= _parentWindow.IsVisibleRecursive;
        _position = _parentWindow.Position + _anchorPosition - new Vector2i(0, _anchorOffset);
    }
}