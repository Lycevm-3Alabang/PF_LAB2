namespace ShoeShop.Services.DTOs
{
    public class CreateShoeDto
    {
        public string ModelName { get; set; } = string.Empty;   // matches InventoryService
        public string Brand { get; set; } = string.Empty;
        public decimal RetailPrice { get; set; }
        public List<CreateColorVariationDto> ColorVariations { get; set; } = new();
    }
}
