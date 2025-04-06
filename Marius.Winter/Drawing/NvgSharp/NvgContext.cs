using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using Texture2D = System.Object;

namespace NvgSharp;

public class NvgContext
{
    private struct RectF
    {
        public readonly float X;
        public readonly float Y;
        public readonly float Width;
        public readonly float Height;

        public RectF(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }

    private float _commandX;
    private float _commandY;
    private float _distTol;
    private readonly bool _edgeAntiAlias;
    private readonly Stack<NvgContextState> _savedStates = new Stack<NvgContextState>();
    private float _tessTol;
    private readonly List<Command> _commands = new List<Command>();
    private readonly ArrayBuilder<Path> _pathsCache = new ArrayBuilder<Path>();
    private Bounds _bounds;
    internal float _fringeWidth;
    internal NvgContextState _currentState;
    internal readonly RenderCache _renderCache;
    internal readonly INvgRenderer _renderer;

    internal object? _textRenderer;

    public bool EdgeAntiAlias => _edgeAntiAlias;
    public bool StencilStrokes => _renderCache.StencilStrokes;

    public float DevicePixelRatio
    {
        get => _renderCache.DevicePixelRatio;

        set
        {
            _tessTol = 0.25f / value;
            _distTol = 0.01f / value;
            _fringeWidth = 1.0f / value;
            _renderCache.DevicePixelRatio = value;
        }
    }

    public NvgContext(INvgRenderer renderer, bool edgeAntiAlias = true, bool stencilStrokes = true)
    {
        _renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
        _edgeAntiAlias = edgeAntiAlias;

        _renderCache = new RenderCache(stencilStrokes);
        ResetState();
        DevicePixelRatio = 1.0f;
    }

    public void Flush()
    {
        _renderer.Draw(_renderCache.DevicePixelRatio, _renderCache.Calls.AsSpan(), _renderCache.VertexArray.AsSpan());
        _renderCache.Reset();
    }

    public void SaveState()
    {
        _savedStates.Push(_currentState);
        _currentState = _currentState.Clone();
    }

    public void RestoreState()
    {
        _currentState = _savedStates.Pop();
    }

    public void ResetState()
    {
        _currentState.Fill = new Paint(Color.White);
        _currentState.Stroke = new Paint(Color.Black);
        _currentState.ShapeAntiAlias = 1;
        _currentState.StrokeWidth = 1.0f;
        _currentState.MiterLimit = 10.0f;
        _currentState.LineCap = NvgSharp.LineCap.Butt;
        _currentState.LineJoin = NvgSharp.LineCap.Miter;
        _currentState.Alpha = 1.0f;
        _currentState.Transform.SetIdentity();
        _currentState.Scissor.Extent.X = -1.0f;
        _currentState.Scissor.Extent.Y = -1.0f;
    }

    public void ShapeAntiAlias(int enabled)
    {
        _currentState.ShapeAntiAlias = enabled;
    }

    public void StrokeWidth(float width)
    {
        _currentState.StrokeWidth = width;
    }

    public void MiterLimit(float limit)
    {
        _currentState.MiterLimit = limit;
    }

    public void LineCap(LineCap cap)
    {
        _currentState.LineCap = cap;
    }

    public void LineJoin(LineCap join)
    {
        _currentState.LineJoin = join;
    }

    public void GlobalAlpha(float alpha)
    {
        _currentState.Alpha = alpha;
    }

    public void Transform(float a, float b, float c, float d, float e, float f)
    {
        Transform t;
        t.T1 = a;
        t.T2 = b;
        t.T3 = c;
        t.T4 = d;
        t.T5 = e;
        t.T6 = f;

        _currentState.Transform.Premultiply(ref t);
    }

    public void ResetTransform()
    {
        _currentState.Transform.SetIdentity();
    }

    public void Translate(float x, float y)
    {
        var t = new Transform();
        t.SetTranslate(x, y);
        _currentState.Transform.Premultiply(ref t);
    }

    public void Rotate(float angle)
    {
        var t = new Transform();
        t.SetRotate(angle);
        _currentState.Transform.Premultiply(ref t);
    }

    public void SkewX(float angle)
    {
        var t = new Transform();
        t.SetSkewX(angle);
        _currentState.Transform.Premultiply(ref t);
    }

    public void SkewY(float angle)
    {
        var t = new Transform();
        t.SetSkewY(angle);
        _currentState.Transform.Premultiply(ref t);
    }

    public void Scale(float x, float y)
    {
        var t = new Transform();
        t.SetScale(x, y);
        _currentState.Transform.Premultiply(ref t);
    }

    public void CurrentTransform(Transform xform)
    {
        _currentState.Transform = xform;
    }

    public void StrokeColor(Color color)
    {
        _currentState.Stroke = new Paint(color);
    }

    public void StrokePaint(Paint paint)
    {
        _currentState.Stroke = paint;
        _currentState.Stroke.Transform.Multiply(ref _currentState.Transform);
    }

    public void FillColor(Color color)
    {
        _currentState.Fill = new Paint(color);
    }

    public void FillPaint(Paint paint)
    {
        _currentState.Fill = paint;
        _currentState.Fill.Transform.Multiply(ref _currentState.Transform);
    }

    public Paint LinearGradient(float sx, float sy, float ex, float ey, Color icol, Color ocol)
    {
        var p = new Paint();
        var large = (float)1e5;
        var dx = ex - sx;
        var dy = ey - sy;
        var d = (float)Math.Sqrt(dx * dx + dy * dy);
        if (d > 0.0001f)
        {
            dx /= d;
            dy /= d;
        }
        else
        {
            dx = 0;
            dy = 1;
        }

        p.Transform.T1 = dy;
        p.Transform.T2 = -dx;
        p.Transform.T3 = dx;
        p.Transform.T4 = dy;
        p.Transform.T5 = sx - dx * large;
        p.Transform.T6 = sy - dy * large;
        p.Extent.X = large;
        p.Extent.Y = large + d * 0.5f;
        p.Radius = 0.0f;
        p.Feather = Math.Max(1.0f, d);
        p.InnerColor = icol;
        p.OuterColor = ocol;
        return p;
    }

    public Paint RadialGradient(float cx, float cy, float inr, float outr, Color icol, Color ocol)
    {
        var p = new Paint();
        var r = (inr + outr) * 0.5f;
        var f = outr - inr;
        p.Transform.SetIdentity();
        p.Transform.T5 = cx;
        p.Transform.T6 = cy;
        p.Extent.X = r;
        p.Extent.Y = r;
        p.Radius = r;
        p.Feather = Math.Max(1.0f, f);
        p.InnerColor = icol;
        p.OuterColor = ocol;
        return p;
    }

