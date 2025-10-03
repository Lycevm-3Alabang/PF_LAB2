using ShoeShop.Repository.Entities;

namespace ShoeShop.Repository.Entities

{
    public class InventoryDto
    {
        public int ShoeId { get; set; }
        public string ShoeName { get; set; } = string.Empty;
        public int TotalStock { get; set; }
    }
}
