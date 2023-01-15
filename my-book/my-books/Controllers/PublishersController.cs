using System;
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
             var newPublisher = publishersService.Add(publishersVM);
            // return Ok(publishersVM);
            return Created(nameof(Add), newPublisher);
        }


        [HttpGet("GetPublisherById/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _response = publishersService.GetPublisherById(id);
            if(_response != null)
                return Ok(_response);
            else
                return NotFound();
        }

        [HttpGet("GetPublisherBookWithAuthors/{id}")]
        public IActionResult GetPublisherBookWithAuthors(int id)
        {
            var _response = publishersService.GetPublisherData(id);
            if(_response != null)
                return Ok(_response);
            else
                return NotFound();
        }

        [HttpDelete("DeletePublisherById/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                publishersService.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception ex)
            {   
                return BadRequest(ex.Message);
            }
        }

    }
}
