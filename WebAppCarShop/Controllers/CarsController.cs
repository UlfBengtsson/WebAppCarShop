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

        CarService _carService = new CarService();

        public IActionResult Index()
        {
            return View(_carService.GetAll());
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
                _carService.AddCar(createCar);

                return RedirectToAction(nameof(Index));
            }

            return View(createCar);
        }
    }
}
