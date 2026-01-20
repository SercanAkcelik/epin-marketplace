# 📁 Controllers

Bu klasör, MVC Controller sınıflarını içermektedir.

## 📋 Controller Listesi

| Controller | Açıklama |
|------------|----------|
| `AdminController` | Admin panel işlemleri, dashboard, CRUD |
| `AuthController` | Giriş, kayıt, Google OAuth, şifre sıfırlama |
| `CartController` | Sepet işlemleri, ürün ekleme/çıkarma |
| `CouponController` | Kupon doğrulama ve uygulama |
| `EpinController` | E-pin kod görüntüleme |
| `HomeController` | Ana sayfa, banner, popüler ürünler |
| `MaintenanceController` | Bakım modu sayfası |
| `PaymentController` | Iyzico 3D Secure ödeme işlemleri |
| `ProductController` | Ürün listeleme, detay, filtreleme |
| `ProfileController` | Kullanıcı profili, siparişler, güvenlik |
| `RaffleController` | Çekiliş katılım işlemleri |
| `SearchController` | Ürün arama |

## 🔒 Yetkilendirme

Controller'lar rol tabanlı yetkilendirme kullanır:
- `[Authorize]` - Giriş yapmış kullanıcı gerektirir
- `[AdminOnly]` - Sadece Admin rolü
- `[SellerOrAdmin]` - Seller veya Admin rolü

---

> ⚠️ **Not:** Kaynak kod özeldir. Sadece örnek dosyalar paylaşılmaktadır.
