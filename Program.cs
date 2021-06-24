using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;

namespace CarShopDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using Context DbContext = new();
            
            if (!(DbContext.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
            {
                // create a database
                DbContext.Database.EnsureCreated();

                // add the data
                DbInitializer.Initialize(DbContext);
                Console.WriteLine("База данных была создана");
            } else
            {
                Console.WriteLine("База данных уже существует");
            }

            Console.WriteLine("Список автомобилей");
            if (DbContext.Cars.Any())
            {
                var cars = DbContext.Cars
                    .Include(c => c.CarBrand)
                    .Include(c => c.CarModel)
                    .Include(c => c.Color).ToList();
                foreach (Car c in cars)
                {
                    Console.WriteLine(c.ToString());
                }
            }
            else
            {
                Console.WriteLine("Нет автомобилей в базе данных");
            }

            Console.Read();
        }
    }
}
