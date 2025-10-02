using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoeShop.Entities
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string ContactEmail { get; set; }
        [MaxLength(20)]
        public string ContactPhone { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
