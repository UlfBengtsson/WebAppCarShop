using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Repo;
using WebAppCarShop.Models.Util;

namespace WebAppCarShop.Models.ViewModel
{
    public class CreateCar
    {
        [Required]
        public string Brand { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string ModelName { get; set; }

        [ModelBinder(BinderType = typeof(DoubleBinder))]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public List<String> BrandList { get; set; }

        public CreateCar()
        {
            //Zero cunstructor is requierd for ModelBinder to work
        }

        public CreateCar(ICarBrandRepo carBrandRepo)
        {
            BrandList = new List<String>();

            foreach (var item in carBrandRepo.Read())
            {
                BrandList.Add(item.Name);
            }
        }
    }
}