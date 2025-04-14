using System;
using System.Collections.Generic;
using OpenTK.Mathematics;

namespace Marius.Winter.Forms;

public class ComboBox : PopupButton
{
    protected VScrollPanel? _scroll;
    protected Widget _container;
    protected List<string> _items = new List<string>();
    protected List<string> _itemsShort = new List<string>();
    protected int _selectedIndex;

    public event Action<ComboBox, int>? Changed;

    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            if (_itemsShort.Count == 0)
                return;

            var children = _container.Children;
            ((Button)children[_selectedIndex]).IsPressed = false;
            ((Button)children[value]).IsPressed = true;
            _selectedIndex = value;
            Caption = _itemsShort[value];
        }
    }

    public List<string> Items
    {
        get => _items;
        set => _items = value;
    }

    public List<string> ItemsShort
    {
        get => _itemsShort;
        set => _itemsShort = value;
    }

    public ComboBox(Widget? parent)
        : base(parent)
    {
        _container = Popup;
        _selectedIndex = 0;
    }

    public ComboBox(Widget? parent, List<string> items, List<string>? itemsShort = null)
        : this(parent)
    {
        SetItems(items, itemsShort);
    }

    public void SetItems(List<string> items, List<string>? itemsShort = null)
    {
        _items = items;
        _itemsShort = itemsShort ?? items;

        if (_selectedIndex < 0 || _selectedIndex >= _items.Count)
            _selectedIndex = 0;

        while (_container.ChildCount != 0)
            _container.RemoveChildAt(_container.ChildCount - 1);

        if (_scroll == null)
        {
            _scroll = new VScrollPanel(_popup)
            {
                FixedHeight = 300,
            };

            _container = new Widget(_scroll);
            _popup.Layout = new BoxLayout(Orientation.Horizontal);
        }

        _container.Layout = new GroupLayout(10);

        var index = 0;
        foreach (var str in items)
        {
            var scopedIndex = index;
            var button = new Button(_container, str)
            {
                Flags = ButtonFlags.RadioButton,
            };

            button.Clicked += _ =>
            {
                _selectedIndex = scopedIndex;
                Caption = _itemsShort[scopedIndex];
                IsPressed = false;
                Popup.IsVisible = false;

                Changed?.Invoke(this, scopedIndex);
            };
            index++;
        }

        SelectedIndex = _selectedIndex;
    }

    public override bool OnScroll(Vector2i position, Vector2 distance, Vector2 relative)
    {
        IsPressed = false;
        Popup.IsVisible = false;
        if (relative.Y < 0)
        {
            SelectedIndex = Math.Min(_selectedIndex + 1, _items.Count - 1);
            Changed?.Invoke(this, _selectedIndex);
            return true;
        }

        if (relative.Y > 0)
        {
            SelectedIndex = Math.Max(_selectedIndex - 1, 0);
            Changed?.Invoke(this, _selectedIndex);
            return true;
        }

        return base.OnScroll(position, distance, relative);
    }
}