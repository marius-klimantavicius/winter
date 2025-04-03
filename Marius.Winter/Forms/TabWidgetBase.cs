using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using FontStashSharp;
using NvgSharp;
using OpenTK.Mathematics;
using OpenTK.Platform;

namespace Marius.Winter.Forms;

public class TabWidgetBase : Widget
{
    protected readonly List<string> _tabCaptions = new List<string>();
    protected readonly List<int> _tabIds = new List<int>();
    protected readonly List<int> _tabOffsets = new List<int>();
    protected FontSystem _font;
    protected int _closeWidth;
    protected int _activeTab;
    protected int _tabDragIndex = -1;
    protected int _tabDragMin = -1;
    protected int _tabDragMax = -1;
    protected int _tabDragStart = -1;
    protected int _tabDragEnd = -1;
    protected int _closeIndex = -1;
    protected int _closeIndexPushed = -1;
    protected bool _tabsDraggable;
    protected bool _tabsCloseable;
    protected Popup? _popup;
    protected int _tabCounter;
    protected int _padding = 3;
    protected Color _backgroundColor;

    public int TabCount => _tabCaptions.Count;

    public int SelectedTabId
    {
        get
        {
            if (_tabIds.Count == 0)
                return -1;

            return _tabIds[_activeTab];
        }
        set
        {
            _activeTab = value;
            UpdateVisibility();
        }
    }

    public int SelectedIndex
    {
        get => _activeTab;
        set
        {
            _activeTab = value;
            UpdateVisibility();
        }
    }

    public bool TabsCloseable
    {
        get => _tabsCloseable;
        set => _tabsCloseable = value;
    }

    public bool TabsDraggable
    {
        get => _tabsDraggable;
        set => _tabsDraggable = value;
    }

    public int Padding
    {
        get => _padding;
        set => _padding = value;
    }

    public Color BackgroundColor
    {
        get => _backgroundColor;
        set => _backgroundColor = value;
    }

    public event Action<TabWidgetBase, int>? TabSelected;
    public event Action<TabWidgetBase, int>? TabClosed;

    public Func<int, Screen, Popup>? OpenPopup { get; set; }

    public TabWidgetBase(Widget? parent, FontSystem? font)
        : base(parent)
    {
        _font = font ?? _theme.FontSansBold;
        _backgroundColor = Color.Black;
        _tabOffsets.Add(0);
    }

    public string GetTabCaption(int id) => _tabCaptions[GetTabIndex(id)];
    public string SetTabCaption(int id, string caption) => _tabCaptions[GetTabIndex(id)] = caption;

    public int GetTabId(int index) => _tabIds[index];

    public int GetTabIndex(int id)
    {
        var index = _tabIds.IndexOf(id);
        if (index < 0)
            throw new ArgumentException($"Tab with id {id} not found.");

        return index;
    }

    public virtual void RemoveTab(int id)
    {
        var index = GetTabIndex(id);
        var closeActive = index == _activeTab;

        _tabCaptions.RemoveAt(index);
        _tabIds.RemoveAt(index);

        if (index <= _activeTab)
            _activeTab = Math.Max(0, _activeTab - 1);

        var context = Screen?.Context;
        if (context != null)
            PerformLayout(context);

        TabClosed?.Invoke(this, id);
        if (closeActive)
        {
            TabSelected?.Invoke(this, SelectedTabId);
            UpdateVisibility();
        }
    }

    public int InsertTab(int index, string caption)
    {
        var id = _tabCounter++;

        _tabCaptions.Insert(index, caption);
        _tabIds.Insert(index, id);

        var context = Screen?.Context;
        if (context != null)
            PerformLayout(context);

        if (index < _activeTab)
            _activeTab++;

        if (_tabIds.Count == 1)
        {
            _activeTab = 0;
            TabSelected?.Invoke(this, id);
            UpdateVisibility();
        }

        return id;
    }

    public int AppendTab(string caption) => InsertTab(_tabCaptions.Count, caption);

