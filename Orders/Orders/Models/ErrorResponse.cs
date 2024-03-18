using System.Text.Json.Serialization;

namespace Orders.Models
{
    public class ErrorResponse
    {
        [JsonPropertyName("error")]
        public string ErrorMessage { get; set; }
    }
}
