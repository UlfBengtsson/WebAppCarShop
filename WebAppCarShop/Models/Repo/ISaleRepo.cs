using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;

namespace WebAppCarShop.Models.Repo
{
    public interface ISaleRepo
    {
        //C.R.U.D.
        Sale Create(Sale sale);

        Sale Read(int id);//Find By Id
        List<Sale> Read();// Get all

        Sale Update(Sale sale);

        bool Delete(int id);
    }
}
