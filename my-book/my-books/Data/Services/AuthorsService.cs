using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Linq;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        private readonly AppDbContext _context;

        public AuthorsService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Add(AuthorVM author)
        {
            Author _author = new()
            {
                Name = author.Name
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBookVM GetAuthorWithBookVM(int authorId)
        {
            var author = _context.Authors.Where(n => n.Id == authorId)
                .Select(n => new AuthorWithBookVM()
                {
                    Name = n.Name,
                    BookTitles = n.Book_Authors.Select(n => n.Book.Title).ToList()
                }).FirstOrDefault();

            return author;
        }
    }
}
