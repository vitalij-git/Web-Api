using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Orders.Models
{
    public class SubElement
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("element")]
        public int Element { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }
    }
}
