namespace BackEnd.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public IList<Window> Windows { get; set; }
    }
}
