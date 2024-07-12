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
3.按键可配置
*/
    public partial class AutoStall : GeneralForm
    {
        private int i_Interval = 200;
        private bool IsEnd = true;//操作是否已完成
        //ocr
        private PaddleOCREngine engine;
        private PaddleStructureEngine structengine;
        public AutoStall(bool top)
        {
            InitializeComponent();
            TopMost = top;            
            GlobalHook.AddEvent(Keys.Home, Operate);
            GlobalHook.AddEvent(Keys.End, Stop);
            //加载列表
            //如果列表为空,选中扫描 否则选中定价
            //可调整抓图间隔
            #region OCR
            //自带轻量版中英文模型V4模型
            OCRModelConfig config = null;
            //OCR参数
            OCRParameter oCRParameter = new OCRParameter();
            oCRParameter.cpu_math_library_num_threads = 10;//预测并发线程数
            oCRParameter.enable_mkldnn = true;
            oCRParameter.cls = false; //是否执行文字方向分类；默认false
            oCRParameter.det = true;//是否开启文本框检测，用于检测文本块
            oCRParameter.use_angle_cls = false;//是否开启方向检测，用于检测识别180旋转
            oCRParameter.det_db_score_mode = true;//是否使用多段线，即文字区域是用多段线还是用矩形，
            oCRParameter.max_side_len = 960;
            oCRParameter.rec_img_h = 48;
            oCRParameter.rec_img_w = 320;
            oCRParameter.det_db_thresh = 0.3f;
            oCRParameter.det_db_box_thresh = 0.618f;

            //初始化OCR引擎
            engine = new PaddleOCREngine(config, oCRParameter);

            //模型配置，使用默认值
            StructureModelConfig structureModelConfig = null;
            //表格识别参数配置，使用默认值
            StructureParameter structureParameter = new StructureParameter();
            structengine = new PaddleStructureEngine(structureModelConfig, structureParameter);
            #endregion

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
                    //截图物品说明部分 
                    OCRResult ocrResult = engine.DetectText(bmp);
                    var totalText = "";
                    foreach (var item in ocrResult.TextBlocks)
                    {
                        totalText += item.Text + " ";
                    }              

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
