using AntdUI;

namespace XXAssistant
{
    partial class AutoStall
    {
       
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            rad_Scan = new AntdUI.Radio();
            rad_SetPrice = new AntdUI.Radio();           

            // 
            // rad_Scan
            // 
            rad_Scan.AutoSizeMode = AntdUI.TAutoSize.Auto;
            rad_Scan.Location = new Point(40, 80);
            rad_Scan.Name = "rad_Scan";
            rad_Scan.Size = new Size(117, 43);
            rad_Scan.TabIndex = 1;
            rad_Scan.Text = "扫描背包";
            // 
            // rad_SetPrice
            // 
            rad_SetPrice.AutoSizeMode = AntdUI.TAutoSize.Auto;
            rad_SetPrice.Location = new Point(210, 80);
            rad_SetPrice.Name = "rad_SetPrice";
            rad_SetPrice.Size = new Size(115, 43);
            rad_SetPrice.TabIndex = 1;
            rad_SetPrice.Text = "自动定价";            
           
           
            // 
            // AutoStall
            //             
            Controls.Add(rad_SetPrice);
            Controls.Add(rad_Scan); 
            Name = "AutoStall";
            Text = "寻仙摆摊助手";
        }

        #endregion
        private AntdUI.Radio rad_Scan;
        private AntdUI.Radio rad_SetPrice;
    }
}
