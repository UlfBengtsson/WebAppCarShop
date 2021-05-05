using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Database;
using WebAppCarShop.Models.Data;

namespace WebAppCarShop.Models.Repo
{
    public class SaleRepo : ISaleRepo
    {
        private readonly CarShopDbContext _carShopDbContext;

        public SaleRepo(CarShopDbContext carShopDbContext)
        {
            this._carShopDbContext = carShopDbContext;
        }

        public Sale Create(Sale sale)
        {
            _carShopDbContext.Sales.Add(sale);

            int result = _carShopDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return sale;
        }


        public Sale Read(int id)
        {
            return _carShopDbContext.Sales.Find(id);
        }

        public List<Sale> Read()
        {
            return _carShopDbContext.Sales.Include( row => row.CarInQuestion ).ToList();
        }

        public Sale Update(Sale sale)
        {
            Sale originalSale = Read(sale.Id);

            if (originalSale == null)
            {
                return null;
            }

            _carShopDbContext.Update(sale);

            //originalSale.BuyerName = sale.BuyerName;
            //originalSale.SellerName = sale.SellerName;
            //originalSale.TimeOfSale = sale.TimeOfSale;
            //originalSale.CarInQuestion = sale.CarInQuestion;

            int result = _carShopDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return originalSale;
        }
        public bool Delete(int id)
        {
            Sale originalSale = Read(id);

            if (originalSale == null)
            {
                return false;
            }

            _carShopDbContext.Sales.Remove(originalSale);

            int result = _carShopDbContext.SaveChanges();

            if (result == 0)
            {
                return false;
            }

            return true;
        }
    }
}
