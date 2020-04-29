#region License
// /////////////////////////////////////////////////////////////////////////////
// Copyright (c) DIGIBIRD(http://www.digibird.com.cn)
// 北京小鸟科技股份有限公司保留所有代码著作权，如有任何疑问请访问官方网站与我们联系。
// 代码只针对特定客户使用，不得在未经允许或授权的情况下对外传播扩散，恶意传播者自行承担法律后果。
// 本代码仅用于北京小鸟科技股份有限公司的DVCP等项目。
// 
// 创建日期:     2018-10-13 12:45:00
// 修改日期:     2019-09-19 10:38:23
// 文件名称:     Win32Consts
// 创建者:       zb
// 类描述:       Win32常量
// /////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.ComponentModel;

namespace Win32Proxy
{
    public class Win32Consts
    {
        public enum DibColorMode : uint
        {
            DIB_RGB_COLORS = 0x00,
            DIB_PAL_COLORS = 0x01,
            DIB_PAL_INDICES = 0x02
        }

        public enum BitmapCompressionMode : uint
        {
            BI_RGB = 0,
            BI_RLE8 = 1,
            BI_RLE4 = 2,
            BI_BITFIELDS = 3,
            BI_JPEG = 4,
            BI_PNG = 5
        }

        public enum RasterOperationMode : uint
        {
            SRCCOPY = 0x00CC0020,
            SRCPAINT = 0x00EE0086,
            SRCAND = 0x008800C6,
            SRCINVERT = 0x00660046,
            SRCERASE = 0x00440328,
            NOTSRCCOPY = 0x00330008,
            NOTSRCERASE = 0x001100A6,
            MERGECOPY = 0x00C000CA,
            MERGEPAINT = 0x00BB0226,
            PATCOPY = 0x00F00021,
            PATPAINT = 0x00FB0A09,
            PATINVERT = 0x005A0049,
            DSTINVERT = 0x00550009,
            BLACKNESS = 0x00000042,
            WHITENESS = 0x00FF0062,
            CAPTUREBLT = 0x40000000 //only if WinVer >= 5.0.0 (see wingdi.h)
        }

        public enum PrintWindowMode : uint
        {
            [Description(
                "Only the client area of the window is copied to hdcBlt. By default, the entire window is copied.")]
            PW_CLIENTONLY = 0x00000001,

            [Description("works on windows that use DirectX or DirectComposition")]
            PW_RENDERFULLCONTENT = 0x00000002
        }

        public const int GWL_WNDPROC = -4;
        public const int GWL_HINSTANCE = -6;
        public const int GWL_HWNDPARENT = -8;
        public const int GWL_STYLE = -16;
        public const int GWL_EXSTYLE = -20;
        public const int GWL_USERDATA = -21;
        public const int GWL_ID = -12;

        /*
         * System Menu Command Values
         */
        public const int SC_SIZE = 0xF000;
        public const int SC_MOVE = 0xF010;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_NEXTWINDOW = 0xF040;
        public const int SC_PREVWINDOW = 0xF050;
        public const int SC_CLOSE = 0xF060;
        public const int SC_VSCROLL = 0xF070;
        public const int SC_HSCROLL = 0xF080;
        public const int SC_MOUSEMENU = 0xF090;
        public const int SC_KEYMENU = 0xF100;
        public const int SC_ARRANGE = 0xF110;
        public const int SC_RESTORE = 0xF120;
        public const int SC_TASKLIST = 0xF130;
        public const int SC_SCREENSAVE = 0xF140;
        public const int SC_HOTKEY = 0xF150;

        /*
         * Window Styles
         */
        public const long WS_OVERLAPPED = 0x00000000L;
        public const long WS_POPUP = 0x80000000L;
        public const long WS_CHILD = 0x40000000L;
        public const long WS_MINIMIZE = 0x20000000L;
        public const long WS_VISIBLE = 0x10000000L;
        public const long WS_DISABLED = 0x08000000L;
        public const long WS_CLIPSIBLINGS = 0x04000000L;
        public const long WS_CLIPCHILDREN = 0x02000000L;
        public const long WS_MAXIMIZE = 0x01000000L;
        public const long WS_CAPTION = 0x00C00000L;     /* WS_BORDER | WS_DLGFRAME  */
        public const long WS_BORDER = 0x00800000L;
        public const long WS_DLGFRAME = 0x00400000L;
        public const long WS_VSCROLL = 0x00200000L;
        public const long WS_HSCROLL = 0x00100000L;
        public const long WS_SYSMENU = 0x00080000L;
        public const long WS_THICKFRAME = 0x00040000L;
        public const long WS_GROUP = 0x00020000L;
        public const long WS_TABSTOP = 0x00010000L;

        public const long WS_MINIMIZEBOX = 0x00020000L;
        public const long WS_MAXIMIZEBOX = 0x00010000L;

