using FinalProject.BusinessLogic.Models.Dto.Address;
using FinalProject.BusinessLogic.Services;
using FinalProject.Database.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = (nameof(Role.User) + "," + nameof(Role.Admin)))]
    [ApiController]
    [Route("[Controller]")]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddress([FromHeader] Guid personalId)
        {
           var result = await  _addressService.GetAddress(personalId);
            return Ok(result);  
        }

        [HttpPost]   
        public async Task<IActionResult> AddAddress([FromBody] AddAddressDto addAddressDto)
        {
             await _addressService.AddAddress(addAddressDto);
            var addedAddress = new { Message = "The address was successfully added", StatusCode = 201 };
            return Created("Address", addedAddress);
        }

        [Route("ApartmentNumber")]
        [HttpPut]
        public async Task<IActionResult> UpdateAddressApartmentNumber([FromBody] UpdateAddressApartmentNumberDto updateAddressApartmentNumberDto)
        {
            await _addressService.UpdateAddressApartmentNumber(updateAddressApartmentNumberDto);
            return Ok();
        }

        [Route("BuildingNumber")]
        [HttpPut]
        public async Task<IActionResult> UpdateAddressBuildingNumber([FromBody] UpdateAddressBuildingNumberDto updateAddressBuildingNumberDto)
        {
             await _addressService.UpdateAddressBuildingNumber(updateAddressBuildingNumberDto);
            return Ok();
        }

        [Route("City")]
        [HttpPut]
        public async Task<IActionResult> UpdateAddressCity([FromBody]UpdateAddressCityDto updateAddressCityDto)
        {
            await _addressService.UpdateAddressCity(updateAddressCityDto);
            return Ok();
        }

        [Route("Street")]
        [HttpPut]
        public async Task<IActionResult> UpdateAddressStreet([FromBody]UpdateAddressStreetDto updateAddressStreetDto)
        {
            await _addressService.UpdateAddressStreet(updateAddressStreetDto);
            return Ok();
        }
    }
}
