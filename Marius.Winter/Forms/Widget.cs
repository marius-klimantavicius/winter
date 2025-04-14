using System.Collections.Generic;
using System.Diagnostics;
using FontStashSharp.RichText;
using NvgSharp;
using OpenTK.Mathematics;
using OpenTK.Platform;

namespace Marius.Winter.Forms;

public class Widget
{
    protected readonly List<Widget> _children = new List<Widget>();

    protected Widget? _parent;
    protected Theme _theme;
    protected Layout? _layout;
    protected Vector2i _position;
    protected Vector2i _size;
    protected Vector2i _fixedSize;

    protected bool _isVisible;

    protected bool _isEnabled;
    protected bool _isFocused;
    protected bool _isMouseOver;
    protected RichTextLayout? _tooltip;
    protected int _fontSize;
    protected float _iconExtraScale;
    protected Cursor _cursor;

    protected float IconScale => _theme!.IconScale * _iconExtraScale;

    public int ChildCount => _children.Count;
    public IList<Widget> Children => _children;

    public Widget? Parent
    {
        get => _parent;
        set => _parent = value;
    }

    public Layout? Layout
    {
        get => _layout;
        set => _layout = value;
    }

    public virtual Theme Theme
    {
        get => _theme;
        set
        {
            _theme = value;
            foreach (var child in _children)
                child.Theme = value;
        }
    }

    public Vector2i Position
    {
        get => _position;
        set => _position = value;
    }

    public Vector2i AbsolutePosition
    {
        get
        {
            if (_parent != null)
                return _parent.AbsolutePosition + _position;

            return _position;
        }
    }

    public Vector2i Size
    {
        get => _size;
        set => _size = value;
    }

    public int Width
    {
        get => _size.X;
        set => _size.X = value;
    }

    public int Height
    {
        get => _size.Y;
        set => _size.Y = value;
    }

    public Vector2i FixedSize
    {
        get => _fixedSize;
        set => _fixedSize = value;
    }

    public int FixedWidth
    {
        get => _fixedSize.X;
        set => _fixedSize.X = value;
    }

    public int FixedHeight
    {
        get => _fixedSize.Y;
        set => _fixedSize.Y = value;
    }

    public bool IsVisible
    {
        get => _isVisible;
        set => _isVisible = value;
    }

    public bool IsVisibleRecursive
    {
        get
        {
            var isVisible = true;
            var widget = this;
            while (widget != null)
            {
                isVisible &= widget._isVisible;
                widget = widget._parent;
            }

            return isVisible;
        }
    }

    public Window? Window
    {
        get
        {
            var widget = this;
            while (widget != null)
            {
                if (widget is Window window)
                    return window;

                widget = widget._parent;
            }

            return null;
        }
    }

    public Screen? Screen
    {
        get
        {
            var widget = this;
            while (widget != null)
            {
                if (widget is Screen screen)
                    return screen;

                widget = widget._parent;
            }

            return null;
        }
    }

    public bool IsEnabled
    {
        get => _isEnabled;
        set => _isEnabled = value;
    }

    public bool IsFocused
    {
        get => _isFocused;
        set
        {
            if (_isFocused == value)
                return;

            _isFocused = value;
            OnFocus(value);
        }
    }

    public RichTextLayout Tooltip
    {
        get => _tooltip ??= new RichTextLayout
        {
            Font = _theme.FontSansRegular.GetFont(15),
            Width = 150,
            VerticalSpacing = 2,
        };
        set => _tooltip = value;
    }

    public string TooltipText
    {
        get => Tooltip.Text;
        set => Tooltip.Text = value;
    }

    public bool HasTooltip => _tooltip != null && !string.IsNullOrEmpty(_tooltip.Text);

    public int FontSize
    {
        get => _fontSize < 0 ? _theme.StandardFontSize : _fontSize;
        set => _fontSize = value;
    }

    public bool HasFontSize => FontSize > 0;

    public float IconExtraScale
    {
        get => _iconExtraScale;
        set => _iconExtraScale = value;
    }

    public Cursor Cursor
    {
        get => _cursor;
        set => _cursor = value;
    }

    public Widget(Widget? parent)
    {
        _parent = parent;
        _theme = Theme.Default;
        _layout = null;
        _position = new Vector2i(0, 0);
        _size = new Vector2i(0, 0);
        _fixedSize = new Vector2i(0, 0);
        _isVisible = true;
        _isEnabled = true;
        _isFocused = false;
        _isMouseOver = false;
        _tooltip = null;
        _fontSize = -1;
        _iconExtraScale = 1.0f;
        _cursor = Cursor.Arrow;
        _parent?.AddChild(this);
    }

    public void AddChild(Widget child)
    {
        _children.Add(child);
        child.Parent = this;
        child.Theme = _theme;
    }

    public void AddChild(int index, Widget child)
    {
        Debug.Assert(index < _children.Count);
        _children.Insert(index, child);
        child.Parent = this;
        child.Theme = _theme;
    }

    public void RemoveChildAt(int index)
    {
        var child = _children[index];
        _children.RemoveAt(index);
        child.Parent = null;
    }

    public void RemoveChild(Widget child)
    {
        _children.Remove(child);
        child.Parent = null;
    }

    public Widget ChildAt(int index)
    {
        return _children[index];
    }

