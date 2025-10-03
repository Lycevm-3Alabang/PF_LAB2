namespace ShoeShop.Services.DTOs
{
    public class CreatePullOutDto
    {
        public int ShoeColorVariationId { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string RequestedBy { get; set; } = string.Empty;
    }
}
