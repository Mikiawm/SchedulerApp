using SchedulerApp.Data.Configuration;
using SchedulerApp.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SchedulerApp.Data.Repositories
{
    public class ContactRepository: RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public void Delete(Expression<Func<Contact, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Contact Get(Expression<Func<Contact, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Contact GetContactByName(string contactName)
        {
            var category = this.DbContext.Contacts.Where(c => c.Name == contactName).FirstOrDefault();

            return category;
        }

        public IEnumerable<Contact> GetMany(Expression<Func<Contact, bool>> where)
        {
            throw new NotImplementedException();
        }

        public override void Update(Contact entity)
        {
            entity.DateUpdated = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IContactRepository : IRepository<Contact>
    {
        Contact GetContactByName(string contactName);
    }

}
