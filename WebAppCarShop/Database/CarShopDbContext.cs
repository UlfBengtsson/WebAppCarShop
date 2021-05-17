using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;// needed for DbContext
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;

namespace WebAppCarShop.Database
{
    public class CarShopDbContext : IdentityDbContext<IdentityUser>
    {
        public CarShopDbContext(DbContextOptions<CarShopDbContext> options) : base(options)
        { }

        //Join table configured using Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //Recommend on the first line inside method to make IdentityDbContext happy

            modelBuilder.Entity<CarInsurance>().HasKey(ci => 
            new { 
                ci.CarId, 
                ci.InsuranceId
            });

            modelBuilder.Entity<CarInsurance>()
                .HasOne<Car>(ci => ci.Car)      //ci = CarInsurance
                .WithMany(c => c.CarInsurances)//c = Car
                .HasForeignKey(ci => ci.CarId);

            modelBuilder.Entity<CarInsurance>()
                .HasOne<Insurance>(ci => ci.Insurance) //ci = CarInsurance
                .WithMany(i => i.CarInsurances)         //i = Insurance
                .HasForeignKey(ci => ci.InsuranceId);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<CarInsurance> CarInsurances { get; set; }

    }
}
/*
 * dotnet ef migrations add
 * 
 * dotnet ef database update
 */