//
// The Open Toolkit Library License
//
// Copyright (c) 2006 - 2009 the Open Toolkit library.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do
// so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
//

using OpenTK.Core.Utility;

#nullable enable

namespace OpenTK.Platform;

/// <summary>
/// Common interface for all platform abstraction layer components.
/// </summary>
public interface IPalComponent
{
    /// <summary>
    /// Name of the abstraction layer component.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Specifies which PAL components this object provides.
    /// </summary>
    // FIXME: Remove this?
    PalComponents Provides { get; }

    /// <summary>
    /// The logger that this component uses to log diagnostic messages.
    /// </summary>
    /// <seealso cref="ILogger"/>
    /// <seealso cref="ToolkitOptions.Logger"/>
    ILogger? Logger { get; set; }

    /// <summary>
    /// Initialize the component.
    /// </summary>
    /// <param name="options">The options to initialize the component with.</param>
    /// <seealso cref="ToolkitOptions"/>
    /// <seealso cref="Toolkit.Init(ToolkitOptions)"/>
    void Initialize(ToolkitOptions options);

    /// <summary>
    /// Uninitialize the component. Frees any native resources used by the component.
    /// </summary>
    /// <seealso cref="Toolkit.Uninit"/>
    void Uninitialize();
}