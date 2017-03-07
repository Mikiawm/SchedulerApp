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
 
        public Contact GetContactByName(string contactName)
        {
            var category = this.DbContext.Contacts.Where(c => c.Name == contactName).FirstOrDefault();

            return category;
        }

        public override void Update(Contact entity)
        {
            entity.DateUpdated = DateTime.Now;
            base.Update(entity);
        }
        public override void Add(Contact entity)
        {
            base.Add(entity);
        }
        public override void Delete(Contact entity)
        {
            base.Delete(entity);
        }
        public override Contact GetById(int id)
        {
            return base.GetById(id);
        }
    }

    public interface IContactRepository : IRepository<Contact>
    {
        Contact GetContactByName(string contactName);
    }

}
