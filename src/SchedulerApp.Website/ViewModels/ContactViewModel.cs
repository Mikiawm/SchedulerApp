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


        public static IEnumerable<ContactViewModel> DisplayContacts(IEnumerable<Contact> contacts)
        {
            List<ContactViewModel> returnValue = new List<ContactViewModel>();
            foreach (var item in contacts)
            {
                ContactViewModel temp = null;
                temp.Name = item.Name;
                temp.PhoneNumber = item.PhoneNumber;
                temp.Adress = item.Adress;
                returnValue.Add(temp);
            }
            return returnValue;
        }
    }
}
