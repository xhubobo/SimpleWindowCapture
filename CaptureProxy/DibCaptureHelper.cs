using System;
using System.IO;
using System.Runtime.InteropServices;
using Win32Proxy;

namespace CaptureProxy
{
    internal class DibCaptureHelper : ICaptureHelper
    {
        private IntPtr _hWnd = IntPtr.Zero;
        private IntPtr _hScrDc = IntPtr.Zero;
        private IntPtr _hMemDc = IntPtr.Zero;
        private IntPtr _hBitmap = IntPtr.Zero;
        private IntPtr _hOldBitmap = IntPtr.Zero;
        private IntPtr _bitsPtr = IntPtr.Zero;

        private Win32Types.BitmapInfo _bitmapInfo;
        private Win32Types.Rect _windowRect;
        private Win32Types.Rect _clientRect;
        private Win32Types.Point _bitbltStartPoint;
        private int _bmpDataSize;

        private bool _saveFile;

        public IntPtr GetBitmapPtr()
        {
            return _hBitmap;
        }

        public Win32Types.BitmapInfo GetBitmapInfo()
        {
            return _bitmapInfo;
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

        public bool Init(IntPtr handle)
        {
            _hWnd = handle;

            //获取窗口大小
            if (!Win32Funcs.GetWindowRectWrapper(_hWnd, out _windowRect)
                || !Win32Funcs.GetClientRectWrapper(_hWnd, out _clientRect))
            {
                return false;
            }

            _bitbltStartPoint.x = 0;
            _bitbltStartPoint.y = 0;

            _bmpDataSize = _clientRect.Width * _clientRect.Height * 3;

            //位图信息
            _bitmapInfo = new Win32Types.BitmapInfo {bmiHeader = new Win32Types.BitmapInfoHeader()};
            _bitmapInfo.bmiHeader.Init();
            _bitmapInfo.bmiHeader.biWidth = _clientRect.Width;
            _bitmapInfo.bmiHeader.biHeight = _clientRect.Height;
            _bitmapInfo.bmiHeader.biPlanes = 1;
            _bitmapInfo.bmiHeader.biBitCount = 24;
            _bitmapInfo.bmiHeader.biSizeImage = (uint) (_clientRect.Width * _clientRect.Height);
            _bitmapInfo.bmiHeader.biCompression = (uint) Win32Consts.BitmapCompressionMode.BI_RGB;

            _hScrDc = Win32Funcs.GetWindowDcWrapper(_hWnd);
            _hMemDc = Win32Funcs.CreateCompatibleDcWrapper(_hScrDc);
            _hBitmap = Win32Funcs.CreateDibSectionWrapper(_hMemDc, ref _bitmapInfo,
                (uint) Win32Consts.DibColorMode.DIB_RGB_COLORS,
                out _bitsPtr, IntPtr.Zero, 0);
            _hOldBitmap = Win32Funcs.SelectObjectWrapper(_hMemDc, _hBitmap);

            return true;
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
            _bitsPtr = IntPtr.Zero;
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
            if (_hBitmap.Equals(IntPtr.Zero) || _hMemDc.Equals(IntPtr.Zero) || _hScrDc.Equals(IntPtr.Zero))
            {
                return IntPtr.Zero;
            }

            var ret = Win32Funcs.BitBltWrapper(
                _hMemDc, 0, 0, _clientRect.Width, _clientRect.Height,
                _hScrDc, _bitbltStartPoint.x, _bitbltStartPoint.y,
                (uint) Win32Consts.RasterOperationMode.SRCCOPY);

            SaveFile();

            return ret ? _bitsPtr : IntPtr.Zero;
        }

        public bool GetCapture(out IntPtr bitsPtr, out int bufferSize, out Win32Types.Rect rect)
        {
            bitsPtr = _bitsPtr;
            bufferSize = _bmpDataSize;
            rect = _clientRect;

            if (_hBitmap.Equals(IntPtr.Zero) || _hMemDc.Equals(IntPtr.Zero) || _hScrDc.Equals(IntPtr.Zero))
            {
                return false;
            }

            var ret = Win32Funcs.BitBltWrapper(
                _hMemDc, 0, 0, _clientRect.Width, _clientRect.Height,
                _hScrDc, _bitbltStartPoint.x, _bitbltStartPoint.y,
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

            var headerSize = (int) _bitmapInfo.bmiHeader.biSize;
            var headerBuffer = StructToBytes(_bitmapInfo.bmiHeader, headerSize);

            var fileHeader = new Win32Types.BitmapFileHeader();
            var fileHeaderSize = Marshal.SizeOf(fileHeader) + _bitmapInfo.bmiHeader.biSize;
            fileHeader.bfType = 0x4D42; //"BM"
            fileHeader.bfSize = (uint) fileHeaderSize + (uint) _bmpDataSize;
            fileHeader.bfOffBits = (uint) fileHeaderSize;
            fileHeader.bfReserved1 = 0;
            fileHeader.bfReserved2 = 0;
            var fileHeaderBuffer = StructToBytes(fileHeader, Marshal.SizeOf(fileHeader));

            var dataBuffer = new byte[_bmpDataSize];
            Marshal.Copy(_bitsPtr, dataBuffer, 0, _bmpDataSize);

            var path = Path.Combine(Environment.CurrentDirectory, DateTime.Now.ToString("HHmmss") + ".bmp");
            var file = File.Open(path, FileMode.Create);
            var binary = new BinaryWriter(file);
            binary.Write(fileHeaderBuffer, 0, Marshal.SizeOf(fileHeader));
            binary.Write(headerBuffer, 0, headerSize);
            binary.Write(dataBuffer, 0, _bmpDataSize);
            binary.Flush();

            file.Seek(0, SeekOrigin.Begin);
            var bmpDataBuffer = new byte[file.Length];
            file.Read(bmpDataBuffer, 0, (int) file.Length);
            file.Close();
            file.Dispose();
        }

        //将Byte转换为结构体类型
        public static byte[] StructToBytes(object structObj, int size)
        {
            var bytes = new byte[size];
            var structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPtr, false);
            //从内存空间拷贝到byte 数组
            Marshal.Copy(structPtr, bytes, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            return bytes;
        }
    }
}
