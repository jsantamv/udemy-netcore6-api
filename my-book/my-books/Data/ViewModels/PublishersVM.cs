using System.Collections.Generic;

namespace my_books.Data.ViewModels
{
    public class PublishersVM
    {
        public string Name { get; set; }
    }

    public class PublishersBooksWithAuthorsVM
    {
        public string Name { get; set; }
        public List<BookAuthorVM> BookAuthors { get; set; }
    }

    public class BookAuthorVM
    {
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }
    }
}