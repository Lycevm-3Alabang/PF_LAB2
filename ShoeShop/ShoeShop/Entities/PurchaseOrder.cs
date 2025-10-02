using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeShop.Entities
{
    public enum PurchaseOrderStatus
    {
        Pending,
        Confirmed,
        Shipped,
        Received,
        Cancelled
    }

    public class PurchaseOrder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string OrderNumber { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public PurchaseOrderStatus Status { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        public ICollection<PurchaseOrderItem> Items { get; set; }
    }
}
