using System;
using System.Windows.Forms;

namespace PlantsVsZombiesPlugin
{
    public partial class Form_Main : Form
    {
        const string ProcessName = "PlantsVsZombies";//进程名
        const int BaseAddress = 0x006A9EC0;//阳光基地址
        const int FirstPartial = 0x768;//一级偏移
        const int SecondPartial = 0x5560;//二级偏移

        int processPid, sunshineNum;
        public Form_Main()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            StartPosition = FormStartPosition.CenterScreen;//设置窗体居中
            FormBorderStyle = FormBorderStyle.FixedSingle;//禁止改变窗口大小
            MaximizeBox = false;//禁用最大化按钮
        }

        private void Button_ReadMemory_Click(object sender, EventArgs e)
        {
            processPid = MemoryHelper.GetPidByProcessName(ProcessName);
            if (processPid.Equals(0))
            {
                MessageBox.Show("游戏未运行，请先启动游戏！", "错误");
                return;
            }
            int baseAddress = MemoryHelper.ReadMemoryInt32Value(processPid, BaseAddress);
            int firstAddress = MemoryHelper.ReadMemoryInt32Value(processPid, baseAddress + FirstPartial);
            sunshineNum = MemoryHelper.ReadMemoryInt32Value(processPid, firstAddress + SecondPartial);
            MessageBox.Show(sunshineNum.ToString());
        }

        private void Button_WriteMemory_Click(object sender, EventArgs e)
        {
            processPid = MemoryHelper.GetPidByProcessName(ProcessName);
            if (processPid.Equals(0))
            {
                MessageBox.Show("游戏未运行，请先启动游戏！", "错误");
                return;
            }
            string num = TextBox_Number.Text;
            if (string.IsNullOrEmpty(num))
            {
                MessageBox.Show("请先输入修改的阳光的数值！", "错误");
                return;
            }
            int sunshineNum = Convert.ToInt32(num);
            int baseAddress = MemoryHelper.ReadMemoryInt32Value(processPid, BaseAddress);
            int firstAddress = MemoryHelper.ReadMemoryInt32Value(processPid, baseAddress + FirstPartial);
            MemoryHelper.WriteMemoryInt32Value(processPid, firstAddress + SecondPartial, sunshineNum);
            MessageBox.Show("修改成功！");
        }
    }
}
