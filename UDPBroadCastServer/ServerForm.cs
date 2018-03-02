using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDPBroadCastReceiver
{
    public partial class ServerForm : Form
    {
        UDPServer server;
        public ServerForm()
        {
            InitializeComponent();
            server = new UDPServer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "") ;
            server.SendMessage(richTextBox1.Text);
        }
    }
}
