namespace XXAssistant
{
    partial class AutoStall
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
            progress4 = new AntdUI.Progress();
            progress5 = new AntdUI.Progress();
            iComplete1 = new AntdUI.Icon.IconComplete();
            progress6 = new AntdUI.Progress();
            iError2 = new AntdUI.Icon.IconError();
            progress7 = new AntdUI.Progress();
            progress8 = new AntdUI.Progress();
            progress9 = new AntdUI.Progress();
            panel_top = new Panel();
            label_title = new Label();
            btn_min = new AntdUI.Button();
            btn_max = new AntdUI.Button();
            btn_close = new AntdUI.Button();
            tooltipComponent1 = new AntdUI.TooltipComponent();
            tooltipComponent2 = new AntdUI.TooltipComponent();
            panel_top.SuspendLayout();
            SuspendLayout();
            // 
            // progress4
            // 
            progress4.ContainerControl = this;
            progress4.Location = new Point(0, 0);
            progress4.Name = "progress4";
            progress4.Size = new Size(0, 0);
            progress4.TabIndex = 21;
            // 
            // progress5
            // 
            progress5.ContainerControl = this;
            progress5.Location = new Point(0, 0);
            progress5.Name = "progress5";
            progress5.Size = new Size(0, 0);
            progress5.TabIndex = 19;
            // 
            // iComplete1
            // 
            iComplete1.Anchor = AnchorStyles.None;
            iComplete1.Back = Color.Transparent;
            iComplete1.Color = Color.FromArgb(0, 204, 0);
            iComplete1.Location = new Point(35, 35);
            iComplete1.Name = "iComplete1";
            iComplete1.Size = new Size(40, 40);
            iComplete1.TabIndex = 11;
            // 
            // progress6
            // 
            progress6.ContainerControl = this;
            progress6.Location = new Point(0, 0);
            progress6.Name = "progress6";
            progress6.Size = new Size(0, 0);
            progress6.TabIndex = 17;
            // 
            // iError2
            // 
            iError2.Location = new Point(0, 0);
            iError2.Name = "iError2";
            iError2.Size = new Size(0, 0);
            iError2.TabIndex = 0;
            // 
            // progress7
            // 
            progress7.ContainerControl = this;
            progress7.Location = new Point(0, 0);
            progress7.Name = "progress7";
            progress7.Size = new Size(0, 0);
            progress7.TabIndex = 20;
            // 
            // progress8
            // 
            progress8.ContainerControl = this;
            progress8.Location = new Point(0, 0);
            progress8.Name = "progress8";
            progress8.Size = new Size(0, 0);
            progress8.TabIndex = 18;
            // 
            // progress9
            // 
            progress9.ContainerControl = this;
            progress9.Location = new Point(0, 0);
            progress9.Name = "progress9";
            progress9.Size = new Size(0, 0);
            progress9.TabIndex = 16;
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
            label_title.Text = "寻仙摆摊助手";
            label_title.TextAlign = ContentAlignment.MiddleLeft;
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
            // AutoStall
            // 
            BackColor = Color.White;
            ClientSize = new Size(1300, 720);
            Controls.Add(panel_top);
            Controls.Add(progress9);
            Controls.Add(progress6);
            Controls.Add(progress8);
            Controls.Add(progress5);
            Controls.Add(progress7);
            Controls.Add(progress4);
            Font = new Font("Microsoft YaHei UI Light", 12F);
            ForeColor = Color.Black;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1300, 720);
            Name = "AutoStall";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "寻仙摆摊助手";
            panel_top.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private AntdUI.Progress progress4;
        private AntdUI.Progress progress5;
        private AntdUI.Progress progress6;
        private AntdUI.Icon.IconComplete iComplete1;
        private AntdUI.Icon.IconError iError2;
        private AntdUI.Progress progress7;
        private AntdUI.Progress progress8;
        private AntdUI.Progress progress9;
        private Panel panel_top;
        private Label label_title;
        private AntdUI.Button btn_close;
        private AntdUI.Button btn_min;
        private AntdUI.Button btn_max;
        private AntdUI.TooltipComponent tooltipComponent1;
        private AntdUI.TooltipComponent tooltipComponent2;
    }
}
