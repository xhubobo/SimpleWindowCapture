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
        bool ChangeWindowHandle(string windowName);
        bool ChangeWindowHandle(IntPtr handle);
        IntPtr Capture();
        bool Capture(out IntPtr bitsPtr, out int bufferSize, out Win32Types.Rect rect);

        Win32Types.Rect WindowRect { get; }
        Win32Types.Rect ClientRect { get; }
        int BitmapDataSize { get; }
        IntPtr BitmapPtr { get; }
        Win32Types.BitmapInfo BitmapInfo { get; }
    }
}
