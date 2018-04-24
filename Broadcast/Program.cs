using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace Broadcast
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Thread th = Thread.CurrentThread;
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep1 = new IPEndPoint(IPAddress.Broadcast, 9050);

            EndPoint ep = (EndPoint)iep1;
            //IPEndPoint iep2 = new IPEndPoint(IPAddress.Parse("192.168.1.255"), 9050);
            string hostname = Dns.GetHostName();
            byte[] data = Encoding.ASCII.GetBytes(hostname);
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);

            //sock.SendTo(data, iep2);
            while (true)
            {
                sw.Start();
                Thread.Sleep(1000);
                sock.SendTo(data, iep1);
                if (sw.ElapsedMilliseconds == 1000)
                {
                    break;
                }
                
            }




            
        }
    }
}