    public override Vector2i GetPreferredSize(NvgContext context)
    {
        var font = _font.GetFont(FontSize);

        var width = 0f;
        foreach (var label in _tabCaptions)
        {
            var labelWidth = font.MeasureString(label).X;
            width += labelWidth + 2 * _theme.TabButtonHorizontalPadding;
            if (_tabsCloseable)
                width += _closeWidth;
        }

        return new Vector2i((int)(width + 1), FontSize + 2 * _theme.TabButtonVerticalPadding + 2 * _padding);
    }

    public override void PerformLayout(NvgContext context)
    {
        _tabOffsets.Clear();
        var font = _font.GetFont(FontSize);
        var width = 0f;
        foreach (var label in _tabCaptions)
        {
            var labelWidth = font.MeasureString(label).X;
            _tabOffsets.Add((int)width);
            width += labelWidth + 2 * _theme.TabButtonHorizontalPadding;
            if (_tabsCloseable)
                width += _closeWidth;
        }

        _tabOffsets.Add((int)width);

        var iconFont = _theme.FontIcons.GetFont(FontSize);
        _closeWidth = (int)iconFont.MeasureString(FontIcon.GetText(Icons.FA_TIMES_CIRCLE)).X;
    }

    public override void Draw(NvgContext context)
    {
        if (_tabOffsets.Count != _tabCaptions.Count + 1)
            throw new InvalidOperationException("Must run TabWidget::perform_layout() after adding/removing tabs!");

        var tabHeight = FontSize + 2 * _theme.TabButtonVerticalPadding;

        if (_backgroundColor.A != 0.0f)
        {
            context.FillColor(_backgroundColor);
            context.BeginPath();
            context.RoundedRect(_position.X + .5f, _position.Y + .5f + tabHeight, _size.X, _size.Y - tabHeight - 2, _theme.ButtonCornerRadius);
            context.Fill();
        }

        base.Draw(context);

        var tabBackgroundColor = context.LinearGradient(
            _position.X, _position.Y + 1, _position.X, _position.Y + tabHeight,
            _theme.ButtonGradientTopPushed, _theme.ButtonGradientBotPushed);

        context.SaveState();
        context.IntersectScissor(_position.X, _position.Y, _size.X, tabHeight);
        for (var i = 0; i < _tabCaptions.Count; ++i)
        {
            var xPos = _position.X + _tabOffsets[i];
            var yPos = _position.Y;
            var width = _tabOffsets[i + 1] - _tabOffsets[i];

            if (i == _activeTab)
            {
                context.BeginPath();
                context.RoundedRect(xPos + 0.5f, yPos + 1.5f, width, tabHeight + 4, _theme.ButtonCornerRadius);
                context.StrokeColor(_theme.BorderLight);
                context.Stroke();

                context.BeginPath();
                context.RoundedRect(xPos + 0.5f, yPos + 0.5f, width, tabHeight + 4, _theme.ButtonCornerRadius);

            }
            else
            {
                context.BeginPath();
                context.RoundedRect(xPos + 0.5f, yPos + 1.5f, width, tabHeight + 4, _theme.ButtonCornerRadius);

                context.FillPaint(tabBackgroundColor);
                context.Fill();
            }

            context.StrokeColor(_theme.BorderDark);
            context.Stroke();

            xPos += _theme.TabButtonHorizontalPadding;
            yPos += _theme.TabButtonVerticalPadding + 1;
            context.FillColor(_theme.TextColor);

            var font = _font.GetFont(FontSize);
            context.Text(font, _tabCaptions[i], xPos, yPos);

            if (_tabsCloseable)
            {
                xPos = _position.X + _tabOffsets[i + 1] - _theme.TabButtonHorizontalPadding - _closeWidth + 5;

                context.FillColor(i == _closeIndexPushed
                    ? _theme.TextColorShadow
                    : _theme.TextColor);
                var highlight = _closeIndex == i;
                var icon = highlight ? Icons.FA_TIMES_CIRCLE : Icons.FA_TIMES;
                float fs = FontSize * (highlight ? 1.0f : .70f),
                    offsetX = highlight ? 0.0f : fs * .40f,
                    offsetY = highlight ? 0.0f : fs * .21f;

                var iconFont = _theme.FontIcons.GetFont(fs);
                context.Text(iconFont, FontIcon.GetText(icon), xPos + offsetX, yPos + offsetY + .5f);
            }
        }

        if (_tabDragIndex != -1 && _tabDragStart != _tabDragEnd)
        {
            var xPos = _position.X + _tabDragMin + _tabDragEnd - _tabDragStart;
            context.BeginPath();
            context.RoundedRect(xPos + 0.5f, _position.Y + 1.5f, _tabDragMax - _tabDragMin, tabHeight + 4, _theme.ButtonCornerRadius);
            context.FillColor(Color.FromArgb(30, 255, 255, 255));
            context.Fill();
        }

        context.RestoreState();

        var x0 = _tabOffsets[_activeTab];
        var x1 = _tabOffsets[_tabOffsets.Count > 1 ? _activeTab + 1 : 0];
        for (var i = 1; i >= 0; --i)
        {
            /* Top border */
            context.BeginPath();
            context.MoveTo(_position.X + .5f, _position.Y + tabHeight + i + .5f);
            context.LineTo(_position.X + x0 + 1.0f, _position.Y + tabHeight + i + .5f);
            context.MoveTo(_position.X + x1, _position.Y + tabHeight + i + .5f);
            context.LineTo(_position.X + _size.X + .5f, _position.Y + tabHeight + i + .5f);
            context.StrokeWidth(1.0f);
            context.StrokeColor(i == 0 ? _theme.BorderDark : _theme.BorderLight);
            context.Stroke();

            /* Bottom + side borders */
            context.SaveState();
            context.IntersectScissor(_position.X, _position.Y + tabHeight, _size.X, _size.Y);
            context.BeginPath();
            context.RoundedRect(_position.X + .5f, _position.Y + i + .5f, _size.X - 1, _size.Y - 2, _theme.ButtonCornerRadius);
            context.Stroke();
            context.RestoreState();
        }
    }

