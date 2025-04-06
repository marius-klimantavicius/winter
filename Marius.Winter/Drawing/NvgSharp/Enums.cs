using System;

namespace NvgSharp;

public enum Winding
{
    /// <summary>
    /// Winding for solid shapes
    /// </summary>
    CounterClockWise = 1,

    /// <summary>
    /// Winding for holes
    /// </summary>
    ClockWise = 2,
}

public enum Solidity
{
    /// <summary>
    /// CCW
    /// </summary>
    Solid = 1,

    /// <summary>
    /// CW
    /// </summary>
    Hole = 2,
}

public enum LineCap
{
    Butt,
    Round,
    Square,
    Bevel,
    Miter,
}

internal enum CommandType
{
    MoveTo = 0,
    LineTo = 1,
    BezierTo = 2,
    Close = 3,
    Winding = 4,
}

[Flags]
internal enum PointFlags
{
    Corner = 0x01,
    Left = 0x02,
    Bevel = 0x04,
    InnerBevel = 0x08,
}
