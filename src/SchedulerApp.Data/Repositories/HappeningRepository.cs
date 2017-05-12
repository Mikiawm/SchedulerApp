using SchedulerApp.Data.Configuration;
using SchedulerApp.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SchedulerApp.Data.Repositories
{
    public class HappeningRepository : RepositoryBase<Happening>, IHappeningRepository
    {
        private readonly SchedulerContext dbContext;
        public HappeningRepository(SchedulerContext dbContext) : base(dbContext)
        {
        }

        public override void Add(Happening entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Expression<Func<Happening, bool>> where)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Happening entity)
        {
            throw new NotImplementedException();
        }

        public Happening Get(Expression<Func<Happening, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Happening GetHappeningByName(string happeningName)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Happening> GetMany(Expression<Func<Happening, bool>> where)
        {
            throw new NotImplementedException();
        }

        public override void Update(Happening entity)
        {
            throw new NotImplementedException();
        }
    }

    internal interface IHappeningRepository : IRepository<Happening>
    {
        Happening GetHappeningByName(string happeningName);
    }
}
