using FrmResultView;
using System;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Logger;
using Newtonsoft.Json;
using System.Threading;
using System.Collections.Generic;
using System.Data;

namespace Symmetry
{
    public partial class FormMain : DockContent
    {
        /// <summary>
        /// 图像显示栏
        /// </summary>
        private static FrmImgeView FrmImgeDlg = new FrmImgeView();
        /// <summary>
        /// 结果数据显示栏
        /// </summary>
        private static FrmResultView FrmResultDlg = new FrmResultView();
        /// <summary>
        /// 日志栏
        /// </summary>
        private static FrmLogger FrmLoggerDlg = new FrmLogger();

        /// <summary>
        /// 相机配置
        /// </summary>
        private static FrmCameraSetting frmCameraSetting = new FrmCameraSetting();

        /// <summary>
        /// PLC配置
        /// </summary>
        private static FrmPlcSetting frmPlcSetting = new FrmPlcSetting();

        /// <summary>
        /// 系统设置
        /// </summary>
        private static FrmSystemSettings frmSystemSettings = new FrmSystemSettings();

        /// <summary>
        /// 登录验证
        /// </summary>
        private static FrmLogin frmLogin = new FrmLogin();

        /// <summary>
        /// 程序所有的配置
        /// </summary>
        private readonly string ConfigsFile = Application.StartupPath + "\\ExeConfigs.ini";

        /// <summary>
        /// 程序所有配置
        /// </summary>
        public ExeConfig ExeConfig = new ExeConfig();

        /// <summary>
        /// 窗口布局配置
        /// </summary>
        private readonly string DockPanelConfig = Application.StartupPath + "\\DockPanel.config";

