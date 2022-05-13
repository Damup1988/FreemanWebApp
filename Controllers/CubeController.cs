using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CubedController : Controller
    {
        public IActionResult Index()
        {
            return View("Cubed");
        }

        public IActionResult Cube(double num)
        {
            TempData["value"] = num.ToString(CultureInfo.InvariantCulture);
            TempData["result"] = Math.Pow(num, 3).ToString(CultureInfo.InvariantCulture);
            return RedirectToAction(nameof(Index));
        }
    }
}