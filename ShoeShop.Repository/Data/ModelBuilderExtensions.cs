﻿using Microsoft.EntityFrameworkCore;
using ShoeShop.Repository.Entities;
using System;
using System.Collections.Generic;

namespace ShoeShop.Repository.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Supplier Seed Data
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = 1, Name = "Alpha Footwear Co.", ContactEmail = "contact@alpha.com", ContactPhone = "123-456-7890", Address = "101 Main St", IsActive = true },
                new Supplier { Id = 2, Name = "Beta Sneakers Inc.", ContactEmail = "info@beta.net", ContactPhone = "987-654-3210", Address = "202 Elm Ave", IsActive = true },
                new Supplier { Id = 3, Name = "Gamma Sports Gear", ContactEmail = "sales@gamma.org", ContactPhone = "555-123-4567", Address = "303 Oak Ln", IsActive = true }
            );

            // Shoe Seed Data: Ginawa na nating static ang petsa
            var fixedDate = DateTime.Parse("2024-01-01");

            var shoe1 = new Shoe { Id = 1, Name = "Runner 5000", Brand = "A-Brand", Cost = 50.00m, Price = 120.00m, Description = "Lightweight running shoe.", ImageUrl = null, IsActive = true, CreatedDate = fixedDate };
            var shoe2 = new Shoe { Id = 2, Name = "Streetwalker Classic", Brand = "B-Casual", Cost = 35.00m, Price = 90.00m, Description = "Everyday casual sneaker.", ImageUrl = null, IsActive = true, CreatedDate = fixedDate };
            var shoe3 = new Shoe { Id = 3, Name = "Court King Pro", Brand = "C-Hoops", Cost = 80.00m, Price = 180.00m, Description = "Professional basketball shoe.", ImageUrl = null, IsActive = true, CreatedDate = fixedDate };

            modelBuilder.Entity<Shoe>().HasData(shoe1, shoe2, shoe3);

            // ShoeColorVariation Seed Data
            // FIX: Inalis ang HexCode sa lahat ng entries para hindi mag-fail ang build.
            modelBuilder.Entity<ShoeColorVariation>().HasData(
                new ShoeColorVariation { Id = 1, ShoeId = 1, ColorName = "Black/White", StockQuantity = 20, ReorderLevel = 10, IsActive = true },
                new ShoeColorVariation { Id = 2, ShoeId = 1, ColorName = "Volt Green", StockQuantity = 15, ReorderLevel = 10, IsActive = true },
                new ShoeColorVariation { Id = 3, ShoeId = 2, ColorName = "Pure White", StockQuantity = 5, ReorderLevel = 5, IsActive = true },
                new ShoeColorVariation { Id = 4, ShoeId = 2, ColorName = "Navy Blue", StockQuantity = 25, ReorderLevel = 5, IsActive = true },
                new ShoeColorVariation { Id = 5, ShoeId = 3, ColorName = "Red Hot", StockQuantity = 12, ReorderLevel = 8, IsActive = true }
            );
        }
    }
}
