using ShoeShop.Repository.Entities;
using System; // Idinagdag ang System para sa DateTime

namespace ShoeShop.Services.DTOs
{
    public class StockPullOutDto
    {
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public int ShoeColorVariationId { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string RequestedBy { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        // FINAL FIX: Idinagdag ang missing property
        public DateTime PullOutDate { get; set; }
    }
}