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
*/
    public partial class AutoResurrect : GeneralForm
    {
        int i_Interval = 200;
        private bool IsEnd = true;//�����Ƿ������
        public AutoResurrect(bool top)
        {
            InitializeComponent();
            TopMost = top;
            GlobalHook.AddEvent(Keys.Home, Operate);
            GlobalHook.AddEvent(Keys.End, Stop);
        }
        /// <summary>
        /// ��ʼ����
        /// </summary>
        public void Operate()
        {
            Thread.Sleep(5000);
            KeyMouseUtil.MouseClick();
            //dm dm = new dm(); // ��������
            //dm.SetMouseDelay("normal", 120);
            //dm.SetMouseDelay("windows", 120);
            //dm.SetMouseDelay("dx", 120);
            //dm.MoveTo(400,400);
            ////dm.KeyPress((int)Keys.Space);
            ////dm.LeftClick();
            //Thread.Sleep(100);
            //dm.ReleaseObj();
            return;
            if (!IsEnd)
                return;
            AutoClick();


        }
        public void AutoClick() {
            //�����޷���Ч����� ��ʱִ��
            Thread.Sleep(5*1000);
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
                    //ָ�����ڽ�ȡ���� ��ȡ������Ļ
                    var bmp = WindowCapture.CaptureFullScreen();
                    bmp.Save($"{folderPath}{Guid.NewGuid()}.bmp");                  
                    Thread.Sleep(i_Interval);
                }
                Notify("�������");
            }
            catch (Exception ex)
            {
                Error($"��������:{ex.Message}");
            }
        }
        /// <summary>
        /// ��ֹ����
        /// </summary>
        public void Stop()
        {
            IsEnd = true;
        }



    }
}
