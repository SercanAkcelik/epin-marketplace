using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epin.Models
{
    /// <summary>
    /// Ürün entity sınıfı.
    /// E-pin satışı yapılan dijital ürünler.
    /// </summary>
    public class Product
    {
        [Key]
        public int ProductsID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string GameName { get; set; }

        public bool Active { get; set; } = true;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// Mevcut stok (EpinCode tablosundan hesaplanır)
        /// </summary>
        public int Stock { get; set; }

        public string? Description { get; set; }

        public string? ImagePath { get; set; }

        /// <summary>
        /// İndirim yüzdesi (0-100)
        /// </summary>
        public int DiscountPercentage { get; set; } = 0;

        /// <summary>
        /// İndirimli fiyat (hesaplanmış)
        /// </summary>
        [NotMapped]
        public decimal DiscountedPrice => 
            Price - (Price * DiscountPercentage / 100);
    }
}
