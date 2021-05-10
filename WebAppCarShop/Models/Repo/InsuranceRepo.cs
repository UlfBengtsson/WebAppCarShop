using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Database;
using WebAppCarShop.Models.Data;

namespace WebAppCarShop.Models.Repo
{
    public class InsuranceRepo : IInsuranceRepo
    {
        private readonly CarShopDbContext _carShopDbContext;

        public InsuranceRepo(CarShopDbContext carShopDbContext)
        {
            _carShopDbContext = carShopDbContext;
        }

        public Insurance Create(Insurance insurance)
        {
            _carShopDbContext.Add(insurance);

            if (_carShopDbContext.SaveChanges() > 0)
            {
                return insurance;
            }

            return null;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Insurance Read(int id)
        {
            return _carShopDbContext.Insurances.SingleOrDefault(insurance => insurance.Id == id);
        }

        public List<Insurance> Read()
        {
            return _carShopDbContext.Insurances.ToList();
        }

        public Insurance Update(Insurance car)
        {
            throw new NotImplementedException();
        }
    }
}
