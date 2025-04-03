﻿using OpenTK.Core.Utility;
using static OpenTK.Platform.Native.SDL.SDL;

namespace OpenTK.Platform.Native.SDL;

public class SDLIconComponent : IIconComponent
{
    /// <inheritdoc/>
    public string Name => nameof(SDLIconComponent);

    /// <inheritdoc/>
    public PalComponents Provides => PalComponents.WindowIcon;

    /// <inheritdoc/>
    public ILogger? Logger { get; set; }

    /// <inheritdoc/>
    public void Initialize(ToolkitOptions options)
    {
    }

    /// <inheritdoc/>
    public void Uninitialize()
    {
    }

    /// <inheritdoc/>
    public bool CanLoadSystemIcons => false;

    /// <inheritdoc/>
    public IconHandle Create(SystemIconType systemIcon)
    {
        throw new PlatformNotSupportedException("SDL2 can't load system icons.");
    }

    /// <inheritdoc/>
    public unsafe IconHandle Create(int width, int height, ReadOnlySpan<byte> data)
    {
        SDLIcon icon = new SDLIcon();

        if (width < 0) throw new ArgumentOutOfRangeException($"Width cannot be negative. Value: {width}");
        if (height < 0) throw new ArgumentOutOfRangeException($"Height cannot be negative. Value: {height}");

        if (data.Length < width * height * 4) throw new ArgumentException($"The given span is too small. It must be at least {width * height * 4} long. Was: {data.Length}");

        SDL_Surface* surface = SDL_CreateRGBSurfaceWithFormat(0, width, height, 32, SDL_PixelFormatEnum.SDL_PIXELFORMAT_ABGR8888);

        SDL_LockSurface(surface);

        fixed (byte* ptr = data)
        {
            Buffer.MemoryCopy(ptr, surface->pixels, surface->pitch * height, data.Length);
        }

        SDL_UnlockSurface(surface);

        icon.Surface = surface;

        return icon;
    }

    /// <inheritdoc/>
    public unsafe void Destroy(IconHandle handle)
    {
        SDLIcon icon = handle.As<SDLIcon>(this);

        if (icon.Surface != null)
        {
            SDL_FreeSurface(icon.Surface);
            icon.Surface = null;
        }
    }

    /// <inheritdoc/>
    public unsafe void GetSize(IconHandle handle, out int width, out int height)
    {
        SDLIcon icon = handle.As<SDLIcon>(this);

        width = icon.Surface->w;
        height = icon.Surface->h;
    }

    public unsafe void GetBitmapData(IconHandle handle, Span<byte> data)
    {
        SDLIcon icon = handle.As<SDLIcon>(this);

        SDL_LockSurface(icon.Surface);

        // Here we rely on sdl having the same pixel format as we do.
        Span<byte> surfaceData = new Span<byte>(icon.Surface->pixels, data.Length);
        surfaceData.CopyTo(data);

        SDL_UnlockSurface(icon.Surface);
    }

    public unsafe int GetBitmapByteSize(IconHandle handle)
    {
        SDLIcon icon = handle.As<SDLIcon>(this);

        return icon.Surface->w * icon.Surface->h * 4;
    }
}