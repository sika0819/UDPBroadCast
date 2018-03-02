using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPBroadCast
{
    public class UDPReceiver
    {
        public string Message = "";
         void RecvThread()
        {
            UdpClient UDPrece = new UdpClient(new IPEndPoint(IPAddress.Any, 8080));
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                byte[] buf = UDPrece.Receive(ref endpoint);
                Message = Encoding.Default.GetString(buf);
                Console.WriteLine(Message);
            }
        }
    }
}
