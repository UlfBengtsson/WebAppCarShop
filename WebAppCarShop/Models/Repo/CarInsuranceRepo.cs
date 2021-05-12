using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Database;
using WebAppCarShop.Models.Data;

namespace WebAppCarShop.Models.Repo
{
    public class CarInsuranceRepo : ICarInsuranceRepo
    {
        private readonly CarShopDbContext _carShopDbContext;

        public CarInsuranceRepo(CarShopDbContext carShopDbContext)
        {
            _carShopDbContext = carShopDbContext;
        }

        public CarInsurance Create(CarInsurance carInsurance)
        {
            _carShopDbContext.CarInsurances.Add(carInsurance);

            if (_carShopDbContext.SaveChanges() > 0)
            {
                return carInsurance;
            }

            return null;
        }


        public CarInsurance Read(int carId, int insurId)
        {
            return _carShopDbContext.CarInsurances.SingleOrDefault(ci => ci.CarId == carId && ci.InsuranceId == insurId);
        }

        public List<CarInsurance> Read()
        {
            return _carShopDbContext.CarInsurances.ToList();
        }
        public bool Delete(int carId, int insurId)
        {

            CarInsurance carInsurance = Read(carId, insurId);

            if (carInsurance == null)
            {
                return false;
            }

            _carShopDbContext.CarInsurances.Remove(carInsurance);

            if (_carShopDbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
