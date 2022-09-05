using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                Title = model.Title,
                Description = model.Description,
                Language = model.Language,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.ID;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var getAllBook = await _context.Books.ToListAsync();
            if (getAllBook?.Any() == true)
            {
                foreach (var book in getAllBook)
                {
                    books.Add(new BookModel()
                    {
                        ID = book.ID,
                        Category = book.Category,
                        Title = book.Title,
                        Author = book.Author,
                        Language = book.Language,
                        Description = book.Description,
                        TotalPages = book.TotalPages
                    });
                }
            }
            return books;
        }
        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    ID = book.ID,
                    Category = book.Category,
                    Title = book.Title,
                    Author = book.Author,
                    Language = book.Language,
                    Description = book.Description,
                    TotalPages = book.TotalPages
                };
                return bookDetails;
            }
            return null;
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
