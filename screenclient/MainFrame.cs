using System;
using System.Drawing;
using System.Windows.Forms;

using System.IO;
using System.ComponentModel;

namespace client
{
    public partial class MainFrame : Form
    {
        private PacketHelper.PacketCollector _ObjPicCollector = new PacketHelper.PacketCollector();
        private UdpReciever _ObjUdpReciever = new UdpReciever(12580);
        public MainFrame()
        {
            InitializeComponent();

            this.pciture_screen.BackgroundImageLayout = ImageLayout.Stretch;

            _ObjPicCollector.OnCollectorEventHandler += new EventHandler<PacketHelper.PacketCollectorEventArgs>(this.OnCollectorEvent);
            _ObjUdpReciever.OnUdpRecieverEventHandler += new EventHandler<UdpRecieverEventArgs>(this.OnUdpRecieverEvent);
        
        }


        private void OnCollectorEvent(Object obj, PacketHelper.PacketCollectorEventArgs evt)
        {
            try
            {
                MemoryStream imgStream = new MemoryStream(evt.data, 0, evt.data.Length);
                Bitmap map = (Bitmap)Image.FromStream(imgStream);
                if (map != null)
                    this.pciture_screen.BackgroundImage = map;
            }
            catch
            {

            }
        }

        private void OnUdpRecieverEvent(Object obj,UdpRecieverEventArgs evt)
        {
            _ObjPicCollector.Collect(evt.data);

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnClosing(e);
        }
       
    }
}
