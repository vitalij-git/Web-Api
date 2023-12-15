using FinalProject.Database.Models.Dto.Login;
using FinalProject.Database.Models.Dto;

namespace FinalProject.Database.Repository
{
    public interface ILoginRepository
    {
        public  Task<LoginResponse> Login(LoginRequestDto loginRequestDto);
    }
}