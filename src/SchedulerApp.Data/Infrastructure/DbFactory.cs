using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        SchedulerContext dbContext;

        public SchedulerContext Init()
        {
            return dbContext ?? (dbContext = new SchedulerContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