    public Paint BoxGradient(float x, float y, float w, float h, float r, float f, Color icol, Color ocol)
    {
        var p = new Paint();
        p.Transform.SetIdentity();
        p.Transform.T5 = x + w * 0.5f;
        p.Transform.T6 = y + h * 0.5f;
        p.Extent.X = w * 0.5f;
        p.Extent.Y = h * 0.5f;
        p.Radius = r;
        p.Feather = Math.Max(1.0f, f);
        p.InnerColor = icol;
        p.OuterColor = ocol;
        return p;
    }

    public Paint ImagePattern(float cx, float cy, float w, float h, float angle, Texture2D image, float alpha)
    {
        var p = new Paint();
        p.Transform.SetRotate(angle);
        p.Transform.T5 = cx;
        p.Transform.T6 = cy;
        p.Extent.X = w;
        p.Extent.Y = h;
        p.Image = image;
        p.InnerColor = p.OuterColor = NvgUtility.FromRGBA(255, 255, 255, (byte)(int)(255 * alpha));
        return p;
    }

    public void Scissor(float x, float y, float w, float h)
    {
        w = Math.Max(0.0f, w);
        h = Math.Max(0.0f, h);
        _currentState.Scissor.Transform.SetIdentity();
        _currentState.Scissor.Transform.T5 = x + w * 0.5f;
        _currentState.Scissor.Transform.T6 = y + h * 0.5f;
        _currentState.Scissor.Transform.Multiply(ref _currentState.Transform);
        _currentState.Scissor.Extent.X = w * 0.5f;
        _currentState.Scissor.Extent.Y = h * 0.5f;
    }

    public void IntersectScissor(float x, float y, float w, float h)
    {
        if (_currentState.Scissor.Extent.X < 0)
        {
            Scissor(x, y, w, h);
            return;
        }

        var pxform = _currentState.Scissor.Transform;
        var ex = _currentState.Scissor.Extent.X;
        var ey = _currentState.Scissor.Extent.Y;
        var invxorm = _currentState.Transform.BuildInverse();
        pxform.Multiply(ref invxorm);
        var tex = ex * Math.Abs(pxform.T1) + ey * Math.Abs(pxform.T3);
        var tey = ex * Math.Abs(pxform.T2) + ey * Math.Abs(pxform.T4);
        var rect = __isectRects(pxform.T5 - tex, pxform.T6 - tey, tex * 2, tey * 2, x, y, w, h);
        Scissor(rect.X, rect.Y, rect.Width, rect.Height);
    }

    public void ResetScissor()
    {
        _currentState.Scissor.Transform.Zero();
        _currentState.Scissor.Extent.X = -1.0f;
        _currentState.Scissor.Extent.Y = -1.0f;
    }

    public void BeginPath()
    {
        _commands.Clear();

        foreach (var item in _pathsCache.AsSpan())
            item.Clear();

        _pathsCache.Clear();
    }

    public void MoveTo(float x, float y) => AppendCommand(CommandType.MoveTo, x, y);

    public void LineTo(float x, float y) => AppendCommand(CommandType.LineTo, x, y);

    public void BezierTo(float c1x, float c1y, float c2x, float c2y, float x, float y) =>
        AppendCommand(c1x, c1y, c2x, c2y, x, y);

    public void QuadTo(float cx, float cy, float x, float y)
    {
        var x0 = _commandX;
        var y0 = _commandY;

        AppendCommand(x0 + 2.0f / 3.0f * (cx - x0), y0 + 2.0f / 3.0f * (cy - y0),
            x + 2.0f / 3.0f * (cx - x), y + 2.0f / 3.0f * (cy - y), x, y);
    }

    public void ArcTo(float x1, float y1, float x2, float y2, float radius)
    {
        var x0 = _commandX;
        var y0 = _commandY;

        if (_commands.Count == 0)
            return;

        if (__ptEquals(x0, y0, x1, y1, _distTol) != 0 || __ptEquals(x1, y1, x2, y2, _distTol) != 0 ||
            __distPtSeg(x1, y1, x0, y0, x2, y2) < _distTol * _distTol || radius < _distTol)
        {
            LineTo(x1, y1);
            return;
        }

        var dx0 = x0 - x1;
        var dy0 = y0 - y1;
        var dx1 = x2 - x1;
        var dy1 = y2 - y1;
        NvgUtility.Normalize(ref dx0, ref dy0);
        NvgUtility.Normalize(ref dx1, ref dy1);
        var a = NvgUtility.AcosF(dx0 * dx1 + dy0 * dy1);
        var d = radius / NvgUtility.TanF(a / 2.0f);
        if (d > 10000.0f)
        {
            LineTo(x1, y1);
            return;
        }

        float cx, cy, a0, a1;
        Winding dir;
        if (NvgUtility.Cross(dx0, dy0, dx1, dy1) > 0.0f)
        {
            cx = x1 + dx0 * d + dy0 * radius;
            cy = y1 + dy0 * d + -dx0 * radius;
            a0 = NvgUtility.Atan2F(dx0, -dy0);
            a1 = NvgUtility.Atan2F(-dx1, dy1);
            dir = Winding.ClockWise;
        }
        else
        {
            cx = x1 + dx0 * d + -dy0 * radius;
            cy = y1 + dy0 * d + dx0 * radius;
            a0 = NvgUtility.Atan2F(-dx0, dy0);
            a1 = NvgUtility.Atan2F(dx1, -dy1);
            dir = Winding.CounterClockWise;
        }

        Arc(cx, cy, radius, a0, a1, dir);
    }

    public void ClosePath() => AppendCommand(CommandType.Close);

    public void PathWinding(Solidity dir) => AppendCommand(dir);

