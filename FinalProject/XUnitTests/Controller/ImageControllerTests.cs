using FinalProject.BusinessLogic.Models.Dto.Image;
using FinalProject.BusinessLogic.Services;
using FinalProject.Controllers;
using FinalProject.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProject.BusinessLogic.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Database.Models.Dto.Image;


namespace XUnitTests.Controller
{
    public class ImageControllerTests
    {
        [Fact]
        public async Task UploadImage_ReturnOkActionResult()
        {
            //Arrange
            var fileMock = new Mock<IFormFile>();
            var image = new ImageUploadRequest()
            {
                Image = fileMock.Object,
                PersonalInformationId = Guid.NewGuid()
            };
            var imageServiceMock = new Mock<IImageService>();
            imageServiceMock.Setup(service => service.UploadImage(image.Image, image.PersonalInformationId));

            var controller = new ImageController(imageServiceMock.Object);

            //Act
            var result = await controller.UploadImage(image);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DownloadImages_ReturnsOkActionResultWithImage()
        {
            //Arrange
            Guid personalInformationId = Guid.NewGuid();
            var imageServiceMock = new Mock<IImageService>();
            imageServiceMock.Setup(service => service.DownloadImages(personalInformationId)).Returns(Task.FromResult(new GetImagesDto()));

            var controller = new ImageController(imageServiceMock.Object);

            //Act
            var result = await controller.DownloadImage(personalInformationId);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var imageResult = Assert.IsType<GetImagesDto>(okResult.Value);

        }

        [Fact]
        public async Task DeleteImage_ReturnsOkActionResult()
        {
            //Arrange
            var imageDto = new ImageDto()
            {
                ImageId = Guid.NewGuid(),
                personalId = Guid.NewGuid(),
            };
            var imageServiceMock = new Mock<IImageService>();
            imageServiceMock.Setup(service => service.DeleteImage(imageDto)).Returns(Task.FromResult(new Image()));

            var controller = new ImageController(imageServiceMock.Object);

            //Act
            var result = await controller.DeleteImage(imageDto);

            //Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
