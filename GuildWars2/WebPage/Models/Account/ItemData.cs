using WebPage.Models.Account.Character.CharacterBag;

namespace WebPage.Models.Account
{
    public class ItemData
    {
        public string name { get; set; }
        public string? description { get; set; }
        public string? type { get; set; }
        public int? level { get; set; }
        public string? rarity { get; set; }
        public int? vendor_value { get; set; }
        public int? default_skin { get; set; }
        public List<string>? game_types { get; set; }
        public List<string>? flags { get; set; }
        public List<object>? restrictions { get; set; }
        public int id { get; set; }
        public string? chat_link { get; set; }
        public string? icon { get; set; }
        public Details details { get; set; }
    }

    public class Details
    {
        public string type { get; set; }
        public string weight_class { get; set; }
        public int defense { get; set; }
        public List<object> infusion_slots { get; set; }
        public double attribute_adjustment { get; set; }
        public InfixUpgrade infix_upgrade { get; set; }
        public int suffix_item_id { get; set; }
        public string secondary_suffix_item_id { get; set; }
    }

    public class InfixUpgrade
    {
        public int id { get; set; }
        public List<object> attributes { get; set; }
    }
}

