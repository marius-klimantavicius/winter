namespace NvgSharp;

internal struct NvgPoint
{
	public float X;
	public float Y;
	public float DeltaX;
	public float DeltaY;
	public float Length;
	public float dmx;
	public float dmy;
	public PointFlags Flags;

	public void Reset()
	{
		this = default;
	}
}