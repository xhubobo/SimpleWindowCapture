using System;
using System.Collections.Generic;
using Win32Proxy;

namespace CaptureProxy
{
    public class CaptureService
    {
        private readonly Dictionary<string, ICaptureHelper> _dicCaptureHelper;

        /// <summary>
        /// 注册抓图服务
        /// </summary>
        /// <param name="name">抓图服务名称</param>
        /// <param name="windowName">窗口名称</param>
        /// <param name="type">抓图类型</param>
        /// <returns>true成功,false失败</returns>
        public bool RegisterCapture(string name, string windowName, CaptureType type = CaptureType.CreateDibSection)
        {
            if (string.IsNullOrEmpty(name) || _dicCaptureHelper.ContainsKey(name))
            {
                return false;
            }

            ICaptureHelper helper;
            switch (type)
            {
                case CaptureType.CreateDibSection:
                    helper = new DibCaptureHelper();
                    break;
                case CaptureType.PrintWindow:
                    helper = new PrintCaptureHelper();
                    break;
                default:
                    return false;
            }

            if (!helper.Init(windowName))
            {
                return false;
            }

            _dicCaptureHelper.Add(name, helper);

            return true;
        }

        /// <summary>
        /// 注册抓图服务
        /// </summary>
        /// <param name="name">抓图服务名称</param>
        /// <param name="handle">窗口句柄</param>
        /// <param name="type">抓图类型</param>
        /// <returns>true成功,false失败</returns>
        public bool RegisterCapture(string name, IntPtr handle, CaptureType type = CaptureType.CreateDibSection)
        {
            if (string.IsNullOrEmpty(name) || _dicCaptureHelper.ContainsKey(name))
            {
                return false;
            }

            ICaptureHelper helper;
            switch (type)
            {
                case CaptureType.CreateDibSection:
                    helper = new DibCaptureHelper();
                    break;
                case CaptureType.PrintWindow:
                    helper = new PrintCaptureHelper();
                    break;
                default:
                    return false;
            }

            if (!helper.Init(handle))
            {
                return false;
            }

            _dicCaptureHelper.Add(name, helper);

            return true;
        }

        /// <summary>
        /// 获取是否已注册抓图服务
        /// </summary>
        /// <param name="name">抓图服务名称</param>
        /// <returns>true已注册,false未注册</returns>
        public bool IsRegister(string name)
        {
            return !string.IsNullOrEmpty(name) && _dicCaptureHelper.ContainsKey(name);
        }

        /// <summary>
        /// 注销抓图服务
        /// </summary>
        /// <param name="name">抓图服务名称</param>
        public void UnRegisterCapture(string name)
        {
            if (string.IsNullOrEmpty(name) || !_dicCaptureHelper.ContainsKey(name))
            {
                return;
            }

            _dicCaptureHelper[name]?.Cleanup();
            _dicCaptureHelper.Remove(name);
        }

        /// <summary>
        /// 清理所有抓图服务
        /// </summary>
        public void Cleanup()
        {
            foreach (var helper in _dicCaptureHelper)
            {
                helper.Value?.Cleanup();
            }

            _dicCaptureHelper.Clear();
        }

        public bool RefreshWindow(string name)
        {
            var ret = !string.IsNullOrEmpty(name) && _dicCaptureHelper.ContainsKey(name);
            if (ret)
            {
                ret = _dicCaptureHelper[name].RefreshWindow();
            }

            return ret;
        }

        /// <summary>
        /// 修改窗口句柄
        /// </summary>
        /// <param name="name">抓图服务名称</param>
        /// <param name="handle">窗口句柄</param>
        public bool ChangeWindowHandle(string name, IntPtr handle)
        {
            return !string.IsNullOrEmpty(name) && _dicCaptureHelper.ContainsKey(name) &&
                   _dicCaptureHelper[name].ChangeWindowHandle(handle);
        }

        /// <summary>
        /// 修改窗口句柄
        /// </summary>
        /// <param name="name">抓图服务名称</param>
        /// <param name="windowName">窗口名称</param>
        public bool ChangeWindowHandle(string name, string windowName)
        {
            return !string.IsNullOrEmpty(name) && _dicCaptureHelper.ContainsKey(name) &&
                   _dicCaptureHelper[name].ChangeWindowHandle(windowName);
        }

