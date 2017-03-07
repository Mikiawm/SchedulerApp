using SchedulerApp.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Website.ViewModels
{
    public class ContactViewModel
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

    }
}
