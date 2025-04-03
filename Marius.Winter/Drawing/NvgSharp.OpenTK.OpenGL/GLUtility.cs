using OpenTK.Graphics.OpenGL;
using System;
using System.Runtime.CompilerServices;

namespace NvgSharp.OpenTK.OpenGL;

internal static class GLUtility
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void CheckError()
	{
		var error = GL.GetError();
		if (error != ErrorCode.NoError)
			ThrowError(error);
		
		return;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static void ThrowError(ErrorCode error) => throw new Exception($"GL.GetError() returned {error}");
	}

	public static void DrawStroke(this FillStrokeInfo fillStrokeInfo, PrimitiveType primitiveType)
	{
		if (fillStrokeInfo.StrokeCount <= 0)
			return;

		GL.DrawArrays(primitiveType, fillStrokeInfo.StrokeOffset, fillStrokeInfo.StrokeCount);
		CheckError();
	}

	public static void DrawFill(this FillStrokeInfo fillStrokeInfo, PrimitiveType primitiveType)
	{
		if (fillStrokeInfo.FillCount <= 0)
			return;

		GL.DrawArrays(primitiveType, fillStrokeInfo.FillOffset, fillStrokeInfo.FillCount);
		CheckError();
	}

	public static void DrawTriangles(this CallInfo callInfo, PrimitiveType primitiveType)
	{
		if (callInfo.TriangleCount <= 0)
			return;

		GL.DrawArrays(primitiveType, callInfo.TriangleOffset, callInfo.TriangleCount);
		CheckError();
	}
}