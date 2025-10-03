using ShoeShop.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<InventoryReportDto>> GenerateInventoryReportAsync();
        Task<IEnumerable<TransactionDto>> GenerateTransactionReportAsync();
        Task<IEnumerable<StockPullOutDto>> GenerateStockPullOutReportAsync();
    }
}
