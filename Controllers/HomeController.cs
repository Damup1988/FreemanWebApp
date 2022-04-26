using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(long id = 1)
        {
            var prod = await _context.Products.FindAsync(id);
            if (prod.CategoryId == 1)
            {
                return View("Watersports", prod);
            }
            else
            {
                return View(prod);
            }
        }
    }
}