using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using NvgSharp;
using OpenTK.Mathematics;
using OpenTK.Platform;

namespace Marius.Winter.Forms;

public class Screen : Widget
{
    private static readonly ConditionalWeakTable<WindowHandle, Screen> Screens = new ConditionalWeakTable<WindowHandle, Screen>();

    protected readonly Backend _backend;
    protected readonly NvgContext _context;

    protected CursorHandle[] _cursors;
    protected List<Widget> _focusPath = new List<Widget>();
    protected Vector2i _fbSize;
    protected float _pixelRatio;
    protected int _mouseState;
    protected KeyModifier _modifiers;
    protected Vector2i _mousePosition;
    protected bool _isDragActive;
    protected Widget? _dragWidget;
    protected long _lastInteraction;
    protected bool _processEvents;
    protected Color4<Rgba> _backgroundColor;
    protected string _caption;
    protected bool _shutdownToolkit;
    protected bool _isFullscreen;
    protected bool _redrawRequested;

    public WindowHandle NativeWindow => _backend.NativeWindow;

    public new bool IsVisible
    {
        get => _isVisible;
        set
        {
            if (_isVisible == value)
                return;

            _isVisible = value;
            if (_isVisible)
                Toolkit.Window.SetMode(NativeWindow, _isFullscreen ? WindowMode.WindowedFullscreen : WindowMode.Normal);
            else
                Toolkit.Window.SetMode(NativeWindow, WindowMode.Hidden);
        }
    }

    public string Caption
    {
        get => _caption;
        set
        {
            _caption = value;
            Toolkit.Window.SetTitle(NativeWindow, _caption);
        }
    }

    public new Vector2i Size
    {
        get => _size;
        set
        {
            _size = value;
            Toolkit.Window.SetSize(NativeWindow, new Vector2i((int)(_size.X * _pixelRatio), (int)(_size.Y * _pixelRatio)));
        }
    }

    public NvgContext Context => _context;

    public event Action<Screen, Vector2i>? Resize;

    public Color BackgroundColor
    {
        get => Color.FromArgb((int)(_backgroundColor.Z * 255), (int)(_backgroundColor.X * 255), (int)(_backgroundColor.Y * 255), (int)(_backgroundColor.Z * 255));
        set => _backgroundColor = new Color4<Rgba>(value.R / 255f, value.G / 255f, value.B / 255f, value.A / 255f);
    }

    public Screen
    (
        Vector2i size,
        BackendFactory backendFactory,
        string caption = "Unnamed",
        bool resizable = true,
        bool isFullscreen = false
    ) : base(null)
    {
        _backgroundColor = new Color4<Rgba>(0.3f, 0.3f, 0.32f, 1);
        _caption = caption;
        _shutdownToolkit = false;
        _isFullscreen = isFullscreen;
        _redrawRequested = false;
        _cursor = Cursor.Arrow;

        _backend = backendFactory.Create(size, _isFullscreen, resizable);
        _context = _backend.Context;

        EventQueue.EventRaised += HandleEvent;

        Toolkit.Window.GetClientSize(_backend.NativeWindow, out _size);
        Toolkit.Window.GetFramebufferSize(_backend.NativeWindow, out _fbSize);

        _pixelRatio = GetPixelRatio(_backend.NativeWindow);

        if (_pixelRatio != 1 && !_isFullscreen)
            Toolkit.Window.SetSize(_backend.NativeWindow, new Vector2i((int)(_size.X * _pixelRatio), (int)(_size.Y * _pixelRatio)));

        _isVisible = Toolkit.Window.GetMode(_backend.NativeWindow) != WindowMode.Hidden;
        _theme = Theme.Default;
        _mousePosition = new Vector2i(0, 0);
        _mouseState = 0;
        _modifiers = 0;
        _isDragActive = false;
        _lastInteraction = Stopwatch.GetTimestamp();
        _processEvents = true;
        _redrawRequested = true;
        Screens.AddOrUpdate(NativeWindow, this);
        _cursors = new CursorHandle[(int)Cursor.CursorCount];
        _cursors[(int)Cursor.Arrow] = Toolkit.Cursor.Create(SystemCursorType.Default);
        _cursors[(int)Cursor.IBeam] = Toolkit.Cursor.Create(SystemCursorType.TextBeam);
        _cursors[(int)Cursor.Crosshair] = Toolkit.Cursor.Create(SystemCursorType.Cross);
        _cursors[(int)Cursor.Hand] = Toolkit.Cursor.Create(SystemCursorType.Hand);
        _cursors[(int)Cursor.HResize] = Toolkit.Cursor.Create(SystemCursorType.ArrowNS);
        _cursors[(int)Cursor.VResize] = Toolkit.Cursor.Create(SystemCursorType.ArrowEW);
    }

