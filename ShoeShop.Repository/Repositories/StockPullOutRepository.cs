using Microsoft.EntityFrameworkCore;
using ShoeShop.Repository.Data; // Assuming ito ang lokasyon ng iyong DbContext
using ShoeShop.Repository.Entities;
using ShoeShop.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repository.Repositories
{
    // FINAL FIX: Tiyakin na public ang class declaration
    public class StockPullOutRepository : IStockPullOutRepository
    {
        // Assuming ApplicationDbContext ang pangalan ng DbContext mo
        private readonly ApplicationDbContext _context;

        public StockPullOutRepository(ApplicationDbContext context) // I-adjust ang type ng context kung iba
        {
            _context = context;
        }

        // --- IMPLEMENTASYON PARA TUGMA SA IStockPullOutRepository.cs ---

        // FIX for CS0535: Ginawa itong AddAsync para tugma sa interface at InventoryService
        public async Task AddAsync(StockPullOut entity)
        {
            // Pinalitan ang .StockPullOuts ng .Set<StockPullOut>() kung sakaling hindi ito DbSet
            // PERO: Assuming tama ang pag-aayos mo sa DbContext, ibalik natin sa StockPullOuts
            await _context.StockPullOuts.AddAsync(entity);
            // Hindi natin kailangan ng SaveChangesAsync() dito, ginagawa na ito sa Service layer
        }

        // FIX for CS0535: Implementasyon ng GetHistoryForShoeAsync (na gagamitin sa Service)
        public async Task<IEnumerable<StockPullOut>> GetHistoryForShoeAsync(int shoeColorVariationId)
        {
            return await _context.StockPullOuts
                .Where(p => p.ShoeColorVariationId == shoeColorVariationId)
                .OrderByDescending(p => p.PullOutDate)
                .AsNoTracking()
                .ToListAsync();
        }

        // FIX: Implementasyon ng SaveChangesAsync()
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // --- IYONG MGA NAUNANG METHODS (Huwag tanggalin, kailangan mo ito) ---

        // Pinalitan ang pangalan at ginawa kong internal
        public async Task<StockPullOut> AddPullOutAsync(StockPullOut pullOut)
        {
            await _context.StockPullOuts.AddAsync(pullOut);
            await _context.SaveChangesAsync();
            return pullOut;
        }

        public async Task<StockPullOut?> GetPullOutByIdAsync(int pullOutId)
        {
            // Kasama ang ColorVariation para sa reporting/validation
            return await _context.StockPullOuts
                .FirstOrDefaultAsync(p => p.Id == pullOutId);
        }

        public async Task UpdatePullOutAsync(StockPullOut pullOut)
        {
            _context.StockPullOuts.Update(pullOut);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StockPullOut>> GetAllPullOutsAsync()
        {
            // Kukunin lahat ng pull-out requests
            return await _context.StockPullOuts
                .OrderByDescending(p => p.PullOutDate)
                .ToListAsync();
        }
    }
}
