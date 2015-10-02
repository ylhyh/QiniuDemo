using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Qiniu.Conf;
using Qiniu.RS;
using System.Text;

namespace QiniuDemo
{
    public class VideoPlayController : ApiController
    {
        [HttpGet]
        [ActionName("download")]
        public HttpResponseMessage Download()
        {
            return Download(1);
        }

        // GET api/<controller>
        [HttpGet]
        [ActionName("download")]
        public HttpResponseMessage Download([FromUri]int videoId)
        {
            Config.ACCESS_KEY = "cCQ2WJbrXVY1yRHDHBVXfKLAoU5jVa72-Q-aEY39";
            Config.SECRET_KEY = "";
            //ToDo 根据videoId找到File Key

            //refer to: http://developer.qiniu.com/docs/v6/sdk/csharp-sdk.html#private-download
            string baseUrl = GetPolicy.MakeBaseUrl("7xlw23.com1.z0.glb.clouddn.com", "o_1a0js9ea71uqvlsh12rli6b1rsn9.mp4");
            string private_url = GetPolicy.MakeRequest(baseUrl);

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(private_url, Encoding.UTF8, "text/plain")
            };

            return result;
        }
    }
}