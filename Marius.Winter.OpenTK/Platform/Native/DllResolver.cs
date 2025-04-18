﻿using System.Reflection;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Native;

internal class DllResolver
{
    static DllResolver()
    {
        NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), DllImportResolver);
    }

    /// <summary>
    /// Called to trigger the static constructor.
    /// </summary>
    public static void InitLoader() { }

    public static IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (OperatingSystem.IsLinux() && LinuxLibraryList.TryGetValue(libraryName, out string[]? names))
        {
            foreach(string name in names)
            {
                if (NativeLibrary.TryLoad(name, assembly, searchPath, out IntPtr lib))
                    return lib;
            }

            throw new DllNotFoundException($"Could not find any of these libraries '{string.Join(", ", names)}' (this load is intercepted, specified in DllImport as '{libraryName}'). Either this library is not installed or this is an OpenTK library resolution bug.");
        }

        return IntPtr.Zero;
    }

    /// <summary>
    /// A dictionary of a priority list of library search names for the
    /// Linux family of operating systems.
    /// </summary>
    private static readonly Dictionary<string, string[]> LinuxLibraryList =
        new Dictionary<string, string[]>
        {
            ["GL"] = new string[]
            {
                "libGL.so",
                "libGL.so.1",
                "libGL.so.0",
            },

            ["X11"] = new string[]
            {
                "libX11.so",
                "libX11.so.6",
                "libX11.so.5",
                "libX11.so.4",
                "libX11.so.3",
                "libX11.so.2",
                "libX11.so.1",
                "libX11.so.0",
            },

            ["X11XCB"] = new string[]
            {
                "libX11-xcb.so",
                "libX11-xcb.so.1",
            },

            ["XCB"] = new string[]
            {
                "libxcb.so",
                "libxcb.so.1",
            },

            ["Xrandr"] = new string[]
            {
                "libXrandr.so",
                "libXrandr.so.3",
                "libXrandr.so.2",
                "libXrandr.so.1",
            },

            ["XFixes"] = new string[]
            {
                "libXfixes.so",
                "libXfixes.so.5",
                "libXfixes.so.4",
                "libXfixes.so.3",
                "libXfixes.so.2",
                "libXfixes.so.1",
            },

            ["Xcursor"] = new string[]
            {
                "libXcursor.so",
                "libXcursor.so.1",
            },

            ["Xkb"] = new string[]
            {
                "libX11.so",
                "libX11.so.6",
                "libX11.so.5",
                "libX11.so.4",
                "libX11.so.3",
                "libX11.so.2",
                "libX11.so.1",
                "libX11.so.0",
            },

            ["XI2"] = new string[]
            {
                "libxcb-xinput.so.0",
            },

            ["XScreenSaver"] = new string[]
            {
                "libXss.so",
                "libXss.so.1",
            },

            ["Gio"] = new string[]
            {
                "libgio-2.0.so",
                "libgio-2.0.so.0",
            },

            ["SDL2"] = new string[]
            {
                "libSDL2-2.0.so",
                // FIXME: Complete this list with a more comprehensive collection of names.
                "libSDL2-2.0.so.0.2600.5",
            },
        };
}