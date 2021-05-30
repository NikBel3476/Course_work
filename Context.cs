using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopDB
{
    class Context : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderCar>()
                .HasKey(t => new { t.OrderId, t.CarId });

            modelBuilder.Entity<OrderCar>()
                .HasOne(oc => oc.Order)
                .WithMany(o => o.OrderCars)
                .HasForeignKey(oc => oc.OrderId);

            modelBuilder.Entity<OrderCar>()
                .HasOne(oc => oc.Car)
                .WithMany(c => c.OrderCars)
                .HasForeignKey(oc => oc.CarId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CarShopDB;Trusted_Connection=True;");
        }
    }
}
