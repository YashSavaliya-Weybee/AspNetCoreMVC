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
            //ViewBag.language = GetLanguage().Select(x => new SelectListItem()
            //{
            //    Text = x.Text,
            //    Value = x.id.ToString()
            //}).ToList();

            var group1 = new SelectListGroup() { Name = "Group 1" };
            var group2 = new SelectListGroup() { Name = "Group 2" };
            var group3 = new SelectListGroup() { Name = "Group 3" };

            ViewBag.language = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "English", Value = "1", Group = group1},
                new SelectListItem(){Text = "Hindi", Value = "2", Group = group2},
                new SelectListItem(){Text = "Gujarati", Value = "3", Group = group2},
                new SelectListItem(){Text = "Tamil", Value = "4", Group = group1},
                new SelectListItem(){Text = "Urdu", Value = "5", Group = group3},
                new SelectListItem(){Text = "Chinese", Value = "6", Group = group3}
            };


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
            ViewBag.language = new SelectList(GetLanguage(), "id", "Text");
            //ModelState.AddModelError("", "This is my custom error message");
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