        /// <summary>
        /// 反序列化DockContent代理
        /// </summary>
        private DeserializeDockContent DeserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);


        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitDockPanel();
            BindingSubFormEvent();
            InitExeConfigs();
        }

        /// <summary>
        /// 初始化程序配置
        /// </summary>
        private void InitExeConfigs()
        {
            string json = string.Empty;
            if (!File.Exists(ConfigsFile))
            {
                File.Create(ConfigsFile).Dispose();
                json = "{}"; // 默认 JSON 内容
            }
            else
            {
                json = File.ReadAllText(ConfigsFile);
            }

            if (string.IsNullOrWhiteSpace(json))
            {
                json = "{}"; // 如果文件为空，设置默认值
            }

            ExeConfig = JsonConvert.DeserializeObject<ExeConfig>(json);
        }

        /// <summary>
        /// 绑定子窗口的事件处理
        /// </summary>
        private void BindingSubFormEvent()
        {
            // 窗口停靠改变事件
            FrmImgeView.IsShowOnDockContentChanged += FrmImgeDlg_IsShowOnDockContentChanged;
            FrmResultView.IsShowOnDockContentChanged += FrmImgeDlg_IsShowOnDockContentChanged;
            FrmLogger.IsShowOnDockContentChanged += FrmImgeDlg_IsShowOnDockContentChanged;

            // 配置更新事件处理
            Config.ConfigsChanged += ConfigsChanged;

            // 登录通知
            FrmLogin.LoginHandler += LoginHandler;
        }

        private void LoginHandler(object sender, bool e)
        {
            if (e)
                登录ToolStripMenuItem.Text = "退出";
            else
                登录ToolStripMenuItem.Text = "登录";
            SetEnable(e);

        }

        private void SetEnable(bool enable)
        {
            fileToolStripMenuItem.Enabled = enable;
            cameraToolStripMenuItem.Enabled = enable;
            plcToolStripMenuItem.Enabled = enable;
            算法参数ToolStripMenuItem.Enabled = enable;
            设置ToolStripMenuItem.Enabled = enable;
        }

        private void ConfigsChanged()
        {
            ExeConfig.CameraConfig = frmCameraSetting.Configs;
            ExeConfig.PlcConfig = frmPlcSetting.Configs;
            //ExeConfig.DetectResultConfig = FrmResultDlg.Configs;
            ExeConfig.SystemConfig = frmSystemSettings.Configs;
        }

        /// <summary>
        /// 停靠窗口的改变事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmImgeDlg_IsShowOnDockContentChanged(object sender, bool e)
        {
            if (sender is FrmImgeView)
                图像ToolStripMenuItem.Checked = e;
            else if (sender is FrmResultView)
                数据窗口ToolStripMenuItem.Checked = e;
            else if (sender is FrmLogger)
                日志窗口ToolStripMenuItem.Checked = e;
        }

        /// <summary>
        /// 加载窗口布局
        /// </summary>
        private void InitDockPanel()
        {
            try
            {
                if (File.Exists(DockPanelConfig))
                {
                    // 如果存在，则从配置文件加载布局
                    this.dockPanel1.LoadFromXml(DockPanelConfig, DeserializeDockContent);
                }
                else
                {
                    LoadDefaultDockPanel();
                }
            }
            catch (Exception ex)
            {
                LoadDefaultDockPanel();
            }
            //更新状态
            图像ToolStripMenuItem.Checked = FrmImgeDlg.Visible;
            数据窗口ToolStripMenuItem.Checked = FrmResultDlg.Visible;
            日志窗口ToolStripMenuItem.Checked = FrmLoggerDlg.Visible;
        }

        /// <summary>
        /// 默认窗口布局
        /// </summary>
        private void LoadDefaultDockPanel()
        {
            FrmImgeDlg.Show(this.dockPanel1, DockState.Document);
            FrmResultDlg.Show(this.dockPanel1, DockState.DockRight);
            FrmLoggerDlg.Show(this.dockPanel1, DockState.DockBottom);
        }

        /// <summary>
        /// 配置委托函数
        /// </summary>
        /// <param name="persistString"></param>
        /// <returns></returns>
        private static IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(FrmImgeView).ToString())
                return FrmImgeDlg;

            else if (persistString == typeof(FrmResultView).ToString())
                return FrmResultDlg;

            else if (persistString == typeof(FrmLogger).ToString())
                return FrmLoggerDlg;

            else
                return null;
        }

        private void 图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            图像ToolStripMenuItem.Checked = !图像ToolStripMenuItem.Checked;
            if (图像ToolStripMenuItem.Checked)
                FrmImgeDlg.Show(this.dockPanel1, DockState.Document);
            else
                FrmImgeDlg.Hide(); 
        }

        private void 数据窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            数据窗口ToolStripMenuItem.Checked = !数据窗口ToolStripMenuItem.Checked;
            if (数据窗口ToolStripMenuItem.Checked)
                FrmResultDlg.Show(this.dockPanel1, DockState.DockRight);
            else
                FrmResultDlg.Hide();
        }

        private void 日志窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            日志窗口ToolStripMenuItem.Checked = !日志窗口ToolStripMenuItem.Checked;
            if (日志窗口ToolStripMenuItem.Checked)
                FrmLoggerDlg.Show(this.dockPanel1, DockState.DockBottom);
            else
                FrmLoggerDlg.Hide();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 保存窗口布局
            this.dockPanel1.SaveAsXml(DockPanelConfig);
            // 保存程序配置
            File.WriteAllText(ConfigsFile, JsonConvert.SerializeObject(ExeConfig, Formatting.Indented));
        }
        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = false;
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = true;
        }

        /// <summary>
        /// 在线点检
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = false;
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = true;
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = true;
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = false;
        }
        
        /// <summary>
        /// 显示相机设置窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void camToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCameraSetting.ShowDialog();
        }

        /// <summary>
        /// 显示plc设置窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlcSetting.ShowDialog();
        }

        /// <summary>
        /// 点击系统设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSystemSettings.ShowDialog();
        }

        private void 添加1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmResultDlg.AddOk1();
        }

        private void 添加NG1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmResultDlg.AddNg1();
        }

        private void 添加ok2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmResultDlg.AddOk2();
        }

        private void 添加ng2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmResultDlg.AddNg2();
        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmLogin.IsLogin)
            {
                frmLogin.Quit();
                登录ToolStripMenuItem.Text = "登录";
            }
            else
                frmLogin.ShowDialog();
        }
    }
}
