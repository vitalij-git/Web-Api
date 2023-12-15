using FinalProject.BusinessLogic.ErrorResponseModel;
using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Models.Dto.Address;
using FinalProject.Database.Models.Dto.PersonalInformation;
using FinalProject.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject.BusinessLogic.Services
{
    public class PersonalInformationService : IPersonalInformationService 
    {
        private readonly IPersonalInformationRepository _personalInformationRepository;

        public PersonalInformationService(IPersonalInformationRepository personalInformationRepository)
        {
            _personalInformationRepository = personalInformationRepository;
        }

        public async Task AddPersonalInformation(AddPersonalInformationDto personalInformationDto)
        {
            if(string.IsNullOrEmpty(personalInformationDto.FirstName) || string.IsNullOrEmpty(personalInformationDto.LastName) || string.IsNullOrEmpty(personalInformationDto.Email) || personalInformationDto.UserId == Guid.Empty) 
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The request contains an empty or null value");
            }
            if (personalInformationDto.FirstName.Any(char.IsDigit) || ContainsSymbol(personalInformationDto.FirstName) || personalInformationDto.LastName.Any(char.IsDigit) || ContainsSymbol(personalInformationDto.LastName))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The first name and last name should not contain a numerical digit or any symbol. Please enter a valid first name and last name");
            }
            if (personalInformationDto.PersonalCode.ToString().Length != 11)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Invalid personal code length");
            }
            if(!IsValidEmail(personalInformationDto.Email))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Invalid email address.Please enter a valid email");
            }
            var personalInformation = new PersonalInformation() 
            { 
                FirstName = personalInformationDto.FirstName,
                LastName = personalInformationDto.LastName,
                Email = personalInformationDto.Email,
                TelNumber = personalInformationDto.TelNumber,
                PersonalCode = personalInformationDto.PersonalCode,
                CreatedAt = DateTime.Now,
                UserId = personalInformationDto.UserId
            };
            await _personalInformationRepository.AddPersonalInformation(personalInformation);

        }

        public async Task<IList<GetPersonalInformationDto>> GetAllPersonalInformation()
        {
            var listOfPersonalInformation = await _personalInformationRepository.GetAllPersonalInformation();
            var listOfPersonalInformationDto =new List<GetPersonalInformationDto>();
            
            foreach(var personalInformation in listOfPersonalInformation)
            {
                listOfPersonalInformationDto.Add(new GetPersonalInformationDto()
                {
                    PersonalCode = personalInformation.PersonalCode,
                    FirstName = personalInformation.FirstName,
                    LastName = personalInformation.LastName,
                    Email= personalInformation.Email,
                    TelNumber = personalInformation.TelNumber,
                });
            }
            return listOfPersonalInformationDto;
        }

        public async Task<GetPersonalInformationDto> GetPersonalInformation(Guid userId)
        {
            var personalInformation = await _personalInformationRepository.GetPersonalInformationById(userId);
            var personalInformationDto = new GetPersonalInformationDto()
            {
                PersonalCode = personalInformation.PersonalCode,
                FirstName = personalInformation.FirstName,
                LastName = personalInformation.LastName,
                Email = personalInformation.Email,
                TelNumber = personalInformation.TelNumber,
                PersonalInformationId = personalInformation.Id
            };
            if (personalInformation.Address != null) 
            {
                personalInformationDto.City = personalInformation.Address.City;
                personalInformationDto.Street = personalInformation.Address.Street;
                personalInformationDto.ApartmentNumber = personalInformation.Address.ApartmentNumber;
                personalInformationDto.BuildingNumber = personalInformation.Address.BuildingNumber;
            }
            if (personalInformation.Images != null) 
            {
                foreach (var image in personalInformation.Images)
                {
                    personalInformationDto.Images.Add(image.Title, image.Data);
                }
            }
            
            return personalInformationDto;
        }

        public async Task UpdatePersonalInformationPersonalCode(UpdatePersonalInformationPersonalCodeDto updatePersonalInformationPersonalCodeDto)
        {
            if(updatePersonalInformationPersonalCodeDto.UserId == Guid.Empty)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The request contains an empty or null value");
            }
            if (updatePersonalInformationPersonalCodeDto.PersonalCode.ToString().Length != 11)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Invalid personal code length");
            }
            await _personalInformationRepository.UpdatePersonalCode(updatePersonalInformationPersonalCodeDto);
        }

        public async Task UpdatePersonalInformationEmail(UpdatePersonalInformationEmailDto updatePersonalInformationEmailDto)
        {
            if (string.IsNullOrEmpty(updatePersonalInformationEmailDto.Email) || updatePersonalInformationEmailDto.UserId == Guid.Empty)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The request contains an empty or null value");
            }
            if (!IsValidEmail(updatePersonalInformationEmailDto.Email))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Invalid email address.Please enter a valid email");
            }
            await _personalInformationRepository.UpdatePersonalEmail(updatePersonalInformationEmailDto);
        }

        public async Task UpdatePersonalInformationFirstName(UpdatePersonalInformationFirstNameDto updatePersonalInformationFirstNameDto)
        {
            if (string.IsNullOrEmpty(updatePersonalInformationFirstNameDto.FirstName) || updatePersonalInformationFirstNameDto.UserId == Guid.Empty)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The request contains an empty or null value");
            }
            if (updatePersonalInformationFirstNameDto.FirstName.Any(char.IsDigit) || ContainsSymbol(updatePersonalInformationFirstNameDto.FirstName) )
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The first name should not contain a numerical digit or any symbol. Please enter a valid first name");
            }
            await _personalInformationRepository.UpdatePersonalFirstName(updatePersonalInformationFirstNameDto);
        }

        public async Task UpdatePersonalInformationLastName(UpdatePersonalInformationLastNameDto updatePersonalInformationLastNameDto)
        {
            if (string.IsNullOrEmpty(updatePersonalInformationLastNameDto.LastName) || updatePersonalInformationLastNameDto.UserId == Guid.Empty)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The request contains an empty or null value");
            }
            if (updatePersonalInformationLastNameDto.LastName.Any(char.IsDigit) || ContainsSymbol(updatePersonalInformationLastNameDto.LastName))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The last name should not contain a numerical digit or any symbol. Please enter a valid last name");
            }
            await _personalInformationRepository.UpdatePersonalLastName(updatePersonalInformationLastNameDto);
        }

        public async Task UpdatePersonalInformationTelNumber(UpdatePersonalInformationTelNumberDto updatePersonalInformationTelNumberDto)
        {
            if (updatePersonalInformationTelNumberDto.UserId == Guid.Empty)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The request contains an empty or null value");
            }
            await _personalInformationRepository.UpdatePersonalTelNumber(updatePersonalInformationTelNumberDto);
        }

        private bool ContainsSymbol(string input)
        {
            string pattern = @"[^A-Za-z0-9\s]";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
    }
}
