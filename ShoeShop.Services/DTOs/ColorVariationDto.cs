namespace ShoeShop.Services.DTOs
{
    public class ColorVariationDto
    {
        public int Id { get; set; }
        public string Color { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public decimal UnitCost { get; set; }
    }
}
