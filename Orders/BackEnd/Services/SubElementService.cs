using BackEnd.Models;
using BackEnd.Models.Dto.SubElement;
using BackEnd.Repository;

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
            await _SubElementRepository.DeleteSubElement(subElementId);
        }

        public async Task<SubElement> GetSubElement(int subElementId)
        {
            return await _SubElementRepository.GetSubElement(subElementId);
        }

        public async Task<IList<SubElement>> GetSubElements()
        {
            return await _SubElementRepository.GetSubElements();
        }
    }
}
