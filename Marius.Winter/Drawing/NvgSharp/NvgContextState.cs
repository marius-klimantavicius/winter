namespace NvgSharp;

internal struct NvgContextState
{
	public int ShapeAntiAlias;
	public Paint Fill;
	public Paint Stroke;
	public float StrokeWidth;
	public float MiterLimit;
	public LineCap LineJoin;
	public LineCap LineCap;
	public float Alpha;
	public Transform Transform;
	public Scissor Scissor;

	public NvgContextState Clone()
	{
		return new NvgContextState
		{
			ShapeAntiAlias = ShapeAntiAlias,
			Fill = Fill,
			Stroke = Stroke,
			StrokeWidth = StrokeWidth,
			MiterLimit = MiterLimit,
			LineJoin = LineJoin,
			LineCap = LineCap,
			Alpha = Alpha,
			Transform = Transform,
			Scissor = Scissor,
		};
	}
}