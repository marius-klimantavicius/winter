using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Color = FontStashSharp.FSColor;

namespace FontStashSharp.RichText;

public static class ColorStorage
{
    public class ColorInfo
    {
        public Color Color { get; set; }
        public string Name { get; set; }
    }

    public static readonly Dictionary<string, ColorInfo> Colors = new Dictionary<string, ColorInfo>();

    static ColorStorage()
    {
        var type = typeof(Color);
        var colors = type.GetRuntimeProperties();
        foreach (var c in colors)
        {
            if (c.PropertyType != typeof(Color))
            {
                continue;
            }

            var value = (Color)c.GetValue(null, null);
            Colors[c.Name.ToLower()] = new ColorInfo
            {
                Color = value,
                Name = c.Name,
            };
        }
    }

    public static string ToHexString(this Color c)
    {
        return $"#{c.R:X2}{c.G:X2}{c.B:X2}{c.A:X2}";
    }

    public static string GetColorName(this Color color)
    {
        foreach (var c in Colors)
        {
            if (c.Value.Color == color)
            {
                return c.Value.Name;
            }
        }

        return null;
    }

    public static Color? FromName(string name)
    {
        if (name.StartsWith("#"))
        {
            name = name.Substring(1);
            if (uint.TryParse(name, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var u))
            {
                // Parsed value contains color in RGBA form
                // Extract color components

                byte r = 0, g = 0, b = 0, a = 0;

                unchecked
                {
                    if (name.Length == 6)
                    {
                        r = (byte)(u >> 16);
                        g = (byte)(u >> 8);
                        b = (byte)u;
                        a = 255;
                    }
                    else if (name.Length == 8)
                    {
                        r = (byte)(u >> 24);
                        g = (byte)(u >> 16);
                        b = (byte)(u >> 8);
                        a = (byte)u;
                    }
                }

                return new Color(r, g, b, a);
            }
        }
        else
        {
            if (Colors.TryGetValue(name.ToLower(), out var result))
            {
                return result.Color;
            }
        }

        return null;
    }

    public static Color CreateColor(int r, int g, int b, int a = 255)
    {
        return new Color((byte)r, (byte)g, (byte)b, (byte)a);
    }
}