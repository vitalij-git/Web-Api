using BackEnd.ErrorResponseModel;
using BackEnd.Models;
using BackEnd.Models.Dto.SubElement;
using BackEnd.Repository;
using System.Net;

namespace BackEnd.Services
{
    public class SubElementService : ISubElementService
    {
        private readonly ISubElementRepository _SubElementRepository;

        public SubElementService(ISubElementRepository subElementRepository)
        {
            _SubElementRepository = subElementRepository;
        }

        public async Task CreateSubElement(SubElementDto subElementDto)
        {
            if (string.IsNullOrEmpty(subElementDto.Type))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Type cannot be empty");
            }
            else if (subElementDto.Width == null)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Width cannot be empty");
            }
            else if (subElementDto.Height == null)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Height cannot be empty");
            }
            else if (subElementDto.Element == null)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Element cannot be empty");
            }
            else if (subElementDto.WindowId == null || subElementDto.WindowId == 0)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Window id cannot be empty");
            }

            var subElement = new SubElement()
            {
                Type = subElementDto.Type,
                Width = subElementDto.Width,
                Height = subElementDto.Height,
                Element = subElementDto.Element,
                WindowId = subElementDto.WindowId,
            };
            await _SubElementRepository.CreateSubElement(subElement);
        }

        public async Task DeleteSubElement(int subElementId)
        {
            if(subElementId == null && subElementId == 0)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Id cannot be null or zero");
                
            }
                await _SubElementRepository.DeleteSubElement(subElementId);
        }

        public async Task<SubElement> GetSubElement(int subElementId)
        {
            if (subElementId == null && subElementId == 0)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Id cannot be null or zero");
                
            }
                return await _SubElementRepository.GetSubElement(subElementId);

        }

        public async Task<IList<SubElement>> GetSubElements()
        {
            return await _SubElementRepository.GetSubElements();
        }
    }
}
