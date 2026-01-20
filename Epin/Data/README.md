# 📁 Data

Bu klasör, Entity Framework Core DbContext sınıfını içermektedir.

## 📋 İçerik

### EpinDbContext

Tüm entity sınıflarını yöneten ana DbContext:

```csharp
public class EpinDbContext : DbContext
{
    // DbSet tanımlamaları
    public DbSet<Users> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<EpinCode> EpinCodes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<CouponUsage> CouponUsages { get; set; }
    public DbSet<Cell> Cells { get; set; }
    public DbSet<CellLog> CellLogs { get; set; }
    public DbSet<CellFraudDetection> CellFraudDetections { get; set; }
    public DbSet<Raffle> Raffles { get; set; }
    public DbSet<RaffleParticipant> RaffleParticipants { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<ProductReview> ProductReviews { get; set; }
    public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
}
```

## 🗄️ Veritabanı

- **SQL Server** kullanılmaktadır
- **Entity Framework Core** ORM
- **Code-First** yaklaşımı
- **Migrations** ile şema yönetimi

---

> ⚠️ **Not:** Kaynak kod özeldir.
