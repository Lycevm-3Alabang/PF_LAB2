using System.Threading.Tasks;

namespace ShoeShop.Services.Interfaces
{
    // Interface para sa Purchase Order operations
    public interface IPurchaseOrderService
    {
        // Sample method para sa paggawa ng purchase order.
        // Palitan ang 'object' ng tamang DTO o entity na gagamitin mo.
        Task<bool> CreatePurchaseOrderAsync(object orderDetails);
    }
}
