namespace ShoeShop.Services.DTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public DateTime Date { get; set; }
        public string Action { get; set; } = string.Empty;

        // 🔥 Added fields for reporting
        public int Quantity { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public string PerformedBy { get; set; } = string.Empty;
    }

    
}
