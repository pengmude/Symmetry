using MvCamCtrl.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_CameraClass
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        CameraHik[] CameraList;
        List<string> CamNameList = new List<string>();
        public CameraHik[] AcquireCameraList()
        {
            //强制回收即时垃圾
            GC.Collect();
            //枚举相机设备
            MyCamera.MV_CC_DEVICE_INFO_LIST stDevList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
            stDevList.nDeviceNum = 0;
            int nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref stDevList);
            //获取失败则退出程序
            if (MyCamera.MV_OK != nRet)
            {
                MessageBox.Show("获取相机列表失败");
            }
            CameraList = new CameraHik[stDevList.nDeviceNum];

            //创建相机列表，获取设备信息
            for (int i = 0; i < stDevList.nDeviceNum; i++)
            {
                MyCamera.MV_CC_DEVICE_INFO stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(stDevList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                if (stDevInfo.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo,
                                                                typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                    CameraList[i] = new CameraHik();
                    CameraList[i].m_ID = i;
                    CameraList[i].m_SerialNumber = gigeInfo.chSerialNumber; //相机序列号
                    CameraList[i].m_Name = gigeInfo.chModelName; //相机型号
                    //MessageBox.Show($"chManufacturerName:{gigeInfo.chManufacturerName}");
                    //MessageBox.Show($"chManufacturerSpecificInfo:{gigeInfo.chManufacturerSpecificInfo}");
                    //MessageBox.Show($"nNetExport:{gigeInfo.nNetExport}");
                    //MessageBox.Show($"chModelName:{gigeInfo.chModelName}");
                    //MessageBox.Show($"chSerialNumber:{gigeInfo.chSerialNumber}");
                    //MessageBox.Show($"nCurrentSubNetMask:{gigeInfo.nCurrentSubNetMask}");
                    //MessageBox.Show($"chDeviceVersion:{gigeInfo.chDeviceVersion}");
                    CameraList[i].stDevInfo = stDevInfo;  //通用设备信息
                }
                if (stDevInfo.nTLayerType == MyCamera.MV_USB_DEVICE)
                {
                    MyCamera.MV_USB3_DEVICE_INFO usbInfo = (MyCamera.MV_USB3_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stUsb3VInfo,
                                            typeof(MyCamera.MV_USB3_DEVICE_INFO));
                    CameraList[i] = new CameraHik();
                    CameraList[i].m_ID = i;
                    CameraList[i].m_SerialNumber = usbInfo.chSerialNumber;
                    CameraList[i].m_Name = usbInfo.chModelName;
                    CameraList[i].stDevInfo = stDevInfo;
                }
                CamNameList.Add(CameraList[i].m_Name + "(" + CameraList[i].m_SerialNumber + ")");
            }
            return CameraList;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CameraList = AcquireCameraList();
            for (int i = 0; i < CamNameList.Count; i++)
            {
                this.comboBox1.Items.Add(CamNameList[i]);
            }
            this.comboBox1.Text = CamNameList[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(var item in CameraList)
            {
                if (this.comboBox1.Text == (item.m_Name + "(" + item.m_SerialNumber + ")"))
                    item.OpenCamera();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in CameraList)
            {
                if (this.comboBox1.Text == (item.m_Name + "(" + item.m_SerialNumber + ")"))
                {
                    item.CloseCamera();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (var item in CameraList)
            {
                if (this.comboBox1.Text == (item.m_Name + "(" + item.m_SerialNumber + ")"))
                {
                    item.DestroyCamera();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in CameraList)
            {
                if (this.comboBox1.Text == (item.m_Name + "(" + item.m_SerialNumber + ")"))
                {
                    item.StartGrabbing();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var item in CameraList)
            {
                if (this.comboBox1.Text == (item.m_Name + "(" + item.m_SerialNumber + ")"))
                {
                    item.StopGrabbing();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (var item in CameraList)
            {
                if (this.comboBox1.Text == (item.m_Name + "(" + item.m_SerialNumber + ")"))
                {
                    Bitmap bitmap = null;
                    item.GetImage(ref bitmap);
                    this.pictureBox1.Image = bitmap;
                }
            }
        }
    }
}