using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDPBroadCastServer
{
    public partial class ServerForm : Form
    {
        public UDPServer server;
        public ServerForm()
        {
            InitializeComponent();
            server = new UDPServer();
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "") 
            server.SendMessage(richTextBox1.Text);
        }

        private void openClassRoom_Click(object sender, EventArgs e)
        {
            server.SendMessage(GlobalValues.UDPCommand.OPEN_VRCLASSROOM);
        }
    }
}
