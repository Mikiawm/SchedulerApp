﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SchedulerApp.Website.ViewModels
{
    public class EventViewModel
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }


        public EventViewModel()
        {
            EventId = 0;
            Name = "BasicConstructor";
            DateFrom = DateTime.Today;
            DateTo = DateTime.Today.AddDays(1);
        }

        public EventViewModel(int id, string name, DateTime dateFrom, DateTime dateTo)
        {
            EventId = id;
            Name = name;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}
