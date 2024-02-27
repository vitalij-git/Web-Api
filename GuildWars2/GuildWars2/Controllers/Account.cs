using GuildWars2.API;
using Microsoft.AspNetCore.Mvc;

namespace GuildWars2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Account : Controller
    {
        
        private readonly IAPIConnection _connection;

        public Account(IAPIConnection connection)
        {
            _connection = connection;
        }

        [Route("Wallet")]
        [HttpGet]
        public async Task<object> GetWallet() 
        {
            string data = "v2/account/wallet";
            var result = await _connection.CallGuildWarsApi(data);
            return result;
        }

        [Route("Characters")]
        [HttpGet]
        public async Task<object> GetCharacters()
        {
            string data = "v2/characters";
            var result = await _connection.CallGuildWarsApi(data);
            return result;
        }

        [Route("Character")]
        [HttpGet]
        public async Task<object> GetCharacter(string name)
        {
            string data = "v2/characters/" + name;
            var result = await _connection.CallGuildWarsApi(data);
            return result;
        }
    }
}
