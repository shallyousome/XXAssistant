using Gma.System.MouseKeyHook;
using PaddleOCRSharp;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace XXAssistant
{
    /*�Զ���̯�߼�    
1.��Home��ʼ������������Ʒ  
2.ɨ��ͼƬ����Ʒ���Ƶ��б���
3.���б������붨��
4.��End�Զ����۳�̯

V1.1����
1.��ȡ��ǰ���չ���Ʒʵʱ�۸�
2.���ӽ�����־���
*/
    public partial class AutoStall : AntdUI.Window
    {
        private int i_Interval = 200;
        private bool IsEnd = true;//�����Ƿ������
        //ocr
        private PaddleOCREngine engine;
        private PaddleStructureEngine structengine;
        public AutoStall(bool top)
        {
            InitializeComponent();
            TopMost = top;
            SubscribeHook();
            AddEvent(Keys.Home, Operate);
            AddEvent(Keys.End, Stop);
            //�����б�
            //����б�Ϊ��,ѡ��ɨ�� ����ѡ�ж���
            //�ɵ���ץͼ���
            #region OCR
            //�Դ���������Ӣ��ģ��V4ģ��
            OCRModelConfig config = null;
            //OCR����
            OCRParameter oCRParameter = new OCRParameter();
            oCRParameter.cpu_math_library_num_threads = 10;//Ԥ�Ⲣ���߳���
            oCRParameter.enable_mkldnn = true;
            oCRParameter.cls = false; //�Ƿ�ִ�����ַ�����ࣻĬ��false
            oCRParameter.det = true;//�Ƿ����ı����⣬���ڼ���ı���
            oCRParameter.use_angle_cls = false;//�Ƿ��������⣬���ڼ��ʶ��180��ת
            oCRParameter.det_db_score_mode = true;//�Ƿ�ʹ�ö���ߣ��������������ö���߻����þ��Σ�
            oCRParameter.max_side_len = 960;
            oCRParameter.rec_img_h = 48;
            oCRParameter.rec_img_w = 320;
            oCRParameter.det_db_thresh = 0.3f;
            oCRParameter.det_db_box_thresh = 0.618f;

            //��ʼ��OCR����
            engine = new PaddleOCREngine(config, oCRParameter);

            //ģ�����ã�ʹ��Ĭ��ֵ
            StructureModelConfig structureModelConfig = null;
            //���ʶ��������ã�ʹ��Ĭ��ֵ
            StructureParameter structureParameter = new StructureParameter();
            structengine = new PaddleStructureEngine(structureModelConfig, structureParameter);
            #endregion

        }
        /// <summary>
        /// ��ʼ����
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
                Error("δѡ�в�������");
            }
            

        }
        /// <summary>
        /// ��ֹ����
        /// </summary>
        public void Stop() {
            IsEnd = true;
        }
        /// <summary>
        /// ����
        /// </summary>
        private void SetPrice() {
            IsEnd = false;
            try
            {
                //��ǰ����ڸı��End����������ֹ����                 
                var initHandler = WindowCapture.GetForegroundWindow();
                if (initHandler == IntPtr.Zero)
                {
                    Error("δ��ȡ�������");
                    return;
                }
                var folderPath = AppDomain.CurrentDomain.BaseDirectory + "/setprice/";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                //�����ͼ
                CleanFile(folderPath);
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
                    //��⵽ƥ�����Ʒ�Զ�����
                    //��⵽ƥ����Ʒ=>��¼��ǰ���λ��=>tab������Ƿ����=>���붨��=>�������λ��
                    Thread.Sleep(i_Interval);
                }
                Notify("�������");
            }
            catch (Exception ex)
            {
                Error($"���۳���:{ex.Message}");
            }
        }

        /// <summary>
        /// ɨ�豳����Ʒ
        /// </summary>
        private void Scan()
        {
            IsEnd = false;
            try
            {
                //Notify($"��ǿԦ������!");
                //��ǰ����ڸı��End����������ֹ����                 
                var initHandler = WindowCapture.GetForegroundWindow();
                if (initHandler == IntPtr.Zero)
                {
                    Error("δ��ȡ�������");
                    return;
                }
                var folderPath = AppDomain.CurrentDomain.BaseDirectory + "/snap/";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                //�����ͼ
                CleanFile(folderPath);
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
                Notify("ɨ�����");
                //���ص��б���
                foreach (string filePath in Directory.GetFiles(folderPath))
                {
                    if (!filePath.EndsWith(".bmp"))
                        continue;
                    //ʶ������
                    var bmp=new Bitmap(filePath);                 
                    //��ͼ��Ʒ˵������ 
                    OCRResult ocrResult = engine.DetectText(bmp);
                    var totalText = "";
                    foreach (var item in ocrResult.TextBlocks)
                    {
                        totalText += item.Text + " ";
                    }              

                }
                //�־û�


            }
            catch (Exception ex)
            {
                Error($"ɨ�����:{ex.Message}");
            }
        }
        /// <summary>
        /// �����ļ���
        /// </summary>
        /// <param name="filepath"></param>
        public void CleanFile(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                foreach (string filePath in Directory.GetFiles(folderPath))
                {
                    File.Delete(filePath);
                }

                foreach (string directoryPath in Directory.GetDirectories(folderPath))
                {
                    CleanFile(directoryPath);
                    Directory.Delete(directoryPath);
                }
            }
        }
        private void Notify(string message)
        {
            AntdUI.Notification.success(this, "��ʾ", message, AntdUI.TAlignFrom.Top, Font);
        }
        private void Error(string message)
        {
            AntdUI.Notification.error(this, "����", message, AntdUI.TAlignFrom.Top, Font);
        }
        #region �����¼�
        //���ڿ��϶�
        protected override void OnMouseDown(MouseEventArgs e)
        {
            DraggableMouseDown();
            base.OnMouseDown(e);
        }
        private void btn_close_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void btn_min_Click(object? sender, EventArgs e)
        {
            Min();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                btn_max.Image = Properties.Resources.app_max2b;
            }
            else
            {
                btn_max.Image = Properties.Resources.app_maxb;
            }
            base.OnSizeChanged(e);
        }

        private void btn_max_Click(object sender, EventArgs e)
        {
            MaxRestore();
        }
        private void Button_Click(object? sender, EventArgs e)
        {

        }
        #endregion
        #region ȫ�ֹ���
        private Dictionary<Keys,Action> dic_Event= new Dictionary<Keys,Action>();
        private IKeyboardMouseEvents m_GlobalHook;
        public void SubscribeHook()
        {
            // Note: for the application hook, use the Hook.AppEvents() instead
            m_GlobalHook = Hook.GlobalEvents();
            //m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            //m_GlobalHook.KeyPress += GlobalHookKeyPress;//KeyPressֻ�ܼ�⵽�ַ���,�޷���⵽���ַ���
            m_GlobalHook.KeyDown+= GlobalHookKeyDown;
        }
        /// <summary>
        /// ע�ᰴ���¼�
        /// </summary>
        /// <param name="key">��ֵ</param>
        /// <param name="action">�¼�</param>
        private void AddEvent(Keys key,Action action)
        {
            dic_Event[key] = action;
        }
        private void GlobalHookKeyDown(object? sender, KeyEventArgs e)
        {
            if (dic_Event.ContainsKey(e.KeyCode))
            {
                var toExecute = dic_Event[e.KeyCode];
                Task.Run(toExecute);
            }           
        }
        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {              
            Notify($"KeyPress: \t{e.KeyChar}");              
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            Notify($"MouseDown: \t{e.Button}; \t System Timestamp: \t{e.Timestamp}");

        }

        public void UnsubscribeHook()
        {
            m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
            m_GlobalHook.KeyPress -= GlobalHookKeyPress;
            m_GlobalHook.KeyDown-= GlobalHookKeyDown;
            //It is recommened to dispose it
            m_GlobalHook.Dispose();
        }
        #endregion

    }
}
