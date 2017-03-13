using SchedulerApp.Data.Configuration;
using SchedulerApp.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SchedulerApp.Data.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly SchedulerContext dbContext;
        public EmployeeRepository(SchedulerContext dbContext)
            : base(dbContext) { }

        void IRepository<Employee>.Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<Employee>.Delete(Expression<Func<Employee, bool>> where)
        {
            throw new NotImplementedException();
        }

        void IRepository<Employee>.Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        Employee IRepository<Employee>.Get(Expression<Func<Employee, bool>> where)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Employee> IRepository<Employee>.GetAll()
        {
            throw new NotImplementedException();
        }

        Employee IRepository<Employee>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeRepository.GetEmployeeByName(string employeeName)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Employee> IRepository<Employee>.GetMany(Expression<Func<Employee, bool>> where)
        {
            throw new NotImplementedException();
        }

        void IRepository<Employee>.Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }

    internal interface IEmployeeRepository : IRepository<Employee>
    {
        Employee GetEmployeeByName(string employeeName);
    }
}