        public const long WS_TILED = WS_OVERLAPPED;
        public const long WS_ICONIC = WS_MINIMIZE;
        public const long WS_SIZEBOX = WS_THICKFRAME;
        public const long WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW;

        /*
         * ShowWindow() Commands
         */
        public const int SW_HIDE = 0;
        public const int SW_SHOWNORMAL = 1;
        public const int SW_NORMAL = 1;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_MAXIMIZE = 3;
        public const int SW_SHOWNOACTIVATE = 4;
        public const int SW_SHOW = 5;
        public const int SW_MINIMIZE = 6;
        public const int SW_SHOWMINNOACTIVE = 7;
        public const int SW_SHOWNA = 8;
        public const int SW_RESTORE = 9;
        public const int SW_SHOWDEFAULT = 10;
        public const int SW_FORCEMINIMIZE = 11;
        public const int SW_MAX = 11;

        /*
         * Common Window Styles
         */
        public const long WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED |
                                                 WS_CAPTION |
                                                 WS_SYSMENU |
                                                 WS_THICKFRAME |
                                                 WS_MINIMIZEBOX |
                                                 WS_MAXIMIZEBOX);

        public const long WS_POPUPWINDOW = (WS_POPUP |
                                            WS_BORDER |
                                            WS_SYSMENU);

        public const long WS_CHILDWINDOW = (WS_CHILD);

        public const long WS_EX_TOPMOST = 0x00000008L; //窗口置顶(停留在所有非最高层窗口的上面)
        public const int WS_EX_LAYERED = 0x00080000; //分层或透明窗口,该样式可使用混合特效
        public const long WS_EX_NOACTIVATE = 0x08000000L; //处于顶层但不激活

        //窗口Z序标识（如果uFlags参数中设置了SWP_NOZORDER标记则本参数将被忽略）
        public const int HWND_TOP = 0;
        public const int HWND_BOTTOM = 1;
        public const int HWND_TOPMOST = -1;
        public const int HWND_NOTOPMOST = -2;
        public static readonly IntPtr HWND_BOTTOM_PTR = new IntPtr(HWND_BOTTOM);
        public static readonly IntPtr HWND_TOP_PTR = new IntPtr(HWND_TOP);
        public static readonly IntPtr HWND_TOPMOST_PTR = new IntPtr(HWND_TOPMOST);
        public static readonly IntPtr HWND_NOTOPMOST_PTR = new IntPtr(HWND_NOTOPMOST);

        public const uint SWP_NOSIZE = 0x0001;
        public const uint SWP_NOMOVE = 0x0002;
        public const uint SWP_NOZORDER = 0x0004;
        public const uint SWP_NOREDRAW = 0x0008;
        public const uint SWP_NOACTIVATE = 0x0010;
        public const uint SWP_FRAMECHANGED = 0x0020;    /* The frame changed: send WM_NCCALCSIZE */
        public const uint SWP_SHOWWINDOW = 0x0040;
        public const uint SWP_HIDEWINDOW = 0x0080;
        public const uint SWP_NOCOPYBITS = 0x0100;
        public const uint SWP_NOOWNERZORDER = 0x0200;   /* Don't do owner Z ordering */
        public const uint SWP_NOSENDCHANGING = 0x0400;  /* Don't send WM_WINDOWPOSCHANGING */

        public const int SE_SHUTDOWN_PRIVILEGE = 0x13;

        public const int WM_ACTIVATEAPP = 0x001C;
        public const int WM_ACTIVATE = 0x0006;
        public const uint WM_SETFOCUS = 0x0007;
        public const uint WM_KILLFOCUS = 0x0008;
        public const uint WM_ENABLE = 0x000A;
        public const uint WM_SETREDRAW = 0x000B;
        public const uint WM_SETTEXT = 0x000C;
        public const uint WM_GETTEXT = 0x000D;
        public const uint WM_GETTEXTLENGTH = 0x000E;
        public const uint WM_PAINT = 0x000F;
        public const uint WM_CLOSE = 0x0010;
        public const uint WM_INITDIALOG = 0x0110;
        public const uint WM_COMMAND = 0x0111;
        public const uint WM_SYSCOMMAND = 0x0112;
        public const uint WM_TIMER = 0x0113;
        public const uint WM_HSCROLL = 0x0114;
        public const uint WM_VSCROLL = 0x0115;
        public const uint WM_INITMENU = 0x0116;
        public const uint WM_INITMENUPOPUP = 0x0117;

        public const uint LWA_COLORKEY = 0x00000001;
        public const uint LWA_ALPHA = 0x00000002;

        public const uint ULW_COLORKEY = 0x00000001;
        public const uint ULW_ALPHA = 0x00000002;
        public const uint ULW_OPAQUE = 0x00000004;

        //
        // currentlly defined blend function
        //
        public const byte AC_SRC_OVER = 0x00;

        //
        // alpha format flags
        //
        public const byte AC_SRC_ALPHA = 0x01;

