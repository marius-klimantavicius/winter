using System;
using System.Drawing;
using System.Numerics;
using Matrix = System.Numerics.Matrix4x4;
using Texture2D = System.Object;

namespace NvgSharp;

public enum CallType
{
	Fill,
	ConvexFill,
	Stroke,
	Triangles,
}

public enum RenderType
{
	FillGradient,
	FillImage,
	Simple,
	Image,
}

public struct UniformInfo
{
	public Matrix ScissorMatrix;
	public Matrix PaintMatrix;
	public Vector4 InnerColor;
	public Vector4 OuterColor;
	public Vector2 ScissorExtent;
	public Vector2 ScissorScale;
	public Vector2 Extent;
	public float Radius;
	public float Feather;
	public float StrokeMult;
	public float StrokeThr;
	public Texture2D? Image;
	public RenderType Type;
}

public struct FillStrokeInfo
{
	public int FillOffset;
	public int FillCount;
	public int StrokeOffset;
	public int StrokeCount;
}

public class CallInfo
{
	internal ArrayBuilder<FillStrokeInfo>? _fillStrokeInfos;
	internal int _startIndex;
	internal int _count;
	
	public CallType Type;
	public UniformInfo UniformInfo, UniformInfo2;
	public ReadOnlyMemory<FillStrokeInfo> FillStrokeInfos => new ReadOnlyMemory<FillStrokeInfo>(_fillStrokeInfos!.Buffer, _startIndex, _count);
	public int TriangleOffset;
	public int TriangleCount;
}

public interface INvgRenderer
{
	/// <summary>
	/// Creates a texture of the specified size
	/// </summary>
	/// <param name="width"></param>
	/// <param name="height"></param>
	/// <returns></returns>
	object CreateTexture(int width, int height);

	/// <summary>
	/// Returns size of the specified texture
	/// </summary>
	/// <param name="texture"></param>
	/// <returns></returns>
	Point GetTextureSize(object texture);

	/// <summary>
	/// Sets RGBA data at the specified bounds
	/// </summary>
	/// <param name="bounds"></param>
	/// <param name="data"></param>
	void SetTextureData(object texture, Rectangle bounds, byte[] data);

	void Draw(float devicePixelRatio, ReadOnlySpan<CallInfo> calls, ReadOnlySpan<Vertex> vertexes);
}