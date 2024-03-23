namespace WebPage.Services
{
    public class HttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetResponseMessageAsync(string data)
        {
            return  await _httpClient.GetAsync("https://localhost:7144/GW2/Data?data="+data);
            
        }
    }
}
