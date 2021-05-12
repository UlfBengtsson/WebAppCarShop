using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;
using WebAppCarShop.Database;
using Microsoft.EntityFrameworkCore;

namespace WebAppCarShop.Models.Repo
{
    public class DatabaseCarRepo : ICarRepo
    {
        private readonly CarShopDbContext carShopDbContext;//DI

        public DatabaseCarRepo(CarShopDbContext carShopDbContext)
        {
            this.carShopDbContext = carShopDbContext;
        }

        public Car Create(Car car)
        {
            carShopDbContext.Cars.Add(car);

            int result = carShopDbContext.SaveChanges();

            if (result == 0)//no changes in the database
            {
                throw new Exception("unable to create car in database.");
            }

            return car;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Car Read(int id)
        {
            return carShopDbContext.Cars.Include(car => car.OwnerHistory)
                                        .Include(car => car.CarInsurances)
                                            .ThenInclude(carIns => carIns.Insurance)
                                        .SingleOrDefault(row => row.Id == id);//if not found it will return null
        }

        public List<Car> Read()
        {
            return carShopDbContext.Cars.ToList();
        }

        public Car Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