        /// <summary>
        /// An existing connection was forcibly closed by the remote host.
        /// </summary>
        public const long WSAECONNRESET = 10054L;

        /* Device Parameters for GetDeviceCaps() */
        public const int DRIVERVERSION = 0;     /* Device driver version                    */
        public const int TECHNOLOGY = 2;        /* Device classification                    */
        public const int HORZSIZE = 4;          /* Horizontal size in millimeters           */
        public const int VERTSIZE = 6;          /* Vertical size in millimeters             */
        public const int HORZRES = 8;           /* Horizontal width in pixels               */
        public const int VERTRES = 10;          /* Vertical height in pixels                */
        public const int BITSPIXEL = 12;        /* Number of bits per pixel                 */
        public const int PLANES = 14;           /* Number of planes                         */
        public const int NUMBRUSHES = 16;       /* Number of brushes the device has         */
        public const int NUMPENS = 18;          /* Number of pens the device has            */
        public const int NUMMARKERS = 20;       /* Number of markers the device has         */
        public const int NUMFONTS = 22;         /* Number of fonts the device has           */
        public const int NUMCOLORS = 24;        /* Number of colors the device supports     */
        public const int PDEVICESIZE = 26;      /* Size required for device descriptor      */
        public const int CURVECAPS = 28;        /* Curve capabilities                       */
        public const int LINECAPS = 30;         /* Line capabilities                        */
        public const int POLYGONALCAPS = 32;    /* Polygonal capabilities                   */
        public const int TEXTCAPS = 34;         /* Text capabilities                        */
        public const int CLIPCAPS = 36;         /* Clipping capabilities                    */
        public const int RASTERCAPS = 38;       /* Bitblt capabilities                      */
        public const int ASPECTX = 40;          /* Length of the X leg                      */
        public const int ASPECTY = 42;          /* Length of the Y leg                      */
        public const int ASPECTXY = 44;         /* Length of the hypotenuse                 */

        public const int LOGPIXELSX = 88;       /* Logical pixels/inch in X                 */
        public const int LOGPIXELSY = 90;       /* Logical pixels/inch in Y                 */

        public const int SIZEPALETTE = 104;     /* Number of entries in physical palette    */
        public const int NUMRESERVED = 106;     /* Number of reserved entries in palette    */
        public const int COLORRES = 108;        /* Actual color resolution                  */

        // Printing related DeviceCaps. These replace the appropriate Escapes

        public const int PHYSICALWIDTH = 110;   /* Physical Width in device units           */
        public const int PHYSICALHEIGHT = 111;  /* Physical Height in device units          */
        public const int PHYSICALOFFSETX = 112; /* Physical Printable Area x margin         */
        public const int PHYSICALOFFSETY = 113; /* Physical Printable Area y margin         */
        public const int SCALINGFACTORX = 114;  /* Scaling factor x                         */
        public const int SCALINGFACTORY = 115;  /* Scaling factor y                         */

        // Display driver specific

        public const int VREFRESH = 116;        /* Current vertical refresh rate of the    */
                                                /* display device (for displays only) in Hz*/
        public const int DESKTOPVERTRES = 117;  /* Horizontal width of entire desktop in   */
                                                /* pixels                                  */
        public const int DESKTOPHORZRES = 118;  /* Vertical height of entire desktop in    */
                                                /* pixels                                  */
        public const int BLTALIGNMENT = 119;    /* Preferred blt alignment                 */

        #region (WINVER >= 0x0500)
        public const int SHADEBLENDCAPS = 120;  /* Shading and blending caps               */
        public const int COLORMGMTCAPS = 121;   /* Color Management caps                   */
        #endregion /* WINVER >= 0x0500 */

        public const int WH_MSGFILTER = -1;
        public const int WH_JOURNALRECORD = 0;
        public const int WH_JOURNALPLAYBACK = 1;
        public const int WH_KEYBOARD = 2;

        public const int WH_GETMESSAGE = 3;

        //Installs a hook procedure that monitors messages before the system
        //sends them to the destination window procedure. For more information,
        //see the CallWndProc hook procedure.
        public const int WH_CALLWNDPROC = 4;

        public const int WH_CBT = 5;

        //Installs a hook procedure that monitors messages generated as a result of an input event
        //in a dialog box, message box, menu, or scroll bar. The hook procedure monitors these
        //messages for all applications in the same desktop as the calling thread. For more information,
        //see the SysMsgProc hook procedure.
        public const int WH_SYSMSGFILTER = 6;
        public const int WH_MOUSE = 7;
        public const int WH_DEBUG = 9;
        public const int WH_SHELL = 10;
        public const int WH_FOREGROUNDIDLE = 11;
        public const int WH_CALLWNDPROCRET = 12;
        public const int WH_KEYBOARD_LL = 13;
        public const int WH_MOUSE_LL = 14;

        public const uint WM_COPYDATA = 0x004A;
        public const uint WM_CANCELJOURNAL = 0x004B;
    }
}
