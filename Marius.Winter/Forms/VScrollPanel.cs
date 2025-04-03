using System;
using System.Drawing;
using NvgSharp;
using OpenTK.Mathematics;
using OpenTK.Platform;

namespace Marius.Winter.Forms;

public class VScrollPanel : Widget
{
    protected int _childPrefferedHeight;
    protected float _scroll;
    protected bool _updateLayout;

    public float Scroll
    {
        get => _scroll;
        set => _scroll = value;
    }

    public VScrollPanel(Widget? parent)
        : base(parent)
    {
        _childPrefferedHeight = 0;
        _scroll = 0;
        _updateLayout = false;
    }

    public override void PerformLayout(NvgContext context)
    {
        base.PerformLayout(context);

        if (_children.Count == 0)
            return;

        if (_children.Count > 1)
            throw new Exception("VScrollPanel should have one child.");

        var child = _children[0];
        _childPrefferedHeight = child.GetPreferredSize(context).Y;

        if (_childPrefferedHeight > _size.Y)
        {
            child.Position = new Vector2i(0, (int)(-_scroll * (_childPrefferedHeight - _size.Y)));
            child.Size = new Vector2i(_size.X - 12, _childPrefferedHeight);
        }
        else
        {
            child.Position = Vector2i.Zero;
            child.Size = _size;
            _scroll = 0;
        }

        child.PerformLayout(context);
    }

    public override Vector2i GetPreferredSize(NvgContext context)
    {
        if (_children.Count == 0)
            return Vector2i.Zero;

        return _children[0].GetPreferredSize(context) + new Vector2i(12, 0);
    }

    public override bool OnMouseDrag(Vector2i position, Vector2i relative, int mouseState, KeyModifier modifiers)
    {
        if (_children.Count != 0 && _childPrefferedHeight > _size.Y)
        {
            var scrollh = Height * Math.Min(1.0f, Height / (float)_childPrefferedHeight);

            _scroll = Math.Max(0.0f, Math.Min(1.0f, _scroll + relative.Y / (_size.Y - 8.0f - scrollh)));
            _updateLayout = true;
            return true;
        }

        return base.OnMouseDrag(position, relative, mouseState, modifiers);
    }

    public override bool OnMouseDown(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        if (base.OnMouseDown(position, button, modifiers))
            return true;

        if (button == MouseButton.Button1 && _children.Count > 0 && _childPrefferedHeight > _size.Y &&
            position.X > _position.X + _size.X - 13 &&
            position.X < _position.X + _size.X - 4)
        {
            var scrollh = (int)(Height * Math.Min(1.0f, Height / (float)_childPrefferedHeight));
            var start = (int)(_position.Y + 4 + 1 + (_size.Y - 8 - scrollh) * _scroll);

            var delta = 0.0f;

            if (position.Y < start)
                delta = -_size.Y / (float)_childPrefferedHeight;
            else if (position.Y > start + scrollh)
                delta = _size.Y / (float)_childPrefferedHeight;

            _scroll = Math.Max(0.0f, Math.Min(1.0f, _scroll + delta * 0.98f));

            _children[0].Position = new Vector2i(0, (int)(-_scroll * (_childPrefferedHeight - _size.Y)));
            _updateLayout = true;
            return true;
        }

        return false;
    }

    public override bool OnScroll(Vector2i position, Vector2 distance, Vector2 relative)
    {
        if (_children.Count != 0 && _childPrefferedHeight > _size.Y)
        {
            var child = _children[0];
            var scrollAmount = relative.Y * _size.Y * .25f;

            _scroll = Math.Max(0.0f, Math.Min(1.0f, _scroll - scrollAmount / _childPrefferedHeight));

            var oldPosition = child.Position;
            child.Position = new Vector2i(0, (int)(-_scroll * (_childPrefferedHeight - _size.Y)));

            var newPosition = child.Position;
            _updateLayout = true;

            child.OnMouseMove(position - _position, oldPosition - newPosition, 0, 0);
            return true;
        }

        return base.OnScroll(position, distance, relative);
    }

    public override void Draw(NvgContext context)
    {
        base.Draw(context);

        if (_children.Count == 0)
            return;

        var child = _children[0];
        var yoffset = 0;
        if (_childPrefferedHeight > _size.Y)
            yoffset = (int)(-_scroll * (_childPrefferedHeight - _size.Y));
        child.Position = new Vector2i(0, yoffset);

        _childPrefferedHeight = child.GetPreferredSize(context).Y;

        var scrollh = Height * Math.Min(1.0f, Height / (float)_childPrefferedHeight);
        if (_updateLayout)
        {
            _updateLayout = false;
            child.PerformLayout(context);
        }

        context.SaveState();
        context.Translate(_position.X, _position.Y);
        context.IntersectScissor(0, 0, _size.X, _size.Y);
        if (child.IsVisible)
            child.Draw(context);
        context.RestoreState();

        if (_childPrefferedHeight <= _size.Y)
            return;

        var paint = context.BoxGradient(
            _position.X + _size.X - 12 + 1, _position.Y + 4 + 1, 8,
            _size.Y - 8, 3, 4, Color.FromArgb(32, 0, 0, 0), Color.FromArgb(92, 0, 0, 0));
        context.BeginPath();
        context.RoundedRect(_position.X + _size.X - 12, _position.Y + 4, 8, _size.Y - 8, 3);
        context.FillPaint(paint);
        context.Fill();

        paint = context.BoxGradient(
            _position.X + _size.X - 12 - 1,
            _position.Y + 4 + (_size.Y - 8 - scrollh) * _scroll - 1, 8, scrollh,
            3, 4, Color.FromArgb(100, 220, 220, 220), Color.FromArgb(100, 128, 128, 128));

        context.BeginPath();
        context.RoundedRect(_position.X + _size.X - 12 + 1, _position.Y + 4 + 1 + (_size.Y - 8 - scrollh) * _scroll, 8 - 2, scrollh - 2, 2);
        context.FillPaint(paint);
        context.Fill();
    }
}