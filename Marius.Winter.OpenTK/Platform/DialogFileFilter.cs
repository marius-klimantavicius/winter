﻿namespace OpenTK.Platform;

/// <summary>
/// Describes a file filter used to filter visible files/folders in a file dialog.
/// </summary>
public struct DialogFileFilter : IEquatable<DialogFileFilter>
{
    /// <summary>
    /// The display name of the filter. Prohibited characters are <c>|</c> and <c>\0</c>.
    /// </summary>
    public string Name;

    /// <summary>
    /// The file extension filter. The format of this string is "ext1;ext2;ext3". Use <c>*</c> to match any files.
    /// </summary>
    /// <example>
    /// <code>new DialogFileFilter(){ Name="Images", Filter="png;jpg;jpeg" };</code>
    /// This creates a file filter that will match any files ending in png, jpg, or jpeg.
    /// </example>
    // FIXME: Should we just make this an array?
    // FIXME: Should we allow wildcards in general and not just extensions? e.g. "test*.png"
    public string Filter;

    /// <summary>
    /// Initializes a new instance of the <see cref="DialogFileFilter"/> struct.
    /// </summary>
    /// <param name="name">The display name of the filter.</param>
    /// <param name="filter">The filter string. <see cref="Filter"/> for format details.</param>
    /// <example>
    /// <code>new DialogFileFilter(){ Name="Images", Filter="png;jpg;jpeg" };</code>
    /// This creates a file filter that will match any files ending in png, jpg, or jpeg.
    /// </example>
    /// <seealso cref="Name"/>
    /// <seealso cref="Filter"/>
    /// <seealso cref="IDialogComponent.ShowOpenDialog(WindowHandle, string, string, DialogFileFilter[], OpenDialogOptions)"/>
    /// <seealso cref="IDialogComponent.ShowSaveDialog(WindowHandle, string, string, DialogFileFilter[], SaveDialogOptions)"/>
    public DialogFileFilter(string name, string filter)
    {
        Name = name;
        Filter = filter;
    }

    /// <inheritdoc/>
    public readonly override bool Equals(object? obj)
    {
        return obj is DialogFileFilter filter && Equals(filter);
    }

    /// <inheritdoc/>
    public readonly bool Equals(DialogFileFilter other)
    {
        return Name == other.Name &&
            Filter == other.Filter;
    }

    /// <inheritdoc/>
    public readonly override int GetHashCode()
    {
        return HashCode.Combine(Name, Filter);
    }

    /// <summary>
    /// Determines whether two specified instances of DialogFileFilter are equal.
    /// </summary>
    /// <param name="left">The first dialog file filter to compare.</param>
    /// <param name="right">The second dialog file filter to compare.</param>
    /// <returns><c>true</c> if <paramref name="left"/> equals <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    public static bool operator ==(DialogFileFilter left, DialogFileFilter right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Determines whether two specified instances of DialogFileFilter are not equal.
    /// </summary>
    /// <param name="left">The first dialog file filter to compare.</param>
    /// <param name="right">The second dialog file filter to compare.</param>
    /// <returns><c>true</c> if <paramref name="left"/> does not equal <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    public static bool operator !=(DialogFileFilter left, DialogFileFilter right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Returns a string in the form "{Name} - {Filter}".
    /// </summary>
    /// <returns>The string representation.</returns>
    public readonly override string ToString()
    {
        return $"{Name} - {Filter}";
    }
}