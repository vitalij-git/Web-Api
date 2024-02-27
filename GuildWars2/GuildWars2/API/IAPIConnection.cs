using System.Runtime.InteropServices.ObjectiveC;

namespace GuildWars2.API
{
    public interface IAPIConnection
    {
        public Task<object> CallGuildWarsApi(string data);
    }
}