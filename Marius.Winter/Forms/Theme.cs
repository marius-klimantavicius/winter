using System.Drawing;
using System.IO;
using FontStashSharp;
using Microsoft.Extensions.FileProviders;

namespace Marius.Winter.Forms;

public class Theme
{
    private static readonly IFileProvider DefaultFileProvider = new EmbeddedFileProvider(typeof(Theme).Assembly, "Resources");

    public static readonly Theme Default = new Theme();

    public FontSystem FontSansRegular { get; set; }
    public FontSystem FontSansBold { get; set; }
    public FontSystem FontIcons { get; set; }
    public FontSystem FontMonoRegular { get; set; }

    public float IconScale { get; set; } = 0.6f;

    public int StandardFontSize { get; set; } = 16;
    public int ButtonFontSize { get; set; } = 20;
    public int TextBoxFontSize { get; set; } = 20;
    public int WindowCornerRadius { get; set; } = 2;
    public int WindowHeaderHeight { get; set; } = 30;
    public int WindowDropShadowSize { get; set; } = 10;
    public int ButtonCornerRadius { get; set; } = 2;
    public float TabBorderWidth { get; set; } = 0.75f;
    public int TabInnerMargin { get; set; } = 5;
    public int TabMinButtonWidth { get; set; } = 20;
    public int TabMaxButtonWidth { get; set; } = 160;
    public int TabControlWidth { get; set; } = 20;
    public int TabButtonHorizontalPadding { get; set; } = 10;
    public int TabButtonVerticalPadding { get; set; } = 2;

    public Color DropShadow { get; set; } = MakeColor(0, 128);
    public Color Transparent { get; set; } = MakeColor(0, 0);
    public Color BorderDark { get; set; } = MakeColor(29, 255);
    public Color BorderLight { get; set; } = MakeColor(92, 255);
    public Color BorderMedium { get; set; } = MakeColor(35, 255);
    public Color TextColor { get; set; } = MakeColor(255, 160);
    public Color DisabledTextColor { get; set; } = MakeColor(255, 80);
    public Color TextColorShadow { get; set; } = MakeColor(0, 160);
    public Color IconColor { get; set; }

    public Color ButtonGradientTopFocused { get; set; } = MakeColor(64, 255);
    public Color ButtonGradientBotFocused { get; set; } = MakeColor(48, 255);
    public Color ButtonGradientTopUnfocused { get; set; } = MakeColor(74, 255);
    public Color ButtonGradientBotUnfocused { get; set; } = MakeColor(58, 255);
    public Color ButtonGradientTopPushed { get; set; } = MakeColor(41, 255);
    public Color ButtonGradientBotPushed { get; set; } = MakeColor(29, 255);

    public Color WindowFillUnfocused { get; set; } = MakeColor(43, 230);
    public Color WindowFillFocused { get; set; } = MakeColor(45, 230);
    public Color WindowTitleUnfocused { get; set; } = MakeColor(220, 160);
    public Color WindowTitleFocused { get; set; } = MakeColor(255, 190);

    public Color WindowHeaderGradientTop { get; set; }
    public Color WindowHeaderGradientBot { get; set; }
    public Color WindowHeaderSepTop { get; set; }
    public Color WindowHeaderSepBot { get; set; }

    public Color WindowPopup { get; set; } = MakeColor(50, 255);
    public Color WindowPopupTransparent { get; set; } = MakeColor(50, 0);

    public FontIcon CheckBoxIcon { get; set; }
    public FontIcon MessageInformationIcon { get; set; }
    public FontIcon MessageQuestionIcon { get; set; }
    public FontIcon MessageWarningIcon { get; set; }
    public FontIcon MessageAltButtonIcon { get; set; }
    public FontIcon MessagePrimaryButtonIcon { get; set; }
    public FontIcon PopupChevronRightIcon { get; set; }
    public FontIcon PopupChevronLeftIcon { get; set; }
    public FontIcon TextBoxUpIcon { get; set; }
    public FontIcon TextBoxDownIcon { get; set; }

    public Theme()
        : this(LoadDefaultFont("Roboto-Regular.ttf"), LoadDefaultFont("Roboto-Bold.ttf"), LoadDefaultFont("FontAwesome-Solid.ttf"), LoadDefaultFont("Inconsolata-Regular.ttf"))
    {
    }

    public Theme(FontSystem fontSansRegular, FontSystem fontSansBold, FontSystem fontIcons, FontSystem fontMonoRegular)
    {
        FontSansRegular = fontSansRegular;
        FontSansBold = fontSansBold;
        FontIcons = fontIcons;
        FontMonoRegular = fontMonoRegular;

        IconColor = TextColor;

        WindowHeaderGradientTop = ButtonGradientTopUnfocused;
        WindowHeaderGradientBot = ButtonGradientBotUnfocused;
        WindowHeaderSepTop = BorderLight;
        WindowHeaderSepBot = BorderDark;

        CheckBoxIcon = new FontIcon(Icons.FA_CHECK, FontIcons);
        MessageInformationIcon = new FontIcon(Icons.FA_INFO_CIRCLE, FontIcons);
        MessageQuestionIcon = new FontIcon(Icons.FA_QUESTION_CIRCLE, FontIcons);
        MessageWarningIcon = new FontIcon(Icons.FA_EXCLAMATION_TRIANGLE, FontIcons);
        MessageAltButtonIcon = new FontIcon(Icons.FA_TIMES_CIRCLE, FontIcons);
        MessagePrimaryButtonIcon = new FontIcon(Icons.FA_CHECK, FontIcons);
        PopupChevronRightIcon = new FontIcon(Icons.FA_CHEVRON_RIGHT, FontIcons);
        PopupChevronLeftIcon = new FontIcon(Icons.FA_CHEVRON_LEFT, FontIcons);
        TextBoxUpIcon = new FontIcon(Icons.FA_CHEVRON_UP, FontIcons);
        TextBoxDownIcon = new FontIcon(Icons.FA_CHEVRON_DOWN, FontIcons);
    }

    private static Color MakeColor(int intensity, int alpha)
    {
        return Color.FromArgb(alpha, intensity, intensity, intensity);
    }

    private static FontSystem LoadDefaultFont(string name)
    {
        var fontSystem = new FontSystem();
        var fileInfo = DefaultFileProvider.GetFileInfo(name);
        if (!fileInfo.Exists)
            throw new FileNotFoundException("Font file not found", name);

        using (var stream = fileInfo.CreateReadStream())
            fontSystem.AddFont(stream);

        return fontSystem;
    }
}