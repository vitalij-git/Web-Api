using FinalProject.BusinessLogic.ErrorResponseModel;
using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Services;
using FinalProject.Database.Models.Dto.PersonalInformation;
using FinalProject.Database.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTests.Services
{
    public class PersonalInformationServiceTests
    {
        [Fact]
        public async Task AddPersonalOnformation_ValidDto_CallsRepositoryMethod()
        {
            //Arrange
            var personalInformationDto = new AddPersonalInformationDto() 
            {
                FirstName = "firstname",
                LastName = "lastname",
                Email = "email@email.com",
                PersonalCode = 39607125421,
                TelNumber = 222,
                UserId = Guid.NewGuid(),
            };
            var personalInformation = new PersonalInformation() 
            {
                FirstName = personalInformationDto.FirstName,
                LastName = personalInformationDto.LastName,
                Email = personalInformationDto.Email,
                PersonalCode = personalInformationDto.PersonalCode,
                TelNumber = personalInformationDto.TelNumber,
                UserId = Guid.NewGuid()
            };
            var personalInformationServiceMock = new Mock<IPersonalInformationRepository>();
            personalInformationServiceMock.Setup(rep => rep.AddPersonalInformation(personalInformation));

            var service = new PersonalInformationService(personalInformationServiceMock.Object);

            //Act
            await service.AddPersonalInformation(personalInformationDto);

            //Assert
            personalInformationServiceMock.Verify(rep => rep.AddPersonalInformation(It.IsAny<PersonalInformation>()), Times.Once);
        }

        [Theory]
        [InlineData(null, "lastname", "email@email.com", 39607125587, 678910, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("firstname", null, "email@email.com", 39607125587, 678910, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("firstname", "lastname", null, 39607125587, 678910, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("firstname", "lastname", "email@email.com", 39607125587, 678910, null)]
        [InlineData("fakename1", "lastname", "email@email.com", 39607125587, 678910, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("fakena#$me1", "lastname", "email@email.com", 39607125587, 678910, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("fakename", "las4tname", "email@email.com", 39607125587, 678910, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("fakename", "las$tname", "email@email.com", 39607125587, 678910, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("fakename", "lastname", "email@email.com", 39607125, 678910, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("fakename", "lastname", "email@email.com", 3960712542123, 678910, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("fakename", "lastname", "email@emai", 3960712542123, 678910, "5356E631-836E-4431-A412-0544889A0D99")]
        public async Task AddPersonalInformation_InvalidDto_ThrowsHttpStatusException(string firstName, string lastName, string email, long personalCode, long telNumber, Guid userId)
        {
            //Arrange
            var personalInformationDto = new AddPersonalInformationDto()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PersonalCode = personalCode,
                TelNumber = telNumber,
                UserId = userId
            };
            var personalInformationServiceMock = new Mock<IPersonalInformationRepository>();
            personalInformationServiceMock.Setup(rep => rep.AddPersonalInformation(new PersonalInformation()));

            var service = new PersonalInformationService(personalInformationServiceMock.Object);

            //Act & Assert
            await Assert.ThrowsAsync<HttpStatusException>(() => service.AddPersonalInformation(personalInformationDto));
        }

        [Fact]
        public async Task GetPersonalInformation_CallsRepositoryMethod()
        {
            //Arrange
            var userId = Guid.NewGuid();   
            var listOfPersonalInformationDto = new GetPersonalInformationDto();
            var personalInformationServiceMock = new Mock<IPersonalInformationRepository>();
            personalInformationServiceMock.Setup(rep => rep.GetPersonalInformationById(userId)).Returns(Task.FromResult(new PersonalInformation
            {
                FirstName = "fakefirstname",
                LastName = "fakelastname",
                Email = "email@email.com",
                PersonalCode = 111,
                TelNumber = 222,
                Address = new Address
                {
                    City = "fakecity",
                    Street = "fakestreet",
                    ApartmentNumber = 1,
                    BuildingNumber = 2
                }
            })); ;

            var service = new PersonalInformationService(personalInformationServiceMock.Object);

            //Act
            var result = await service.GetPersonalInformation(userId);

            //Assert 
            Assert.IsType<GetPersonalInformationDto>(result);
            Assert.Equal("fakefirstname", result.FirstName);
            Assert.Equal("fakelastname", result.LastName);
            Assert.Equal("email@email.com", result.Email);
            Assert.Equal(111, result.PersonalCode);
            Assert.Equal(222, result.TelNumber);
            Assert.Equal("fakecity", result.City);
            Assert.Equal("fakestreet", result.Street);
            Assert.Equal(1, result.ApartmentNumber);
            Assert.Equal(2, result.BuildingNumber);
        }

        [Fact]
        public async Task UpdatePesonalInformation_PersonalCode_CallsRepositoryMethod()
        {
            //Arrange
            var personalInformationDto = new UpdatePersonalInformationPersonalCodeDto()
            {
                PersonalCode = 39607125587,
                UserId = Guid.NewGuid(),
            };
            var personalInformationServiceMock = new Mock<IPersonalInformationRepository>();
            personalInformationServiceMock.Setup(rep => rep.UpdatePersonalCode(personalInformationDto));

            var service = new PersonalInformationService(personalInformationServiceMock.Object);

            //Act
            await service.UpdatePersonalInformationPersonalCode(personalInformationDto);

            //Assert
            personalInformationServiceMock.Verify(rep => rep.UpdatePersonalCode(It.IsAny< UpdatePersonalInformationPersonalCodeDto>()), Times.Once);
        }

        [Theory]
        [InlineData(111,null)]
        public async Task UpdatePesonalInformation_PersonalCode_InvalidDto_ThrowsHttpStatusException(int personalCode, Guid userId)
        {
            //Arrange
            var personalInformationDto = new UpdatePersonalInformationPersonalCodeDto()
            {
                PersonalCode = personalCode,
                UserId = userId,
            };
            var personalInformationServiceMock = new Mock<IPersonalInformationRepository>();
            personalInformationServiceMock.Setup(rep => rep.UpdatePersonalCode(personalInformationDto));

            var service = new PersonalInformationService(personalInformationServiceMock.Object);

            //Act && Assert
            await Assert.ThrowsAsync<HttpStatusException>(() => service.UpdatePersonalInformationPersonalCode(personalInformationDto));
        }

        [Fact]
        public async Task UpdatePesonalInformation_Email_CallsRepositoryMethod()
        {
            //Arrange
            var personalInformationDto = new UpdatePersonalInformationEmailDto()
            {
                Email = "email@email.com",
                UserId = Guid.NewGuid(),
            };
            var personalInformationServiceMock = new Mock<IPersonalInformationRepository>();
            personalInformationServiceMock.Setup(rep => rep.UpdatePersonalEmail(personalInformationDto));

            var service = new PersonalInformationService(personalInformationServiceMock.Object);

            //Act
            await service.UpdatePersonalInformationEmail(personalInformationDto);

            //Assert
            personalInformationServiceMock.Verify(rep => rep.UpdatePersonalEmail(It.IsAny<UpdatePersonalInformationEmailDto>()), Times.Once);
        }

        [Theory]
        [InlineData(null, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("email@email.com", null)]
        [InlineData("email@email", "5356E631-836E-4431-A412-0544889A0D99")]
        public async Task UpdatePesonalInformation_Email_InvalidDto_ThrowsHttpStatusException(string email, Guid userId)
        {
            //Arrange
            var personalInformationDto = new UpdatePersonalInformationEmailDto()
            {
                Email = email,
                UserId = userId,
            };
            var personalInformationServiceMock = new Mock<IPersonalInformationRepository>();
            personalInformationServiceMock.Setup(rep => rep.UpdatePersonalEmail(personalInformationDto));

            var service = new PersonalInformationService(personalInformationServiceMock.Object);

            //Act && Assert
            await Assert.ThrowsAsync<HttpStatusException>(() => service.UpdatePersonalInformationEmail(personalInformationDto));
        }

        [Fact]
        public async Task UpdatePesonalInformation_FirstName_CallsRepositoryMethod()
        {
            //Arrange
            var personalInformationDto = new UpdatePersonalInformationFirstNameDto()
            {
                FirstName = "fakeFirstName",
                UserId = Guid.NewGuid(),
            };
            var personalInformationServiceMock = new Mock<IPersonalInformationRepository>();
            personalInformationServiceMock.Setup(rep => rep.UpdatePersonalFirstName(personalInformationDto));

            var service = new PersonalInformationService(personalInformationServiceMock.Object);

            //Act
            await service.UpdatePersonalInformationFirstName(personalInformationDto);

            //Assert
            personalInformationServiceMock.Verify(rep => rep.UpdatePersonalFirstName(It.IsAny<UpdatePersonalInformationFirstNameDto>()), Times.Once);
        }

        [Theory]
        [InlineData(null, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("fakeFirstName", null)]
        [InlineData("fakeFirst21Name", "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("fakeFi#$rstName", "5356E631-836E-4431-A412-0544889A0D99")]
        public async Task UpdatePesonalInformation_FirstName_InvalidDto_ThrowsHttpStatusException(string firstName, Guid userId)
        {
            //Arrange
            var personalInformationDto = new UpdatePersonalInformationFirstNameDto()
            {
                FirstName = firstName,
                UserId = userId,
            };
            var personalInformationServiceMock = new Mock<IPersonalInformationRepository>();
            personalInformationServiceMock.Setup(rep => rep.UpdatePersonalFirstName(personalInformationDto));

            var service = new PersonalInformationService(personalInformationServiceMock.Object);

            //Act && Assert
            await Assert.ThrowsAsync<HttpStatusException>(() => service.UpdatePersonalInformationFirstName(personalInformationDto));
        }

        [Fact]
        public async Task UpdatePesonalInformation_LastName_CallsRepositoryMethod()
        {
            //Arrange
            var personalInformationDto = new UpdatePersonalInformationLastNameDto()
            {
                LastName = "fakeLastName",
                UserId = Guid.NewGuid(),
            };
            var personalInformationServiceMock = new Mock<IPersonalInformationRepository>();
            personalInformationServiceMock.Setup(rep => rep.UpdatePersonalLastName(personalInformationDto));

            var service = new PersonalInformationService(personalInformationServiceMock.Object);

            //Act
            await service.UpdatePersonalInformationLastName(personalInformationDto);

            //Assert
            personalInformationServiceMock.Verify(rep => rep.UpdatePersonalLastName(It.IsAny<UpdatePersonalInformationLastNameDto>()), Times.Once);
        }

        [Theory]
        [InlineData(null, "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("fakeLastName", null)]
        [InlineData("fakeLa23stName", "5356E631-836E-4431-A412-0544889A0D99")]
        [InlineData("fakeLa$stName", "5356E631-836E-4431-A412-0544889A0D99")]
        public async Task UpdatePesonalInformation_LastName_InvalidDto_ThrowsHttpStatusException(string lastName, Guid userId)
        {
            //Arrange
            var personalInformationDto = new UpdatePersonalInformationLastNameDto()
            {
                LastName = lastName,
                UserId = userId,
            };
            var personalInformationServiceMock = new Mock<IPersonalInformationRepository>();
            personalInformationServiceMock.Setup(rep => rep.UpdatePersonalLastName(personalInformationDto));

            var service = new PersonalInformationService(personalInformationServiceMock.Object);

            //Act && Assert
            await Assert.ThrowsAsync<HttpStatusException>(() => service.UpdatePersonalInformationLastName(personalInformationDto));
        }

        [Fact]
        public async Task UpdatePesonalInformation_TelNumber_CallsRepositoryMethod()
        {
            //Arrange
            var personalInformationDto = new UpdatePersonalInformationTelNumberDto()
            {
                TelNumber = 111,
                UserId = Guid.NewGuid(),
            };
            var personalInformationServiceMock = new Mock<IPersonalInformationRepository>();
            personalInformationServiceMock.Setup(rep => rep.UpdatePersonalTelNumber(personalInformationDto));

            var service = new PersonalInformationService(personalInformationServiceMock.Object);

            //Act
            await service.UpdatePersonalInformationTelNumber(personalInformationDto);

            //Assert
            personalInformationServiceMock.Verify(rep => rep.UpdatePersonalTelNumber(It.IsAny<UpdatePersonalInformationTelNumberDto>()), Times.Once);
        }

        [Theory]
        [InlineData(111, null)]
        public async Task UpdatePesonalInformation_TelNumber_InvalidDto_ThrowsHttpStatusException(int telNumber, Guid userId)
        {
            //Arrange
            var personalInformationDto = new UpdatePersonalInformationTelNumberDto()
            {
                TelNumber = telNumber,
                UserId = userId,
            };
            var personalInformationServiceMock = new Mock<IPersonalInformationRepository>();
            personalInformationServiceMock.Setup(rep => rep.UpdatePersonalTelNumber(personalInformationDto));

            var service = new PersonalInformationService(personalInformationServiceMock.Object);

            //Act && Assert
            await Assert.ThrowsAsync<HttpStatusException>(() => service.UpdatePersonalInformationTelNumber(personalInformationDto));
        }
    }
}
