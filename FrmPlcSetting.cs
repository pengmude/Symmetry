using System;
using System.Windows.Forms;
using PLC;
using System.IO.Ports;
using FrmResultView;
using Logger;

namespace Symmetry
{
    public partial class FrmPlcSetting : Form
    {
        /// <summary>
        /// PLC设备
        /// </summary>
        public PLC_DEVICE PLC_DEVICE = new PLC_DEVICE();

        /// <summary>
        /// 对外开放访问本类对象的配置
        /// </summary>
        PlcConfig _config = new PlcConfig();
        public PlcConfig Configs {  get { return _config; } set { _config = value;  } }

        public FrmPlcSetting()
        {
            InitializeComponent();
            PLC_DEVICE.SerialPLC = new SerialPLC();
            PLC_DEVICE.EthernetPLC = new TCPIPPLC();

            // 在窗口显示时刷新com
            VisibleChanged += FrmPlcSetting_VisibleChanged;

            if (comboBox_bauterate.Items.Count > 0) { comboBox_bauterate.SelectedIndex = 1; }
            if (comboBox_databit.Items.Count > 0) { comboBox_databit.SelectedIndex = 3; }
            if (comboBox_stopbit.Items.Count > 0) { comboBox_stopbit.SelectedIndex = 0; }
            if (comboBox_parity.Items.Count > 0) { comboBox_parity.SelectedIndex = 0; }
        }

        /// <summary>
        /// 可见性改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPlcSetting_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                GetComPorts();
        }

        /// <summary>
        /// 初始化串口
        /// </summary>
        public void GetComPorts()
        {
            comboBox_com.Items.Clear();
            String[] mystring = SerialPort.GetPortNames(); // 获取计算机的端口名的数组
            for (int i = 0; i < mystring.Length; i++)
            {
                comboBox_com.Items.Add(mystring[i]);
            }
            if (mystring.Length > 0) { comboBox_com.SelectedIndex = 0; }
        }

        /// <summary>
        /// 点击连接串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_connect_Click(object sender, EventArgs e)
        {
            try
            {
                string portName = comboBox_com.Text;
                int baudRate = int.Parse(comboBox_bauterate.Text);
                int dataBits = int.Parse(comboBox_databit.Text);
                StopBits stopBits = comboBox_stopbit.Text == "0" ? StopBits.None : comboBox_stopbit.Text == "1" ? StopBits.One : StopBits.Two;
                Parity parity = comboBox_parity.Text == "无" ? Parity.None : comboBox_parity.Text == "奇" ? Parity.Odd : Parity.Even;

                bool isOpen = PLC_DEVICE.SerialPLC.Open(portName, baudRate, dataBits, stopBits, parity);
                if (isOpen)
                {
                    button_connect.Enabled = false;
                    button_close.Enabled = true;

                    // 连接成功，给主窗口更新plc参数
                    _config = new PlcConfig(portName, baudRate, dataBits, stopBits, parity, true);
                    Config.ConfigsChanged?.Invoke();

                    FrmLogger.AddLog("串口已成功连接！", MsgLevel.Info);
                }
                else
                {
                    button_connect.Enabled = true;
                    button_close.Enabled = false;
                    FrmLogger.AddLog("连接失败！", MsgLevel.Exception);
                    MessageBox.Show("连接失败！");
                }
            }
            catch (Exception ex)
            {
                FrmLogger.AddLog("串口连接异常：" + ex.Message, MsgLevel.Exception);
                MessageBox.Show("串口连接异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 点击关闭串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_close_Click(object sender, EventArgs e)
        {
            PLC_DEVICE.SerialPLC.Close();
            button_connect.Enabled = true;
            button_close.Enabled = false;
            FrmLogger.AddLog("串口已断开连接！", MsgLevel.Info);
        }
    }

}
