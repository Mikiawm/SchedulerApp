using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Model.Models
{
    public class Location
    {
        public int IdLocation { get; set; }
        public string Adress { get; set; }
        public List<Contact> Contact { get; set; }
        public Location(string adress)
        {
            Adress = adress;
        }
    }
}
