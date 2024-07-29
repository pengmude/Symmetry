using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.Internal.Vectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Symmetry
{
    public partial class FormTest : Form
    {
        Mat grayImg = null;
        Mat binaryImg = new Mat();
        Mat colorImg = new Mat();
        Mat RoiImg = new Mat();
        Rect Roi = new Rect();

        public FormTest()
        {
            InitializeComponent();

            Roi = new Rect(new OpenCvSharp.Point(int.Parse(textBoxX.Text), int.Parse(textBoxY.Text)),
                    new OpenCvSharp.Size(int.Parse(textBoxW.Text), int.Parse(textBoxH.Text)));
        }

        /// <summary>
        /// 选择文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                grayImg = Cv2.ImRead(openFileDialog1.FileName, ImreadModes.Grayscale);
                Cv2.CvtColor(grayImg, colorImg, ColorConversionCodes.GRAY2BGR);
                //grayImg = MatBaseOperator.ClosingImage(grayImg, trackBar2.Value);
                Cv2.Threshold(grayImg, binaryImg, trackBar1.Value, 255, ThresholdTypes.Binary);
                ytPictrueBox1.SrcImage = binaryImg.ToBitmap();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(grayImg == null) { return; }


            RoiImg = binaryImg.Clone(Roi);

            var outputImg = colorImg.Clone();

            var lines = FindLinesInImage(RoiImg);
            foreach (var line in lines)
            {
                var p1 = new OpenCvSharp.Point(line.P1.X + Roi.X, line.P1.Y + Roi.Y);
                var p2 = new OpenCvSharp.Point(line.P2.X + Roi.X, line.P2.Y + Roi.Y);

                Cv2.Line(outputImg, p1, p2, Scalar.Red, 2);
            }
            ytPictrueBox1.SrcImage = outputImg.ToBitmap();
        }

        public LineSegmentPoint[] FindLinesInImage(Mat binaryImg)
        {
            // 高斯模糊
            Cv2.GaussianBlur(binaryImg, binaryImg, new OpenCvSharp.Size(15, 15), 0);

            // 提取边缘
            Mat edges = new Mat();
            Cv2.Canny(binaryImg, edges, 50, 155);
            Cv2.ImShow("edges", edges);

            return Cv2.HoughLinesP(edges, 3, Cv2.PI / 180, trackBar1.Value, 500, 100);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (grayImg == null) { return; }

            Cv2.Threshold(grayImg, binaryImg, trackBar1.Value, 255, ThresholdTypes.Binary);
            ytPictrueBox1.SrcImage = binaryImg.ToBitmap();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (grayImg == null) { return; }

            if (trackBar2.Value % 2 != 0)
            {
                binaryImg = MatBaseOperator.ClosingImage(binaryImg, trackBar2.Value);
                ytPictrueBox1.SrcImage = binaryImg.ToBitmap();
            }
        }

        private void textBoxX_TextChanged(object sender, EventArgs e)
        {
            var img = binaryImg.Clone();
            try
            {
                if(int.Parse(textBoxX.Text) < 0 || int.Parse(textBoxY.Text) < 0 || int.Parse(textBoxW.Text) < 0 || int.Parse(textBoxH.Text) < 0)
                    return;
            }
            catch (Exception ex)
            {
                return;
            }

            Roi = new Rect(new OpenCvSharp.Point(int.Parse(textBoxX.Text), int.Parse(textBoxY.Text)),
                    new OpenCvSharp.Size(int.Parse(textBoxW.Text), int.Parse(textBoxH.Text)));
            Cv2.Rectangle(img, Roi, Scalar.Red, 10);
            ytPictrueBox1.SrcImage = img.ToBitmap();
        }
    }
}
