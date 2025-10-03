using Microsoft.AspNetCore.Mvc;

namespace ShoeShop_SOLOLEVELING.Controllers
{
    public class InventoryPageController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }
    }
}
