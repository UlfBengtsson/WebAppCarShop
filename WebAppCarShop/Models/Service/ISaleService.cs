using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;
using WebAppCarShop.Models.ViewModel;

namespace WebAppCarShop.Models.Service
{
    public interface ISaleService
    {
        Sale Add(CreateSale createSale);
        List<Sale> All();
        Sale FindById(int id);//Find Sale by its Id

        List<Sale> FindByCarId(int carId);//Find all sales that have the Car with the Id of

        Sale Edit(int id, CreateSale sale);
        CreateSale SaleToCreateSale(Sale sale);
        bool Remove(int id);
    }
}
