using System.ComponentModel;

namespace CaptureProxy
{
    public enum CaptureType
    {
        [Description("使用CreateDIBSection抓图，速度快，但是无法抓取D3D等渲染的窗口")]
        CreateDibSection = 0,

        [Description("使用PrintWindow抓图，速度慢(16ms左右)，但是可以抓取D3D等渲染的窗口")]
        PrintWindow
    }
}
