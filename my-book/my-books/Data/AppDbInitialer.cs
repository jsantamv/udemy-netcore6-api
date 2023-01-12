using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Linq;

namespace my_books.Data
{
    public class AppDbInitialer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books .Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st Book Titile",
                        Description = "Firs Book on library",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-11),
                        Rate = 4,
                        Genere = "Biography",
                        Author = "John Santmary",
                        CoverUrl = "helloworld.com",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "2st Book Titile",
                        Description = "Second Book on library",
                        IsRead = false,
                        Genere = "Suspense",
                        Author = "John Santmary",
                        CoverUrl = "helloworldw.com",
                        DateAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
