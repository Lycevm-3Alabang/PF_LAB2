using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

// FIX: Ito ang missing references para makita ang klase at interface
using ShoeShop.Repository.Data;
using ShoeShop.Repository.Entities;
using ShoeShop.Repository.Interfaces;

namespace ShoeShop.Repository.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        // Ginamit na ang ApplicationDbContext
        private readonly ApplicationDbContext _context;

        // Ginamit na ang ApplicationDbContext sa constructor
        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Implementation ng ISupplierRepository methods

        public async Task<Supplier> AddSupplierAsync(Supplier supplier)
        {
            // Ito ang code na nagco-cause ng error kung hindi pa naka-declare sa DbContext
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier?> GetSupplierByIdAsync(int supplierId)
        {
            return await _context.Suppliers.FindAsync(supplierId);
        }

        public async Task UpdateSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
        }
    }
}
