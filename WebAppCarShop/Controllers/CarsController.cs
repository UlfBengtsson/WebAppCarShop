using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;
using WebAppCarShop.Models.Repo;
using WebAppCarShop.Models.Service;
using WebAppCarShop.Models.ViewModel;

namespace WebAppCarShop.Controllers
{
    public class CarsController : Controller
    {

        ICarService _carService;
        private readonly ICarBrandRepo _carBrandRepo;

        public CarsController(ICarService carService, ICarBrandRepo carBrandRepo)//constuctor injection
        {
            _carService = carService;
            _carBrandRepo = carBrandRepo;
        }

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
            return View(new CreateCar(_carBrandRepo));
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

        public IActionResult Details(int id)
        {
            Car car = _carService.FindById(id);

            if (car == null)
            {
                return RedirectToAction("Index");
            }

            return View(car);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Car car = _carService.FindById(id);

            if (car == null)
            {
                return RedirectToAction("Index");
            }

            EditCar editCar = new EditCar();
            editCar.Id = id;
            editCar.CreateCar = _carService.CarToCreateCar(car);

            return View(editCar);
        }

        [HttpPost]
        public IActionResult Edit(int id, CreateCar createCar)
        {
            if (ModelState.IsValid)
            {
                Car car = _carService.Edit(id, createCar);

                return RedirectToAction(nameof(Index));
            }

            EditCar editCar = new EditCar();
            editCar.Id = id;
            editCar.CreateCar = createCar;

            return View(editCar);
        }
    }
}
