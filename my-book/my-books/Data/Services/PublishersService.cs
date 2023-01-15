using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;
using my_books.Data.ViewModels;
using my_books.Exceptions;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace my_books.Data.Services
{
    public class PublishersService
    {
        private readonly AppDbContext _context;

        public PublishersService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public Publisher Add(PublishersVM publisher)
        {

            if (StringStartsWithNumber(publisher.Name)) throw new PublisherNameException("Name starts with number", publisher.Name);

            Publisher _publisher = new()
            {
                Name = publisher.Name
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }

        public Publisher GetPublisherById(int id) => _context.Publishers.Find(id);

        public PublishersBooksWithAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisher = _context.Publishers.Where(x => x.Id == publisherId)
            .Select(n => new PublishersBooksWithAuthorsVM()
            {
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
            else
                throw new Exception($" Does not exist id {id}");
        }

        private bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));

    }
}
