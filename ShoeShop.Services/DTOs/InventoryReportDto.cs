namespace ShoeShop.Services.DTOs
{
    public class InventoryReportDto
    {
        public int ShoeId { get; set; }
        public string ShoeName { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public int TotalStock { get; set; }
    }
}