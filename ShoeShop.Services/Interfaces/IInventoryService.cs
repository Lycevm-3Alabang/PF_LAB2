using ShoeShop.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<ShoeDto> CreateShoeAsync(CreateShoeDto dto);
        Task<IEnumerable<ShoeDto>> GetAllShoesAsync();
        Task<ShoeDto?> GetShoeByIdAsync(int id);
        Task UpdateShoeAsync(int id, CreateShoeDto dto);
        Task DeleteShoeAsync(int id);
        Task<int> GetStockQuantityAsync(int shoeId);
        Task<bool> AdjustStockAsync(int shoeId, int quantityChange, string reason, string user);

        Task<ColorVariationDto> AddColorVariationAsync(int shoeId, CreateColorVariationDto dto);
        Task<IEnumerable<ColorVariationDto>> GetColorVariationsByShoeIdAsync(int shoeId);
        Task<ColorVariationDto?> GetColorVariationByIdAsync(int variationId);
        Task<ColorVariationDto> UpdateColorVariationAsync(int variationId, CreateColorVariationDto dto);
        Task DeleteColorVariationAsync(int variationId);

        // BAGONG METHOD para sa ReportsController
        Task<IEnumerable<StockPullOutDto>> GetAllPullOutHistoryAsync();
    }
}