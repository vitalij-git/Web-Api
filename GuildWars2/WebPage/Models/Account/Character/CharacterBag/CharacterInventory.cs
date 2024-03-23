namespace WebPage.Models.Account.Character.CharacterBag
{
    public class CharacterInventory
    {
        public int id { get; set; }
        public int? count { get; set; }
        public List<int>? upgrades { get; set; }
        public List<int>? upgradeSlotIndices { get; set; }
        public string binding { get; set; }
        public string boundTo { get; set; }
        public int? skin { get; set; }
    }
}
