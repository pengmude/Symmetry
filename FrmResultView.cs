using FrmResultView;
using Logger;
using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Symmetry
{
    public partial class FrmResultView : DockContent
    {
        /// <summary>
        /// 通知主窗口本窗口是否还显示在DockContent中
        /// </summary>
        public static event EventHandler<bool> IsShowOnDockContentChanged;

        private DetectResultConfig _config = new DetectResultConfig();

        public DetectResultConfig Configs { get { return _config;} set { _config = value; } }

        public FrmResultView()
        {
            InitializeComponent();
            FrmLogin.LoginHandler += LoginHandler;
        }

        private void LoginHandler(object sender, bool e)
        {
            button1.Enabled = e;
            button2.Enabled = e;
        }

        private void FrmResultView_VisibleChanged(object sender, EventArgs e)
        {
            IsShowOnDockContentChanged?.Invoke(this, Visible);
        }

        private void FrmResultView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public void AddOk1()
        {
            _config.CountTotal1++;
            _config.CountOk1++;
            var per = ((double)_config.CountOk1 / (double)_config.CountTotal1 * 100f);
            _config.Percent1 = per.ToString("0.00") + "%";

            label2.Text = _config.CountTotal1.ToString();
            label4.Text = _config.CountOk1.ToString();
            label8.Text = _config.Percent1;

            label9.Text = "OK";
            label9.BackColor = System.Drawing.Color.SeaGreen;
        }

        public void AddNg1()
        {
            _config.CountTotal1++;
            _config.CountNg1++;
            var per = ((double)_config.CountOk1 / (double)_config.CountTotal1 * 100f);
            _config.Percent1 = per.ToString("0.00") + "%";

            label2.Text = _config.CountTotal1.ToString();
            label6.Text = _config.CountNg1.ToString();
            label8.Text = _config.Percent1;

            label9.Text = "NG";
            label9.BackColor = System.Drawing.Color.Red;
        }

        public void AddOk2()
        {
            _config.CountTotal2++;
            _config.CountOk2++;
            var per = ((double)_config.CountOk2 / (double)_config.CountTotal2 * 100f);
            _config.Percent2 = per.ToString("0.00") + "%";

            label11.Text = _config.CountTotal2.ToString();
            label13.Text = _config.CountOk2.ToString();
            label17.Text = _config.Percent2;

            label18.Text = "OK";
            label18.BackColor = System.Drawing.Color.SeaGreen;
        }

        public void AddNg2()
        {
            _config.CountTotal2++;
            _config.CountNg2++;
            var per = ((double)_config.CountOk2 / (double)_config.CountTotal2 * 100f);
            _config.Percent2 = per.ToString("0.00") + "%";

            label11.Text = _config.CountTotal2.ToString();
            label15.Text = _config.CountNg2.ToString();
            label17.Text = _config.Percent2;

            label18.Text = "NG";
            label18.BackColor = System.Drawing.Color.Red;
        }

        /// <summary>
        /// 正极结果清零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            _config.CountTotal1 = 0;
            _config.CountOk1 = 0;
            _config.CountNg1 = 0;
            _config.Percent1 = "0.0%";


            label2.Text = _config.CountTotal1.ToString();
            label4.Text = _config.CountOk1.ToString();
            label6.Text = _config.CountNg1.ToString();
            label8.Text = _config.Percent1;
        }

        /// <summary>
        /// 负极结果清零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            _config.CountTotal2 = 0;
            _config.CountOk2 = 0;
            _config.CountNg2 = 0;
            _config.Percent2 = "0.0%";


            label11.Text = _config.CountTotal2.ToString();
            label13.Text = _config.CountOk2.ToString();
            label15.Text = _config.CountNg2.ToString();
            label17.Text = _config.Percent2;
        }
    }
}
