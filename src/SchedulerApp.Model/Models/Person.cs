using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Model.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

        public Person(string name, string phoneNumber, string adress)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Adress = adress;
        }
    }
}
