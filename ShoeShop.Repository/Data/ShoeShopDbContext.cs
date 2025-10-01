using Microsoft.EntityFrameworkCore;
using ShoeShop.Repository.Entities;
using ShoeShop.Repository.Data;

namespace ShoeShop.Repository.Data
{
    public class ShoeShopDbContext : DbContext
    {
        public ShoeShopDbContext(DbContextOptions<ShoeShopDbContext> options)
            : base(options)
        {
        }

        // DbSets for all Entities
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<ShoeColorVariation> ColorVariations { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public DbSet<StockPullOut> StockPullOuts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data
            modelBuilder.Seed();

            // Fluent API Configurations
            modelBuilder.Entity<ShoeColorVariation>()
                .HasOne(v => v.Shoe)
                .WithMany(s => s.ColorVariations)
                .HasForeignKey(v => v.ShoeId);

            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(o => o.Supplier)
                .WithMany(s => s.PurchaseOrders)
                .HasForeignKey(o => o.SupplierId);
        }
    }
}