    public void Arc(float cx, float cy, float r, float a0, float a1, Winding dir)
    {
        var px = (float)0;
        var py = (float)0;
        var ptanx = (float)0;
        var ptany = (float)0;
        var move = _commands.Count > 0 ? CommandType.LineTo : CommandType.MoveTo;
        var da = a1 - a0;
        if (dir == Winding.ClockWise)
        {
            if (Math.Abs(da) >= NvgUtility.PI * 2)
                da = NvgUtility.PI * 2;
            else
                while (da < 0.0f)
                    da += NvgUtility.PI * 2;
        }
        else
        {
            if (Math.Abs(da) >= NvgUtility.PI * 2)
                da = -NvgUtility.PI * 2;
            else
                while (da > 0.0f)
                    da -= NvgUtility.PI * 2;
        }

        var ndivs = Math.Max(1, Math.Min((int)(Math.Abs(da) / (NvgUtility.PI * 0.5f) + 0.5f), 5));
        var hda = da / ndivs / 2.0f;
        var kappa = Math.Abs(4.0f / 3.0f * (1.0f - NvgUtility.CosF(hda)) / NvgUtility.SinF(hda));
        if (dir == Winding.CounterClockWise)
            kappa = -kappa;
        for (var i = 0; i <= ndivs; i++)
        {
            var a = a0 + da * (i / (float)ndivs);
            var dx = NvgUtility.CosF(a);
            var dy = NvgUtility.SinF(a);
            var x = cx + dx * r;
            var y = cy + dy * r;
            var tanx = -dy * r * kappa;
            var tany = dx * r * kappa;
            if (i == 0)
            {
                AppendCommand(move, x, y);
            }
            else
            {
                AppendCommand(px + ptanx, py + ptany, x - tanx, y - tany, x, y);
            }

            px = x;
            py = y;
            ptanx = tanx;
            ptany = tany;
        }
    }

    public void Rect(float x, float y, float w, float h)
    {
        AppendCommand(CommandType.MoveTo, x, y);
        AppendCommand(CommandType.LineTo, x, y + h);
        AppendCommand(CommandType.LineTo, x + w, y + h);
        AppendCommand(CommandType.LineTo, x + w, y);
        AppendCommand(CommandType.Close);
    }

    public void RoundedRect(float x, float y, float w, float h, float r) => RoundedRectVarying(x, y, w, h, r, r, r, r);

    public void RoundedRectVarying(float x, float y, float w, float h, float radTopLeft, float radTopRight,
        float radBottomRight, float radBottomLeft)
    {
        if (radTopLeft < 0.1f && radTopRight < 0.1f && radBottomRight < 0.1f && radBottomLeft < 0.1f)
        {
            Rect(x, y, w, h);
        }
        else
        {
            var halfw = Math.Abs(w) * 0.5f;
            var halfh = Math.Abs(h) * 0.5f;
            var rxBL = Math.Min(radBottomLeft, halfw) * Math.Sign(w);
            var ryBL = Math.Min(radBottomLeft, halfh) * Math.Sign(h);
            var rxBR = Math.Min(radBottomRight, halfw) * Math.Sign(w);
            var ryBR = Math.Min(radBottomRight, halfh) * Math.Sign(h);
            var rxTR = Math.Min(radTopRight, halfw) * Math.Sign(w);
            var ryTR = Math.Min(radTopRight, halfh) * Math.Sign(h);
            var rxTL = Math.Min(radTopLeft, halfw) * Math.Sign(w);
            var ryTL = Math.Min(radTopLeft, halfh) * Math.Sign(h);
            AppendCommand(CommandType.MoveTo, x, y + ryTL);
            AppendCommand(CommandType.LineTo, x, y + h - ryBL);
            AppendCommand(x, y + h - ryBL * (1 - NvgUtility.NVG_KAPPA90), x + rxBL * (1 - NvgUtility.NVG_KAPPA90), y + h, x + rxBL, y + h);
            AppendCommand(CommandType.LineTo, x + w - rxBR, y + h);
            AppendCommand(x + w - rxBR * (1 - NvgUtility.NVG_KAPPA90), y + h, x + w, y + h - ryBR * (1 - NvgUtility.NVG_KAPPA90), x + w, y + h - ryBR);
            AppendCommand(CommandType.LineTo, x + w, y + ryTR);
            AppendCommand(x + w, y + ryTR * (1 - NvgUtility.NVG_KAPPA90), x + w - rxTR * (1 - NvgUtility.NVG_KAPPA90), y, x + w - rxTR, y);
            AppendCommand(CommandType.LineTo, x + rxTL, y);
            AppendCommand(x + rxTL * (1 - NvgUtility.NVG_KAPPA90), y, x, y + ryTL * (1 - NvgUtility.NVG_KAPPA90), x, y + ryTL);
            AppendCommand(CommandType.Close);
        }
    }

    public void Ellipse(float cx, float cy, float rx, float ry)
    {
        AppendCommand(CommandType.MoveTo, cx - rx, cy);
        AppendCommand(cx - rx, cy + ry * NvgUtility.NVG_KAPPA90, cx - rx * NvgUtility.NVG_KAPPA90, cy + ry, cx, cy + ry);
        AppendCommand(cx + rx * NvgUtility.NVG_KAPPA90, cy + ry, cx + rx, cy + ry * NvgUtility.NVG_KAPPA90, cx + rx, cy);
        AppendCommand(cx + rx, cy - ry * NvgUtility.NVG_KAPPA90, cx + rx * NvgUtility.NVG_KAPPA90, cy - ry, cx, cy - ry);
        AppendCommand(cx - rx * NvgUtility.NVG_KAPPA90, cy - ry, cx - rx, cy - ry * NvgUtility.NVG_KAPPA90, cx - rx, cy);
        AppendCommand(CommandType.Close);
    }

    public void Circle(float cx, float cy, float r) => Ellipse(cx, cy, r, r);

    /*		public void DebugDumpPathCache()
            {
                NVGpath path;
                int i = 0;
                int j = 0;
                printf("Dumping %d cached paths\n", (int)(cache.Paths.Count));
                for (i = (int)(0); (i) < (cache.Paths.Count); i++)
                {
                    path = &cache.Paths[i];
                    printf(" - Path %d\n", (int)(i));
                    if ((path.nfill) != 0)
                    {
                        printf("   - fill: %d\n", (int)(path.nfill));
                        for (j = (int)(0); (j) < (path.nfill); j++)
                        {
                            printf("%f\t%f\n", (double)(path.Fill[j].X), (double)(path.Fill[j].Y));
                        }
                    }
                    if ((path.nstroke) != 0)
                    {
                        printf("   - stroke: %d\n", (int)(path.nstroke));
                        for (j = (int)(0); (j) < (path.nstroke); j++)
                        {
                            printf("%f\t%f\n", (double)(path.Stroke[j].X), (double)(path.Stroke[j].Y));
                        }
                    }
                }
            }*/

