namespace WebPage.Models.Account.Character.CharacterBag
{
    public class CharacterInventory
    {
        public int id { get; set; }
        public int count { get; set; }
        public string binding { get; set; }
        public List<int> upgrades { get; set; }
        public List<int> upgrade_slot_indices { get; set; }
    }
}
