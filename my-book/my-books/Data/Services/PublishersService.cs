using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Linq;

namespace my_books.Data.Services
{
    public class PublishersService
    {
        private readonly AppDbContext _context;

        public PublishersService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Add(PublishersVM publisher)
        {
            Publisher _publisher = new()
            {
                Name = publisher.Name
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public PublishersBooksWithAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisher = _context.Publishers.Where(x => x.Id == publisherId)
            .Select(n => new PublishersBooksWithAuthorsVM(){
                Name = n.Name,
                BookAuthors = n.Books.Select(x => new BookAuthorVM() 
                {
                    BookName = x.Title,
                    BookAuthors = x.Book_Authors.Select(n => n.Author.Name).ToList()
                }).ToList()
            }).FirstOrDefault();

            return _publisher;
        }

        public void DeletePublisherById(int id)
        {
            var publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);

            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
        }
    }
}
