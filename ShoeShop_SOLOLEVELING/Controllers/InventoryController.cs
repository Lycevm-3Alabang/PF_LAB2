using Microsoft.AspNetCore.Mvc;
using ShoeShop.Services.Interfaces;
using ShoeShop.Services.DTOs;
using System.Threading.Tasks;

namespace ShoeShop_SOLOLEVELING.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public async Task<IActionResult> Index()
        {
            var shoes = await _inventoryService.GetAllShoesAsync(); 
            return View(shoes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateShoeDto shoeDto)
        {
            if (ModelState.IsValid)
            {
                await _inventoryService.CreateShoeAsync(shoeDto);

                TempData["Message"] = $"Successfully added new shoe model: {shoeDto.ModelName}!";

                return RedirectToAction(nameof(Index));
            }

            return View(shoeDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdjustStock(int shoeId, int quantityChange, string reason, string user)
        {
            var success = await _inventoryService.AdjustStockAsync(shoeId, quantityChange, reason, user);
            TempData["Message"] = success ? "Stock updated successfully." : "Failed to update stock.";
            return RedirectToAction(nameof(Index));
        }
    }
}