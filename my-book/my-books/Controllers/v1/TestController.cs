using Microsoft.AspNetCore.Mvc;

namespace my_books.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiVersion("1.2")]
    [ApiVersion("1.9")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet("GetData")]
        public IActionResult GetV1()
        {
            return Ok("This test v1");
        }

        [HttpGet("GetData"), MapToApiVersion("1.2")]
        public IActionResult GetV2()
        {
            return Ok("This test v1.2");
        }

        [HttpGet("GetData"), MapToApiVersion("1.9")]
        public IActionResult GetV9()
        {
            return Ok("This test v1.9");
        }
    }
}
