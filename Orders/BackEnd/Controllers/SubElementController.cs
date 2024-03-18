using BackEnd.Models.Dto.SubElement;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("[Controller]")]
    public class SubElementController : Controller
    {
      private readonly ISubElementService _subElementService;

        public SubElementController(ISubElementService subElementService)
        {
            _subElementService = subElementService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubElement([FromBody] SubElementDto subElementDto)
        {
            await _subElementService.CreateSubElement(subElementDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSubElement([FromHeader] int subElementId)
        {
            await _subElementService.DeleteSubElement(subElementId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetSubElement([FromHeader] int subElementId)
        {
            var element = await _subElementService.GetSubElement(subElementId);
            return Ok(element);
        }

        [Route("SubElements")]
        [HttpGet]
        public async Task<IActionResult> GetSubElements()
        {
            var elements = await _subElementService.GetSubElements();
            return Ok(elements);
        }
    }
}
