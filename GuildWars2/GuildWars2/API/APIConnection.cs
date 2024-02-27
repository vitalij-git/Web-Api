using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GuildWars2.API
{
    public class APIConnection : IAPIConnection
    {
        private readonly string _guildWars2Uri = "https://api.guildwars2.com/";
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public APIConnection(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiKey = configuration.GetSection("GuildWars2API").Value;
        }

        public async Task<object> CallGuildWarsApi(string data)
        {
            var apiUri = _guildWars2Uri + data + "?access_token=" + _apiKey;
            var responseString = await CallApi(HttpMethod.Get, apiUri);
            return responseString;
        }

        private async Task<string> CallApi(HttpMethod httpMethod, string apiUri)
        {
            var request = new HttpRequestMessage(httpMethod, apiUri);
            using var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }
    }
}
