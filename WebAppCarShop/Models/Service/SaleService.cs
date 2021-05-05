using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;
using WebAppCarShop.Models.Repo;
using WebAppCarShop.Models.ViewModel;

namespace WebAppCarShop.Models.Service
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepo _saleRepo;
        private readonly ICarRepo _carRepo;

        public SaleService(ISaleRepo saleRepo, ICarRepo carRepo)
        {
            _saleRepo = saleRepo;
            _carRepo = carRepo;
        }

        public Sale Add(CreateSale createSale)
        {
            Sale sale = new Sale();

            sale.BuyerName = createSale.BuyerName;
            sale.SellerName = createSale.SellerName;
            sale.TimeOfSale = DateTime.Now;
            sale.CarInQuestion = _carRepo.Read( createSale.CarInQuestionId );

            return _saleRepo.Create(sale);
        }

        public List<Sale> All()
        {
            return _saleRepo.Read();
        }

        public Sale Edit(int id, CreateSale sale)
        {
            throw new NotImplementedException();
        }

        public List<Sale> FindByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public Sale FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public CreateSale SaleToCreateSale(Sale sale)
        {
            throw new NotImplementedException();
        }
    }
}
