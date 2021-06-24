using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopDB
{
    class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public List<OrderCar> OrderCars{ get; set; }

        public Order()
        {
            OrderCars = new List<OrderCar>();
        }
    }
}
