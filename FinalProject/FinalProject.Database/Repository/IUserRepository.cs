
using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Models.Dto.User;
using FinalProject.Database.Models.Dto.User;

namespace FinalProject.Database.Repository
{
    public interface IUserRepository
    {
        public Task CreateUser(User user);

        public Task UpdateUsername(UpdateUserNameDto updateUserNameDto);

        public Task UpdateUserPassword(UpdateUserPasswordDto updateUserPassword);

        public Task DeleteUser(DeleteUserDto deleteUserDto);

        public Task<IList<User>> GetUsers();

        public Task ChangeUserRole(ChangeUserRoleDto changeUserRoleDto);
    }
}