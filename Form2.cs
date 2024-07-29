using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Symmetry
{
    public partial class Form2 : Form
    {
        Symmetry symmetry = new Symmetry();
        Mat grayImage;

        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                grayImage = Cv2.ImRead(openFileDialog1.FileName, ImreadModes.Grayscale);
                symmetry.input = new Input(grayImage, int.Parse(txbThreshold1.Text), int.Parse(txbThreshold2.Text), 
                                            int.Parse(textBox_kernel1.Text), int.Parse(textBox_kernel2.Text), 2.9,
                                            int.Parse(textBox_col1.Text), int.Parse(textBox_col2.Text), 
                                            double.Parse(textBox_widthMM.Text), double.Parse(textBox_limitMM.Text));
                
                symmetry.output.Scale = double.Parse(textBox_scale.Text);
                symmetry.Run1();

                pictureBox1.Image = symmetry.output.PlateThresholdImage;
                pictureBox2.Image = symmetry.output.AluminumThresholdImage;pictureBox3.Image = symmetry.output.ResultImage;
                label_result.Text = (symmetry.output.CurSymmetry + double.Parse(textBox_buchang.Text)).ToString("0.000");
                label1_pix.Text = symmetry.output.PlatePixNum.ToString();

                label_A.Text = $"A({symmetry.output.PointA.X}, {symmetry.output.PointA.Y})";
                label_B.Text = $"B({symmetry.output.PointB.X}, {symmetry.output.PointB.Y})";
                label_C.Text = $"C({symmetry.output.PointC.X}, {symmetry.output.PointC.Y})";
                label_D.Text = $"D({symmetry.output.PointD.X}, {symmetry.output.PointD.Y})";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(grayImage == null)
            {
                MessageBox.Show("请先选择图像！");
                return;
            }
            symmetry.input = new Input(grayImage, int.Parse(txbThreshold1.Text), int.Parse(txbThreshold2.Text),
                                        int.Parse(textBox_kernel1.Text), int.Parse(textBox_kernel2.Text), 2.9,
                                        int.Parse(textBox_col1.Text), int.Parse(textBox_col2.Text),
                                        double.Parse(textBox_widthMM.Text), double.Parse(textBox_limitMM.Text));

            symmetry.output.Scale = double.Parse(textBox_scale.Text);
            symmetry.Run1();

            pictureBox1.Image = symmetry.output.PlateThresholdImage;
            pictureBox2.Image = symmetry.output.AluminumThresholdImage;pictureBox3.Image = symmetry.output.ResultImage;
            label_result.Text = (symmetry.output.CurSymmetry + double.Parse(textBox_buchang.Text)).ToString("0.000");
            label1_pix.Text = symmetry.output.PlatePixNum.ToString();

            label_A.Text = $"A({symmetry.output.PointA.X}, {symmetry.output.PointA.Y})";
            label_B.Text = $"B({symmetry.output.PointB.X}, {symmetry.output.PointB.Y})";
            label_C.Text = $"C({symmetry.output.PointC.X}, {symmetry.output.PointC.Y})";
            label_D.Text = $"D({symmetry.output.PointD.X}, {symmetry.output.PointD.Y})";
        }
    }
}
