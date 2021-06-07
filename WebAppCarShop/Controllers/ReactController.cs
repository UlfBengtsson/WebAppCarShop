using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
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
    [EnableCors("ReactPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly ICarBrandRepo _brandRepo;

        public ReactController(ICarService carService, ICarBrandRepo brandRepo)
        {
            _carService = carService;
            _brandRepo = brandRepo;
        }

        [HttpGet]
        public List<Car> Get()
        {
            //Response.StatusCode = 418;//Im a Tea Pot
            return _carService.All().CarList;
        }

        [HttpGet("{id}")]
        public Car GetById(int id)
        {
            Car car = _carService.FindById(id);

            foreach (Sale sale in car.OwnerHistory)
            {
                sale.CarInQuestion = null;
            }

            foreach (CarInsurance carIns in car.CarInsurances)
            {
                carIns.Car = null;
                carIns.Insurance.CarInsurances = null;
            }

            return car;
        }

        [HttpPost]
        public ActionResult<Car> Create([FromBody] CreateCar car)
        {
            //ModelState.isValid
            if (ModelState.IsValid)
            {
                return _carService.Add(car);
            }

            return BadRequest(car);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_carService.Remove(id))
            {
                Response.StatusCode = 200;
            }
            else
            {
                Response.StatusCode = 400;
            }
        }

        //----------------------------------- Brand ------------------------------------------------------

        [HttpGet("Brands")]
        public List<CarBrand> GetBrands()
        {
            return _brandRepo.Read();
        }
    }
}
