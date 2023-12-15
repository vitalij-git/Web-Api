using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Models.Dto.Image;

namespace FinalProject.Database.Repository
{
    public interface IImageRepository
    {
        public Task UploadImage(Image image);

        public Task<List<Image>> DownloadImages(Guid personalInformationId);

        public Task DeleteImage(ImageDto imageDto);  
    }
}