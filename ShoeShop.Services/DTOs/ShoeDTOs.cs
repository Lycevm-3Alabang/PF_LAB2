namespace ShoeShop.Services.DTOs
{
    public class ShoeDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public double RetailPrice { get; set; }
        public bool IsActive { get; set; }

        // ✅ Dapat ito ay ColorVariationDto
        public List<ColorVariationDto> ColorVariations { get; set; } = new();
    }
}
