using System.Drawing;
using FontStashSharp;
using FontStashSharp.RichText;
using NvgSharp;
using OpenTK.Mathematics;

namespace Marius.Winter.Forms;

public class Label : Widget
{
    private RichTextLayout? _captionLayout;

    protected string _caption;
    protected FontSystem _font;
    protected Color _color;

    public string Caption
    {
        get => _caption;
        set => _caption = value;
    }

    public FontSystem Font
    {
        get => _font;
        set => _font = value;
    }

    public Color Color
    {
        get => _color;
        set => _color = value;
    }

    public override Theme Theme
    {
        get => base.Theme;
        set
        {
            base.Theme = value;
            _fontSize = value.StandardFontSize;
            _color = value.TextColor;
        }
    }

    public Label(Widget? parent, string caption, FontSystem font, int fontSize = -1) : base(parent)
    {
        _caption = caption;
        _font = font;

        _fontSize = _theme.StandardFontSize;
        _color = _theme.TextColor;

        if (fontSize >= 0)
            _fontSize = fontSize;
    }

    public override Vector2i GetPreferredSize(NvgContext context)
    {
        if (string.IsNullOrEmpty(_caption))
            return new Vector2i(0, 0);

        var font = _font.GetFont(FontSize);

        _captionLayout ??= new RichTextLayout();
        _captionLayout.SupportsCommands = false;
        _captionLayout.Text = _caption;
        _captionLayout.Font = font;
        _captionLayout.Width = null;

        var bounds = _captionLayout.Measure(null);
        return new Vector2i(bounds.X, bounds.Y);
    }

    public override void Draw(NvgContext context)
    {
        base.Draw(context);

        var font = _font.GetFont(FontSize);
        context.FillColor(_color);

        _captionLayout ??= new RichTextLayout();
        _captionLayout.SupportsCommands = false;
        _captionLayout.Text = _caption;
        _captionLayout.Font = font;
        _captionLayout.Width = _size.X;

        var bounds = _captionLayout.Measure(_size.X);
        var y = _position.Y;
        if (bounds.Y < _size.Y)
            y += (_size.Y - bounds.Y) / 2;
        
        context.RichText(_captionLayout, _position.X, y);
    }
}