    public override bool OnKeyDown(Key key, Scancode scancode, KeyModifier modifiers, bool isRepeat)
    {
        if (_focusPath.Count > 0)
        {
            for (var i = _focusPath.Count - 1; i >= 0; i--)
            {
                var item = _focusPath[i];
                if (item == this)
                    continue;

                if (item.IsFocused && item.OnKeyDown(key, scancode, modifiers, isRepeat))
                    return true;
            }
        }

        return false;
    }

    public override bool OnKeyUp(Key key, Scancode scancode, KeyModifier modifiers)
    {
        if (_focusPath.Count > 0)
        {
            for (var i = _focusPath.Count - 1; i >= 0; i--)
            {
                var item = _focusPath[i];
                if (item == this)
                    continue;

                if (item.IsFocused && item.OnKeyUp(key, scancode, modifiers))
                    return true;
            }
        }

        return false;
    }

    public override bool OnTextInput(string input)
    {
        if (_focusPath.Count > 0)
        {
            for (var i = _focusPath.Count - 1; i >= 0; i--)
            {
                var item = _focusPath[i];
                if (item == this)
                    continue;

                if (item.IsFocused && item.OnTextInput(input))
                    return true;
            }
        }

        return false;
    }

    public virtual bool OnResize(Vector2i size)
    {
        Resize?.Invoke(this, size);
        _redrawRequested = true;
        DrawAll();
        return true;
    }

    public virtual bool OnFileDrop(IReadOnlyList<string> filePaths, Vector2i position)
    {
        return false;
    }

    public virtual void DrawSetup()
    {
        _backend.PrepareFrame(_backgroundColor);
    }

    public virtual void DrawTearDown()
    {
        _backend.SubmitFrame();
    }

    public virtual void DrawAll()
    {
        if (_redrawRequested || TooltipFadeInProgress())
        {
            _redrawRequested = false;

            DrawSetup();
            DrawContents();
            DrawWidgets();
            DrawTearDown();
        }
    }

    public virtual void DrawContents()
    {
    }

    public void Redraw()
    {
        if (!_redrawRequested)
        {
            _redrawRequested = true;
            EventQueue.Raise(NativeWindow, PlatformEventType.NoOperation, EventArgs.Empty);
        }
    }

    public void Flush()
    {
        _context.Flush();
        _context.DevicePixelRatio = _pixelRatio;
    }

