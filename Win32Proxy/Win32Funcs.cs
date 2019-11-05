#region License
// /////////////////////////////////////////////////////////////////////////////
// Copyright (c) DIGIBIRD(http://www.digibird.com.cn)
// 北京小鸟科技股份有限公司保留所有代码著作权，如有任何疑问请访问官方网站与我们联系。
// 代码只针对特定客户使用，不得在未经允许或授权的情况下对外传播扩散，恶意传播者自行承担法律后果。
// 本代码仅用于北京小鸟科技股份有限公司的DVCP等项目。
// 
// 创建日期:     2018-10-13 12:44:33
// 修改日期:     2019-09-12 17:29:09
// 文件名称:     Win32Funcs
// 创建者:       zb
// 类描述:       Win32函数
// /////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Win32Proxy
{
    public static class Win32Funcs
    {
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int width, int height,
            uint flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport("User32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass,
            string lpszWindow);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, out Win32Types.Rect lpRect);

        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, out Win32Types.Rect lpRect);

        [DllImport("User32.dll")]
        private static extern bool ClientToScreen(IntPtr hWnd, ref Win32Types.Point pt);

        [DllImport("User32.dll")]
        private static extern bool ScreenToClient(IntPtr hWnd, ref Win32Types.Point pt);

        [DllImport("User32.dll")]
        private static extern bool ScreenToClient(IntPtr hWnd, ref Win32Types.Rect lpRect);

        [DllImport("user32.dll", EntryPoint = "GetWindowDC")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hDc, int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hDc);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern int UpdateLayeredWindow(IntPtr hWnd, IntPtr hdcDst, ref Win32Types.Point pptDst,
            ref Win32Types.Size psize, IntPtr hdcSrc, ref Win32Types.Point pptSrc, uint crKey,
            ref Win32Types.BlendFunction pblend, uint dwFlags);

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hDc, IntPtr hObject);

        [DllImport("gdi32.dll")]
        private static extern bool DeleteDC(IntPtr hDc);

        [DllImport("user32.dll")]
        private static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateDIBSection(IntPtr hdc, ref Win32Types.BitmapInfo bmi,
            uint usage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);

        [DllImport("gdiplus.dll", SetLastError = true)]
        private static extern int GdipCreateBitmapFromGdiDib(IntPtr bmpInfo, IntPtr pixData, out IntPtr image);

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern bool BitBlt(
            IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight,
            IntPtr hObjectSource, int nXSrc, int nYSrc, uint dwRop);

        [DllImport("user32.dll")]
        private static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, Win32Types.EnumWindowProc callback, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(Win32Types.EnumWindowProc callback, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int SetLayeredWindowAttributes(IntPtr hWnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("Ws2_32.dll")]
        private static extern long WSAGetLastError();

        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [DllImport("Kernel32.dll")]
        private static extern uint GetLastError();

        [DllImport("kernel32.dll")]
        private static extern void SetLastError(uint dwErrCode);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalLock(IntPtr handle);

        [DllImport("user32.dll")]
        private static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        [DllImport("user32.dll")]
        private static extern void LockWorkStation();

        [DllImport("PowrProf.dll", CharSet = CharSet.Auto)]
        private static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        //This is the Import for the SetWindowsHookEx function.
        //Use this function to install a thread-specific hook.
        [DllImport("user32.dll", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int SetWindowsHookEx(int idHook, Win32Types.HookProc lpfn,
            IntPtr hInstance, int threadId);

        //This is the Import for the UnhookWindowsHookEx function.
        //Call this function to uninstall the hook.
        [DllImport("user32.dll", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(int idHook);

        //This is the Import for the CallNextHookEx function.
        //Use this function to pass the hook information to the next hook procedure in chain.
        [DllImport("user32.dll", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int CallNextHookEx(int idHook, int nCode,
            IntPtr wParam, IntPtr lParam);

        public static int GetWindowLongWrapper(IntPtr hWnd, int nIndex)
        {
            return GetWindowLong(hWnd, nIndex);
        }

        public static int SetWindowLongWrapper(IntPtr hWnd, int nIndex, int dwNewLong)
        {
            return SetWindowLong(hWnd, nIndex, dwNewLong);
        }

        public static bool SetWindowPosWrapper(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int width, int height,
            uint flags)
        {
            return SetWindowPos(hWnd, hWndInsertAfter, x, y, width, height, flags);
        }

        public static bool MoveWindowWrapper(IntPtr hWnd, int x, int y, int width, int height, bool repaint)
        {
            return MoveWindow(hWnd, x, y, width, height, repaint);
        }

        public static bool SetForegroundWindowWrapper(IntPtr hWnd)
        {
            return SetForegroundWindow(hWnd);
        }

        public static IntPtr SetFocusWrapper(IntPtr hWnd)
        {
            return SetFocus(hWnd);
        }

        public static IntPtr FindWindowWrapper(string lpClassName, string lpWindowName)
        {
            return FindWindow(lpClassName, lpWindowName);
        }

        public static IntPtr FindWindowExWrapper(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass,
            string lpszWindow)
        {
            return FindWindowEx(hwndParent, hwndChildAfter, lpszClass, lpszWindow);
        }

        public static bool ShowWindowWrapper(IntPtr hWnd, int nCmdShow)
        {
            return ShowWindow(hWnd, nCmdShow);
        }

        public static bool GetWindowRectWrapper(IntPtr hWnd, out Win32Types.Rect lpRect)
        {
            return GetWindowRect(hWnd, out lpRect);
        }

        public static bool GetClientRectWrapper(IntPtr hWnd, out Win32Types.Rect lpRect)
        {
            return GetClientRect(hWnd, out lpRect);
        }

        public static bool ClientToScreenWrapper(IntPtr hWnd, ref Win32Types.Point pt)
        {
            return ClientToScreen(hWnd, ref pt);
        }

        public static bool ScreenToClientWrapper(IntPtr hWnd, ref Win32Types.Point pt)
        {
            return ScreenToClient(hWnd, ref pt);
        }

        public static bool ScreenToClientWrapper(IntPtr hWnd, ref Win32Types.Rect lpRect)
        {
            return ScreenToClient(hWnd, ref lpRect);
        }

        public static IntPtr GetWindowDcWrapper(IntPtr hWnd)
        {
            return GetWindowDC(hWnd);
        }

        public static IntPtr GetDcWrapper(IntPtr hWnd)
        {
            return GetDC(hWnd);
        }

        public static IntPtr CreateCompatibleBitmapWrapper(IntPtr hDc, int nWidth, int nHeight)
        {
            return CreateCompatibleBitmap(hDc, nWidth, nHeight);
        }

        public static IntPtr CreateCompatibleDcWrapper(IntPtr hDc)
        {
            return CreateCompatibleDC(hDc);
        }

        public static int UpdateLayeredWindowWrapper(IntPtr hWnd, IntPtr hdcDst, ref Win32Types.Point pptDst,
            ref Win32Types.Size psize, IntPtr hdcSrc, ref Win32Types.Point pptSrc, uint crKey,
            ref Win32Types.BlendFunction pblend, uint dwFlags)
        {
            return UpdateLayeredWindow(hWnd, hdcDst, ref pptDst, ref psize, hdcSrc, ref pptSrc, crKey, ref pblend, dwFlags);
        }

        public static IntPtr SelectObjectWrapper(IntPtr hDc, IntPtr hObject)
        {
            return SelectObject(hDc, hObject);
        }

        public static bool DeleteDcWrapper(IntPtr hDc)
        {
            return DeleteDC(hDc);
        }

        public static IntPtr ReleaseDcWrapper(IntPtr hwnd, IntPtr hdc)
        {
            return ReleaseDC(hwnd, hdc);
        }

        public static bool DeleteObjectWrapper(IntPtr hObject)
        {
            return DeleteObject(hObject);
        }

        public static IntPtr CreateDibSectionWrapper(IntPtr hdc, ref Win32Types.BitmapInfo bmi,
            uint usage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset)
        {
            return CreateDIBSection(hdc, ref bmi, usage, out ppvBits, hSection, dwOffset);
        }

        public static int GdipCreateBitmapFromGdiDibWrapper(IntPtr bmpInfo, IntPtr pixData, out IntPtr image)
        {
            return GdipCreateBitmapFromGdiDib(bmpInfo, pixData, out image);
        }

        public static bool BitBltWrapper(
            IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight,
            IntPtr hObjectSource, int nXSrc, int nYSrc, uint dwRop)
        {
            return BitBlt(hObject, nXDest, nYDest, nWidth, nHeight,
                hObjectSource, nXSrc, nYSrc, dwRop);
        }

        public static bool PrintWindowWrapper(IntPtr hwnd, IntPtr hdcBlt, uint nFlags)
        {
            return PrintWindow(hwnd, hdcBlt, nFlags);
        }

        public static bool EnumChildWindowsWrapper(IntPtr window, Win32Types.EnumWindowProc callback, IntPtr lParam)
        {
            return EnumChildWindows(window, callback, lParam);
        }

        public static bool EnumWindowsWrapper(Win32Types.EnumWindowProc callback, IntPtr lParam)
        {
            return EnumWindows(callback, lParam);
        }

        public static int GetWindowTextWrapper(IntPtr hWnd, StringBuilder lpString, int nMaxCount)
        {
            return GetWindowText(hWnd, lpString, nMaxCount);
        }

        public static int GetClassNameWrapper(IntPtr hWnd, StringBuilder lpString, int nMaxCount)
        {
            return GetClassName(hWnd, lpString, nMaxCount);
        }

        public static int SendMessageWrapper(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            return SendMessage(hWnd, msg, wParam, lParam);
        }

        public static int SetLayeredWindowAttributesWrapper(IntPtr hWnd, uint crKey, byte bAlpha, uint dwFlags)
        {
            return SetLayeredWindowAttributes(hWnd, crKey, bAlpha, dwFlags);
        }

        public static long WsaGetLastErrorWrapper()
        {
            return WSAGetLastError();
        }

        public static void SetLastErrorWrapper(uint dwErrCode)
        {
            SetLastError(dwErrCode);
        }

        public static bool SetProcessDpiAwareWrapper()
        {
            return SetProcessDPIAware();
        }

        public static uint GetLastErrorWrapper()
        {
            return GetLastError();
        }

        public static IntPtr GlobalLockWrapper(IntPtr handle)
        {
            return GlobalLock(handle);
        }

        public static bool ExitWindowsExWrapper(uint uFlags, uint dwReason)
        {
            return ExitWindowsEx(uFlags, dwReason);
        }

        public static void LockWorkStationWrapper()
        {
            LockWorkStation();
        }

        public static bool SetSuspendStateWrapper(bool hiberate, bool forceCritical, bool disableWakeEvent)
        {
            return SetSuspendState(hiberate, forceCritical, disableWakeEvent);
        }

        public static long SetParentWrapper(IntPtr hWndChild, IntPtr hWndNewParent)
        {
            return SetParent(hWndChild, hWndNewParent);
        }

        public static IntPtr GetParentWrapper(IntPtr hWnd)
        {
            return GetParent(hWnd);
        }

        public static int GetWindowThreadProcessIdWrapper(IntPtr hWnd, out int lpdwProcessId)
        {
            return GetWindowThreadProcessId(hWnd, out lpdwProcessId);
        }

        public static int GetDeviceCapsWrapper(IntPtr hdc, int nIndex)
        {
            return GetDeviceCaps(hdc, nIndex);
        }

        public static int SetWindowsHookExWrapper(int idHook, Win32Types.HookProc lpfn,
            IntPtr hInstance, int threadId)
        {
            return SetWindowsHookEx(idHook, lpfn, hInstance, threadId);
        }

        public static bool UnhookWindowsHookExWrapper(int idHook)
        {
            return UnhookWindowsHookEx(idHook);
        }

        public static int CallNextHookExWrapper(int idHook, int nCode,
            IntPtr wParam, IntPtr lParam)
        {
            return CallNextHookEx(idHook, nCode, wParam, lParam);
        }
    }
}
