using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;
using WebAppCarShop.Models.ViewModel;

namespace WebAppCarShop.Models.Service
{
    public class CarService
    {
        static int idCounter = 0;
        static List<Car> carList = new List<Car>();

        public Car AddCar(CreateCar createCar)
        {
            Car car = new Car();
            car.Id = ++idCounter;
            car.Brand = createCar.Brand;
            car.ModelName = createCar.ModelName;
            car.Price = createCar.Price;

            carList.Add(car);

            return car;
        }

        public List<Car> GetAll()
        {
            return carList;
        }
    }
}
