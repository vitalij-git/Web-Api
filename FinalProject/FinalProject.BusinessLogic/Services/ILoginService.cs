using FinalProject.Database.Models.Dto;
using FinalProject.Database.Models.Dto.Login;

namespace FinalProject.BusinessLogic.Services
{
    public interface ILoginService
    {
        public  Task<LoginResponse> Login(LoginRequestDto loginRequestDto);
    }
}