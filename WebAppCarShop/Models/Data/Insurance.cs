using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarShop.Models.Data
{
    public class Insurance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        //Many to many join table
        public List<CarInsurance> CarInsurances { get; set; }
    }
}
