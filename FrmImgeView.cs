using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Symmetry
{
    public partial class FrmImgeView : DockContent
    {
        /// <summary>
        /// 通知主窗口本窗口是否还显示在DockContent中
        /// </summary>
        public static event EventHandler<bool> IsShowOnDockContentChanged;

        public FrmImgeView()
        {
            InitializeComponent();
            if(!File.Exists(Application.StartupPath + @"\NOIMAGE.bmp"))
            {
                throw new Exception("exe程序运行目录下少了一张测试图片，自行补上，仅供开发测试图像控件用，不需要可以去掉！");
            }
            this.ytPictrueBox1.SrcImage = new Bitmap(Application.StartupPath + @"\NOIMAGE.bmp");
            this.ytPictrueBox2.SrcImage = new Bitmap(Application.StartupPath + @"\NOIMAGE.bmp");
        }

        private void ytPictrueBox2_VisibleChanged(object sender, EventArgs e)
        {
            IsShowOnDockContentChanged?.Invoke(this, Visible);
        }

        private void FrmImgeView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
