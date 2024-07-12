using AntdUI;

namespace XXAssistant
{
    partial class AutoResurrect
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoResurrect));
            label1 = new AntdUI.Label();
            panel_top.SuspendLayout();
            SuspendLayout();
            // 
            // panel_top
            // 
            panel_top.Size = new Size(616, 40);
            // 
            // label_title
            // 
            label_title.Size = new Size(458, 40);
            // 
            // btn_close
            // 
            btn_close.Location = new Point(558, 0);
            // 
            // btn_min
            // 
            btn_min.Location = new Point(458, 0);
            // 
            // btn_max
            // 
            btn_max.Image = (Image)resources.GetObject("btn_max.Image");
            btn_max.Location = new Point(508, 0);
            // 
            // label1
            // 
            label1.Location = new Point(32, 59);
            label1.Name = "label1";
            label1.Size = new Size(215, 30);
            label1.TabIndex = 1;
            label1.Text = "Home键开始，End键结束";
            // 
            // AutoResurrect
            // 
            ClientSize = new Size(616, 489);
            Controls.Add(label1);
            Name = "AutoResurrect";
            Text = "自动复活";
            Controls.SetChildIndex(panel_top, 0);
            Controls.SetChildIndex(label1, 0);
            panel_top.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label label1;
    }
}
