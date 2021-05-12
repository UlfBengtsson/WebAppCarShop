using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;

namespace WebAppCarShop.Models.Repo
{
    public interface ICarInsuranceRepo
    {
        CarInsurance Create(CarInsurance carInsurance);

        CarInsurance Read(int carId, int insurId);
        List<CarInsurance> Read();

        bool Delete(int carId, int insurId);

    }
}
