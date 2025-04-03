namespace Marius.Winter.Forms;

public enum Cursor
{
    /// <summary>
    /// The arrow cursor.
    /// </summary>
    Arrow = 0,

    /// <summary>
    /// The I-beam cursor.
    /// </summary>
    IBeam,

    /// <summary>
    /// The crosshair cursor.
    /// </summary>
    Crosshair,

    /// <summary>
    /// The hand cursor.
    /// </summary>
    Hand,

    /// <summary>
    /// The horizontal resize cursor.
    /// </summary>
    HResize,

    /// <summary>
    /// The vertical resize cursor.
    /// </summary>
    VResize,

    /// <summary>
    /// Not a cursor --- should always be last: enables a loop over the cursor types.
    /// </summary>
    CursorCount,
}