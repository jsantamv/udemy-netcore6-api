using my_books.Data.Models;
using System.Collections.Generic;

namespace my_books.Data.ViewModels
{
    public class AuthorVM
    {
        public string Name { get; set; }

    }

    public class AuthorWithBookVM
    {
        public string Name { get; set; }
        public List<string> BookTitles { get; set; }
     }

    
}