using FinalProject.BusinessLogic.Models.Dto.User;
using FinalProject.BusinessLogic.Services;
using FinalProject.Controllers;
using FinalProject.Database.Models.Dto.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTests.Controller
{
    public class UserControllerTests
    {
        [Fact]
        public async Task CreateUser_ReturnsCreatedActionResult()
        {
            //Arrange
            var userDto = new CreateUserDto()
            {
                Username = "Test",
                Password = "Test",
            };
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.CreateUser(userDto));
            
            var controller = new UserController(userServiceMock.Object);

            //Act
            var result = await controller.CreateUser(userDto);

            //Assert
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task UpdateUser_Username_ReturnsOkResult()
        {
            //Arrange
            var userDto = new UpdateUserNameDto()
            {
                NewUserName = "newFake",
                OldUserName = "Fake",
                UserId = Guid.NewGuid(),
            };
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.UpdateUsername(userDto));

            var controller = new UserController(userServiceMock.Object);

            //Act
            var result = await controller.UpdateUsername(userDto);

            //Assert 
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateUser_Password_ReturnsOkResult()
        {
            //Arrange
            var userDto = new UpdateUserPasswordDto()
            {
                NewPassword = "newPasswordFake",
                OldPassword = "PasswordFake",
                UserId = Guid.NewGuid(),
            };
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.UpdateUserPassword(userDto));

            var controller = new UserController(userServiceMock.Object);

            //Act
            var result = await controller.UpdateUserPassword(userDto);

            //Assert 
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task ChangeUser_Role_ReturnsOkResult()
        {
            //Arrange
            var userDto = new ChangeUserRoleDto()
            {
                UserId = Guid.NewGuid(),
                UserRole = 0,
                AdminId = Guid.NewGuid(),
                AdminRole = (FinalProject.Database.Models.Role)1

            };
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.ChangeUserRole(userDto));

            var controller = new UserController(userServiceMock.Object);

            //Act
            var result = await controller.ChangeUserRole(userDto);

            //Assert 
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Deleteuser_ReturnsOkResult()
        {
            //Arrange
            var userDto = new DeleteUserDto()
            {
                UserId = Guid.NewGuid(),
                AdminId = Guid.NewGuid(),
                AdminRole = (FinalProject.Database.Models.Role)1

            };
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.DeleteUser(userDto));

            var controller = new UserController(userServiceMock.Object);

            //Act
            var result = await controller.DeleteUser(userDto);

            //Assert 
            Assert.IsType<OkResult>(result);
        }

    }
}
