#region License
// /////////////////////////////////////////////////////////////////////////////
// Copyright (c) DIGIBIRD(http://www.digibird.com.cn)
// 北京小鸟科技股份有限公司保留所有代码著作权，如有任何疑问请访问官方网站与我们联系。
// 代码只针对特定客户使用，不得在未经允许或授权的情况下对外传播扩散，恶意传播者自行承担法律后果。
// 本代码仅用于北京小鸟科技股份有限公司的DVCP等项目。
// 
// 创建日期:     2018/10/16 15:15:14
// 修改日期:     2018/10/19 17:55:29
// 文件名称:     Win32Helper
// 创建者:       zb
// 类描述:       Win32方法帮助类
// /////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Win32Proxy
{
    public static class Win32Helper
    {
        /// <summary>
        /// 设置窗口无边框
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        public static void SetWindowNoBorder(IntPtr hWnd)
        {
            var wndStyle = (long)Win32Funcs.GetWindowLongWrapper(hWnd, Win32Consts.GWL_STYLE);
            wndStyle &= ~Win32Consts.WS_CAPTION;
            wndStyle &= ~Win32Consts.WS_THICKFRAME;
            //WS_BORDER,WS_DLGFRAME;
            Win32Funcs.SetWindowLongWrapper(hWnd, Win32Consts.GWL_STYLE, (int)wndStyle);
        }

        /// <summary>
        /// 将窗口置顶
        /// </summary>
        /// <param name="windowName">窗口名称</param>
        public static void SetWindowTopMost(string windowName)
        {
            var hWnd = Win32Funcs.FindWindowWrapper(null, windowName);
            if (!hWnd.Equals(IntPtr.Zero))
            {
                SetWindowTopMost(hWnd);
            }
        }

        /// <summary>
        /// 将窗口置顶
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        public static void SetWindowTopMost(IntPtr hWnd)
        {
            //SWP_NOSIZE：维持当前尺寸（忽略cx和cy参数）
            //SWP_NOMOVE：维持当前位置（忽略X和Y参数）
            const uint flags = Win32Consts.SWP_NOSIZE | Win32Consts.SWP_NOMOVE;
            Win32Funcs.SetWindowPosWrapper(hWnd, Win32Consts.HWND_TOPMOST_PTR, 0, 0, 0, 0, flags);
            Win32Funcs.SendMessageWrapper(hWnd, Win32Consts.WM_SETFOCUS, IntPtr.Zero, IntPtr.Zero);

            Win32Funcs.SetForegroundWindowWrapper(hWnd);
        }

        /// <summary>
        /// 将窗口置底
        /// </summary>
        /// <param name="windowName">窗口名称</param>
        public static bool SetWindowBottom(string windowName)
        {
            var hWnd = Win32Funcs.FindWindowWrapper(null, windowName);
            return !hWnd.Equals(IntPtr.Zero) && SetWindowBottom(hWnd);
        }

        /// <summary>
        /// 将窗口置底
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        public static bool SetWindowBottom(IntPtr hWnd)
        {
            //SWP_NOSIZE：维持当前尺寸（忽略cx和cy参数）
            //SWP_NOMOVE：维持当前位置（忽略X和Y参数）
            const uint flags = Win32Consts.SWP_NOSIZE | Win32Consts.SWP_NOMOVE;
            return Win32Funcs.SetWindowPosWrapper(hWnd, Win32Consts.HWND_BOTTOM_PTR, 0, 0, 0, 0, (int) flags);
        }

        /// <summary>
        /// 永久将窗口置底
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        public static bool SetWindowBottomForever(IntPtr hWnd)
        {
            //SWP_NOSIZE：维持当前尺寸（忽略cx和cy参数）
            //SWP_NOMOVE：维持当前位置（忽略X和Y参数）
            const uint flags = Win32Consts.SWP_NOSIZE | Win32Consts.SWP_NOMOVE | Win32Consts.SE_SHUTDOWN_PRIVILEGE;
            return Win32Funcs.SetWindowPosWrapper(hWnd, Win32Consts.HWND_BOTTOM_PTR, 0, 0, 0, 0, (int)flags);
        }

        /// <summary>
        /// 将窗口移出屏幕可见区域
        /// </summary>
        /// <param name="windowName">窗口名称</param>
        public static void SetWindowOutOfScreen(string windowName)
        {
            var hWnd = Win32Funcs.FindWindowWrapper(null, windowName);
            if (!hWnd.Equals(IntPtr.Zero))
            {
                SetWindowOutOfScreen(hWnd);
            }
        }

        /// <summary>
        /// 将窗口移出屏幕可见区域
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        public static void SetWindowOutOfScreen(IntPtr hWnd)
        {
            //0, 1040, 147, 858
            Win32Types.Rect winRect;
            Win32Funcs.GetWindowRectWrapper(hWnd, out winRect);

            //0, 1024, 0, 672,ClientToScreen之后坐标为8,178
            Win32Types.Rect clientRect;
            Win32Funcs.GetClientRectWrapper(hWnd, out clientRect);

            var offset = winRect.Width - clientRect.Width;
            var x = -winRect.Width + offset + 1;
            var y = winRect.Top;

            const uint flags = Win32Consts.SWP_NOZORDER;
            Win32Funcs.SetWindowPosWrapper(hWnd, IntPtr.Zero, x, y, winRect.Width, winRect.Height, flags);
        }

        /// <summary>
        /// 设置窗口透明度
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="alpha">透明度</param>
        public static void SetWindowAlpha(IntPtr hWnd, byte alpha)
        {
            //在调用SetLayeredWindowAttributes 之前,需要给窗口加上WS_EX_LAYERED属性,否则会无效
            var wndExStyle = Win32Funcs.GetWindowLongWrapper(hWnd, Win32Consts.GWL_EXSTYLE);
            wndExStyle |= Win32Consts.WS_EX_LAYERED;
            Win32Funcs.SetWindowLongWrapper(hWnd, Win32Consts.GWL_EXSTYLE, wndExStyle);

            //设置透明度
            Win32Funcs.SetLayeredWindowAttributesWrapper(hWnd, 0, alpha, Win32Consts.LWA_ALPHA);
        }

        public static void ResizeWindow(IntPtr hWnd, int width, int height)
        {
            const uint flags = Win32Consts.SWP_FRAMECHANGED | Win32Consts.SWP_NOMOVE |
                               Win32Consts.SWP_NOZORDER | Win32Consts.SWP_NOOWNERZORDER;
            Win32Funcs.SetWindowPosWrapper(hWnd, IntPtr.Zero, 0, 0, width, height, flags);
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="windowName">窗口名称</param>
        public static void CloseWindow(string windowName)
        {
            var hWnd = Win32Funcs.FindWindowWrapper(null, windowName);
            if (!hWnd.Equals(IntPtr.Zero))
            {
                Win32Funcs.SendMessageWrapper(hWnd, Win32Consts.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }
        }

        #region 计算机操作

        /// <summary>
        /// 关机
        /// </summary>
        public static void SetComputerShutdown()
        {
            //参数 /s 的意思是要关闭计算机
            //参数 /t 0 的意思是告诉计算机 0 秒之后执行命令
            Process.Start("shutdown", "/s /t 0");
        }

        /// <summary>
        /// 重启
        /// </summary>
        public static void SetComputerRestart()
        {
            //参数 /r 的意思是要重新启动计算机
            Process.Start("shutdown", "/r /t 0");
        }

        /// <summary>
        /// 注销
        /// </summary>
        public static void SetComputerLogout()
        {
            Win32Funcs.ExitWindowsExWrapper(0, 0);
        }

        /// <summary>
        /// 锁定
        /// </summary>
        public static void SetComputerLock()
        {
            Win32Funcs.LockWorkStationWrapper();
        }

        /// <summary>
        /// 睡眠
        /// </summary>
        public static void SetComputerSleep()
        {
            Win32Funcs.SetSuspendStateWrapper(false, true, true);
        }

        /// <summary>
        /// 休眠
        /// </summary>
        public static void SetComputerHibernate()
        {
            Win32Funcs.SetSuspendStateWrapper(true, true, true);
        }

        #endregion

        public static IntPtr GetProcessWnd(uint pid)
        {
            var ptrWnd = IntPtr.Zero;

            var ret = Win32Funcs.EnumWindowsWrapper((hWnd, lParam) =>
            {
                if (IntPtr.Zero.Equals(Win32Funcs.GetParentWrapper(hWnd)))
                {
                    int id;
                    Win32Funcs.GetWindowThreadProcessIdWrapper(hWnd, out id);
                    if (new IntPtr(id).Equals(lParam))
                    {
                        ptrWnd = hWnd;
                        Win32Funcs.SetLastErrorWrapper(0);
                        return false;
                    }
                }

                return true;
            }, new IntPtr(pid));

            return (!ret && Marshal.GetLastWin32Error() == 0) ? ptrWnd : IntPtr.Zero;
        }

        public static void MinimizeWindow(IntPtr hWnd)
        {
            Win32Funcs.SendMessageWrapper(hWnd, Win32Consts.WM_SYSCOMMAND,
                new IntPtr(Win32Consts.SC_MINIMIZE), IntPtr.Zero);  //最小化
        }

        public static void MaximizeWindow(IntPtr hWnd)
        {
            Win32Funcs.SendMessageWrapper(hWnd, Win32Consts.WM_SYSCOMMAND,
                new IntPtr(Win32Consts.SC_MAXIMIZE), IntPtr.Zero);  //最大化
        }

        public static void RestoreWindow(IntPtr hWnd)
        {
            Win32Funcs.SendMessageWrapper(hWnd, Win32Consts.WM_SYSCOMMAND,
                new IntPtr(Win32Consts.SC_RESTORE), IntPtr.Zero);  //还原
        }

        public static void ShowTaskBar(bool show)
        {
            var cmd = show ? Win32Consts.SW_RESTORE : Win32Consts.SW_HIDE;

            //系统任务栏
            var handle = Win32Funcs.FindWindowWrapper("Shell_TrayWnd", null);
            if (!IntPtr.Zero.Equals(handle))
            {
                Win32Funcs.ShowWindowWrapper(handle, cmd);
            }

            //开始菜单栏按钮
            handle = Win32Funcs.FindWindowWrapper("Button", null);
            if (!IntPtr.Zero.Equals(handle))
            {
                Win32Funcs.ShowWindowWrapper(handle, cmd);
            }
        }

        //获取系统缩放比例
        public static float GetSystemScale()
        {
            //1. 当用户使用默认方法设置缩放时(更改文本、应用等项目的大小)，
            //   应该使用GetDeviceCaps(DESKTOPHORZRES)/GetDeviceCaps(HORZRES)获得缩放比例
            //2. 当用户使用高级模式中的自定义缩放时(高级缩放设置)，
            //   应该使用GetDeviceCaps(LOGPIXELSX)再除以0.96（再除以100，因为算出来的数字是百分比）
            //3. 经验证，Win10中上述两种情况下，第一种计算方法总能获取到正确的系统缩放比例
            var systemScale = 1.0f;
            var screenDc = Win32Funcs.GetDcWrapper(IntPtr.Zero);
            var dpiA = Win32Funcs.GetDeviceCapsWrapper(screenDc, Win32Consts.DESKTOPHORZRES) * 1.0f
                / Win32Funcs.GetDeviceCapsWrapper(screenDc, Win32Consts.HORZRES);
            var dpiB = Win32Funcs.GetDeviceCapsWrapper(screenDc, Win32Consts.LOGPIXELSX) / 0.96f / 100f;

            const float tolerance = 0.000001f;
            if (Math.Abs(dpiA - 1f) < tolerance)
            {
                systemScale = dpiB;
            }
            else if (Math.Abs(dpiB - 1f) < tolerance)
            {
                systemScale = dpiA;
            }
            else if (Math.Abs(dpiA - dpiB) < tolerance)
            {
                systemScale = dpiA;
            }
            else
            {
                //Error
            }

            Win32Funcs.ReleaseDcWrapper(IntPtr.Zero, screenDc);
            return systemScale;
        }
    }
}
