using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCosmosWatcher.JsonData
{
    public class RootPlayer
    {
        public string result { get; set; }
        public DateTime called { get; set; }
        public string usage { get; set; }
        public string response { get; set; }
        public List<Server> servers { get; set; }
    }

    public class Server
    {
        public string guild_name { get; set; }
        public string username { get; set; }
        public DateTime join_date { get; set; }
        public DateTime lastest_chat { get; set; }
        public string lottery_tickets { get; set; }
        public DateTime daily_time { get; set; }
        public string daily_streak { get; set; }
        public string in_cookie_jar { get; set; }
        public string shop_level { get; set; }
        public int prestige { get; set; }
        public List<PlayerCookie> cookies { get; set; }
        public List<PlayerItem> items { get; set; }
    }

    public class PlayerCookie
    {
        public string name { get; set; }
        public int amount { get; set; }
        public int price { get; set; }
    }

    public class PlayerItem
    {
        public string item_type { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
    }
}
