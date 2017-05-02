using SchedulerApp.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Data.Configuration
{
    public class Contact
    {
        public Contact(string name, string phoneNumber, string adress)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Adress = adress;
        }
        public Contact()
        {

        }
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public DateTime DateUpdated { get; internal set; }

        public interface IContact: IRepository<Contact>
        {
            Contact GetCategoryByName(string categoryName);
        }
    }
}
