using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epin.Models
{
    /// <summary>
    /// Kullanıcı entity sınıfı.
    /// Email/şifre veya Google OAuth ile giriş destekler.
    /// </summary>
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// BCrypt ile hashlenmiş şifre
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Google OAuth kullanıcıları için
        /// </summary>
        public string? GoogleId { get; set; }

        public int RoleId { get; set; }

        /// <summary>
        /// Referans ile kayıt olduysa
        /// </summary>
        public int? CellId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [ForeignKey("CellId")]
        public virtual Cell? Cell { get; set; }
    }
}
