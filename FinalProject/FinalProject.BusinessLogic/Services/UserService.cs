using FinalProject.BusinessLogic.ErrorResponseModel;
using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Models.Dto.User;
using FinalProject.Database.Models;
using FinalProject.Database.Models.Dto.User;
using FinalProject.Database.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinalProject.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(CreateUserDto createUserDto)
        {
            if (createUserDto == null || string.IsNullOrEmpty(createUserDto.Username) || string.IsNullOrEmpty(createUserDto.Password))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The request contains an empty or null value");
            }
            if (!createUserDto.Password.Any(char.IsUpper) || createUserDto.Password.Length < 8 || !createUserDto.Password.Any(char.IsDigit))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, " The password is too weak. It must be at least 8 characters long and contain at least one uppercase letter and one number.");      
            }
            CreatePasswordHash(createUserDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User() 
            { 
                Username = createUserDto.Username,
                Password = passwordHash,
                PasswordSalt = passwordSalt,
                Role = Role.User,
                CreatedAt = DateTime.Now,

            };
            await _userRepository.CreateUser(user);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA256();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public async Task<IList<GetUsersDto>> GetUsers()
        {
           var users = await _userRepository.GetUsers();
           var usersDto = new List<GetUsersDto>();
            foreach (var user in users) 
            {
                usersDto.Add(new GetUsersDto() { Username = user.Username, });
            }
            return usersDto;
        }

        public async Task UpdateUsername(UpdateUserNameDto updateUserNameDto)
        {
            if(updateUserNameDto.UserId == Guid.Empty || string.IsNullOrEmpty(updateUserNameDto.NewUserName) || string.IsNullOrEmpty(updateUserNameDto.OldUserName))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The request contains an empty or null value");
            }
            await _userRepository.UpdateUsername(updateUserNameDto);
        }

        public async Task UpdateUserPassword(UpdateUserPasswordDto updateUserPassword)
        {
            if(updateUserPassword.UserId == Guid.Empty || string.IsNullOrEmpty(updateUserPassword.NewPassword) || string.IsNullOrEmpty(updateUserPassword.OldPassword))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The request contains an empty or null value");
            }
            if (!updateUserPassword.NewPassword.Any(char.IsUpper) || updateUserPassword.NewPassword.Length < 8 || !updateUserPassword.NewPassword.Any(char.IsDigit))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, " The password is too weak. It must be at least 8 characters long and contain at least one uppercase letter and one number.");
            }
            await _userRepository.UpdateUserPassword(updateUserPassword);
        }

        public async Task ChangeUserRole(ChangeUserRoleDto changeUserRoleDto)
        {
            if(string.IsNullOrEmpty(changeUserRoleDto.AdminRole.ToString()) || string.IsNullOrEmpty(changeUserRoleDto.UserRole.ToString()) || changeUserRoleDto.AdminId == Guid.Empty || changeUserRoleDto.UserId == Guid.Empty) 
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The request contains an empty or null value");
            }
            await _userRepository.ChangeUserRole(changeUserRoleDto);
        }

        public async Task DeleteUser(DeleteUserDto deleteUserDto)
        {
        if(deleteUserDto.UserId == Guid.Empty || deleteUserDto.AdminId == Guid.Empty) 
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The request contains an empty or null value");
            }
           await _userRepository.DeleteUser(deleteUserDto);
        }
    }
}
