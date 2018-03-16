using GlobalValues;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace UDPBroadCastServer
{
    public partial class ServerForm : Form
    {
        public UDPServer server;
        Process openExe;
        Process startScreenCast;
        public ServerForm()
        {
            InitializeComponent();
            server = new UDPServer(8080);
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "") 
            server.SendMessage(richTextBox1.Text);
        }

        private void openClassRoom_Click(object sender, EventArgs e)
        {
            server.SendMessage(UDPCommand.OPEN_VRCLASSROOM);
            OpenExe(ExeName.VRCLASSROOM);
        }

     
        public void OpenExe(string exeName)
        {
            if (openExe == null)
            {
                openExe = new Process();
                openExe.StartInfo.FileName = Application.StartupPath+"\\"+ exeName;
                Console.WriteLine(openExe.StartInfo.FileName);
                openExe.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
                openExe.StartInfo.Arguments = "";
                openExe.StartInfo.WorkingDirectory = "";
                openExe.StartInfo.UseShellExecute = false;
                openExe.StartInfo.RedirectStandardInput = true;
                openExe.StartInfo.RedirectStandardOutput = true;
                openExe.StartInfo.RedirectStandardError = true;
                openExe.StartInfo.ErrorDialog = false;
                openExe.StartInfo.CreateNoWindow = true;
                openExe.Start();
            }

        }

        private void startBoardcastBtn_Click(object sender, EventArgs e)
        {
            if (startScreenCast == null)
            {
                startScreenCast = new Process();
                startScreenCast.StartInfo.FileName = Application.StartupPath + "\\screen-cast.exe";
                Console.WriteLine(startScreenCast.StartInfo.FileName);
                startScreenCast.StartInfo.Arguments = "";
                startScreenCast.StartInfo.WorkingDirectory = "";
                startScreenCast.StartInfo.UseShellExecute = false;
                startScreenCast.StartInfo.RedirectStandardInput = true;
                startScreenCast.StartInfo.RedirectStandardOutput = true;
                startScreenCast.StartInfo.RedirectStandardError = true;
                startScreenCast.StartInfo.ErrorDialog = false;
                startScreenCast.StartInfo.CreateNoWindow = true;
                startScreenCast.Start();
            }
           
        }

        private void endBroadcastBtn_Click(object sender, EventArgs e)
        {
            if (startScreenCast != null)
            {
                startScreenCast.Close();
            }
            server.SendMessage(UDPCommand.SCREENCAST_CLOSE);
        }
    }
}
