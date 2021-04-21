using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Service;
using WebAppCarShop.Models.ViewModel;

namespace WebAppCarShop.Controllers
{
    public class CarsController : Controller
    {

        ICarService _carService = new CarService();

        [HttpGet]
        public IActionResult Index()
        {
            return View(_carService.All());
        }
        [HttpPost]
        public IActionResult Index(CarIndexViewModel indexViewModel)
        {
            indexViewModel.CarList = _carService.FindByBrand(indexViewModel.FilterText);

            return View(indexViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateCar());
        }
        [HttpPost]
        public IActionResult Create(CreateCar createCar)
        {
            if (ModelState.IsValid)
            {
                _carService.Add(createCar);

                return RedirectToAction(nameof(Index));
            }

            return View(createCar);
        }
    }
}
