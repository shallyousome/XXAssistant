using Gma.System.MouseKeyHook;
using PaddleOCRSharp;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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
    public partial class GeneralForm : AntdUI.Window
    {
        /*
         保存计时配置
         
         */
        public GeneralForm()
        {
            InitializeComponent();     

        }


        protected virtual void Notify(string message)
        {
            AntdUI.Notification.success(this, "提示", message, AntdUI.TAlignFrom.Top, Font);
        }
        protected virtual void Error(string message)
        {
            AntdUI.Notification.error(this, "错误", message, AntdUI.TAlignFrom.Top, Font);
        }
        #region 窗体事件
        //窗口可拖动
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
