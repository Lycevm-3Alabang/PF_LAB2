using System;

namespace ShoeShop.Services.DTOs
{
    // Ito lang DAPAT ang kaisa-isang definition ng class sa file na ito
    public class PullOutRequestDto // <--- Dapat isa lang 'to
    {
        // ... (Properties mo: ShoeColorVariationId, Quantity, Reason, etc.)
        public int ShoeColorVariationId { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; }
        public string RequestedBy { get; set; }
        public DateTime PullOutDate { get; set; }
        public string Status { get; set; }

    }
}