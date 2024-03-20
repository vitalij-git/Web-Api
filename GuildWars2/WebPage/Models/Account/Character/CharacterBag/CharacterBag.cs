namespace WebPage.Models.Account.Character.CharacterBag
{
    public class CharacterBag
    {
        public int id { get; set; }
        public int size { get; set; }
        public List<CharacterInventory> inventory { get; set; }
    }
}
