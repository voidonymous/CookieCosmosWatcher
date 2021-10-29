using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCosmosWatcher.JsonData
{
    public class RootCookie
    {
        public string result { get; set; }
        public DateTime called { get; set; }
        public string usage { get; set; }
        public List<Cookie> cookies { get; set; }
    }

    public class Cookie
    {
        public string name { get; set; }
        public string type { get; set; }
        public int price { get; set; }
        public int max_price { get; set; }
        public int highest_price { get; set; }
        public int lowest_price { get; set; }
    }
}
