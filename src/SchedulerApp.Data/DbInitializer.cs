using SchedulerApp.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchedulerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
                new Employee{Name="Carson",Adress="Alexander",PhoneNumber="(283) 843-9772"},
            new Employee{Name="Meredith",Adress="Alonso",PhoneNumber="(323) 789-1103"},
            new Employee{Name="Arturo",Adress="Anand",PhoneNumber="(457) 213-9438"},
            new Employee{Name="Gytis",Adress="Barzdukas",PhoneNumber="(663) 646-4717"},
            new Employee{Name="Yan",Adress="Li",PhoneNumber="(271) 844-936Update-Database5"},
            new Employee{Name="Peggy",Adress="Justice",PhoneNumber="(722) 279-7386"},
            new Employee{Name="Laura",Adress="Norman",PhoneNumber="(914) 976-3869"},
            new Employee{Name="Nino",Adress="Olivetto",PhoneNumber="(224) 127-0732"}
            };
            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();

            var locations = new Location[]
            {
            new Location{ Adress="8785 Windfall St. Whitehall, PA 18052",Contact=null},
            new Location { Adress="77 Winchester Lane Coachella, CA 92236",Contact=null},
            new Location{Adress="1 N. Cactus Ave. Green Bay, WI 54302",Contact=null},
            new Location{Adress="665 Clinton Lane Wilkes Barre, PA 18702",Contact=null},
            new Location{Adress="711 Old York Drive Richmond, VA 23223",Contact=null},
            new Location{Adress="787 Lakeview St. Marion, NC 28752",Contact=null},
            new Location{Adress="198 West Manhattan Drive Richmond, VA 23223",Contact=null}
            };
            foreach (Location l in locations)
            {
                context.Locations.Add(l);
            }
            context.SaveChanges();
            var contacts = new Contact[]
            {
             new Contact("Carson","Alexander","(283) 843-9772"),
            new Contact("Meredith","Alonso","(323) 789-1103"),
            new Contact("Arturo","Anand","(457) 213-9438"),
            new Contact("Gytis","Barzdukas","(663) 646-4717"),
            new Contact("Yan","Li","(271) 844-936Update-Database5"),
            new Contact("Peggy","Justice","(722) 279-7386"),
            new Contact("Laura","Norman","(914) 976-3869"),
            new Contact("Nino","Olivetto","(224) 127-0732")
            };
            foreach (Contact c in contacts)
            {
                context.Contacts.Add(c);
            }
            context.SaveChanges();
        }
    }
}