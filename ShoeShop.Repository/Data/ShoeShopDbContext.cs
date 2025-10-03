using Microsoft.EntityFrameworkCore;
using ShoeShop.Repository.Entities; // Assuming your entities are here

namespace ShoeShop.Repository.Data
{
    public class ShoeShopDbContext : DbContext
    {
        public ShoeShopDbContext(DbContextOptions<ShoeShopDbContext> options)
            : base(options)
        {
        }

        // Tiyakin na nakalagay dito ang lahat ng entities mo
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<ShoeColorVariation> ColorVariations { get; set; }
        // ... atbp.
    }
}