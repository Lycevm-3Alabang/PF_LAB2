using Microsoft.EntityFrameworkCore;
using ShoeShop.Repository.Data;
using ShoeShop.Repository.Entities;
using ShoeShop.Repository.Interfaces;

namespace ShoeShop.Repository.Repositories
{
    // Tandaan: Ang ILogger ay dapat gamitin sa Services Layer, hindi sa Repository.
    public class ShoeRepository : IShoeRepository
    {
        private readonly ShoeShopDbContext _context;

        public ShoeRepository(ShoeShopDbContext context)
        {
            _context = context;
        }

        public async Task<Shoe> GetShoeByIdAsync(int id)
        {
            // Kukunin ang shoe kasama ang color variations
            return await _context.Shoes
                                 .Include(s => s.ColorVariations)
                                 .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Shoe>> GetAllShoesAsync()
        {
            // Kukunin ang lahat ng shoes kasama ang color variations
            return await _context.Shoes
                                 .Include(s => s.ColorVariations)
                                 .ToListAsync();
        }

        public async Task<Shoe> AddShoeAsync(Shoe shoe)
        {
            _context.Shoes.Add(shoe);
            await _context.SaveChangesAsync();
            return shoe;
        }

        public async Task UpdateShoeAsync(Shoe shoe)
        {
            // I-update lang ang status at mag-save ng changes
            _context.Shoes.Update(shoe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShoeAsync(int id)
        {
            var shoeToDelete = await _context.Shoes.FindAsync(id);
            if (shoeToDelete != null)
            {
                _context.Shoes.Remove(shoeToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
