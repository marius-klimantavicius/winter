using OpenTK.Mathematics;

namespace Marius.Winter.Forms;

public class ToolButton : Button
{
    public ToolButton(Widget? parent, string caption = "", Icon? icon = null) 
        : base(parent, caption, icon)
    {
        Flags = ButtonFlags.RadioButton | ButtonFlags.ToggleButton;
        FixedSize = new Vector2i(25, 25);
    }
}