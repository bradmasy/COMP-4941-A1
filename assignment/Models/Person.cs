using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace assignment.Models
{
    public class Person
    {
        [DisplayName("Person")]
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class Customer : Person
    {
       public string Address { get; set; }

        public virtual ICollection<Job> Job { get;set; }

    }

    public class Employee : Person
    {
        public string Department { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }


    public class Service
    {

        [DisplayName("Service")]
        public int ServiceID { get; set; }
        public string Name { get; set; }

        [DisplayName("Employee")]
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<Job> Job { get; set; }
    }

    public class Job
    {
        [DisplayName("Customer")]
        public int CustomerId { get; set; }

        [DisplayName("Service")]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public virtual Customer Customer { get; set; }
    }

    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Derived Tables using TPT or Table Per Type
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Employee>().ToTable("Employee");

            // Employee -> Service
            modelBuilder.Entity<Service>()
                .HasRequired(s => s.Employee)
                .WithMany(e => e.Services)
                .HasForeignKey(s => s.EmployeeID);


            // Service -> Job <- Customer
            modelBuilder.Entity<Job>()
                .HasKey(sc => new { sc.ServiceId, sc.CustomerId });

            modelBuilder.Entity<Job>()
                .HasRequired(job => job.Service)
                .WithMany(service => service.Job)
                .HasForeignKey(job => job.ServiceId);

            modelBuilder.Entity<Job>()
                .HasRequired(job => job.Customer)
                .WithMany(customer => customer.Job)
                .HasForeignKey(job => job.CustomerId);
        }

        public System.Data.Entity.DbSet<assignment.Models.Job> Jobs { get; set; }
    }


}