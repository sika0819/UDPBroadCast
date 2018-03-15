using System;

namespace GlobalSetting
{

    public static class UDPCommand
    {
        public const string FORM_CLOSE = "form_close";
        public const string FORM_HIDE = "form_hide";
        public const string FORM_SHOW = "form_show";
        public const string OPEN_VRCLASSROOM = "open_vrclassroom";
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
       
    }
    
}