    internal static void MultiplyAlpha(ref Color c, float alpha)
    {
        var na = (byte)(int)(c.A * alpha);

        c = NvgUtility.FromRGBA(c.R, c.G, c.B, na);
    }

    public void Fill()
    {
        var fillPaint = _currentState.Fill;
        __flattenPaths();
        if (_edgeAntiAlias && _currentState.ShapeAntiAlias != 0)
            __expandFill(_fringeWidth, NvgSharp.LineCap.Miter, 2.4f);
        else
            __expandFill(0.0f, NvgSharp.LineCap.Miter, 2.4f);
        MultiplyAlpha(ref fillPaint.InnerColor, _currentState.Alpha);
        MultiplyAlpha(ref fillPaint.OuterColor, _currentState.Alpha);

        _renderCache.RenderFill(ref fillPaint, ref _currentState.Scissor, _fringeWidth, _bounds, _pathsCache.AsSpan());
    }

    public void Stroke()
    {
        var scale = __getAverageScale(ref _currentState.Transform);
        var strokeWidth = NvgUtility.ClampF(_currentState.StrokeWidth * scale, 0.0f, 200.0f);
        var strokePaint = _currentState.Stroke;
        if (strokeWidth < _fringeWidth)
        {
            var alpha = NvgUtility.ClampF(strokeWidth / _fringeWidth, 0.0f, 1.0f);

            MultiplyAlpha(ref strokePaint.InnerColor, alpha * alpha);
            MultiplyAlpha(ref strokePaint.OuterColor, alpha * alpha);
            strokeWidth = _fringeWidth;
        }

        MultiplyAlpha(ref strokePaint.InnerColor, _currentState.Alpha);
        MultiplyAlpha(ref strokePaint.OuterColor, _currentState.Alpha);

        __flattenPaths();
        if (_edgeAntiAlias && _currentState.ShapeAntiAlias != 0)
            __expandStroke(strokeWidth * 0.5f, _fringeWidth, _currentState.LineCap, _currentState.LineJoin, _currentState.MiterLimit);
        else
            __expandStroke(strokeWidth * 0.5f, 0.0f, _currentState.LineCap, _currentState.LineJoin, _currentState.MiterLimit);
        _renderCache.RenderStroke(ref strokePaint, ref _currentState.Scissor, _fringeWidth, strokeWidth, _pathsCache.AsSpan());
    }

    private void AppendCommand(Command command)
    {
        if (command.Type != CommandType.Close && command.Type != CommandType.Winding)
        {
            _commandX = command.P1;
            _commandY = command.P2;
        }

        switch (command.Type)
        {
            case CommandType.LineTo:
            case CommandType.MoveTo:
                _currentState.Transform.TransformPoint(out command.P1, out command.P2, command.P1, command.P2);
                break;
            case CommandType.BezierTo:
                _currentState.Transform.TransformPoint(out command.P1, out command.P2, command.P1, command.P2);
                _currentState.Transform.TransformPoint(out command.P3, out command.P4, command.P3, command.P4);
                _currentState.Transform.TransformPoint(out command.P5, out command.P6, command.P5, command.P6);
                break;
        }

        _commands.Add(command);
    }

    private void AppendCommand(CommandType type) => AppendCommand(new Command(type));
    private void AppendCommand(Solidity solidity) => AppendCommand(new Command(solidity));
    private void AppendCommand(CommandType type, float p1, float p2) => AppendCommand(new Command(type, p1, p2));

    private void AppendCommand(float p1, float p2, float p3, float p4, float p5, float p6) =>
        AppendCommand(new Command(p1, p2, p3, p4, p5, p6));

    private ref Path GetLastPath()
    {
        if (_pathsCache.Count > 0)
            return ref _pathsCache[_pathsCache.Count - 1];

        return ref Unsafe.NullRef<Path>();
    }

    private ref Path __addPath()
    {
        var newPath = new Path
        {
            Winding = Winding.CounterClockWise,
        };

        var index = _pathsCache.Append(newPath);
        return ref _pathsCache[index];
    }

    private void __addPoint(float x, float y, PointFlags flags)
    {
        ref var path = ref GetLastPath();
        if (Unsafe.IsNullRef(ref path))
            return;

        NvgPoint pt;
        if (path.Count > 0)
        {
            pt = path.LastPoint;
            if (__ptEquals(pt.X, pt.Y, x, y, _distTol) != 0)
            {
                pt.flags |= flags;
                return;
            }
        }

        pt = new NvgPoint();
        pt.Reset();
        pt.X = x;
        pt.Y = y;
        pt.flags = flags;
        path.Append(pt);
    }

    private void __closePath()
    {
        ref var path = ref GetLastPath();
        if (Unsafe.IsNullRef(ref path))
            return;

        path.Closed = true;
    }

    private void __pathWinding(Winding winding)
    {
        ref var path = ref GetLastPath();
        if (Unsafe.IsNullRef(ref path))
            return;

        path.Winding = winding;
    }

    private void __tesselateBezier(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4,
        int level, PointFlags type)
    {
        if (level > 10)
            return;

        var x12 = (x1 + x2) * 0.5f;
        var y12 = (y1 + y2) * 0.5f;
        var x23 = (x2 + x3) * 0.5f;
        var y23 = (y2 + y3) * 0.5f;
        var x34 = (x3 + x4) * 0.5f;
        var y34 = (y3 + y4) * 0.5f;
        var x123 = (x12 + x23) * 0.5f;
        var y123 = (y12 + y23) * 0.5f;
        var dx = x4 - x1;
        var dy = y4 - y1;
        var d2 = Math.Abs((x2 - x4) * dy - (y2 - y4) * dx);
        var d3 = Math.Abs((x3 - x4) * dy - (y3 - y4) * dx);
        if ((d2 + d3) * (d2 + d3) < _tessTol * (dx * dx + dy * dy))
        {
            __addPoint(x4, y4, type);
            return;
        }

        var x234 = (x23 + x34) * 0.5f;
        var y234 = (y23 + y34) * 0.5f;
        var x1234 = (x123 + x234) * 0.5f;
        var y1234 = (y123 + y234) * 0.5f;
        __tesselateBezier(x1, y1, x12, y12, x123, y123, x1234, y1234, level + 1, 0);
        __tesselateBezier(x1234, y1234, x234, y234, x34, y34, x4, y4, level + 1, type);
    }

