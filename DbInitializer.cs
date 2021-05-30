using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopDB
{
    class DbInitializer
    {
        public static void Initialize(Context context)
        {
            // Car brands
            CarBrand cb1 = new() { BrandName = "Toyota" };
            CarBrand cb2 = new() { BrandName = "Hyundai" };
            CarBrand cb3 = new() { BrandName = "Volkswagen" };
            context.CarBrands.AddRange(new List<CarBrand> { cb1, cb2, cb3 });
            context.SaveChanges();

            // Car models
            CarModel cm1 = new() { ModelName = "Corolla" };
            CarModel cm2 = new() { ModelName = "Elantra" };
            CarModel cm3 = new() { ModelName = "Jetta" };
            context.CarModels.AddRange(new List<CarModel> { cm1, cm2, cm3 });
            context.SaveChanges();

            // Colors
            Color c1 = new() { ColorName = "Белый" };
            Color c2 = new() { ColorName = "Черный" };
            Color c3 = new() { ColorName = "Синий" };
            context.Colors.AddRange(new List<Color> { c1, c2, c3 });
            context.SaveChanges();

            // Cars
            Car car1 = new()
            {
                CarBrand = cb1,
                CarModel = cm1,
                Color = c1,
                Hp = 122,
                Price = 1500000
            };
            Car car2 = new()
            {
                CarBrand = cb2,
                CarModel = cm2,
                Color = c2,
                Hp = 140,
                Price = 1400000
            };
            Car car3 = new()
            {
                CarBrand = cb3,
                CarModel = cm3,
                Color = c3,
                Hp = 146,
                Price = 1700000
            };
            context.Cars.AddRange(new List<Car> { car1, car2, car3 });
            context.SaveChanges();

            // Customers
            Customer cust1 = new() { FirstName = "Иван", LastName = "Иванов" };
            Customer cust2 = new() { FirstName = "Петр", LastName = "Петров" };
            Customer cust3 = new() { FirstName = "Алексей", LastName = "Алексеев" };
            context.Customers.AddRange(new List<Customer> { cust1, cust2, cust3 });
            context.SaveChanges();

            // Orders
            Order o1 = new() { OrderDate = DateTime.Parse("2021-04-09"), Customer = cust1 };
            Order o2 = new() { OrderDate = DateTime.Parse("2021-04-09"), Customer = cust2 };
            Order o3 = new() { OrderDate = DateTime.Parse("2021-04-09"), Customer = cust3 };
            context.Orders.AddRange(new List<Order> { o1, o2, o3 });
            context.SaveChanges();

            // Add cars to orders
            // order 1
            o1.OrderCars.Add(new OrderCar { OrderId = o1.Id, CarId = car1.Id });
            o2.OrderCars.Add(new OrderCar { OrderId = o2.Id, CarId = car2.Id });
            o3.OrderCars.Add(new OrderCar { OrderId = o3.Id, CarId = car3.Id });
            o3.OrderCars.Add(new OrderCar { OrderId = o3.Id, CarId = car1.Id });
            context.SaveChanges();
        }
    }
}