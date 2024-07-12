using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XXAssistant.Util
{
    public static class KeyMouseUtil
    {
        // 模拟键盘按键
        [DllImport("user32.dll", SetLastError = true)]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        // 模拟鼠标移动
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        public const int KEYEVENTF_EXTENDEDKEY = 0x1;
        public const int KEYEVENTF_KEYUP = 0x2;
        public const int MOUSEEVENTF_MOVE = 0x1;
        public const int MOUSEEVENTF_LEFTDOWN = 0x2;
        public const int MOUSEEVENTF_LEFTUP = 0x4;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x8;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        public const int MOUSEEVENTF_MIDDLEUP = 0x40;
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        /// <summary>
        /// 按下和释放按键
        /// </summary>
        /// <param name="key"></param>
        public static void SendKey(Keys key) {
            //随机间隔防止检测
            Random random = new Random();
            var randomNum = random.Next(25, 50);
            keybd_event((byte)key, 0, 0, 0);            
            Thread.Sleep(randomNum);
            keybd_event((byte)key, 0, KEYEVENTF_KEYUP, 0);
        }
        public static void MouseClick() {
            //随机间隔防止检测
            Random random = new Random();
            var randomNum = random.Next(25, 50);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep(randomNum);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

        }

        public static void Test()
        {
            // 模拟按下和释放 'A' 键
            keybd_event((byte)Keys.A, 0, 0, 0);
            keybd_event((byte)Keys.A, 0, KEYEVENTF_KEYUP, 0);

            // 模拟鼠标移动到坐标(100, 100)并点击左键
            Cursor.Position = new System.Drawing.Point(100, 100);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
    }
}
