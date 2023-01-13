using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {

        public AuthorsService authorsService;

        public AuthorController(AuthorsService authorsService)
        {
            this.authorsService = authorsService;
        }

        [HttpPost("add-book")]
        public IActionResult Add([FromBody] AuthorVM authorVM)
        {
            authorsService.Add(authorVM);
            return Ok(authorVM);
        }

    }
}
