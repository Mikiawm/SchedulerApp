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
        private readonly IRepository<Contact> _contactRepository;

        public ContactServices(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public ContactServices()
        {

        }
        public void CreateContact(Contact contact)
        {
            _contactRepository.Add(contact);
        }

        public Contact GetContact(string name = null)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact(int id)
        {
            var contact = _contactRepository.GetById(id);
            return contact;
        }

        public IEnumerable<Contact> GetContacts(string name = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                return _contactRepository.GetAll();
            }
            else
            {
                return _contactRepository.GetAll().Where(c => c.Name == name);
            }
        }

        public void SaveContact()
        {
            throw new NotImplementedException();
        }
    }
}
