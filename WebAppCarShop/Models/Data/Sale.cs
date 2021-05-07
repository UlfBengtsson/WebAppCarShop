using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarShop.Models.Data
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string BuyerName { get; set; }

        [Required]
        [MaxLength(60)]
        public string SellerName { get; set; }

        [Required]
        public DateTime TimeOfSale { get; set; }

        [ForeignKey("CarInQuestion")]
        public int CarInQuestionId { get; set; }

        //One
        [Required]
        public Car CarInQuestion { get; set; }//navi prop

    }
}
