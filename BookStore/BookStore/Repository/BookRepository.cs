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
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl = model.BookPdfUrl
            };

            newBook.bookGallery = new List<BookGallery>();
            foreach (var file in model.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

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
                        LanguageId = book.LanguageId,
                        Description = book.Description,
                        TotalPages = book.TotalPages,
                        CoverImageUrl = book.CoverImageUrl
                    });
                }
            }
            return books;
        }
        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.ID == id).Select(book => new BookModel()
            {
                ID = book.ID,
                Category = book.Category,
                Title = book.Title,
                Author = book.Author,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                Description = book.Description,
                TotalPages = book.TotalPages,
                CoverImageUrl = book.CoverImageUrl,
                Gallery = book.bookGallery.Select(g => new GalleryModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    URL = g.URL
                }).ToList(),
                BookPdfUrl = book.BookPdfUrl
            }).FirstOrDefaultAsync();
        }
        public List<BookModel> SearchBook()
        {
            return null;
        }

    }
}
