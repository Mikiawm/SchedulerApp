using SchedulerApp.Data.Configuration;
using SchedulerApp.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SchedulerApp.Data.Repositories
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public void Add(Contact entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<Contact, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(Contact entity)
        {
            throw new NotImplementedException();
        }

        public Contact Get(Expression<Func<Contact, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Event GetEventByName(string eventName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetMany(Expression<Func<Contact, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(Contact entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact> IRepository<Contact>.GetAll()
        {
            throw new NotImplementedException();
        }

        Contact IRepository<Contact>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

    internal interface IEventRepository : IRepository<Contact>
    {
        Event GetEventByName(string eventName);
    }
}
