using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Models.Service;
using WebAppCarShop.Models.ViewModel;

namespace WebAppCarShop.Controllers
{
    public class InsurencesController : Controller
    {
        private readonly IInsuranceService _insuranceService;

        public InsurencesController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        // GET: InsurencesController
        public ActionResult Index()
        {
            return View(_insuranceService.All());
        }

        // GET: InsurencesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InsurencesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InsurencesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateInsurance createInsurance)
        {
            if(ModelState.IsValid)
            {
                _insuranceService.Add(createInsurance);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createInsurance);
            }
        }

        // GET: InsurencesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InsurencesController/Edit/5
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

        // GET: InsurencesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InsurencesController/Delete/5
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
