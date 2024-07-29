using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace Symmetry
{
    internal class Symmetry
    {
        // 盖板轮廓外接旋转矩形
        private RotatedRect PlateBox;

        // 铝块轮廓外接旋转矩形
        private RotatedRect AluminumBox;

        private double Distance(OpenCvSharp.Point pA, OpenCvSharp.Point pB, OpenCvSharp.Point pC, OpenCvSharp.Point pD)
        {
            // 计算直线l0的斜率和截距
            double slope = (double)(pB.Y - pA.Y) / (double)(pB.X - pA.X);
            double intercept = pA.Y - slope * pA.X;

            // 计算p3和p4到直线l0的垂直距离
            double d0 = Math.Abs(slope * pC.X - pC.Y + intercept) / Math.Sqrt(slope * slope + 1);
            double d1 = Math.Abs(slope * pD.X - pD.Y + intercept) / Math.Sqrt(slope * slope + 1);

            // 找到d0和d1中的最大值，并返回最大值的两倍
            double max = Math.Max(d0, d1);
            return 2 * max;
        }




        // 对称度输入参数
        public Input input = new Input();

        // 对称度输出参数
        public Output output = new Output();

        /// <summary>
        /// 执行对称度检测算法
        /// </summary>
        /// <param name="srcImg"></param>
        public void Run1()
        {
            var image = input.InputImage.Clone();

            // 检测铝块中线特征点CD
            FindPointsCD1(image);

            if (!output.IsOk2)
                return;

            var points = FindPointsAB(image, input.Col1, input.Col2);

            if(points == null)
                return;

            // 画出中线
            Cv2.Line(image, output.PointC, output.PointD, Scalar.Green, 2);
            // 画出CD点
            Cv2.Circle(image, output.PointC, 5, Scalar.Green, 25);
            Cv2.Circle(image, output.PointD, 5, Scalar.Green, 25);
            Cv2.PutText(image, "C", new OpenCvSharp.Point(output.PointC.X + 50, output.PointC.Y - 50), HersheyFonts.HersheyComplex, 2.5, Scalar.Green, 4);
            Cv2.PutText(image, "D", new OpenCvSharp.Point(output.PointD.X + 50, output.PointD.Y - 50), HersheyFonts.HersheyComplex, 2.5, Scalar.Green, 4);

            // 画出中线
            Cv2.Line(image, points.Item1, points.Item2, Scalar.Green, 2);
            // 画出AB点
            Cv2.Circle(image, points.Item1, 5, Scalar.Green, 25);
            Cv2.Circle(image, points.Item2, 5, Scalar.Green, 25);
            Cv2.PutText(image, "A", new OpenCvSharp.Point(points.Item1.X + 50, points.Item1.Y - 50), HersheyFonts.HersheyComplex, 2.5, Scalar.Green, 4);
            Cv2.PutText(image, "B", new OpenCvSharp.Point(points.Item2.X + 50, points.Item2.Y - 50), HersheyFonts.HersheyComplex, 2.5, Scalar.Green, 4);

            output.OutputImage = image;
            output.ResultImage = image.ToBitmap();

            // 判断对称度是否符合OK
            var maxDis = Distance(points.Item1, points.Item2, output.PointC, output.PointD);

            output.CurSymmetry = maxDis * output.Scale;


            if (output.CurSymmetry <= input.MaxLimit)
            {
                output.IsOk = true;
                return;
            }
            else
            {
                output.IsOk = false;
                return;
            }
        }

        /// <summary>
        /// 检测铝块中线AB
        /// </summary>
        /// <param name="inputMat"></param>
        /// <param name="col1"></param>
        /// <param name="col2"></param>
        /// <returns></returns>
        public Tuple<OpenCvSharp.Point, OpenCvSharp.Point> FindPointsAB(Mat inputMat, int col1, int col2)
        {
            Mat binaryImg = new Mat();
            var img2 = MatBaseOperator.ClosingImage(inputMat, (int)input.Kernel1);
            Cv2.Threshold(img2, binaryImg, input.Threshold1, 255, ThresholdTypes.Binary);

            output.PlateThresholdImage = binaryImg.ToBitmap();

            // 检查列是否在图像宽度范围内
            if (col1 < 0 || col1 >= binaryImg.Cols || col2 < 0 || col2 >= binaryImg.Cols)
            {
                MessageBox.Show("左右基准值不能超过图像宽度范围！");
                return null;
            }

            OpenCvSharp.Point midPoint1 = FindMidpointForColumn(binaryImg, col1);
            OpenCvSharp.Point midPoint2 = FindMidpointForColumn(binaryImg, col2);

            output.PointA = midPoint1;
            output.PointB = midPoint2;

            return Tuple.Create(midPoint1, midPoint2);
        }


        /// <summary>
        /// 查找某一列下的白色区域的中点
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private OpenCvSharp.Point FindMidpointForColumn(Mat mat, int column)
        {
            int rowStart = -1;
            int rowEnd = -1;

            for (int row = 0; row < mat.Rows; row++)
            {
                byte pixelValue = (byte)mat.At<byte>(row, column);
                if (pixelValue > 0 && rowStart == -1)
                {
                    rowStart = row;
                }
                else if (pixelValue == 0 && rowStart != -1 && rowEnd == -1)
                {
                    rowEnd = row;
                    break;
                }
            }

            if (rowStart == -1 || rowEnd == -1)
            {
                MessageBox.Show("找不到盖板的边界！");
            }
            output.PlatePixNum = rowEnd - rowStart;
            int midRow = (rowStart + rowEnd) / 2;
            return new OpenCvSharp.Point(column, midRow);
        }


        /// <summary>
        /// 检测铝块中线CD
        /// </summary>
        /// <param name="srcImg">输入图像</param>
        /// <param name="rCorMM">R角物理半径</param>
        /// <param name="threshold2">定位铝块二值化阈值</param>
        /// <param name="tupleCD">找到的中线CD点</param>
        /// <returns></returns>
        public void FindPointsCD1(Mat srcImg)
        {
            // 转为二值化图像（铝块）
            using (Mat grayImg = new Mat(), binaryImg = new Mat())
            {
                #region 检测铝块轮廓

                var img2 = MatBaseOperator.ClosingImage(srcImg, (int)input.Kernel2);
                Cv2.Threshold(img2, binaryImg, input.Threshold2, 255, ThresholdTypes.Binary);

                // 输出铝块二值化图像
                output.AluminumThresholdImage = BitmapConverter.ToBitmap(binaryImg);

                // 找到图像中的所有轮廓
                OpenCvSharp.Point[][] contours = null;
                HierarchyIndex[] hierarchy = null;
                Cv2.FindContours(binaryImg, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);

                Dictionary<OpenCvSharp.Point[], double> resultMap = new Dictionary<OpenCvSharp.Point[], double>();

                // 循环遍历所有找到的轮廓
                foreach (var contour in contours)
                {
                    // 计算轮廓面积
                    double area = Cv2.ContourArea(contour);
                    if (area > 1000000 && area < 3000000)
                        resultMap.Add(contour, area);
                }

                // 轮廓过滤
                if (resultMap.Count != 2)
                {
                    output.IsOk2 = false;
                    return;
                }

                // 保存铝块轮廓和面积
                KeyValuePair<OpenCvSharp.Point[], double> minValuePair = new KeyValuePair<OpenCvSharp.Point[], double>();

                // 取二者面积小的作为结果（小的为铝块轮廓，大的为铝块外塑胶轮廓）
                minValuePair = resultMap.Aggregate((l, r) => l.Value < r.Value ? l : r);

                // 计算最小外接矩形
                RotatedRect box = Cv2.MinAreaRect(minValuePair.Key);

                #endregion

                #region 计算铝块中线特征点CD

                // 计算旋转矩形的边界框
                OpenCvSharp.Point2f[] boxPoints = box.Points();

                // 旋转角度
                double angle = box.Angle;

                // 确定旋转矩形的四个顶点
                OpenCvSharp.Point2f leftTop, rightTop, leftBottom, rightBottom;

                // 找到旋转矩形的左下和右下点
                if (angle < 45)
                {
                    leftTop = boxPoints[1];
                    rightTop = boxPoints[2];
                    leftBottom = boxPoints[0];
                    rightBottom = boxPoints[3];
                }
                else
                {
                    leftTop = boxPoints[0];
                    rightTop = boxPoints[1];
                    leftBottom = boxPoints[3];
                    rightBottom = boxPoints[2];
                }

                // 计算中线
                OpenCvSharp.Point midPointLeft = new OpenCvSharp.Point((leftTop.X + leftBottom.X) / 2, (leftTop.Y + leftBottom.Y) / 2);
                OpenCvSharp.Point midPointRight = new OpenCvSharp.Point((rightTop.X + rightBottom.X) / 2, (rightTop.Y + rightBottom.Y) / 2);

                // 查找铝块内的2个特征点
                var points1 = FindPointsOnPerpendicularBisector((OpenCvSharp.Point)leftBottom, (OpenCvSharp.Point)leftTop, input.RCorMM / output.Scale);
                var points2 = FindPointsOnPerpendicularBisector((OpenCvSharp.Point)rightBottom, (OpenCvSharp.Point)rightTop, input.RCorMM / output.Scale);

                // 渲染结果
                OpenCvSharp.Point p0, p1;

                if (angle < 45 || angle == 90)
                {
                    p0 = points1.Item1;
                    p1 = points2.Item2;
                }
                else
                {
                    p0 = points1.Item2;
                    p1 = points2.Item1;
                }

                output.PointC = p0;
                output.PointD = p1;

                #endregion


                // 判断特征点C和D是否超出图像边界，不合法
                if (output.PointC.X < 0 || output.PointC.X > srcImg.Width || output.PointC.Y < 0 || output.PointC.Y > srcImg.Height ||
                    output.PointD.X < 0 || output.PointD.X > srcImg.Width || output.PointD.Y < 0 || output.PointD.Y > srcImg.Height)
                {
                    output.IsOk2 = false;
                    return;
                }
                else
                    output.IsOk2 = true;
            }
        }


        /// <summary>
        /// 根据两个点计算垂直平分线上高为h的两个点。
        /// </summary>
        /// <param name="pt1">第一个点。</param>
        /// <param name="pt2">第二个点。</param>
        /// <param name="h">垂直距离。</param>
        /// <returns>包含两个点坐标的元组。</returns>
        private Tuple<OpenCvSharp.Point, OpenCvSharp.Point> FindPointsOnPerpendicularBisector(OpenCvSharp.Point pt1, OpenCvSharp.Point pt2, double distance)
        {
            // 计算中点
            OpenCvSharp.Point midPoint = new OpenCvSharp.Point((pt1.X + pt2.X) / 2, (pt1.Y + pt2.Y) / 2);

            // 除以0异常
            if (pt2.X - pt1.X == 0)
            {
                //throw new Exception("除以零");
                return Tuple.Create(new OpenCvSharp.Point(midPoint.X + distance, midPoint.Y), new OpenCvSharp.Point(midPoint.X - distance, midPoint.Y));
            }

            // 计算两点之间的斜率
            double slope = (pt2.Y - pt1.Y) / (pt2.X - pt1.X);

            // 计算垂直于这两点形成的直线L0的垂线L1的斜率
            double perpendicularSlope = double.IsInfinity(slope) ? 0 : -1 / slope;

            // 当直线L0是与X轴不平行时，在它的垂线L1上找到距离点midPoint的距离为distance的2个点
            OpenCvSharp.Point p1 = CalculatePointOnPerpendicularLine(perpendicularSlope, midPoint, distance);
            OpenCvSharp.Point p2 = CalculatePointOnPerpendicularLine(perpendicularSlope, midPoint, -distance);

            return Tuple.Create(p1, p2);
        }


        /// <summary>
        /// 计算垂直于给定斜率的直线上，距离中点为distance的点。
        /// </summary>
        /// <param name="perpendicularSlope">垂直线的斜率。</param>
        /// <param name="midPoint">原直线上的参考点（中点）。</param>
        /// <param name="distance">垂直距离。</param>
        /// <returns>计算出的点。</returns>
        private OpenCvSharp.Point CalculatePointOnPerpendicularLine(double perpendicularSlope, OpenCvSharp.Point midPoint, double distance)
        {
            // 计算垂直线上的点
            // 公式为：x = x0 ± d*sqrt(1+m^2) / |m|, y = mx + c
            double sqrtTerm = Math.Sqrt(1 + Math.Pow(perpendicularSlope, 2));
            double newX = midPoint.X + (distance * Math.Sign(perpendicularSlope)) / sqrtTerm;
            double newY = perpendicularSlope * newX + midPoint.Y - perpendicularSlope * midPoint.X;

            return new OpenCvSharp.Point((int)newX, (int)newY);
        }

    }


    /// <summary>
    /// 对称度输入
    /// </summary>
    public struct Input
    {
        /// <summary>
        /// 待检测图像(默认灰度图)
        /// </summary>
        public Mat InputImage;

        /// <summary>
        /// 盖板二值化阈值
        /// </summary>
        public int Threshold1;

        /// <summary>
        /// 铝块二值化阈值
        /// </summary>
        public int Threshold2;

        public int Kernel1;

        public int Kernel2;


        /// <summary>
        /// R角半径
        /// </summary>
        public double RCorMM;

        /// <summary>
        ///  左列
        /// </summary>
        public int Col1;

        /// <summary>
        /// 右列
        /// </summary>
        public int Col2;

        /// <summary>
        /// 盖板宽度mm
        /// </summary>
        public double PlateWidthMM;

        /// <summary>
        /// 对称度最大允许限值
        /// </summary>
        public double MaxLimit;

        public Input(
            Mat inputImage,
            int threshold1,
            int threshold2,
            int kernel1,
            int kernel2,
            double rCorMM,
            int col1,
            int col2,
            double plateWidthMM,
            double maxLimit)
        {
            InputImage = inputImage;
            Threshold1 = threshold1;
            Threshold2 = threshold2;
            Kernel1 = kernel1;
            Kernel2 = kernel2;
            RCorMM = rCorMM;
            Col1 = col1;
            Col2 = col2;
            PlateWidthMM = plateWidthMM;
            MaxLimit = maxLimit;
        }
    }

    /// <summary>
    /// 对称度输出
    /// </summary>
    public struct Output
    {
        /// <summary>
        /// 特征点A
        /// </summary>
        public OpenCvSharp.Point PointA;

        /// <summary>
        /// 特征点B
        /// </summary>
        public OpenCvSharp.Point PointB;

        /// <summary>
        /// 盖板二值化图像
        /// </summary>
        public Image PlateThresholdImage;

        /// <summary>
        /// 检测盖板是否OK？
        /// </summary>
        public bool IsOk1;

        /// <summary>
        /// 特征点C
        /// </summary>
        public OpenCvSharp.Point PointC;

        /// <summary>
        /// 特征点D
        /// </summary>
        public OpenCvSharp.Point PointD;

        /// <summary>
        /// 铝块二值化图像
        /// </summary>
        public Image AluminumThresholdImage;

        /// <summary>
        /// 检测铝块是否OK？
        /// </summary>
        public bool IsOk2;

        /// <summary>
        /// 盖板像素尺寸
        /// </summary>
        public int PlatePixNum;

        /// <summary>
        /// 毫米/像素比例尺
        /// </summary>
        public double Scale;

        /// <summary>
        /// 当前对称度结果
        /// </summary>
        public double CurSymmetry;

        /// <summary>
        /// 对称度检测是否OK
        /// </summary>
        public bool IsOk;

        /// <summary>
        /// 结果渲染图像
        /// </summary>
        public Image ResultImage;

        /// <summary>
        /// 结果渲染图像Mat
        /// </summary>
        public Mat OutputImage;
    }


}
