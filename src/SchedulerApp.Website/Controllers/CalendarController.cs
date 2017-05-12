using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchedulerApp.Website.ViewModels;
using SchedulerApp.Domain.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SchedulerApp.Website.Controllers
{
    public class CalendarController : Controller
    {
        private readonly IHappeningService happeningService;

        public CalendarController(IHappeningService happeningService)
        {
            this.happeningService = happeningService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [Route("Calendar/json")]
        public IActionResult Calendar()
        {
            Dictionary<string, string> returnDic = new Dictionary<string, string>();
            returnDic.Add("TodayDay", DateTime.Now.Day.ToString());
            returnDic.Add("TodayMonth", DateTime.Now.Month.ToString());
            returnDic.Add("TodayYear", DateTime.Now.Year.ToString());  
            return Json(returnDic);
        }

        [Route("Calendar/SaveEvent")]
        [HttpPost]
        public IActionResult SaveEvent(string happeningDays)
        {
            var happeningDaysTab = happeningDays.Split(',');
            var x = happeningDaysTab.First();
            Console.WriteLine(happeningDaysTab.First());
            DateTime dateFrom = DateTime.ParseExact(happeningDaysTab.First(), "yyyy-M-dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime dateTo = DateTime.ParseExact(happeningDaysTab.Last(), "yyyy-M-dd", System.Globalization.CultureInfo.InvariantCulture);
            HappeningViewModel happeningViewMode= new HappeningViewModel(dateFrom, dateTo);

            return View();
        }
        [Route("Calendar/json2")]
        public IActionResult Calendar2()
        {
            return Json(DateTime.Today);
        }
        [Route("Calendar/json3")]
        public IActionResult Calendar3()
        {
            var data = DateTime.Now;
            return Json(data);
        }


    }
}
