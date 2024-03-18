using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Window
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityOfWindows { get; set; }
        public IList<SubElement> SubElements { get; set; } = new List<SubElement>();

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