    private void __flattenPaths()
    {
        if (_pathsCache.Count > 0)
            return;

        ref Path lastPath = ref Unsafe.NullRef<Path>();
        for (var i = 0; i < _commands.Count; ++i)
        {
            switch (_commands[i].Type)
            {
                case CommandType.MoveTo:
                    lastPath = ref __addPath();
                    __addPoint(_commands[i].P1, _commands[i].P2, PointFlags.Corner);
                    break;
                case CommandType.LineTo:
                    __addPoint(_commands[i].P1, _commands[i].P2, PointFlags.Corner);
                    break;
                case CommandType.BezierTo:
                    if (!Unsafe.IsNullRef(ref lastPath) && lastPath.Count > 0)
                    {
                        ref var last = ref lastPath.LastPoint;
                        __tesselateBezier(last.X, last.Y,
                            _commands[i].P1, _commands[i].P2,
                            _commands[i].P3, _commands[i].P4,
                            _commands[i].P5, _commands[i].P6,
                            0, PointFlags.Corner);
                    }

                    break;
                case CommandType.Close:
                    __closePath();
                    break;
                case CommandType.Winding:
                    __pathWinding((Winding)_commands[i].P1);
                    break;
            }
        }

        _bounds.X = _bounds.Y = 1e6f;
        _bounds.X2 = _bounds.Y2 = -1e6f;
        for (var j = 0; j < _pathsCache.Count; j++)
        {
            ref var path = ref _pathsCache[j];

            var p0Index = path.Count - 1;
            var p1Index = 0;
            if (__ptEquals(path.LastPoint.X, path.LastPoint.Y, path.FirstPoint.X, path.FirstPoint.Y, _distTol) != 0)
            {
                path.RemoveLast();
                --p0Index;
                path.Closed = true;
            }

            if (path.Count > 2)
            {
                var area = __polyArea(path.AsSpan());
                if (path.Winding == Winding.CounterClockWise && area < 0.0f)
                    __polyReverse(path.AsSpan());
                if (path.Winding == Winding.ClockWise && area > 0.0f)
                    __polyReverse(path.AsSpan());
            }

            for (var i = 0; i < path.Count; i++)
            {
                ref var p0 = ref path[p0Index];
                ref var p1 = ref path[p1Index];
                p0.DeltaX = p1.X - p0.X;
                p0.DeltaY = p1.Y - p0.Y;
                p0.Length = NvgUtility.Normalize(ref p0.DeltaX, ref p0.DeltaY);
                _bounds.X = Math.Min(_bounds.X, p0.X);
                _bounds.Y = Math.Min(_bounds.Y, p0.Y);
                _bounds.X2 = Math.Max(_bounds.X2, p0.X);
                _bounds.Y2 = Math.Max(_bounds.Y2, p0.Y);
                p0Index = p1Index++;
            }
        }
    }

    private void __calculateJoins(float w, LineCap lineJoin, float miterLimit)
    {
        var iw = 0.0f;
        if (w > 0.0f)
            iw = 1.0f / w;
        for (var i = 0; i < _pathsCache.Count; i++)
        {
            ref var path = ref _pathsCache[i];
            var p0Index = path.Count - 1;
            var p1Index = 0;
            var nleft = 0;
            for (var j = 0; j < path.Count; j++)
            {
                ref var p0 = ref path[p0Index];
                ref var p1 = ref path[p1Index];

                var dlx0 = p0.DeltaY;
                var dly0 = -p0.DeltaX;
                var dlx1 = p1.DeltaY;
                var dly1 = -p1.DeltaX;
                p1.dmx = (dlx0 + dlx1) * 0.5f;
                p1.dmy = (dly0 + dly1) * 0.5f;
                var dmr2 = p1.dmx * p1.dmx + p1.dmy * p1.dmy;
                if (dmr2 > 0.000001f)
                {
                    var scale = 1.0f / dmr2;
                    if (scale > 600.0f)
                        scale = 600.0f;
                    p1.dmx *= scale;
                    p1.dmy *= scale;
                }

                p1.flags = (p1.flags & PointFlags.Corner) != 0 ? PointFlags.Corner : 0;
                var cross = p1.DeltaX * p0.DeltaY - p0.DeltaX * p1.DeltaY;
                if (cross > 0.0f)
                {
                    nleft++;
                    p1.flags |= PointFlags.Left;
                }

                var limit = Math.Max(1.01f, Math.Min(p0.Length, p1.Length) * iw);
                if (dmr2 * limit * limit < 1.0f)
                    p1.flags |= PointFlags.InnerBevel;
                if ((p1.flags & PointFlags.Corner) != 0)
                    if (dmr2 * miterLimit * miterLimit < 1.0f || lineJoin == NvgSharp.LineCap.Bevel || lineJoin == NvgSharp.LineCap.Round)
                        p1.flags |= PointFlags.Bevel;
                p0Index = p1Index++;
            }

            path.Convex = nleft == path.Count;
        }
    }

