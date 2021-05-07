using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Database;
using WebAppCarShop.Models.Data;

namespace WebAppCarShop.Models.Repo
{
    public class CarBrandRepo : ICarBrandRepo
    {
        private readonly CarShopDbContext _carShopDbContext;

        public CarBrandRepo(CarShopDbContext carShopDbContext)
        {
            this._carShopDbContext = carShopDbContext;
        }

        public CarBrand Create(CarBrand carBrand)
        {
            _carShopDbContext.CarBrands.Add(carBrand);

            int result = _carShopDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return carBrand;
        }

        public CarBrand Read(int id)
        {
            return _carShopDbContext.CarBrands.SingleOrDefault(brand => brand.Id == id);
        }

        public List<CarBrand> Read()
        {
            return _carShopDbContext.CarBrands.ToList();
        }

        public CarBrand Update(CarBrand carBrand)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            _carShopDbContext.CarBrands.Remove(Read(id));

            int result = _carShopDbContext.SaveChanges();

            if (result == 0)
            {
                return false;
            }

            return true;
        }
    }
}
