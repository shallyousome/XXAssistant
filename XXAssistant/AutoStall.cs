using Gma.System.MouseKeyHook;
using PaddleOCRSharp;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using XXAssistant.Util;

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
3.����������
*/
    public partial class AutoStall : GeneralForm
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
            GlobalHook.AddEvent(Keys.Home, Operate);
            GlobalHook.AddEvent(Keys.End, Stop);
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
                var folderPath = AppDomain.CurrentDomain.BaseDirectory + "/current/";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                //�����ͼ
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
       


    }
}
