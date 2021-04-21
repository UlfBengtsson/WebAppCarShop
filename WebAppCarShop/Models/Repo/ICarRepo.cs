using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;

namespace WebAppCarShop.Models.Repo
{
    public interface ICarRepo
    {
        //C.R.U.D.
        Car Create(Car car);
        
        Car Read(int id);//Find By Id
        List<Car> Read();// Get all

        Car Update(Car car);

        bool Delete(int id);
    }
}
