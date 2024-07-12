using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XXAssistant
{
    static class WindowCapture
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hdc, uint nFlags);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("gdi32.dll")]
        static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);

        const uint PW_CLIENT = 0x00000001;
        const uint PW_MAINWINDOW = 0x00000002;

        public static Bitmap CaptureActiveWindow(IntPtr hwnd)
        {
            IntPtr hdcSrc = CreateDC("DISPLAY", null, null, IntPtr.Zero);
            IntPtr hdcDest = CreateCompatibleDC(hdcSrc);
            Size size = GetWindowSize(hwnd);
            IntPtr hBitmap = CreateCompatibleBitmap(hdcSrc, size.Width, size.Height);
            IntPtr hOld = SelectObject(hdcDest, hBitmap);
            bool success = PrintWindow(hwnd, hdcDest, PW_CLIENT); // 捕获窗口客户区域
            if (!success)
            {
                // 如果失败，尝试捕获整个窗口
                success = PrintWindow(hwnd, hdcDest, PW_MAINWINDOW);
            }
            SelectObject(hdcDest, hOld);
            Bitmap bmp = Bitmap.FromHbitmap(hBitmap);
            DeleteObject(hBitmap);
            DeleteDC(hdcDest);
            ReleaseDC(hwnd, hdcSrc);
            return bmp;
        }

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll")]
        static extern bool DeleteObject(IntPtr hObject);

        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rect lpRect);

        private static Size GetWindowSize(IntPtr hwnd)
        {
            Rect rect;
            GetClientRect(hwnd, out rect);
            return new Size(rect.Right - rect.Left, rect.Bottom - rect.Top);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }
}
