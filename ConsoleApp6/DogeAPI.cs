using System;
using System.Security.Cryptography;
using System.Text;
using RestSharp;

namespace DogeCloud.CSharp
{
    public class DogeCloud
    {

        public static string merge(string path, string body)
        {
            return path + "\n" + body;
        }
        public static string HMACSHA1Text(string text, string key)
        {
            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = System.Text.Encoding.UTF8.GetBytes(key);
            byte[] dataBuffer = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
            var enText = new StringBuilder();
            foreach (byte iByte in hashBytes)
            {
                enText.AppendFormat("{0:x2}", iByte);
            }
            return enText.ToString();
        }
    }
}
