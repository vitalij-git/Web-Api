using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Services;
using FinalProject.Controllers;
using FinalProject.Database.Models.Dto.PersonalInformation;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTests.Controller
{
    public class PersonalInformationControllerTests
    {
       
        [Fact]
        public async Task GetPersonalInformationByUserId_ValidId_ReturnOkResultWithPersonalInformation()
        {
            //Arrange
            Guid userId = Guid.NewGuid();
            var personalInformationServiceMock = new Mock<IPersonalInformationService>();
            personalInformationServiceMock.Setup(service => service.GetPersonalInformation(userId)).Returns(Task.FromResult(new GetPersonalInformationDto { 
                FirstName = "fakename",
                LastName = "lastname",
                Email = "fakeemail",
                PersonalCode = 111,
                TelNumber = 222,
                City = "city", 
                Street = "street",
                ApartmentNumber = 1,
                BuildingNumber = 2 }));

            var controller = new PersonalInformationController(personalInformationServiceMock.Object);

            //Act
            var result = await controller.GetPersonalInformation(userId);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var personalInformationDto = Assert.IsType<GetPersonalInformationDto>(okResult.Value);
            Assert.Equal("fakename", personalInformationDto.FirstName);
            Assert.Equal("lastname", personalInformationDto.LastName);
            Assert.Equal("fakeemail", personalInformationDto.Email);
            Assert.Equal(111, personalInformationDto.PersonalCode);
            Assert.Equal(222, personalInformationDto.TelNumber);
            Assert.Equal("city", personalInformationDto.City);
            Assert.Equal("street", personalInformationDto.Street);
            Assert.Equal(1, personalInformationDto.ApartmentNumber);
            Assert.Equal(2, personalInformationDto.BuildingNumber);
        }

        [Fact]
        public async Task AddPersonalInformation_ReturnsCreatedActionResult()
        {
            //Arrange
            var personalInformationDto = new AddPersonalInformationDto()
            {
                FirstName = "firstname",
                LastName = "lastname",
                Email = "email",
                PersonalCode = 111,
                TelNumber = 222,
                UserId = Guid.NewGuid(),
            };
            var personalInformationServiceMock = new Mock<IPersonalInformationService>();
            personalInformationServiceMock.Setup(service => service.AddPersonalInformation(personalInformationDto));

            var controller = new PersonalInformationController(personalInformationServiceMock.Object);

            //Act
            var result = await controller.AddPersonalInformation(personalInformationDto);

            //Assert
             Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task UpdatePersonalInformation_FirstName_ReturnsOkResult()
        {
            //Arrange
            var personalInfomartionFirstNameDto = new UpdatePersonalInformationFirstNameDto()
            {
                FirstName = "firstname",
                UserId= Guid.NewGuid(),
            };
            var personalInfomartionFirstNameMock = new Mock<IPersonalInformationService>();
            personalInfomartionFirstNameMock.Setup(service => service.UpdatePersonalInformationFirstName(personalInfomartionFirstNameDto));

            var controller = new PersonalInformationController(personalInfomartionFirstNameMock.Object);

            //Act
            var result = await controller.UpdatePersonalInformationFirstName(personalInfomartionFirstNameDto);

            //Assert
             Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdatePersonalInformation_LastName_ReturnsOkResult()
        {
            //Arrange
            var personalInfomartionLastNameDto = new UpdatePersonalInformationLastNameDto()
            {
                LastName = "lastname",
                UserId = Guid.NewGuid(),
            };
            var personalInfomartionLastNameMock = new Mock<IPersonalInformationService>();
            personalInfomartionLastNameMock.Setup(service => service.UpdatePersonalInformationLastName(personalInfomartionLastNameDto));

            var controller = new PersonalInformationController(personalInfomartionLastNameMock.Object);

            //Act
            var result = await controller.UpdatePersonalInformationLastName(personalInfomartionLastNameDto);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdatePersonalInformation_PersonalCode_ReturnsOkResult()
        {
            //Arrange
            var personalInfomartionPersonalCodeDto = new UpdatePersonalInformationPersonalCodeDto()
            {
                PersonalCode = 123456,
                UserId = Guid.NewGuid(),
            };
            var personalInfomartionPersonalCodeMock = new Mock<IPersonalInformationService>();
            personalInfomartionPersonalCodeMock.Setup(service => service.UpdatePersonalInformationPersonalCode(personalInfomartionPersonalCodeDto));

            var controller = new PersonalInformationController(personalInfomartionPersonalCodeMock.Object);

            //Act
            var result = await controller.UpdatePersonalInformationPersonalCode(personalInfomartionPersonalCodeDto);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdatePersonalInformation_TelNumber_ReturnsOkResult()
        {
            //Arrange
            var personalInfomartionTelNumberDto = new UpdatePersonalInformationTelNumberDto()
            {
                TelNumber = 123456,
                UserId = Guid.NewGuid(),
            };
            var personalInfomartionTelNumberMock = new Mock<IPersonalInformationService>();
            personalInfomartionTelNumberMock.Setup(service => service.UpdatePersonalInformationTelNumber(personalInfomartionTelNumberDto));

            var controller = new PersonalInformationController(personalInfomartionTelNumberMock.Object);

            //Act
            var result = await controller.UpdatePersonalInformationTelNumber(personalInfomartionTelNumberDto);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdatePersonalInformation_Email_ReturnsOkResult()
        {
            //Arrange
            var personalInfomartionEmailDto = new UpdatePersonalInformationEmailDto()
            {
                Email = "fake@gmail.com",
                UserId = Guid.NewGuid(),
            };
            var personalInfomartionEmailMock = new Mock<IPersonalInformationService>();
            personalInfomartionEmailMock.Setup(service => service.UpdatePersonalInformationEmail(personalInfomartionEmailDto));

            var controller = new PersonalInformationController(personalInfomartionEmailMock.Object);

            //Act
            var result = await controller.UpdatePersonalInformationEmail(personalInfomartionEmailDto);

            //Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
