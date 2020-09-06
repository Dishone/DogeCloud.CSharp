using DogeCloud.Model;
using RestSharp;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DogeCloud.CSharp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var query = new CDNQuery();
            var key = new DogeCloudModel();
            key.access_key = "05e3988ad6c7dede";
            key.secret_key = "72fd815d799f6611ea88ecea810ca01c";
            var reques = new DogeRequest(key);
            Console.WriteLine(reques.CDNStats(query));
        }
    }
}
