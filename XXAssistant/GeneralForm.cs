using Gma.System.MouseKeyHook;
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
    public partial class GeneralForm : AntdUI.Window
    {
        /*
         �����ʱ����
         
         */
        public GeneralForm()
        {
            InitializeComponent();     

        }


        protected virtual void Notify(string message)
        {
            AntdUI.Notification.success(this, "��ʾ", message, AntdUI.TAlignFrom.Top, Font);
        }
        protected virtual void Error(string message)
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
        protected virtual void btn_close_Click(object? sender, EventArgs e)
        {
            Close();
        }

        protected virtual void btn_min_Click(object? sender, EventArgs e)
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

        protected virtual void btn_max_Click(object sender, EventArgs e)
        {
            MaxRestore();
        }
        #endregion


    }
}
