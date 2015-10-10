using Newtonsoft.Json.Linq;
using Qiniu.Conf;
using Qiniu.RS;
using Qiniu.Util;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;

namespace QiniuSample
{
    public class VideoController : ApiController
    {
        static readonly string accessKey = ConfigurationManager.AppSettings["QiniuAccessKey"];
        static readonly string secretKey = ConfigurationManager.AppSettings["QiniuSecretKey"];
        static readonly string bucket = ConfigurationManager.AppSettings["QiniuBucket"];
        static readonly string[] pipelines = ConfigurationManager.AppSettings["QiniuPipelinePool"].Split(';');
        static readonly string domain = ConfigurationManager.AppSettings["QiniuDomain"];

        public VideoController()
        {
            Config.ACCESS_KEY = accessKey;
            Config.SECRET_KEY = secretKey;
        }

        /// <summary>
        /// api/qiniu/uptoken
        /// </summary>
        /// <returns>{}</returns>
        [HttpGet]
        [ActionName("uptoken")]
        public HttpResponseMessage UpToken()
        {
            Debug.WriteLine("UpToken");
            
            PutPolicy put = new PutPolicy(bucket);
            put.CallBackUrl = "http://wobo.ylhyh.onmypc.net:810/QiniuSample/api/Video/Callback";

            //refer to http://developer.qiniu.com/docs/v6/api/overview/up/response/vars.html for available variables
            //refer to http://developer.qiniu.com/docs/v6/api/reference/fop/av/avinfo.html
            put.CallBackBody = "name=$(fname)&key=$(key)&hash=$(etag)&filesize=$(fsize)&avinfo=$(avinfo)";
 
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent("{\"uptoken\":\"" + put.Token() + "\"}", Encoding.UTF8, "application/json");

            return response;
        }

