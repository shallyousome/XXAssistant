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
    public partial class NuhaiClock : GeneralForm
    {
        private int i_Interval = 200;
        private bool IsEnd = true;//操作是否已完成
        //ocr
        private PaddleOCREngine engine;
        private PaddleStructureEngine structengine;
        /*
         保存计时配置
         
         */
        public NuhaiClock(bool top)
        {
            InitializeComponent();
            TopMost = top; 
        }



    }
}
