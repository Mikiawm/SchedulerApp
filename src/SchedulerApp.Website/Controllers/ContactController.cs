using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchedulerApp.Domain.Services;
using SchedulerApp.Data.Configuration;
using SchedulerApp.Website.ViewModels;
//using SchedulerApp.Data.Configuration;
//using SchedulerApp.Website.ViewModels;
//using SchedulerApp.Domain.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SchedulerApp.Website.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }
        // GET: /<controller>/
        [Route("contact/index")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            return View();
        }
        [Route("contacts")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public JsonResult Contacts()
        {
            IEnumerable<Contact> contacts;
            contacts = contactService.GetContacts();
            ViewData["Message"] = "Your contact page.";

            if (contacts != null)
            {
                return Json(ContactViewModel.DisplayContacts(contacts).ToArray());
            }
            else
            {
                return Json("");
            }
        }
        [Route("contact/new")]
        [HttpPost]
        public ActionResult AddContact(string name, string phoneNumber, string adress)
        {
            contactService.CreateContact(name, phoneNumber, adress);
            return Content("Success :)");
        }
        //[Route("contact/new")]
        //[HttpPost]
        //public ActionResult AddContact(ContactViewModel contact)
        //{
        //    contactService.CreateContact(ContactViewModel.CreateContactFromView(contact));
        //    return Content("Success :)");
        //}
        [Route("contact/edit")]
        [HttpPost]
        public ActionResult EditContact(int id, string name)
        {
            var contact = contactService.GetContact(id);
            contactService.EditContact(contact, name);
            return Content("Hello");
        }
    }
}