    internal void DrawWidgets()
    {
        _context.DevicePixelRatio = _pixelRatio;
        _context.ResetState();

        Draw(_context);

        var elapsed = Stopwatch.GetElapsedTime(_lastInteraction);
        if (elapsed.TotalMilliseconds > 500)
        {
            var widget = Find(_mousePosition);
            if (widget != null && widget.HasTooltip)
            {
                var layout = widget.Tooltip;

                var size = layout.Measure(layout.Width.GetValueOrDefault(150));
                var widgetRect = new RectangleF(widget.AbsolutePosition.X, widget.AbsolutePosition.Y, widget.Size.X, widget.Size.Y);
                var screen = new SizeF(_size.X, _size.Y);
                var (rect, pip) = PlaceTooltipAndPip(
                    widgetRect,
                    new SizeF(size.X + 8, size.Y + 18),
                    screen);

                // If the tooltip is touching the screen border, try to move it by 5, don't allow overlap with the widget
                if (rect.X < 5)
                {
                    var newRect = rect with { X = 5 };
                    if (IsFullyVisible(newRect, screen) && !widgetRect.IntersectsWith(newRect))
                    {
                        pip.X += 5 - rect.X;
                        rect.X = 5;
                    }
                }

                if (rect.Y < 5)
                {
                    var newRect = rect with { Y = 5 };
                    if (IsFullyVisible(newRect, screen) && !widgetRect.IntersectsWith(newRect))
                    {
                        pip.Y += 5 - rect.Y;
                        rect.Y = 5;
                    }
                }

                if (rect.Right > screen.Width - 5)
                {
                    var newRect = rect with { X = screen.Width - rect.Width - 5 };
                    if (IsFullyVisible(newRect, screen) && !widgetRect.IntersectsWith(newRect))
                    {
                        pip.X += screen.Width - rect.Right - 5;
                        rect.X = screen.Width - rect.Width - 5;
                    }
                }

                if (rect.Bottom > screen.Height - 5)
                {
                    var newRect = rect with { Y = screen.Height - rect.Height - 5 };
                    if (IsFullyVisible(newRect, screen) && !widgetRect.IntersectsWith(newRect))
                    {
                        pip.Y += screen.Height - rect.Bottom - 5;
                        rect.Y = screen.Height - rect.Height - 5;
                    }
                }

                _context.SaveState();

                _context.GlobalAlpha(Math.Min(1.0f, 2 * ((float)elapsed.TotalSeconds - 0.5f)) * 0.8f);

                _context.BeginPath();
                _context.FillColor(Color.White);
                _context.RoundedRect(
                    rect.X,
                    rect.Y,
                    rect.Width,
                    rect.Height, 3);

                _context.MoveTo(pip.X - 7, pip.Y);
                _context.LineTo(pip.X, pip.Y + 7);
                _context.LineTo(pip.X + 7, pip.Y);
                _context.LineTo(pip.X, pip.Y - 7);
                _context.Fill();

                _context.FillColor(Color.Black);
                _context.RichText(layout, rect.X + 4, rect.Y + 4);

                _context.RestoreState();
            }
        }

        _context.Flush();

    }

    private static (RectangleF, PointF) PlaceTooltipAndPip(RectangleF widget, SizeF tooltip, SizeF screen)
    {
        // 1. Try to position just below the widget
        var bottom = new RectangleF(
            widget.X + (widget.Width - tooltip.Width) / 2.0f,
            widget.Y + widget.Height + 10,
            tooltip.Width,
            tooltip.Height);

        if (bottom.X < 0)
            bottom.X = 0;

        if (bottom.Right > screen.Width)
            bottom.X -= bottom.Right - screen.Width;

        if (IsFullyVisible(bottom, screen))
        {
            var bottomPip = new PointF(
                PlacePip(widget.X, widget.Width, bottom.X, bottom.Width),
                bottom.Y);

            return (bottom, bottomPip);
        }

        // 2. Let's try to position above the widget
        var top = new RectangleF(
            widget.X + (widget.Width - tooltip.Width) / 2.0f,
            widget.Y - tooltip.Height - 10,
            tooltip.Width,
            tooltip.Height);

        if (top.X < 0)
            top.X = 0;

        if (top.Right > screen.Width)
            top.X -= top.Right - screen.Width;

        if (IsFullyVisible(top, screen))
        {
            var topPip = new PointF(
                PlacePip(widget.X, widget.Width, top.X, top.Width),
                top.Y + tooltip.Height);

            return (top, topPip);
        }

        // 3. Let's try to position to the left of the widget
        var left = new RectangleF(
            widget.X - tooltip.Width - 10,
            widget.Y + (widget.Height - tooltip.Height) / 2.0f,
            tooltip.Width,
            tooltip.Height);

        if (left.Y < 0)
            left.Y = 0;

        if (left.Bottom > screen.Height)
            left.Y -= left.Bottom - screen.Height;

        if (IsFullyVisible(left, screen))
        {
            var leftPip = new PointF(
                left.X + tooltip.Width,
                PlacePip(widget.Y, widget.Height, left.Y, left.Height));

            return (left, leftPip);
        }

        // 4. Let's try to position to the right of the widget
        var right = new RectangleF(
            widget.X + widget.Width + 10,
            widget.Y + (widget.Height - tooltip.Height) / 2.0f,
            tooltip.Width,
            tooltip.Height);

        if (right.Y < 0)
            right.Y = 0;

        if (right.Bottom > screen.Height)
            right.Y -= right.Bottom - screen.Height;

        if (IsFullyVisible(right, screen))
        {
            var rightPip = new PointF(
                right.X,
                PlacePip(widget.Y, widget.Height, right.Y, right.Height));

            return (right, rightPip);
        }

        // 5. Not enough space so let's calculate the visible areas
        var topIntersect = new RectangleF(0, 0, screen.Width, screen.Height);
        topIntersect.Intersect(top);
        var topVisibleArea = topIntersect.Width * topIntersect.Height;

        var bottomIntersect = new RectangleF(0, 0, screen.Width, screen.Height);
        bottomIntersect.Intersect(bottom);
        var bottomVisibleArea = bottomIntersect.Width * bottomIntersect.Height;

        var leftIntersect = new RectangleF(0, 0, screen.Width, screen.Height);
        leftIntersect.Intersect(left);
        var leftVisibleArea = leftIntersect.Width * leftIntersect.Height;

        var rightIntersect = new RectangleF(0, 0, screen.Width, screen.Height);
        rightIntersect.Intersect(right);
        var rightVisibleArea = rightIntersect.Width * rightIntersect.Height;

        var maxVisibleArea = Math.Max(topVisibleArea, Math.Max(bottomVisibleArea, Math.Max(leftVisibleArea, rightVisibleArea)));
        if (maxVisibleArea == bottomVisibleArea)
        {
            var bottomPip = new PointF(
                PlacePip(widget.X, widget.Width, bottom.X, bottom.Width),
                bottom.Y);

            return (bottom, bottomPip);
        }

        if (maxVisibleArea == topVisibleArea)
        {
            var topPip = new PointF(
                PlacePip(widget.X, widget.Width, top.X, top.Width),
                top.Y + tooltip.Height);

            return (top, topPip);
        }

        if (maxVisibleArea == rightVisibleArea)
        {
            var rightPip = new PointF(
                right.X,
                PlacePip(widget.Y, widget.Height, right.Y, right.Height));

            return (right, rightPip);
        }

        var pip = new PointF(
            left.X + tooltip.Width,
            PlacePip(widget.Y, widget.Height, left.Y, left.Height));

        return (left, pip);

        static float PlacePip(float widgetAxisPosition, float widgetAxisSize, float tooltipAxisPosition, float tooltipAxisSize)
        {
            // Find the intersection position and size of the widget and tooltip in this axis
            var intersectionPosition = 0f;
            var intersectionSize = 0f;
            if (widgetAxisPosition > tooltipAxisPosition)
                intersectionPosition = widgetAxisPosition;
            else
                intersectionPosition = tooltipAxisPosition;

            intersectionSize = Math.Min(tooltipAxisPosition + tooltipAxisSize, widgetAxisPosition + widgetAxisSize) - intersectionPosition;
            return intersectionPosition + intersectionSize / 2.0f;
        }
    }

