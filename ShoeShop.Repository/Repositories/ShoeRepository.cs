using Microsoft.EntityFrameworkCore;
using ShoeShop.Repository.Data;
using ShoeShop.Repository.Entities;
using ShoeShop.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repository.Repositories
{
    public class ShoeRepository : IShoeRepository
    {
        private readonly ApplicationDbContext _context;

        public ShoeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Helper method para isama ang ColorVariations
        private IQueryable<Shoe> GetShoeQuery()
        {
            return _context.Shoes.Include(s => s.ColorVariations);
        }

        // 1. ADD METHOD: Tamang AddAsync implementation
        public async Task AddAsync(Shoe entity)
        {
            await _context.Shoes.AddAsync(entity);
        }

        // 2. UPDATE METHOD: Tamang UpdateAsync implementation
        public Task UpdateAsync(Shoe entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask; // Hindi na kailangan ng await Task.CompletedTask
        }

        // 3. GET ALL with VARIATIONS (MISSING IMPLEMENTATION): Ginagamit ang logic ng dating GetAllShoesAsync
        public async Task<IEnumerable<Shoe>> GetAllWithVariationsAsync()
        {
            return await GetShoeQuery().ToListAsync();
        }

        // 4. GET BY ID with VARIATIONS (MISSING IMPLEMENTATION): Ginagamit ang logic ng dating GetShoeByIdAsync
        public async Task<Shoe?> GetByIdWithVariationsAsync(int id)
        {
            return await GetShoeQuery().FirstOrDefaultAsync(s => s.Id == id);
        }

        // 5. DELETE ASYNC (MISSING IMPLEMENTATION): Kinakailangan ang Shoe object bilang parameter (galing sa CS0535)
        public async Task DeleteAsync(Shoe shoe)
        {
            // Assuming the entity passed is tracked or fetched already.
            _context.Shoes.Remove(shoe);
            await Task.CompletedTask; // Returns a completed task since SaveChangesAsync will do the work.
        }

        // Ginamit mo ang DeleteAsync(int id) na may logic, kaya idadagdag natin siya
        // sa class mo. (Pero TANGGALIN mo siya sa IShoeRepository kung DeleteAsync(Shoe) lang ang kailangan)
        public async Task DeleteAsync(int id)
        {
            var shoe = await _context.Shoes.FindAsync(id);
            if (shoe != null)
            {
                _context.Shoes.Remove(shoe);
            }
        }

        // 6. SAVE CHANGES: Inayos ang return type para maging Task<int>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // --- Iba pang Methods na Ginagamit Mo (Optional, depende sa interface) ---

        // Ginagamit ang GetByIdWithVariationsAsync sa taas
        // public async Task<Shoe?> GetShoeByIdAsync(int id) { ... } 

        // Ginagamit ang GetAllWithVariationsAsync sa taas
        // public async Task<IEnumerable<Shoe>> GetAllShoesAsync() { ... }

        public async Task<Shoe?> GetShoeByColorVariationIdAsync(int colorVariationId)
        {
            return await GetShoeQuery()
                .FirstOrDefaultAsync(s => s.ColorVariations.Any(v => v.Id == colorVariationId));
        }
    }
}