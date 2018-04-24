using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Thread th = Thread.CurrentThread;
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep1 = new IPEndPoint(IPAddress.Broadcast, 9050);
            byte[] data = Encoding.ASCII.GetBytes("This is a test message");
            EndPoint ep = (EndPoint)iep1;
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);

            while (true)
            {
                sw.Start();
                Thread.Sleep(1100);
                sock.SendTo(data, iep1);
                if (sw.ElapsedMilliseconds == 1100)
                {
                    break;
                }

            }
            sock.Close();
        }
    }
}
