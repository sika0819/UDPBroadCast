using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDPBroadCast
{
    public partial class ClientForm : Form
    {
        UDPReceiver client;
        public ClientForm()
        {
            InitializeComponent();
            client = new UDPReceiver();
        }
    }
}
