using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Asset_Management.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Asset_Management.DAL
{
    public class DataContext : DbContext
    {
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Contract> Contracts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }

        public DbSet<Maintenance> Maintenances { get; set; }

    }
}