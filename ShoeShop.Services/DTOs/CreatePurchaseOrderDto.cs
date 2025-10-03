namespace ShoeShop.Services.DTOs
{
    public class CreatePurchaseOrderDto
    {
        public int SupplierId { get; set; }
        public List<PurchaseOrderItemDto> Items { get; set; } = new List<PurchaseOrderItemDto>();
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }

    public class PurchaseOrderItemDto
    {
        public int ShoeColorVariationId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
