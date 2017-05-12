using System;
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
using React.AspNet;
using React;

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
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddReact();
            var connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = SchedulerApp; Integrated Security=True;Connect Timeout=15;";

            services.AddDbContext<SchedulerContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("SchedulerApp.Data")));
            return SetAutofacContainer(services);

        }
        public IContainer ApplicationContainer { get; private set; }
        private IServiceProvider SetAutofacContainer(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            // Register dependencies, populate the services from
            // the collection, and build the container. If you want
            // to dispose of the container at the end of the app,
            // be sure to keep a reference to it as a property or field.
            builder.RegisterType<ContactServices>().As<IContactService>().InstancePerLifetimeScope();
            builder.RegisterType<HappeningServices>().As<IHappeningService>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepository<>));
            

            //builder.RegisterType<ContactServices>().As<IContactService>();
            builder.Populate(services);
            var ApplicationContainer = builder.Build();
            //ApplicationContainer.Resolve<IContactRepository>();
            //scope.Resolve<IUnitOfWork>();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(ApplicationContainer);
        }

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

            app.UseReact(config =>
            {
                // If you want to use server-side rendering of React components,
                // add all the necessary JavaScript files here. This includes
                // your components as well as all of their dependencies.
                // See http://reactjs.net/ for more information. Example:
                //config.AddScript("~/js/Tutorial.jsx");
                config
                    .AddScript("~/js/remarkable.min.js")
                    .AddScript("~/js/Tutorial.jsx")
                    .AddScript("~/js/navBar.jsx")
                    .AddScript("~/js/calendar.jsx");
                // If you use an external build too (for example, Babel, Webpack,
                // Browserify or Gulp), you can improve performance by disabling
                // ReactJS.NET's version of Babel and loading the pre-transpiled
                // scripts. Example:
                //config
                //  .SetLoadBabel(false)
                //  .AddScriptWithoutTransform("~/Scripts/bundle.server.js");
            });
            app.UseStaticFiles();
            
            ReactSiteConfiguration.Configuration = new ReactSiteConfiguration()
                .AddScript("~/js/Tutorial.jsx")
                .AddScript("~/js/calendar.jsx");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            DbInitializer.Initialize(context);
        }
    }
}
