using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Data.Configuration
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Adress { get; set; }
        public List<Contact> Contact { get; set; }

    }
}
