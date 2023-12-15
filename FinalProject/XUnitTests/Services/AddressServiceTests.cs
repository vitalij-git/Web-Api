using FinalProject.BusinessLogic.ErrorResponseModel;
using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Models.Dto.Address;
using FinalProject.BusinessLogic.Services;
using FinalProject.Database.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace XUnitTests.Services
{
    public class AddressServiceTests
    {
        [Theory]
        [InlineData(null, "Street", 123, 456, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("City", null, 123, 456, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("City", "Street", 123, 456, null)]
        [InlineData("City1", "Street", 123, 456, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("City@", "Street", 123, 456, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("City", "St12reet1", 123, 456, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("City@", "St#reet", 123, 456, "5356E631-836E-4431-A412-0544889A0D99")]
        public async Task AddAddress_InvalidDto_ThrowsHttpStatusException(string city, string street, int buildingNumber, int apartmentNumber, Guid personalInformationId)
        {
            //Arrange
            var addressDto = new AddAddressDto()
            {
                City = city,
                Street = street,
                BuildingNumber = buildingNumber,
                ApartmentNumber = apartmentNumber,
                PersonalInformationId = personalInformationId
            };
            var address = new Address()
            {
                City = city,
                Street = street,
                BuildingNumber = buildingNumber,
                ApartmentNumber = apartmentNumber,
                PersonalInformationId = personalInformationId
            };
           
            var addressRepositoryMock = new Mock<IAddressRepository>();
            addressRepositoryMock.Setup(repository => repository.AddAddress(address));

            var service = new AddressService(addressRepositoryMock.Object);

            //Act & Assert
            await Assert.ThrowsAsync<HttpStatusException>(() => service.AddAddress(addressDto));
        }

        [Fact]
        public async Task AddAddress_ValidDto_CallsRepositoryMethod()
        {
            // Arrange
            var addAddressDto = new AddAddressDto
            {
                City = "City",
                Street = "Street",
                BuildingNumber = 123,
                ApartmentNumber = 456,
                PersonalInformationId = Guid.NewGuid()
            };
            var address = new Address()
            {
                City = addAddressDto.City,
                Street = addAddressDto.Street,
                BuildingNumber = addAddressDto.BuildingNumber,
                ApartmentNumber = addAddressDto.ApartmentNumber,
                PersonalInformationId = addAddressDto.PersonalInformationId
            };
            var addressRepositoryMock = new Mock<IAddressRepository>();
            addressRepositoryMock.Setup(repository => repository.AddAddress(address));

            var service = new AddressService(addressRepositoryMock.Object);

            //Act
            await service.AddAddress(addAddressDto);

            //Assert
            addressRepositoryMock.Verify(rep => rep.AddAddress(It.IsAny<Address>()), Times.Once);
        }

        [Fact]
        public async Task GetAddress_ValidPersonalInformationId_CallsRepositoryMethod()
        {
            //Arrange
            Guid personalInformationId = Guid.NewGuid();
            var addressRepositoryMock = new Mock<IAddressRepository>();
            addressRepositoryMock.Setup(rep => rep.GetAddress(personalInformationId)).Returns(Task.FromResult(new Address()
            {
                City = "fakeCity",
                Street = "fakeStreet",
                BuildingNumber = 1,
                ApartmentNumber = 2,
            }));

            var service = new AddressService(addressRepositoryMock.Object);

            //Act
            var result = await service.GetAddress(personalInformationId);

            //Assert
            Assert.IsType<GetAddressDto>(result);
            Assert.Equal("fakeCity",result.City);
            Assert.Equal("fakeStreet", result.Street);
            Assert.Equal(1, result.BuildingNumber);
            Assert.Equal(2, result.ApartmentNumber);
        }

        [Fact]
        public async Task GetAddress_WhenPersonalInformationIdIsNotFound_ThrowsHttpStatusException()
        {
            //Arrange
            Guid personalInformationId = Guid.NewGuid();
            var addressRepositoryMock = new Mock<IAddressRepository>();
            addressRepositoryMock.Setup(rep => rep.GetAddress(personalInformationId)).Returns(Task.FromResult((Address)null));

            var service = new AddressService(addressRepositoryMock.Object);

            //Act && Assert
            await Assert.ThrowsAsync<HttpStatusException>(() => service.GetAddress(personalInformationId));
        }

        [Fact]
        public async Task UpdateAddress_City_CallsRepositoryMethod()
        {
            //Arange
            var addressDto = new UpdateAddressCityDto()
            {
                City = "FakeCity",
                PersonalInformationId = Guid.NewGuid()
            };
            var addressRepositoryMock = new Mock<IAddressRepository>();
            addressRepositoryMock.Setup(rep => rep.UpdateAddressCity(addressDto));

            var service = new AddressService(addressRepositoryMock.Object);

            //Act
            await service.UpdateAddressCity(addressDto);
            
            //Assert
            addressRepositoryMock.Verify(rep => rep.UpdateAddressCity(It.IsAny<UpdateAddressCityDto>()), Times.Once);
        }

        [Theory]
        [InlineData("C2i2ty")]
        [InlineData("Ci@ty")]
        public async Task UpdateAddress_City_InvalidDto_ThrowsHttpStatusException(string city)
        {
            //Arange
            var addressDto = new UpdateAddressCityDto()
            {
                City = city,
                PersonalInformationId = Guid.NewGuid()
            };
            var addressRepositoryMock = new Mock<IAddressRepository>();
            addressRepositoryMock.Setup(rep => rep.UpdateAddressCity(addressDto));

            var service = new AddressService(addressRepositoryMock.Object);

            //Act && Assert
            await Assert.ThrowsAsync<HttpStatusException>(() => service.UpdateAddressCity(addressDto));
        }

        [Fact]
        public async Task UpdateAddress_Street_CallsRepositoryMethod()
        {
            //Arange
            var addressDto = new UpdateAddressStreetDto()
            {
                Street = "FakeStreet",
                PersonalInformationId = Guid.NewGuid()
            };
            var addressRepositoryMock = new Mock<IAddressRepository>();
            addressRepositoryMock.Setup(rep => rep.UpdateAddressStreet(addressDto));

            var service = new AddressService(addressRepositoryMock.Object);

            //Act
            await service.UpdateAddressStreet(addressDto);

            //Assert
            addressRepositoryMock.Verify(rep => rep.UpdateAddressStreet(It.IsAny<UpdateAddressStreetDto>()), Times.Once);
        }

        [Theory]
        [InlineData("Str3et")]
        [InlineData("Str#$t")]
        public async Task UpdateAddress_Street_InvalidDto_ThrowsHttpStatusException(string street)
        {
            //Arange
            var addressDto = new UpdateAddressStreetDto()
            {
                Street = street,
                PersonalInformationId = Guid.NewGuid()
            };
            var addressRepositoryMock = new Mock<IAddressRepository>();
            addressRepositoryMock.Setup(rep => rep.UpdateAddressStreet(addressDto));

            var service = new AddressService(addressRepositoryMock.Object);

            //Act && Assert
            await Assert.ThrowsAsync<HttpStatusException>(() => service.UpdateAddressStreet(addressDto));
        }

        [Fact]
        public async Task UpdateAddress_BuildingNumber_CallsRepositoryMethod()
        {
            //Arange
            var addressDto = new UpdateAddressBuildingNumberDto()
            {
                BuildingNumber = 1,
                PersonalInformationId = Guid.NewGuid()
            };
            var addressRepositoryMock = new Mock<IAddressRepository>();
            addressRepositoryMock.Setup(rep => rep.UpdateAddressBuildingNumber(addressDto));

            var service = new AddressService(addressRepositoryMock.Object);

            //Act
            await service.UpdateAddressBuildingNumber(addressDto);

            //Assert
            addressRepositoryMock.Verify(rep => rep.UpdateAddressBuildingNumber(It.IsAny<UpdateAddressBuildingNumberDto>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAddress_ApartmentNumber_CallsRepositoryMethod()
        {
            //Arange
            var addressDto = new UpdateAddressApartmentNumberDto()
            {
                ApartmentNumber = 1,
                PersonalInformationId = Guid.NewGuid()
            };
            var addressRepositoryMock = new Mock<IAddressRepository>();
            addressRepositoryMock.Setup(rep => rep.UpdateAddressApartmentNumber(addressDto));

            var service = new AddressService(addressRepositoryMock.Object);

            //Act
            await service.UpdateAddressApartmentNumber(addressDto);

            //Assert
            addressRepositoryMock.Verify(rep => rep.UpdateAddressApartmentNumber(It.IsAny<UpdateAddressApartmentNumberDto>()), Times.Once);
        }

    }
}
