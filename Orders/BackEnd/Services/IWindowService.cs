using BackEnd.Models;
using BackEnd.Models.Dto.Window;

namespace BackEnd.Services
{
    public interface IWindowService
    {
        public Task CreateWindow(WindowDto windowDto);
        public Task<IList<GetWindowDto>> GetWindows();
        public Task<GetWindowDto> GetWindow(int windowId);
        public Task DeleteWindow(int windowId);
    }
}