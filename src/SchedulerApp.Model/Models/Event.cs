using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Model.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Location Location { get; set; }
        public virtual List<Employee> Employees { get; set; }
        public Event()
        {
            DateCreated = DateTime.Now;
        }
    }
}
