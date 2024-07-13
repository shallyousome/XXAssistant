using Gma.System.MouseKeyHook;
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
3.按键可配置
*/
    public partial class AutoStall : GeneralForm
    {
        private int i_Interval = 200;
        private bool IsEnd = true;//操作是否已完成
        public AutoStall(bool top)
        {
            InitializeComponent();
            TopMost = top;            
            GlobalHook.AddEvent(Keys.Home, Operate);
            GlobalHook.AddEvent(Keys.End, Stop);
            //加载列表
            //如果列表为空,选中扫描 否则选中定价
            //可调整抓图间隔


        }
        /// <summary>
        /// 开始操作
        /// </summary>
        public void Operate() {
            if (!IsEnd)
                return;
            if (rad_Scan.Checked)
            {
                Scan();
            }
            else if (rad_SetPrice.Checked)
            {
                SetPrice();
            }
            else
            {
                Error("未选中操作类型");
            }
            

        }
        /// <summary>
        /// 终止操作
        /// </summary>
        public void Stop() {
            IsEnd = true;
        }
        /// <summary>
        /// 定价
        /// </summary>
        private void SetPrice() {
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
                var folderPath = AppDomain.CurrentDomain.BaseDirectory + "/current/";
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
                    var bmp = WindowCapture.CaptureActiveWindow(initHandler);
                    bmp.Save($"{folderPath}{Guid.NewGuid()}.bmp");
                    //检测到匹配的物品自动定价
                    //检测到匹配物品=>记录当前鼠标位置=>tab或方向键是否可用=>输入定价=>返回鼠标位置
                    Thread.Sleep(i_Interval);
                }
                Notify("定价完成");
            }
            catch (Exception ex)
            {
                Error($"定价出错:{ex.Message}");
            }
        }

        /// <summary>
        /// 扫描背包物品
        /// </summary>
        private void Scan()
        {
            IsEnd = false;
            try
            {
                //Notify($"加强驭剑游侠!");
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
                    var bmp = WindowCapture.CaptureActiveWindow(initHandler);
                    bmp.Save($"{folderPath}{Guid.NewGuid()}.bmp");
                    Thread.Sleep(i_Interval);
                }
                Notify("扫描完成");
                //加载到列表中
                foreach (string filePath in Directory.GetFiles(folderPath))
                {
                    if (!filePath.EndsWith(".bmp"))
                        continue;
                    //识别内容
                    var bmp=new Bitmap(filePath);                 
               

                }
                //持久化


            }
            catch (Exception ex)
            {
                Error($"扫描出错:{ex.Message}");
            }
        }
       


    }
}
