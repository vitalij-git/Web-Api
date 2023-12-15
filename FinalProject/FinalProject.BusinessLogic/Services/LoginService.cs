using FinalProject.Database.Database;
using FinalProject.Database.Models.Dto;
using FinalProject.Database.Models.Dto.Login;
using FinalProject.Database.Repository;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BusinessLogic.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<LoginResponse> Login(LoginRequestDto loginRequestDto)
        {
            return await _loginRepository.Login(loginRequestDto);
        }
        
    }
}
