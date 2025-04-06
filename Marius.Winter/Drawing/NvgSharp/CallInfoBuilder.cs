using System;

namespace NvgSharp;

internal class CallInfoBuilder
{
    private CallInfo?[] _calls = new CallInfo?[16];
    private int _callIndex;

    private CallInfo? _currentCall;
    private int _callFillStrokeIndex;
    
    private FillStrokeInfo[] _fillStrokeInfos = new FillStrokeInfo[16];
    private int _fillStrokeIndex;

    public CallInfo? CurrentCall => _currentCall;
    
    public CallInfo Add(CallType type)
    {
        if (_callIndex >= _calls.Length) 
            Array.Resize(ref _calls, _calls.Length * 2);

        _callFillStrokeIndex = _fillStrokeIndex;
        
        _currentCall = _calls[_callIndex] ??= new CallInfo();
        _currentCall.FillStrokeInfos = default;
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
        if (_fillStrokeIndex >= _fillStrokeInfos.Length)
            Array.Resize(ref _fillStrokeInfos, _fillStrokeInfos.Length * 2);

        _fillStrokeInfos[_fillStrokeIndex] = info;
        _fillStrokeIndex++;
        
        if (_currentCall != null) 
            _currentCall.FillStrokeInfos = new ReadOnlyMemory<FillStrokeInfo>(_fillStrokeInfos, _callFillStrokeIndex, _fillStrokeIndex - _callFillStrokeIndex);
    }
    
    public void Clear()
    {
        _callIndex = 0;
        _fillStrokeIndex = 0;
        _callFillStrokeIndex = 0;
        _currentCall = null;
    }

    public ReadOnlySpan<CallInfo> AsSpan()
    {
        return _calls.AsSpan(0, _callIndex);
    }
}