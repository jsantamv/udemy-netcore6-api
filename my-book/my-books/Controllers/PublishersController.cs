using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : Controller
    {

        public AuthorsService publishersService;

        public PublishersController(PublishersService publishersService)
        {
            this.publishersService = publishersService;
        }

        [HttpPost("add-book")]
        public IActionResult Add([FromBody] PublishersVM publishersVM)
        {
            publishersService.Add(publishersVM);
            return Ok(publishersVM);
        }

    }
}
