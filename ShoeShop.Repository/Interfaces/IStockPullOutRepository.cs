// FILE: ShoeShop.Repository\Interfaces\IStockPullOutRepository.cs

using ShoeShop.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Repository.Interfaces
{
    public interface IStockPullOutRepository
    {
        // Ito ang mga methods na kailangan ng PullOutService at ReportService
        Task<StockPullOut> AddPullOutAsync(StockPullOut pullOut);
        Task<StockPullOut?> GetPullOutByIdAsync(int pullOutId);
        Task UpdatePullOutAsync(StockPullOut pullOut);
        Task<IEnumerable<StockPullOut>> GetAllPullOutsAsync();
        Task AddAsync(StockPullOut entity);
    }
}