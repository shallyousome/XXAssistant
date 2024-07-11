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
        /*自动出摊逻辑
        1.按Home开始遍历背包内物品  
        2.扫描图片和物品名称到列表中
        3.在列表中输入定价
        4.按End自动定价

        V1.1内容
        1.获取当前可收购物品实时价格
        */
        private void Start()
        {
          
        }
        public void Init() {
            Thread.Sleep(500);
            Notify("请加强驭剑!请加强驭剑!请加强驭剑!");
        }

        private void Notify(string message)
        {
            AntdUI.Notification.success(this, "提示", message, AntdUI.TAlignFrom.Top, Font);
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
