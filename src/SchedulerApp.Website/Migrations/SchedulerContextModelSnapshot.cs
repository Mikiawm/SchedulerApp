using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SchedulerApp.Data;

namespace SchedulerApp.Website.Migrations
{
    [DbContext(typeof(SchedulerContext))]
    partial class SchedulerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchedulerApp.Data.Configuration.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.Property<int?>("LocationId");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("ContactId");

                    b.HasIndex("LocationId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("SchedulerApp.Data.Configuration.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.Property<int?>("EventId");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("EmployeeId");

                    b.HasIndex("EventId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SchedulerApp.Data.Configuration.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContactId");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<int?>("LocationId");

                    b.Property<string>("Name");

                    b.HasKey("EventId");

                    b.HasIndex("ContactId");

                    b.HasIndex("LocationId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SchedulerApp.Data.Configuration.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("SchedulerApp.Data.Configuration.Contact", b =>
                {
                    b.HasOne("SchedulerApp.Data.Configuration.Location")
                        .WithMany("Contact")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("SchedulerApp.Data.Configuration.Employee", b =>
                {
                    b.HasOne("SchedulerApp.Data.Configuration.Event")
                        .WithMany("Employees")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("SchedulerApp.Data.Configuration.Event", b =>
                {
                    b.HasOne("SchedulerApp.Data.Configuration.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.HasOne("SchedulerApp.Data.Configuration.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });
        }
    }
}
