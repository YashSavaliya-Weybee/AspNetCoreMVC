using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        [Route("book-details/{id}", Name = "bookDetailsRoute")]

        public async Task<ViewResult> GetBook(int id)
        {
            var book = await _bookRepository.GetBookById(id);
            return View(book);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            //ViewBag.language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text = "English", Value = "1"},
            //    new SelectListItem(){Text = "Hindi", Value = "2"},
            //    new SelectListItem(){Text = "Gujarati", Value = "3"},
            //    new SelectListItem(){Text = "Tamil", Value = "4"},
            //    new SelectListItem(){Text = "Urdu", Value = "5"},
            //    new SelectListItem(){Text = "Chinese", Value = "6"}
            //};

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }

            }

            //ViewBag.language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text = "English", Value = "1"},
            //    new SelectListItem(){Text = "Hindi", Value = "2"},
            //    new SelectListItem(){Text = "Gujarati", Value = "3"},
            //    new SelectListItem(){Text = "Tamil", Value = "4"},
            //    new SelectListItem(){Text = "Urdu", Value = "5"},
            //    new SelectListItem(){Text = "Chinese", Value = "6"}
            //};

            ViewBag.language = new SelectList(GetLanguage(), "id", "Text");
            return View();
        }

        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel(){id = 1, Text = "Hindi"},
                new LanguageModel(){id = 2, Text = "Gujarati"},
                new LanguageModel(){id = 3, Text = "English"},
            };
        }

    }
}
