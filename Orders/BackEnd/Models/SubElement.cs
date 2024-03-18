using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class SubElement
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Element { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        [ForeignKey("WindowId")]
        public Window Window { get; set; }
        public int WindowId { get; set; }
    }
}
