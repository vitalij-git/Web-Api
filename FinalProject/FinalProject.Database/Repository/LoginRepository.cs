using FinalProject.Database.Models.Dto.Login;
using FinalProject.Database.Models.Dto;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Database.Database;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace FinalProject.Database.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DbContextService _dbContextServices;

        public LoginRepository(DbContextService dbContextServices)
        {
            _dbContextServices = dbContextServices;
        }

        public async Task<LoginResponse> Login(LoginRequestDto loginRequestDto)
        {
            var account = await _dbContextServices.Users.SingleOrDefaultAsync(u => u.Username == loginRequestDto.Username);
            if (account == null)
            {
                return new LoginResponse(false);
            }
            var isSuccess = VerifyPasswordHash(loginRequestDto.Password, account.Password, account.PasswordSalt);
            return new LoginResponse(isSuccess, account.Role, account.Id);
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA256(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
