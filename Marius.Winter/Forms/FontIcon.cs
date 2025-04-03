using System.Collections.Concurrent;
using FontStashSharp;

namespace Marius.Winter.Forms;

public class FontIcon : Icon
{
    private static readonly ConcurrentDictionary<int, string> IconTextCache = new ConcurrentDictionary<int, string>();

    public string IconText { get; }
    public FontSystem IconFont { get; }
    
    public FontIcon(string iconText, FontSystem iconFont)
    {
        IconText = iconText;
        IconFont = iconFont;
    }

    public FontIcon(int iconCode, FontSystem iconFont)
    {
        IconText = IconTextCache.GetOrAdd(iconCode, static s => char.ConvertFromUtf32(s));
        IconFont = iconFont;
    }
    
    public static string GetText(int iconCode)
    {
        return IconTextCache.GetOrAdd(iconCode, static s => char.ConvertFromUtf32(s));
    }
}