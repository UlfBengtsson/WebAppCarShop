using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;

namespace WebAppCarShop.Models.Repo
{
    public interface ICarBrandRepo
    {
        //C.R.U.D.
        CarBrand Create(CarBrand carBrand);

        CarBrand Read(int id);//Find By Id
        List<CarBrand> Read();// Get all

        CarBrand Update(CarBrand carBrand);

        bool Delete(int id);
    }
}
