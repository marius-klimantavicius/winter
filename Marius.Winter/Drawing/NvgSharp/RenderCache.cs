using System;

namespace NvgSharp;

internal class RenderCache
{
    private const int MAX_VERTICES = 8192;

    private readonly bool _stencilStrokes;

    public readonly ArrayBuilder<Vertex> VertexArray = new ArrayBuilder<Vertex>();
    public readonly CallInfoBuilder Calls = new CallInfoBuilder();
    public float DevicePixelRatio;

    public int VertexCount => VertexArray.Count;

    public bool StencilStrokes => _stencilStrokes;

    public RenderCache(bool stencilStrokes)
    {
        _stencilStrokes = stencilStrokes;
    }

    public void Reset()
    {
        VertexArray.Clear();
        Calls.Clear();
    }

    public void AddVertex(float x, float y, float u, float v)
    {
        VertexArray.Append(new Vertex(x, y, u, v));
    }

    public void AddVertex(Vertex v)
    {
        VertexArray.Append(v);
    }

    private static void BuildUniform(ref Paint paint, ref Scissor scissor, float width, float fringe,
        float strokeThr, ref UniformInfo uniform)
    {
        uniform.InnerColor = paint.InnerColor.ToVector4(true);
        uniform.OuterColor = paint.OuterColor.ToVector4(true);

        if (scissor.Extent.X < -0.5f || scissor.Extent.Y < -0.5f)
        {
            uniform.ScissorMatrix.MakeZero();
            uniform.ScissorExtent.X = 1.0f;
            uniform.ScissorExtent.Y = 1.0f;
            uniform.ScissorScale.X = 1.0f;
            uniform.ScissorScale.Y = 1.0f;
        }
        else
        {
            uniform.ScissorMatrix = scissor.Transform.BuildInverse().ToMatrix();
            uniform.ScissorExtent.X = scissor.Extent.X;
            uniform.ScissorExtent.Y = scissor.Extent.Y;
            uniform.ScissorScale.X = (float)Math.Sqrt(scissor.Transform.T1 * scissor.Transform.T1 + scissor.Transform.T3 * scissor.Transform.T3) / fringe;
            uniform.ScissorScale.Y = (float)Math.Sqrt(scissor.Transform.T2 * scissor.Transform.T2 + scissor.Transform.T4 * scissor.Transform.T4) / fringe;
        }

        uniform.Extent = paint.Extent;
        uniform.StrokeMult = (width * 0.5f + fringe * 0.5f) / fringe;
        uniform.StrokeThr = strokeThr;

        uniform.Image = paint.Image;

        if (paint.Image != null)
        {
            uniform.Type = RenderType.FillImage;
        }
        else
        {
            uniform.Type = (int)RenderType.FillGradient;
            uniform.Radius = paint.Radius;
            uniform.Feather = paint.Feather;
        }

        uniform.PaintMatrix = paint.Transform.BuildInverse().ToMatrix();
    }

    public void RenderFill(ref Paint paint, ref Scissor scissor, float fringe, Bounds bounds, ReadOnlySpan<Path> paths)
    {
        var call = Calls.Add(CallType.Fill);

        if (paths.Length == 1 && paths[0].Convex)
            call.Type = CallType.ConvexFill;

        foreach (var path in paths)
        {
            var drawCallInfo = new FillStrokeInfo
            {
                FillOffset = path.FillOffset,
                FillCount = path.FillCount,
                StrokeOffset = path.StrokeOffset,
                StrokeCount = path.StrokeCount,
            };

            Calls.Add(drawCallInfo);
        }

        // Setup uniforms for draw calls
        if (call.Type == CallType.Fill)
        {
            // Quad
            call.TriangleOffset = VertexArray.Count;
            call.TriangleCount = 4;
            VertexArray.Append(new Vertex(bounds.X2, bounds.Y2, 0.5f, 1.0f));
            VertexArray.Append(new Vertex(bounds.X2, bounds.Y, 0.5f, 1.0f));
            VertexArray.Append(new Vertex(bounds.X, bounds.Y2, 0.5f, 1.0f));
            VertexArray.Append(new Vertex(bounds.X, bounds.Y, 0.5f, 1.0f));

            // Simple shader for stencil
            call.UniformInfo.StrokeThr = -1.0f;
            call.UniformInfo.Type = RenderType.Simple;

            // Fill shader
            BuildUniform(ref paint, ref scissor, fringe, fringe, -1.0f, ref call.UniformInfo2);
        }
        else
        {
            // Fill shader
            BuildUniform(ref paint, ref scissor, fringe, fringe, -1.0f, ref call.UniformInfo);
        }
    }

    public void RenderStroke(ref Paint paint, ref Scissor scissor, float fringe, float strokeWidth, ReadOnlySpan<Path> paths)
    {
        var call = Calls.Add(CallType.Stroke);

        foreach (var path in paths)
        {
            var drawCallInfo = new FillStrokeInfo
            {
                StrokeOffset = path.StrokeOffset,
                StrokeCount = path.StrokeCount,
            };

            Calls.Add(drawCallInfo);
        }

        // Setup uniforms for draw calls
        if (_stencilStrokes)
        {
            // Fill shader
            BuildUniform(ref paint, ref scissor, strokeWidth, fringe, -1.0f, ref call.UniformInfo);
            BuildUniform(ref paint, ref scissor, strokeWidth, fringe, 1.0f - 0.5f / 255.0f, ref call.UniformInfo2);
        }
        else
        {
            // Fill shader
            BuildUniform(ref paint, ref scissor, strokeWidth, fringe, -1.0f, ref call.UniformInfo);
        }
    }

    public void RenderTriangles(ref Paint paint, ref Scissor scissor, float fringe, int triangleOffset, int triangleCount)
    {
        var call = Calls.Add(CallType.Triangles);
        call.TriangleOffset = triangleOffset;
        call.TriangleCount = triangleCount;

        // Fill shader
        BuildUniform(ref paint, ref scissor, 1.0f, fringe, -1.0f, ref call.UniformInfo);
        call.UniformInfo.Type = RenderType.Image;
    }
}