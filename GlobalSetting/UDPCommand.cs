using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GlobalSetting
{

    public static class UDPCommand
    {
        public const string FORM_CLOSE = "form_close";
        public const string FORM_HIDE = "form_hide";
        public const string FORM_SHOW = "form_show";
        public const string OPEN_VRCLASSROOM = "open_vrclassroom";
        public const string OPEN_SCREEN_CLIENT = "open_screen_client";
    }
    public static class ExeName {
        public const string VRCLASSROOM = "VRSteam教室";
        public const string CHUANLIANDIANLU = "串联电路";
        public const string DANBAI = "单摆";
        public const string TANLI = "弹力";
        public const string DIANCI = "电磁";
        public const string FOLI = "浮力";
        public const string GUANGHEZUOYONG = "光合呼吸作用";
        public const string HUALUNZU = "滑轮组";
        public const string HUAXUEFENZISHI = "化学分子式";
        public const string MOCALI = "摩擦力";
        public const string RENTIJIEPOU = "人体解剖";
        public const string CHAICHE = "拆车";
        public const string CISHENGDIAN = "磁生电";
        public const string HANYULEYUAN = "光合作用";
        public const string SHUIGUORENZHE = "水果忍者";
        public const string TAIYANGXI = "太阳系";
        public const string ZHENGCHANG = "正常人眼";
        public const string JINSHI = "近视眼";
        public const string YUANSHI = "远视眼";
        public const string ZHESHE = "折射实验";

    }
    public static class FilePath {
        public static string GetPath(string fileName) {
            
            string fileDir = Environment.CurrentDirectory+"\\"+fileName+".exe";
            Console.WriteLine("当前程序目录：" + fileDir);
            return fileDir ;
        }
        public static string GetSetting(string name) {
            return null;
        }
        public static void UnRar(string path) {
            ProcessStartInfo startinfo = new ProcessStartInfo(); ;
            Process process = new Process();
            string rarName = "EXE.rar"; //将要解压缩的 .rar 文件名（包括后缀）  
             //path文件解压路径（绝对）  
            string rarPath =path;  //将要解压缩的 .rar 文件的存放目录（绝对路径）  
            string rarexe = @"c:\Program Files\WinRAR\WinRAR.exe";  //WinRAR安装位置  

            try
            {
                //解压缩命令，相当于在要压缩文件(rarName)上点右键->WinRAR->解压到当前文件夹  
                string cmd = string.Format("x {0} {1} -y",
                                    rarName,
                                    path);
                startinfo.FileName = rarexe;
                startinfo.Arguments = cmd;                          //设置命令参数  
                startinfo.WindowStyle = ProcessWindowStyle.Hidden;  //隐藏 WinRAR 窗口  

                startinfo.WorkingDirectory = rarPath;
                process.StartInfo = startinfo;
                process.Start();
                process.WaitForExit(); //无限期等待进程 winrar.exe 退出  
                if (process.HasExited)
                {
                    MessageBox.Show("解压缩成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("解压缩成功");
            }
            finally
            {
                process.Dispose();
                process.Close();
            }
        }
    }
    
}
