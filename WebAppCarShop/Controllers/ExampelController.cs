using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;
using WebAppCarShop.Models.Service;

namespace WebAppCarShop.Controllers
{
    public class ExampelController : Controller
    {
        static readonly ICarService _carService = new CarService();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ExampelOne(string messageText)
        {
            ViewBag.Msg = messageText;
            return View("Index");
        }

        public IActionResult ExampelTwo(string messageText)
        {
            ViewBag.Msg = messageText;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AllCarsPartcialView()
        {
            List<Car> carList = _carService.All().CarList;

            return PartialView("_AllCarPartcialView", carList);
        }

        [HttpPost]
        public IActionResult DetailsPartcialView(int id)
        {
            Car car = _carService.FindById(id);

            return PartialView("_ACarRowPartcialView", car);
            //return NotFound();// status code 404
            //return BadRequest();// status code 400
        }
    }
}
