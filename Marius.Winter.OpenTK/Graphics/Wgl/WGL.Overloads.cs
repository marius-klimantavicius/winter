// This file is auto generated, do not edit. Generated: 2025-03-27 19:03:30 GMT+01:00

using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;

namespace OpenTK.Graphics.Wgl;

public static unsafe partial class Wgl
{
    /// <inheritdoc cref="ChoosePixelFormat(IntPtr, PixelFormatDescriptor*)"/>
    public static unsafe int ChoosePixelFormat(IntPtr hDc, ref readonly PixelFormatDescriptor pPfd)
    {
        int returnValue;
        fixed (PixelFormatDescriptor* pPfd_ptr = &pPfd)
        {
            returnValue = ChoosePixelFormat(hDc, pPfd_ptr);
        }
        return returnValue;
    }
    /// <inheritdoc cref="CopyContext_(IntPtr, IntPtr, AttribMask)"/>
    public static unsafe bool CopyContext(IntPtr hglrcSrc, IntPtr hglrcDst, AttribMask mask)
    {
        var returnValue = CopyContext_(hglrcSrc, hglrcDst, mask);
        var returnValue_bool = returnValue != 0;
        return returnValue_bool;
    }
    /// <inheritdoc cref="DeleteContext_(IntPtr)"/>
    public static unsafe bool DeleteContext(IntPtr oldContext)
    {
        var returnValue = DeleteContext_(oldContext);
        var returnValue_bool = returnValue != 0;
        return returnValue_bool;
    }
    /// <inheritdoc cref="DescribeLayerPlane(IntPtr, int, int, uint, LayerPlaneDescriptor*)"/>
    public static unsafe bool DescribeLayerPlane(IntPtr hDc, int pixelFormat, int layerPlane, uint nBytes, out LayerPlaneDescriptor plpd)
    {
        bool returnValue_bool;
        fixed (LayerPlaneDescriptor* plpd_ptr = &plpd)
        {
            var returnValue = DescribeLayerPlane(hDc, pixelFormat, layerPlane, nBytes, plpd_ptr);
            returnValue_bool = returnValue != 0;
        }
        return returnValue_bool;
    }
    /// <inheritdoc cref="DescribePixelFormat(IntPtr, int, uint, PixelFormatDescriptor*)"/>
    public static unsafe int DescribePixelFormat(IntPtr hdc, int ipfd, uint cjpfd, out PixelFormatDescriptor ppfd)
    {
        int returnValue;
        fixed (PixelFormatDescriptor* ppfd_ptr = &ppfd)
        {
            returnValue = DescribePixelFormat(hdc, ipfd, cjpfd, ppfd_ptr);
        }
        return returnValue;
    }
    /// <inheritdoc cref="GetEnhMetaFilePixelFormat(IntPtr, uint, PixelFormatDescriptor*)"/>
    public static unsafe uint GetEnhMetaFilePixelFormat(IntPtr hemf, uint cbBuffer, out PixelFormatDescriptor ppfd)
    {
        uint returnValue;
        fixed (PixelFormatDescriptor* ppfd_ptr = &ppfd)
        {
            returnValue = GetEnhMetaFilePixelFormat(hemf, cbBuffer, ppfd_ptr);
        }
        return returnValue;
    }
    /// <inheritdoc cref="GetLayerPaletteEntries(IntPtr, int, int, int, ColorRef*)"/>
    public static unsafe int GetLayerPaletteEntries(IntPtr hdc, int iLayerPlane, int iStart, int cEntries, Span<ColorRef> pcr)
    {
        int returnValue;
        fixed (ColorRef* pcr_ptr = pcr)
        {
            returnValue = GetLayerPaletteEntries(hdc, iLayerPlane, iStart, cEntries, pcr_ptr);
        }
        return returnValue;
    }
    /// <inheritdoc cref="GetLayerPaletteEntries(IntPtr, int, int, int, ColorRef*)"/>
    public static unsafe int GetLayerPaletteEntries(IntPtr hdc, int iLayerPlane, int iStart, int cEntries, ColorRef[] pcr)
    {
        int returnValue;
        fixed (ColorRef* pcr_ptr = pcr)
        {
            returnValue = GetLayerPaletteEntries(hdc, iLayerPlane, iStart, cEntries, pcr_ptr);
        }
        return returnValue;
    }
    /// <inheritdoc cref="GetLayerPaletteEntries(IntPtr, int, int, int, ColorRef*)"/>
    public static unsafe int GetLayerPaletteEntries(IntPtr hdc, int iLayerPlane, int iStart, int cEntries, ref ColorRef pcr)
    {
        int returnValue;
        fixed (ColorRef* pcr_ptr = &pcr)
        {
            returnValue = GetLayerPaletteEntries(hdc, iLayerPlane, iStart, cEntries, pcr_ptr);
        }
        return returnValue;
    }
    /// <inheritdoc cref="GetProcAddress(byte*)"/>
    public static unsafe IntPtr GetProcAddress(string lpszProc)
    {
        byte* lpszProc_ptr = (byte*)Marshal.StringToCoTaskMemUTF8(lpszProc);
        var returnValue = GetProcAddress(lpszProc_ptr);
        Marshal.FreeCoTaskMem((IntPtr)lpszProc_ptr);
        return returnValue;
    }
    /// <inheritdoc cref="MakeCurrent_(IntPtr, IntPtr)"/>
    public static unsafe bool MakeCurrent(IntPtr hDc, IntPtr newContext)
    {
        var returnValue = MakeCurrent_(hDc, newContext);
        var returnValue_bool = returnValue != 0;
        return returnValue_bool;
    }
    /// <inheritdoc cref="RealizeLayerPalette_(IntPtr, int, int)"/>
    public static unsafe bool RealizeLayerPalette(IntPtr hdc, int iLayerPlane, int bRealize)
    {
        var returnValue = RealizeLayerPalette_(hdc, iLayerPlane, bRealize);
        var returnValue_bool = returnValue != 0;
        return returnValue_bool;
    }
    /// <inheritdoc cref="SetLayerPaletteEntries(IntPtr, int, int, int, ColorRef*)"/>
    public static unsafe int SetLayerPaletteEntries(IntPtr hdc, int iLayerPlane, int iStart, int cEntries, ReadOnlySpan<ColorRef> pcr)
    {
        int returnValue;
        fixed (ColorRef* pcr_ptr = pcr)
        {
            returnValue = SetLayerPaletteEntries(hdc, iLayerPlane, iStart, cEntries, pcr_ptr);
        }
        return returnValue;
    }
    /// <inheritdoc cref="SetLayerPaletteEntries(IntPtr, int, int, int, ColorRef*)"/>
    public static unsafe int SetLayerPaletteEntries(IntPtr hdc, int iLayerPlane, int iStart, int cEntries, ColorRef[] pcr)
    {
        int returnValue;
        fixed (ColorRef* pcr_ptr = pcr)
        {
            returnValue = SetLayerPaletteEntries(hdc, iLayerPlane, iStart, cEntries, pcr_ptr);
        }
        return returnValue;
    }
    /// <inheritdoc cref="SetLayerPaletteEntries(IntPtr, int, int, int, ColorRef*)"/>
    public static unsafe int SetLayerPaletteEntries(IntPtr hdc, int iLayerPlane, int iStart, int cEntries, ref readonly ColorRef pcr)
    {
        int returnValue;
        fixed (ColorRef* pcr_ptr = &pcr)
        {
            returnValue = SetLayerPaletteEntries(hdc, iLayerPlane, iStart, cEntries, pcr_ptr);
        }
        return returnValue;
    }
    /// <inheritdoc cref="SetPixelFormat(IntPtr, int, PixelFormatDescriptor*)"/>
    public static unsafe bool SetPixelFormat(IntPtr hdc, int ipfd, ref readonly PixelFormatDescriptor ppfd)
    {
        bool returnValue_bool;
        fixed (PixelFormatDescriptor* ppfd_ptr = &ppfd)
        {
            var returnValue = SetPixelFormat(hdc, ipfd, ppfd_ptr);
            returnValue_bool = returnValue != 0;
        }
        return returnValue_bool;
    }
    /// <inheritdoc cref="ShareLists_(IntPtr, IntPtr)"/>
    public static unsafe bool ShareLists(IntPtr hrcSrvShare, IntPtr hrcSrvSource)
    {
        var returnValue = ShareLists_(hrcSrvShare, hrcSrvSource);
        var returnValue_bool = returnValue != 0;
        return returnValue_bool;
    }
    /// <inheritdoc cref="SwapBuffers_(IntPtr)"/>
    public static unsafe bool SwapBuffers(IntPtr hdc)
    {
        var returnValue = SwapBuffers_(hdc);
        var returnValue_bool = returnValue != 0;
        return returnValue_bool;
    }
    /// <inheritdoc cref="SwapLayerBuffers_(IntPtr, LayerPlaneMask)"/>
    public static unsafe bool SwapLayerBuffers(IntPtr hdc, LayerPlaneMask fuFlags)
    {
        var returnValue = SwapLayerBuffers_(hdc, fuFlags);
        var returnValue_bool = returnValue != 0;
        return returnValue_bool;
    }
    /// <inheritdoc cref="UseFontBitmaps_(IntPtr, uint, uint, uint)"/>
    public static unsafe bool UseFontBitmaps(IntPtr hDC, uint first, uint count, uint listBase)
    {
        var returnValue = UseFontBitmaps_(hDC, first, count, listBase);
        var returnValue_bool = returnValue != 0;
        return returnValue_bool;
    }
    /// <inheritdoc cref="UseFontBitmapsA_(IntPtr, uint, uint, uint)"/>
    public static unsafe bool UseFontBitmapsA(IntPtr hDC, uint first, uint count, uint listBase)
    {
        var returnValue = UseFontBitmapsA_(hDC, first, count, listBase);
        var returnValue_bool = returnValue != 0;
        return returnValue_bool;
    }
    /// <inheritdoc cref="UseFontBitmapsW_(IntPtr, uint, uint, uint)"/>
    public static unsafe bool UseFontBitmapsW(IntPtr hDC, uint first, uint count, uint listBase)
    {
        var returnValue = UseFontBitmapsW_(hDC, first, count, listBase);
        var returnValue_bool = returnValue != 0;
        return returnValue_bool;
    }
    /// <inheritdoc cref="UseFontOutlines_(IntPtr, uint, uint, uint, float, float, FontFormat, IntPtr)"/>
    public static unsafe bool UseFontOutlines(IntPtr hDC, uint first, uint count, uint listBase, float deviation, float extrusion, FontFormat format, IntPtr lpgmf)
    {
        var returnValue = UseFontOutlines_(hDC, first, count, listBase, deviation, extrusion, format, lpgmf);
        var returnValue_bool = returnValue != 0;
        return returnValue_bool;
    }
    /// <inheritdoc cref="UseFontOutlinesA_(IntPtr, uint, uint, uint, float, float, FontFormat, IntPtr)"/>
    public static unsafe bool UseFontOutlinesA(IntPtr hDC, uint first, uint count, uint listBase, float deviation, float extrusion, FontFormat format, IntPtr lpgmf)
    {
        var returnValue = UseFontOutlinesA_(hDC, first, count, listBase, deviation, extrusion, format, lpgmf);
        var returnValue_bool = returnValue != 0;
        return returnValue_bool;
    }
    /// <inheritdoc cref="UseFontOutlinesW_(IntPtr, uint, uint, uint, float, float, FontFormat, IntPtr)"/>
    public static unsafe bool UseFontOutlinesW(IntPtr hDC, uint first, uint count, uint listBase, float deviation, float extrusion, FontFormat format, IntPtr lpgmf)
    {
        var returnValue = UseFontOutlinesW_(hDC, first, count, listBase, deviation, extrusion, format, lpgmf);
        var returnValue_bool = returnValue != 0;
        return returnValue_bool;
    }
    public static unsafe partial class _3DL
    {
        /// <inheritdoc cref="SetStereoEmitterState3DL_(IntPtr, StereoEmitterState)"/>
        public static unsafe bool SetStereoEmitterState3DL(IntPtr hDC, StereoEmitterState uState)
        {
            var returnValue = SetStereoEmitterState3DL_(hDC, uState);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
    }
    public static unsafe partial class AMD
    {
        /// <inheritdoc cref="CreateAssociatedContextAttribsAMD(uint, IntPtr, int*)"/>
        public static unsafe IntPtr CreateAssociatedContextAttribsAMD(uint id, IntPtr hShareContext, ReadOnlySpan<int> attribList)
        {
            IntPtr returnValue;
            fixed (int* attribList_ptr = attribList)
            {
                returnValue = CreateAssociatedContextAttribsAMD(id, hShareContext, attribList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="CreateAssociatedContextAttribsAMD(uint, IntPtr, int*)"/>
        public static unsafe IntPtr CreateAssociatedContextAttribsAMD(uint id, IntPtr hShareContext, int[] attribList)
        {
            IntPtr returnValue;
            fixed (int* attribList_ptr = attribList)
            {
                returnValue = CreateAssociatedContextAttribsAMD(id, hShareContext, attribList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="CreateAssociatedContextAttribsAMD(uint, IntPtr, int*)"/>
        public static unsafe IntPtr CreateAssociatedContextAttribsAMD(uint id, IntPtr hShareContext, ref readonly int attribList)
        {
            IntPtr returnValue;
            fixed (int* attribList_ptr = &attribList)
            {
                returnValue = CreateAssociatedContextAttribsAMD(id, hShareContext, attribList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="DeleteAssociatedContextAMD_(IntPtr)"/>
        public static unsafe bool DeleteAssociatedContextAMD(IntPtr hglrc)
        {
            var returnValue = DeleteAssociatedContextAMD_(hglrc);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetGPUIDsAMD(uint, uint*)"/>
        public static unsafe uint GetGPUIDsAMD(uint maxCount, Span<uint> ids)
        {
            uint returnValue;
            fixed (uint* ids_ptr = ids)
            {
                returnValue = GetGPUIDsAMD(maxCount, ids_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="GetGPUIDsAMD(uint, uint*)"/>
        public static unsafe uint GetGPUIDsAMD(uint maxCount, uint[] ids)
        {
            uint returnValue;
            fixed (uint* ids_ptr = ids)
            {
                returnValue = GetGPUIDsAMD(maxCount, ids_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="GetGPUIDsAMD(uint, uint*)"/>
        public static unsafe uint GetGPUIDsAMD(uint maxCount, ref uint ids)
        {
            uint returnValue;
            fixed (uint* ids_ptr = &ids)
            {
                returnValue = GetGPUIDsAMD(maxCount, ids_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="GetGPUInfoAMD(uint, GPUPropertyAMD, ScalarType, uint, void*)"/>
        public static unsafe int GetGPUInfoAMD(uint id, GPUPropertyAMD property, ScalarType dataType, uint size, IntPtr data)
        {
            void* data_vptr = (void*)data;
            var returnValue = GetGPUInfoAMD(id, property, dataType, size, data_vptr);
            return returnValue;
        }
        /// <inheritdoc cref="GetGPUInfoAMD(uint, GPUPropertyAMD, ScalarType, uint, void*)"/>
        public static unsafe int GetGPUInfoAMD<T1>(uint id, GPUPropertyAMD property, ScalarType dataType, uint size, Span<T1> data)
            where T1 : unmanaged
        {
            int returnValue;
            fixed (void* data_ptr = data)
            {
                returnValue = GetGPUInfoAMD(id, property, dataType, size, data_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="GetGPUInfoAMD(uint, GPUPropertyAMD, ScalarType, uint, void*)"/>
        public static unsafe int GetGPUInfoAMD<T1>(uint id, GPUPropertyAMD property, ScalarType dataType, uint size, T1[] data)
            where T1 : unmanaged
        {
            int returnValue;
            fixed (void* data_ptr = data)
            {
                returnValue = GetGPUInfoAMD(id, property, dataType, size, data_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="GetGPUInfoAMD(uint, GPUPropertyAMD, ScalarType, uint, void*)"/>
        public static unsafe int GetGPUInfoAMD<T1>(uint id, GPUPropertyAMD property, ScalarType dataType, uint size, ref T1 data)
            where T1 : unmanaged
        {
            int returnValue;
            fixed (void* data_ptr = &data)
            {
                returnValue = GetGPUInfoAMD(id, property, dataType, size, data_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="MakeAssociatedContextCurrentAMD_(IntPtr)"/>
        public static unsafe bool MakeAssociatedContextCurrentAMD(IntPtr hglrc)
        {
            var returnValue = MakeAssociatedContextCurrentAMD_(hglrc);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
    }
    public static unsafe partial class ARB
    {
        /// <inheritdoc cref="BindTexImageARB_(IntPtr, ColorBuffer)"/>
        public static unsafe bool BindTexImageARB(IntPtr hPbuffer, ColorBuffer iBuffer)
        {
            var returnValue = BindTexImageARB_(hPbuffer, iBuffer);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="ChoosePixelFormatARB(IntPtr, PixelFormatAttribute*, float*, uint, int*, uint*)"/>
        public static unsafe bool ChoosePixelFormatARB(IntPtr hdc, ReadOnlySpan<PixelFormatAttribute> piAttribIList, ReadOnlySpan<float> pfAttribFList, uint nMaxFormats, Span<int> piFormats, out uint nNumFormats)
        {
            bool returnValue_bool;
            fixed (uint* nNumFormats_ptr = &nNumFormats)
            {
                fixed (int* piFormats_ptr = piFormats)
                {
                    fixed (float* pfAttribFList_ptr = pfAttribFList)
                    {
                        fixed (PixelFormatAttribute* piAttribIList_ptr = piAttribIList)
                        {
                            var returnValue = ChoosePixelFormatARB(hdc, piAttribIList_ptr, pfAttribFList_ptr, nMaxFormats, piFormats_ptr, nNumFormats_ptr);
                            returnValue_bool = returnValue != 0;
                        }
                    }
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="ChoosePixelFormatARB(IntPtr, PixelFormatAttribute*, float*, uint, int*, uint*)"/>
        public static unsafe bool ChoosePixelFormatARB(IntPtr hdc, PixelFormatAttribute[] piAttribIList, float[] pfAttribFList, uint nMaxFormats, int[] piFormats, out uint nNumFormats)
        {
            bool returnValue_bool;
            fixed (uint* nNumFormats_ptr = &nNumFormats)
            {
                fixed (int* piFormats_ptr = piFormats)
                {
                    fixed (float* pfAttribFList_ptr = pfAttribFList)
                    {
                        fixed (PixelFormatAttribute* piAttribIList_ptr = piAttribIList)
                        {
                            var returnValue = ChoosePixelFormatARB(hdc, piAttribIList_ptr, pfAttribFList_ptr, nMaxFormats, piFormats_ptr, nNumFormats_ptr);
                            returnValue_bool = returnValue != 0;
                        }
                    }
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="ChoosePixelFormatARB(IntPtr, PixelFormatAttribute*, float*, uint, int*, uint*)"/>
        public static unsafe bool ChoosePixelFormatARB(IntPtr hdc, ref readonly PixelFormatAttribute piAttribIList, ref readonly float pfAttribFList, uint nMaxFormats, ref int piFormats, out uint nNumFormats)
        {
            bool returnValue_bool;
            fixed (PixelFormatAttribute* piAttribIList_ptr = &piAttribIList)
            fixed (float* pfAttribFList_ptr = &pfAttribFList)
            fixed (int* piFormats_ptr = &piFormats)
            fixed (uint* nNumFormats_ptr = &nNumFormats)
            {
                var returnValue = ChoosePixelFormatARB(hdc, piAttribIList_ptr, pfAttribFList_ptr, nMaxFormats, piFormats_ptr, nNumFormats_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="CreateContextAttribsARB(IntPtr, IntPtr, ContextAttribs*)"/>
        public static unsafe IntPtr CreateContextAttribsARB(IntPtr hDC, IntPtr hShareContext, ReadOnlySpan<ContextAttribs> attribList)
        {
            IntPtr returnValue;
            fixed (ContextAttribs* attribList_ptr = attribList)
            {
                returnValue = CreateContextAttribsARB(hDC, hShareContext, attribList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="CreateContextAttribsARB(IntPtr, IntPtr, ContextAttribs*)"/>
        public static unsafe IntPtr CreateContextAttribsARB(IntPtr hDC, IntPtr hShareContext, ContextAttribs[] attribList)
        {
            IntPtr returnValue;
            fixed (ContextAttribs* attribList_ptr = attribList)
            {
                returnValue = CreateContextAttribsARB(hDC, hShareContext, attribList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="CreateContextAttribsARB(IntPtr, IntPtr, ContextAttribs*)"/>
        public static unsafe IntPtr CreateContextAttribsARB(IntPtr hDC, IntPtr hShareContext, ref readonly ContextAttribs attribList)
        {
            IntPtr returnValue;
            fixed (ContextAttribs* attribList_ptr = &attribList)
            {
                returnValue = CreateContextAttribsARB(hDC, hShareContext, attribList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="CreatePbufferARB(IntPtr, int, int, int, int*)"/>
        public static unsafe IntPtr CreatePbufferARB(IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, ReadOnlySpan<int> piAttribList)
        {
            IntPtr returnValue;
            fixed (int* piAttribList_ptr = piAttribList)
            {
                returnValue = CreatePbufferARB(hDC, iPixelFormat, iWidth, iHeight, piAttribList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="CreatePbufferARB(IntPtr, int, int, int, int*)"/>
        public static unsafe IntPtr CreatePbufferARB(IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, int[] piAttribList)
        {
            IntPtr returnValue;
            fixed (int* piAttribList_ptr = piAttribList)
            {
                returnValue = CreatePbufferARB(hDC, iPixelFormat, iWidth, iHeight, piAttribList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="CreatePbufferARB(IntPtr, int, int, int, int*)"/>
        public static unsafe IntPtr CreatePbufferARB(IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, ref readonly int piAttribList)
        {
            IntPtr returnValue;
            fixed (int* piAttribList_ptr = &piAttribList)
            {
                returnValue = CreatePbufferARB(hDC, iPixelFormat, iWidth, iHeight, piAttribList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="DestroyPbufferARB_(IntPtr)"/>
        public static unsafe bool DestroyPbufferARB(IntPtr hPbuffer)
        {
            var returnValue = DestroyPbufferARB_(hPbuffer);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetExtensionsStringARB_(IntPtr)"/>
        public static unsafe string? GetExtensionsStringARB(IntPtr hdc)
        {
            var returnValue = GetExtensionsStringARB_(hdc);
            var returnValue_str = Marshal.PtrToStringAnsi((IntPtr)returnValue);
            return returnValue_str;
        }
        /// <inheritdoc cref="GetPixelFormatAttribfvARB(IntPtr, int, int, uint, PixelFormatAttribute*, float*)"/>
        public static unsafe bool GetPixelFormatAttribfvARB(IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ReadOnlySpan<PixelFormatAttribute> piAttributes, Span<float> pfValues)
        {
            bool returnValue_bool;
            fixed (float* pfValues_ptr = pfValues)
            {
                fixed (PixelFormatAttribute* piAttributes_ptr = piAttributes)
                {
                    var returnValue = GetPixelFormatAttribfvARB(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes_ptr, pfValues_ptr);
                    returnValue_bool = returnValue != 0;
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetPixelFormatAttribfvARB(IntPtr, int, int, uint, PixelFormatAttribute*, float*)"/>
        public static unsafe bool GetPixelFormatAttribfvARB(IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, PixelFormatAttribute[] piAttributes, float[] pfValues)
        {
            bool returnValue_bool;
            fixed (float* pfValues_ptr = pfValues)
            {
                fixed (PixelFormatAttribute* piAttributes_ptr = piAttributes)
                {
                    var returnValue = GetPixelFormatAttribfvARB(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes_ptr, pfValues_ptr);
                    returnValue_bool = returnValue != 0;
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetPixelFormatAttribfvARB(IntPtr, int, int, uint, PixelFormatAttribute*, float*)"/>
        public static unsafe bool GetPixelFormatAttribfvARB(IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ref readonly PixelFormatAttribute piAttributes, ref float pfValues)
        {
            bool returnValue_bool;
            fixed (PixelFormatAttribute* piAttributes_ptr = &piAttributes)
            fixed (float* pfValues_ptr = &pfValues)
            {
                var returnValue = GetPixelFormatAttribfvARB(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes_ptr, pfValues_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetPixelFormatAttribivARB(IntPtr, int, int, uint, PixelFormatAttribute*, int*)"/>
        public static unsafe bool GetPixelFormatAttribivARB(IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ReadOnlySpan<PixelFormatAttribute> piAttributes, Span<int> piValues)
        {
            bool returnValue_bool;
            fixed (int* piValues_ptr = piValues)
            {
                fixed (PixelFormatAttribute* piAttributes_ptr = piAttributes)
                {
                    var returnValue = GetPixelFormatAttribivARB(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes_ptr, piValues_ptr);
                    returnValue_bool = returnValue != 0;
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetPixelFormatAttribivARB(IntPtr, int, int, uint, PixelFormatAttribute*, int*)"/>
        public static unsafe bool GetPixelFormatAttribivARB(IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, PixelFormatAttribute[] piAttributes, int[] piValues)
        {
            bool returnValue_bool;
            fixed (int* piValues_ptr = piValues)
            {
                fixed (PixelFormatAttribute* piAttributes_ptr = piAttributes)
                {
                    var returnValue = GetPixelFormatAttribivARB(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes_ptr, piValues_ptr);
                    returnValue_bool = returnValue != 0;
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetPixelFormatAttribivARB(IntPtr, int, int, uint, PixelFormatAttribute*, int*)"/>
        public static unsafe bool GetPixelFormatAttribivARB(IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ref readonly PixelFormatAttribute piAttributes, ref int piValues)
        {
            bool returnValue_bool;
            fixed (PixelFormatAttribute* piAttributes_ptr = &piAttributes)
            fixed (int* piValues_ptr = &piValues)
            {
                var returnValue = GetPixelFormatAttribivARB(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes_ptr, piValues_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="MakeContextCurrentARB_(IntPtr, IntPtr, IntPtr)"/>
        public static unsafe bool MakeContextCurrentARB(IntPtr hDrawDC, IntPtr hReadDC, IntPtr hglrc)
        {
            var returnValue = MakeContextCurrentARB_(hDrawDC, hReadDC, hglrc);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="QueryPbufferARB(IntPtr, PBufferAttribute, int*)"/>
        public static unsafe bool QueryPbufferARB(IntPtr hPbuffer, PBufferAttribute iAttribute, out int piValue)
        {
            bool returnValue_bool;
            fixed (int* piValue_ptr = &piValue)
            {
                var returnValue = QueryPbufferARB(hPbuffer, iAttribute, piValue_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="ReleaseTexImageARB_(IntPtr, ColorBuffer)"/>
        public static unsafe bool ReleaseTexImageARB(IntPtr hPbuffer, ColorBuffer iBuffer)
        {
            var returnValue = ReleaseTexImageARB_(hPbuffer, iBuffer);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="RestoreBufferRegionARB_(IntPtr, int, int, int, int, int, int)"/>
        public static unsafe bool RestoreBufferRegionARB(IntPtr hRegion, int x, int y, int width, int height, int xSrc, int ySrc)
        {
            var returnValue = RestoreBufferRegionARB_(hRegion, x, y, width, height, xSrc, ySrc);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="SaveBufferRegionARB_(IntPtr, int, int, int, int)"/>
        public static unsafe bool SaveBufferRegionARB(IntPtr hRegion, int x, int y, int width, int height)
        {
            var returnValue = SaveBufferRegionARB_(hRegion, x, y, width, height);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="SetPbufferAttribARB(IntPtr, int*)"/>
        public static unsafe bool SetPbufferAttribARB(IntPtr hPbuffer, ReadOnlySpan<int> piAttribList)
        {
            bool returnValue_bool;
            fixed (int* piAttribList_ptr = piAttribList)
            {
                var returnValue = SetPbufferAttribARB(hPbuffer, piAttribList_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="SetPbufferAttribARB(IntPtr, int*)"/>
        public static unsafe bool SetPbufferAttribARB(IntPtr hPbuffer, int[] piAttribList)
        {
            bool returnValue_bool;
            fixed (int* piAttribList_ptr = piAttribList)
            {
                var returnValue = SetPbufferAttribARB(hPbuffer, piAttribList_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="SetPbufferAttribARB(IntPtr, int*)"/>
        public static unsafe bool SetPbufferAttribARB(IntPtr hPbuffer, ref readonly int piAttribList)
        {
            bool returnValue_bool;
            fixed (int* piAttribList_ptr = &piAttribList)
            {
                var returnValue = SetPbufferAttribARB(hPbuffer, piAttribList_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
    }
    public static unsafe partial class EXT
    {
        /// <inheritdoc cref="ChoosePixelFormatEXT(IntPtr, int*, float*, uint, int*, uint*)"/>
        public static unsafe bool ChoosePixelFormatEXT(IntPtr hdc, ReadOnlySpan<int> piAttribIList, ReadOnlySpan<float> pfAttribFList, uint nMaxFormats, Span<int> piFormats, out uint nNumFormats)
        {
            bool returnValue_bool;
            fixed (uint* nNumFormats_ptr = &nNumFormats)
            {
                fixed (int* piFormats_ptr = piFormats)
                {
                    fixed (float* pfAttribFList_ptr = pfAttribFList)
                    {
                        fixed (int* piAttribIList_ptr = piAttribIList)
                        {
                            var returnValue = ChoosePixelFormatEXT(hdc, piAttribIList_ptr, pfAttribFList_ptr, nMaxFormats, piFormats_ptr, nNumFormats_ptr);
                            returnValue_bool = returnValue != 0;
                        }
                    }
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="ChoosePixelFormatEXT(IntPtr, int*, float*, uint, int*, uint*)"/>
        public static unsafe bool ChoosePixelFormatEXT(IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, uint nMaxFormats, int[] piFormats, out uint nNumFormats)
        {
            bool returnValue_bool;
            fixed (uint* nNumFormats_ptr = &nNumFormats)
            {
                fixed (int* piFormats_ptr = piFormats)
                {
                    fixed (float* pfAttribFList_ptr = pfAttribFList)
                    {
                        fixed (int* piAttribIList_ptr = piAttribIList)
                        {
                            var returnValue = ChoosePixelFormatEXT(hdc, piAttribIList_ptr, pfAttribFList_ptr, nMaxFormats, piFormats_ptr, nNumFormats_ptr);
                            returnValue_bool = returnValue != 0;
                        }
                    }
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="ChoosePixelFormatEXT(IntPtr, int*, float*, uint, int*, uint*)"/>
        public static unsafe bool ChoosePixelFormatEXT(IntPtr hdc, ref readonly int piAttribIList, ref readonly float pfAttribFList, uint nMaxFormats, ref int piFormats, out uint nNumFormats)
        {
            bool returnValue_bool;
            fixed (int* piAttribIList_ptr = &piAttribIList)
            fixed (float* pfAttribFList_ptr = &pfAttribFList)
            fixed (int* piFormats_ptr = &piFormats)
            fixed (uint* nNumFormats_ptr = &nNumFormats)
            {
                var returnValue = ChoosePixelFormatEXT(hdc, piAttribIList_ptr, pfAttribFList_ptr, nMaxFormats, piFormats_ptr, nNumFormats_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="CreatePbufferEXT(IntPtr, int, int, int, int*)"/>
        public static unsafe IntPtr CreatePbufferEXT(IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, ReadOnlySpan<int> piAttribList)
        {
            IntPtr returnValue;
            fixed (int* piAttribList_ptr = piAttribList)
            {
                returnValue = CreatePbufferEXT(hDC, iPixelFormat, iWidth, iHeight, piAttribList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="CreatePbufferEXT(IntPtr, int, int, int, int*)"/>
        public static unsafe IntPtr CreatePbufferEXT(IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, int[] piAttribList)
        {
            IntPtr returnValue;
            fixed (int* piAttribList_ptr = piAttribList)
            {
                returnValue = CreatePbufferEXT(hDC, iPixelFormat, iWidth, iHeight, piAttribList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="CreatePbufferEXT(IntPtr, int, int, int, int*)"/>
        public static unsafe IntPtr CreatePbufferEXT(IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, ref readonly int piAttribList)
        {
            IntPtr returnValue;
            fixed (int* piAttribList_ptr = &piAttribList)
            {
                returnValue = CreatePbufferEXT(hDC, iPixelFormat, iWidth, iHeight, piAttribList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="DestroyPbufferEXT_(IntPtr)"/>
        public static unsafe bool DestroyPbufferEXT(IntPtr hPbuffer)
        {
            var returnValue = DestroyPbufferEXT_(hPbuffer);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetExtensionsStringEXT_()"/>
        public static unsafe string? GetExtensionsStringEXT()
        {
            var returnValue = GetExtensionsStringEXT_();
            var returnValue_str = Marshal.PtrToStringAnsi((IntPtr)returnValue);
            return returnValue_str;
        }
        /// <inheritdoc cref="GetPixelFormatAttribfvEXT(IntPtr, int, int, uint, PixelFormatAttribute*, float*)"/>
        public static unsafe bool GetPixelFormatAttribfvEXT(IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, Span<PixelFormatAttribute> piAttributes, Span<float> pfValues)
        {
            bool returnValue_bool;
            fixed (float* pfValues_ptr = pfValues)
            {
                fixed (PixelFormatAttribute* piAttributes_ptr = piAttributes)
                {
                    var returnValue = GetPixelFormatAttribfvEXT(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes_ptr, pfValues_ptr);
                    returnValue_bool = returnValue != 0;
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetPixelFormatAttribfvEXT(IntPtr, int, int, uint, PixelFormatAttribute*, float*)"/>
        public static unsafe bool GetPixelFormatAttribfvEXT(IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, PixelFormatAttribute[] piAttributes, float[] pfValues)
        {
            bool returnValue_bool;
            fixed (float* pfValues_ptr = pfValues)
            {
                fixed (PixelFormatAttribute* piAttributes_ptr = piAttributes)
                {
                    var returnValue = GetPixelFormatAttribfvEXT(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes_ptr, pfValues_ptr);
                    returnValue_bool = returnValue != 0;
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetPixelFormatAttribfvEXT(IntPtr, int, int, uint, PixelFormatAttribute*, float*)"/>
        public static unsafe bool GetPixelFormatAttribfvEXT(IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ref readonly PixelFormatAttribute piAttributes, ref float pfValues)
        {
            bool returnValue_bool;
            fixed (PixelFormatAttribute* piAttributes_ptr = &piAttributes)
            fixed (float* pfValues_ptr = &pfValues)
            {
                var returnValue = GetPixelFormatAttribfvEXT(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes_ptr, pfValues_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetPixelFormatAttribivEXT(IntPtr, int, int, uint, PixelFormatAttribute*, int*)"/>
        public static unsafe bool GetPixelFormatAttribivEXT(IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, Span<PixelFormatAttribute> piAttributes, Span<int> piValues)
        {
            bool returnValue_bool;
            fixed (int* piValues_ptr = piValues)
            {
                fixed (PixelFormatAttribute* piAttributes_ptr = piAttributes)
                {
                    var returnValue = GetPixelFormatAttribivEXT(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes_ptr, piValues_ptr);
                    returnValue_bool = returnValue != 0;
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetPixelFormatAttribivEXT(IntPtr, int, int, uint, PixelFormatAttribute*, int*)"/>
        public static unsafe bool GetPixelFormatAttribivEXT(IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, PixelFormatAttribute[] piAttributes, int[] piValues)
        {
            bool returnValue_bool;
            fixed (int* piValues_ptr = piValues)
            {
                fixed (PixelFormatAttribute* piAttributes_ptr = piAttributes)
                {
                    var returnValue = GetPixelFormatAttribivEXT(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes_ptr, piValues_ptr);
                    returnValue_bool = returnValue != 0;
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetPixelFormatAttribivEXT(IntPtr, int, int, uint, PixelFormatAttribute*, int*)"/>
        public static unsafe bool GetPixelFormatAttribivEXT(IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ref readonly PixelFormatAttribute piAttributes, ref int piValues)
        {
            bool returnValue_bool;
            fixed (PixelFormatAttribute* piAttributes_ptr = &piAttributes)
            fixed (int* piValues_ptr = &piValues)
            {
                var returnValue = GetPixelFormatAttribivEXT(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes_ptr, piValues_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="LoadDisplayColorTableEXT(ushort*, uint)"/>
        public static unsafe bool LoadDisplayColorTableEXT(ReadOnlySpan<ushort> table, uint length)
        {
            bool returnValue;
            fixed (ushort* table_ptr = table)
            {
                returnValue = LoadDisplayColorTableEXT(table_ptr, length);
            }
            return returnValue;
        }
        /// <inheritdoc cref="LoadDisplayColorTableEXT(ushort*, uint)"/>
        public static unsafe bool LoadDisplayColorTableEXT(ushort[] table, uint length)
        {
            bool returnValue;
            fixed (ushort* table_ptr = table)
            {
                returnValue = LoadDisplayColorTableEXT(table_ptr, length);
            }
            return returnValue;
        }
        /// <inheritdoc cref="LoadDisplayColorTableEXT(ushort*, uint)"/>
        public static unsafe bool LoadDisplayColorTableEXT(ref readonly ushort table, uint length)
        {
            bool returnValue;
            fixed (ushort* table_ptr = &table)
            {
                returnValue = LoadDisplayColorTableEXT(table_ptr, length);
            }
            return returnValue;
        }
        /// <inheritdoc cref="MakeContextCurrentEXT_(IntPtr, IntPtr, IntPtr)"/>
        public static unsafe bool MakeContextCurrentEXT(IntPtr hDrawDC, IntPtr hReadDC, IntPtr hglrc)
        {
            var returnValue = MakeContextCurrentEXT_(hDrawDC, hReadDC, hglrc);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="QueryPbufferEXT(IntPtr, PBufferAttribute, int*)"/>
        public static unsafe bool QueryPbufferEXT(IntPtr hPbuffer, PBufferAttribute iAttribute, out int piValue)
        {
            bool returnValue_bool;
            fixed (int* piValue_ptr = &piValue)
            {
                var returnValue = QueryPbufferEXT(hPbuffer, iAttribute, piValue_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="SwapIntervalEXT_(int)"/>
        public static unsafe bool SwapIntervalEXT(int interval)
        {
            var returnValue = SwapIntervalEXT_(interval);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
    }
    public static unsafe partial class I3D
    {
        /// <inheritdoc cref="AssociateImageBufferEventsI3D(IntPtr, IntPtr*, IntPtr*, uint*, uint)"/>
        public static unsafe bool AssociateImageBufferEventsI3D(IntPtr hDC, ReadOnlySpan<IntPtr> pEvent, ReadOnlySpan<IntPtr> pAddress, ReadOnlySpan<uint> pSize, uint count)
        {
            bool returnValue_bool;
            fixed (uint* pSize_ptr = pSize)
            {
                fixed (IntPtr* pAddress_ptr = pAddress)
                {
                    fixed (IntPtr* pEvent_ptr = pEvent)
                    {
                        var returnValue = AssociateImageBufferEventsI3D(hDC, pEvent_ptr, pAddress_ptr, pSize_ptr, count);
                        returnValue_bool = returnValue != 0;
                    }
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="AssociateImageBufferEventsI3D(IntPtr, IntPtr*, IntPtr*, uint*, uint)"/>
        public static unsafe bool AssociateImageBufferEventsI3D(IntPtr hDC, IntPtr[] pEvent, IntPtr[] pAddress, uint[] pSize, uint count)
        {
            bool returnValue_bool;
            fixed (uint* pSize_ptr = pSize)
            {
                fixed (IntPtr* pAddress_ptr = pAddress)
                {
                    fixed (IntPtr* pEvent_ptr = pEvent)
                    {
                        var returnValue = AssociateImageBufferEventsI3D(hDC, pEvent_ptr, pAddress_ptr, pSize_ptr, count);
                        returnValue_bool = returnValue != 0;
                    }
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="AssociateImageBufferEventsI3D(IntPtr, IntPtr*, IntPtr*, uint*, uint)"/>
        public static unsafe bool AssociateImageBufferEventsI3D(IntPtr hDC, ref readonly IntPtr pEvent, ref readonly IntPtr pAddress, ref readonly uint pSize, uint count)
        {
            bool returnValue_bool;
            fixed (IntPtr* pEvent_ptr = &pEvent)
            fixed (IntPtr* pAddress_ptr = &pAddress)
            fixed (uint* pSize_ptr = &pSize)
            {
                var returnValue = AssociateImageBufferEventsI3D(hDC, pEvent_ptr, pAddress_ptr, pSize_ptr, count);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="BeginFrameTrackingI3D_()"/>
        public static unsafe bool BeginFrameTrackingI3D()
        {
            var returnValue = BeginFrameTrackingI3D_();
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="DestroyImageBufferI3D_(IntPtr, IntPtr)"/>
        public static unsafe bool DestroyImageBufferI3D(IntPtr hDC, IntPtr pAddress)
        {
            var returnValue = DestroyImageBufferI3D_(hDC, pAddress);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="DisableFrameLockI3D_()"/>
        public static unsafe bool DisableFrameLockI3D()
        {
            var returnValue = DisableFrameLockI3D_();
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="DisableGenlockI3D_(IntPtr)"/>
        public static unsafe bool DisableGenlockI3D(IntPtr hDC)
        {
            var returnValue = DisableGenlockI3D_(hDC);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="EnableFrameLockI3D_()"/>
        public static unsafe bool EnableFrameLockI3D()
        {
            var returnValue = EnableFrameLockI3D_();
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="EnableGenlockI3D_(IntPtr)"/>
        public static unsafe bool EnableGenlockI3D(IntPtr hDC)
        {
            var returnValue = EnableGenlockI3D_(hDC);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="EndFrameTrackingI3D_()"/>
        public static unsafe bool EndFrameTrackingI3D()
        {
            var returnValue = EndFrameTrackingI3D_();
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="GenlockSampleRateI3D_(IntPtr, uint)"/>
        public static unsafe bool GenlockSampleRateI3D(IntPtr hDC, uint uRate)
        {
            var returnValue = GenlockSampleRateI3D_(hDC, uRate);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="GenlockSourceDelayI3D_(IntPtr, uint)"/>
        public static unsafe bool GenlockSourceDelayI3D(IntPtr hDC, uint uDelay)
        {
            var returnValue = GenlockSourceDelayI3D_(hDC, uDelay);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="GenlockSourceEdgeI3D_(IntPtr, uint)"/>
        public static unsafe bool GenlockSourceEdgeI3D(IntPtr hDC, uint uEdge)
        {
            var returnValue = GenlockSourceEdgeI3D_(hDC, uEdge);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="GenlockSourceI3D_(IntPtr, uint)"/>
        public static unsafe bool GenlockSourceI3D(IntPtr hDC, uint uSource)
        {
            var returnValue = GenlockSourceI3D_(hDC, uSource);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetDigitalVideoParametersI3D(IntPtr, DigitalVideoAttribute, int*)"/>
        public static unsafe bool GetDigitalVideoParametersI3D(IntPtr hDC, DigitalVideoAttribute iAttribute, out int piValue)
        {
            bool returnValue_bool;
            fixed (int* piValue_ptr = &piValue)
            {
                var returnValue = GetDigitalVideoParametersI3D(hDC, iAttribute, piValue_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetFrameUsageI3D(float*)"/>
        public static unsafe bool GetFrameUsageI3D(out float pUsage)
        {
            bool returnValue_bool;
            fixed (float* pUsage_ptr = &pUsage)
            {
                var returnValue = GetFrameUsageI3D(pUsage_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetGammaTableI3D(IntPtr, int, ushort*, ushort*, ushort*)"/>
        public static unsafe bool GetGammaTableI3D(IntPtr hDC, int iEntries, Span<ushort> puRed, Span<ushort> puGreen, Span<ushort> puBlue)
        {
            bool returnValue_bool;
            fixed (ushort* puBlue_ptr = puBlue)
            {
                fixed (ushort* puGreen_ptr = puGreen)
                {
                    fixed (ushort* puRed_ptr = puRed)
                    {
                        var returnValue = GetGammaTableI3D(hDC, iEntries, puRed_ptr, puGreen_ptr, puBlue_ptr);
                        returnValue_bool = returnValue != 0;
                    }
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetGammaTableI3D(IntPtr, int, ushort*, ushort*, ushort*)"/>
        public static unsafe bool GetGammaTableI3D(IntPtr hDC, int iEntries, ushort[] puRed, ushort[] puGreen, ushort[] puBlue)
        {
            bool returnValue_bool;
            fixed (ushort* puBlue_ptr = puBlue)
            {
                fixed (ushort* puGreen_ptr = puGreen)
                {
                    fixed (ushort* puRed_ptr = puRed)
                    {
                        var returnValue = GetGammaTableI3D(hDC, iEntries, puRed_ptr, puGreen_ptr, puBlue_ptr);
                        returnValue_bool = returnValue != 0;
                    }
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetGammaTableI3D(IntPtr, int, ushort*, ushort*, ushort*)"/>
        public static unsafe bool GetGammaTableI3D(IntPtr hDC, int iEntries, ref ushort puRed, ref ushort puGreen, ref ushort puBlue)
        {
            bool returnValue_bool;
            fixed (ushort* puRed_ptr = &puRed)
            fixed (ushort* puGreen_ptr = &puGreen)
            fixed (ushort* puBlue_ptr = &puBlue)
            {
                var returnValue = GetGammaTableI3D(hDC, iEntries, puRed_ptr, puGreen_ptr, puBlue_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetGammaTableParametersI3D(IntPtr, GammaTableAttribute, int*)"/>
        public static unsafe bool GetGammaTableParametersI3D(IntPtr hDC, GammaTableAttribute iAttribute, out int piValue)
        {
            bool returnValue_bool;
            fixed (int* piValue_ptr = &piValue)
            {
                var returnValue = GetGammaTableParametersI3D(hDC, iAttribute, piValue_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetGenlockSampleRateI3D(IntPtr, uint*)"/>
        public static unsafe bool GetGenlockSampleRateI3D(IntPtr hDC, out uint uRate)
        {
            bool returnValue_bool;
            fixed (uint* uRate_ptr = &uRate)
            {
                var returnValue = GetGenlockSampleRateI3D(hDC, uRate_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetGenlockSourceDelayI3D(IntPtr, uint*)"/>
        public static unsafe bool GetGenlockSourceDelayI3D(IntPtr hDC, out uint uDelay)
        {
            bool returnValue_bool;
            fixed (uint* uDelay_ptr = &uDelay)
            {
                var returnValue = GetGenlockSourceDelayI3D(hDC, uDelay_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetGenlockSourceEdgeI3D(IntPtr, uint*)"/>
        public static unsafe bool GetGenlockSourceEdgeI3D(IntPtr hDC, out uint uEdge)
        {
            bool returnValue_bool;
            fixed (uint* uEdge_ptr = &uEdge)
            {
                var returnValue = GetGenlockSourceEdgeI3D(hDC, uEdge_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetGenlockSourceI3D(IntPtr, uint*)"/>
        public static unsafe bool GetGenlockSourceI3D(IntPtr hDC, out uint uSource)
        {
            bool returnValue_bool;
            fixed (uint* uSource_ptr = &uSource)
            {
                var returnValue = GetGenlockSourceI3D(hDC, uSource_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="IsEnabledFrameLockI3D(int*)"/>
        public static unsafe bool IsEnabledFrameLockI3D(out int pFlag)
        {
            bool returnValue_bool;
            fixed (int* pFlag_ptr = &pFlag)
            {
                var returnValue = IsEnabledFrameLockI3D(pFlag_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="IsEnabledGenlockI3D(IntPtr, int*)"/>
        public static unsafe bool IsEnabledGenlockI3D(IntPtr hDC, out int pFlag)
        {
            bool returnValue_bool;
            fixed (int* pFlag_ptr = &pFlag)
            {
                var returnValue = IsEnabledGenlockI3D(hDC, pFlag_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="QueryFrameLockMasterI3D(int*)"/>
        public static unsafe bool QueryFrameLockMasterI3D(out int pFlag)
        {
            bool returnValue_bool;
            fixed (int* pFlag_ptr = &pFlag)
            {
                var returnValue = QueryFrameLockMasterI3D(pFlag_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="QueryFrameTrackingI3D(uint*, uint*, float*)"/>
        public static unsafe bool QueryFrameTrackingI3D(out uint pFrameCount, out uint pMissedFrames, out float pLastMissedUsage)
        {
            bool returnValue_bool;
            fixed (uint* pFrameCount_ptr = &pFrameCount)
            fixed (uint* pMissedFrames_ptr = &pMissedFrames)
            fixed (float* pLastMissedUsage_ptr = &pLastMissedUsage)
            {
                var returnValue = QueryFrameTrackingI3D(pFrameCount_ptr, pMissedFrames_ptr, pLastMissedUsage_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="QueryGenlockMaxSourceDelayI3D(IntPtr, uint*, uint*)"/>
        public static unsafe bool QueryGenlockMaxSourceDelayI3D(IntPtr hDC, out uint uMaxLineDelay, out uint uMaxPixelDelay)
        {
            bool returnValue_bool;
            fixed (uint* uMaxLineDelay_ptr = &uMaxLineDelay)
            fixed (uint* uMaxPixelDelay_ptr = &uMaxPixelDelay)
            {
                var returnValue = QueryGenlockMaxSourceDelayI3D(hDC, uMaxLineDelay_ptr, uMaxPixelDelay_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="ReleaseImageBufferEventsI3D(IntPtr, IntPtr*, uint)"/>
        public static unsafe bool ReleaseImageBufferEventsI3D(IntPtr hDC, ReadOnlySpan<IntPtr> pAddress, uint count)
        {
            bool returnValue_bool;
            fixed (IntPtr* pAddress_ptr = pAddress)
            {
                var returnValue = ReleaseImageBufferEventsI3D(hDC, pAddress_ptr, count);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="ReleaseImageBufferEventsI3D(IntPtr, IntPtr*, uint)"/>
        public static unsafe bool ReleaseImageBufferEventsI3D(IntPtr hDC, IntPtr[] pAddress, uint count)
        {
            bool returnValue_bool;
            fixed (IntPtr* pAddress_ptr = pAddress)
            {
                var returnValue = ReleaseImageBufferEventsI3D(hDC, pAddress_ptr, count);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="ReleaseImageBufferEventsI3D(IntPtr, IntPtr*, uint)"/>
        public static unsafe bool ReleaseImageBufferEventsI3D(IntPtr hDC, ref readonly IntPtr pAddress, uint count)
        {
            bool returnValue_bool;
            fixed (IntPtr* pAddress_ptr = &pAddress)
            {
                var returnValue = ReleaseImageBufferEventsI3D(hDC, pAddress_ptr, count);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="SetDigitalVideoParametersI3D(IntPtr, DigitalVideoAttribute, int*)"/>
        public static unsafe bool SetDigitalVideoParametersI3D(IntPtr hDC, DigitalVideoAttribute iAttribute, ref readonly int piValue)
        {
            bool returnValue_bool;
            fixed (int* piValue_ptr = &piValue)
            {
                var returnValue = SetDigitalVideoParametersI3D(hDC, iAttribute, piValue_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="SetGammaTableI3D(IntPtr, int, ushort*, ushort*, ushort*)"/>
        public static unsafe bool SetGammaTableI3D(IntPtr hDC, int iEntries, ReadOnlySpan<ushort> puRed, ReadOnlySpan<ushort> puGreen, ReadOnlySpan<ushort> puBlue)
        {
            bool returnValue_bool;
            fixed (ushort* puBlue_ptr = puBlue)
            {
                fixed (ushort* puGreen_ptr = puGreen)
                {
                    fixed (ushort* puRed_ptr = puRed)
                    {
                        var returnValue = SetGammaTableI3D(hDC, iEntries, puRed_ptr, puGreen_ptr, puBlue_ptr);
                        returnValue_bool = returnValue != 0;
                    }
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="SetGammaTableI3D(IntPtr, int, ushort*, ushort*, ushort*)"/>
        public static unsafe bool SetGammaTableI3D(IntPtr hDC, int iEntries, ushort[] puRed, ushort[] puGreen, ushort[] puBlue)
        {
            bool returnValue_bool;
            fixed (ushort* puBlue_ptr = puBlue)
            {
                fixed (ushort* puGreen_ptr = puGreen)
                {
                    fixed (ushort* puRed_ptr = puRed)
                    {
                        var returnValue = SetGammaTableI3D(hDC, iEntries, puRed_ptr, puGreen_ptr, puBlue_ptr);
                        returnValue_bool = returnValue != 0;
                    }
                }
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="SetGammaTableI3D(IntPtr, int, ushort*, ushort*, ushort*)"/>
        public static unsafe bool SetGammaTableI3D(IntPtr hDC, int iEntries, ref readonly ushort puRed, ref readonly ushort puGreen, ref readonly ushort puBlue)
        {
            bool returnValue_bool;
            fixed (ushort* puRed_ptr = &puRed)
            fixed (ushort* puGreen_ptr = &puGreen)
            fixed (ushort* puBlue_ptr = &puBlue)
            {
                var returnValue = SetGammaTableI3D(hDC, iEntries, puRed_ptr, puGreen_ptr, puBlue_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="SetGammaTableParametersI3D(IntPtr, GammaTableAttribute, int*)"/>
        public static unsafe bool SetGammaTableParametersI3D(IntPtr hDC, GammaTableAttribute iAttribute, ref readonly int piValue)
        {
            bool returnValue_bool;
            fixed (int* piValue_ptr = &piValue)
            {
                var returnValue = SetGammaTableParametersI3D(hDC, iAttribute, piValue_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
    }
    public static unsafe partial class NV
    {
        /// <inheritdoc cref="BindSwapBarrierNV_(uint, uint)"/>
        public static unsafe bool BindSwapBarrierNV(uint group, uint barrier)
        {
            var returnValue = BindSwapBarrierNV_(group, barrier);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="BindVideoCaptureDeviceNV_(uint, IntPtr)"/>
        public static unsafe bool BindVideoCaptureDeviceNV(uint uVideoSlot, IntPtr hDevice)
        {
            var returnValue = BindVideoCaptureDeviceNV_(uVideoSlot, hDevice);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="BindVideoDeviceNV(IntPtr, uint, IntPtr, int*)"/>
        public static unsafe bool BindVideoDeviceNV(IntPtr hDc, uint uVideoSlot, IntPtr hVideoDevice, ReadOnlySpan<int> piAttribList)
        {
            bool returnValue_bool;
            fixed (int* piAttribList_ptr = piAttribList)
            {
                var returnValue = BindVideoDeviceNV(hDc, uVideoSlot, hVideoDevice, piAttribList_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="BindVideoDeviceNV(IntPtr, uint, IntPtr, int*)"/>
        public static unsafe bool BindVideoDeviceNV(IntPtr hDc, uint uVideoSlot, IntPtr hVideoDevice, int[] piAttribList)
        {
            bool returnValue_bool;
            fixed (int* piAttribList_ptr = piAttribList)
            {
                var returnValue = BindVideoDeviceNV(hDc, uVideoSlot, hVideoDevice, piAttribList_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="BindVideoDeviceNV(IntPtr, uint, IntPtr, int*)"/>
        public static unsafe bool BindVideoDeviceNV(IntPtr hDc, uint uVideoSlot, IntPtr hVideoDevice, ref readonly int piAttribList)
        {
            bool returnValue_bool;
            fixed (int* piAttribList_ptr = &piAttribList)
            {
                var returnValue = BindVideoDeviceNV(hDc, uVideoSlot, hVideoDevice, piAttribList_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="BindVideoImageNV_(IntPtr, IntPtr, VideoOutputBuffer)"/>
        public static unsafe bool BindVideoImageNV(IntPtr hVideoDevice, IntPtr hPbuffer, VideoOutputBuffer iVideoBuffer)
        {
            var returnValue = BindVideoImageNV_(hVideoDevice, hPbuffer, iVideoBuffer);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="CopyImageSubDataNV_(IntPtr, uint, TextureTarget, int, int, int, int, IntPtr, uint, TextureTarget, int, int, int, int, int, int, int)"/>
        public static unsafe bool CopyImageSubDataNV(IntPtr hSrcRC, uint srcName, TextureTarget srcTarget, int srcLevel, int srcX, int srcY, int srcZ, IntPtr hDstRC, uint dstName, TextureTarget dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int width, int height, int depth)
        {
            var returnValue = CopyImageSubDataNV_(hSrcRC, srcName, srcTarget, srcLevel, srcX, srcY, srcZ, hDstRC, dstName, dstTarget, dstLevel, dstX, dstY, dstZ, width, height, depth);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="CreateAffinityDCNV(IntPtr*)"/>
        public static unsafe IntPtr CreateAffinityDCNV(ReadOnlySpan<IntPtr> phGpuList)
        {
            IntPtr returnValue;
            fixed (IntPtr* phGpuList_ptr = phGpuList)
            {
                returnValue = CreateAffinityDCNV(phGpuList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="CreateAffinityDCNV(IntPtr*)"/>
        public static unsafe IntPtr CreateAffinityDCNV(IntPtr[] phGpuList)
        {
            IntPtr returnValue;
            fixed (IntPtr* phGpuList_ptr = phGpuList)
            {
                returnValue = CreateAffinityDCNV(phGpuList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="CreateAffinityDCNV(IntPtr*)"/>
        public static unsafe IntPtr CreateAffinityDCNV(ref readonly IntPtr phGpuList)
        {
            IntPtr returnValue;
            fixed (IntPtr* phGpuList_ptr = &phGpuList)
            {
                returnValue = CreateAffinityDCNV(phGpuList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="DelayBeforeSwapNV_(IntPtr, float)"/>
        public static unsafe bool DelayBeforeSwapNV(IntPtr hDC, float seconds)
        {
            var returnValue = DelayBeforeSwapNV_(hDC, seconds);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="DeleteDCNV_(IntPtr)"/>
        public static unsafe bool DeleteDCNV(IntPtr hdc)
        {
            var returnValue = DeleteDCNV_(hdc);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="DXCloseDeviceNV_(IntPtr)"/>
        public static unsafe bool DXCloseDeviceNV(IntPtr hDevice)
        {
            var returnValue = DXCloseDeviceNV_(hDevice);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="DXLockObjectsNV(IntPtr, int, IntPtr*)"/>
        public static unsafe bool DXLockObjectsNV(IntPtr hDevice, int count, Span<IntPtr> hObjects)
        {
            bool returnValue_bool;
            fixed (IntPtr* hObjects_ptr = hObjects)
            {
                var returnValue = DXLockObjectsNV(hDevice, count, hObjects_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="DXLockObjectsNV(IntPtr, int, IntPtr*)"/>
        public static unsafe bool DXLockObjectsNV(IntPtr hDevice, int count, IntPtr[] hObjects)
        {
            bool returnValue_bool;
            fixed (IntPtr* hObjects_ptr = hObjects)
            {
                var returnValue = DXLockObjectsNV(hDevice, count, hObjects_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="DXLockObjectsNV(IntPtr, int, IntPtr*)"/>
        public static unsafe bool DXLockObjectsNV(IntPtr hDevice, int count, ref readonly IntPtr hObjects)
        {
            bool returnValue_bool;
            fixed (IntPtr* hObjects_ptr = &hObjects)
            {
                var returnValue = DXLockObjectsNV(hDevice, count, hObjects_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="DXObjectAccessNV_(IntPtr, DXInteropMaskNV)"/>
        public static unsafe bool DXObjectAccessNV(IntPtr hObject, DXInteropMaskNV access)
        {
            var returnValue = DXObjectAccessNV_(hObject, access);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="DXOpenDeviceNV(void*)"/>
        public static unsafe IntPtr DXOpenDeviceNV(IntPtr dxDevice)
        {
            void* dxDevice_vptr = (void*)dxDevice;
            var returnValue = DXOpenDeviceNV(dxDevice_vptr);
            return returnValue;
        }
        /// <inheritdoc cref="DXOpenDeviceNV(void*)"/>
        public static unsafe IntPtr DXOpenDeviceNV<T1>(ref readonly T1 dxDevice)
            where T1 : unmanaged
        {
            IntPtr returnValue;
            fixed (void* dxDevice_ptr = &dxDevice)
            {
                returnValue = DXOpenDeviceNV(dxDevice_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="DXRegisterObjectNV(IntPtr, void*, uint, ObjectTypeDX, DXInteropMaskNV)"/>
        public static unsafe IntPtr DXRegisterObjectNV(IntPtr hDevice, IntPtr dxObject, uint name, ObjectTypeDX type, DXInteropMaskNV access)
        {
            void* dxObject_vptr = (void*)dxObject;
            var returnValue = DXRegisterObjectNV(hDevice, dxObject_vptr, name, type, access);
            return returnValue;
        }
        /// <inheritdoc cref="DXRegisterObjectNV(IntPtr, void*, uint, ObjectTypeDX, DXInteropMaskNV)"/>
        public static unsafe IntPtr DXRegisterObjectNV<T1>(IntPtr hDevice, ref readonly T1 dxObject, uint name, ObjectTypeDX type, DXInteropMaskNV access)
            where T1 : unmanaged
        {
            IntPtr returnValue;
            fixed (void* dxObject_ptr = &dxObject)
            {
                returnValue = DXRegisterObjectNV(hDevice, dxObject_ptr, name, type, access);
            }
            return returnValue;
        }
        /// <inheritdoc cref="DXSetResourceShareHandleNV(void*, IntPtr)"/>
        public static unsafe bool DXSetResourceShareHandleNV(IntPtr dxObject, IntPtr shareHandle)
        {
            void* dxObject_vptr = (void*)dxObject;
            var returnValue = DXSetResourceShareHandleNV(dxObject_vptr, shareHandle);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="DXSetResourceShareHandleNV(void*, IntPtr)"/>
        public static unsafe bool DXSetResourceShareHandleNV<T1>(ref readonly T1 dxObject, IntPtr shareHandle)
            where T1 : unmanaged
        {
            bool returnValue_bool;
            fixed (void* dxObject_ptr = &dxObject)
            {
                var returnValue = DXSetResourceShareHandleNV(dxObject_ptr, shareHandle);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="DXUnlockObjectsNV(IntPtr, int, IntPtr*)"/>
        public static unsafe bool DXUnlockObjectsNV(IntPtr hDevice, int count, Span<IntPtr> hObjects)
        {
            bool returnValue_bool;
            fixed (IntPtr* hObjects_ptr = hObjects)
            {
                var returnValue = DXUnlockObjectsNV(hDevice, count, hObjects_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="DXUnlockObjectsNV(IntPtr, int, IntPtr*)"/>
        public static unsafe bool DXUnlockObjectsNV(IntPtr hDevice, int count, IntPtr[] hObjects)
        {
            bool returnValue_bool;
            fixed (IntPtr* hObjects_ptr = hObjects)
            {
                var returnValue = DXUnlockObjectsNV(hDevice, count, hObjects_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="DXUnlockObjectsNV(IntPtr, int, IntPtr*)"/>
        public static unsafe bool DXUnlockObjectsNV(IntPtr hDevice, int count, ref readonly IntPtr hObjects)
        {
            bool returnValue_bool;
            fixed (IntPtr* hObjects_ptr = &hObjects)
            {
                var returnValue = DXUnlockObjectsNV(hDevice, count, hObjects_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="DXUnregisterObjectNV_(IntPtr, IntPtr)"/>
        public static unsafe bool DXUnregisterObjectNV(IntPtr hDevice, IntPtr hObject)
        {
            var returnValue = DXUnregisterObjectNV_(hDevice, hObject);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="EnumerateVideoCaptureDevicesNV(IntPtr, IntPtr*)"/>
        public static unsafe uint EnumerateVideoCaptureDevicesNV(IntPtr hDc, Span<IntPtr> phDeviceList)
        {
            uint returnValue;
            fixed (IntPtr* phDeviceList_ptr = phDeviceList)
            {
                returnValue = EnumerateVideoCaptureDevicesNV(hDc, phDeviceList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="EnumerateVideoCaptureDevicesNV(IntPtr, IntPtr*)"/>
        public static unsafe uint EnumerateVideoCaptureDevicesNV(IntPtr hDc, IntPtr[] phDeviceList)
        {
            uint returnValue;
            fixed (IntPtr* phDeviceList_ptr = phDeviceList)
            {
                returnValue = EnumerateVideoCaptureDevicesNV(hDc, phDeviceList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="EnumerateVideoCaptureDevicesNV(IntPtr, IntPtr*)"/>
        public static unsafe uint EnumerateVideoCaptureDevicesNV(IntPtr hDc, ref IntPtr phDeviceList)
        {
            uint returnValue;
            fixed (IntPtr* phDeviceList_ptr = &phDeviceList)
            {
                returnValue = EnumerateVideoCaptureDevicesNV(hDc, phDeviceList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="EnumerateVideoDevicesNV(IntPtr, IntPtr*)"/>
        public static unsafe int EnumerateVideoDevicesNV(IntPtr hDc, Span<IntPtr> phDeviceList)
        {
            int returnValue;
            fixed (IntPtr* phDeviceList_ptr = phDeviceList)
            {
                returnValue = EnumerateVideoDevicesNV(hDc, phDeviceList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="EnumerateVideoDevicesNV(IntPtr, IntPtr*)"/>
        public static unsafe int EnumerateVideoDevicesNV(IntPtr hDc, IntPtr[] phDeviceList)
        {
            int returnValue;
            fixed (IntPtr* phDeviceList_ptr = phDeviceList)
            {
                returnValue = EnumerateVideoDevicesNV(hDc, phDeviceList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="EnumerateVideoDevicesNV(IntPtr, IntPtr*)"/>
        public static unsafe int EnumerateVideoDevicesNV(IntPtr hDc, ref IntPtr phDeviceList)
        {
            int returnValue;
            fixed (IntPtr* phDeviceList_ptr = &phDeviceList)
            {
                returnValue = EnumerateVideoDevicesNV(hDc, phDeviceList_ptr);
            }
            return returnValue;
        }
        /// <inheritdoc cref="EnumGpuDevicesNV(IntPtr, uint, _GPU_DEVICE*)"/>
        public static unsafe bool EnumGpuDevicesNV(IntPtr hGpu, uint iDeviceIndex, Span<_GPU_DEVICE> lpGpuDevice)
        {
            bool returnValue_bool;
            fixed (_GPU_DEVICE* lpGpuDevice_ptr = lpGpuDevice)
            {
                var returnValue = EnumGpuDevicesNV(hGpu, iDeviceIndex, lpGpuDevice_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="EnumGpuDevicesNV(IntPtr, uint, _GPU_DEVICE*)"/>
        public static unsafe bool EnumGpuDevicesNV(IntPtr hGpu, uint iDeviceIndex, _GPU_DEVICE[] lpGpuDevice)
        {
            bool returnValue_bool;
            fixed (_GPU_DEVICE* lpGpuDevice_ptr = lpGpuDevice)
            {
                var returnValue = EnumGpuDevicesNV(hGpu, iDeviceIndex, lpGpuDevice_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="EnumGpuDevicesNV(IntPtr, uint, _GPU_DEVICE*)"/>
        public static unsafe bool EnumGpuDevicesNV(IntPtr hGpu, uint iDeviceIndex, ref _GPU_DEVICE lpGpuDevice)
        {
            bool returnValue_bool;
            fixed (_GPU_DEVICE* lpGpuDevice_ptr = &lpGpuDevice)
            {
                var returnValue = EnumGpuDevicesNV(hGpu, iDeviceIndex, lpGpuDevice_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="EnumGpusFromAffinityDCNV(IntPtr, uint, IntPtr*)"/>
        public static unsafe bool EnumGpusFromAffinityDCNV(IntPtr hAffinityDC, uint iGpuIndex, out IntPtr hGpu)
        {
            bool returnValue_bool;
            fixed (IntPtr* hGpu_ptr = &hGpu)
            {
                var returnValue = EnumGpusFromAffinityDCNV(hAffinityDC, iGpuIndex, hGpu_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="EnumGpusNV(uint, IntPtr*)"/>
        public static unsafe bool EnumGpusNV(uint iGpuIndex, out IntPtr phGpu)
        {
            bool returnValue_bool;
            fixed (IntPtr* phGpu_ptr = &phGpu)
            {
                var returnValue = EnumGpusNV(iGpuIndex, phGpu_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="FreeMemoryNV(void*)"/>
        public static unsafe void FreeMemoryNV(IntPtr pointer)
        {
            void* pointer_vptr = (void*)pointer;
            FreeMemoryNV(pointer_vptr);
        }
        /// <inheritdoc cref="FreeMemoryNV(void*)"/>
        public static unsafe void FreeMemoryNV<T1>(Span<T1> pointer)
            where T1 : unmanaged
        {
            fixed (void* pointer_ptr = pointer)
            {
                FreeMemoryNV(pointer_ptr);
            }
        }
        /// <inheritdoc cref="FreeMemoryNV(void*)"/>
        public static unsafe void FreeMemoryNV<T1>(T1[] pointer)
            where T1 : unmanaged
        {
            fixed (void* pointer_ptr = pointer)
            {
                FreeMemoryNV(pointer_ptr);
            }
        }
        /// <inheritdoc cref="FreeMemoryNV(void*)"/>
        public static unsafe void FreeMemoryNV<T1>(ref T1 pointer)
            where T1 : unmanaged
        {
            fixed (void* pointer_ptr = &pointer)
            {
                FreeMemoryNV(pointer_ptr);
            }
        }
        /// <inheritdoc cref="GetVideoDeviceNV(IntPtr, int, IntPtr*)"/>
        public static unsafe bool GetVideoDeviceNV(IntPtr hDC, int numDevices, Span<IntPtr> hVideoDevice)
        {
            bool returnValue_bool;
            fixed (IntPtr* hVideoDevice_ptr = hVideoDevice)
            {
                var returnValue = GetVideoDeviceNV(hDC, numDevices, hVideoDevice_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetVideoDeviceNV(IntPtr, int, IntPtr*)"/>
        public static unsafe bool GetVideoDeviceNV(IntPtr hDC, int numDevices, IntPtr[] hVideoDevice)
        {
            bool returnValue_bool;
            fixed (IntPtr* hVideoDevice_ptr = hVideoDevice)
            {
                var returnValue = GetVideoDeviceNV(hDC, numDevices, hVideoDevice_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetVideoDeviceNV(IntPtr, int, IntPtr*)"/>
        public static unsafe bool GetVideoDeviceNV(IntPtr hDC, int numDevices, ref IntPtr hVideoDevice)
        {
            bool returnValue_bool;
            fixed (IntPtr* hVideoDevice_ptr = &hVideoDevice)
            {
                var returnValue = GetVideoDeviceNV(hDC, numDevices, hVideoDevice_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetVideoInfoNV(IntPtr, ulong*, ulong*)"/>
        public static unsafe bool GetVideoInfoNV(IntPtr hpVideoDevice, out ulong pulCounterOutputPbuffer, out ulong pulCounterOutputVideo)
        {
            bool returnValue_bool;
            fixed (ulong* pulCounterOutputPbuffer_ptr = &pulCounterOutputPbuffer)
            fixed (ulong* pulCounterOutputVideo_ptr = &pulCounterOutputVideo)
            {
                var returnValue = GetVideoInfoNV(hpVideoDevice, pulCounterOutputPbuffer_ptr, pulCounterOutputVideo_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="JoinSwapGroupNV_(IntPtr, uint)"/>
        public static unsafe bool JoinSwapGroupNV(IntPtr hDC, uint group)
        {
            var returnValue = JoinSwapGroupNV_(hDC, group);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="LockVideoCaptureDeviceNV_(IntPtr, IntPtr)"/>
        public static unsafe bool LockVideoCaptureDeviceNV(IntPtr hDc, IntPtr hDevice)
        {
            var returnValue = LockVideoCaptureDeviceNV_(hDc, hDevice);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="QueryCurrentContextNV(ContextAttribute, int*)"/>
        public static unsafe bool QueryCurrentContextNV(ContextAttribute iAttribute, out int piValue)
        {
            bool returnValue_bool;
            fixed (int* piValue_ptr = &piValue)
            {
                var returnValue = QueryCurrentContextNV(iAttribute, piValue_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="QueryFrameCountNV(IntPtr, uint*)"/>
        public static unsafe bool QueryFrameCountNV(IntPtr hDC, out uint count)
        {
            bool returnValue_bool;
            fixed (uint* count_ptr = &count)
            {
                var returnValue = QueryFrameCountNV(hDC, count_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="QueryMaxSwapGroupsNV(IntPtr, uint*, uint*)"/>
        public static unsafe bool QueryMaxSwapGroupsNV(IntPtr hDC, out uint maxGroups, out uint maxBarriers)
        {
            bool returnValue_bool;
            fixed (uint* maxGroups_ptr = &maxGroups)
            fixed (uint* maxBarriers_ptr = &maxBarriers)
            {
                var returnValue = QueryMaxSwapGroupsNV(hDC, maxGroups_ptr, maxBarriers_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="QuerySwapGroupNV(IntPtr, uint*, uint*)"/>
        public static unsafe bool QuerySwapGroupNV(IntPtr hDC, out uint group, out uint barrier)
        {
            bool returnValue_bool;
            fixed (uint* group_ptr = &group)
            fixed (uint* barrier_ptr = &barrier)
            {
                var returnValue = QuerySwapGroupNV(hDC, group_ptr, barrier_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="QueryVideoCaptureDeviceNV(IntPtr, IntPtr, VideoCaptureDeviceAttribute, int*)"/>
        public static unsafe bool QueryVideoCaptureDeviceNV(IntPtr hDc, IntPtr hDevice, VideoCaptureDeviceAttribute iAttribute, out int piValue)
        {
            bool returnValue_bool;
            fixed (int* piValue_ptr = &piValue)
            {
                var returnValue = QueryVideoCaptureDeviceNV(hDc, hDevice, iAttribute, piValue_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="ReleaseVideoCaptureDeviceNV_(IntPtr, IntPtr)"/>
        public static unsafe bool ReleaseVideoCaptureDeviceNV(IntPtr hDc, IntPtr hDevice)
        {
            var returnValue = ReleaseVideoCaptureDeviceNV_(hDc, hDevice);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="ReleaseVideoDeviceNV_(IntPtr)"/>
        public static unsafe bool ReleaseVideoDeviceNV(IntPtr hVideoDevice)
        {
            var returnValue = ReleaseVideoDeviceNV_(hVideoDevice);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="ReleaseVideoImageNV_(IntPtr, VideoOutputBuffer)"/>
        public static unsafe bool ReleaseVideoImageNV(IntPtr hPbuffer, VideoOutputBuffer iVideoBuffer)
        {
            var returnValue = ReleaseVideoImageNV_(hPbuffer, iVideoBuffer);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="ResetFrameCountNV_(IntPtr)"/>
        public static unsafe bool ResetFrameCountNV(IntPtr hDC)
        {
            var returnValue = ResetFrameCountNV_(hDC);
            var returnValue_bool = returnValue != 0;
            return returnValue_bool;
        }
        /// <inheritdoc cref="SendPbufferToVideoNV(IntPtr, VideoOutputBufferType, ulong*, int)"/>
        public static unsafe bool SendPbufferToVideoNV(IntPtr hPbuffer, VideoOutputBufferType iBufferType, out ulong pulCounterPbuffer, int bBlock)
        {
            bool returnValue_bool;
            fixed (ulong* pulCounterPbuffer_ptr = &pulCounterPbuffer)
            {
                var returnValue = SendPbufferToVideoNV(hPbuffer, iBufferType, pulCounterPbuffer_ptr, bBlock);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
    }
    public static unsafe partial class OML
    {
        /// <inheritdoc cref="GetMscRateOML(IntPtr, int*, int*)"/>
        public static unsafe bool GetMscRateOML(IntPtr hdc, out int numerator, out int denominator)
        {
            bool returnValue_bool;
            fixed (int* numerator_ptr = &numerator)
            fixed (int* denominator_ptr = &denominator)
            {
                var returnValue = GetMscRateOML(hdc, numerator_ptr, denominator_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="GetSyncValuesOML(IntPtr, long*, long*, long*)"/>
        public static unsafe bool GetSyncValuesOML(IntPtr hdc, out long ust, out long msc, out long sbc)
        {
            bool returnValue_bool;
            fixed (long* ust_ptr = &ust)
            fixed (long* msc_ptr = &msc)
            fixed (long* sbc_ptr = &sbc)
            {
                var returnValue = GetSyncValuesOML(hdc, ust_ptr, msc_ptr, sbc_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="WaitForMscOML(IntPtr, long, long, long, long*, long*, long*)"/>
        public static unsafe bool WaitForMscOML(IntPtr hdc, long target_msc, long divisor, long remainder, out long ust, out long msc, out long sbc)
        {
            bool returnValue_bool;
            fixed (long* ust_ptr = &ust)
            fixed (long* msc_ptr = &msc)
            fixed (long* sbc_ptr = &sbc)
            {
                var returnValue = WaitForMscOML(hdc, target_msc, divisor, remainder, ust_ptr, msc_ptr, sbc_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
        /// <inheritdoc cref="WaitForSbcOML(IntPtr, long, long*, long*, long*)"/>
        public static unsafe bool WaitForSbcOML(IntPtr hdc, long target_sbc, out long ust, out long msc, out long sbc)
        {
            bool returnValue_bool;
            fixed (long* ust_ptr = &ust)
            fixed (long* msc_ptr = &msc)
            fixed (long* sbc_ptr = &sbc)
            {
                var returnValue = WaitForSbcOML(hdc, target_sbc, ust_ptr, msc_ptr, sbc_ptr);
                returnValue_bool = returnValue != 0;
            }
            return returnValue_bool;
        }
    }
}