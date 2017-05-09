using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SchedulerApp.Website.Controllers
{
    public class CalendarController : Controller
    {
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
