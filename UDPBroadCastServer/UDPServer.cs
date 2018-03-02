﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPBroadCastReceiver
{
    public class UDPServer
    {
        UdpClient UDPsend = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
        IPEndPoint endpoint = new IPEndPoint(IPAddress.Broadcast, 8080);
        //其实 IPAddress.Broadcast 就是 255.255.255.255
        //下面代码与上面有相同的作用
        //IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 8080);
        public void SendMessage(string msg) {
            byte[] byteMsg = Encoding.Default.GetBytes("This is UDP broadcast");
            UDPsend.Send(byteMsg, byteMsg.Length, endpoint);
        }
        
    }
}