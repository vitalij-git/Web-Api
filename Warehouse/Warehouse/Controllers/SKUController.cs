using Microsoft.AspNetCore.Mvc;

namespace WarehouseStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SKUController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
