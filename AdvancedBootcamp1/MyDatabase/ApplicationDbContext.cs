using AdvancedBootcamp1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdvancedBootcamp1.MyDatabase
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext() :base("Sindesmos")
        {

        }

        public DbSet<Domain> Domains { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<WebPage> WebPages { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Name> Names { get; set; }
    }
}