    private static bool IsFullyVisible(RectangleF r, SizeF size)
    {
        return r.X >= 0 && r.Y >= 0 && r.Right <= size.Width && r.Bottom <= size.Height;
    }

    internal void UpdateFocus(Widget? widget)
    {
        foreach (var item in _focusPath)
        {
            if (!item.IsFocused)
                continue;

            item.OnFocus(false);
        }

        _focusPath.Clear();

        var window = default(Window);
        while (widget != null)
        {
            _focusPath.Add(widget);
            if (widget is Window w)
                window = w;

            widget = widget.Parent;
        }

        for (var i = _focusPath.Count - 1; i >= 0; i--)
        {
            var item = _focusPath[i];
            item.OnFocus(true);
        }

        if (window != null)
            MoveWindowToFront(window);
    }

    internal void DisposeWindow(Window window)
    {
        if (_focusPath.IndexOf(window) != -1)
            _focusPath.Clear();

        if (_dragWidget == window)
            _dragWidget = null;

        RemoveChild(window);
    }

    internal void CenterWindow(Window window)
    {
        if (window.Size == Vector2i.Zero)
        {
            window.Size = window.GetPreferredSize(_context);
            window.PerformLayout(_context);
        }

        window.Position = (_size - window.Size) / 2;
    }

    internal void MoveWindowToFront(Window window)
    {
        _children.Remove(window);
        _children.Add(window);

        var changed = false;
        do
        {
            var baseIndex = 0;
            for (var index = 0; index < _children.Count; index++)
                if (_children[index] == window)
                    baseIndex = index;

            changed = false;
            for (var index = 0; index < _children.Count; index++)
            {
                if (_children[index] is Popup pw && pw.ParentWindow == window && index < baseIndex)
                {
                    MoveWindowToFront(pw);
                    changed = true;
                    break;
                }
            }

        } while (changed);
    }

