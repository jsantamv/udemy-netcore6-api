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

        public PublishersService publishersService;

        public PublishersController(PublishersService publishersService)
        {
            this.publishersService = publishersService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] PublishersVM publishersVM)
        {
            publishersService.Add(publishersVM);
            return Ok(publishersVM);
        }

        [HttpGet("GetPublisherBookWithAuthors/{id}")]
        public IActionResult GetPublisherBookWithAuthors(int id)
        {
            var _response = publishersService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpDelete("DeletePublisherById/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            publishersService.DeletePublisherById(id);
            return Ok();
        }

    }
}
