using FinalProject.BusinessLogic.ErrorResponseModel;
using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Models.Dto.Image;
using FinalProject.Database.Models.Dto.Image;
using FinalProject.Database.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BusinessLogic.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task DeleteImage(ImageDto imageDto)
        {
            if(imageDto.ImageId == Guid.Empty || imageDto.personalId == Guid.Empty)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The request contains an empty or null value");
            }
            await _imageRepository.DeleteImage(imageDto);
        }

        public async Task<GetImagesDto> DownloadImages(Guid personalInformationId)
        {
           var images = await _imageRepository.DownloadImages(personalInformationId);
            var getImageDto = new GetImagesDto();  
            foreach(var image in images)
            {
                getImageDto.Images.Add(image.Title, image.Data);
            }
            return getImageDto;
        }

        public async Task UploadImage(IFormFile imageRequest, Guid personalInformationId)
        {
            var image = new Image();
            using var memoryStream = new MemoryStream();
            imageRequest.CopyTo(memoryStream);

            image.Data = memoryStream.ToArray();
            image.Title = imageRequest.FileName;
            image.PersonalInformationId = personalInformationId;
            image.CreatedAt = DateTime.Now;
            await _imageRepository.UploadImage(image);
        }
    }
}
