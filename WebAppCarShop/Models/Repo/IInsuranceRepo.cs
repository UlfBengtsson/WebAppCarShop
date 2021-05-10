using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;

namespace WebAppCarShop.Models.Repo
{
    public interface IInsuranceRepo
    {
        //C.R.U.D.
        Insurance Create(Insurance insurance);

        Insurance Read(int id);//Find By Id
        List<Insurance> Read();// Get all

        Insurance Update(Insurance car);

        bool Delete(int id);
    }
}
