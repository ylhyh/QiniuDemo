using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qiniu.RS;

namespace QiniuFileTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //string accessKey = "HCXrxqnaoMmMDoSCkGe0gUQyTKhyefUZZRbYcjjE";
            //string secretKey = "zl_9IksA_xeKyFdsQPjkSQLe-aGPNeL1jy2aTOiy";
            //Qiniu.Conf.Config.ACCESS_KEY = accessKey;
            //Qiniu.Conf.Config.SECRET_KEY = secretKey;
            //string privateBucket = "wobo-video";
            //string videoFops = "avthumb/m3u8/segtime/15/video_240k";

            //string m3u8Key = "m3u8_7e2061dbf1524d34abca5c73675918d7.m3u";
            //string m3uencodedEntryURI = Qiniu.Util.Base64URLSafe.Encode(privateBucket + ":" + m3u8Key);
            //string m3usaveas = "|saveas/" + m3uencodedEntryURI;

            //videoFops += m3usaveas;


            //Qiniu.RS.Pfop pfop=new Pfop();
            //string persistentID = pfop.Do(new EntryPath(privateBucket, "video_o_1a4ep1eootftno71nrn1rtjt6hc.mkv"),
            //    new string[] { videoFops }, new Uri("http://api.5bvv.com/api/QiniuUpload/Notify"), "pipeline3");
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmFileMove());
        }
    }
}
