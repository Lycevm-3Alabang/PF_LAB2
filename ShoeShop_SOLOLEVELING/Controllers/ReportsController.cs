using Microsoft.AspNetCore.Mvc;
using ShoeShop.Services.Interfaces;
using ShoeShop.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop_SOLOLEVELING.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public ReportsController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<StockPullOutDto> pulloutHistory = await _inventoryService.GetAllPullOutHistoryAsync();


            return View(pulloutHistory);
        }

    }
}