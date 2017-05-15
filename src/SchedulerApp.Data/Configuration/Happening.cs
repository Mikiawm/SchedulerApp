using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Data.Configuration
{
    public class Happening
    {
        public Happening()
        {

        }
        public Happening(string name, DateTime dateFrom, DateTime dateTo)
         {
            Name = name;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
        public int HappeningId { get; set; }
        public string Name { get; set; }
        public string DisplayColor { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Contact Contact { get; set; }
        public Location Location { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
