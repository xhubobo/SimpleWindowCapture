using System;
using Win32Proxy;

namespace CaptureProxy
{
    internal interface ICaptureHelper
    {
        bool Init(string windowName);
        bool Init(IntPtr handle);
        void Cleanup();
        bool RefreshWindow();
        Win32Types.Rect GetWindowRect();
        Win32Types.Rect GetClientRect();
        int GetBitmapDataSize();
        bool ChangeWindowHandle(string windowName);
        bool ChangeWindowHandle(IntPtr handle);
        IntPtr GetCapture();
        IntPtr GetBitmapPtr();
        Win32Types.BitmapInfo GetBitmapInfo();
        bool GetCapture(out IntPtr bitsPtr, out int bufferSize, out Win32Types.Rect rect);
    }
}
