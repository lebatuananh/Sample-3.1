using System;
using System.Collections.Generic;
using System.Text;
using Api.Data.Postgre.Dto;
using Base.Static.Application;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Postgre
{
    public class CRMDbContext : DbContext
    {
        public CRMDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                AppSettings.Get<string>("Databases:Postgre:ConnectionStrings:CRM")
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Replace column names            
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.Name.ToLower());
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName().ToLower());
                }
            }

            modelBuilder.Entity<RegionDto>()
                .Property(t => t.Alias).HasColumnName("namealias");

            modelBuilder.Entity<RegionDto>()
                .Property(t => t.EnglishName).HasColumnName("nameenglish");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CustomerDto> Customers { get; set; }
        public DbSet<RegionDto> Regions { get; set; }
    }
}
