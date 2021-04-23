using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarShop.Controllers
{
    public class ExampelController : Controller
    {
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
    }
}
