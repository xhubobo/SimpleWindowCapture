using System;
using System.IO;
using Win32Proxy;

namespace CaptureProxy
{
    internal class DibCaptureHelper : AbsCaptureHelper
    {
        private Win32Types.BitmapInfo _bitmapInfo;
        private IntPtr _bitsPtr = IntPtr.Zero;
        private bool _saveFile;

        protected override bool CommonInit()
        {
            //位图信息
            _bitmapInfo = new Win32Types.BitmapInfo {bmiHeader = new Win32Types.BitmapInfoHeader()};
            _bitmapInfo.bmiHeader.Init();
            _bitmapInfo.bmiHeader.biWidth = WinClientRect.Width;
            _bitmapInfo.bmiHeader.biHeight = WinClientRect.Height;
            _bitmapInfo.bmiHeader.biPlanes = 1;
            _bitmapInfo.bmiHeader.biBitCount = 24;
            _bitmapInfo.bmiHeader.biSizeImage = (uint) (WinClientRect.Width * WinClientRect.Height);
            _bitmapInfo.bmiHeader.biCompression = (uint) Win32Consts.BitmapCompressionMode.BI_RGB;

            HScrDc = Win32Funcs.GetWindowDcWrapper(HWnd);
            HMemDc = Win32Funcs.CreateCompatibleDcWrapper(HScrDc);
            HBitmap = Win32Funcs.CreateDibSectionWrapper(HMemDc, ref _bitmapInfo,
                (uint) Win32Consts.DibColorMode.DIB_RGB_COLORS,
                out _bitsPtr, IntPtr.Zero, 0);
            HOldBitmap = Win32Funcs.SelectObjectWrapper(HMemDc, HBitmap);

            return true;
        }

        protected override IntPtr DoCapture()
        {
            var ret = Win32Funcs.BitBltWrapper(
                HMemDc, 0, 0, WinClientRect.Width, WinClientRect.Height,
                HScrDc, 0, 0,
                (uint) Win32Consts.RasterOperationMode.SRCCOPY);

            SaveFile();

            return ret ? _bitsPtr : IntPtr.Zero;
        }

        protected override bool DoCapture(out IntPtr bitsPtr)
        {
            bitsPtr = _bitsPtr;
            var ret = Win32Funcs.BitBltWrapper(
                HMemDc, 0, 0, WinClientRect.Width, WinClientRect.Height,
                HScrDc, 0, 0,
                (uint) Win32Consts.RasterOperationMode.SRCCOPY);

            return ret;
        }

        private void SaveFile()
        {
            if (!_saveFile)
            {
                return;
            }

            _saveFile = false;

            var path = Path.Combine(Environment.CurrentDirectory, DateTime.Now.ToString("HHmmss") + ".bmp");
            BitmapHelper.SaveBitmapToFile(_bitmapInfo, BitmapDataSize, _bitsPtr, path);
        }
    }
}
