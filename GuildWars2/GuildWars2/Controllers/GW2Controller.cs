using GuildWars2.API;
using Microsoft.AspNetCore.Mvc;

namespace GuildWars2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GW2Controller : Controller
    {
        private readonly IAPIConnection _connection;

        public GW2Controller(IAPIConnection connection)
        {
            _connection = connection;
        }

        [Route("Data")]
        [HttpGet]
        public async Task<object> GetData([FromQuery] string data)
        {
            var result = await _connection.CallGuildWarsApi(data);
            return result;
        }
    }
}
