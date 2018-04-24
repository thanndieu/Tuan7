using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace Pinging
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Ping myPing = new Ping();
                Console.Write("Input IP to Ping: ");
                string p = Console.ReadLine();
                PingReply reply = myPing.Send(""+p,10000);
                if (reply != null)
                {
                    Console.WriteLine("Status: " + reply.Status + " ,Time: " + reply.RoundtripTime.ToString() + " ,Address: " + reply.Address);

                }

            }
            catch
            {
                Console.WriteLine("Check your input or something wrong occure!");
            }
            Console.ReadKey();
        }
    }
}
