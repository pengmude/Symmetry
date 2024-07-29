using MvCamCtrl.NET;
using PLC;
using System;
using System.IO.Ports;

namespace Symmetry
{
    /// <summary>
    /// 所有非主窗口类共用配置改变事件
    /// </summary>
    public class Config
    {
        public delegate void YTEventHandler();
        public static YTEventHandler ConfigsChanged;
    }

    /// <summary>
    /// 正负极相机配置
    /// </summary>
    public struct CameraConfig
    {
        public MyCamera.MV_CC_DEVICE_INFO CameraInfoPositive;
        public MyCamera.MV_CC_DEVICE_INFO CameraInfoNegative;
    }

    /// <summary>
    /// PLC配置
    /// </summary>
    public struct PlcConfig
    {
        public string ComName;
        public int BaudRate;
        public int DataBit;
        public StopBits StopBits;
        public Parity Parity;
        public bool IsOpen;
        public PlcConfig(string com, int baud, int databit, StopBits stopbits, Parity parity, bool isOpen)
        {
            ComName = com;
            BaudRate = baud;
            DataBit = databit;
            StopBits = stopbits;
            Parity = parity;
            IsOpen = isOpen;
        }
    }

    /// <summary>
    /// 不同连接类型的PLC设备
    /// </summary>
    public struct PLC_DEVICE
    {
        public SerialPLC SerialPLC;
        public TCPIPPLC EthernetPLC;
    }

    /// <summary>
    /// 对称度算法配置
    /// </summary>
    public struct SymmetryConfig
    {
        public uint Col1;
    }

    /// <summary>
    /// 系统设置
    /// </summary>
    public struct SystemSettingsConfig
    {
        public string SrcImgPath;
        public string RenImgPath;
        public bool IsSaveSrcImg;
        public bool IsSaveRenImg;
        public bool CompressSrcImg;
        public bool CompressRenImg;
        public bool AutoDeleteImg;
        public uint AutoDeleteCountdown;
        public bool AutoRun;
        public string SignalReady;
        public string SignalShot;
        public string SignalOk;
        public string SignalNg;
    }

    public struct SystemConfig 
    {
        public SystemSettingsConfig Item1;
        public SystemSettingsConfig Item2;
    }

    /// <summary>
    /// 检测结果配置
    /// </summary>
    public struct DetectResultConfig
    {
        public uint CountTotal1;
        public uint CountOk1;
        public uint CountNg1;
        public string Percent1;

        public uint CountTotal2;
        public uint CountOk2;
        public uint CountNg2;
        public string Percent2;
    }

    /// <summary>
    /// 整个程序配置
    /// </summary>
    public struct ExeConfig
    {
        public CameraConfig CameraConfig;
        public PlcConfig PlcConfig;
        public SymmetryConfig SymmetryConfig;
        public SystemConfig SystemConfig;
        public DetectResultConfig DetectResultConfig;
    }

}
