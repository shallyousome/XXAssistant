using Gma.System.MouseKeyHook;
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
        public AutoStall(bool top)
        {
            InitializeComponent();
            TopMost = top;            
            GlobalHook.AddEvent(Keys.Home, Operate);
            GlobalHook.AddEvent(Keys.End, Stop);
            //�����б�
            //����б�Ϊ��,ѡ��ɨ�� ����ѡ�ж���
            //�ɵ���ץͼ���


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
