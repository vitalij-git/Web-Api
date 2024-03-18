using BackEnd.Models.Dto.SubElement;
using BackEnd.Models.Dto.Window;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("[Controller]")]
    public class WindowController : Controller
    {
       private readonly IWindowService _windowService;

        public WindowController(IWindowService windowService)
        {
            _windowService = windowService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWindow([FromBody] WindowDto windowDto)
        {
            await _windowService.CreateWindow(windowDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWindow([FromHeader] int windowId)
        {
            await _windowService.DeleteWindow(windowId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetWindow([FromHeader] int windowId)
        {
            var window = await _windowService.GetWindow(windowId);
            return Ok(window);
        }

        [Route("Windows")]
        [HttpGet]
        public async Task<IActionResult> GetWindows()
        {
            var window = await _windowService.GetWindows();
            return Ok(window);
        }
    }

}
