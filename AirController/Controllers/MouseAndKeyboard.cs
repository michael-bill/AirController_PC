using AirController.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirController.Controllers
{
    class MouseAndKeyboard
    {
        public static void KeyboardReceiver()
        {
            Thread thread = new Thread(() => {
                UdpClient udpSocket = new UdpClient((int)Settings.Ports.KEYBOARD);
                IPEndPoint ip = null;
                while (true)
                {
                    byte[] data = udpSocket.Receive(ref ip);
                    if (Settings.Connected)
                    {
                        SendKeys.SendWait(Encoding.UTF8.GetString(data));
                    }
                }
            });
            thread.Start();
        }
    }
}
