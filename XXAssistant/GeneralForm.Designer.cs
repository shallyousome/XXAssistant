using AntdUI;

namespace XXAssistant
{
    partial class GeneralForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            iError2 = new AntdUI.Icon.IconError();
            panel_top = new AntdUI.Panel();
            label_title = new AntdUI.Label();
            btn_min = new AntdUI.Button();
            btn_max = new AntdUI.Button();
            btn_close = new AntdUI.Button();
            tooltipComponent1 = new TooltipComponent();
            tooltipComponent2 = new TooltipComponent();
            panel_top.SuspendLayout();
            SuspendLayout();
            // 
            // iError2
            // 
            iError2.Location = new Point(0, 0);
            iError2.Name = "iError2";
            iError2.Size = new Size(0, 0);
            iError2.TabIndex = 0;
            // 
            // panel_top
            // 
            panel_top.Controls.Add(label_title);
            panel_top.Controls.Add(btn_min);
            panel_top.Controls.Add(btn_max);
            panel_top.Controls.Add(btn_close);
            panel_top.Dock = DockStyle.Top;
            panel_top.Location = new Point(0, 0);
            panel_top.Name = "panel_top";
            panel_top.Size = new Size(1300, 40);
            panel_top.TabIndex = 0;
            // 
            // label_title
            // 
            label_title.Dock = DockStyle.Fill;
            label_title.Location = new Point(0, 0);
            label_title.Name = "label_title";
            label_title.Padding = new Padding(10, 0, 0, 0);
            label_title.Size = new Size(1142, 40);
            label_title.TabIndex = 0;
            label_title.Text = "Demo";
            // 
            // btn_min
            // 
            btn_min.BackActive = Color.FromArgb(172, 172, 172);
            btn_min.BackColor = Color.Transparent;
            btn_min.BackHover = Color.FromArgb(223, 223, 223);
            btn_min.Dock = DockStyle.Right;
            btn_min.Font = new Font("Microsoft YaHei UI Light", 18F);
            btn_min.Ghost = true;
            btn_min.Image = Properties.Resources.app_minb;
            btn_min.Location = new Point(1142, 0);
            btn_min.Name = "btn_min";
            btn_min.Size = new Size(50, 40);
            btn_min.TabIndex = 3;
            btn_min.Click += btn_min_Click;
            // 
            // btn_max
            // 
            btn_max.BackActive = Color.FromArgb(172, 172, 172);
            btn_max.BackColor = Color.Transparent;
            btn_max.BackHover = Color.FromArgb(223, 223, 223);
            btn_max.Dock = DockStyle.Right;
            btn_max.Font = new Font("Microsoft YaHei UI Light", 18F);
            btn_max.Ghost = true;
            btn_max.Image = Properties.Resources.app_maxb;
            btn_max.Location = new Point(1192, 0);
            btn_max.Name = "btn_max";
            btn_max.Size = new Size(50, 40);
            btn_max.TabIndex = 2;
            btn_max.Click += btn_max_Click;
            // 
            // btn_close
            // 
            btn_close.BackActive = Color.FromArgb(145, 31, 20);
            btn_close.BackColor = Color.Transparent;
            btn_close.BackHover = Color.FromArgb(196, 43, 28);
            btn_close.Dock = DockStyle.Right;
            btn_close.Font = new Font("Microsoft YaHei UI Light", 20F);
            btn_close.Ghost = true;
            btn_close.Image = Properties.Resources.app_closeb;
            btn_close.ImageHover = Properties.Resources.app_close;
            btn_close.Location = new Point(1242, 0);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(58, 40);
            btn_close.TabIndex = 1;
            btn_close.Click += btn_close_Click;
            // 
            // tooltipComponent1
            // 
            tooltipComponent1.Font = new Font("Microsoft YaHei UI Light", 9F);
            // 
            // tooltipComponent2
            // 
            tooltipComponent2.Font = new Font("Microsoft YaHei UI Light", 12F);
            // 
            // GeneralForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(600, 450);
            Controls.Add(panel_top);
            Font = new Font("Microsoft YaHei UI Light", 12F);
            ForeColor = Color.Black;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(600, 450);
            Name = "GeneralForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "基类窗体";
            panel_top.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        protected AntdUI.Icon.IconError iError2;
        protected AntdUI.Panel panel_top;
        protected AntdUI.Label label_title;
        protected AntdUI.Button btn_close;
        protected AntdUI.Button btn_min;
        protected AntdUI.Button btn_max;
        protected AntdUI.TooltipComponent tooltipComponent1;
        protected AntdUI.TooltipComponent tooltipComponent2;
    }
}
