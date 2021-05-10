using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;
using WebAppCarShop.Models.Repo;
using WebAppCarShop.Models.ViewModel;

namespace WebAppCarShop.Models.Service
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRepo _insuranceRepo;

        public InsuranceService(IInsuranceRepo insuranceRepo)
        {
            _insuranceRepo = insuranceRepo;
        }

        public Insurance Add(CreateInsurance createInsurance)
        {
            Insurance insurance = new Insurance() { Name = createInsurance.Name };

            return _insuranceRepo.Create(insurance);
        }

        public List<Insurance> All()
        {
            return _insuranceRepo.Read();
        }
        public Insurance FindById(int id)
        {
            return _insuranceRepo.Read(id);
        }

        public Insurance Edit(int id, CreateInsurance insurance)
        {
            throw new NotImplementedException();
        }


        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
