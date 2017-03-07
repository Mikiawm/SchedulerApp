 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Model.Models
{
    public class Employee : Person
    { 
        public Employee(string name, string phoneNumber, string adress) : base(name, phoneNumber, adress)
        {

        }
    }
}
