using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;

namespace WebAppCarShop.Models.ViewModel
{
    public class CreateSale
    {
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string BuyerName { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string SellerName { get; set; }

        [Required]
        public int CarInQuestionId { get; set; }

        public List<Car> CarList { get; set; }
    }
}
