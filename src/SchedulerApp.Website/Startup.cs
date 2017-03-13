﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SchedulerApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using SchedulerApp.Data.Infrastructure;
using SchedulerApp.Data.Repositories;
using SchedulerApp.Domain.Services;

namespace SchedulerApp.Website
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddApplicationInsightsTelemetry(Configuration);

            var connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = SchedulerApp; Integrated Security=True;Connect Timeout=15;";
            services.AddScoped<IContactRepository, ContactRepository>();
            
            services.AddDbContext<SchedulerContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("SchedulerApp.Data")));
            //return SetAutofacContainer(services);

        }
        public IContainer ApplicationContainer { get; private set; }
        //private IServiceProvider SetAutofacContainer(IServiceCollection services)
        //{
        //    var builder = new ContainerBuilder();

        //    // Register dependencies, populate the services from
        //    // the collection, and build the container. If you want
        //    // to dispose of the container at the end of the app,
        //    // be sure to keep a reference to it as a property or field.
        //    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        //    builder.RegisterType<ContactRepository>().As<IContactRepository>().InstancePerRequest();
        //    builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

        //    builder.RegisterType<ContactServices>().As<IContactService>().InstancePerMatchingLifetimeScope();


        //    //builder.RegisterType<ContactServices>().As<IContactService>();
        //    builder.Populate(services);
        //    var ApplicationContainer = builder.Build();
        //    //ApplicationContainer.Resolve<IContactRepository>();
        //    //scope.Resolve<IUnitOfWork>();

        //    // Create the IServiceProvider based on the container.
        //    return new AutofacServiceProvider(ApplicationContainer);
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, SchedulerContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            DbInitializer.Initialize(context);
            //appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
        }
    }
}
