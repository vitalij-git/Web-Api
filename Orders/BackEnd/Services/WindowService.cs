using BackEnd.ErrorResponseModel;
using BackEnd.Models;
using BackEnd.Models.Dto;
using BackEnd.Models.Dto.SubElement;
using BackEnd.Models.Dto.Window;
using BackEnd.Repository;
using System.Net;

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
            if(string.IsNullOrEmpty(windowDto.Name))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Name cannot be empty");
            }
            if(windowDto.QuantityOfWindows == null)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Quantity of windows cannot be empty");
            }
            else if (windowDto.OrderId == null || windowDto.OrderId == 0)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Order id cannot be empty");
            }
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
            if(windowId == 0 && windowId == null)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Id cannot be null or zero");
            }
                await _windowRepository.DeleteWindow(windowId);
        }

        public async Task<GetWindowDto> GetWindow(int windowId)
        {
            if (windowId == 0 || windowId == null)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Id cannot be null or zero");
            }
           
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
