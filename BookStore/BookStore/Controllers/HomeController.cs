using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewBookAlertConfig _newBookAlertConfiguration;

        public HomeController(IOptions<NewBookAlertConfig> newBookAlertConfiguration)
        {
            _newBookAlertConfiguration = newBookAlertConfiguration.Value;
        }

        public ViewResult Index()
        {
            bool isDisplay = _newBookAlertConfiguration.DisplayNewBookAlert;

            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