        /// <summary>
        /// 获取窗口尺寸
        /// </summary>
        /// <param name="name">抓图服务名称</param>
        /// <param name="winRect">输出的窗口尺寸</param>
        /// <returns>true成功,false失败</returns>
        public bool GetWindowRect(string name, out Win32Types.Rect winRect)
        {
            var ret = !string.IsNullOrEmpty(name) && _dicCaptureHelper.ContainsKey(name);
            winRect = ret ? _dicCaptureHelper[name].WindowRect : new Win32Types.Rect();
            return ret;
        }

        /// <summary>
        /// 获取窗口客户区尺寸
        /// </summary>
        /// <param name="name">抓图服务名称</param>
        /// <param name="clientRect">输出的窗口客户区尺寸</param>
        /// <returns>true成功,false失败</returns>
        public bool GetClientRect(string name, out Win32Types.Rect clientRect)
        {
            var ret = !string.IsNullOrEmpty(name) && _dicCaptureHelper.ContainsKey(name);
            clientRect = ret ? _dicCaptureHelper[name].ClientRect : new Win32Types.Rect();
            return ret;
        }

        /// <summary>
        /// 获取抓图数据大小
        /// </summary>
        /// <param name="name">抓图服务名称</param>
        /// <param name="bmpDataSize">抓图数据大小</param>
        /// <returns>true成功,false失败</returns>
        public bool GetBitmapDataSize(string name, out int bmpDataSize)
        {
            var ret = !string.IsNullOrEmpty(name) && _dicCaptureHelper.ContainsKey(name);
            bmpDataSize = ret ? _dicCaptureHelper[name].BitmapDataSize : 0;
            return ret;
        }

        public IntPtr GetBitmapPtr(string name)
        {
            if (string.IsNullOrEmpty(name) || !_dicCaptureHelper.ContainsKey(name))
            {
                return IntPtr.Zero;
            }

            return _dicCaptureHelper[name].BitmapPtr;
        }

        public Win32Types.BitmapInfo GetBitmapInfo(string name)
        {
            if (string.IsNullOrEmpty(name) || !_dicCaptureHelper.ContainsKey(name))
            {
                return new Win32Types.BitmapInfo();
            }

            return _dicCaptureHelper[name].BitmapInfo;
        }

        /// <summary>
        /// 获取抓图
        /// </summary>
        /// <param name="name">抓图服务名称</param>
        /// <param name="bitsPtr">位图指针</param>
        /// <returns>true成功,false失败</returns>
        public bool Capture(string name, out IntPtr bitsPtr)
        {
            var ret = !string.IsNullOrEmpty(name) && _dicCaptureHelper.ContainsKey(name);
            bitsPtr = ret ? _dicCaptureHelper[name].Capture() : IntPtr.Zero;
            return ret && !bitsPtr.Equals(IntPtr.Zero);
        }

        /// <summary>
        /// 获取抓图
        /// </summary>
        /// <param name="name">抓图服务名称</param>
        /// <param name="bitsPtr">位图指针</param>
        /// <param name="bufferSize">位图数据大小</param>
        /// <param name="texSize">位图尺寸</param>
        /// <returns>true成功,false失败</returns>
        public bool Capture(string name, out IntPtr bitsPtr, out int bufferSize, out Win32Types.Rect texSize)
        {
            if (string.IsNullOrEmpty(name) || !_dicCaptureHelper.ContainsKey(name))
            {
                bitsPtr = IntPtr.Zero;
                bufferSize = 0;
                texSize = new Win32Types.Rect();
                return false;
            }

            return _dicCaptureHelper[name].Capture(out bitsPtr, out bufferSize, out texSize);
        }

        #region 单例模式

        private static CaptureService _instance;

        private static readonly object LockHelper = new object();

        private CaptureService()
        {
            _dicCaptureHelper = new Dictionary<string, ICaptureHelper>();
        }

        public static CaptureService Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                lock (LockHelper)
                {
                    _instance = _instance ?? new CaptureService();
                }

                return _instance;
            }
        }

        #endregion
    }
}
