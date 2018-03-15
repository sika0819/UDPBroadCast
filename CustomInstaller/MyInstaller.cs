using System.ComponentModel;
using System.Configuration.Install;

namespace CustomInstaller
{
    [RunInstaller(true)]
    public partial class MyInstaller : System.Configuration.Install.Installer
    {
        public MyInstaller()
        {
            InitializeComponent();
            this.AfterInstall += new InstallEventHandler(Installer_AfterInstall);
        }

        private void Installer_AfterInstall(object sender, InstallEventArgs e)
        {
            
        }
    }
}
