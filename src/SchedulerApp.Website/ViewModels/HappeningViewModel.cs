using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchedulerApp.Data.Configuration;
using System.Globalization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SchedulerApp.Website.ViewModels
{
    public class HappeningViewModel
    {
        public int? EventId { get; set; }
        public string Name { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }


        public HappeningViewModel()
        {
            EventId = 0;
            Name = "BasicConstructor";
            DateFrom = DateTime.Today.ToString("g").Replace('/', '.');
            DateTo = DateTime.Today.AddDays(1).ToString("g").Replace('/', '.');
        }

        public HappeningViewModel(int? id, string name, DateTime dateFrom, DateTime dateTo)
        {
            EventId = id;
            Name = name;
            DateFrom = dateFrom.ToString("dd.M.yyyy", CultureInfo.InvariantCulture);
            DateTo = dateTo.ToString("dd.M.yyyy", CultureInfo.InvariantCulture);
        }

        public HappeningViewModel(DateTime dateFrom, DateTime dateTo)
        {
            Name = "Custom";
            this.DateFrom = dateFrom.ToString("g").Replace('/', '.');
            this.DateTo = dateTo.ToString("g").Replace('/', '.'); 
        }

        internal static List<HappeningViewModel> DisplayHappenings(IEnumerable<Happening> happenings)
        {
            List<HappeningViewModel> returnValue = new List<HappeningViewModel>();
            foreach (var item in happenings)
            {
                HappeningViewModel temp = new HappeningViewModel(item.HappeningId, item.Name, item.DateFrom, item.DateTo);
                returnValue.Add(temp);
            }
            return returnValue;
        }
    }
}
