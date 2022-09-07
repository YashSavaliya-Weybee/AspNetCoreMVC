using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [Route("~/")]
        public ViewResult Index()
        {
            return View();
        }
        //[HttpGet("about-us", Name = "aboutus")]
        public ViewResult AboutUs()
        {
            return View();
        }
        //[Route("contact-us", Name = "contact-us")]
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
