using System;
using System.Collections.Generic;
using FontStashSharp;
using NvgSharp;
using OpenTK.Mathematics;

namespace Marius.Winter.Forms;

public class TabWidget : TabWidgetBase
{
    protected Dictionary<int, Widget> _widgets = new Dictionary<int, Widget>();
    protected bool _removeChildren = true;

    public bool RemoveChildren
    {
        get => _removeChildren;
        set => _removeChildren = value;
    }

    public TabWidget(Widget? parent, FontSystem? font = null) : base(parent, font)
    {
        _font = font ?? _theme.FontSansBold;
    }

    public int InsertTab(int index, string caption, Widget widget)
    {
        var id = base.InsertTab(index, caption);
        _widgets[id] = widget;
        UpdateVisibility();
        return id;
    }

    public int AppendTab(string caption, Widget widget)
    {
        widget.IsVisible = false;

        var id = base.AppendTab(caption);
        _widgets[id] = widget;
        UpdateVisibility();
        return id;
    }

    public override void RemoveTab(int id)
    {
        base.RemoveTab(id);
        if (_widgets.Remove(id, out var widget) && _removeChildren)
            RemoveChild(widget);
    }

    public override Vector2i GetPreferredSize(NvgContext context)
    {
        var baseSize = base.GetPreferredSize(context);
        var contentSize = new Vector2i(0);
        foreach (var child in _children)
            contentSize = Vector2i.ComponentMax(contentSize, child.GetPreferredSize(context));

        return new Vector2i(
            Math.Max(baseSize.X, contentSize.X + 2 * _padding),
            baseSize.Y + contentSize.Y + 2 * _padding
        );
    }

    public override void PerformLayout(NvgContext context)
    {
        base.PerformLayout(context);

        var tabHeight = FontSize + 2 * _theme.TabButtonVerticalPadding;
        foreach (var child in _children)
        {
            child.Position = new Vector2i(_padding, _padding + tabHeight + 1);
            child.Size = _size - new Vector2i(2 * _padding, 2 * _padding + tabHeight + 1);
            child.PerformLayout(context);
        }
    }

    protected override void UpdateVisibility()
    {
        if (TabCount == 0)
            return;

        foreach (var child in _children)
            child.IsVisible = false;

        if (_widgets.TryGetValue(SelectedTabId, out var widget))
            widget.IsVisible = true;
    }
}