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
        ICarService _carService;

        public ExampelController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManyOptions()
        {
            Compeny compeny = new Compeny();

            Employee employee1 = new Employee();
            employee1.Id = 11;
            employee1.Name = "employee1";
            employee1.PhoneNumbers.Add(new Phone() { Id = 1, NumberToCall = "123456789" });
            employee1.PhoneNumbers.Add(new Phone() { Id = 2, NumberToCall = "456789123" });
            employee1.PhoneNumbers.Add(new Phone() { Id = 3, NumberToCall = "789123456" });

            Employee employee2 = new Employee();
            employee2.Id = 22;
            employee2.Name = "employee2";
            employee2.PhoneNumbers.Add(new Phone() { Id = 4, NumberToCall = "123456000" });
            employee2.PhoneNumbers.Add(new Phone() { Id = 5, NumberToCall = "456789000" });
            employee2.PhoneNumbers.Add(new Phone() { Id = 6, NumberToCall = "789123000" });

            compeny.Workers.Add(employee1);
            compeny.Workers.Add(employee2);

            return View(compeny);
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
