﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
