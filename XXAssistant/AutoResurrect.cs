using Gma.System.MouseKeyHook;
using PaddleOCRSharp;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using XXAssistant.Util;

namespace XXAssistant
{
    /*自动出摊逻辑    
1.按Home开始遍历背包内物品  
2.扫描图片和物品名称到列表中
3.在列表中输入定价
4.按End自动定价出摊

V1.1内容
1.获取当前可收购物品实时价格
2.增加界面日志输出
*/
    public partial class AutoResurrect : GeneralForm
    {
        int i_Interval = 200;
        private bool IsEnd = true;//操作是否已完成
        public AutoResurrect(bool top)
        {
            InitializeComponent();
            TopMost = top;
            GlobalHook.AddEvent(Keys.Home, Operate);
            GlobalHook.AddEvent(Keys.End, Stop);
        }
        /// <summary>
        /// 开始操作
        /// </summary>
        public void Operate()
        {
            Thread.Sleep(5000);
            KeyMouseUtil.MouseClick();
            Thread.Sleep(2000);
            KeyMouseUtil.MouseClick();
            Thread.Sleep(2000);
            KeyMouseUtil.MouseClick();
            Thread.Sleep(2000);
            return;

            if (!IsEnd)
                return;
            AutoClick();


        }
        public void AutoClick() {
            //钩子无法生效的情况 延时执行
            Thread.Sleep(5*1000);
            IsEnd = false;
            try
            {
                //当前活动窗口改变或按End键结束后终止操作                 
                var initHandler = WindowCapture.GetForegroundWindow();
                if (initHandler == IntPtr.Zero)
                {
                    Error("未获取到活动窗口");
                    return;
                }               


                var folderPath = AppDomain.CurrentDomain.BaseDirectory + "/snap/";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                //清理截图
                FileUtil.CleanFile(folderPath);
                while (!IsEnd)
                {
                    var currentHandler = WindowCapture.GetForegroundWindow();
                    if (currentHandler != initHandler)
                    {
                        IsEnd = true;
                        break;
                    }
                    //指定窗口截取不到 截取整个屏幕
                    var bmp = WindowCapture.CaptureFullScreen();
                    bmp.Save($"{folderPath}{Guid.NewGuid()}.bmp");                  
                    Thread.Sleep(i_Interval);
                }
                Notify("操作完成");
            }
            catch (Exception ex)
            {
                Error($"操作出错:{ex.Message}");
            }
        }
        /// <summary>
        /// 终止操作
        /// </summary>
        public void Stop()
        {
            IsEnd = true;
        }



    }
}
