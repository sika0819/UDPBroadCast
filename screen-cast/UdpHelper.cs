using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace screen_cast
{
    class UdpHelper
    {
        private UdpClient UdpHandler = null;
        private IPEndPoint RemoteIp = null;
        private double TimeStamp = 0;

        public UdpHelper(string address, int port)
        {
            try
            {
                UdpHandler = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
                UdpHandler.EnableBroadcast = true;
                RemoteIp = new IPEndPoint(IPAddress.Parse(address), port);
            }
            catch(Exception ex)
            {
                Console.WriteLine("UdpHelper:Init Error.");
            }
        }
        public void Dispose()
        {
            UdpHandler.Close();
        }

        public void Send(byte[] msg)
        {

            TimeStamp += 1;
            ICollection<PacketHelper.CastPacket> Packets = PacketHelper.PacketSplitter.Split(TimeStamp, msg);

            foreach (var Pac in Packets)
            {
                try
                {
                    Byte[] PacByte = Pac.ToArray();
                    UdpHandler.Send(PacByte, PacByte.Length, RemoteIp);
                    //Thread.Sleep(1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("UdpHelper:Send Error.");
                    return;
                }
            }
        }
        public void Send(string msg) {
            byte[] byteMsg = Encoding.Default.GetBytes(msg);
            UdpHandler.Send(byteMsg, byteMsg.Length, RemoteIp);
            Console.WriteLine("发送" + msg);
            UdpHandler.Close();
        }
    }
}
