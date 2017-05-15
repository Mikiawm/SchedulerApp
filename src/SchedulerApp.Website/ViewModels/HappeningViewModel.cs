﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchedulerApp.Data.Configuration;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SchedulerApp.Website.ViewModels
{
    public class HappeningViewModel
    {
        public int? EventId { get; set; }
        public string Name { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }


        public HappeningViewModel()
        {
            EventId = 0;
            Name = "BasicConstructor";
            DateFrom = DateTime.Today;
            DateTo = DateTime.Today.AddDays(1);
        }

        public HappeningViewModel(int? id, string name, DateTime dateFrom, DateTime dateTo)
        {
            EventId = id;
            Name = name;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        public HappeningViewModel(DateTime dateFrom, DateTime dateTo)
        {
            Name = "Custom";
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
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