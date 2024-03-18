using BackEnd.Models;
using System.Threading.Tasks;

namespace BackEnd.Repository
{
    public interface IWindowRepository
    {
        public Task CreateWindow(Window window);
        public Task<IList<Window>> GetWindows();
        public Task<Window> GetWindow(int windowId);
        public Task DeleteWindow(int windowId);
    }
}