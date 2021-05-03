using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;

namespace WebAppCarShop.Models.Repo
{
    public class InMemoryCarRepo : ICarRepo
    {
        List<Car> carList = new List<Car>();
        int idCounter = 0;

        public InMemoryCarRepo()
        {
            carList.Add(new Car() {Id = 1, Brand = "Saab", ModelName = "900S", Price = 1999.99 });
            carList.Add(new Car() {Id = 2, Brand = "Volvo", ModelName = "745", Price = 2999.99 });
            carList.Add(new Car() {Id = 3, Brand = "BMW", ModelName = "525i", Price = 5599.99 });
            idCounter = 3;
        }

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
