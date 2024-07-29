using System;
using System.Windows.Forms;
using FrmResultView;
using Logger;

namespace Symmetry
{
    public partial class FrmSystemSettings : Form
    {
        private SystemConfig _config;

        public SystemConfig Configs { get => _config; set => _config = value; }

        public FrmSystemSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择原图存图路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox9.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        /// <summary>
        /// 界面所有输入改变处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxChanged(object sender, EventArgs e)
        {
            // 正极信号配置
            if (sender == textBox1)
                _config.Item1.SrcImgPath = textBox1.Text;
            else if (sender == textBox2)
                _config.Item1.RenImgPath = textBox2.Text;
            else if (sender == checkBox1)
                _config.Item1.IsSaveSrcImg = checkBox1.Checked;
            else if (sender == checkBox2)
                _config.Item1.IsSaveRenImg = checkBox2.Checked;
            else if (sender == checkBox3)
                _config.Item1.CompressSrcImg = checkBox3.Checked;
            else if (sender == checkBox4)
                _config.Item1.CompressRenImg = checkBox4.Checked;
            else if (sender == checkBox5)
                _config.Item1.AutoDeleteImg = checkBox5.Checked;
            else if (sender == textBox3)
            {
                try
                {
                    _config.Item1.AutoDeleteCountdown = uint.Parse(textBox3.Text);
                }
                catch (Exception)
                {
                    FrmLogger.AddLog("正极无效的天数设置！", MsgLevel.Warn);
                    return;
                }
            }
            else if (sender == checkBox6)
                _config.Item1.AutoRun = checkBox6.Checked;
            else if (sender == textBox4)
                _config.Item1.SignalReady = textBox4.Text;
            else if (sender == textBox5)
                _config.Item1.SignalShot = textBox5.Text;
            else if (sender == textBox6)
                _config.Item1.SignalOk = textBox6.Text;
            else if (sender == textBox7)
                _config.Item1.SignalNg = textBox7.Text;

            // 负极信号配置
            if (sender == textBox8)
                _config.Item2.SrcImgPath = textBox8.Text;
            else if (sender == textBox9)
                _config.Item2.RenImgPath = textBox9.Text;
            else if (sender == checkBox7)
                _config.Item2.IsSaveSrcImg = checkBox7.Checked;
            else if (sender == checkBox8)
                _config.Item2.IsSaveRenImg = checkBox8.Checked;
            else if (sender == checkBox9)
                _config.Item2.CompressSrcImg = checkBox9.Checked;
            else if (sender == checkBox10)
                _config.Item2.CompressRenImg = checkBox10.Checked;
            else if (sender == checkBox11)
                _config.Item2.AutoDeleteImg = checkBox11.Checked;
            else if (sender == textBox10)
            {
                try
                {
                    _config.Item2.AutoDeleteCountdown = uint.Parse(textBox10.Text);
                }
                catch (Exception)
                {
                    FrmLogger.AddLog("负极无效的天数设置！", MsgLevel.Warn);
                    return;
                }
            }
            else if (sender == checkBox12)
                _config.Item2.AutoRun = checkBox12.Checked;
            else if (sender == textBox11)
                _config.Item2.SignalReady = textBox11.Text;
            else if (sender == textBox12)
                _config.Item2.SignalShot = textBox12.Text;
            else if (sender == textBox13)
                _config.Item2.SignalOk = textBox13.Text;
            else if (sender == textBox14)
                _config.Item2.SignalNg = textBox14.Text;

            Config.ConfigsChanged?.Invoke();
        }

    }


}
