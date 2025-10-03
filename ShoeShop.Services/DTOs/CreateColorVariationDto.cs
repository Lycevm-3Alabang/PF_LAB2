// File: CreateColorVariationDto.cs
namespace ShoeShop.Services.DTOs
{
    public class CreateColorVariationDto
    {
        public string Color { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public decimal UnitCost { get; set; }
    }
}