        /// <summary>
        /// api/qiniu/callback
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("callback")]
        public HttpResponseMessage Callback([FromBody]JObject postData)
        {
#if DEBUG
            Debug.WriteLine("Callback");
#endif

            #region 数据返回格式
            /*
            {
              "name": "贝瓦儿歌—小兔子乖乖.mp4",
              "key": "o_1a11dud60vq11dmo1guh1gk8glt9.mp4",
              "hash": "lsW45LizUGPP9O3GZtbJLSymlrlE",
              "filesize": "17839736",
              "avinfo": "{\"audio\":{\"Disposition\":{\"attached_pic\":0},\"avg_frame_rate\":\"0/0\",\"bit_rate\":\"123584\",\"channels\":2,\"codec_name\":\"aac\",\"codec_type\":\"audio\",\"duration\":\"135.116916\",\"index\":1,\"nb_frames\":\"5819\",\"r_frame_rate\":\"0/0\",\"sample_fmt\":\"fltp\",\"sample_rate\":\"44100\",\"start_time\":\"0.000000\",\"tags\":{\"creation_time\":\"1970-01-01 00:00:00\"}},\"format\":{\"bit_rate\":\"1047547\",\"duration\":\"136.240000\",\"format_long_name\":\"QuickTime / MOV\",\"format_name\":\"mov,mp4,m4a,3gp,3g2,mj2\",\"nb_streams\":2,\"size\":\"17839736\",\"start_time\":\"0.000000\",\"tags\":{\"creation_time\":\"1970-01-01 00:00:00\"}},\"video\":{\"Disposition\":{\"attached_pic\":0},\"avg_frame_rate\":\"25/1\",\"bit_rate\":\"920580\",\"codec_name\":\"h264\",\"codec_type\":\"video\",\"display_aspect_ratio\":\"3:2\",\"duration\":\"136.240000\",\"height\":480,\"index\":0,\"nb_frames\":\"3406\",\"pix_fmt\":\"yuv420p\",\"r_frame_rate\":\"25/1\",\"sample_aspect_ratio\":\"1:1\",\"start_time\":\"0.000000\",\"tags\":{\"creation_time\":\"1970-01-01 00:00:00\"},\"width\":720}}"
            }
            */
            #endregion

            if (!IsQiniuCallback(Request.Headers.Authorization))
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            else
            {
                //得到视频尺寸及其它信息
                string fileKey = postData.GetValue("key").ToString();
                string videoWidth = ((JObject)((JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(((Newtonsoft.Json.Linq.JValue)(postData.GetValue("avinfo"))).Value.ToString())).GetValue("video")).GetValue("width").ToString();
                string videoHeight = ((JObject)((JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(((Newtonsoft.Json.Linq.JValue)(postData.GetValue("avinfo"))).Value.ToString())).GetValue("video")).GetValue("height").ToString();

                //生成缩略图
                // refer to http://developer.qiniu.com/docs/v6/api/reference/fop/av/vframe.html
                // refer to http://developer.qiniu.com/docs/v6/api/reference/fop/saveas.html
                string thumbnail = "vframe/jpg/offset/7";

                string thumbKey = "thumbnail_" + Guid.NewGuid().ToString("N") + ".jpg";
                string thumbencodedEntryURI = Qiniu.Util.Base64URLSafe.Encode(bucket + ":" + thumbKey);
                string thumbsaveas = "|saveas/" + thumbencodedEntryURI;

                string fops = thumbnail + thumbsaveas;
                Pfop pfop = new Pfop();
                string persistentId_thumb = pfop.Do(new EntryPath(bucket, fileKey), new string[] { fops }, new Uri("http://wobo.ylhyh.onmypc.net:810/QiniuSample/api/Video/Notify"), GetPipeline());
#if DEBUG
                Debug.WriteLine(persistentId_thumb);
#endif

                //音视频切片： http://developer.qiniu.com/docs/v6/api/reference/fop/av/segtime.html
                fops = "avthumb/m3u8/segtime/15/video_240k";

                string m3u8Key = "m3u8_" + Guid.NewGuid().ToString("N") + ".m3u";
                string m3uencodedEntryURI = Qiniu.Util.Base64URLSafe.Encode(bucket + ":" + m3u8Key);
                string m3usaveas = "|saveas/" + m3uencodedEntryURI;

                fops += m3usaveas;
                pfop = new Pfop();
                string persistentId_m3u8 = pfop.Do(new EntryPath(bucket, fileKey), new string[] { fops }, new Uri("http://wobo.ylhyh.onmypc.net:810/QiniuSample/api/Video/Notify"), GetPipeline());

#if DEBUG
                Debug.WriteLine(persistentId_m3u8);
#endif
                //ToDo 创建视频记录, 并把生成缩略图片切片的File Key和Persistent Id存储起来，根据Persistent Id可以查询每个处理的状态
                //thumbKey, persistentId_thumb, m3u8Key, persistentId_m3u8
                int videoId = 3;

                string returnJson = "{\"videoId\":\"" + videoId + "\"}";

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(returnJson, Encoding.UTF8, "application/json");

                return response;
            }
        }

        [HttpPost]
        [ActionName("notify")]
        public HttpResponseMessage Notify([FromBody]JObject postData)
        {
#if DEBUG
            Debug.WriteLine("Notify");
#endif

            #region 返回数据格式
            /*
             缩略图：
             {
              "id": "z0.561537a77823de5a49f9103e",
              "pipeline": "1380510864.pipeline1",
              "code": 0,
              "desc": "The fop was completed successfully",
              "reqid": "bEIAAEDuJt-D8AoU",
              "inputBucket": "ylhyh",
              "inputKey": "o_1a11e1ko71tlqcuo1o8ugsl1fkv.mp4",
              "items": [
                {
                  "cmd": "vframe/jpg/offset/7|saveas/eWxoeWg6dGh1bWJuYWlsXzVkOWRlNDhhYTJmMjQ4NDU5ZTZhZTk4Y2EzZDQzZTcwLmpwZw==",
                  "code": 0,
                  "desc": "The fop was completed successfully",
                  "hash": "Fl25WhZR12raUNBI1fkGNBykyBdW",
                  "key": "thumbnail_5d9de48aa2f248459e6ae98ca3d43e70.jpg",
                  "returnOld": 0
                }
              ]
            }
            
            切片：
            {
              "id": "z0.561537a77823de5a49f91041",
              "pipeline": "1380510864.pipeline2",
              "code": 0,
              "desc": "The fop was completed successfully",
              "reqid": "bEIAACgzDd-D8AoU",
              "inputBucket": "ylhyh",
              "inputKey": "o_1a11e1ko71tlqcuo1o8ugsl1fkv.mp4",
              "items": [
                {
                  "cmd": "avthumb/m3u8/segtime/15/video_240k|saveas/eWxoeWg6bTN1OF9iNTdhOTgxMDY1MWM0NmYxOWQ4OWJiZjkyZTcwMzM0Ni5tM3U=",
                  "code": 0,
                  "desc": "The fop was completed successfully",
                  "hash": "FuYTrVLG2sQd3Tic6cRWB6y3l7y5",
                  "key": "m3u8_b57a9810651c46f19d89bbf92e703346.m3u",
                  "returnOld": 0
                }
              ]
            }
            */
            #endregion

            //根据返回的persistentId和文件key, 更新视频记录的状态
                
            //如果接收到缩略图生成成功的通知，把缩略图的文件Key存储到视频表对应的字段

            //如果接收到切片生成成功的通知，把m3u8的文件Key存储到视频到对应的字段

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        [HttpGet]
        [ActionName("thumbnail")]
        public HttpResponseMessage Thumbnail(int videoId)
        {
            //refer to: http://developer.qiniu.com/docs/v6/sdk/csharp-sdk.html#private-download

            //根据Video Id获取到视频缩略图对应的文件Key
            string fileKey = "thumbnail_8b6bc270fd014260942caa1c5eacc234.jpg";
            return GetDownloadUrl(fileKey);
        }

        [HttpGet]
        [ActionName("playurl")]
        public HttpResponseMessage PlayUrl(int videoId)
        {
            //refer to: http://developer.qiniu.com/docs/v6/sdk/csharp-sdk.html#private-download

            //根据Video Id获取到视频缩略图对应的m3u8文件Key
            string fileKey = ".m3u8";

            //使用pm3u8指令为每个ts文件生成download token.
            //refer to: http://developer.qiniu.com/docs/v6/api/reference/fop/av/pm3u8.html
            fileKey += "?pm3u8/0";
            return GetDownloadUrl(fileKey);
        }

        private HttpResponseMessage GetDownloadUrl(string fileKey)
        {
            string baseUrl = GetPolicy.MakeBaseUrl(domain, fileKey);
            string privateUrl = GetPolicy.MakeRequest(baseUrl);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(privateUrl, Encoding.UTF8, "text/plain");

            return response;
        }

        /// <summary>
        /// Pick a random pipeline.
        /// </summary>
        /// <returns></returns>
        private string GetPipeline()
        {
            string result = null;

            if (pipelines != null)
            {
                Random random = new Random();
                result = pipelines[random.Next(0, pipelines.Length - 1)];
            }

            return result;
        }

        private bool IsQiniuCallback(AuthenticationHeaderValue auth)
        {
            bool result = false;

            if (auth != null
                && auth.Scheme != null
                && auth.Parameter != null
                && auth.Scheme == "QBox")
            {
                string[] parameters = auth.Parameter.Split(':');

                if (parameters.Length == 2)
                {
                    string encodedData = parameters[1];

                    HttpRequest request = HttpContext.Current.Request;
                    Regex charConvert = new Regex(@"\%[a-z,A-Z]\d|\%\d[a-z,A-Z]|\%[a-z,A-Z][a-z,A-Z]");
                    string requestBody = charConvert.Replace(request.Form.ToString(), delegate(Match match)
                    {
                        return match.Value.ToUpper();
                    }).Replace("(", "%28").Replace(")", "%29").Replace("&", "\u0026");

                    string data = request.Url.PathAndQuery + "\n" + requestBody;
                    result = accessKey.Equals(parameters[0]) && QiniuHamcSha1(secretKey, data).Equals(encodedData);
                }
            }

            return result;
        }

        private string QiniuHamcSha1(string key, string data)
        {
            return Base64URLSafe.Encode(HamcSha1(key, data));
        }

        private byte[] HamcSha1(string key, string data)
        {
            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = Encoding.UTF8.GetBytes(key);
            byte[] dataBuffer = Encoding.UTF8.GetBytes(data);
            return hmacsha1.ComputeHash(dataBuffer);
        }
    }
}