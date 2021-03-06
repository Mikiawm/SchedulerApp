﻿using Microsoft.EntityFrameworkCore;
using SchedulerApp.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Data
{

    public class SchedulerContext : DbContext
    {
        public SchedulerContext(DbContextOptions<SchedulerContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Happening> Happenings { get; set; }
        public DbSet<Location> Locations { get; set; }

        public SchedulerContext()
        {

        }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<Happening>().ToTable("Happening");
            modelBuilder.Entity<Location>().ToTable("Location");
        }
    }



}
