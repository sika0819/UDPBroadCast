using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace client
{

    public class UdpRecieverEventArgs:EventArgs
    {
        public byte[] data;
    }
    public class UdpReciever
    {
        private UdpClient UdpHandler = null;
        private IPEndPoint RemoteIp = null;
        private bool bRunning = false;
        private Thread RecvThreadHandler = null;

        public EventHandler<UdpRecieverEventArgs> OnUdpRecieverEventHandler;

        public UdpReciever(int port, bool bThread = true, int Timeout = 2000)
        {
            {
                UdpHandler = new UdpClient(new IPEndPoint(IPAddress.Any, port));
                UdpHandler.Client.ReceiveTimeout = Timeout;
                RemoteIp = new IPEndPoint(IPAddress.Any, 0);

                if (bThread == true)
                {
                    bRunning = true;
                    RecvThreadHandler = new Thread(new ThreadStart(RecvThread));
                    RecvThreadHandler.IsBackground = true;
                    RecvThreadHandler.Start();
                }
            }
        }

        public void Dispose()
        {
            bRunning = false;
            UdpHandler.Close();
            //WinHelper.WaitForThreadExit(RecvThreadHandler);
        }

        public void RecvThread()
        {
            byte[] msg = null;
            while(bRunning)
            {
                try
                {
                    msg = UdpHandler.Receive(ref RemoteIp);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("mc-UdpBroadReceiver: ");
                    continue;
                }
                if (msg != null && OnUdpRecieverEventHandler != null)
                    OnUdpRecieverEventHandler(this, new UdpRecieverEventArgs() { data = msg});
            }
        }

        public byte[] ReceiveMsg()
        {
            return UdpHandler.Receive(ref RemoteIp);
        }
    }
}
