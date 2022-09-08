using BookStore.Models;
using BookStore.Repository;
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
        private readonly IMessageRepository _messageRepository;

        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlertConfiguration, IMessageRepository messageRepository)
        {
            _newBookAlertConfiguration = newBookAlertConfiguration.Value;
            _messageRepository = messageRepository;
        }

        public ViewResult Index()
        {
            bool isDisplay = _newBookAlertConfiguration.DisplayNewBookAlert;

            var value = _messageRepository.GetName();

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
