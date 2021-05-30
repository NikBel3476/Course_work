using CarShopDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;

namespace CarDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Car list");
            using Context DbContext = new();

            
            if (!(DbContext.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
            {
                // create a database
                DbContext.Database.EnsureCreated();

                // add the data
                DbInitializer.Initialize(DbContext);
            } 

            if (DbContext.Cars.Any())
            {
                var cars = DbContext.Cars.Include(c => c.CarBrand).Include(c => c.CarModel).Include(c => c.Color).ToList();
                foreach (Car c in cars)
                {
                    Console.WriteLine(c.ToString());
                }
            }
            else
            {
                Console.WriteLine("there is no cars in database");
            }

            Console.Read();
        }
    }
}
