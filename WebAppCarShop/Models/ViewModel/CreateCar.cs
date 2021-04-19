﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarShop.Models.ViewModel
{
    public class CreateCar
    {
        [Required]
        public string Brand { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string ModelName { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public List<String> BrandList { get; set; }

        public CreateCar()
        {
            BrandList = new List<String>() 
            {
                "Saab",
                "Volvo",
                "BMW",
                "Opel",
                "Volkswagen",
                "Mazda",
                "TVR"
            };
        }
    }
}
