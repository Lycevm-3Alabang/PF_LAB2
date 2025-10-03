using ShoeShop.Repository.Entities;


namespace ShoeShop.Services.DTOs
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
    }
}
