using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return NotFound();
        }
    }
}
