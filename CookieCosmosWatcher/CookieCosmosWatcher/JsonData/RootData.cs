using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCosmosWatcher.JsonData
{
    class RootData
    {
        public string result { get; set; }
        public DateTime called { get; set; }
        public string usage { get; set; }
        public string response { get; set; }
        public List<Player> player { get; set; }
        public List<EconomyCookie> cookies { get; set; }
        public List<EconomyItem> items { get; set; }
        public List<EconomyRelic> relics { get; set; }
    }

    public class Player
    {
        public string guild_name { get; set; }
        public string username { get; set; }
        public DateTime join_date { get; set; }
        public DateTime lastest_chat { get; set; }
        public int lottery_tickets { get; set; }
        public DateTime daily_time { get; set; }
        public int daily_streak { get; set; }
        public int in_cookie_jar { get; set; }
        public int shop_level { get; set; }
        public int prestige { get; set; }
        public List<PlayerCookie> cookies { get; set; }
        public List<PlayerItem> items { get; set; }
        public List<PlayerRelic> relics { get; set; }
        public List<PlayerTitle> titles { get; set; }
        public List<PlayerAchievement> achievements { get; set; }
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

    public class PlayerRelic
    {
        public string item_type { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string relic_rate { get; set; }
        public int relic_rate_type { get; set; }
        public int tier { get; set; }
    }

    public class PlayerTitle
    {
        public string item_type { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class PlayerAchievement
    {
        public string item_type { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class EconomyCookie
    {
        public string name { get; set; }
        public string type { get; set; }
        public int price { get; set; }
        public int max_price { get; set; }
        public int highest_price { get; set; }
        public int lowest_price { get; set; }
    }

    public class EconomyItem
    {
        public string item_type { get; set; }
        public string rarity { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string cookie_type { get; set; }
        public int buy_price { get; set; }
        public int sell_price { get; set; }
    }

    public class EconomyRelic
    {
        public string name { get; set; }
        public string description { get; set; }
        public List<EconomyRelicTier> tiers { get; set; }
    }


    public class EconomyRelicTier
    {
        public int tier { get; set; }
        public string relic_rate { get; set; }
        public int relic_rate_type { get; set; }
        public List<EconomyRelicIngredient> ingredients { get; set; }
    }

    public class EconomyRelicIngredient
    { 
        public string item { get; set; }
        public int amount { get; set; }
    }
}
