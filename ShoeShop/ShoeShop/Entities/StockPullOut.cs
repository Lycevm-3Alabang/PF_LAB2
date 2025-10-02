using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeShop.Entities
{
    public enum StockPullOutStatus
    {
        Pending,
        Approved,
        Completed,
        Rejected
    }

    public class StockPullOut
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ShoeColorVariation")]
        public int ShoeColorVariationId { get; set; }
        public ShoeColorVariation ShoeColorVariation { get; set; }
        public int Quantity { get; set; }
        [Required]
        [MaxLength(30)]
        public string Reason { get; set; }
        public string ReasonDetails { get; set; }
        [Required]
        [MaxLength(50)]
        public string RequestedBy { get; set; }
        [MaxLength(50)]
        public string ApprovedBy { get; set; }
        public DateTime PullOutDate { get; set; }
        public StockPullOutStatus Status { get; set; }
    }
}
