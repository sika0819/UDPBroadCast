using System;
using System.Windows.Forms;

namespace UDPBroadCastServer
{
    static class Program
    {
        public static ServerForm serverForm;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            serverForm = new ServerForm();
            Application.Run(serverForm);
        }
    }
}
