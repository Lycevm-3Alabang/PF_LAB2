using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoeShop.Data;
using ShoeShop.Entities;

namespace ShoeShop.Repository.ConsoleApp
{
    public static class SeedData
    {
        public static void Seed(ShoeShopDbContext context)
        {
            if (!context.Shoes.Any())
            {
                var shoes = new List<Shoe>();
                for (int i = 1; i <= 15; i++)
                {
                    shoes.Add(new Shoe
                    {
                        Name = $"Shoe Model {i}",
                        Brand = i % 3 == 0 ? "Nike" : i % 3 == 1 ? "Adidas" : "Puma",
                        Cost = 3000 + i * 100,
                        Price = 5000 + i * 150,
                        Description = $"Description for Shoe {i}",
                        IsActive = true,
                        CreatedDate = DateTime.Now.AddDays(-i)
                    });
                }
                context.Shoes.AddRange(shoes);
                context.SaveChanges();
            }

            if (!context.Suppliers.Any())
            {
                var suppliers = new List<Supplier>
                {
                    new Supplier { Name = "Supplier A", ContactEmail = "a@supplier.com", ContactPhone = "1234567890", Address = "Address A", IsActive = true },
                    new Supplier { Name = "Supplier B", ContactEmail = "b@supplier.com", ContactPhone = "2345678901", Address = "Address B", IsActive = true },
                    new Supplier { Name = "Supplier C", ContactEmail = "c@supplier.com", ContactPhone = "3456789012", Address = "Address C", IsActive = true }
                };
                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();
            }

            // Add sample color variations, purchase orders, and pull-outs as needed
        }
    }
}
