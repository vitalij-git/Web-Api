using FinalProject.BusinessLogic.ErrorResponseModel;
using FinalProject.BusinessLogic.Models;
using FinalProject.Database.Database;
using FinalProject.Database.Models.Dto.PersonalInformation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Repository
{
    public class PersonalInformationRepository : IPersonalInformationRepository
    {
        private readonly DbContextService _dbContextService;

        public PersonalInformationRepository(DbContextService dbContextService)
        {
            _dbContextService = dbContextService;
        }

        public async Task AddPersonalInformation(PersonalInformation personalInformation)
        {
            _dbContextService.PersonalInformations.Add(personalInformation);
            var result = await _dbContextService.Users.SingleOrDefaultAsync(u => u.Id == personalInformation.UserId);
            if (result == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "The requested User is not found");
            }
            result.PersonalInformationId = personalInformation.Id;
            result.PersonalInformation = personalInformation;
            await _dbContextService.SaveChangesAsync(); 
        }

        public async Task<IList<PersonalInformation>> GetAllPersonalInformation()
        {
           return await _dbContextService.PersonalInformations.ToListAsync();
        }

        public async Task<PersonalInformation> GetPersonalInformationById(Guid userId)
        {
           var personalInformationRequest = await _dbContextService.PersonalInformations.SingleOrDefaultAsync(x => x.UserId == userId);
            if (personalInformationRequest == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "The requested personal information is not found");
            }
            var addressRequest = await _dbContextService.Addresses.SingleOrDefaultAsync(x => x.Id == personalInformationRequest.AddressId);
            var imageRequest = await _dbContextService.Images.SingleOrDefaultAsync(i => i.PersonalInformationId == personalInformationRequest.Id);
            return personalInformationRequest;
        }

        public async Task UpdatePersonalEmail(UpdatePersonalInformationEmailDto updatePersonalInformationEmailDto)
        {
            var request = await GetPersonalInformationForUpdate(updatePersonalInformationEmailDto.UserId);
            request.Email = updatePersonalInformationEmailDto.Email;
            request.UpdatedAt = DateTime.Now;
            await _dbContextService.SaveChangesAsync();
        }

        public async Task UpdatePersonalFirstName(UpdatePersonalInformationFirstNameDto updatePersonalInformationFirstNameDto)
        {
            var request = await GetPersonalInformationForUpdate(updatePersonalInformationFirstNameDto.UserId);
            request.FirstName = updatePersonalInformationFirstNameDto.FirstName;
            request.UpdatedAt = DateTime.Now;
            await _dbContextService.SaveChangesAsync();
        }

        public async Task UpdatePersonalLastName(UpdatePersonalInformationLastNameDto updatePersonalInformationLastNameDto)
        {
            var request = await GetPersonalInformationForUpdate(updatePersonalInformationLastNameDto.UserId);
            request.LastName = updatePersonalInformationLastNameDto.LastName;
            request.UpdatedAt = DateTime.Now;
            await _dbContextService.SaveChangesAsync();
        }

        public async Task UpdatePersonalCode(UpdatePersonalInformationPersonalCodeDto updatePersonalInformationPersonalCodeDto)
        {
            var request = await GetPersonalInformationForUpdate(updatePersonalInformationPersonalCodeDto.UserId);
            request.PersonalCode = updatePersonalInformationPersonalCodeDto.PersonalCode;
            request.UpdatedAt = DateTime.Now;
            await _dbContextService.SaveChangesAsync();
        }

        public async Task UpdatePersonalTelNumber(UpdatePersonalInformationTelNumberDto updatePersonalInformationTelNumberDto)
        {
            var request = await GetPersonalInformationForUpdate(updatePersonalInformationTelNumberDto.UserId);
            request.TelNumber = updatePersonalInformationTelNumberDto.TelNumber;
            request.UpdatedAt = DateTime.Now;
            await _dbContextService.SaveChangesAsync();
        }

        private async Task<PersonalInformation> GetPersonalInformationForUpdate(Guid userId)
        {
            var result = await _dbContextService.PersonalInformations.SingleOrDefaultAsync(x => x.UserId == userId);
            if (result == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "The requested User is not found");
            }
            return result;
        }
    }
}
