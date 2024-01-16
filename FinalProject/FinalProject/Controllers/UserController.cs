using FinalProject.BusinessLogic.Models.Dto.User;
using FinalProject.BusinessLogic.Services;
using FinalProject.Database.Models;
using FinalProject.Database.Models.Dto.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : Controller
    {
       private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            await _userService.CreateUser(createUserDto);
            var createdUser = new { Message = "The new user was successfully created", StatusCode = 201};
            return Created("User", createdUser);
        }

       [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = (nameof(Role.User) + "," + nameof(Role.Admin)))]
        [Route("username")]
        [HttpPut]
        public async Task<IActionResult> UpdateUsername([FromBody] UpdateUserNameDto updateUserNameDto)
        {
            await _userService.UpdateUsername(updateUserNameDto);
            return Ok();
        }

       [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = (nameof(Role.User) + "," + nameof(Role.Admin)))]
        [Route("password")]
        [HttpPut]
        public async Task<IActionResult> UpdateUserPassword([FromBody] UpdateUserPasswordDto updateUserPasswordDto)
        {
            await _userService.UpdateUserPassword(updateUserPasswordDto);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = (nameof(Role.Admin)))]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserDto deleteUserDto)
        {
            await _userService.DeleteUser(deleteUserDto);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = (nameof(Role.Admin)))]
        [Route("role")]
        [HttpPut]
        public async Task<IActionResult> ChangeUserRole([FromBody] ChangeUserRoleDto changeUserRoleDto)
        {
            await _userService.ChangeUserRole(changeUserRoleDto);
            return Ok();
        }
    }
}
