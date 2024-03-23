namespace WebPage.Models.Account.Bank
{
    public class BankItemInfo
    {
        public int id { get; set; }
        public int count { get; set; }
        public string binding { get; set; }
        public int? charges { get; set; }
        public int? skin { get; set; }
        public int[]? dyes { get; set; }
        public int[]? upgrades { get; set; }
        public int[]? upgrade_slot_indices { get; set; }
        public int[]? infusions { get; set; }
        public string? bound_to { get; set; }
        public object? stats { get; set; }
    }
}
