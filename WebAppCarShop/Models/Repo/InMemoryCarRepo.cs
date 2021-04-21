using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;

namespace WebAppCarShop.Models.Repo
{
    public class InMemoryCarRepo : ICarRepo
    {
        static List<Car> carList = new List<Car>();
        static int idCounter = 0;

        public Car Create(Car car)
        {
            car.Id = ++idCounter;
            carList.Add(car);

            return car;
        }

        public Car Read(int id)
        {
            foreach (Car item in carList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        public List<Car> Read()
        {
            return carList;
        }

        public Car Update(Car car)
        {
            Car originalCar = Read(car.Id);

            if (originalCar == null)
            {
                return null;
            }

            originalCar.Brand = car.Brand;
            originalCar.ModelName = car.ModelName;
            originalCar.Price = car.Price;

            return originalCar;
        }

        public bool Delete(int id)
        {
            Car car = Read(id);

            if (car == null)
            {
                return false;
            }

            return carList.Remove(car);
        }
    }
}
