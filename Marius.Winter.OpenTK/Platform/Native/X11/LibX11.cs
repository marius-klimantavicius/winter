using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;

namespace OpenTK.Platform.Native.X11;

/// <summary>
/// Wrapper for the native library libX11.so.
/// </summary>
internal static partial class LibX11
{
    private const string X11 = "X11";

    static LibX11()
    {
        DllResolver.InitLoader();
    }

    public const int Success = 0;

    public const int False = 0;
    public const int True = 1;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int XErrorHandler(XDisplayPtr display, XErrorEvent* error_event);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XSetErrorHandler(XErrorHandler handler);

    internal static unsafe void XGetErrorText(XDisplayPtr display, int code, StringBuilder buffer_return, int length)
    {
        var buffer = length < 256 ? stackalloc byte[256] : new byte[length];
        fixed (byte* ptr = buffer)
        {
            XGetErrorText_(display, code, ptr, length);
            buffer_return.Append(Marshal.PtrToStringUTF8((nint)ptr));
        }
    }

    [DllImport(X11, EntryPoint = "XGetErrorText", CallingConvention = CallingConvention.Cdecl)]
    internal static extern unsafe void XGetErrorText_(XDisplayPtr display, int code, [Out] byte* buffer_return, int length);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial XDisplayPtr XOpenDisplay([MarshalAs(UnmanagedType.LPStr)]string? name);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XDefaultScreen(XDisplayPtr display);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial XVisual* XDefaultVisual(XDisplayPtr display, int screen_number);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial XVisualId XVisualIDFromVisual(XVisual* visual);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XScreenCount(XDisplayPtr dispay);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial ulong XBlackPixel(XDisplayPtr display, int screenNumber);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial ulong XWhitePixel(XDisplayPtr display, int screenNumber);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial XWindow XCreateSimpleWindow(
        XDisplayPtr display,
        XWindow parent,
        int x,
        int y,
        uint width,
        uint height,
        ulong border,
        ulong background);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial XWindow XCreateWindow(
        XDisplayPtr display,
        XWindow parent,
        int x,
        int y,
        uint width,
        uint height,
        uint border,
        int depth,
        WindowClass @class,
        ref XVisual visual,
        XWindowAttributeValueMask valueMask,
        ref XSetWindowAttributes attributes);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XConfigureWindow(XDisplayPtr display, XWindow w, XWindowChangesMask value_mask, ref XWindowChanges values);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XMoveWindow(XDisplayPtr display, XWindow w, int x, int y);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XResizeWindow(XDisplayPtr display, XWindow w, int width, int height);
        
    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XMoveResizeWindow(XDisplayPtr display, XWindow w, int x, int y, uint width, uint height);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XDisplayWidth(XDisplayPtr display, int screen_number);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XDisplayHeight(XDisplayPtr display, int screen_number);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial void XSetWMNormalHints(XDisplayPtr display, XWindow w, XSizeHints* hints);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial int /* Status */ XGetWMNormalHints(XDisplayPtr display, XWindow w, XSizeHints* hints_return, XSizeHintFlags* supplied_return);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial XWMHints* XAllocWMHints();

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial XWMHints* XGetWMHints(XDisplayPtr display, XWindow w);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial void XSetWMHints(XDisplayPtr display, XWindow w, XWMHints* wmhints);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial XSizeHints* XAllocSizeHints();

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial XClassHint *XAllocClassHint();

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial void XSetClassHint(XDisplayPtr display, XWindow w, XClassHint* class_hints);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XSelectInput(XDisplayPtr display, XWindow xWindow, XEventMask events);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial XWindow XDefaultRootWindow(XDisplayPtr display);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial XWindow XRootWindow(XDisplayPtr display, int screen_number);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XSetStandardProperties(
        XDisplayPtr display,
        XWindow window,
        [MarshalAs(UnmanagedType.LPStr)]string windowName,
        [MarshalAs(UnmanagedType.LPStr)]string iconName,
        XPixmap iconPixmap,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[]? argv,
        int argc,
        ref XSizeHints hints);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial XGC XCreateGC(XDisplayPtr display, XDrawable drawable, long valueMask,
        IntPtr values);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XSetBackground(XDisplayPtr display, XGC gc, ulong background);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XSetForeground(XDisplayPtr display, XGC gc, ulong background);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XClearWindow(XDisplayPtr display, XWindow window);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XMapRaised(XDisplayPtr display, XWindow window);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XMapWindow(XDisplayPtr display, XWindow window);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XUnmapWindow(XDisplayPtr display, XWindow window);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int /* Status */ XWithdrawWindow(XDisplayPtr display, XWindow w, int screen_number);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XFreeGC(XDisplayPtr display, XGC gc);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XDestroyWindow(XDisplayPtr display, XWindow window);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XCloseDisplay(XDisplayPtr display);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XNextEvent(XDisplayPtr display, out XEvent @event);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XPutBackEvent(XDisplayPtr display, in XEvent @event);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XFree(IntPtr pointer);
        
    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial int XFree(void* pointer);

