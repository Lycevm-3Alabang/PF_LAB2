using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeShop.Entities
{
    public class PurchaseOrderItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PurchaseOrder")]
        public int PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        [ForeignKey("ShoeColorVariation")]
        public int ShoeColorVariationId { get; set; }
        public ShoeColorVariation ShoeColorVariation { get; set; }
        public int QuantityOrdered { get; set; }
        public int QuantityReceived { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitCost { get; set; }
    }
}
