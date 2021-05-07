using Microsoft.EntityFrameworkCore;// needed for DbContext
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;

namespace WebAppCarShop.Database
{
    public class CarShopDbContext : DbContext
    {
        public CarShopDbContext(DbContextOptions<CarShopDbContext> options) : base(options)
        { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Sale> Sales { get; set; }

    }
}
/*
 * dotnet ef migrations add
 * 
 * dotnet ef database update
 * 
 * 
 */