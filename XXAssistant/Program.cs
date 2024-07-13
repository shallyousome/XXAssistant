namespace XXAssistant
{
    internal static class Program
    {
        static void Main(string[] arge)
        {
            bool istop = false;
            if (arge.Length > 0) { if (arge[0] == "t") istop = true; }
            //AntdUI.Localization.Provider = new Localizer();
            AntdUI.Config.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new AutoStall(istop));
            //Application.Run(new NuhaiClock(istop));
            Application.Run(new AutoResurrect(istop));
            //失败了。。。。 =>需要管理员方式运行
        }
    }
}