    internal bool TooltipFadeInProgress()
    {
        var elapsed = Stopwatch.GetElapsedTime(_lastInteraction);
        if (elapsed.TotalSeconds < 0.25 || elapsed.TotalSeconds > 1.25)
            return false;

        var widget = Find(_mousePosition);
        return widget != null && widget.HasTooltip;
    }

    private void HandleEvent(PalHandle? handle, PlatformEventType type, EventArgs args)
    {
        if (NativeWindow != handle || !_processEvents)
            return;

        switch (type)
        {
            case PlatformEventType.MouseMove:
                if (args is MouseMoveEventArgs mm)
                    HandleMouseMove(mm.ClientPosition);
                break;
            case PlatformEventType.MouseDown:
                if (args is MouseButtonDownEventArgs md)
                    HandleMouseDown(md.Button, md.Modifiers);
                break;
            case PlatformEventType.MouseUp:
                if (args is MouseButtonUpEventArgs mu)
                    HandleMouseUp(mu.Button, mu.Modifiers);
                break;
            case PlatformEventType.KeyDown:
                if (args is KeyDownEventArgs kd)
                    HandleKeyDown(kd.Key, kd.Scancode, kd.Modifiers, kd.IsRepeat);
                break;
            case PlatformEventType.KeyUp:
                if (args is KeyUpEventArgs ku)
                    HandleKeyUp(ku.Key, ku.Scancode, ku.Modifiers);
                break;
            case PlatformEventType.TextInput:
                if (args is TextInputEventArgs ti)
                    HandleTextInput(ti.Text);
                break;
            case PlatformEventType.FileDrop:
                if (args is FileDropEventArgs fd)
                    HandleFileDrop(fd.FilePaths, fd.Position);
                break;
            case PlatformEventType.Scroll:
                if (args is ScrollEventArgs s)
                    HandleScroll(s.Distance, s.Delta);
                break;
            case PlatformEventType.WindowFramebufferResize:
                if (args is WindowFramebufferResizeEventArgs wfr)
                    HandleResize(wfr.NewFramebufferSize);
                break;
            case PlatformEventType.Focus:
                if (args is FocusEventArgs f)
                    HandleFocus(f.GotFocus);
                break;
            case PlatformEventType.WindowScaleChange:
                if (args is WindowScaleChangeEventArgs)
                {
                    _pixelRatio = GetPixelRatio(NativeWindow);
                    HandleResize(_size);
                }

                break;
        }
    }

    private void HandleFocus(bool isFocused)
    {
        try
        {
            OnFocus(isFocused);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
        }

        _redrawRequested = true;
    }

    private void HandleResize(Vector2i _)
    {
        Toolkit.Window.GetFramebufferSize(NativeWindow, out var fbSize);
        Toolkit.Window.GetSize(NativeWindow, out var size);

        if (fbSize == Vector2i.Zero || size == Vector2i.Zero)
            return;

        _fbSize = fbSize;
        _size = size;

        var scaled = _size.ToVector2() / _pixelRatio;
        _size = new Vector2i((int)scaled.X, (int)scaled.Y);

        _lastInteraction = Stopwatch.GetTimestamp();

        try
        {
            OnResize(_size);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
        }

        _redrawRequested = true;
    }

    private void HandleScroll(Vector2 distance, Vector2 delta)
    {
        _lastInteraction = Stopwatch.GetTimestamp();
        try
        {
            if (_focusPath.Count > 1)
            {
                if (_focusPath[_focusPath.Count - 2] is Window window && window.IsModal)
                {
                    if (!window.Contains(_mousePosition))
                        return;
                }
            }

            _redrawRequested |= OnScroll(_mousePosition, distance, delta);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
        }
    }

    private void HandleFileDrop(IReadOnlyList<string> filePaths, Vector2i position)
    {
        try
        {
            _redrawRequested |= OnFileDrop(filePaths, position);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
        }
    }

    private void HandleKeyDown(Key key, Scancode scancode, KeyModifier modifiers, bool isRepeat)
    {
        _lastInteraction = Stopwatch.GetTimestamp();
        try
        {
            _redrawRequested |= OnKeyDown(key, scancode, modifiers, isRepeat);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
        }
    }

