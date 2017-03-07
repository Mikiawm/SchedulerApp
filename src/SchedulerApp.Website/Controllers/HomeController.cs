using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchedulerApp.Data.Configuration;
using SchedulerApp.Domain.Services;
using SchedulerApp.Website.ViewModels;

namespace SchedulerApp.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactService contactServices;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {

            var contacts = contactServices.GetContacts();
            ViewData["Message"] = "Your contact page.";
            
            return View(ContactViewModel.DisplayContacts(contacts));
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
