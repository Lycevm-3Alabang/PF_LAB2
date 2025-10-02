using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeShop.Entities
{
    public class ShoeColorVariation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Shoe")]
        public int ShoeId { get; set; }
        public Shoe Shoe { get; set; }
        [Required]
        [MaxLength(30)]
        public string ColorName { get; set; }
        [MaxLength(7)]
        public string HexCode { get; set; }
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; } = 5;
        public bool IsActive { get; set; }
        public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public ICollection<StockPullOut> StockPullOuts { get; set; }
    }
}
