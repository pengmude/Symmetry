using OpenCvSharp;

namespace Symmetry
{
    /// <summary>
    /// OpeenCV 格式图片Mat的基本操作
    /// </summary>
    class MatBaseOperator
    {
        /// <summary>
        /// 对输入图像执行腐蚀操作
        /// 腐蚀操作使得感兴趣区域的边缘向内收缩
        /// 应用于暗色区域把亮色区域边缘侵蚀的场景
        /// </summary>
        /// <param name="binaryImage"></param>
        /// <param name="kernelSize"></param>
        /// <returns></returns>
        public static Mat ErodeImage(Mat binaryImage, int kernelSize = 3)
        {
            // 创建一个结构元素（内核），用于腐蚀操作。大小和形状可以根据需要调整。
            // 这里使用3x3的矩形结构元素作为示例。
            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(kernelSize, kernelSize));
            // 执行腐蚀操作
            Mat erodedImage = new Mat();
            Cv2.Erode(binaryImage, erodedImage, kernel);
            return erodedImage;
        }
        /// <summary>
        /// 对输入图像执行膨胀操作
        /// 膨胀操作使得感兴趣区域的边缘向外扩大
        /// 应用于使亮色区域边缘扩大侵蚀暗色区域的场景
        /// </summary>
        /// <param name="image"></param>
        /// <param name="kernelSize"></param>
        /// <returns></returns>
        public static Mat DilateImage(Mat image, int kernelSize = 3)
        {
            // 创建一个结构元素（内核），用于膨胀操作。大小可以根据实际情况调整。
            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(kernelSize, kernelSize));
            // 执行膨胀操作
            Mat dilatedImage = new Mat();
            Cv2.Dilate(image, dilatedImage, kernel);
            return dilatedImage;
        }
        /// <summary>
        /// 对输入图像执行开运算
        /// 效果等同于先执行一次腐蚀操作再执行膨胀操作
        /// 应用于分离原本接触的物体，使得它们之间形成明显间隙的场景
        /// </summary>
        /// <param name="binaryImage"></param>
        /// <param name="kernelSize"></param>
        /// <returns></returns>
        public static Mat OpeningImage(Mat binaryImage, int kernelSize = 3)
        {
            // 创建一个结构元素（内核），用于开运算。大小可以根据实际情况调整。
            // 例如，3x3的正方形结构元素用于去除较小的噪点
            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(kernelSize, kernelSize));
            // 执行开运算
            Mat openedImage = new Mat();
            Cv2.MorphologyEx(binaryImage, openedImage, MorphTypes.Open, kernel);
            return openedImage;
        }
        /// <summary>
        /// 对输入图像执行闭运算
        /// 效果等同于先执行一次膨胀操作再执行腐蚀操作
        /// 应用于在亮色区域中将暗色的噪点吞噬的场景
        /// </summary>
        /// <param name="binaryImage"></param>
        /// <param name="kernelSize"></param>
        /// <returns></returns>
        public static Mat ClosingImage(Mat binaryImage, int kernelSize = 3)
        {
            // 创建一个结构元素（内核），用于闭运算。大小可以根据实际情况调整。
            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(kernelSize, kernelSize));
            // 执行闭运算
            Mat closedImage = new Mat();
            Cv2.MorphologyEx(binaryImage, closedImage, MorphTypes.Close, kernel);
            return closedImage;
        }
    }
}
