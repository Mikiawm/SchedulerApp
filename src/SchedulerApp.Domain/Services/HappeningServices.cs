using SchedulerApp.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Domain.Services
{
    public interface IHappeningService
    {
        IEnumerable<Happening> GetHappenings(string name = null);
        Happening GetHappening(int id);
        Happening GetHappening(string name);
        bool CreateHappening(Happening contact);
        void SaveHappening();
        void CreateHappening(string name, string phoneNumber, string adress);
        void CreateHappening(DateTime dateFrom, DateTime dateTo, string name);
        void CreateHappening(DateTime dateFrom, DateTime dateTo);
        void EditHappening(Happening contact, string name);
    }
    public class HappeningServices : IHappeningService
    {
        public bool CreateHappening(Happening contact)
        {
            throw new NotImplementedException();
        }

        public void CreateHappening(DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
        }

        public void CreateHappening(DateTime dateFrom, DateTime dateTo, string name)
        {
            throw new NotImplementedException();
        }

        public void CreateHappening(string name, string phoneNumber, string adress)
        {
            throw new NotImplementedException();
        }

        public void EditHappening(Happening contact, string name)
        {
            throw new NotImplementedException();
        }

        public Happening GetHappening(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Happening> GetHappening(string name = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Happening> GetHappenings(string name = null)
        {
            throw new NotImplementedException();
        }

        public void SaveHappening()
        {
            throw new NotImplementedException();
        }

        Happening IHappeningService.GetHappening(string name)
        {
            throw new NotImplementedException();
        }
    }
}
