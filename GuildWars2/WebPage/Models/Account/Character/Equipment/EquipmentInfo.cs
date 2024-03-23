namespace WebPage.Models.Account.Character.Equipment
{
    public class EquipmentInfo
    {
        public int id { get; set; }
        public string? slot { get; set; }
        public List<int>? upgrades { get; set; }
        public string? binding { get; set; }
        public string? bound_to { get; set; }
        public int? skin { get; set; }
        public List<int>? dyes { get; set; }
        public EquipmentStats? stats { get; set; }
    }
}
