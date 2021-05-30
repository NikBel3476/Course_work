using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopDB
{
    class Car
    {
        public int Id { get; set; }
        public int Hp { get; set; }
        public int Price { get; set; }
        public Color Color { get; set; }
        public CarModel CarModel { get; set; }
        public CarBrand CarBrand { get; set; }
        public List<OrderCar> OrderCars { get; set; }

        public Car()
        {
            OrderCars = new List<OrderCar>();
        }

        public override string ToString()
        {
            return $"{Id}: {CarBrand.BrandName} {CarModel.ModelName}, цвет: {Color.ColorName}, мощность: {Hp} л/с, цена: {Price} рублей";
        }
    }
}
