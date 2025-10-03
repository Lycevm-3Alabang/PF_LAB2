using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShoeShop.Repository.Entities;


namespace ShoeShop.Repository.Entities
{
    public class ShoeColorVariation
    {
        public int Id { get; set; }

        public int ShoeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ColorName { get; set; }

        [MaxLength(7)]
        public int StockQuantity { get; set; }

        public int ReorderLevel { get; set; } = 5;

        public bool IsActive { get; set; } = true;

        [ForeignKey("ShoeId")]
        public Shoe Shoe { get; set; }

        public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();
        public ICollection<StockPullOut> StockPullOuts { get; set; } = new List<StockPullOut>();
    }
}