using FinalProject.BusinessLogic.ErrorResponseModel;
using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Models.Dto.Image;
using FinalProject.Database.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly DbContextService _dbContext;

        public ImageRepository(DbContextService dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteImage(ImageDto imageDto)
        {
            var imageRequest = await _dbContext.Images.FirstOrDefaultAsync(i => i.PersonalInformationId == imageDto.personalId && i.Id == imageDto.ImageId);
            if (imageRequest == null) 
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "The requested image was not found");
            }
            _dbContext.Images.Remove(imageRequest);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Image>> DownloadImages(Guid personalInformationId)
        {
           return await _dbContext.Images.Where( i => i.PersonalInformationId == personalInformationId).ToListAsync();
        }

        public async Task UploadImage(Image image)
        {
            _dbContext.Images.Add(image);
            var request = await _dbContext.PersonalInformations.SingleOrDefaultAsync(pi => pi.Id == image.PersonalInformationId);
            if (request == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "The requested personal information is not found");
            }
            request.Images.Add(image);
            await _dbContext.SaveChangesAsync();
        }
    }
}
