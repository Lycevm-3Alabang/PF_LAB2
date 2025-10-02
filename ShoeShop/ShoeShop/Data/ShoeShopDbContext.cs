using Microsoft.EntityFrameworkCore;
using ShoeShop.Entities;

namespace ShoeShop.Data
{
    public class ShoeShopDbContext : DbContext
    {
        public ShoeShopDbContext(DbContextOptions<ShoeShopDbContext> options) : base(options) { }

        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<ShoeColorVariation> ShoeColorVariations { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public DbSet<StockPullOut> StockPullOuts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Shoe - ShoeColorVariation
            modelBuilder.Entity<Shoe>()
                .HasMany(s => s.ColorVariations)
                .WithOne(cv => cv.Shoe)
                .HasForeignKey(cv => cv.ShoeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Supplier - PurchaseOrder
            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.PurchaseOrders)
                .WithOne(po => po.Supplier)
                .HasForeignKey(po => po.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            // PurchaseOrder - PurchaseOrderItem
            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(po => po.Items)
                .WithOne(i => i.PurchaseOrder)
                .HasForeignKey(i => i.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // ShoeColorVariation - PurchaseOrderItem
            modelBuilder.Entity<ShoeColorVariation>()
                .HasMany(cv => cv.PurchaseOrderItems)
                .WithOne(i => i.ShoeColorVariation)
                .HasForeignKey(i => i.ShoeColorVariationId)
                .OnDelete(DeleteBehavior.Restrict);

            // ShoeColorVariation - StockPullOut
            modelBuilder.Entity<ShoeColorVariation>()
                .HasMany(cv => cv.StockPullOuts)
                .WithOne(sp => sp.ShoeColorVariation)
                .HasForeignKey(sp => sp.ShoeColorVariationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data will be added here in next step
        }
    }
}
