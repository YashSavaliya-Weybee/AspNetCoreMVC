using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string CustomProperty { get; set; }
        [ViewData]
        public string Title { get; set; }
        [ViewData]
        public BookModel Book { get; set; }
        public ViewResult Index()
        {
            CustomProperty = "custom Value";
            Title = "Home page from controller";
            Book = new BookModel() { ID = 2, Title = "Asp.Net Core Tutorial" };

            //ViewData--------------------------------------------------------------
            //ViewData["Property1"] = "Yash Savaliya";

            //ViewData["book"] = new BookModel() { Author = "Yash", ID = 1 };

            //ViewBag---------------------------------------------------------------
            //ViewBag.Title = "Yash";

            //dynamic data = new ExpandoObject();
            //data.Id = 1;
            //data.Name = "Yash";

            //ViewBag.Data = data;

            //ViewBag.Type = new BookModel() { ID = 5, Author = "Author" };

            return View();
        }
        public ViewResult AboutUs()
        {
            Title = "About Us page from controller";
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
