using System;
using Win32Proxy;

namespace CaptureProxy
{
    internal class PrintCaptureHelper : ICaptureHelper
    {
        private IntPtr _hWnd = IntPtr.Zero;
        private IntPtr _hScrDc = IntPtr.Zero;
        private IntPtr _hMemDc = IntPtr.Zero;
        private IntPtr _hBitmap = IntPtr.Zero;
        private IntPtr _hOldBitmap = IntPtr.Zero;

        private Win32Types.Rect _windowRect;
        private Win32Types.Rect _clientRect;
        private int _bmpDataSize;

        public IntPtr GetBitmapPtr()
        {
            return _hBitmap;
        }

        public Win32Types.BitmapInfo GetBitmapInfo()
        {
            return new Win32Types.BitmapInfo();
        }

        public bool Init(IntPtr handle)
        {
            _hWnd = handle;

            //获取窗口大小
            if (!Win32Funcs.GetWindowRectWrapper(_hWnd, out _windowRect) ||
                !Win32Funcs.GetClientRectWrapper(_hWnd, out _clientRect))
            {
                return false;
            }

            _bmpDataSize = _windowRect.Width * _windowRect.Height * 3;

            _hScrDc = Win32Funcs.GetWindowDcWrapper(_hWnd);
            _hBitmap = Win32Funcs.CreateCompatibleBitmapWrapper(_hScrDc, _windowRect.Width, _windowRect.Height);
            _hMemDc = Win32Funcs.CreateCompatibleDcWrapper(_hScrDc);
            _hOldBitmap = Win32Funcs.SelectObjectWrapper(_hMemDc, _hBitmap);

            return true;
        }

        public bool Init(string windowName)
        {
            var handle = Win32Funcs.FindWindowWrapper(null, windowName);
            if (handle.Equals(IntPtr.Zero))
            {
                return false;
            }

            return Init(handle);
        }

        public void Cleanup()
        {
            if (_hBitmap.Equals(IntPtr.Zero))
            {
                return;
            }

            //删除用过的对象
            Win32Funcs.SelectObjectWrapper(_hMemDc, _hOldBitmap);
            Win32Funcs.DeleteObjectWrapper(_hBitmap);
            Win32Funcs.DeleteDcWrapper(_hMemDc);
            Win32Funcs.ReleaseDcWrapper(_hWnd, _hScrDc);

            _hWnd = IntPtr.Zero;
            _hScrDc = IntPtr.Zero;
            _hMemDc = IntPtr.Zero;
            _hBitmap = IntPtr.Zero;
            _hOldBitmap = IntPtr.Zero;
        }

        public bool RefreshWindow()
        {
            var hWnd = _hWnd;
            Cleanup();
            return Init(hWnd);
        }

        public Win32Types.Rect GetWindowRect()
        {
            return _windowRect;
        }

        public Win32Types.Rect GetClientRect()
        {
            return _clientRect;
        }

        public int GetBitmapDataSize()
        {
            return _bmpDataSize;
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

        public IntPtr GetCapture()
        {
            if (_hMemDc.Equals(IntPtr.Zero) || _hScrDc.Equals(IntPtr.Zero))
            {
                return IntPtr.Zero;
            }

            var ret = Win32Funcs.PrintWindowWrapper(_hWnd, _hMemDc,
                (uint) Win32Consts.PrintWindowMode.PW_CLIENTONLY |
                (uint) Win32Consts.PrintWindowMode.PW_RENDERFULLCONTENT);
            return ret ? _hBitmap : IntPtr.Zero;
        }

        public bool GetCapture(out IntPtr bitsPtr, out int bufferSize, out Win32Types.Rect rect)
        {
            bitsPtr = _hBitmap;
            bufferSize = _bmpDataSize;
            rect = _clientRect;

            if (_hBitmap.Equals(IntPtr.Zero) || _hMemDc.Equals(IntPtr.Zero) || _hScrDc.Equals(IntPtr.Zero))
            {
                return false;
            }

            var ret = Win32Funcs.PrintWindowWrapper(_hWnd, _hMemDc,
                (uint) Win32Consts.PrintWindowMode.PW_CLIENTONLY |
                (uint) Win32Consts.PrintWindowMode.PW_RENDERFULLCONTENT);

            return ret;
        }
    }
}
