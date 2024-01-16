using FinalProject.BusinessLogic.Services;
using FinalProject.Database.Models;
using FinalProject.Database.Models.Dto.Login;
using FinalProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IJwtService _jwtService;

        public LoginController(ILoginService loginService, IJwtService jwtService)
        {
            _loginService = loginService;
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var response = await _loginService.Login(loginRequestDto);
            if (!response.IsSuccess)
            {
                return Unauthorized();
            }
            var result = new
            {
                username = loginRequestDto.Username,
                role = (Role)response.Role,
                userId = (Guid)response.userId

            };

            //return Ok(_jwtService.GetJwtToken(loginRequestDto.Username, (Role)response.Role));
            return Ok(result);    
        }
    }
}
