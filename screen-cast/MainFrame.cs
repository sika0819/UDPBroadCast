using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using GlobalValues;

namespace screen_cast
{
    public partial class MainFrame : Form
    {
        private ScreenCapture _ObjCapture = new ScreenCapture();
        private UdpHelper _ObjUdp = new UdpHelper("255.255.255.255",12580);
        private Boolean _bRunning = false;

        public MainFrame()
        {
            InitializeComponent();

            this.text_fps.Text = "20";
            this.text_quality.Text = "80";
            this._ObjCapture.OnScreenDataEventHandler += new EventHandler<ScreenCaptureEventArgs>(this.OnScreenData);
            this._ObjCapture.OnScreenDataEventHandler += new EventHandler<ScreenCaptureEventArgs>(this.OnContrl);
            //this.picture_screen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        private void OnContrl(object sender, ScreenCaptureEventArgs e)
        {
            e.data = Encoding.Default.GetBytes(UDPCommand.SCREENCAST_CLOSE);
            _ObjUdp.Send(e.data);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {

            TogglePlay();
        }
        public void TogglePlay() {
            if (this._bRunning == false)
            {
                int Fps = int.Parse(this.text_fps.Text);
                int Quality = int.Parse(this.text_quality.Text);

                this._ObjCapture.UpdateQuality(Quality);
                this._ObjCapture.StartCapture(1000L / Fps);

                this._bRunning = true;
                this.btn_start.Text = "Stop";

                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this._ObjCapture.StopCapture();

                this._bRunning = false;
                this.btn_start.Text = "Start";

            }
        }
        private void OnScreenData(Object obj,ScreenCaptureEventArgs evt)
        {
            try
            {
                MemoryStream imgStream = new MemoryStream(evt.data, 0, evt.data.Length);
                Bitmap map = (Bitmap)Image.FromStream(imgStream);
                if (map == null)
                {
                    throw new Exception("屏幕广播失败");
                    //this.picture_screen.BackgroundImage = map;
                }
                _ObjUdp.Send(evt.data);
            }
            catch
            {

            }
        }
    }
}