    internal static unsafe int XFree<T>(Span<T> span)
    {
        return XFree(Unsafe.AsPointer(ref MemoryMarshal.GetReference(span)));
    }

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial XColorMap XCreateColormap(
        XDisplayPtr display,
        XWindow window,
        ref XVisual visual,
        int alloc);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial XColorMap XDefaultColormap(XDisplayPtr display, int screen_number);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XDefaultDepth(XDisplayPtr display, int screen_number);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XFreeColormap(XDisplayPtr display, XColorMap colormap);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XGetWindowAttributes(
        XDisplayPtr display,
        XWindow window,
        out XWindowAttributes attributes);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XTranslateCoordinates(
        XDisplayPtr display,
        XWindow source,
        XWindow destination,
        int sourceX,
        int sourceY,
        out int destinationX,
        out int destinationY,
        out XWindow child);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XSendEvent(
        XDisplayPtr display,
        XWindow window,
        int propagate,
        XEventMask eventMask,
        in XEvent ea);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XEventsQueued(XDisplayPtr display, XEventsQueuedMode mode);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XFetchName(XDisplayPtr display, XWindow window, out IntPtr name);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XStoreName(XDisplayPtr display, XWindow window, [MarshalAs(UnmanagedType.LPStr)]string name);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial XStatus XGetIconName(XDisplayPtr display, XWindow w, out IntPtr icon_name_return);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial void XSetIconName(XDisplayPtr display, XWindow w, [MarshalAs(UnmanagedType.LPStr)]string name);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial XAtom XInternAtom(XDisplayPtr display,[MarshalAs(UnmanagedType.LPStr)] string atomName, [MarshalAs(UnmanagedType.Bool)] bool onlyIfExists);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XInternAtoms(
        XDisplayPtr display,
        ref IntPtr names,
        int count,
        [MarshalAs(UnmanagedType.Bool)] bool onlyIfExists,
        ref XAtom atoms);

        
    internal static unsafe string XGetAtomName(XDisplayPtr display, XAtom atom) {

        byte* namePtr = XGetAtomName_(display, atom);
        string name = Marshal.PtrToStringUTF8((IntPtr)namePtr) ?? "";
        if (namePtr != null)
        {
            XFree(namePtr);
        }
        return name;
    }

    // FIXME: Make a managed copy and free the native string?
    [LibraryImport(X11, EntryPoint = "XGetAtomName")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    private static unsafe partial byte* XGetAtomName_(XDisplayPtr display, XAtom atom);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XGetWindowProperty(
        XDisplayPtr display,
        XWindow window,
        XAtom property,
        long offset,
        long length,
        [MarshalAs(UnmanagedType.I1)] bool delete,
        XAtom requestType,
        out XAtom actualType,
        out int actualFormat,
        out long numberOfItems,
        out long remainingBytes,
        out IntPtr contents
    );

    internal static unsafe int XChangeProperty<T>(
        XDisplayPtr display,
        XWindow window,
        XAtom property,
        XAtom propertyType,
        int format,
        XPropertyMode mode,
        ReadOnlySpan<T> data,
        int elements) where T : unmanaged
    {
        fixed(T* dataPtr = data)
        {
            return XChangeProperty(display, window, property, propertyType, format, mode, (IntPtr)dataPtr, elements);
        }
    }

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XChangeProperty(
        XDisplayPtr display,
        XWindow window,
        XAtom property,
        XAtom propertyType,
        int format,
        XPropertyMode mode,
        IntPtr data,
        int elements
    );

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XChangeProperty(
        XDisplayPtr display,
        XWindow window,
        XAtom property,
        XAtom propertyType,
        int format,
        XPropertyMode mode,
        long[] data,
        int elements
    );

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XChangeProperty(
        XDisplayPtr display,
        XWindow window,
        XAtom property,
        XAtom propertyType,
        int format,
        XPropertyMode mode,
        byte[] data,
        int elements
    );

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XDeleteProperty(XDisplayPtr display, XWindow w, XAtom property);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XGetInputFocus(XDisplayPtr display, out XWindow focus_return, out RevertTo revert_to_return);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XSetInputFocus(XDisplayPtr display, XWindow focus, RevertTo revert_to, XTime time);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XRaiseWindow(XDisplayPtr display, XWindow w);

    [DllImport(X11, CallingConvention = CallingConvention.Cdecl)]
    internal static extern void XFlush(XDisplayPtr display);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int /* Status */ XSetWMProtocols(XDisplayPtr display, XWindow w, [In] XAtom[] protocols, int count);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial XCursor XCreateFontCursor(XDisplayPtr display, XCursorShape shape);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XDefineCursor(XDisplayPtr display, XWindow w, XCursor cursor);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XUndefineCursor(XDisplayPtr display, XWindow w);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XFreeCursor(XDisplayPtr display, XCursor cursor);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial byte XQueryPointer(
        XDisplayPtr display,
        XWindow w,
        out XWindow root_return,
        out XWindow child_return,
        out int root_x_return,
        out int root_y_return,
        out int win_x_return,
        out int win_y_return,
        out uint mask_return);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XWarpPointer(
        XDisplayPtr display,
        XWindow src_w,
        XWindow dest_w,
        int src_x,
        int src_y,
        uint src_width,
        uint src_height,
        int dest_x,
        int dest_y);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial XPixmap XCreatePixmap(XDisplayPtr display, XDrawable d, int width, int height, int depth);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XFreePixmap(XDisplayPtr display, XPixmap pixmap);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial XPixmap XCreateBitmapFromData(XDisplayPtr display, XDrawable d, byte* data, int width, int height);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial XCursor XCreatePixmapCursor(XDisplayPtr display, XPixmap source, XPixmap mask, XColorPtr foreground_color, XColorPtr background_color, int x, int y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.I1)]
    internal delegate bool XPredicate(XDisplayPtr display, ref XEvent @event, IntPtr arg);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static partial bool XCheckIfEvent(XDisplayPtr display, out XEvent event_return, XPredicate predicate, IntPtr arg);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XIfEvent(XDisplayPtr display, out XEvent event_return, XPredicate predicate, IntPtr arg);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int /* Status */ XIconifyWindow(XDisplayPtr display, XWindow w, int screen_number);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial GrabResult XGrabPointer(
        XDisplayPtr display,
        XWindow grab_window,
        [MarshalAs(UnmanagedType.I1)] bool owner_events,
        XEventMask event_mask,
        GrabMode pointer_mode,
        GrabMode keyboard_mode,
        XWindow confine_to,
        XCursor cursor,
        XTime time);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XUngrabPointer(XDisplayPtr display, XTime time);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool XQueryExtension(XDisplayPtr display, [MarshalAs(UnmanagedType.LPStr)] string name, out int major_opcode_return, out int first_event_return, out int first_error_return);

