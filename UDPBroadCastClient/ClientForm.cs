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
        Process p;
       public  UDPReceiver Receiver = new UDPReceiver(8080);
        Process showScreen;
        public ClientForm()
        {
            InitializeComponent();
         
        }

        private void OnReceiveMsg(object sender, UdpRecieverEventArgs udpReceiveEvent)
        {
            Console.WriteLine(udpReceiveEvent.Command);
            switch (udpReceiveEvent.Command)
            {
                case GlobalValues.UDPCommand.FORM_CLOSE:
                    Application.Exit();
                    return;
                case GlobalValues.UDPCommand.FORM_HIDE:
                    Hide();
                    return;
                case GlobalValues.UDPCommand.OPEN_VRCLASSROOM:
                    OpenExe(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + GlobalValues.ExeName.VRCLASSROOM);
                    return;
                case GlobalValues.UDPCommand.SCREENCAST_OPEN:
                    OpenShower();
                    return;
                case GlobalValues.UDPCommand.SCREENCAST_CLOSE:
                    CloseShower();
                    return;
                default:
                    break;
            }
            saveteacherNote.Items.Add(udpReceiveEvent.Command);
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
           
            Receiver.OnReceiveHandler += OnReceiveMsg;
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
        public void OpenShower() {
            if (showScreen == null)
            {
                showScreen = new Process();
                showScreen.StartInfo.FileName = "client.exe";
                showScreen.Start();
            }
            else
            {
                if (showScreen.HasExited) //是否正在运行
                {
                    showScreen.Close();
                }
            }
        }
        public void CloseShower() {
            if (showScreen!=null) //是否正在运行
            {
                showScreen.Kill();
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
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.ApplicationExitCall:
                    
                    e.Cancel = false;
                    break;
                default:
                    notifyIcon1.ShowBalloonTip(1000, "学生端最小化", "最小化，请使用右下角系统通知区域菜单唤醒或退出程序", ToolTipIcon.Info);
                    this.ShowInTaskbar = false;
                    this.Hide();
                    e.Cancel = true;
                    break;
            }

        }
        
    }
}
