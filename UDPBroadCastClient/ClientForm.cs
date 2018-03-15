using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UDPBroadCastClient
{
    public partial class ClientForm : Form
    {

        private UdpClient udpClient;
        private Thread UdpThread;
        Process p;
        delegate void OnReceivedMsg(string msg);
        OnReceivedMsg ReceiveDelegate;
        public ClientForm()
        {
            InitializeComponent();  
        }

        public void StartReceiver()
        {
            if (udpClient != null)
            {
                UdpThread.Abort();
                Thread.Sleep(TimeSpan.FromMilliseconds(500d));
                udpClient.Close();
            }
            try
            {
                udpClient = new UdpClient(new IPEndPoint(IPAddress.Any, 8080));
                UdpThread = new Thread(new ThreadStart(RecvThread));
                UdpThread.Start();
                //buttonStartServer.Enabled = false;
            }
            catch (Exception y)
            {
                MessageBox.Show(this, y.Message, "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        void RecvThread()
        {
            IPEndPoint remoteHost = null;
           
            //listBox1.Items.Add("启动...");
            while (udpClient != null && Thread.CurrentThread.ThreadState == System.Threading.ThreadState.Running)
            {
                try
                {
                    byte[] buf = udpClient.Receive(ref remoteHost);
                    string bufs = Encoding.UTF8.GetString(buf);
                    this.BeginInvoke(ReceiveDelegate, bufs);
                }
                catch (Exception y)
                {
                    throw y;
                }
            }
            this.Invoke(ReceiveDelegate, "结束...");
        }
        public void OnReceiveMsg(string message)
        {
            switch (message) {
                case GlobalSetting.UDPCommand.FORM_CLOSE:
                    Application.Exit();
                    return;
                case GlobalSetting.UDPCommand.FORM_HIDE:
                    Hide();
                    return;
                case GlobalSetting.UDPCommand.OPEN_VRCLASSROOM:
                    OpenExe(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\" +GlobalSetting.ExeName.VRCLASSROOM);
                    return;
                default:
                    break;
            }
            saveteacherNote.Items.Add(message);
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            StartReceiver();
            ReceiveDelegate = new OnReceivedMsg(OnReceiveMsg);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void saveStuButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "保存学生笔记";
            saveFileDialog1.FileName = "学生笔记"+System.DateTime.UtcNow.ToFileTime();
            saveFileDialog1.Filter = "|*.txt";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                StreamWriter fs = new StreamWriter(saveFileDialog1.FileName);
                fs.Write(richTextBox1.Text);
                fs.Close();
            }
        }


        private void teacherSaveBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "保存教师笔记";
            saveFileDialog1.FileName = "教师笔记" + System.DateTime.UtcNow.ToFileTime();
            saveFileDialog1.Filter = "|*.txt";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                StreamWriter fs = new StreamWriter(saveFileDialog1.FileName,true,Encoding.UTF8);
                for (int i = 0; i < saveteacherNote.Items.Count; i++)
                {
                    string item = saveteacherNote.Items[i].ToString();
                    fs.Write(item);
                    //
                }
                fs.Close();
            }
        }
        
        public void OpenExe(string dir) {
            Console.WriteLine(dir);
            
            if (p == null)
            {
                p = new Process();
                p.StartInfo.FileName = dir;
                p.Start();
            }
            else
            {
                if (p.HasExited) //是否正在运行
                {
                    p.Start();
                }
            }
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
        }
    
    }
}
