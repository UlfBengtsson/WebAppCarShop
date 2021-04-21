using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;

namespace WebAppCarShop.Models.ViewModel
{
    public class CarIndexViewModel
    {
        public string FilterText { get; set; }

        public List<Car> CarList { get; set; }

    }
}
