using FinalProject.BusinessLogic.Models.Dto.Address;
using FinalProject.BusinessLogic.Services;
using FinalProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTests.Controller
{
    public class AddressControllerTests
    {
        [Fact]
        public async Task AddAddress_ReturnsCreatedActionResult()
        {
            //Arrange
            var addressDto = new AddAddressDto()
            {
                City = "fakeCity",
                Street = "fakeStreet",
                ApartmentNumber = 1,
                BuildingNumber = 2,
                PersonalInformationId = Guid.NewGuid()
            };
            var addressServiceMock = new Mock<IAddressService>();
            addressServiceMock.Setup(service => service.AddAddress(addressDto));

            var controller = new AddressController(addressServiceMock.Object);

            //Act
            var result = await controller.AddAddress(addressDto);

            //Assert
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task GetAddressByPersonalInformationId_ReturnOkWithAddress()
        { 
            //Arrange
            Guid personalInformationId = Guid.NewGuid();
            var addressServiceMock = new Mock<IAddressService>();
            addressServiceMock.Setup(service => service.GetAddress(personalInformationId)).Returns(Task.FromResult(new GetAddressDto { 
                City = "city", 
                Street = "street", 
                ApartmentNumber = 1, 
                BuildingNumber = 2 }));

            var controller = new AddressController(addressServiceMock.Object);

            //Act
            var result = await controller.GetAddress(personalInformationId);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var addressDto = Assert.IsType<GetAddressDto>(okResult.Value);
            Assert.Equal("city", addressDto.City);
            Assert.Equal("street", addressDto.Street);
            Assert.Equal(1, addressDto.ApartmentNumber);
            Assert.Equal(2, addressDto.BuildingNumber);
        }

        [Fact]
        public async Task UpdateAddress_City_ReturnsOkResult()
        {
            //Arrange
            var addressCityDto = new UpdateAddressCityDto()
            {
                City ="city",
                PersonalInformationId = Guid.NewGuid(),
            };
            var addressServiceMock = new Mock<IAddressService>();
            addressServiceMock.Setup(service => service.UpdateAddressCity(addressCityDto));

            var controller = new AddressController(addressServiceMock.Object);

            //Act
            var result = await controller.UpdateAddressCity(addressCityDto);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateAddress_Street_ReturnsOkResult()
        {
            //Arrange
            var addressStreetDto = new UpdateAddressStreetDto()
            {
                Street = "city",
                PersonalInformationId = Guid.NewGuid(),
            };
            var addressServiceMock = new Mock<IAddressService>();
            addressServiceMock.Setup(service => service.UpdateAddressStreet(addressStreetDto));

            var controller = new AddressController(addressServiceMock.Object);

            //Act
            var result = await controller.UpdateAddressStreet(addressStreetDto);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateAddress_ApartmentNumber_ReturnsOkResult()
        {
            //Arrange
            var addressApartmentNumberDto = new UpdateAddressApartmentNumberDto()
            {
                ApartmentNumber = 1,
                PersonalInformationId = Guid.NewGuid(),
            };
            var addressServiceMock = new Mock<IAddressService>();
            addressServiceMock.Setup(service => service.UpdateAddressApartmentNumber(addressApartmentNumberDto));

            var controller = new AddressController(addressServiceMock.Object);

            //Act
            var result = await controller.UpdateAddressApartmentNumber(addressApartmentNumberDto);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateAddress_BuildingNumber_ReturnsOkResult()
        {
            //Arrange
            var addressBuildingNumberDto = new UpdateAddressBuildingNumberDto()
            {
                BuildingNumber = 1,
                PersonalInformationId = Guid.NewGuid(),
            };
            var addressServiceMock = new Mock<IAddressService>();
            addressServiceMock.Setup(service => service.UpdateAddressBuildingNumber(addressBuildingNumberDto));

            var controller = new AddressController(addressServiceMock.Object);

            //Act
            var result = await controller.UpdateAddressBuildingNumber(addressBuildingNumberDto);

            //Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
