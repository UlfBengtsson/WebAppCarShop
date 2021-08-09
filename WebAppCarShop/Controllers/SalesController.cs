using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin, SalesEmployee")]
    public class SalesController : Controller
    {
        private readonly ISaleService _saleService;
        private readonly ICarService _carService;

        public SalesController(ISaleService saleService, ICarService carService)
        {
            this._saleService = saleService;
            this._carService = carService;
        }

        // GET: SalesController
        public ActionResult Index()
        {
            return View(_saleService.All());
        }

        // GET: SalesController/Details/5
        public ActionResult Details(int id)
        {
            Sale sale = _saleService.FindById(id);

            if (sale == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(sale);
        }

        // GET: SalesController/Create
        public ActionResult Create()
        {
            CreateSale createSale = new CreateSale();
            createSale.CarList = _carService.All().CarList;

            return View(createSale);
        }

        // POST: SalesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSale createSale)
        {
            if(ModelState.IsValid)
            {
                _saleService.Add(createSale);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createSale);
            }
        }

        // GET: SalesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
