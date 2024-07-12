using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXAssistant
{
    public static class GlobalHook
    {
        public static Dictionary<Keys, Action> dic_Event = new Dictionary<Keys, Action>();
        private static IKeyboardMouseEvents m_GlobalHook;
        static GlobalHook() {
            SubscribeHook();
        }
        public static void SubscribeHook()
        {
            // Note: for the application hook, use the Hook.AppEvents() instead
            m_GlobalHook = Hook.GlobalEvents();
            //m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            //m_GlobalHook.KeyPress += GlobalHookKeyPress;//KeyPress只能检测到字符键,无法检测到非字符键
            m_GlobalHook.KeyDown += GlobalHookKeyDown;
        }
        /// <summary>
        /// 注册按键事件
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="action">事件</param>
        public static void AddEvent(Keys key, Action action)
        {
            dic_Event[key] = action;
        }
        private static void GlobalHookKeyDown(object? sender, KeyEventArgs e)
        {
            if (dic_Event.ContainsKey(e.KeyCode))
            {
                var toExecute = dic_Event[e.KeyCode];
                Task.Run(toExecute);
            }
        }
        private static void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            //Notify($"KeyPress: \t{e.KeyChar}");
        }

        private static void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            //Notify($"MouseDown: \t{e.Button}; \t System Timestamp: \t{e.Timestamp}");
        }

        public static void UnsubscribeHook()
        {
            m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
            m_GlobalHook.KeyPress -= GlobalHookKeyPress;
            m_GlobalHook.KeyDown -= GlobalHookKeyDown;
            //It is recommened to dispose it
            m_GlobalHook.Dispose();
        }
    }
}
