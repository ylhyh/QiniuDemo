using Newtonsoft.Json.Linq;
using Qiniu.IO;
using Qiniu.RS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace QiniuDemo
{
    public class QiniuCallbackController : ApiController
    {
        // GET api/<controller>
        [HttpPost]
        [ActionName("upload")]
        public JObject Upload([FromBody]JObject value)
        {
            if (!IsQiniuCallback(Request.Headers.Authorization))
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            else
            {
                //HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                //HttpRequestBase request = context.Request;//定义传统request对象            
                //string name = request.Form["name"];

                /*
                {{
                  "name": "贝瓦儿歌—小兔子乖乖.mp4",
                  "key": "o_1a0ju5mn81s02d4dp4uvip1evc9.mp4",
                  "hash": "lsW45LizUGPP9O3GZtbJLSymlrlE",
                  "filesize": "17839736",
                  "processId": ""
                }}
                */

                /*
                默认用hash值作为文件名存储，除非在前端指定了unique_names=ture,会生成维一的文件名称，如果不指定unique-names=true，用hash值作为文件名存储时相同文件内容的文件不会重复存储。

                //通过get请求查询avinfo, 如果在UpToken中已经指定了返回avinfo，就不需要重新通过Get请求获取。但返回数据格式稍有不同.
                用以使用http://{domain}/{file hash}?avinfo 或空间中的file name查询音视频文件信息 http://{domain}/{file name}?avinfo
                refer to http://developer.qiniu.com/docs/v6/api/reference/fop/av/avinfo.html
                for example: http://7xlw23.com1.z0.glb.clouddn.com/o_1a0js9ea71uqvlsh12rli6b1rsn9.mp4?avinfo
                
                HttpClient client = new HttpClient();
                HttpResponseMessage responseResult = client.GetAsync("http://" + "7xlw23.com1.z0.glb.clouddn.com" +"/"+ value.GetValue("hash").ToString() + "?avinfo").Result;
                JObject result = responseResult.Content.ReadAsAsync<JObject>().Result;

                /*
                通过Get请求avinfor返回的信息：
                {{
                  "streams": [
                    {
                      "index": 0,
                      "codec_name": "h264",
                      "codec_long_name": "H.264 / AVC / MPEG-4 AVC / MPEG-4 part 10",
                      "profile": "Constrained Baseline",
                      "codec_type": "video",
                      "codec_time_base": "1/50",
                      "codec_tag_string": "avc1",
                      "codec_tag": "0x31637661",
                      "width": 720,
                      "height": 480,
                      "has_b_frames": 0,
                      "sample_aspect_ratio": "1:1",
                      "display_aspect_ratio": "3:2",
                      "pix_fmt": "yuv420p",
                      "level": 30,
                      "chroma_location": "left",
                      "is_avc": "1",
                      "nal_length_size": "4",
                      "r_frame_rate": "25/1",
                      "avg_frame_rate": "25/1",
                      "time_base": "1/25",
                      "start_pts": 0,
                      "start_time": "0.000000",
                      "duration_ts": 3406,
                      "duration": "136.240000",
                      "bit_rate": "920580",
                      "bits_per_raw_sample": "8",
                      "nb_frames": "3406",
                      "disposition": {
                        "default": 1,
                        "dub": 0,
                        "original": 0,
                        "comment": 0,
                        "lyrics": 0,
                        "karaoke": 0,
                        "forced": 0,
                        "hearing_impaired": 0,
                        "visual_impaired": 0,
                        "clean_effects": 0,
                        "attached_pic": 0
                      },
                      "tags": {
                        "creation_time": "1970-01-01 00:00:00",
                        "language": "und",
                        "handler_name": "\fVideoHandler"
                      }
                    },
                    {
                      "index": 1,
                      "codec_name": "aac",
                      "codec_long_name": "AAC (Advanced Audio Coding)",
                      "profile": "LC",
                      "codec_type": "audio",
                      "codec_time_base": "1/44100",
                      "codec_tag_string": "mp4a",
                      "codec_tag": "0x6134706d",
                      "sample_fmt": "fltp",
                      "sample_rate": "44100",
                      "channels": 2,
                      "channel_layout": "stereo",
                      "bits_per_sample": 0,
                      "r_frame_rate": "0/0",
                      "avg_frame_rate": "0/0",
                      "time_base": "1/44100",
                      "start_pts": 0,
                      "start_time": "0.000000",
                      "duration_ts": 5958656,
                      "duration": "135.116916",
                      "bit_rate": "123584",
                      "nb_frames": "5819",
                      "disposition": {
                        "default": 1,
                        "dub": 0,
                        "original": 0,
                        "comment": 0,
                        "lyrics": 0,
                        "karaoke": 0,
                        "forced": 0,
                        "hearing_impaired": 0,
                        "visual_impaired": 0,
                        "clean_effects": 0,
                        "attached_pic": 0
                      },
                      "tags": {
                        "creation_time": "1970-01-01 00:00:00",
                        "language": "und",
                        "handler_name": "\fSoundHandler"
                      }
                    }
                  ],
                  "format": {
                    "nb_streams": 2,
                    "nb_programs": 0,
                    "format_name": "mov,mp4,m4a,3gp,3g2,mj2",
                    "format_long_name": "QuickTime / MOV",
                    "start_time": "0.000000",
                    "duration": "136.240000",
                    "size": "17839736",
                    "bit_rate": "1047547",
                    "probe_score": 100,
                    "tags": {
                      "major_brand": "isom",
                      "minor_version": "512",
                      "compatible_brands": "mp41",
                      "creation_time": "1970-01-01 00:00:00"
                    }
                  }
                }}

                跟随UpToken一起返回的信息：
                {{
                  "name": "贝瓦儿歌—小兔子乖乖.mp4",
                  "key": "o_1a0ju5mn81s02d4dp4uvip1evc9.mp4",
                  "hash": "lsW45LizUGPP9O3GZtbJLSymlrlE",
                  "filesize": "17839736",
                  "avinfo": "{\"audio\":{\"Disposition\":{\"attached_pic\":0},\"avg_frame_rate\":\"0/0\",\"bit_rate\":\"123584\",\"channels\":2,\"codec_name\":\"aac\",\"codec_type\":\"audio\",\"duration\":\"135.116916\",\"index\":1,\"nb_frames\":\"5819\",\"r_frame_rate\":\"0/0\",\"sample_fmt\":\"fltp\",\"sample_rate\":\"44100\",\"start_time\":\"0.000000\",\"tags\":{\"creation_time\":\"1970-01-01 00:00:00\"}},\"format\":{\"bit_rate\":\"1047547\",\"duration\":\"136.240000\",\"format_long_name\":\"QuickTime / MOV\",\"format_name\":\"mov,mp4,m4a,3gp,3g2,mj2\",\"nb_streams\":2,\"size\":\"17839736\",\"start_time\":\"0.000000\",\"tags\":{\"creation_time\":\"1970-01-01 00:00:00\"}},\"video\":{\"Disposition\":{\"attached_pic\":0},\"avg_frame_rate\":\"25/1\",\"bit_rate\":\"920580\",\"codec_name\":\"h264\",\"codec_type\":\"video\",\"display_aspect_ratio\":\"3:2\",\"duration\":\"136.240000\",\"height\":480,\"index\":0,\"nb_frames\":\"3406\",\"pix_fmt\":\"yuv420p\",\"r_frame_rate\":\"25/1\",\"sample_aspect_ratio\":\"1:1\",\"start_time\":\"0.000000\",\"tags\":{\"creation_time\":\"1970-01-01 00:00:00\"},\"width\":720}}"
                }}
                */
                string videoWidth = ((JObject)((JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(((Newtonsoft.Json.Linq.JValue)(value.GetValue("avinfo"))).Value.ToString())).GetValue("video")).GetValue("width").ToString();
                string videoHeight = ((JObject)((JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(((Newtonsoft.Json.Linq.JValue)(value.GetValue("avinfo"))).Value.ToString())).GetValue("video")).GetValue("height").ToString();

                //获取文件信息成功，开始发送pfop请求进行数据处理
                // refer to: http://developer.qiniu.com/docs/v6/api/reference/fop/pfop/pfop.html

                string bucket = "ylhyh";
                string domain = "7xlw23.com1.z0.glb.clouddn.com";
                string fileKey = value.GetValue("key").ToString();

                //缩略图： http://7xlw23.com1.z0.glb.clouddn.com/o_1a0kjb5u9td94gb1ooortjtei9.mp4?vframe/png/offset/100/w/400/h/300

                /*
                //bucket=<urlEncodedBucket>&key=<urlEncodedKey>&fops=<urlEncodedFops>&notifyURL=<urlEncodedPersistentNotifyUrl>&force=<Force>&pipeline=<Pipeline Name>
                string strContent = "bucket=" + HttpUtility.UrlEncode(bucket) 
                    + "&key=" + HttpUtility.UrlEncode(fileKey) 
                    + "&fops=" + HttpUtility.UrlEncode(fops) 
                    + "&notifyURL=" + HttpUtility.UrlEncode("http://ylhyh.onmypc.net:90/QiniuDemo/api/QiniuCallback/Fop");

                //http://developer.qiniu.com/docs/v6/api/reference/security/access-token.html#access-token-algorithm
                string signingStr = "/pfop/\n" + strContent;
                
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(strContent, System.Text.Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("QBox", "");
                HttpResponseMessage responseResult = client.PostAsync("http://api.qiniu.com/pfop/", content).Result;
                JObject result = responseResult.Content.ReadAsAsync<JObject>().Result;
                */
                /*
                //Use the first frame as thumbnail.
                string thumbnail = "vframe/jpg/offset/7";

                string thumbKey = "wobo_" + Guid.NewGuid().ToString("N") + ".jpg";
                //string thumbencodedEntryURI = Qiniu.Util.Base64URLSafe.Encode(bucket + ":" + thumbKey);
                //string thumbsaveas = "|saveas/" + thumbencodedEntryURI;

                string baseUrl = GetPolicy.MakeBaseUrl(domain, fileKey);
                string private_url = GetPolicy.MakeRequest(baseUrl + "?" + thumbnail);// +thumbsaveas);

                HttpClient client = new HttpClient();
                Stream vframeResponse = client.GetStreamAsync(private_url).Result;
                string thumbFilepath = Path.GetTempFileName();
                FileStream fileStream = File.OpenWrite(thumbFilepath);
                byte[] buffer = new byte[4096];
                int count = vframeResponse.Read(buffer, 0, buffer.Length);

                while (count > 0)
                {
                    fileStream.Write(buffer, 0, count);
                    count = vframeResponse.Read(buffer, 0, buffer.Length);
                }

                vframeResponse.Close();
                fileStream.Close();

                var policy = new PutPolicy(bucket, 3600);
                string upToken = policy.Token();
                PutExtra extra = new PutExtra();
                IOClient ioClient = new IOClient();
                ioClient.PutFile(upToken, thumbKey, thumbFilepath, extra);
                File.Delete(thumbFilepath);
                */

                // 音视频切片： http://developer.qiniu.com/docs/v6/api/reference/fop/av/segtime.html
                string fops = "avthumb/m3u8/segtime/15/video_240k";

                string m3u8Key = "wobo_" + Guid.NewGuid().ToString("N") + ".m3u";
                string m3uencodedEntryURI = Qiniu.Util.Base64URLSafe.Encode(bucket + ":" + m3u8Key);
                string m3usaveas = "|saveas/" + m3uencodedEntryURI;

                fops += m3usaveas;
                //fops += ";" + thumbnail + thumbsaveas;

                Qiniu.RS.Pfop pfop = new Qiniu.RS.Pfop();
                string result = pfop.Do(new Qiniu.RS.EntryPath(bucket, fileKey), fops.Split(';'), new Uri("http://ylhyh.onmypc.net:90/QiniuDemo/api/QiniuCallback/Fop"), "");

                return value;
            }
        }

        private string AccessToken()
        {

            return string.Empty;
        }

        [HttpPost]
        [ActionName("fop")]
        public JObject Fop([FromBody]JObject value)
        {
            /*
            {{
  "id": "z0.560e99c37823de5a49c22393",
  "pipeline": "0.default",
  "code": 0,
  "desc": "The fop was completed successfully",
  "reqid": "NTAAAGzpokQgZgkU",
  "inputBucket": "ylhyh",
  "inputKey": "o_1a0kgaafl14nlcg2caatsdg4j9.mp4",
  "items": [
    {
      "cmd": "avthumb/m3u8/segtime/15/video_240k|saveas/eWxoeWg6ZjliNzliYWFkOTNkNDE0NWE4ZGRlMDVkYTBlOWU1ZjIubTN1OA==",
      "code": 0,
      "desc": "The fop was completed successfully",
      "hash": "FuYTrVLG2sQd3Tic6cRWB6y3l7y5",
      "key": "f9b79baad93d4145a8dde05da0e9e5f2.m3u8",
      "returnOld": 0
    }
  ]
}}

{{
  "id": "z0.560ea5687823de5a49c273a0",
  "pipeline": "0.default",
  "code": 3,
  "desc": "The fop is failed",
  "reqid": "bEIAAIBdVkXWaAkU",
  "inputBucket": "ylhyh",
  "inputKey": "o_1a0kjb5u9td94gb1ooortjtei9.mp4",
  "items": [
    {
      "cmd": "avthumb/m3u8/segtime/15/video_240k|vframe/jpg/offset/7",
      "code": 3,
      "desc": "The fop is failed",
      "error": "execute fop cmd failed: not a valid media",
      "returnOld": 0
    }
  ]
}}
            */



            return value;
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

                    HttpContextBase context=(HttpContextBase )Request.Properties["MS_HttpContext"];
                    string data = context.Request.Path + "\n" + HttpUtility.UrlDecode(context.Request.Form.ToString());
                    result = Util.HAMCSHA1(data, Qiniu.Conf.Config.SECRET_KEY).Equals(encodedData);
                }
            }

            return result;
        }
    }
}