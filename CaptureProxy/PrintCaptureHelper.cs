using System;
using Win32Proxy;

namespace CaptureProxy
{
    internal class PrintCaptureHelper : AbsCaptureHelper
    {
        protected override bool CommonInit()
        {
            HScrDc = Win32Funcs.GetWindowDcWrapper(HWnd);
            HBitmap = Win32Funcs.CreateCompatibleBitmapWrapper(HScrDc, WinClientRect.Width, WinClientRect.Height);
            HMemDc = Win32Funcs.CreateCompatibleDcWrapper(HScrDc);
            HOldBitmap = Win32Funcs.SelectObjectWrapper(HMemDc, HBitmap);
            return true;
        }

        protected override IntPtr DoCapture()
        {
            var ret = Win32Funcs.PrintWindowWrapper(HWnd, HMemDc,
                (uint) Win32Consts.PrintWindowMode.PW_CLIENTONLY |
                (uint) Win32Consts.PrintWindowMode.PW_RENDERFULLCONTENT);
            return ret ? HBitmap : IntPtr.Zero;
        }

        protected override bool DoCapture(out IntPtr bitsPtr)
        {
            bitsPtr = HBitmap;
            var ret = Win32Funcs.PrintWindowWrapper(HWnd, HMemDc,
                (uint) Win32Consts.PrintWindowMode.PW_CLIENTONLY |
                (uint) Win32Consts.PrintWindowMode.PW_RENDERFULLCONTENT);
            return ret;
        }
    }
}