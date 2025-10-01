using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShoeShop_SOLOLEVELING.Models;
using Microsoft.Extensions.Logging; // <--- IDAGDAG ANG LINYANG ITO

namespace ShoeShop_SOLOLEVELING.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) // Ito ang error line
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}