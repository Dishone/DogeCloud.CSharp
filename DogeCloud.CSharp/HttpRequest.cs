using DogeCloud.Model;
using RestSharp;
using System;
using System.Security.Cryptography;
using System.Text;

namespace DogeCloud.CSharp
{
    /// <summary>
    /// Http请求类
    /// </summary>
    public class DogeRequest
    {
        public DogeRequest(DogeCloudKey doge) {
            _doge = doge;
        }
        public static DogeCloudKey _doge;
        public string Request(string ApiPath, string accessToken, string body = null)
        {
            
            RestClient client = new RestClient("https://api.dogecloud.com" + ApiPath);
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", accessToken);
            request.AddParameter("application/x-www-form-urlencoded; charset=UTF-8", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
        public string CDNStats(CDNQuery query) {
            string ApiPath = "/cdn/stat/traffic.json";
            var token = $"TOKEN {_doge.access_key}:"+CDNQueryCode(ApiPath, query);
            var body = CDNQueryBody(query);
            return Request(ApiPath, token, body);
        }
        public static string CDNQueryBody(CDNQuery query)
        {
            string body = $"start_date={query.start_date}&end_date={query.end_date}&granularity={query.granularity}";
            if (query.domains != null)
            {
                foreach (var item in query.domains)
                {
                    body += $"{item}";
                }
            }
            return body;
        }
        public static string CDNQueryCode(string apiPath,CDNQuery query)
        {
            string body = $"start_date={query.start_date}&end_date={query.end_date}&granularity={query.granularity}";
            if (query.domains != null)
            {
                body += "&";
                foreach (var item in query.domains)
                {
                    body += $"{item}%2";
                }
                body.Substring(0, body.Length - 2);
            }
            return HMACSHA1Text(merge(apiPath, body));
        }
        public static string merge(string path, string body = "")
        {
            return path + "\n" + body;
        }
        public static string HMACSHA1Text(string text)
        {
            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = System.Text.Encoding.UTF8.GetBytes(_doge.secret_key);

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
