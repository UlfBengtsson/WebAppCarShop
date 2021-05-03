using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models;
using WebAppCarShop.Models.Data;
using WebAppCarShop.Models.Service;

namespace WebAppCarShop.Controllers
{
    public class HomeController : Controller
    {
        ICarService _carService;

        public HomeController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            //just for demo
            List<Car> carList = _carService.All().CarList;
            Car lastCar = null;
            if(carList.Count > 0)
            {
                lastCar = carList[carList.Count - 1];
            }
            //------

            return View(lastCar);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
