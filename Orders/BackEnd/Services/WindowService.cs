using BackEnd.Models;
using BackEnd.Models.Dto;
using BackEnd.Models.Dto.SubElement;
using BackEnd.Models.Dto.Window;
using BackEnd.Repository;

namespace BackEnd.Services
{
    public class WindowService : IWindowService
    {
        private readonly IWindowRepository _windowRepository;

        public WindowService(IWindowRepository windowRepository)
        {
            _windowRepository = windowRepository;
        }

        public async Task CreateWindow(WindowDto windowDto)
        {
            var window = new Window()
            {
                Name = windowDto.Name,
                QuantityOfWindows = windowDto.QuantityOfWindows,
                OrderId = windowDto.OrderId,
            };
            await _windowRepository.CreateWindow(window);
        }

        public async Task DeleteWindow(int windowId)
        {
            await _windowRepository.DeleteWindow(windowId);
        }

        public async Task<GetWindowDto> GetWindow(int windowId)
        {
            var window = await _windowRepository.GetWindow(windowId);

            var getWindowDto = new GetWindowDto()
            {
                Name = window.Name,
                QuantityOfWindows = window.QuantityOfWindows,
                TotalSubElements = window.SubElements.Count
            };
            return getWindowDto;
        }

        public async Task<IList<GetWindowDto>> GetWindows()
        {
            var windows = await _windowRepository.GetWindows();
            var getWindowsDto = new List<GetWindowDto>();    

            foreach (var window in windows)
            {
                var getWindowDto = new GetWindowDto()
                {
                    Id = window.Id,
                    Name = window.Name,
                    QuantityOfWindows = window.QuantityOfWindows,
                    TotalSubElements = window.SubElements.Count,
                };
               
                getWindowsDto.Add(getWindowDto);
            }

            return getWindowsDto;
        }
    }
}
