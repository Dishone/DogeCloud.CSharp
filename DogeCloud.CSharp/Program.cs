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
            var key = new DogeCloudKey();
            key.access_key = "You access_key";
            key.secret_key = "You secret_key";
            var reques = new DogeRequest(key);

            Console.WriteLine(reques.CDNStats(query));
        }
    }
}
