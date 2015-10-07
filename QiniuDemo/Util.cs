using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace QiniuDemo
{
    public static class Util
    {
        public static string HAMCSHA1(string content, string key)
        {
            //HMACSHA1 hmacsha1 = new HMACSHA1();
            //hmacsha1.Key = Encoding.UTF8.GetBytes(key);
            //byte[] dataBuffer = Encoding.UTF8.GetBytes(content);
            //byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
            //return Convert.ToBase64String(hashBytes);



            byte[] byteData = Encoding.UTF8.GetBytes(content);
            byte[] byteKey = Encoding.UTF8.GetBytes(key);

            HMACSHA1 hmac = new HMACSHA1(byteKey);
            CryptoStream cs = new CryptoStream(Stream.Null, hmac, CryptoStreamMode.Write);
            cs.Write(byteData, 0, byteData.Length);
            cs.Close();
            return Convert.ToBase64String(hmac.Hash);

        }
    }
}