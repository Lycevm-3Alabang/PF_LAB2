using System.Threading.Tasks;
using System.Collections.Generic;
// Tiyakin na ito ang tamang path sa iyong DTOs
using ShoeShop.Services.DTOs;

namespace ShoeShop.Services.Interfaces
{
    // Interface para sa Stock Pull Out operations (Fixes IPullOutService error)
    public interface IPullOutService
    {
        // Sample method para sa pagkuha ng lahat ng pull out history
        Task<IEnumerable<StockPullOutDto>> GetAllPullOutsAsync();
    }
}
