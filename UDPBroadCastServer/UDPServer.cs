using System;

using System.Net;
using System.Net.Sockets;
using System.Text;


namespace UDPBroadCastServer
{
    public class UDPServer
    {
        public UdpClient UDPsend;
        IPEndPoint endpoint;
        public UDPServer(int remotePort) {
            UDPsend = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
            endpoint = new IPEndPoint(IPAddress.Broadcast, remotePort);
        }
        
        
        //其实 IPAddress.Broadcast 就是 255.255.255.255
        //下面代码与上面有相同的作用
        //IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 8080);
        public void SendMessage(string msg) {
          
            byte[] byteMsg = Encoding.Default.GetBytes(msg);
            UDPsend.Send(byteMsg, byteMsg.Length, endpoint);
            Console.WriteLine("发送"+msg);
            UDPsend.Close();
        }
        
    }
}
