using System.Text.Json.Serialization;

namespace Orders.Models
{
    public class NewOrder
    {
        public string Name { get; set; }
        public string State { get; set; }
    }
}
