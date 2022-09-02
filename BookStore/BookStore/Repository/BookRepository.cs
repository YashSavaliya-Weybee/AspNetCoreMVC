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
                new BookModel(){ID=1,Title="MVC",Author="Yash", Description="This is the description for MVC book",Category="Programming",Language="English",TotalPages=134},
                new BookModel(){ID=2,Title="Dot Net Core",Author="Yash", Description="This is the description for Dot Net Core book",Category="Framework",Language="Hindi",TotalPages=265},
                new BookModel(){ID=3,Title="C#",Author="Yash", Description="This is the description for C# book",Category="Developer",Language="English",TotalPages=576},
                new BookModel(){ID=4,Title="Java",Author="Monika", Description="This is the description for Java book",Category="Concept",Language="Hindi",TotalPages=841},
                new BookModel(){ID=5,Title="PHP",Author="Yash", Description="This is the description for PHP book",Category="Programming",Language="English",TotalPages=356},
                new BookModel(){ID=6,Title="HTML",Author="Nitish", Description="This is the description for HTML book",Category="DevOps",Language="English",TotalPages=426}
            };
        }
    }
}
