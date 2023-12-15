using FinalProject.BusinessLogic.ErrorResponseModel;
using FinalProject.BusinessLogic.Models.Dto.Address;
using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Services;
using FinalProject.Database.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.BusinessLogic.Models.Dto.Image;

namespace XUnitTests.Services
{
    public class ImageServiceTests
    {
        [Theory]
        [InlineData(null , "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("5356E631-836E-4431-A412-0544889A0D99", null)]
      
        public async Task DeleteImage_InvalidDto_ThrowsHttpStatusException(Guid imageId, Guid personalInformationId)
        {
            //Arrange
            var imageDto = new ImageDto()
            {
                ImageId = imageId,
                personalId = personalInformationId
            };
            var imageRepositoryMock = new Mock<IImageRepository>();
            imageRepositoryMock.Setup(repository => repository.DeleteImage(imageDto));

            var service = new ImageService(imageRepositoryMock.Object);

            //Act & Assert
            await Assert.ThrowsAsync<HttpStatusException>(() => service.DeleteImage(imageDto));
        }
    }
}
