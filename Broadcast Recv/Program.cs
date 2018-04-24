using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;

namespace Broadcast_Recv
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);
            sock.Bind(iep); EndPoint ep = (EndPoint)iep;
            Console.WriteLine("Ready to receive…");
            byte[] data = new byte[1024];
            int recv = sock.ReceiveFrom(data, ref ep);
            string stringData = Encoding.ASCII.GetString(data, 0, recv);
            while (true)
            {

                Console.WriteLine("received: {0} from: {1}", stringData, ep.ToString());
                data = new byte[1024]; recv = sock.ReceiveFrom(data, ref ep);
                stringData = Encoding.ASCII.GetString(data, 0, recv);
                

            }
        }
    }
}
