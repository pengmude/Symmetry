using MvCamCtrl.NET;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static MvCamCtrl.NET.MyCamera;

namespace Test_CameraClass
{
    public class CameraHik
    {
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

        MyCamera m_Camera;
        public int m_ID;
        public string m_SerialNumber;
        public string m_Name;
        public MyCamera.MV_CC_DEVICE_INFO stDevInfo;
        //用于从驱动获取图像的缓存
        UInt32 nDstDataSize = 0;
        IntPtr pBufForConvert = IntPtr.Zero;
        MyCamera.MV_FRAME_OUT stFrameOut = new MyCamera.MV_FRAME_OUT();

        /// <summary>
        /// 打开相机
        /// </summary>
        /// <returns></returns>
        public bool OpenCamera()
        {
            if (m_Camera == null)
            {
                m_Camera = new MyCamera();
                if (m_Camera == null)
                {
                    MessageBox.Show($"创建相机{m_Name}资源失败");
                    return false;
                }
            }
            //创建相机对象
            int nRet = m_Camera.MV_CC_CreateDevice_NET(ref stDevInfo);
            if (MyCamera.MV_OK != nRet)
            {
                MessageBox.Show($"创建相机{m_Name}对象失败");
                return false;
            }

            //打开相机对象
            nRet = m_Camera.MV_CC_OpenDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                MessageBox.Show($"打开相机{m_Name}失败");
                return false;
            }
            //检测网络最佳包大小(只对GigE相机有效)
            if (stDevInfo.nTLayerType == MyCamera.MV_GIGE_DEVICE)
            {
                int nPacketSize = m_Camera.MV_CC_GetOptimalPacketSize_NET();
                if (nPacketSize > 0)
                {
                    nRet = m_Camera.MV_CC_SetIntValueEx_NET("GevSCPSPacketSize", nPacketSize);
                    if (nRet != MyCamera.MV_OK)
                    {
                        MessageBox.Show($"设置相机{m_Name}最佳数据包大小失败");
                    }
                }
                else
                {
                    MessageBox.Show($"获取相机{m_Name}最佳数据包大小失败");
                }
            }
            SetTriggerMode(false);
            MessageBox.Show($"相机{m_Name}打开成功");
            return true;
        }
        /// <summary>
        /// 设置触发模式
        /// </summary>
        /// <param name="isTrigger">触发模式：true；连续采集模式：false</param>
        public void SetTriggerMode(bool isTrigger)
        {
            if (isTrigger)
            {
                m_Camera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
            }
            else
            {
                m_Camera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
            }
        }
        /// <summary>
        /// 设置软触发
        /// </summary>
        /// <param name="trigBySoft"></param>
        public void SetSoftTrigger(bool trigBySoft)
        {
            if (trigBySoft)
            {
                m_Camera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
            }
            else
            {
                //外部触发源：Line0~Line3，默认用Line0
                m_Camera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);
            }
        }

        /// <summary>
        /// 开始采集
        /// </summary>
        public void StartGrabbing()
        {
            int nRet = m_Camera.MV_CC_StartGrabbing_NET();
            if (MyCamera.MV_OK != nRet)
            {
                MessageBox.Show($"相机{m_Camera}开始采集失败");
            }
        }

        /// <summary>
        /// 停止采集
        /// </summary>
        public void StopGrabbing()
        {
            int nRet = m_Camera.MV_CC_StopGrabbing_NET();
            if (nRet != MyCamera.MV_OK)
            {
                MessageBox.Show($"相机{m_Camera}结束采集失败");
            }
        }

        public void GetImage(ref Bitmap m_bitmap)
        {
            PixelFormat m_bitmapPixelFormat = PixelFormat.Undefined;
            int nRet = m_Camera.MV_CC_GetImageBuffer_NET(ref stFrameOut, 1000);
            // 获取一帧图像
            if (MyCamera.MV_OK == nRet)
            {
                MyCamera.MvGvspPixelType enType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Undefined;
                uint nChannelNum = 0;
                if (IsColorPixelFormat(stFrameOut.stFrameInfo.enPixelType))
                {
                    enType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                    m_bitmapPixelFormat = PixelFormat.Format24bppRgb;
                    nChannelNum = 3;
                }
                else if (IsMonoPixelFormat(stFrameOut.stFrameInfo.enPixelType))
                {
                    enType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8;
                    m_bitmapPixelFormat = PixelFormat.Format8bppIndexed;
                    nChannelNum = 1;
                }

                if (enType != MyCamera.MvGvspPixelType.PixelType_Gvsp_Undefined)
                {
                    if (pBufForConvert == IntPtr.Zero)
                    {
                        pBufForConvert = Marshal.AllocHGlobal((int)(stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight * nChannelNum));
                    }
                    //创建转换变量
                    MyCamera.MV_PIXEL_CONVERT_PARAM stConvertPixelParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();

                    //图像相关
                    stConvertPixelParam.nWidth = stFrameOut.stFrameInfo.nWidth; //图像宽度
                    stConvertPixelParam.nHeight = stFrameOut.stFrameInfo.nHeight; //图像高度
                    stConvertPixelParam.pSrcData = stFrameOut.pBufAddr; //源数据
                    stConvertPixelParam.nSrcDataLen = stFrameOut.stFrameInfo.nFrameLen; //图像大小
                    stConvertPixelParam.enSrcPixelType = stFrameOut.stFrameInfo.enPixelType; //源数据的格式
                    stConvertPixelParam.enDstPixelType = enType; //图像像素格式
                    //转换后
                    stConvertPixelParam.pDstBuffer = pBufForConvert; //转换后的数据地址
                    stConvertPixelParam.nDstBufferSize = (uint)(stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight * nChannelNum);//数据包大小
                    
                    nRet = m_Camera.MV_CC_ConvertPixelType_NET(ref stConvertPixelParam);//格式转换
                    if (MyCamera.MV_OK != nRet)
                    {
                        MessageBox.Show($"相机{m_Name}像素格式转换失败");
                    }
                    m_bitmap = new Bitmap((Int32)stConvertPixelParam.nWidth, (Int32)stConvertPixelParam.nHeight, m_bitmapPixelFormat);
                    BitmapData bitmapData = m_bitmap.LockBits(new Rectangle(0, 0, stConvertPixelParam.nWidth, stConvertPixelParam.nHeight), ImageLockMode.ReadWrite, m_bitmap.PixelFormat);
                    CopyMemory(bitmapData.Scan0, stConvertPixelParam.pDstBuffer, (UInt32)(bitmapData.Stride * m_bitmap.Height));
                    m_bitmap.UnlockBits(bitmapData);
                }
                m_Camera.MV_CC_FreeImageBuffer_NET(ref stFrameOut);
                //if (pBufForConvert != IntPtr.Zero)
                //{
                //    Marshal.FreeHGlobal(pBufForConvert);
                //}
            }
        }
        static bool IsMonoPixelFormat(MyCamera.MvGvspPixelType enType)
        {
            switch (enType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
                    return true;
                default:
                    return false;
            }
        }

        static bool IsColorPixelFormat(MyCamera.MvGvspPixelType enType)
        {
            switch (enType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BGR8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
                    return true;
                default:
                    return false;
            }
        }
        /// <summary>
        /// 设置相机曝光
        /// </summary>
        /// <param name="value"></param>
        public void SetExposure(float value)
        {
            m_Camera.MV_CC_SetEnumValue_NET("ExposureAuto", 0);
            int nRet = m_Camera.MV_CC_SetFloatValue_NET("ExposureTime", value);
            if (nRet != MyCamera.MV_OK)
            {
                MessageBox.Show($"相机{m_Name}设置曝光值失败");
            }
        }
        /// <summary>
        /// 获取相机设置当前曝光
        /// </summary>
        /// <returns></returns>
        public double GetExposure()
        {
            MVCC_FLOATVALUE exposureTime = new MVCC_FLOATVALUE();
            int nRet = m_Camera.MV_CC_GetFloatValue_NET("ExposureTime", ref exposureTime);
            if (nRet != MyCamera.MV_OK)
            {
                MessageBox.Show($"相机{m_Name}获取曝光值失败");
            }
            return exposureTime.fCurValue;
        }
        /// <summary>
        ///  获取相机设置最大曝光
        /// </summary>
        /// <returns></returns>
        public double GetExposureMAX()
        {
            MVCC_FLOATVALUE exposureTime = new MVCC_FLOATVALUE();
            int nRet = m_Camera.MV_CC_GetFloatValue_NET("ExposureTime", ref exposureTime);
            if (nRet != MyCamera.MV_OK)
            {
                MessageBox.Show($"相机{m_Name}获取曝光值失败");
            }
            return exposureTime.fMax;
        }
        /// <summary>
        /// 获取相机设置最小曝光
        /// </summary>
        /// <returns></returns>
        public double GetExposureMIN()
        {
            MVCC_FLOATVALUE exposureTime = new MVCC_FLOATVALUE();
            int nRet = m_Camera.MV_CC_GetFloatValue_NET("ExposureTime", ref exposureTime);
            if (nRet != MyCamera.MV_OK)
            {
                MessageBox.Show($"相机{m_Name}获取曝光值失败");
            }
            return exposureTime.fMin;
        }

        /// <summary>
        /// 设置相机增益
        /// </summary>
        /// <param name="value"></param>
        public void SetGainValue(float value)
        {
            m_Camera.MV_CC_SetEnumValue_NET("GainAuto", 0);
            int nRet = m_Camera.MV_CC_SetFloatValue_NET("Gain", value);
            if (nRet != MyCamera.MV_OK)
            {
                MessageBox.Show($"相机{m_Name}设置增益值失败");
            }
        }
        /// <summary>
        /// 获取相机设置当前曝光
        /// </summary>
        /// <returns></returns>
        public double GetGain()
        {
            MVCC_FLOATVALUE gainRange = new MVCC_FLOATVALUE();
            int nRet = m_Camera.MV_CC_GetFloatValue_NET("Gain", ref gainRange);
            if (nRet != MyCamera.MV_OK)
            {
                MessageBox.Show($"相机{m_Name}获取曝光值失败");
            }
            return gainRange.fCurValue;
        }
        /// <summary>
        ///  获取相机设置最大曝光
        /// </summary>
        /// <returns></returns>
        public double GetGainMAX()
        {
            MVCC_FLOATVALUE gainRange = new MVCC_FLOATVALUE();
            int nRet = m_Camera.MV_CC_GetFloatValue_NET("Gain", ref gainRange);
            if (nRet != MyCamera.MV_OK)
            {
                MessageBox.Show($"相机{m_Name}获取曝光值失败");
            }
            return gainRange.fMax;
        }
        /// <summary>
        /// 获取相机设置最小曝光
        /// </summary>
        /// <returns></returns>
        public double GetGainMIN()
        {
            MVCC_FLOATVALUE gainRange = new MVCC_FLOATVALUE();
            int nRet = m_Camera.MV_CC_GetFloatValue_NET("Gain", ref gainRange);
            if (nRet != MyCamera.MV_OK)
            {
                MessageBox.Show($"相机{m_Name}获取曝光值失败");
            }
            return gainRange.fMin;
        }

        /// <summary>
        /// 关闭相机
        /// </summary>
        /// <returns></returns>
        public bool CloseCamera()
        {
            int nRet = m_Camera.MV_CC_CloseDevice_NET();
            if (nRet != MyCamera.MV_OK)
            {
                MessageBox.Show($"关闭相机{m_Name}失败");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 销毁相机
        /// </summary>
        /// <returns></returns>
        public void DestroyCamera()
        {
            int nRet = m_Camera.MV_CC_DestroyDevice_NET();
            if (nRet != MyCamera.MV_OK)
            {
                MessageBox.Show($"销毁相机{m_Name}失败");
            }
        }
    }
}
