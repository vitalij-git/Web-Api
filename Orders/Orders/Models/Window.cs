using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Orders.Models
{
    public class Window
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("quantityOfWindows")]
        public int QuantityOfWindows { get; set; }

        [JsonPropertyName("totalSubElements")]
        public int TotalSubElements { get; set; }


    }
}
