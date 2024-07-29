using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using YTVisionPro.Controls;

namespace YTVisionPro.Forms.ImageViewer
{
    public partial class FrmImgeView : DockContent
    {
        private List<string> _windowsNameList = new List<string>();
        public FrmImgeView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 给图像显示窗口后面添加一个显示区域
        /// </summary>
        public void AddImageDisplayArea(string windowsName)
        {
            _windowsNameList.Add(windowsName);
        }
        /// <summary>
        /// 获取窗口名列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetWindowsNameList()
        {
            return _windowsNameList;
        }

        public void SetImgWndNum(int nums)
        {
            // 确保nums为有效值
            if (nums < 1 || nums > 9) { MessageBox.Show("目前仅支持1-9个图像显示窗口！"); return; }

            // 当前行数和列数
            int currentRows = tableLayoutPanel1.RowCount;
            int currentColumns = tableLayoutPanel1.ColumnCount;

            #region 根据传入参数值计算设置的行数和列数
            int idealRows = 0, idealColumns = 0;
            if (nums == 1)
            {
                idealRows = 1;
                idealColumns = 1;
            }
            else if (nums <= 2)
            {
                idealRows = 1;
                idealColumns = 2;
            }
            else if (nums <= 4)
            {
                idealRows = 2;
                idealColumns = 2;
            }
            else if (nums <= 6)
            {
                idealRows = 2;
                idealColumns = 3;
            }
            else if(nums <= 9)
            {
                idealRows = 3;
                idealColumns = 3;
            }
            #endregion

            // 仅在布局需要改变时进行调整
            if (currentRows != idealRows || currentColumns != idealColumns)
            {
                tableLayoutPanel1.RowCount = idealRows;
                tableLayoutPanel1.ColumnCount = idealColumns;
                // 改变行列数目时，要清除原来的行列样式，最后再根据行列等分要求添加进去
                tableLayoutPanel1.RowStyles.Clear();
                tableLayoutPanel1.ColumnStyles.Clear();
            }
            // 清除现有控件，准备重新布局
            tableLayoutPanel1.Controls.Clear();

            // 添加PictureBox控件到TableLayoutPanel
            for (int i = 0; i < idealRows; i++)
            {
                for (int j = 0; j < idealColumns; j++)
                {
                    // 确保PictureBox的数量不超过nums
                    if (i * idealColumns + j < nums)
                    {
                        //ProPictureBox pictureBox = new ProPictureBox();
                        //pictureBox.Image = new Bitmap(@"D:\Code\C#\YTVisionPro1-4\img\暂无图像.png"); // 默认图片路径
                        //pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // 设置图片缩放模式为Zoom
                        //pictureBox.Dock = DockStyle.Fill; // 让PictureBox填充单元格
                        //pictureBox.BackColor = Color.Black;
                        //pictureBox.Margin = new Padding(0);
                        //pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        //tableLayoutPanel1.Controls.Add(pictureBox, j, i); // 添加到TableLayoutPanel

                        ImageShowViewCtl imageShowViewCtl = new ImageShowViewCtl();
                        imageShowViewCtl.Image = new Bitmap(@"D:\Code\C#\YTVisionPro1-4\img\暂无图像.png");
                        imageShowViewCtl.Dock = DockStyle.Fill;
                        //imageShowViewCtl.Width =
                        tableLayoutPanel1.Controls.Add(imageShowViewCtl, j, i); // 添加到TableLayoutPanel
                    }
                }
            }


            // 初始化或重新设置RowStyles和ColumnStyles
            for (int i = 0; i < idealRows; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f / idealRows));
            }
            for (int j = 0; j < idealColumns; j++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f / idealColumns));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetImgWndNum(int.Parse(textBox1.Text));
        }
    }
}
