using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeShop.Repository.Entities
{
    public class StockPullOut
    {
        public int Id { get; set; }

        public int ShoeColorVariationId { get; set; }

        public int Quantity { get; set; }

        [Required]
        [MaxLength(50)]
        public string Reason { get; set; } // Damaged, Returned, Promotional, etc.

        public string? ReasonDetails { get; set; }

        [Required]
        [MaxLength(100)]
        public string RequestedBy { get; set; }

        [MaxLength(100)]
        public string? ApprovedBy { get; set; }

        public DateTime PullOutDate { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } // Pending, Approved, Completed, Rejected

        [ForeignKey("ShoeColorVariationId")]
        public ShoeColorVariation ShoeColorVariation { get; set; }
    }
}