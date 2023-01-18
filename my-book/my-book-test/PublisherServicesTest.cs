using Microsoft.EntityFrameworkCore;
using my_books.Data;
using my_books.Data.Models;
using my_books.Data.Services;
using NUnit.Framework;

namespace my_book_test
{
    public class Tests
    {

        private static DbContextOptions<AppDbContext> dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "BookDbTest")
            .Options;


        AppDbContext context;
        PublishersService publishersService;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new AppDbContext(dbContextOptions);
            context.Database.EnsureCreated();
            SeeDatabase();
            publishersService = new PublishersService(context);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }
        private void SeeDatabase()
        {
            List<Publisher> publisher = new()
            {
                new Publisher()
                {
                    Id= 1,
                    Name = "Publisher 1"
                },
                new Publisher()
                {
                    Id= 2,
                    Name = "Publisher 2"
                },
                new Publisher()
                {
                    Id= 3,
                    Name = "Publisher 3"
                },
            };

            context.Publishers.AddRange(publisher);


            List<Author> author = new()
            {
                new Author()
                {
                    Id= 1,
                    Name = "Author 1"
                },
                new Author()
                {
                    Id= 2,
                    Name = "Author 2"
                },
                new Author()
                {
                    Id= 3,
                    Name = "Author 3"
                },
            };

            context.Authors.AddRange(author);


            List<Book> books = new()
            {
                new Book()
                {
                    Title = "1st Book Titile",
                    Description = "Firs Book on library",
                    IsRead = true,
                    DateRead = DateTime.Now.AddDays(-11),
                    Rate = 4,
                    Genere = "Biography",
                    CoverUrl = "helloworld.com",
                    DateAdded = DateTime.Now,
                    PublisherId = 1
                },
                new Book()
                {
                    Title = "2st Book Titile",
                    Description = "Second Book on library",
                    IsRead = false,
                    Genere = "Suspense",
                    CoverUrl = "helloworldw.com",
                    DateAdded = DateTime.Now,
                    PublisherId = 2
                }
            };

            context.Books.AddRange(books);

            List<Book_Author> book_author = new()
            {
                new Book_Author()
                {
                    Id= 1,
                    BookId = 1,
                    AuthorId =1
                },

                new Book_Author()
                {
                    Id= 2,
                    BookId = 2,
                    AuthorId =2
                },

                new Book_Author()
                {
                    Id= 3,
                    BookId = 3,
                    AuthorId = 3
                },
            };

            context.Book_Authors.AddRange(book_author);

        }

        [Test]
        public void GetAllPublisher_WithNo_SortBy_SearchString_and_pageNumber()
        {
            var result = publishersService.GetAllPublisher(string.Empty, string.Empty, null);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(3, Is.EqualTo(result.Count()));
        }
    }
}