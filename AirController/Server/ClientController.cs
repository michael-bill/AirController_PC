using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirController.Server
{
    class ClientController
    {
        public static void ClientDetector()
        {
            Thread cdThread = new Thread(()=> {
                UdpClient udpSocket = new UdpClient((int)Settings.Ports.DETECTION_SERVER);
                IPEndPoint ip = null;
                string message = null;
                while (true)
                {
                    message = Encoding.UTF8.GetString(udpSocket.Receive(ref ip));
                    if (message == Settings.DETECTION_KEY && !Settings.Connected)
                    {
                        byte[] data = Encoding.UTF8.GetBytes(Settings.DETECTION_KEY + "_" + Environment.MachineName);
                        udpSocket.Send(data, data.Length, ip.Address.ToString(), (int)Settings.Ports.DETECTION_CLIENT);
                    }
                }
            });
            cdThread.Start();
        }

        public static void ClientConnector(Form form)
        {
            Thread ccThread = new Thread(()=> {
                UdpClient udpSocket = new UdpClient((int)Settings.Ports.CONNECTION);
                IPEndPoint ip = null;
                string message = null;
                while (true)
                {
                    message = Encoding.UTF8.GetString(udpSocket.Receive(ref ip));
                    if (message == Settings.CONNECTION_KEY && !Settings.Connected)
                    {
                        byte[] data = Encoding.UTF8.GetBytes(Settings.CONNECTION_KEY + "_" + Environment.MachineName);
                        udpSocket.Send(data, data.Length, ip.Address.ToString(), (int)Settings.Ports.CONNECTION);
                        Settings.Connected = true;
                        form.Controls["lblConnectedDevice"].Text = "Device " + ip.Address.ToString() + " connected";
                    }
                }
            });
            ccThread.Start();
        }
    }
}
