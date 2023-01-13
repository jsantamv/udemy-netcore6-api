using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;

namespace my_books.Data.Services
{

    public class BooksServices
    {
        private AppDbContext _context;

        public BooksServices(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void AddBook(BookVM book)
        {
            Book _book = new()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genere = book.Genere,
                CoverUrl = book.CoverUrl,
                Author = book.Author,
                DateAdded = DateTime.Now,
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetBooks() => _context.Books.ToList();

        public Book GetBooksById(int id) => _context.Books.FirstOrDefault(x => x.Id == id);


        public Book UpdateById(int id, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genere = book.Genere;
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }

            return _book;
        }

        public void DeleteById(int id)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }


    }
}
