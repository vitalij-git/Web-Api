using FinalProject.BusinessLogic.Services;
using FinalProject.Database.Models;
using FinalProject.Database.Models.Dto.PersonalInformation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = (nameof(Role.User) + "," + nameof(Role.Admin)))]
    [ApiController]
    [Route("[Controller]")]
    public class PersonalInformationController : Controller
    {
        private readonly IPersonalInformationService _personalInformationService;

        public PersonalInformationController(IPersonalInformationService personalInformationService)
        {
            _personalInformationService = personalInformationService;
        }
    
      
        [HttpPost]
        public async Task<IActionResult> AddPersonalInformation([FromBody] AddPersonalInformationDto addPersonalInformationDto)
        {
           await _personalInformationService.AddPersonalInformation(addPersonalInformationDto);
            var addedPersonalInformation = new { Message = "The new user was successfully created", StatusCode = 201 };
            return Created("PersonalInformation", addedPersonalInformation);
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonalInformation([FromHeader] Guid userId)
        {
            var result = await _personalInformationService.GetPersonalInformation(userId);
            return Ok(result);
        }

        [Route("firstname")]
        [HttpPut]
        public async Task<IActionResult> UpdatePersonalInformationFirstName([FromBody] UpdatePersonalInformationFirstNameDto updatePersonalInformationFirstNameDto)
        {
            await _personalInformationService.UpdatePersonalInformationFirstName(updatePersonalInformationFirstNameDto);
            return Ok();
        }

        [Route("lastname")]
        [HttpPut]
        public async Task<IActionResult> UpdatePersonalInformationLastName([FromBody] UpdatePersonalInformationLastNameDto updatePersonalInformationLastNameDto)
        {
            await _personalInformationService.UpdatePersonalInformationLastName(updatePersonalInformationLastNameDto);
            return Ok();
        }

        [Route("personalcode")]
        [HttpPut]
        public async Task<IActionResult> UpdatePersonalInformationPersonalCode([FromBody] UpdatePersonalInformationPersonalCodeDto updatePersonalInformationPersonalCodeDto)
        {
            await _personalInformationService.UpdatePersonalInformationPersonalCode(updatePersonalInformationPersonalCodeDto);
            return Ok();
        }

        [Route("email")]
        [HttpPut]
        public async Task<IActionResult> UpdatePersonalInformationEmail([FromBody] UpdatePersonalInformationEmailDto updatePersonalInformationEmailDto)
        {
            await _personalInformationService.UpdatePersonalInformationEmail(updatePersonalInformationEmailDto);
            return Ok();
        }

        [Route("telnumber")]
        [HttpPut]
        public async Task<IActionResult> UpdatePersonalInformationTelNumber([FromBody] UpdatePersonalInformationTelNumberDto updatePersonalInformationTelNumberDto)
        {
            await _personalInformationService.UpdatePersonalInformationTelNumber(updatePersonalInformationTelNumberDto);
            return Ok();
        }
    }
}
