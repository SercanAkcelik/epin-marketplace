using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epin.Models
{
    /// <summary>
    /// Sipariş entity sınıfı.
    /// Ödeme ve e-pin teslimat takibi.
    /// </summary>
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        /// <summary>
        /// Benzersiz sipariş numarası (ORD-2026-XXXXX)
        /// </summary>
        [Required]
        public string OrderNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Pending, Completed, Failed, Cancelled
        /// </summary>
        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? PaidAt { get; set; }

        // Kupon snapshot
        public string? CouponCode { get; set; }
        public string? CouponDiscountType { get; set; }
        public decimal? CouponDiscountValue { get; set; }
        public decimal? CouponDiscountAmount { get; set; }

        // Referans snapshot
        public int? CellId { get; set; }
        public string? CellName { get; set; }
        public bool IsReferredOrder { get; set; } = false;

        // Navigation Properties
        [ForeignKey("UserId")]
        public virtual Users User { get; set; }

        [ForeignKey("CellId")]
        public virtual Cell? Cell { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<EpinCode> EpinCodes { get; set; }
    }
}
