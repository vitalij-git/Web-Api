using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Models.Dto.Image;
using FinalProject.Database.Models.Dto.Image;
using Microsoft.AspNetCore.Http;

namespace FinalProject.BusinessLogic.Services
{
    public interface IImageService
    {
        public Task UploadImage(IFormFile image, Guid personalInformationId);

        public Task<GetImagesDto> DownloadImages(Guid personalInformationId);

        public Task DeleteImage(ImageDto imageDto);
    }
}