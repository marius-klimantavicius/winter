﻿using OpenTK.Core.Utility;
using static OpenTK.Platform.Native.SDL.SDL;

namespace OpenTK.Platform.Native.SDL;

public class SDLClipboardComponent : IClipboardComponent
{
    /// <inheritdoc/>
    public string Name => nameof(SDLClipboardComponent);

    /// <inheritdoc/>
    public PalComponents Provides => PalComponents.Clipboard;

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

    private readonly ClipboardFormat[] _supportedFormats = {
        ClipboardFormat.Text,
    };

    /// <inheritdoc/>
    public IReadOnlyList<ClipboardFormat> SupportedFormats => _supportedFormats;

    /// <inheritdoc/>
    public ClipboardFormat GetClipboardFormat()
    {
        if (SDL_HasClipboardText() == 1) return ClipboardFormat.Text;
        else return ClipboardFormat.None;
    }

    /// <inheritdoc/>
    public void SetClipboardText(string text)
    {
        int result = SDL_SetClipboardText(text);
        if (result < 0)
        {
            string error = SDL_GetError();
            Logger?.LogError($"SDL2 could not set the clipboard text: {error}");
        }
    }

    /// <inheritdoc/>
    public string? GetClipboardText()
    {
        if (GetClipboardFormat() == ClipboardFormat.Text)
        {
            string? text = SDL_GetClipboardText();
            if (text == "")
            {
                string error = SDL_GetError();
                Logger?.LogError($"SDL2 could not get clipboard text: {error}");
                text = null;
            }

            return text;
        }
        else
        {
            return null;
        }
    }

    /// <inheritdoc/>
    public AudioData? GetClipboardAudio()
    {
        throw new InvalidOperationException("SDL 2 doesn't support audio clipboard data.");
    }

    /// <inheritdoc/>
    public void SetClipboardBitmap(Bitmap bitmap)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Bitmap? GetClipboardBitmap()
    {
        throw new InvalidOperationException("SDL 2 doesn't support bitmap clipboard data.");
    }

    /// <inheritdoc/>
    public List<string>? GetClipboardFiles()
    {
        throw new InvalidOperationException("SDL 2 doesn't support files clipboard data.");
    }

}