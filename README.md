# 🎮 EPIN Marketplace

> **Dijital Ürün Satış Platformu** | ASP.NET Core MVC | Entity Framework Core | SQL Server

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server)
![Iyzico](https://img.shields.io/badge/Iyzico-3D_Secure-00A1E4?style=for-the-badge)

---

> ⚠️ **Bu repository showcase amaçlıdır. Kaynak kod özeldir.**
>
> Bu proje, dijital ürün (E-pin, Game Code) satışı için geliştirilmiş profesyonel bir e-ticaret platformudur.
> Aşağıda projenin özellikleri, mimarisi ve ekran görüntüleri yer almaktadır.

---

## 📋 Proje Hakkında

EPIN Marketplace, dijital oyun kodları satışı için tasarlanmış kapsamlı bir e-ticaret sistemidir. Platform, modern web teknolojileri kullanılarak geliştirilmiş olup, güvenli ödeme entegrasyonu ve tam özellikli admin paneli içermektedir.

---

## ✨ Özellikler

### 🛒 E-ticaret
- Ürün listeleme ve kategorilere göre filtreleme
- Sepet yönetimi
- Stok takibi ve E-pin kod yönetimi
- Otomatik E-pin teslimatı (ödeme sonrası anında)
- Ürün indirimleri ve kampanyalar

### 💳 Ödeme Sistemi
- **Iyzico 3D Secure** entegrasyonu
- Kredi/banka kartı ile güvenli ödeme
- Detaylı ödeme hata yönetimi ve loglama
- Kupon/indirim kodu sistemi

### 👥 Kullanıcı Yönetimi
- Email/şifre ile kayıt ve giriş
- **Google OAuth 2.0** ile tek tıkla giriş
- Şifremi unuttum (email ile sıfırlama)
- Rol tabanlı yetkilendirme (Admin, Customer, Seller)
- Profil ve sipariş geçmişi

### 🎁 Çekiliş Sistemi
- Farklı katılım koşulları:
  - Sadece üyelik
  - Belirli ürün satın alma
  - Minimum sipariş sayısı
- Otomatik/manuel kazanan seçimi
- Çekiliş sonuç bildirimleri

### 📊 Referans/Bayi Sistemi (Cell)
- Özel referans linkleri
- Komisyon oranı belirleme
- Satış takibi ve raporlama
- Fraud detection

### 🎠 İçerik Yönetimi
- Dinamik banner yönetimi (görsel + video)
- Bildirim sistemi
- Ürün yorumları ve puanlama

### ⚙️ Admin Panel
- Dashboard ve gerçek zamanlı istatistikler
- Ürün/kullanıcı/sipariş yönetimi
- Kupon oluşturma ve yönetimi
- Çekiliş yönetimi
- Bayi/referans yönetimi
- Detaylı raporlama
- Sistem ayarları

---

## 🏗 Teknoloji Stack

| Katman | Teknoloji |
|--------|-----------|
| **Backend** | ASP.NET Core 8.0 MVC |
| **ORM** | Entity Framework Core |
| **Veritabanı** | SQL Server |
| **Ödeme** | Iyzico 3D Secure API |
| **Kimlik Doğrulama** | Session + Google OAuth 2.0 |
| **Şifreleme** | BCrypt.Net |
| **Email** | SMTP (Gmail) |
| **Frontend** | Razor Views, Bootstrap, Chart.js |

---

## 📸 Ekran Görüntüleri

### Ana Sayfa
> Dinamik banner slider, popüler ürünler, kategoriler

### Ürün Detay
> Ürün bilgileri, stok durumu, sepete ekleme

### Sepet & Ödeme
> Kupon uygulama, Iyzico 3D Secure checkout

### Admin Dashboard
> Gerçek zamanlı istatistikler, döviz kurları, grafikler

### Admin - Ürün Yönetimi
> CRUD işlemleri, E-pin kod ekleme, stok takibi

### Admin - Sipariş Takibi
> Sipariş listesi, durum takibi, detaylar

*Ekran görüntüleri için `/screenshots` klasörüne bakınız.*

---

## 🗂 Proje Mimarisi

```
Epin/
├── Controllers/          # 12 MVC Controller
├── Models/               # 26 Entity sınıfı
├── Services/             # 15 Business Logic servisi
├── Views/                # 50+ Razor View
├── Data/                 # DbContext
├── Middleware/           # Custom middleware
└── wwwroot/              # Statik dosyalar
```

### Veritabanı Tabloları
- `Users` - Kullanıcı bilgileri
- `Products` - Ürünler
- `EpinCodes` - Dijital kodlar
- `Orders` - Siparişler
- `OrderItems` - Sipariş detayları
- `Payments` - Ödeme kayıtları
- `Coupons` - İndirim kuponları
- `Cells` - Bayi/Referans sistemi
- `Raffles` - Çekilişler
- `Banners` - Banner görselleri
- `Notifications` - Bildirimler
- ve daha fazlası...

---

## 🔒 Güvenlik

- ✅ BCrypt ile şifre hashleme
- ✅ 3D Secure ödeme doğrulaması
- ✅ SQL Injection koruması (EF Core)
- ✅ XSS koruması
- ✅ HTTPS zorlaması
- ✅ Session-based authentication
- ✅ Role-based authorization
- ✅ Rate limiting (şifre sıfırlama)

---

## 📄 Lisans

Bu proje özel mülkiyettir. Kaynak kodu paylaşılmamaktadır.

Proje hakkında daha fazla bilgi veya demo talebi için iletişime geçebilirsiniz.

---

## 📞 İletişim

**Sercan Akçelik**

[![GitHub](https://img.shields.io/badge/GitHub-SercanAkcelik-181717?style=flat-square&logo=github)](https://github.com/SercanAkcelik)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-Sercan_Akçelik-0A66C2?style=flat-square&logo=linkedin)](https://linkedin.com/in/sercanakcelik)

---

> 💡 **Demo veya işbirliği için iletişime geçebilirsiniz.**
