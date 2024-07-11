using System;
using System.Windows.Forms;

namespace XXAssistant
{
    public partial class AutoStall : AntdUI.Window
    {
        public AutoStall(bool top)
        {
            InitializeComponent();
            TopMost = top;          
            Task.Run(Init);
        }
        /*�Զ���̯�߼�
        1.��Home��ʼ������������Ʒ  
        2.ɨ��ͼƬ����Ʒ���Ƶ��б���
        3.���б������붨��
        4.��End�Զ�����

        V1.1����
        1.��ȡ��ǰ���չ���Ʒʵʱ�۸�
        */
        private void Start()
        {
          
        }
        public void Init() {
            Thread.Sleep(500);
            Notify("���ǿԦ��!���ǿԦ��!���ǿԦ��!");
        }

        private void Notify(string message)
        {
            AntdUI.Notification.success(this, "��ʾ", message, AntdUI.TAlignFrom.Top, Font);
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
    }
}
