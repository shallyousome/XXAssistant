using Gma.System.MouseKeyHook;
using PaddleOCRSharp;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace XXAssistant
{
    /*�Զ���̯�߼�    
1.��Home��ʼ������������Ʒ  
2.ɨ��ͼƬ����Ʒ���Ƶ��б���
3.���б������붨��
4.��End�Զ����۳�̯

V1.1����
1.��ȡ��ǰ���չ���Ʒʵʱ�۸�
2.���ӽ�����־���
*/
    public partial class NuhaiClock : GeneralForm
    {
        private int i_Interval = 200;
        private bool IsEnd = true;//�����Ƿ������
        //ocr
        private PaddleOCREngine engine;
        private PaddleStructureEngine structengine;
        /*
         �����ʱ����
         
         */
        public NuhaiClock(bool top)
        {
            InitializeComponent();
            TopMost = top; 
        }



    }
}
