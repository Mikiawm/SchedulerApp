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
        bool CreateContact(Contact contact);
        void SaveContact();
        void CreateContact(string name, string phoneNumber, string adress);
        void EditContact(Contact contact, string name);
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
        public bool CreateContact(Contact contact)
        {
            bool contactCreated = true;
            try
            {
                _contactRepository.Add(contact);
            }
            catch
            {
                contactCreated = false;
                throw;
            }
            finally
            {
                Console.WriteLine(contactCreated);
            }
            return contactCreated;
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

        public void CreateContact(string name, string phoneNumber, string adress)
        {
            Contact saveContact = new Contact(name, phoneNumber, adress);
            _contactRepository.Add(saveContact);
        }

        public void EditContact(Contact contact, string name)
        {
            var saveContact = contact;
            contact.Name = name;
            _contactRepository.Update(contact);
        }
    }
}

