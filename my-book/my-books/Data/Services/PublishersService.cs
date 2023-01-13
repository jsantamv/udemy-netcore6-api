using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;

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
    }
}
