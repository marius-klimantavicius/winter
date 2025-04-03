﻿using System.Diagnostics;

namespace OpenTK.Core.Utility;

/// <summary>
/// A logger that uses <see cref="Debug"/> to write messages to the debug log.
/// </summary>
public class DebugLogger : ILogger
{
    /// <inheritdoc />
    public LogLevel Filter { get; set; } = LogLevel.Debug;

    void ILogger.LogInternal(string str, LogLevel level, string filePath, int lineNumber, string member)
    {
        if (level < Filter)
        {
            return;
        }

        Debug.Write($"[{level}] {member} {Path.GetFileName(filePath)}:{lineNumber} ");
        Debug.WriteLine(str);
    }

    void ILogger.Flush()
    {
        Debug.Flush();
    }
}