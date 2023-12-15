using FinalProject.BusinessLogic.ErrorResponseModel;
using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Models.Dto.User;
using FinalProject.Database.Database;
using FinalProject.Database.Models;
using FinalProject.Database.Models.Dto.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly DbContextService _dbContext;

        public UserRepository(DbContextService dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task CreateUser(User user)
        {
            var checkUsername = await _dbContext.Users.SingleOrDefaultAsync(us => us.Username == user.Username);
            if (checkUsername != null)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "That username is already exist");
            }
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();    
        }

        public async Task DeleteUser(DeleteUserDto deleteUserDto)
        {
            var requestCheckRole = await _dbContext.Users.SingleOrDefaultAsync(r => r.Role == deleteUserDto.AdminRole && r.Id == deleteUserDto.AdminId);
            if (requestCheckRole == null) 
            {
                throw new Exception("The requested user was not found");
            }
            if (requestCheckRole.Role != Role.Admin)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "This account doesn't have a permission to change role");
            }
            var result = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == deleteUserDto.UserId);
            if (result == null)
            {
                throw new Exception("The requested user was not found");
            }
            _dbContext.Users.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<User>> GetUsers()
        {
           return await _dbContext.Users.ToListAsync();
        }

        public async Task UpdateUsername(UpdateUserNameDto updateUserNameDto)
        {
            var checkUsername = await _dbContext.Users.SingleOrDefaultAsync(us => us.Username == updateUserNameDto.NewUserName);
             if(checkUsername != null)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "That username is already exist");
            }
            var result = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == updateUserNameDto.UserId && u.Username == updateUserNameDto.OldUserName);
            if (result == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "The requested user was not found");
            }
            result.Username = updateUserNameDto.NewUserName;
            result.UpdatedAt = DateTime.Now;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserPassword(UpdateUserPasswordDto updateUserPasswordDto)
        {
            var result = await _dbContext.Users.SingleOrDefaultAsync(us => us.Id == updateUserPasswordDto.UserId);
            if (result == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "The requested user was not found");
            }
            var checkPassword = CheckPasswordHash(updateUserPasswordDto.OldPassword, result.Password, result.PasswordSalt);
            if(checkPassword != true)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The password is not matches");
            }
            CreatePasswordHash(updateUserPasswordDto.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
            result.Password = passwordHash;
            result.PasswordSalt = passwordSalt;
            result.UpdatedAt = DateTime.Now;
            await _dbContext.SaveChangesAsync();
        }

        private bool CheckPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA256(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA256();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public async Task ChangeUserRole(ChangeUserRoleDto changeUserRoleDto)
        {
            var requestCheckRole = await _dbContext.Users.SingleOrDefaultAsync(r => r.Role == changeUserRoleDto.AdminRole && r.Id == changeUserRoleDto.AdminId);
            if (requestCheckRole == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "The requested user was not found");
            }
            if (requestCheckRole.Role != Role.Admin )
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "This account doesn't have a permission to change role");
            }
            var requestUser = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == changeUserRoleDto.UserId);
            if (requestUser == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "The user you want to delete does not found");
            }
            requestUser.Role = changeUserRoleDto.UserRole;
            await _dbContext.SaveChangesAsync();
        }
    }
}
