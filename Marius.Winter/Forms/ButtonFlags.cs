using System;

namespace Marius.Winter.Forms;

[Flags]
public enum ButtonFlags
{
    NormalButton = 1 << 0,
    RadioButton = 1 << 1,
    ToggleButton = 1 << 2,
    PopupButton = 1 << 3,
    MenuButton = 1 << 4,
}