    public override bool OnMouseDown(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        var (index, close) = GetTabAtPosition(position);
        var handled = false;

        var screen = Screen;
        if (_popup != null)
        {
            _popup.OnMouseDown(position - _position + AbsolutePosition - _popup.AbsolutePosition + _popup.Position, button, modifiers);
            screen?.UpdateFocus(this);
            screen?.RemoveChild(_popup);
            _popup = null;
            handled = true;
        }

        var dragInProgress = _tabDragIndex != -1 && _tabDragStart != _tabDragEnd;
        if (OpenPopup != null && button == MouseButton.Button2 && index != -1 && !dragInProgress)
        {
            _popup = OpenPopup(GetTabId(index), screen);
            if (_popup != null)
            {
                _popup.Position = position + new Vector2i(8, -6);
                _popup.AnchorOffset = 8;
                _popup.AnchorSize = 8;
                _popup.Layout ??= new GroupLayout(5, 3);
                foreach (var w in _popup.Children)
                {
                    var b = w as Button;
                    if (b == null)
                        continue;

                    b.IconPosition = IconPosition.Right;
                    b.Flags = ButtonFlags.MenuButton;
                }

                var ctx = screen?.Context;
                if (ctx != null)
                {
                    _popup.Size = _popup.GetPreferredSize(ctx) + new Vector2i(40, 0);
                    _popup.PerformLayout(ctx);
                }

                handled = true;
            }
        }

        if (button == MouseButton.Button1 && _popup == null)
        {
            if (index >= 0)
            {
                if (close && _tabDragIndex == -1)
                {
                    _closeIndexPushed = index;
                }
                else
                {
                    var tabChanged = _activeTab != index;
                    _activeTab = index;
                    _tabDragIndex = _tabsDraggable ? index : -1;
                    _tabDragStart = _tabDragEnd = position.X;
                    _tabDragMin = _tabOffsets[index];
                    _tabDragMax = _tabOffsets[index + 1];
                    _closeIndexPushed = -1;
                    if (tabChanged)
                    {
                        TabSelected?.Invoke(this, SelectedTabId);
                        UpdateVisibility();
                    }
                }
            }

            handled = true;
        }

        handled |= base.OnMouseDown(position, button, modifiers);

        return handled;
    }

