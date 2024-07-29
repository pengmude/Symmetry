using FrmResultView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Logger;

namespace Symmetry
{
    public partial class FrmCameraSetting : Form
    {
        private CameraHik _selectedCamera;
        private List<CameraHik> CameraList = new List<CameraHik>();
        private List<string> CamNameList = new List<string>();

        /// <summary>
        /// 正负极按使用的相机对象
        /// </summary>
        public static CameraHik PositiveCamera;
        public static CameraHik NegativeCamera;

        /// <summary>
        /// 是否显示在DockContent中
        /// </summary>
        public bool IsShowOnDockContent = true;

        /// <summary>
        /// 配置更新给主窗口
        /// </summary>
        private CameraConfig _config = new CameraConfig();

        /// <summary>
        /// 对外开放访问本类对象的配置
        /// </summary>
        public CameraConfig Configs { get { return _config; }  set { _config = value; } }

        public FrmCameraSetting()
        {
            InitializeComponent();
            InitCameras();
        }

        private void InitCameras()
        {
            PositiveCamera = new CameraHik();
            PositiveCamera.SetDevInfo(_config.CameraInfoPositive);
            bool flag1 = false;
            bool flag2 = false;
            flag1 = PositiveCamera.OpenCamera();
            flag1 = PositiveCamera.StartGrabbing();

            NegativeCamera = new CameraHik();
            NegativeCamera.SetDevInfo(_config.CameraInfoNegative);
            flag2 = NegativeCamera.OpenCamera();
            flag2 = NegativeCamera.StartGrabbing();

            if(!flag1 && flag2) { MessageBox.Show("正极相机启动失败！"); }
            if (flag1 && !flag2) { MessageBox.Show("负极相机启动失败！"); }
            if (!flag1 && !flag2) { MessageBox.Show("正极和负极相机均启动失败！"); }
        }

        /// <summary>
        /// 枚举相机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            CameraHik.AcquireCameraList(ref CameraList, ref CamNameList);
            if(CameraList.Count == 0)
            {
                FrmLogger.AddLog( "没有找到海康相机！", MsgLevel.Warn);
                MessageBox.Show("没有找到海康相机！");
                return;
            }

            FrmLogger.AddLog($"总共找到{CameraList.Count}个相机", MsgLevel.Info);

            foreach (var cameraName in CamNameList)
            {
                this.comboBox1.Items.Add(cameraName);
            }
            this.comboBox1.Text = CamNameList.FirstOrDefault();
            _selectedCamera = CameraList.FirstOrDefault();
        }

        /// <summary>
        /// 点击打开相机取流
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (CameraList.Count == 0)
            {
                FrmLogger.AddLog("相机为空取流测试失败！", MsgLevel.Exception);
                return;
            }
            if (!_selectedCamera.IsOpen)
            {
                if (!_selectedCamera.OpenCamera())
                {
                    FrmLogger.AddLog("相机打开失败！检查是否被占用！", MsgLevel.Exception);
                    MessageBox.Show("相机打开失败！检查是否被占用！");
                    return;
                }
            }
            _selectedCamera.StartGrabbing();
            FrmLogger.AddLog("相机取流设置已打开", MsgLevel.Info);
            Bitmap bitmap = null;

            FrmLogger.AddLog("相机开始采集一帧图像……", MsgLevel.Info);
            _selectedCamera.GetImage(ref bitmap);

            if (bitmap != null)
            {
                Invoke(new Action(() =>
                {
                    pictureBox1.Image = bitmap;
                }));
            }
            else
            {
                FrmLogger.AddLog("相机采集图像失败！", MsgLevel.Exception);
                MessageBox.Show("图像为空！");
            }
            _selectedCamera.StopGrabbing();
            _selectedCamera.CloseCamera();
            FrmLogger.AddLog("相机采集图像成功！", MsgLevel.Info);
            YTMessageBox yTMessageBox = new YTMessageBox("相机采集图像成功！");
            yTMessageBox.Show();
        }

        /// <summary>
        /// 选择相机改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCamera = CameraList[comboBox1.SelectedIndex];
        }

        /// <summary>
        /// 设置为正极相机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_positive_setting_Click(object sender, EventArgs e)
        {
            if(_selectedCamera == null)
            {
                FrmLogger.AddLog($"无效相机！", MsgLevel.Exception);
                MessageBox.Show("无效相机！");
                return;
            }
            _selectedCamera.StopGrabbing();
            _selectedCamera.CloseCamera();
            PositiveCamera = _selectedCamera;
            // 通知主窗口更新配置
            _config.CameraInfoPositive = _selectedCamera.GetDevInfo();
            Config.ConfigsChanged?.Invoke();
            FrmLogger.AddLog($"正极相机切换为{_selectedCamera.m_Name}", MsgLevel.Info);
        }

        /// <summary>
        /// 设置为负极相机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_negative_setting_Click(object sender, EventArgs e)
        {
            if (_selectedCamera == null)
            {
                FrmLogger.AddLog($"无效相机！", MsgLevel.Exception);
                MessageBox.Show("无效相机！");
                return;
            }

            _selectedCamera.StopGrabbing();
            _selectedCamera.CloseCamera();
            NegativeCamera = _selectedCamera;
            // 通知主窗口更新配置
            _config.CameraInfoNegative = _selectedCamera.GetDevInfo();
            Config.ConfigsChanged?.Invoke();
            FrmLogger.AddLog($"负极相机切换为{_selectedCamera.m_Name}", MsgLevel.Info);
        }
    }
}