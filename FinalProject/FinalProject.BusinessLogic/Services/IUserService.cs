using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Models.Dto.User;
using FinalProject.Database.Models.Dto.User;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.BusinessLogic.Services
{
    public interface IUserService
    {
        public Task CreateUser(CreateUserDto createUserDto);

        public Task UpdateUsername(UpdateUserNameDto updateUserNameDto);

        public Task UpdateUserPassword(UpdateUserPasswordDto updateUserPassword);

        public Task<IList<GetUsersDto>> GetUsers();

        public Task ChangeUserRole(ChangeUserRoleDto changeUserRoleDto);

        public Task DeleteUser(DeleteUserDto deleteUserDto);

    }
}