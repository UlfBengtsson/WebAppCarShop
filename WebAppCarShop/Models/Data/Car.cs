using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarShop.Models.Data
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(100)]
        public string ModelName { get; set; }

        public double Price { get; set; }

        //Many
        public List<Sale> OwnerHistory { get; set; }//navi prop
    }
}
