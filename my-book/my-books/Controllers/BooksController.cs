using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System.Collections.Generic;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {

        public BooksServices booksServices;

        public BooksController(BooksServices booksServices)
        {
            this.booksServices = booksServices;
        }

        /// <summary>
        /// Add new book
        /// </summary>
        /// <param name="book">bookvm</param>
        /// <returns>book created</returns>
        [HttpPost("addWithAuthors")]
        public IActionResult Add([FromBody] BookVM book)
        {
            booksServices.AddBookWthiAuthors(book);
            return Ok(book);
        }


        [HttpGet("get-all-books")]
        public IActionResult GetBooks()
        {            
            return Ok(booksServices.GetBooks());
        }

        [HttpGet("get-book-id/{id}")]
        public IActionResult GetBookById(int id)
        {   
            return Ok(booksServices.GetBooksById(id));
        }

        [HttpPut("UpdateById/{id}")]
        public IActionResult UpdateById(int id, [FromBody] BookVM book)
        {
            return Ok(booksServices.UpdateById(id, book));

        }

        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteById(int id)
        {
            booksServices.DeleteById(id);
            return Ok();
        }

    }
}
