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







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MerchantLocation>()
                .HasOne(l => l.Merchant)          // each location has one merchant
                .WithMany(m => m.merchantlocations)       // one merchant has many locations
                .HasForeignKey(l => l.MerchantId); // foreign key in Location table
        }

    }
}
