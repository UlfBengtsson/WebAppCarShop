using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;
using WebAppCarShop.Models.Service;

namespace WebAppCarShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        private readonly ICarService _carService;

        public ReactController(ICarService carService)
        {
            _carService = carService;
        }

        [EnableCors("ReactPolicy")]
        [HttpGet]
        public List<Car> Get()
        {
            //Response.StatusCode = 418;//Im a Tea Pot
            return _carService.All().CarList;
        }
    }
}
