using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Qiniu.Conf;
using Qiniu.RS;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QiniuDemo
{
    public class QiniuTokenController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [ActionName("upload")]
        public QiniuToken UploadToken()
        {
            Config.ACCESS_KEY = "cCQ2WJbrXVY1yRHDHBVXfKLAoU5jVa72-Q-aEY39";
            Config.SECRET_KEY = "W8ELTSoeo540eBLm4EameoiAaxIxSlCgyUXvvhUa";
            string bucket = "ylhyh";
            PutPolicy put = new PutPolicy(bucket);
            put.CallBackUrl = "http://ylhyh.onmypc.net:90/QiniuDemo/api/QiniuCallback/Upload";

            //refer to http://developer.qiniu.com/docs/v6/api/overview/up/response/vars.html for availables
            //put.CallBackBody = "name=$(fname)&hash=$(etag)&filesize=$(fsize)&processId=$(persistentId)";
            put.CallBackBody = "name=$(fname)&key=$(key)&hash=$(etag)&filesize=$(fsize)&avinfo=$(avinfo)";

            //refer to http://api.qiniu.com/status/get/prefop?id=<persistentId> for status inquery
            //put.PersistentNotifyUrl = "http://ylhyh.onmypc.net:90/QiniuDemo/api/QiniuCallback/Fop";

            // refer to http://developer.qiniu.com/docs/v6/api/reference/fop/av/segtime.html
            // refer to http://developer.qiniu.com/docs/v6/api/reference/fop/av/vframe.html
            // refer to http://developer.qiniu.com/docs/v6/api/reference/fop/saveas.html
            //String encodedEntryURI = Qiniu.Util.Base64URLSafe.Encode("ylhyh:asdfasfdasdfasdfasdf_hd.m3u8");
            //string URL = "|saveas/" + encodedEntryURI;
            /*
            string thumbnail = "vframe/jpg/offset/7";

            string thumbKey = "wobo_" + Guid.NewGuid().ToString("N") + ".jpg";
            string thumbencodedEntryURI = Qiniu.Util.Base64URLSafe.Encode(bucket + ":" + thumbKey);
            string thumbsaveas = "|saveas/" + thumbencodedEntryURI;


            //put.PersistentOps = "avthumb/m3u8/segtime/15/video_240k|vframe/jpg/offset/1";// + URL;
            put.PersistentOps = thumbnail + thumbsaveas;
            //put.PersistentPipeline = "";
            */
            return new QiniuToken() { UpToken = put.Token() };
        }

        private long Deadline()
        {
            return (DateTime.Now.AddDays(1).ToUniversalTime() - DateTime.Parse("1970-1-1").ToUniversalTime()).Ticks / 10000000;
        }
    }

    public class QiniuToken
    {
        [JsonProperty("uptoken")]
        public string UpToken
        {
            get;
            set;
        }
    }
}