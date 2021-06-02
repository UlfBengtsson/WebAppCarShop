using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;
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

        public ReactController(ICarService carService)
        {
            _carService = carService;
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
            return _carService.FindById(id);
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
    }
}
