using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataDource();
        }
        public BookModel GetBookById(int id)
        {
            return DataDource().Where(x => x.ID == id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title, string AuthorName)
        {
            return DataDource().Where(x => x.Title == title || x.Author == AuthorName).ToList();
        }
        private List<BookModel> DataDource()
        {
            return new List<BookModel>()
            {
                new BookModel(){ID=1,Title="MVC",Author="Yash"},
                new BookModel(){ID=2,Title="Dot Net Core",Author="Yash"},
                new BookModel(){ID=3,Title="C#",Author="Yash"},
                new BookModel(){ID=4,Title="Java",Author="Monika"},
                new BookModel(){ID=5,Title="PHP",Author="Yash"},
                new BookModel(){ID=6,Title="HTML",Author="Nitish"}
            };
        }
    }
}
