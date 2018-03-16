using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPBroadCastClient
{
    public class UdpRecieverEventArgs : EventArgs
    {
        public string Command;
    }
    public class UDPReceiver
    {
        private UdpClient udpClient;
        private Thread UdpThread;
        public EventHandler<UdpRecieverEventArgs> OnReceiveHandler;//接受事件
        public IPEndPoint RemoteIp;
        private bool bThread=true;
        private bool bRunning;
      

        public UDPReceiver(int port)
        {
            StartReceiver(port);
        }

        public void StartReceiver(int port)
        {

            udpClient = new UdpClient(new IPEndPoint(IPAddress.Any, port));
            udpClient.Client.ReceiveTimeout = 2000;
            RemoteIp = new IPEndPoint(IPAddress.Any, 0);

            if (bThread == true)
            {
                bRunning = true;
                UdpThread = new Thread(new ThreadStart(RecvThread));
                UdpThread.IsBackground = true;
                UdpThread.Start();
            }
        }
        void RecvThread()
        {
            IPEndPoint remoteHost = null;

            string msg = "";
            while (bRunning)
            {
                try
                {
                    byte[] buf = udpClient.Receive(ref remoteHost);
                    msg = Encoding.UTF8.GetString(buf);
                    if (msg != "" && OnReceiveHandler != null)
                    {

                        OnReceiveHandler(this, new UdpRecieverEventArgs() { Command = msg });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("mc-UdpBroadReceiver: ");
                    continue;
                }
               
            }
        }
            //udpClient.Close();
            //UdpThread.Abort();
        
        public void Dispose()
        {
            UdpThread.Abort();
            Thread.Sleep(TimeSpan.FromMilliseconds(500d));
            bRunning = false;
            udpClient.Close();
            //WinHelper.WaitForThreadExit(RecvThreadHandler);
        }
    }
}