    internal static unsafe string[] XListExtensions(XDisplayPtr display, out int nextensions_return)
    {
        byte** ptr = XListExtensions_(display, out nextensions_return);

        string[] strings = new string[nextensions_return];
        for (int i = 0; i < strings.Length; i++)
        {
            strings[i] = Marshal.PtrToStringUTF8((IntPtr)ptr[i]) ?? throw new NullReferenceException("XListExtensions() returned null string.");
        }
            
        return strings;
    }

    [LibraryImport(X11, EntryPoint = "XListExtensions")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    private static unsafe partial byte** XListExtensions_(XDisplayPtr display, out int nextensions_return);
        
    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XSync(XDisplayPtr display, int discard);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XConvertSelection(XDisplayPtr display, XAtom selection, XAtom target, XAtom property, XWindow requestor, XTime time);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XSetSelectionOwner(XDisplayPtr display, XAtom selection, XWindow window, XTime time);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool XCheckTypedWindowEvent(XDisplayPtr display, XWindow w, XEventType event_type, out XEvent event_return);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XPending(XDisplayPtr display);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int XConnectionNumber(XDisplayPtr display);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial int XLookupString(XKeyEvent* event_struct, byte* buffer_return, int bytes_buffer, XKeySym* keysym_return, XComposeStatus* status_in_out);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial XIM XOpenIM(XDisplayPtr display, XrmDatabase db, [MarshalAs(UnmanagedType.LPStr)] string res_name, [MarshalAs(UnmanagedType.LPStr)] string res_class);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int /* Status */ XCloseIM(XIM im);

    [DllImport(X11, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSetIMValues")]
    private static extern unsafe byte* XSetIMValues_(XIM im, __arglist);

    internal static unsafe string? XSetIMValues<T>(XIM im, string key, T value) where T : unmanaged
    {
        byte* str = (byte*)Marshal.StringToCoTaskMemUTF8(key);
        byte* ret = XSetIMValues_(im, __arglist(str, value, null));
        Marshal.FreeCoTaskMem((IntPtr)str);
        return Marshal.PtrToStringUTF8((IntPtr)ret);
    }

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial int Xutf8LookupString(XIC ic, XKeyEvent* @event, byte* buffer_return, int bytes_buffer, XKeySym* keysym_return, int* /*Status*/ status_return);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial void XDisplayKeycodes(XDisplayPtr display, out int min_keycodes_return, out int max_keycodes_return);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial XKeySym* XGetKeyboardMapping(XDisplayPtr display, byte /* KeyCode */ first_keycode, int keycode_count, out int keysyms_per_keycode_return);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial XKeySym XKeycodeToKeysym(XDisplayPtr display, byte /* KeyCode */ keycode, int index);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial byte /* KeyCode */ XKeysymToKeycode(XDisplayPtr display, XKeySym keysym);

    [LibraryImport(X11, EntryPoint = "XKeysymToString")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    private static unsafe partial byte* XKeysymToString_(XKeySym keysym);

    internal static unsafe string? XKeysymToString(XKeySym keysym)
    {
        byte* ptr = XKeysymToString_(keysym);
        string? str = Marshal.PtrToStringUTF8((nint)ptr);
        return str;
    }

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial int /* Status */ XQueryTree(XDisplayPtr display, XWindow w, out XWindow root_return, out XWindow parent_return, out XWindow* children_return, out uint nchildren_return);

    [LibraryImport(X11)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static unsafe partial int XSetTransientForHint(XDisplayPtr display, XWindow w, XWindow prop_window);
}