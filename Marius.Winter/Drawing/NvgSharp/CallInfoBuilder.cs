using System;

namespace NvgSharp;

internal class CallInfoBuilder
{
    private CallInfo?[] _calls = new CallInfo?[16];
    private int _callIndex;

    private CallInfo? _currentCall;
    private int _callFillStrokeIndex;

    private readonly ArrayBuilder<FillStrokeInfo> _fillStrokeInfos = new ArrayBuilder<FillStrokeInfo>();

    public CallInfo Add(CallType type)
    {
        if (_callIndex >= _calls.Length)
            Array.Resize(ref _calls, _calls.Length * 2);

        _callFillStrokeIndex = _fillStrokeInfos.Count;

        _currentCall = _calls[_callIndex] ??= new CallInfo();
        _currentCall._fillStrokeInfos = _fillStrokeInfos;
        _currentCall._startIndex = 0;
        _currentCall._count = 0;
        _currentCall.TriangleCount = 0;
        _currentCall.TriangleOffset = 0;
        _currentCall.UniformInfo = default;
        _currentCall.UniformInfo2 = default;
        _currentCall.Type = type;

        _callIndex++;
        return _currentCall;
    }

    public void Add(FillStrokeInfo info)
    {
        _fillStrokeInfos.Append(info);

        if (_currentCall != null)
        {
            _currentCall._fillStrokeInfos = _fillStrokeInfos;
            _currentCall._startIndex = _callFillStrokeIndex;
            _currentCall._count = _fillStrokeInfos.Count - _callFillStrokeIndex;
        }
    }

    public void Clear()
    {
        _callIndex = 0;
        _callFillStrokeIndex = 0;
        _currentCall = null;
        _fillStrokeInfos.Clear();
    }

    public ReadOnlySpan<CallInfo> AsSpan()
    {
        return _calls.AsSpan(0, _callIndex);
    }
}
