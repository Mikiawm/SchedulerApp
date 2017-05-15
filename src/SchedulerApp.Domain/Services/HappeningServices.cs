using SchedulerApp.Data.Configuration;
using SchedulerApp.Data.Infrastructure;
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
        bool CreateHappening(Happening happening);
        void SaveHappening();
        void CreateHappening(string name, DateTime dateFrom, DateTime dateTo);
        void CreateHappening(DateTime dateFrom, DateTime dateTo);
        void EditHappening(Happening contact, string name);
    }
    public class HappeningServices : IHappeningService
    {
        private readonly IRepository<Happening> _happeningRepository;
        public HappeningServices(IRepository<Happening> happeningRepository)
        {
            _happeningRepository = happeningRepository;
        }
        public HappeningServices()
        {

        }
        public bool CreateHappening(Happening happening)
        {
            bool happeningCreated = true;
            try
            {
                _happeningRepository.Add(happening);
            }
            catch
            {
                happeningCreated = false;
                throw;
            }
            return happeningCreated;
        }

        public void CreateHappening(DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
        }

        public void CreateHappening(string name, DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
        }

        public void EditHappening(Happening happening, string name)
        {
            var newHappening = happening;
            newHappening.DateCreated = DateTime.Now;
            _happeningRepository.Update(newHappening);
        }

        public Happening GetHappening(int id)
        {
            var happening = _happeningRepository.GetById(id);
            return happening;
        }

        public IEnumerable<Happening> GetHappenings(string name = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                return _happeningRepository.GetAll();
            }
            else
            {
                return _happeningRepository.GetAll().Where(c => c.Name == name);
            }
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
