using System;
using System.Collections.Generic;
using System.Text;
using Api.Modules.Customer.Domain;
using Api.Modules.Customer.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Api.Modules.Customer.Infrastructure
{
    public class CustomerDbContext : DbContext
    {

        public DbSet<CustomerDomain> Customers { get; set; }
        public DbSet<PhoneContactDomain> PhoneContacts { get; set; }
        public DbSet<NoteDomain> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneContactEntityConfiguration());
            modelBuilder.ApplyConfiguration(new NoteEntityConfiguration());
        }
    }
}
