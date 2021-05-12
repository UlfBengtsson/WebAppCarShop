using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;

namespace WebAppCarShop.Models.ViewModel
{
    public class CarInsurancesViewModel
    {
        public Car Car { get; set; }

        public List<Insurance> Insurances { get; set; }
    }
}
