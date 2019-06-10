using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject4
{
    public class Car : BaseEntety
    {
        public Car()
        {
            Route = new List<int>();
        }

        public Car(Car car)
        {
            EntetyId = car.EntetyId;
            Route = car.Route;
            Price = car.Price;
            Capacity = car.Capacity;
        }

        public int Price { get; set; }

        public List<int> Route { get; set; }

        public void UpdateCurrntPoint()
        { }

        public int Capacity { get; set; }
    }
}