    private void __expandStroke(float w, float fringe, LineCap lineCap, LineCap lineJoin, float miterLimit)
    {
        var aa = fringe;
        var u0 = 0.0f;
        var u1 = 1.0f;
        var ncap = __curveDivs(w, NvgUtility.PI, _tessTol);
        w += aa * 0.5f;
        if (aa == 0.0f)
        {
            u0 = 0.5f;
            u1 = 0.5f;
        }

        __calculateJoins(w, lineJoin, miterLimit);

        for (var i = 0; i < _pathsCache.Count; i++)
        {
            var vertexOffset = _renderCache.VertexCount;
            ref var path = ref _pathsCache[i];
            float dx = 0;
            float dy = 0;
            path.FillCount = 0;
            var loop = path.Closed;

            int p0Index, p1Index;
            int s;
            int e;
            if (loop)
            {
                p0Index = path.Count - 1;
                p1Index = 0;
                s = 0;
                e = path.Count;
            }
            else
            {
                p0Index = 0;
                p1Index = 1;
                s = 1;
                e = path.Count - 1;
            }

            ref var p0 = ref path[p0Index];
            ref var p1 = ref path[p1Index];
            if (!loop)
            {
                dx = p1.X - p0.X;
                dy = p1.Y - p0.Y;
                NvgUtility.Normalize(ref dx, ref dy);
                if (lineCap == NvgSharp.LineCap.Butt)
                    __buttCapStart(p0, dx, dy, w, -aa * 0.5f, aa, u0, u1);
                else if (lineCap == NvgSharp.LineCap.Square)
                    __buttCapStart(p0, dx, dy, w, w - aa, aa, u0, u1);
                else if (lineCap == NvgSharp.LineCap.Round)
                    __roundCapStart(p0, dx, dy, w, ncap, aa, u0, u1);
            }

            for (var j = s; j < e; ++j)
            {
                p0 = ref path[p0Index];
                p1 = ref path[p1Index];
                if ((p1.flags & (PointFlags.Bevel | PointFlags.InnerBevel)) != 0)
                {
                    if (lineJoin == NvgSharp.LineCap.Round)
                        __roundJoin(p0, p1, w, w, u0, u1, ncap, aa);
                    else
                        __bevelJoin(p0, p1, w, w, u0, u1, aa);
                }
                else
                {
                    _renderCache.AddVertex(p1.X + p1.dmx * w, p1.Y + p1.dmy * w, u0, 1);
                    _renderCache.AddVertex(p1.X - p1.dmx * w, p1.Y - p1.dmy * w, u1, 1);
                }

                p0Index = p1Index++;
            }

            if (loop)
            {
                var v = _renderCache.VertexArray[vertexOffset];
                _renderCache.AddVertex(v.Position.X, v.Position.Y, u0, 1);
                v = _renderCache.VertexArray[vertexOffset + 1];
                _renderCache.AddVertex(v.Position.X, v.Position.Y, u1, 1);
            }
            else
            {
                p0 = ref path[p0Index];
                p1 = ref path[p1Index];

                dx = p1.X - p0.X;
                dy = p1.Y - p0.Y;
                NvgUtility.Normalize(ref dx, ref dy);
                if (lineCap == NvgSharp.LineCap.Butt)
                    __buttCapEnd(p1, dx, dy, w, -aa * 0.5f, aa, u0, u1);
                else if (lineCap == NvgSharp.LineCap.Square)
                    __buttCapEnd(p1, dx, dy, w, w - aa, aa, u0, u1);
                else if (lineCap == NvgSharp.LineCap.Round)
                    __roundCapEnd(p1, dx, dy, w, ncap, aa, u0, u1);
            }

            path.StrokeOffset = vertexOffset;
            path.StrokeCount = _renderCache.VertexCount - vertexOffset;
        }
    }

    private void __expandFill(float w, LineCap lineJoin, float miterLimit)
    {
        var aa = _fringeWidth;
        var fringe = w > 0.0f;
        __calculateJoins(w, lineJoin, miterLimit);

        var convex = _pathsCache.Count == 1 && _pathsCache[0].Convex;
        for (var i = 0; i < _pathsCache.Count; i++)
        {
            var vertexOffset = _renderCache.VertexCount;
            ref var path = ref _pathsCache[i];
            var woff = 0.5f * aa;
            if (fringe)
            {
                var p0Index = path.Count - 1;
                var p1Index = 0;
                for (var j = 0; j < path.Count; ++j)
                {
                    ref var p0 = ref path[p0Index];
                    ref var p1 = ref path[p1Index];

                    if ((p1.flags & PointFlags.Bevel) != 0)
                    {
                        var dlx0 = p0.DeltaY;
                        var dly0 = -p0.DeltaX;
                        var dlx1 = p1.DeltaY;
                        var dly1 = -p1.DeltaX;
                        if ((p1.flags & PointFlags.Left) != 0)
                        {
                            var lx = p1.X + p1.dmx * woff;
                            var ly = p1.Y + p1.dmy * woff;
                            _renderCache.AddVertex(lx, ly, 0.5f, 1);
                        }
                        else
                        {
                            var lx0 = p1.X + dlx0 * woff;
                            var ly0 = p1.Y + dly0 * woff;
                            var lx1 = p1.X + dlx1 * woff;
                            var ly1 = p1.Y + dly1 * woff;
                            _renderCache.AddVertex(lx0, ly0, 0.5f, 1);
                            _renderCache.AddVertex(lx1, ly1, 0.5f, 1);
                        }
                    }
                    else
                    {
                        _renderCache.AddVertex(p1.X + p1.dmx * woff, p1.Y + p1.dmy * woff, 0.5f, 1);
                    }

                    p0Index = p1Index++;
                }
            }
            else
            {
                for (var j = 0; j < path.Count; ++j)
                {
                    ref var p = ref path[j];
                    _renderCache.AddVertex(p.X, p.Y, 0.5f, 1);
                }
            }

            path.FillOffset = vertexOffset;
            path.FillCount = _renderCache.VertexCount - vertexOffset;

            vertexOffset = _renderCache.VertexCount;
            if (fringe)
            {
                var lw = w + woff;
                var rw = w - woff;
                var lu = 0.0f;
                var ru = 1.0f;

                if (convex)
                {
                    lw = woff;
                    lu = 0.5f;
                }

                var p0Index = path.Count - 1;
                var p1Index = 0;
                for (var j = 0; j < path.Count; ++j)
                {
                    ref var p0 = ref path[p0Index];
                    ref var p1 = ref path[p1Index];

                    if ((p1.flags & (PointFlags.Bevel | PointFlags.InnerBevel)) != 0)
                    {
                        __bevelJoin(p0, p1, lw, rw, lu, ru, _fringeWidth);
                    }
                    else
                    {
                        _renderCache.AddVertex(p1.X + p1.dmx * lw, p1.Y + p1.dmy * lw, lu, 1);
                        _renderCache.AddVertex(p1.X - p1.dmx * rw, p1.Y - p1.dmy * rw, ru, 1);
                    }

                    p0Index = p1Index++;
                }

                var v = _renderCache.VertexArray[vertexOffset];
                _renderCache.AddVertex(v.Position.X, v.Position.Y, lu, 1);
                v = _renderCache.VertexArray[vertexOffset + 1];
                _renderCache.AddVertex(v.Position.X, v.Position.Y, ru, 1);

                path.StrokeOffset = vertexOffset;
                path.StrokeCount = _renderCache.VertexCount - vertexOffset;
            }
            else
            {
                path.StrokeCount = 0;
            }
        }
    }

    private static float __triarea2(float ax, float ay, float bx, float by, float cx, float cy)
    {
        var abx = bx - ax;
        var aby = by - ay;
        var acx = cx - ax;
        var acy = cy - ay;
        return acx * aby - abx * acy;
    }

    private static float __polyArea(Span<NvgPoint> pts)
    {
        var area = (float)0;
        for (var i = 2; i < pts.Length; i++)
        {
            var a = pts[0];
            var b = pts[i - 1];
            var c = pts[i];
            area += __triarea2(a.X, a.Y, b.X, b.Y, c.X, c.Y);
        }

        return area * 0.5f;
    }

