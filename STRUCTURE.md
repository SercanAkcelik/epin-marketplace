# 📁 Proje Yapısı

Bu dosya, EPIN Marketplace projesinin klasör ve dosya yapısını göstermektedir.

```
Epin/
│
├── 📂 Controllers/                    # MVC Controller'lar
│   ├── AdminController.cs             # Admin panel işlemleri
│   ├── AuthController.cs              # Giriş, kayıt, OAuth
│   ├── CartController.cs              # Sepet işlemleri
│   ├── CouponController.cs            # Kupon doğrulama
│   ├── EpinController.cs              # E-pin kod görüntüleme
│   ├── HomeController.cs              # Ana sayfa
│   ├── MaintenanceController.cs       # Bakım modu
│   ├── PaymentController.cs           # Iyzico ödeme
│   ├── ProductController.cs           # Ürün listeleme
│   ├── ProfileController.cs           # Kullanıcı profili
│   ├── RaffleController.cs            # Çekiliş katılım
│   └── SearchController.cs            # Arama
│
├── 📂 Models/                         # Entity sınıfları
│   ├── Users.cs                       # Kullanıcı
│   ├── Role.cs                        # Rol (Admin, Customer, Seller)
│   ├── Product.cs                     # Ürün
│   ├── EpinCode.cs                    # Dijital kod
│   ├── Order.cs                       # Sipariş
│   ├── OrderItem.cs                   # Sipariş kalemi
│   ├── Payment.cs                     # Ödeme kaydı
│   ├── Coupon.cs                      # İndirim kuponu
│   ├── CouponUsage.cs                 # Kupon kullanımı
│   ├── Cell.cs                        # Bayi/Referans
│   ├── CellLog.cs                     # Referans log
│   ├── CellFraudDetection.cs          # Fraud tespiti
│   ├── Raffle.cs                      # Çekiliş
│   ├── RaffleParticipant.cs           # Çekiliş katılımcısı
│   ├── Banner.cs                      # Ana sayfa banner
│   ├── Notification.cs                # Bildirim
│   ├── ProductReview.cs               # Ürün yorumu
│   ├── PasswordResetToken.cs          # Şifre sıfırlama
│   └── ViewModels/                    # DTO'lar
│       ├── LoginViewModel.cs
│       ├── RegisterViewModel.cs
│       ├── ProductDetailViewModel.cs
│       └── ...
│
├── 📂 Services/                       # İş mantığı servisleri
│   ├── IyzicoPaymentService.cs        # Ödeme entegrasyonu
│   ├── PaymentErrorHandler.cs         # Hata yönetimi
│   ├── CellService.cs                 # Bayi işlemleri
│   ├── CellTrackingService.cs         # Referans takip
│   ├── RaffleService.cs               # Çekiliş işlemleri
│   ├── EmailService.cs                # Email gönderimi
│   ├── PasswordService.cs             # Şifre hashleme
│   ├── PasswordResetService.cs        # Token yönetimi
│   ├── NotificationService.cs         # Bildirim gönderimi
│   ├── ReportService.cs               # Raporlama
│   └── ReviewService.cs               # Yorum işlemleri
│
├── 📂 Data/
│   └── EpinDbContext.cs               # Entity Framework DbContext
│
├── 📂 Middleware/
│   └── MaintenanceMiddleware.cs       # Bakım modu kontrolü
│
├── 📂 Views/                          # Razor Views
│   ├── 📂 Home/
│   │   └── Index.cshtml               # Ana sayfa
│   ├── 📂 Product/
│   │   ├── Index.cshtml               # Ürün listesi
│   │   └── Details.cshtml             # Ürün detay
│   ├── 📂 Cart/
│   │   └── Index.cshtml               # Sepet
│   ├── 📂 Auth/
│   │   ├── Login.cshtml               # Giriş
│   │   ├── Register.cshtml            # Kayıt
│   │   └── ForgotPassword.cshtml      # Şifre sıfırlama
│   ├── 📂 Profile/
│   │   ├── Index.cshtml               # Profil
│   │   ├── Orders.cshtml              # Siparişlerim
│   │   └── Security.cshtml            # Güvenlik
│   ├── 📂 Admin/
│   │   ├── Index.cshtml               # Dashboard
│   │   ├── Products/                  # Ürün CRUD
│   │   ├── Users/                     # Kullanıcı yönetimi
│   │   ├── Orders/                    # Sipariş yönetimi
│   │   ├── Coupons/                   # Kupon yönetimi
│   │   ├── Raffles/                   # Çekiliş yönetimi
│   │   ├── Banners/                   # Banner yönetimi
│   │   ├── Cells/                     # Bayi yönetimi
│   │   └── Reports/                   # Raporlar
│   └── 📂 Shared/
│       ├── _Layout.cshtml             # Ana layout
│       └── _AdminLayout.cshtml        # Admin layout
│
├── 📂 wwwroot/                        # Statik dosyalar
│   ├── 📂 css/
│   │   ├── site.css
│   │   └── admin-panel.css
│   ├── 📂 js/
│   │   └── site.js
│   ├── 📂 img/
│   │   ├── products/
│   │   └── banners/
│   └── 📂 uploads/
│
├── Program.cs                         # Uygulama başlangıcı
├── appsettings.json                   # Konfigürasyon
└── Epin.csproj                        # Proje dosyası
```

---

## 📊 Özet İstatistikler

| Kategori | Sayı |
|----------|------|
| Controllers | 12 |
| Models | 26 |
| Services | 11 |
| Views | 50+ |
| Middleware | 1 |

---

> ⚠️ **Not:** Bu repository showcase amaçlıdır. Kaynak kod özeldir.
