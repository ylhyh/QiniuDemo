using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EncodeDecodeTest
{
    class Program
    {
        static string data = "name=PassportMask_PAL.wmv&key=o_1a18bt3qqfks3cl199v119r1l9tn.wmv&hash=FtDqfOGoCUV_H6FDWeXZ0jIExRoZ&filesize=29268&avinfo=%7b%22audio%22%3anull%2c%22format%22%3a%7b%22bit_rate%22%3a%2223230%22%2c%22duration%22%3a%2210.079000%22%2c%22format_long_name%22%3a%22ASF+(Advanced+%2f+Active+Streaming+Format)%22%2c%22format_name%22%3a%22asf%22%2c%22nb_streams%22%3a1%2c%22size%22%3a%2229268%22%2c%22start_time%22%3a%220.000000%22%2c%22tags%22%3a%7b%7d%7d%2c%22video%22%3a%7b%22Disposition%22%3a%7b%22attached_pic%22%3a0%7d%2c%22avg_frame_rate%22%3a%220%2f0%22%2c%22bit_rate%22%3a%228000000%22%2c%22codec_name%22%3a%22wmv3%22%2c%22codec_type%22%3a%22video%22%2c%22display_aspect_ratio%22%3a%2216%3a9%22%2c%22duration%22%3a%2210.079000%22%2c%22height%22%3a576%2c%22index%22%3a0%2c%22nb_frames%22%3a%22%22%2c%22pix_fmt%22%3a%22yuv420p%22%2c%22r_frame_rate%22%3a%2225%2f1%22%2c%22sample_aspect_ratio%22%3a%2264%3a45%22%2c%22start_time%22%3a%220.000000%22%2c%22tags%22%3a%7b%7d%2c%22width%22%3a720%7d%7d";

        static void Main(string[] args)
        {
            Regex charConvert = new Regex(@"\%(?<char>[a-z,A-Z])\d|\%\d(?<char>[a-z,A-Z])|\%(?<char>[a-z,A-Z][a-z,A-Z])");
            var matches=charConvert.Matches(data);

            string data2 = charConvert.Replace(data, delegate(Match match)
            {
                string v = match.Result("${char}");
                return match.Value.ToUpper();
            }).Replace("(", "%28").Replace(")", "%29").Replace("&", "\u0026");
        }
    }
}
