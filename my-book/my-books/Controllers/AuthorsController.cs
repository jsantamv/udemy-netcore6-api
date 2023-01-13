using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {
        public AuthorsService authorsService;

        public AuthorsController(AuthorsService authorsService)
        {
            this.authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult Add([FromBody] AuthorVM authorVM)
        {
            authorsService.Add(authorVM);
            return Ok(authorVM);
        }
    }
}
