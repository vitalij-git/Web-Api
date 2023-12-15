using FinalProject.Database.Models;

namespace FinalProject.Services
{
    public interface IJwtService
    {
        public string GetJwtToken(string username, Role role);
    }
}