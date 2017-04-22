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
        private readonly IContactService contactService;

        public HomeController(IContactService contactService)
        {
            this.contactService = contactService;
        }
        public IActionResult Index()
        {
            if(contactService == null)
            {
                throw new ArgumentNullException("contacService");
            }
            var contacts = ContactViewModel.DisplayContacts(contactService.GetContacts());
            ViewData["Message"] = "Your contact page.";
            if (contacts != null)
            {
                return View();
            }
            else
            {
                return View();
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [Route("contacts")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public JsonResult Contacts()
        {
            IEnumerable<Contact> contacts;
            contacts = contactService.GetContacts();
            ViewData["Message"] = "Your contact page.";

            if(contacts != null)
            {
                return Json(ContactViewModel.DisplayContacts(contacts).ToArray());
            }
            else
            {
                return Json("");
            }
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
