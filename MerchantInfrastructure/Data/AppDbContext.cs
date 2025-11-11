using MerchantCore.Entities;
using MerchantInfrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MerchantInfrastructure.Data
{
    public class AppDbContext : DbContext
    { 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<MerchantLocation> MerchantLocations { get; set; }
        public DbSet<ManagementHierarchy> ManagementHierarchies { get; set; }

        public DbSet<User> Users { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure MerchantLocation
            modelBuilder.Entity<MerchantLocation>()
                .HasKey(l => l.ID); // primary key

            // Make ID auto-increment
            modelBuilder.Entity<MerchantLocation>()
                .Property(l => l.ID)
                .ValueGeneratedOnAdd();


            //
            modelBuilder.Entity<MerchantLocation>()
                .HasOne(l => l.Merchant)          // each location has one merchant
                .WithMany(m => m.merchantlocations)       // one merchant has many locations
                .HasForeignKey(l => l.MerchantId); // foreign key in Location table
        }

    }
}
