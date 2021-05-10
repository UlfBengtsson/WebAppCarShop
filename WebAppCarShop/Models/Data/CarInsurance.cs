using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarShop.Models.Data
{
    public class CarInsurance//Join table
    {
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int InsuranceId { get; set; }
        public Insurance Insurance { get; set; }
    }
}
