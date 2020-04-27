using System;
using Win32Proxy;

namespace CaptureProxy
{
    internal abstract class AbsCaptureHelper : ICaptureHelper
    {
        public Win32Types.Rect WindowRect => _windowRect;
        public Win32Types.Rect ClientRect => WinClientRect;
        public int BitmapDataSize => _bmpDataSize;
        public IntPtr BitmapPtr => HBitmap;
        public Win32Types.BitmapInfo BitmapInfo { get; } = new Win32Types.BitmapInfo();

        protected IntPtr HWnd = IntPtr.Zero;
        protected IntPtr HScrDc = IntPtr.Zero;
        protected IntPtr HMemDc = IntPtr.Zero;
        protected IntPtr HBitmap = IntPtr.Zero;
        protected IntPtr HOldBitmap = IntPtr.Zero;

        private Win32Types.Rect _windowRect;
        protected Win32Types.Rect WinClientRect;
        private int _bmpDataSize;

        protected abstract bool CommonInit();
        protected abstract IntPtr DoCapture();
        protected abstract bool DoCapture(out IntPtr bitsPtr);

        public bool Init(string windowName)
        {
            var handle = Win32Funcs.FindWindowWrapper(null, windowName);
            if (handle.Equals(IntPtr.Zero))
            {
                return false;
            }

            return Init(handle);
        }

        public bool Init(IntPtr handle)
        {
            HWnd = handle;

            //获取窗口大小
            if (!Win32Funcs.GetWindowRectWrapper(HWnd, out _windowRect)
                || !Win32Funcs.GetClientRectWrapper(HWnd, out WinClientRect))
            {
                return false;
            }

            _bmpDataSize = WinClientRect.Width * WinClientRect.Height * 3;

            return CommonInit();
        }

        public void Cleanup()
        {
            if (HBitmap.Equals(IntPtr.Zero))
            {
                return;
            }

            //删除用过的对象
            Win32Funcs.SelectObjectWrapper(HMemDc, HOldBitmap);
            Win32Funcs.DeleteObjectWrapper(HBitmap);
            Win32Funcs.DeleteDcWrapper(HMemDc);
            Win32Funcs.ReleaseDcWrapper(HWnd, HScrDc);

            HWnd = IntPtr.Zero;
            HScrDc = IntPtr.Zero;
            HMemDc = IntPtr.Zero;
            HBitmap = IntPtr.Zero;
            HOldBitmap = IntPtr.Zero;
            //_bitsPtr = IntPtr.Zero;
        }

        public bool RefreshWindow()
        {
            return ChangeWindowHandle(HWnd);
        }

        public bool ChangeWindowHandle(string windowName)
        {
            Cleanup();
            return Init(windowName);
        }

        public bool ChangeWindowHandle(IntPtr handle)
        {
            Cleanup();
            return Init(handle);
        }

        public IntPtr Capture()
        {
            if (HBitmap.Equals(IntPtr.Zero) || HMemDc.Equals(IntPtr.Zero) || HScrDc.Equals(IntPtr.Zero))
            {
                return IntPtr.Zero;
            }

            return DoCapture();
        }

        public bool Capture(out IntPtr bitsPtr, out int bufferSize, out Win32Types.Rect rect)
        {
            bitsPtr = IntPtr.Zero;
            bufferSize = _bmpDataSize;
            rect = WinClientRect;

            if (HBitmap.Equals(IntPtr.Zero) || HMemDc.Equals(IntPtr.Zero) || HScrDc.Equals(IntPtr.Zero))
            {
                return false;
            }

            return DoCapture(out bitsPtr);
        }
    }
}