    internal static void __polyReverse(Span<NvgPoint> pts)
    {
        var i = 0;
        var j = pts.Length - 1;
        while (i < j)
        {
            var tmp = pts[i];
            pts[i] = pts[j];
            pts[j] = tmp;
            i++;
            j--;
        }
    }

    private static RectF __isectRects(float ax, float ay, float aw, float ah, float bx, float by, float bw, float bh)
    {
        var minx = Math.Max(ax, bx);
        var miny = Math.Max(ay, by);
        var maxx = Math.Min(ax + aw, bx + bw);
        var maxy = Math.Min(ay + ah, by + bh);

        return new RectF(minx, miny, Math.Max(0.0f, maxx - minx), Math.Max(0.0f, maxy - miny));
    }

    private static float __getAverageScale(ref Transform t)
    {
        var sx = (float)Math.Sqrt(t.T1 * t.T1 + t.T3 * t.T3);
        var sy = (float)Math.Sqrt(t.T2 * t.T2 + t.T4 * t.T4);
        return (sx + sy) * 0.5f;
    }

    private static int __curveDivs(float r, float arc, float tol)
    {
        var da = NvgUtility.AcosF(r / (r + tol)) * 2.0f;
        return Math.Max(2, (int)NvgUtility.CeilingF(arc / da));
    }

    private static Bounds __chooseBevel(PointFlags bevel, NvgPoint p0, NvgPoint p1, float w)
    {
        var result = new Bounds();
        if (bevel != 0)
        {
            result.X = p1.X + p0.DeltaY * w;
            result.Y = p1.Y - p0.DeltaX * w;
            result.X2 = p1.X + p1.DeltaY * w;
            result.Y2 = p1.Y - p1.DeltaX * w;
        }
        else
        {
            result.X = p1.X + p1.dmx * w;
            result.Y = p1.Y + p1.dmy * w;
            result.X2 = p1.X + p1.dmx * w;
            result.Y2 = p1.Y + p1.dmy * w;
        }

        return result;
    }

    private void __roundJoin(NvgPoint p0, NvgPoint p1, float lw, float rw, float lu, float ru, int ncap, float fringe)
    {
        var dlx0 = p0.DeltaY;
        var dly0 = -p0.DeltaX;
        var dlx1 = p1.DeltaY;
        var dly1 = -p1.DeltaX;
        if ((p1.flags & PointFlags.Left) != 0)
        {
            var bounds = __chooseBevel(p1.flags & PointFlags.InnerBevel, p0, p1, lw);
            var a0 = NvgUtility.Atan2F(-dly0, -dlx0);
            var a1 = NvgUtility.Atan2F(-dly1, -dlx1);
            if (a1 > a0)
                a1 -= NvgUtility.PI * 2;
            _renderCache.AddVertex(bounds.X, bounds.Y, lu, 1);
            _renderCache.AddVertex(p1.X - dlx0 * rw, p1.Y - dly0 * rw, ru, 1);
            var n = NvgUtility.ClampI((int)NvgUtility.CeilingF((a0 - a1) / NvgUtility.PI * ncap), 2, ncap);
            for (var i = 0; i < n; i++)
            {
                var u = i / (float)(n - 1);
                var a = a0 + u * (a1 - a0);
                var rx = p1.X + NvgUtility.CosF(a) * rw;
                var ry = p1.Y + NvgUtility.SinF(a) * rw;
                _renderCache.AddVertex(p1.X, p1.Y, 0.5f, 1);
                _renderCache.AddVertex(rx, ry, ru, 1);
            }

            _renderCache.AddVertex(bounds.X2, bounds.Y2, lu, 1);
            _renderCache.AddVertex(p1.X - dlx1 * rw, p1.Y - dly1 * rw, ru, 1);
        }
        else
        {
            var bounds = __chooseBevel(p1.flags & PointFlags.InnerBevel, p0, p1, -rw);
            var a0 = NvgUtility.Atan2F(dly0, dlx0);
            var a1 = NvgUtility.Atan2F(dly1, dlx1);
            if (a1 < a0)
                a1 += NvgUtility.PI * 2;
            _renderCache.AddVertex(p1.X + dlx0 * rw, p1.Y + dly0 * rw, lu, 1);
            _renderCache.AddVertex(bounds.X, bounds.Y, ru, 1);
            var n = NvgUtility.ClampI((int)NvgUtility.CeilingF((a1 - a0) / NvgUtility.PI * ncap), 2, ncap);
            for (var i = 0; i < n; i++)
            {
                var u = i / (float)(n - 1);
                var a = a0 + u * (a1 - a0);
                var lx = p1.X + NvgUtility.CosF(a) * lw;
                var ly = p1.Y + NvgUtility.SinF(a) * lw;
                _renderCache.AddVertex(lx, ly, lu, 1);
                _renderCache.AddVertex(p1.X, p1.Y, 0.5f, 1);
            }

            _renderCache.AddVertex(p1.X + dlx1 * rw, p1.Y + dly1 * rw, lu, 1);
            _renderCache.AddVertex(bounds.X2, bounds.Y2, ru, 1);
        }
    }

