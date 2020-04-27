using System;
using System.IO;
using System.Runtime.InteropServices;
using Win32Proxy;

namespace CaptureProxy
{
    internal sealed class BitmapHelper
    {
        /// <summary>
        /// 保存位图到文件
        /// </summary>
        /// <param name="bitmapInfo">位图信息</param>
        /// <param name="bmpDataSize">位图数据大小</param>
        /// <param name="bitsPtr">位图地址</param>
        /// <param name="filePath">文件路径</param>
        public static void SaveBitmapToFile(Win32Types.BitmapInfo bitmapInfo, int bmpDataSize, IntPtr bitsPtr, string filePath)
        {
            var headerSize = (int)bitmapInfo.bmiHeader.biSize;
            var headerBuffer = StructToBytes(bitmapInfo.bmiHeader, headerSize);

            var fileHeader = new Win32Types.BitmapFileHeader();
            var fileHeaderSize = Marshal.SizeOf(fileHeader) + bitmapInfo.bmiHeader.biSize;
            fileHeader.bfType = 0x4D42; //"BM"
            fileHeader.bfSize = (uint)fileHeaderSize + (uint)bmpDataSize;
            fileHeader.bfOffBits = (uint)fileHeaderSize;
            fileHeader.bfReserved1 = 0;
            fileHeader.bfReserved2 = 0;
            var fileHeaderBuffer = StructToBytes(fileHeader, Marshal.SizeOf(fileHeader));

            var dataBuffer = new byte[bmpDataSize];
            Marshal.Copy(bitsPtr, dataBuffer, 0, bmpDataSize);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            
            var file = File.Open(filePath, FileMode.Create);
            var binary = new BinaryWriter(file);
            binary.Write(fileHeaderBuffer, 0, Marshal.SizeOf(fileHeader));
            binary.Write(headerBuffer, 0, headerSize);
            binary.Write(dataBuffer, 0, bmpDataSize);
            binary.Flush();

            file.Close();
            file.Dispose();
        }

        //将结构体对象转换为byte数组
        private static byte[] StructToBytes(object structObj, int size)
        {
            var bytes = new byte[size];
            var structPtr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(structObj, structPtr, false); //将结构体拷到分配好的内存空间
            Marshal.Copy(structPtr, bytes, 0, size); //从内存空间拷贝到byte数组
            Marshal.FreeHGlobal(structPtr); //释放内存空间
            return bytes;
        }
    }
}