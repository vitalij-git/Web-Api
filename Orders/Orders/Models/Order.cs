using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Orders.Models
{

    public class Order
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("windows")]
        public IList<Window> Windows { get; set; }

    }


}
