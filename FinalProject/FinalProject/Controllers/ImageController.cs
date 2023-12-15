using FinalProject.BusinessLogic.Models.Dto.Image;
using FinalProject.BusinessLogic.Services;
using FinalProject.Database.Models;
using FinalProject.Request;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ImageController : Controller
    {
       private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = (nameof(Role.User) + "," + nameof(Role.Admin)))]
        [HttpPost("Upload")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadRequest imageUploadRequest)
        {
            await _imageService.UploadImage(imageUploadRequest.Image, imageUploadRequest.PersonalInformationId);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = (nameof(Role.User) + "," + nameof(Role.Admin)))]
        [HttpGet("Download")]
        public async Task<IActionResult> DownloadImage([FromHeader] Guid personalInformationId)
        {
            var image = await _imageService.DownloadImages(personalInformationId);
            return Ok(image);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = (nameof(Role.User) + "," + nameof(Role.Admin)))]
        [HttpDelete]
        public async Task<IActionResult> DeleteImage([FromBody] ImageDto imageDto)
        {
            await _imageService.DeleteImage(imageDto);
            return Ok();
        }

    }
}
