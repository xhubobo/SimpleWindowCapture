using System;
using System.Threading;
using CaptureProxy;
using Win32Proxy;

namespace SimpleWindowCapture
{
    internal sealed class CaptureHelper
    {
        public event Action<string, IntPtr, Win32Types.BitmapInfo> CaptureDone =
            (captureName, bitmapPtr, bitmapInfo) => { };

        public int Fps { get; set; } = 15;

        private double TimerInterval => 1000.0 / Fps;
        private string _captureName;
        private Timer _timer;

        public bool Start(string captureName, IntPtr handle, CaptureType type = CaptureType.CreateDibSection)
        {
            if (!CaptureService.Instance.RegisterCapture(captureName, handle, type))
            {
                return false;
            }

            _captureName = captureName;

            //创建守护定时器，马上执行
            _timer = new Timer(CaptureFunc, null,
                TimeSpan.FromMilliseconds(0), Timeout.InfiniteTimeSpan);

            return true;
        }

        public void Stop()
        {
            //移除定时器
            _timer?.Dispose();
            _timer = null;

            CaptureService.Instance.UnRegisterCapture(_captureName);
            _captureName = string.Empty;
        }

        private void CaptureFunc(object state)
        {
            Capture();

            //执行下次定时器
            _timer?.Change(TimeSpan.FromMilliseconds(TimerInterval), Timeout.InfiniteTimeSpan);
        }

        private void Capture()
        {
            IntPtr bitsPtr;
            if (!CaptureService.Instance.GetCapture(_captureName, out bitsPtr))
            {
                return;
            }

            var bitmapPtr = CaptureService.Instance.GetBitmapPtr(_captureName);
            var bitmapInfo = CaptureService.Instance.GetBitmapInfo(_captureName);
            CaptureDone.Invoke(_captureName, bitmapPtr, bitmapInfo);
        }
    }
}
