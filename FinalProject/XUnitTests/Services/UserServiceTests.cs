using FinalProject.BusinessLogic.ErrorResponseModel;
using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Models.Dto.User;
using FinalProject.BusinessLogic.Services;
using FinalProject.Database.Models.Dto.User;
using FinalProject.Database.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTests.Services
{
    public class UserServiceTests
    {

        [Fact]
        public async Task CreateUser_ValidDto_CallsRepositoryMethod()
        {
            //Arrange
            var userDto = new CreateUserDto()
            {
                Username = "UsernameTest",
                Password = "Strong123"
            };
            var user = new User();
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(rep => rep.CreateUser(user));

            var service = new UserService(userRepositoryMock.Object);

            //Act
            await service.CreateUser(userDto);

            //Assert
            userRepositoryMock.Verify(rep => rep.CreateUser(It.IsAny<User>()), Times.Once);
        }

        [Theory]
        [InlineData(null, "Strong123")]
        [InlineData("fakeUsername", null)]
        [InlineData("fakeUsername", "strong123")]
        [InlineData("fakeUsername", "Strongssss")]
        [InlineData("fakeUsername", "Str24")]
        public async Task CreateUSer_InvalidDto_ThrowsHttpStatusException(string username, string password)
        {
            //Arrange
            var userDto = new CreateUserDto()
            {
                Username = username,
                Password = password
            };
            var user = new User();
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(rep => rep.CreateUser(user));

            var service = new UserService(userRepositoryMock.Object);

            //Act && Assert
            await Assert.ThrowsAsync<HttpStatusException>(() => service.CreateUser(userDto));
        }

        [Fact]
        public async Task UpdateUser_Username_ValidDto_CallsRepositoryMethod()
        {
            //Arrange
            var userDto = new UpdateUserNameDto()
            {
                UserId = Guid.NewGuid(),
                NewUserName = "newUsername",
                OldUserName = "oldUserName"
            };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(rep => rep.UpdateUsername(userDto));

            var service = new UserService(userRepositoryMock.Object);

            //Act
            await service.UpdateUsername(userDto);

            //Assert
            userRepositoryMock.Verify(rep => rep.UpdateUsername(It.IsAny<UpdateUserNameDto>()), Times.Once);
        }

        [Theory]
        [InlineData(null, "oldUsername", "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("newUsername", null, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("newUsername", "oldUsername", null)]
        public async Task UpdateUser_Username_InvalidDto_ThrowsHttpStatusException(string newUserName, string oldUserName, Guid userId)
        {
            //Arrange
            var userDto = new UpdateUserNameDto()
            {
                UserId = userId,
                NewUserName = newUserName,
                OldUserName = oldUserName
            };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(rep => rep.UpdateUsername(userDto));

            var service = new UserService(userRepositoryMock.Object);

            //Act & Arrange
            await Assert.ThrowsAsync<HttpStatusException>(() => service.UpdateUsername(userDto));
        }

        [Fact]
        public async Task UpdateUser_Password_ValidDto_CallsRepositoryMethod()
        {
            //Arrange
            var userDto = new UpdateUserPasswordDto()
            {
                UserId = Guid.NewGuid(),
                NewPassword = "Strong123",
                OldPassword = "Strong12334"
            };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(rep => rep.UpdateUserPassword(userDto));

            var service = new UserService(userRepositoryMock.Object);

            //Act
            await service.UpdateUserPassword(userDto);

            //Assert
            userRepositoryMock.Verify(rep => rep.UpdateUserPassword(It.IsAny<UpdateUserPasswordDto>()), Times.Once);
        }

        [Theory]
        [InlineData(null, "Strong123", "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("newPassword", null, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("newPassword", "Strong123", null)]
        [InlineData("newPassword", "Short1", "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("newPassword", "Strongssss", "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("newPassword", "strongssss222", "5356E631-836E-4431-A412-0544889A0D99")]
        public async Task UpdateUser_Password_InvalidDto_ThrowsHttpStatusException(string newPassword, string oldPassword, Guid userId)
        {
            //Arrange
            var userDto = new UpdateUserPasswordDto()
            {
                UserId = userId,
                NewPassword = newPassword,
                OldPassword = oldPassword
            };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(rep => rep.UpdateUserPassword(userDto));

            var service = new UserService(userRepositoryMock.Object);

            //Act & Arrange
            await Assert.ThrowsAsync<HttpStatusException>(() => service.UpdateUserPassword(userDto));
        }

        [Fact]
        public async Task ChangeUser_Role_ValidDto_CallsRepositoryMethod()
        {
            //Arrange
            var userDto = new ChangeUserRoleDto()
            {
                UserId = Guid.NewGuid(),
               AdminId = Guid.NewGuid(),
               UserRole = 0,
               AdminRole = (FinalProject.Database.Models.Role)1
            };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(rep => rep.ChangeUserRole(userDto));

            var service = new UserService(userRepositoryMock.Object);

            //Act
            await service.ChangeUserRole(userDto);

            //Assert
            userRepositoryMock.Verify(rep => rep.ChangeUserRole(It.IsAny<ChangeUserRoleDto>()), Times.Once);
        }

        [Theory]
        [InlineData(null, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("5356E631-836E-4431-A412-0544889A0D99", null)]
        public async Task ChangeUser_Role_InvalidDto_ThrowsHttpStatusException(Guid adminId, Guid userId)
        {
            //Arrange
            var userDto = new ChangeUserRoleDto()
            {
                UserId = userId,
                AdminId = adminId
            };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(rep => rep.ChangeUserRole(userDto));

            var service = new UserService(userRepositoryMock.Object);

            //Act & Arrange
            await Assert.ThrowsAsync<HttpStatusException>(() => service.ChangeUserRole(userDto));
        }

        [Fact]
        public async Task DeleteUser_ValidDto_CallsRepositoryMethod()
        {
            //Arrange
            var userDto = new DeleteUserDto()
            {
                UserId = Guid.NewGuid(),
                AdminId = Guid.NewGuid(),
                AdminRole = (FinalProject.Database.Models.Role)1
            };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(rep => rep.DeleteUser(userDto));

            var service = new UserService(userRepositoryMock.Object);

            //Act
            await service.DeleteUser(userDto);

            //Assert
            userRepositoryMock.Verify(rep => rep.DeleteUser(It.IsAny<DeleteUserDto>()), Times.Once);
        }

        [Theory]
        [InlineData(null, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("5356E631-836E-4431-A412-0544889A0D99", null)]
        public async Task DeleteUser_InvalidDto_ThrowsHttpStatusException(Guid adminId, Guid userId)
        {
            //Arrange
            var userDto = new DeleteUserDto()
            {
                UserId = userId,
                AdminId = adminId
            };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(rep => rep.DeleteUser(userDto));

            var service = new UserService(userRepositoryMock.Object);

            //Act & Arrange
            await Assert.ThrowsAsync<HttpStatusException>(() => service.DeleteUser(userDto));
        }
    }
}
