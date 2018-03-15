using System;
using System.Windows.Forms;

namespace GlobalSetting
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            textBox1.Text = Application.StartupPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FilePath.UnRar(textBox1.Text);
            this.Close();
        }
    }
}
