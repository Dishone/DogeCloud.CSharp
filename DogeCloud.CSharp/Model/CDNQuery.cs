
using System;

namespace DogeCloud.Model
{
    public class CDNQuery
    {
        public string start_date { get; set; } = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
        public string end_date { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        public string granularity { get; set; } = "day";
        public string[] domains { get; set; }
    }
}