    public override bool OnMouseUp(Vector2i position, MouseButton button, KeyModifier modifiers)
    {
        var (index, close) = GetTabAtPosition(position);
        var handled = false;

        var screen = Screen;
        if (_popup != null)
        {
            _popup.OnMouseUp(position - _position + AbsolutePosition - _popup.AbsolutePosition + _popup.Position, button, modifiers);
            screen?.UpdateFocus(this);
            screen?.RemoveChild(_popup);
            _popup = null;
            handled = true;
        }

        if (button == MouseButton.Button1 && _popup == null)
        {
            if (index >= 0)
            {
                if (close && _tabDragIndex == -1)
                {
                    if (_closeIndex == _closeIndexPushed)
                    {
                        RemoveTab(GetTabId(index));
                        OnMouseMove(position, new Vector2i(0), 0, 0);
                    }
                }
                else
                {
                    if (_tabDragIndex != -1)
                    {
                        _tabDragIndex = -1;
                        OnMouseMove(position, new Vector2i(0), 0, 0);
                        
                        var context = Screen?.Context;
                        if (context != null)
                            PerformLayout(context);
                    }
                }
            }

            _closeIndexPushed = -1;
            _tabDragIndex = -1;

            handled = true;
        }

        handled |= base.OnMouseUp(position, button, modifiers);

        return handled;
    }

    public override bool OnMouseEnter(Vector2i position, bool isMouseOver)
    {
        if (_tabsCloseable && _closeIndex >= 0)
        {
            _closeIndex = -1;
            _closeIndexPushed = -1;
            return true;
        }

        return false;
    }

    public override bool OnMouseMove(Vector2i position, Vector2i relative, int button, KeyModifier modifiers)
    {
        var (index, close) = GetTabAtPosition(position, false);

        if (_tabDragIndex != -1)
        {
            _tabDragEnd = position.X;
            if (index != -1 && _tabDragIndex != index)
            {
                var i0 = Math.Min(_tabDragIndex, index);
                var i1 = Math.Max(_tabDragIndex, index);
                var mid = (_tabOffsets[i0] + _tabOffsets[i1 + 1]) / 2;
                if ((_tabDragIndex < index && position.X - _position.Y > mid) ||
                    (_tabDragIndex > index && position.X - _position.Y < mid))
                {
                    Swap(ref CollectionsMarshal.AsSpan(_tabCaptions)[index], ref CollectionsMarshal.AsSpan(_tabCaptions)[_tabDragIndex]);
                    Swap(ref CollectionsMarshal.AsSpan(_tabIds)[index], ref CollectionsMarshal.AsSpan(_tabIds)[_tabDragIndex]);

                    var context = Screen?.Context;
                    if (context != null)
                        PerformLayout(context);

                    _tabDragIndex = index;
                    _activeTab = index;
                }
            }

            return true;
        }

        if (!close)
            index = -1;

        if (index != _closeIndex)
        {
            _closeIndex = index;
            _closeIndexPushed = -1;
            return true;
        }

        return base.OnMouseMove(position, relative, button, modifiers);
    }

    protected virtual void UpdateVisibility()
    {
    }

    protected (int, bool) GetTabAtPosition(Vector2i position, bool testVertical = true)
    {
        var tabHeight = FontSize + 2 * _theme.TabButtonVerticalPadding;
        if (testVertical && (position.Y <= _position.Y || position.Y > _position.Y + tabHeight))
            return (-1, false);

        var x = position.X - _position.X;
        for (var i = 0; i < _tabOffsets.Count - 1; ++i)
        {
            if (x >= _tabOffsets[i] && x < _tabOffsets[i + 1])
            {
                var r = _tabOffsets[i + 1] - x;
                return (i,
                    _tabsCloseable &&
                    r < _theme.TabButtonHorizontalPadding + _closeWidth - 4 &&
                    r > _theme.TabButtonHorizontalPadding - 4 &&
                    position.Y - _position.Y > _theme.TabButtonVerticalPadding &&
                    position.Y - _position.Y <= tabHeight - _theme.TabButtonVerticalPadding
                );
            }
        }

        return (-1, false);
    }

    private static void Swap<T>(ref T a, ref T b)
    {
        var temp = a;
        a = b;
        b = temp;
    }
}