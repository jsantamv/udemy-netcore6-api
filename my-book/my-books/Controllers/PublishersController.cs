using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using my_books.Data.Models;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using my_books.Exceptions;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : Controller
    {

        private PublishersService publishersService;
        private readonly ILogger<PublishersController> logger;

        public PublishersController(PublishersService publishersService, ILogger<PublishersController> logger)
        {
            this.publishersService = publishersService;
            this.logger = logger;
        }


        [HttpGet("getAll")]
        public IActionResult GetAllPublisher(string sortBy, string searchString, int pageNumber)
        {
            try
            {
                logger.LogInformation("This is just a log in ...");
                var restul = publishersService.GetAllPublisher(sortBy, searchString, pageNumber);
                return Ok(restul);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("add")]
        public IActionResult Add([FromBody] PublishersVM publishersVM)
        {
            try
            {
                var newPublisher = publishersService.Add(publishersVM);
                // return Ok(publishersVM);
                return Created(nameof(Add), newPublisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher name: {ex.PublisherName}");
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        [HttpGet("GetPublisherById/{id}")]
        public ActionResult<Publisher> GetPublisherById(int id)
        {
            // throw new Exception("This is an exeption that will be handled by middleware");

            var _response = publishersService.GetPublisherById(id);
            if (_response != null)
                return Ok(_response);
            else
                return NotFound();
        }

        [HttpGet("GetPublisherBookWithAuthors/{id}")]
        public IActionResult GetPublisherBookWithAuthors(int id)
        {
            var _response = publishersService.GetPublisherData(id);
            if (_response != null)
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
