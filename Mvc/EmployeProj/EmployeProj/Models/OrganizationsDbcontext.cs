using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EmployeProj.Migrations;

namespace EmployeProj.Models
{
    public class OrganizationsDbcontext:DbContext
    {
        public OrganizationsDbcontext():base("MyConnectionstring")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OrganizationsDbcontext, Configuration>());
        }
        public DbSet<Empploye> Empployes { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}