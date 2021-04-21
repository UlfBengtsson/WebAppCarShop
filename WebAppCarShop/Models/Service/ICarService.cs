using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;
using WebAppCarShop.Models.ViewModel;

namespace WebAppCarShop.Models.Service
{
    public interface ICarService
    {
        Car Add(CreateCar createCar);
        CarIndexViewModel All();
        Car FindById(int id);
        List<Car> FindByBrand(string brand);
        Car Edit(int id, CreateCar car);
        bool Remove(int id);
    }
}
