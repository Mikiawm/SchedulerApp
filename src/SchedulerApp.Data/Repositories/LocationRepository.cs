using SchedulerApp.Data.Configuration;
using SchedulerApp.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SchedulerApp.Data.Repositories
{
    public class LocationRepository : IRepository<Location>, ILocationRepository
    {
        public void Add(Location entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<Location, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(Location entity)
        {
            throw new NotImplementedException();
        }

        public Location Get(Expression<Func<Location, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetAll()
        {
            throw new NotImplementedException();
        }

        public Location GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Location GetContactionByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetMany(Expression<Func<Location, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(Location entity)
        {
            throw new NotImplementedException();
        }
    }

    internal interface ILocationRepository
    {
        Location GetContactionByName(string name);

    }
}
