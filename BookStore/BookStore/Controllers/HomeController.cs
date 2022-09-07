﻿using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public ViewResult Index()
        {

            //var newBook = configuration.GetSection("NewBookAlert");
            //var result = newBook.GetValue<bool>("DisplayNewBookAlert");
            //var result2 = newBook.GetValue<string>("BookName");
            //var result1 = newBook["DisplayNewBookAlert"];


            //var result = configuration.GetValue<bool>("NewBookAlert:DisplayNewBookAlert");
            //var result2 = configuration.GetValue<string>("NewBookAlert:BookName");
            //var result1 = configuration["NewBookAlert:DisplayNewBookAlert"];

            //var result = configuration["AppName"];
            //var key1 = configuration["infoObj:key1"];
            //var key2 = configuration["infoObj:key2"];
            //var key3 = configuration["infoObj:key3:key3obj1"];
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
