using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;
using WebAppCarShop.Models.Repo;
using WebAppCarShop.Models.ViewModel;

namespace WebAppCarShop.Models.Service
{
    public class CarService : ICarService
    {
        ICarRepo _carRepo;//storage for car data

        public CarService()
        {
            _carRepo = new InMemoryCarRepo();
        }

        public Car Add(CreateCar createCar)
        {
            Car car = new Car();

            car.Brand = createCar.Brand;
            car.ModelName = createCar.ModelName;
            car.Price = createCar.Price;

            car = _carRepo.Create(car);

            return car;
        }

        public CarIndexViewModel All()
        {
            CarIndexViewModel indexViewModel = new CarIndexViewModel();

            indexViewModel.CarList = _carRepo.Read();

            return indexViewModel;
        }

        public Car FindById(int id)
        {
            return _carRepo.Read(id);
        }

        public List<Car> FindByBrand(string brand)
        {
            List<Car> carBrandList = new List<Car>();

            foreach (Car item in _carRepo.Read())
            {
                if (item.Brand.Equals(brand))
                {
                    carBrandList.Add(item);
                }
            }

            return carBrandList;
        }

        public Car Edit(int id, CreateCar car)
        {
            Car originalCar = FindById(id);

            if (originalCar == null)
            {
                return null;
            }

            originalCar.Brand = car.Brand;
            originalCar.ModelName = car.ModelName;
            originalCar.Price = car.Price;

            originalCar = _carRepo.Update(originalCar);

            return originalCar;
        }

        public bool Remove(int id)
        {
            return _carRepo.Delete(id);
        }

        public CreateCar CarToCreateCar(Car car)
        {
            CreateCar createCar = new CreateCar();

            createCar.Brand = car.Brand;
            createCar.ModelName = car.ModelName;
            createCar.Price = car.Price;

            return createCar;
        }
    }
}
