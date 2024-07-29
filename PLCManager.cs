using HslCommunication;
using HslCommunication.Profinet.Panasonic;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLC
{
    /// <summary>
    /// PLC的连接方式
    /// </summary>
    public enum PLCConnectType
    {
        SERIAL,
        ETHERNET
    }
    public class PLCBase
    {
        public PLCConnectType ConnectType;
        public virtual bool Open(string portName, int baudRate, int dataBits, StopBits stopBits, Parity parity) { return false; }
        public virtual bool Open(string ipAddress, int port) { return false; }
        public virtual bool IsOpen() { return false; }
        public virtual OperateResult<bool> ReadBool(string address) { return new OperateResult<bool>(); }
        public virtual OperateResult<string> ReadString(string address, ushort length, Encoding encoding) { return new OperateResult<string>(); }
        public virtual OperateResult Write(string address, bool value) { return new OperateResult(); }
        public virtual OperateResult WriteInt(string address, int value) { return new OperateResult(); }
        public virtual void Close() { }
    }

    public class SerialPLC : PLCBase
    {
        PanasonicMewtocol panasonicMewtocol = new PanasonicMewtocol();

        public override bool Open(string portName, int baudRate, int dataBits, StopBits stopBits, Parity parity)
        {
            panasonicMewtocol.SerialPortInni(sp =>
            {
                sp.PortName = portName;
                sp.BaudRate = baudRate;
                sp.DataBits = dataBits;
                sp.StopBits = stopBits;
                sp.Parity = parity;
                //sp.StopBits = Convert.ToInt32(tbStopBits.Text) == 0 ? System.IO.Ports.StopBits.None : (Convert.ToInt32(tbStopBits.Text) == 1 ? System.IO.Ports.StopBits.One : System.IO.Ports.StopBits.Two);
                //sp.Parity = cbParity.SelectedIndex == 0 ? System.IO.Ports.Parity.None : (cbParity.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even);
            });
            if (panasonicMewtocol.IsOpen())
                return true;
            else
            {
                panasonicMewtocol.Open();
                if (panasonicMewtocol.Open().IsSuccess)
                    return true;
            }
            return false;
        }

        public override bool IsOpen()
        {
            return panasonicMewtocol.IsOpen();
        }

        public override OperateResult<bool> ReadBool(string address)
        {
            return panasonicMewtocol.ReadBool(address);
        }
        public override OperateResult<string> ReadString(string address, ushort length, Encoding encoding)
        {
            return panasonicMewtocol.ReadString(address, length, encoding);
        }
        public override OperateResult Write(string address, bool value)
        {
            return panasonicMewtocol.Write(address, value);
        }
        public override OperateResult WriteInt(string address, int value)
        {
            return panasonicMewtocol.Write(address, value);
        }
        public override void Close()
        {
            panasonicMewtocol.Close();
        }
    }

    public class TCPIPPLC : PLCBase
    {
        PanasonicMcNet mcNet = new PanasonicMcNet();
        
        bool isConnect = false;
        public override bool Open(string ipAddress, int port)
        {
            mcNet.IpAddress = ipAddress;
            mcNet.Port = port;
            mcNet.ConnectServer();
            isConnect = mcNet.ConnectServer().IsSuccess;
            return isConnect;
        }
        public override bool IsOpen()
        {
            return isConnect;
        }
        public override OperateResult<bool> ReadBool(string address)
        {
            return mcNet.ReadBool(address);          
        }
        public override OperateResult<string> ReadString(string address, ushort length, Encoding encoding)
        {
            return mcNet.ReadString(address, length, encoding);
        }
        public override OperateResult Write(string address, bool value)
        {
            return mcNet.Write(address, value);
        }
        public override OperateResult WriteInt(string address, int value)
        {
            return mcNet.Write(address, value);
        }
        public override void Close()
        {
            if(IsOpen())
            {
                mcNet.ConnectClose();
                isConnect = !mcNet.ConnectClose().IsSuccess;
            }                     
        }
    }
}
