using SchedulerApp.Data.Configuration;
using SchedulerApp.Data.Infrastructure;
using SchedulerApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Domain.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetContacts(string name = null);
        Contact GetContact(int id);
        Contact GetContact(string name);
        void CreateContact(Contact contact);
        void SaveContact();
    }

    public class ContactServices : IContactService
    {
        private readonly IContactRepository contactRepository;

        public ContactServices(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public ContactServices()
        {

        }
        public void CreateContact(Contact contact)
        {
            contactRepository.Add(contact);
        }

        public Contact GetContact(string name = null)
        {
            var contact = contactRepository.GetContactByName(name);
            return contact;
        }

        public Contact GetContact(int id)
        {
            var contact = contactRepository.GetById(id);
            return contact;
        }

        public IEnumerable<Contact> GetContacts(string name = null)
        {
            if(string.IsNullOrEmpty(name))
            {
                return contactRepository.GetAll();
            }
            else
            {
                return contactRepository.GetAll().Where(c => c.Name == name);
            }
        }

        public void SaveContact()
        {
            throw new NotImplementedException();
        }
    }
}
