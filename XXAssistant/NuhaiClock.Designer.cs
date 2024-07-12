using AntdUI;

namespace XXAssistant
{
    partial class NuhaiClock
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {            
            tbx_Hour = new Input();
            tbx_Minute = new Input();
            label1 = new AntdUI.Label();
            label2 = new AntdUI.Label();
            label3 = new AntdUI.Label();
            tbx_Interval = new Input();
            button1 = new AntdUI.Button();            
           
            // 
            // tbx_Hour
            // 
            tbx_Hour.Location = new Point(118, 108);
            tbx_Hour.Name = "tbx_Hour";
            tbx_Hour.Size = new Size(75, 32);
            tbx_Hour.TabIndex = 1;
            tbx_Hour.Text = "input1";
            // 
            // tbx_Minute
            // 
            tbx_Minute.Location = new Point(218, 108);
            tbx_Minute.Name = "tbx_Minute";
            tbx_Minute.Size = new Size(75, 32);
            tbx_Minute.TabIndex = 2;
            tbx_Minute.Text = "input2";
            // 
            // label1
            // 
            label1.Location = new Point(199, 108);
            label1.Name = "label1";
            label1.Size = new Size(13, 32);
            label1.TabIndex = 3;
            label1.Text = ":";
            // 
            // label2
            // 
            label2.Location = new Point(37, 108);
            label2.Name = "label2";
            label2.Size = new Size(75, 32);
            label2.TabIndex = 4;
            label2.Text = "开始时间";
            // 
            // label3
            // 
            label3.Location = new Point(37, 165);
            label3.Name = "label3";
            label3.Size = new Size(75, 23);
            label3.TabIndex = 5;
            label3.Text = "间隔";
            // 
            // tbx_Interval
            // 
            tbx_Interval.Location = new Point(118, 165);
            tbx_Interval.Name = "tbx_Interval";
            tbx_Interval.Size = new Size(75, 33);
            tbx_Interval.TabIndex = 6;
            tbx_Interval.Text = "input1";
            // 
            // button1
            // 
            button1.ForeColor = Color.Black;
            button1.Location = new Point(118, 215);
            button1.Name = "button1";
            button1.Size = new Size(75, 40);
            button1.TabIndex = 7;
            button1.Text = "开始计时";
            // 
            // NuhaiClock
            //            
            Controls.Add(button1);
            Controls.Add(tbx_Interval);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbx_Minute);
            Controls.Add(tbx_Hour);          
            Name = "NuhaiClock";
            Text = "怒海争霸计时";
          
        }

        #endregion
        private Input tbx_Hour;
        private Input tbx_Minute;
        private AntdUI.Label label1;
        private AntdUI.Label label2;
        private AntdUI.Label label3;
        private Input tbx_Interval;
        private AntdUI.Button button1;
    }
}
