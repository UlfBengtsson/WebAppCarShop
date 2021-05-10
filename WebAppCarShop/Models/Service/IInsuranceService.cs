using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;
using WebAppCarShop.Models.ViewModel;

namespace WebAppCarShop.Models.Service
{
    public interface IInsuranceService
    {
        Insurance Add(CreateInsurance createInsurance);
        List<Insurance> All();
        Insurance FindById(int id);//Find Sale by its Id
        Insurance Edit(int id, CreateInsurance insurance);
        bool Remove(int id);
    }
}