    private void __bevelJoin(NvgPoint p0, NvgPoint p1, float lw, float rw, float lu, float ru, float fringe)
    {
        var dlx0 = p0.DeltaY;
        var dly0 = -p0.DeltaX;
        var dlx1 = p1.DeltaY;
        var dly1 = -p1.DeltaX;
        if ((p1.flags & PointFlags.Left) != 0)
        {
            var bounds = __chooseBevel(p1.flags & PointFlags.InnerBevel, p0, p1, lw);
            _renderCache.AddVertex(bounds.X, bounds.Y, lu, 1);
            _renderCache.AddVertex(p1.X - dlx0 * rw, p1.Y - dly0 * rw, ru, 1);
            if ((p1.flags & PointFlags.Bevel) != 0)
            {
                _renderCache.AddVertex(bounds.X, bounds.Y, lu, 1);
                _renderCache.AddVertex(p1.X - dlx0 * rw, p1.Y - dly0 * rw, ru, 1);
                _renderCache.AddVertex(bounds.X2, bounds.Y2, lu, 1);
                _renderCache.AddVertex(p1.X - dlx1 * rw, p1.Y - dly1 * rw, ru, 1);
            }
            else
            {
                var rx0 = p1.X - p1.dmx * rw;
                var ry0 = p1.Y - p1.dmy * rw;
                _renderCache.AddVertex(p1.X, p1.Y, 0.5f, 1);
                _renderCache.AddVertex(p1.X - dlx0 * rw, p1.Y - dly0 * rw, ru, 1);
                _renderCache.AddVertex(rx0, ry0, ru, 1);
                _renderCache.AddVertex(rx0, ry0, ru, 1);
                _renderCache.AddVertex(p1.X, p1.Y, 0.5f, 1);
                _renderCache.AddVertex(p1.X - dlx1 * rw, p1.Y - dly1 * rw, ru, 1);
            }

            _renderCache.AddVertex(bounds.X2, bounds.Y2, lu, 1);
            _renderCache.AddVertex(p1.X - dlx1 * rw, p1.Y - dly1 * rw, ru, 1);
        }
        else
        {
            var bounds = __chooseBevel(p1.flags & PointFlags.InnerBevel, p0, p1, -rw);
            _renderCache.AddVertex(p1.X + dlx0 * lw, p1.Y + dly0 * lw, lu, 1);
            _renderCache.AddVertex(bounds.X, bounds.Y, ru, 1);
            if ((p1.flags & PointFlags.Bevel) != 0)
            {
                _renderCache.AddVertex(p1.X + dlx0 * lw, p1.Y + dly0 * lw, lu, 1);
                _renderCache.AddVertex(bounds.X, bounds.Y, ru, 1);
                _renderCache.AddVertex(p1.X + dlx1 * lw, p1.Y + dly1 * lw, lu, 1);
                _renderCache.AddVertex(bounds.X2, bounds.Y2, ru, 1);
            }
            else
            {
                var lx0 = p1.X + p1.dmx * lw;
                var ly0 = p1.Y + p1.dmy * lw;
                _renderCache.AddVertex(p1.X + dlx0 * lw, p1.Y + dly0 * lw, lu, 1);
                _renderCache.AddVertex(p1.X, p1.Y, 0.5f, 1);
                _renderCache.AddVertex(lx0, ly0, lu, 1);
                _renderCache.AddVertex(lx0, ly0, lu, 1);
                _renderCache.AddVertex(p1.X + dlx1 * lw, p1.Y + dly1 * lw, lu, 1);
                _renderCache.AddVertex(p1.X, p1.Y, 0.5f, 1);
            }

            _renderCache.AddVertex(p1.X + dlx1 * lw, p1.Y + dly1 * lw, lu, 1);
            _renderCache.AddVertex(bounds.X2, bounds.Y2, ru, 1);
        }
    }

    private void __buttCapStart(NvgPoint p, float dx, float dy, float w, float d, float aa, float u0, float u1)
    {
        var px = p.X - dx * d;
        var py = p.Y - dy * d;
        var dlx = dy;
        var dly = -dx;

        _renderCache.AddVertex(px + dlx * w - dx * aa, py + dly * w - dy * aa, u0, 0);
        _renderCache.AddVertex(px - dlx * w - dx * aa, py - dly * w - dy * aa, u1, 0);
        _renderCache.AddVertex(px + dlx * w, py + dly * w, u0, 1);
        _renderCache.AddVertex(px - dlx * w, py - dly * w, u1, 1);
    }

    private void __buttCapEnd(NvgPoint p, float dx, float dy, float w, float d, float aa, float u0, float u1)
    {
        var px = p.X + dx * d;
        var py = p.Y + dy * d;
        var dlx = dy;
        var dly = -dx;
        _renderCache.AddVertex(px + dlx * w, py + dly * w, u0, 1);
        _renderCache.AddVertex(px - dlx * w, py - dly * w, u1, 1);
        _renderCache.AddVertex(px + dlx * w + dx * aa, py + dly * w + dy * aa, u0, 0);
        _renderCache.AddVertex(px - dlx * w + dx * aa, py - dly * w + dy * aa, u1, 0);
    }

    private void __roundCapStart(NvgPoint p, float dx, float dy, float w, int ncap, float aa, float u0, float u1)
    {
        var px = p.X;
        var py = p.Y;
        var dlx = dy;
        var dly = -dx;
        for (var i = 0; i < ncap; i++)
        {
            var a = i / (float)(ncap - 1) * NvgUtility.PI;
            var ax = NvgUtility.CosF(a) * w;
            var ay = NvgUtility.SinF(a) * w;
            _renderCache.AddVertex(px - dlx * ax - dx * ay, py - dly * ax - dy * ay, u0, 1);
            _renderCache.AddVertex(px, py, 0.5f, 1);
        }

        _renderCache.AddVertex(px + dlx * w, py + dly * w, u0, 1);
        _renderCache.AddVertex(px - dlx * w, py - dly * w, u1, 1);
    }

    private void __roundCapEnd(NvgPoint p, float dx, float dy, float w, int ncap, float aa, float u0, float u1)
    {
        var px = p.X;
        var py = p.Y;
        var dlx = dy;
        var dly = -dx;
        _renderCache.AddVertex(px + dlx * w, py + dly * w, u0, 1);
        _renderCache.AddVertex(px - dlx * w, py - dly * w, u1, 1);
        for (var i = 0; i < ncap; i++)
        {
            var a = i / (float)(ncap - 1) * NvgUtility.PI;
            var ax = NvgUtility.CosF(a) * w;
            var ay = NvgUtility.SinF(a) * w;
            _renderCache.AddVertex(px, py, 0.5f, 1);
            _renderCache.AddVertex(px - dlx * ax + dx * ay, py - dly * ax + dy * ay, u0, 1);
        }
    }

    private static int __ptEquals(float x1, float y1, float x2, float y2, float tol)
    {
        var dx = x2 - x1;
        var dy = y2 - y1;
        return dx * dx + dy * dy < tol * tol ? 1 : 0;
    }

    private static float __distPtSeg(float x, float y, float px, float py, float qx, float qy)
    {
        var pqx = qx - px;
        var pqy = qy - py;
        var dx = x - px;
        var dy = y - py;
        var d = pqx * pqx + pqy * pqy;
        var t = pqx * dx + pqy * dy;
        if (d > 0)
            t /= d;
        if (t < 0)
            t = 0;
        else if (t > 1)
            t = 1;
        dx = px + t * pqx - x;
        dy = py + t * pqy - y;
        return dx * dx + dy * dy;
    }
}