    private void HandleKeyUp(Key key, Scancode scancode, KeyModifier modifiers)
    {
        _lastInteraction = Stopwatch.GetTimestamp();
        try
        {
            _redrawRequested |= OnKeyUp(key, scancode, modifiers);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
        }
    }

    private void HandleTextInput(string text)
    {
        _lastInteraction = Stopwatch.GetTimestamp();
        try
        {
            _redrawRequested |= OnTextInput(text);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
        }
    }

    private void HandleMouseUp(MouseButton button, KeyModifier modifiers)
    {
        _modifiers = modifiers;
        _lastInteraction = Stopwatch.GetTimestamp();

        try
        {
            if (_focusPath.Count > 1)
            {
                if (_focusPath[_focusPath.Count - 2] is Window window && window.IsModal)
                {
                    if (!window.Contains(_mousePosition))
                        return;
                }
            }

            _mouseState &= ~(1 << (int)button);

            var dropWidget = Find(_mousePosition);
            if (_isDragActive && dropWidget != _dragWidget)
            {
                Debug.Assert(_dragWidget != null);
                Debug.Assert(_dragWidget.Parent != null);

                _dragWidget.OnMouseUp(_mousePosition - _dragWidget.Parent.AbsolutePosition, button, _modifiers);
            }

            if (dropWidget != null && dropWidget.Cursor != _cursor)
            {
                _cursor = dropWidget.Cursor;
                Toolkit.Window.SetCursor(NativeWindow, _cursors[(int)_cursor]);
            }

            var isButton12 = button == MouseButton.Button1 || button == MouseButton.Button2;
            if (_isDragActive && isButton12)
            {
                _isDragActive = false;
                _dragWidget = null;
            }

            OnMouseUp(_mousePosition, button, _modifiers);
            _redrawRequested = true; // Need to always redraw in case of Window losing focus
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
        }
    }

    private void HandleMouseDown(MouseButton button, KeyModifier modifiers)
    {
        _modifiers = modifiers;
        _lastInteraction = Stopwatch.GetTimestamp();

        try
        {
            if (_focusPath.Count > 1)
            {
                if (_focusPath[_focusPath.Count - 2] is Window window && window.IsModal)
                {
                    if (!window.Contains(_mousePosition))
                        return;
                }
            }

            _mouseState |= 1 << (int)button;

            var dropWidget = Find(_mousePosition);
            if (dropWidget != null && dropWidget.Cursor != _cursor)
            {
                _cursor = dropWidget.Cursor;
                Toolkit.Window.SetCursor(NativeWindow, _cursors[(int)_cursor]);
            }

            var isButton12 = button == MouseButton.Button1 || button == MouseButton.Button2;
            if (!_isDragActive && isButton12)
            {
                _dragWidget = Find(_mousePosition);
                if (_dragWidget == this)
                    _dragWidget = null;

                _isDragActive = _dragWidget != null;
                if (!_isDragActive)
                    UpdateFocus(null);
            }

            OnMouseDown(_mousePosition, button, _modifiers);
            _redrawRequested = true; // Need to always redraw in case of Window losing focus
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
        }
    }

    private void HandleMouseMove(Vector2 position)
    {
        var scaled = position / _pixelRatio;
        var p = new Vector2i((int)scaled.X, (int)scaled.Y);

        _lastInteraction = Stopwatch.GetTimestamp();

        try
        {
            p -= new Vector2i(1, 2);

            var ret = false;
            if (!_isDragActive)
            {
                var widget = Find(p);
                if (widget != null && widget.Cursor != _cursor)
                {
                    _cursor = widget.Cursor;
                    Toolkit.Window.SetCursor(NativeWindow, _cursors[(int)_cursor]);
                }
            }
            else
            {
                Debug.Assert(_dragWidget != null);

                ret = _dragWidget.OnMouseDrag(p, p - _mousePosition, _mouseState, _modifiers);
            }

            if (!ret)
                OnMouseMove(p, p - _mousePosition, _mouseState, _modifiers);

            _mousePosition = p;
            _redrawRequested = true;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
        }
    }

    private static float GetPixelRatio(WindowHandle window)
    {
        Toolkit.Window.GetScaleFactor(window, out var scaleX, out var _);
        return scaleX;
    }
}