    public int ChildIndex(Widget child)
    {
        return _children.IndexOf(child);
    }

    public void RequestFocus()
    {
        var widget = this;
        while (widget._parent != null)
            widget = widget._parent;

        ((Screen)widget).UpdateFocus(this);
    }

    public bool Contains(Vector2i position)
    {
        var d = position - _position;
        return d.X >= 0 && d.Y >= 0 && d.X < _size.X && d.Y < _size.Y;
    }

    public Widget? Find(Vector2i position)
    {
        for (var i = _children.Count - 1; i >= 0; i--)
        {
            var child = _children[i];
            if (child.IsVisible && child.Contains(position - _position))
                return child.Find(position - _position);
        }

        if (Contains(position))
            return this;

        return null;
    }

    public virtual bool OnMouseDown(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        for (var i = _children.Count - 1; i >= 0; i--)
        {
            var child = _children[i];
            if (child.IsVisible && child.Contains(position - _position) && child.OnMouseDown(position - _position, button, modifiers))
                return true;
        }

        if (button == MouseButton.Button1 && !_isFocused)
            RequestFocus();

        return false;
    }

    public virtual bool OnMouseUp(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        for (var i = _children.Count - 1; i >= 0; i--)
        {
            var child = _children[i];
            if (child.IsVisible && child.Contains(position - _position) && child.OnMouseUp(position - _position, button, modifiers))
                return true;
        }

        return false;
    }

    public virtual bool OnMouseMove(Vector2i position, Vector2i relative, int mouseState, KeyModifier modifiers)
    {
        var handled = false;
        for (var i = _children.Count - 1; i >= 0; i--)
        {
            var child = _children[i];
            if (!child.IsVisible)
                continue;

            var contained = child.Contains(position - _position);
            var prevContained = child.Contains(position - _position - relative);
            if (contained != prevContained)
                handled |= child.OnMouseEnter(position - _position, contained);

            if (contained || prevContained)
                handled |= child.OnMouseMove(position - _position, relative, mouseState, modifiers);
        }

        return handled;
    }

    public virtual bool OnMouseDrag(Vector2i position, Vector2i relative, int mouseState, KeyModifier modifiers)
    {
        return false;
    }

    public virtual bool OnMouseEnter(Vector2i position, bool isMouseOver)
    {
        _isMouseOver = isMouseOver;
        return false;
    }

    public virtual bool OnScroll(Vector2i position, Vector2 distance, Vector2 relative)
    {
        for (var i = _children.Count - 1; i >= 0; i--)
        {
            var child = _children[i];
            if (!child.IsVisible)
                continue;

            if (child.Contains(position - _position) && child.OnScroll(position - _position, distance, relative))
                return true;
        }

        return false;
    }

    public virtual bool OnFocus(bool isFocused)
    {
        _isFocused = isFocused;
        return false;
    }

    public virtual bool OnKeyDown(Key key, Scancode scancode, KeyModifier modifiers, bool isRepeat)
    {
        return false;
    }

    public virtual bool OnKeyUp(Key key, Scancode scancode, KeyModifier modifiers)
    {
        return false;
    }

    public virtual bool OnTextInput(string input)
    {
        return false;
    }

    public virtual Vector2i GetPreferredSize(NvgContext context)
    {
        if (_layout != null)
            return _layout.GetPreferredSize(context, this);

        return _size;
    }

    public virtual void PerformLayout(NvgContext context)
    {
        if (_layout != null)
        {
            _layout.PerformLayout(context, this);
        }
        else
        {
            foreach (var child in _children)
            {
                var preferedSize = child.GetPreferredSize(context);
                var fixedSize = child.FixedSize;

                var width = fixedSize.X != 0 ? fixedSize.X : preferedSize.X;
                var height = fixedSize.Y != 0 ? fixedSize.Y : preferedSize.Y;
                child.Size = new Vector2i(width, height);

                child.PerformLayout(context);
            }
        }
    }

    public virtual void Draw(NvgContext context)
    {
#if SHOW_WIDGET_BOUNDS
        var size = _size;
        if (size != Vector2i.Zero)
        {
            context.StrokeWidth(1);
            context.BeginPath();
            context.Rect(Position.X - 0.5f, Position.Y - 0.5f, size.X + 1, size.Y + 1);
            context.MoveTo(Position.X, Position.Y);
            context.LineTo(Position.X + size.X, Position.Y + size.Y);
            context.MoveTo(Position.X + size.X, Position.Y);
            context.LineTo(Position.X, Position.Y + size.Y);
            context.StrokeColor(System.Drawing.Color.FromArgb(120, System.Drawing.Color.Red));
            context.Stroke();
        }
#endif

        if (_children.Count == 0)
            return;

        context.Translate(_position.X, _position.Y);
        foreach (var child in _children)
        {
            if (!child._isVisible)
                continue;

#if !SHOW_WIDGET_BOUNDS
            context.SaveState();
            context.IntersectScissor(child._position.X, child._position.Y, child._size.X, child._size.Y);
#endif

            child.Draw(context);

#if !SHOW_WIDGET_BOUNDS
            context.RestoreState();
#endif
        }

        context.Translate(-_position.X, -_position.Y);
    }

    protected static System.Drawing.Color MakeColor(int intensity, int alpha)
    {
        return System.Drawing.Color.FromArgb(alpha, intensity, intensity, intensity);
    }
}