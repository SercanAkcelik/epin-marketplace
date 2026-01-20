# 🎮 Epin Mağaza Sistemi - Kapsamlı Teknik Dokümantasyon

> **Dijital Ürün Satış Platformu** | ASP.NET Core MVC | Entity Framework Core | SQL Server

---

## 📋 İçindekiler

1. [Genel Bakış](#-genel-bakış)
2. [Sistem Mimarisi](#-sistem-mimarisi)
3. [Veritabanı Şeması](#-veritabanı-şeması)
4. [Modüller ve Sistemler](#-modüller-ve-sistemler)
5. [API ve Entegrasyonlar](#-api-ve-entegrasyonlar)
6. [Güvenlik](#-güvenlik)
7. [Dosya Yapısı](#-dosya-yapısı)

---

## 🎯 Genel Bakış

Epin Mağaza Sistemi, dijital oyun kodları (E-pin) satışı için geliştirilmiş profesyonel bir e-ticaret platformudur.

### Temel Özellikler

| Özellik | Açıklama |
|---------|----------|
| 🛒 **E-pin Satışı** | Dijital oyun kodlarının güvenli satışı ve teslimi |
| 💳 **Ödeme Entegrasyonu** | Iyzico 3D Secure ödeme altyapısı |
| 👥 **Kullanıcı Yönetimi** | Rol tabanlı erişim kontrolü (Admin, Customer, Seller) |
| 🎁 **Çekiliş Sistemi** | Otomatik veya manuel çekiliş yönetimi |
| 🏷️ **Kupon Sistemi** | Yüzde veya sabit indirim kuponları |
| 📊 **Referans Sistemi** | Bayi/Satıcı komisyon takibi |
| 📢 **Bildirim Sistemi** | Kullanıcılara anlık bildirimler |
| 🎠 **Banner Yönetimi** | Dinamik görsel ve video bannerlar |

---

## 🏗 Sistem Mimarisi

### Uygulama Katmanları

```mermaid
graph TB
    subgraph "Sunum Katmanı"
        UI[Views / Razor Pages]
        VC[ViewComponents]
    end
    
    subgraph "Uygulama Katmanı"
        CTRL[Controllers]
        MW[Middleware]
    end
    
    subgraph "İş Mantığı Katmanı"
        SVC[Services]
        VAL[Validation]
    end
    
    subgraph "Veri Erişim Katmanı"
        CTX[EpinDbContext]
        MDL[Models]
    end
    
    subgraph "Altyapı"
        DB[(SQL Server)]
        EXT[Harici API'ler]
    end
    
    UI --> CTRL
    VC --> CTRL
    CTRL --> SVC
    CTRL --> MW
    SVC --> CTX
    CTX --> MDL
    MDL --> DB
    SVC --> EXT
    
    style UI fill:#6366f1,color:#fff
    style CTRL fill:#10b981,color:#fff
    style SVC fill:#f59e0b,color:#fff
    style CTX fill:#ec4899,color:#fff
    style DB fill:#3b82f6,color:#fff
```

### Controller Yapısı

```mermaid
graph LR
    subgraph "Admin Controllers"
        AC[AdminController]
        ACC[AdminCellController]
        ARC[AdminRaffleController]
    end
    
    subgraph "Public Controllers"
        HC[HomeController]
        PC[ProductsController]
        RC[RaffleController]
    end
    
    subgraph "User Controllers"
        AUTH[AuthController]
        PROF[ProfileController]
        CART[CartController]
        PAY[PaymentController]
    end
    
    subgraph "System Controllers"
        MNT[MaintenanceController]
        REV[ReviewController]
    end
    
    style AC fill:#ef4444,color:#fff
    style AUTH fill:#6366f1,color:#fff
    style HC fill:#10b981,color:#fff
    style PAY fill:#f59e0b,color:#fff
```

### Servis Bağımlılıkları

```mermaid
graph TD
    subgraph "Payment Services"
        IPS[IyzicoPaymentService]
    end
    
    subgraph "User Services"
        ES[EmailService]
        PRS[PasswordResetService]
        PS[PasswordService]
    end
    
    subgraph "Business Services"
        CS[CellService]
        CTS[CellTrackingService]
        RS[RaffleService]
        NS[NotificationService]
        RPS[ReportService]
        RVS[ReviewService]
    end
    
    IPS --> ES
    CS --> CTS
    PRS --> ES
    
    style IPS fill:#f59e0b,color:#fff
    style ES fill:#3b82f6,color:#fff
    style CS fill:#10b981,color:#fff
```

---

## 💾 Veritabanı Şeması

### Ana Tablolar İlişki Diyagramı

```mermaid
erDiagram
    Users ||--o{ Orders : places
    Users ||--o| Cell : referred_by
    Users }o--|| Role : has
    
    Orders ||--|{ OrderItems : contains
    Orders ||--|{ Payments : has
    Orders ||--|{ EpinCodes : delivers
    Orders }o--o| Cell : attributed_to
    Orders }o--o| Coupon : uses
    
    Products ||--|{ EpinCodes : has
    Products ||--|{ OrderItems : sold_as
    Products ||--o{ ProductReviews : reviewed
    
    Cell ||--|{ CellLogs : tracks
    Cell ||--|{ CellFraudDetection : monitors
    
    Raffle ||--|{ RaffleEntries : receives
    Raffle }o--o| Users : won_by
    
    Coupon ||--|{ CouponUsages : tracked
    
    Users {
        int Id PK
        string UserName
        string Password
        string Email
        string GoogleId
        int RoleId FK
        int CellId FK
        datetime CreatedAt
    }
    
    Products {
        int ProductsID PK
        string Name
        string GameName
        decimal Price
        decimal DiscountPercentage
        int Stock
        bool Active
        bool IsPopular
    }
    
    Orders {
        int Id PK
        int UserId FK
        string OrderNumber
        decimal TotalPrice
        string Status
        string CouponCode
        int CellId FK
    }
    
    Payments {
        int Id PK
        int OrderId FK
        string Provider
        string Status
        decimal PaidPrice
        string ErrorCode
        string ErrorMessage
    }
    
    EpinCodes {
        int Id PK
        int ProductId FK
        string Code
        bool IsSold
        int OrderId FK
    }
    
    Cell {
        int Id PK
        string Name
        string ReferenceCode
        int OwnerUserId FK
        decimal CommissionPercentage
        bool IsActive
    }
```

### Ödeme ve Sipariş Akışı

```mermaid
sequenceDiagram
    actor User
    participant Cart as 🛒 Sepet
    participant Payment as 💳 PaymentController
    participant Iyzico as 🏦 Iyzico API
    participant DB as 💾 Database
    participant Epin as 🎮 EpinCodes
    
    User->>Cart: Sepete Ürün Ekle
    Cart->>Payment: Ödeme Başlat
    Payment->>DB: Order Oluştur (Pending)
    Payment->>Iyzico: 3D Secure Başlat
    Iyzico-->>User: 3D Secure Sayfası
    User->>Iyzico: SMS Onayı
    Iyzico->>Payment: Callback
    
    alt Ödeme Başarılı
        Payment->>DB: Order Status = Completed
        Payment->>DB: Payment Status = Success
        Payment->>Epin: E-pin Kodlarını Ata
        Epin->>DB: IsSold = true
        Payment-->>User: ✅ Başarılı + Kodlar
    else Ödeme Başarısız
        Payment->>DB: Payment Status = Failed
        Payment->>DB: ErrorCode, ErrorMessage Kaydet
        Payment-->>User: ❌ Hata Mesajı
    end
```

---

## 🧩 Modüller ve Sistemler

### 1. 🔐 Kimlik Doğrulama Sistemi

```mermaid
flowchart TD
    subgraph "Giriş Yöntemleri"
        LP[Email/Şifre Login]
        GL[Google OAuth 2.0]
    end
    
    subgraph "Şifre Yönetimi"
        REG[Kayıt]
        FP[Şifremi Unuttum]
        RP[Şifre Sıfırla]
    end
    
    subgraph "Session Yönetimi"
        SS[Session Storage]
        AUTH[Authentication Cookie]
    end
    
    LP --> SS
    GL --> AUTH
    REG --> LP
    FP --> RP
    RP --> LP
    
    style LP fill:#6366f1,color:#fff
    style GL fill:#ea4335,color:#fff
    style SS fill:#10b981,color:#fff
```

**Özellikler:**
- ✅ Email/Şifre ile klasik giriş
- ✅ Google OAuth 2.0 entegrasyonu
- ✅ BCrypt ile şifre hashleme
- ✅ Şifremi unuttum email akışı
- ✅ 30 dakika session timeout
- ✅ Rol tabanlı erişim (Admin, Customer, Seller)

---

### 2. 💳 Ödeme Sistemi (Iyzico)

```mermaid
flowchart LR
    subgraph "Ödeme Akışı"
        A[Checkout] --> B[Form Oluştur]
        B --> C[3D Secure]
        C --> D{Callback}
        D -->|Başarılı| E[✅ Complete Order]
        D -->|Başarısız| F[❌ Log Error]
    end
    
    subgraph "Hata Yönetimi"
        F --> G[ErrorCode]
        F --> H[ErrorMessage]
        F --> I[ErrorGroup]
    end
    
    subgraph "Error Groups"
        I --> J[BANK]
        I --> K[USER]
        I --> L[SYSTEM]
    end
    
    style E fill:#10b981,color:#fff
    style F fill:#ef4444,color:#fff
```

**Özellikler:**
- ✅ Iyzico 3D Secure entegrasyonu
- ✅ Detaylı hata loglama (Bank/User/System)
- ✅ Kupon indirim entegrasyonu
- ✅ Otomatik E-pin teslimi
- ✅ Ödeme geçmişi raporlama

---

### 3. 🎁 Çekiliş Sistemi (Raffle)

```mermaid
stateDiagram-v2
    [*] --> Draft: Oluşturuldu
    Draft --> Scheduled: Zamanlama
    Scheduled --> Active: Başlangıç Tarihi
    Active --> Completed: Bitiş Tarihi
    Completed --> Finished: Kazanan Seçildi
    Active --> Cancelled: İptal
    
    note right of Active
        Katılım Koşulları:
        - Sadece Giriş
        - Ürün Satın Alma
        - Minimum Sipariş
    end note
```

**Katılım Türleri:**

| Tür | Açıklama |
|-----|----------|
| `LoginOnly` | Sadece giriş yapan kullanıcılar |
| `ProductPurchase` | Belirli ürünü satın alanlar |
| `MinOrderCount` | Minimum sipariş sayısına ulaşanlar |

---

### 4. 🏷️ Kupon Sistemi

```mermaid
flowchart TD
    subgraph "Kupon Türleri"
        PCT[Yüzde İndirim<br/>%10, %25, vb.]
        FIX[Sabit İndirim<br/>₺50, ₺100, vb.]
    end
    
    subgraph "Kupon Kontrolleri"
        A{Aktif mi?}
        B{Tarih Geçerli mi?}
        C{Kullanım Limiti?}
        D{Min. Sipariş Tutarı?}
        E{Kullanıcı Limiti?}
    end
    
    subgraph "Sonuç"
        OK[✅ Kupon Uygulandı]
        FAIL[❌ Kupon Geçersiz]
    end
    
    PCT --> A
    FIX --> A
    A -->|Evet| B
    A -->|Hayır| FAIL
    B -->|Evet| C
    B -->|Hayır| FAIL
    C -->|OK| D
    C -->|Limit Dolu| FAIL
    D -->|OK| E
    D -->|Yetersiz| FAIL
    E -->|OK| OK
    E -->|Limit Aşıldı| FAIL
    
    style OK fill:#10b981,color:#fff
    style FAIL fill:#ef4444,color:#fff
```

---

### 5. 📊 Referans/Bayi Sistemi (Cell)

```mermaid
flowchart LR
    subgraph "Referans Akışı"
        A[Bayi/Satıcı] -->|Referans Linki| B[Yeni Kullanıcı]
        B -->|Kayıt| C[Cell Atama]
        C -->|Satın Alma| D[Komisyon Takibi]
    end
    
    subgraph "Cell Özellikleri"
        E[ReferenceCode<br/>Unique URL-safe]
        F[CommissionPercentage<br/>%5, %10, vb.]
        G[IsActive<br/>Aktif/Pasif]
    end
    
    subgraph "Raporlama"
        H[Referred Users]
        I[Referred Orders]
        J[Total Commission]
    end
    
    D --> H
    D --> I
    D --> J
    
    style A fill:#6366f1,color:#fff
    style D fill:#f59e0b,color:#fff
```

**Cell Log Türleri:**
- `UserRegistration` - Yeni kullanıcı kaydı
- `OrderCreation` - Sipariş oluşturma
- `Commission` - Komisyon hesaplama

---

### 6. 🎠 Banner Yönetimi

```mermaid
graph LR
    subgraph "Banner Türleri"
        IMG[🖼️ Görsel Banner]
        VID[🎬 Video Banner]
    end
    
    subgraph "Özellikler"
        A[Title]
        B[LinkUrl]
        C[Order/Sıralama]
        D[IsActive]
    end
    
    subgraph "Görüntüleme"
        E[Ana Sayfa Slider]
    end
    
    IMG --> A
    VID --> A
    A --> E
    B --> E
    C --> E
    
    style IMG fill:#3b82f6,color:#fff
    style VID fill:#ec4899,color:#fff
```

---

## 🔌 API ve Entegrasyonlar

### Harici Servisler

```mermaid
graph TD
    subgraph "Epin Uygulaması"
        APP[ASP.NET Core App]
    end
    
    subgraph "Ödeme"
        IYZICO[Iyzico API<br/>3D Secure]
    end
    
    subgraph "Kimlik Doğrulama"
        GOOGLE[Google OAuth 2.0]
    end
    
    subgraph "Email"
        SMTP[SMTP Server<br/>Şifre Sıfırlama]
    end
    
    subgraph "Finans Verileri"
        FIN[Truncgil API<br/>Döviz/Altın]
    end
    
    APP <-->|Ödeme İşlemleri| IYZICO
    APP <-->|OAuth Login| GOOGLE
    APP -->|Email Gönder| SMTP
    APP -->|JSON Fetch| FIN
    
    style APP fill:#6366f1,color:#fff
    style IYZICO fill:#f59e0b,color:#fff
    style GOOGLE fill:#ea4335,color:#fff
```

### Admin Dashboard API'leri

| Endpoint | Kaynak | Veri |
|----------|--------|------|
| `/Admin` | Truncgil | USD, EUR, Gram Altın |
| Dashboard | Internal | Satış grafikleri, istatistikler |

---

## 🔒 Güvenlik

### Güvenlik Katmanları

```mermaid
flowchart TD
    subgraph "Kimlik Doğrulama"
        A[Session Authentication]
        B[Google OAuth 2.0]
        C[BCrypt Password Hashing]
    end
    
    subgraph "Yetkilendirme"
        D[Role-Based Access Control]
        E[Admin Middleware]
        F[Session Validation]
    end
    
    subgraph "Veri Güvenliği"
        G[SQL Injection Protection<br/>EF Core]
        H[XSS Protection]
        I[HTTPS Zorlaması]
    end
    
    subgraph "Ödeme Güvenliği"
        J[3D Secure]
        K[Payment Logging]
        L[Error Tracking]
    end
    
    A --> D
    B --> D
    C --> A
    D --> G
    E --> F
    J --> K
    
    style A fill:#6366f1,color:#fff
    style J fill:#f59e0b,color:#fff
    style G fill:#10b981,color:#fff
```

### Rol Tabanlı Erişim

| Rol | ID | Yetkiler |
|-----|----|----|
| **Admin** | 1 | Tüm yetkiler, Panel erişimi |
| **Customer** | 2 | Satın alma, Profil yönetimi |
| **Seller** | 3 | Cell yönetimi, Komisyon takibi |

---

## 📁 Dosya Yapısı

```
Epin/
├── 📁 Controllers/           # MVC Controller'lar
│   ├── AdminController.cs        # Admin dashboard
│   ├── AdminCellController.cs    # Referans yönetimi
│   ├── AdminRaffleController.cs  # Çekiliş yönetimi
│   ├── AuthController.cs         # Kimlik doğrulama
│   ├── CartController.cs         # Sepet işlemleri
│   ├── HomeController.cs         # Ana sayfa
│   ├── PaymentController.cs      # Ödeme işlemleri
│   ├── ProductsController.cs     # Ürün yönetimi
│   ├── ProfileController.cs      # Kullanıcı profili
│   ├── RaffleController.cs       # Çekiliş katılım
│   └── ReviewController.cs       # Ürün yorumları
│
├── 📁 Models/                # Veri modelleri
│   ├── Users.cs                  # Kullanıcı modeli
│   ├── Product.cs                # Ürün modeli
│   ├── Order.cs                  # Sipariş modeli
│   ├── Payment.cs                # Ödeme modeli
│   ├── EpinCode.cs               # E-pin kodları
│   ├── Cell.cs                   # Referans sistemi
│   ├── Raffle.cs                 # Çekiliş modeli
│   ├── Coupon.cs                 # Kupon modeli
│   ├── Banner.cs                 # Banner modeli
│   └── ...                       # Diğer modeller
│
├── 📁 Services/              # İş mantığı servisleri
│   ├── IyzicoPaymentService.cs   # Iyzico entegrasyonu
│   ├── CellService.cs            # Referans servisi
│   ├── RaffleService.cs          # Çekiliş servisi
│   ├── NotificationService.cs    # Bildirim servisi
│   ├── EmailService.cs           # Email servisi
│   └── ...                       # Diğer servisler
│
├── 📁 Views/                 # Razor Views
│   ├── 📁 Admin/                 # Admin panel sayfaları
│   ├── 📁 Auth/                  # Giriş/Kayıt sayfaları
│   ├── 📁 Products/              # Ürün sayfaları
│   ├── 📁 Shared/                # Layout ve partial'lar
│   └── ...
│
├── 📁 Data/                  # Veritabanı context
│   └── EpinDbContext.cs
│
├── 📁 Middleware/            # Custom middleware
│   └── MaintenanceMiddleware.cs
│
├── 📁 wwwroot/               # Statik dosyalar
│   ├── 📁 css/
│   ├── 📁 js/
│   ├── 📁 images/
│   └── 📁 uploads/
│
├── Program.cs                # Uygulama entry point
└── appsettings.json          # Konfigürasyon
```

---

## 📈 Raporlama ve İstatistikler

### Dashboard Metrikleri

```mermaid
pie title Ürün Durumu Dağılımı
    "Aktif Ürünler" : 75
    "Pasif Ürünler" : 25
```

### Admin Panel Özellikleri

- 📊 Son 7 günlük satış grafikleri
- 🎮 Oyunlara göre ürün dağılımı
- 💰 Gerçek zamanlı döviz/altın kurları
- 👥 Kayıtlı kullanıcı sayısı
- 📦 Stok durumu takibi
- 💳 Başarısız ödeme analizi

---

## 🚀 Kurulum ve Çalıştırma

### Gereksinimler

- .NET 8.0 SDK
- SQL Server 2019+
- Visual Studio 2022 / VS Code

### Konfigürasyon

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=...;Database=Epin;..."
  },
  "Authentication": {
    "Google": {
      "ClientId": "...",
      "ClientSecret": "..."
    }
  },
  "Iyzico": {
    "ApiKey": "...",
    "SecretKey": "...",
    "BaseUrl": "https://api.iyzipay.com"
  }
}
```

### Çalıştırma

```bash
# Veritabanı migration
dotnet ef database update

# Uygulamayı başlat
dotnet run
```

---

## 📝 Notlar

> [!IMPORTANT]
> Bu proje production-ready bir e-ticaret platformudur. Tüm ödeme işlemleri 3D Secure ile güvence altındadır.

> [!TIP]
> Admin panelindeki döviz kurları, birden fazla proxy kaynağından otomatik olarak çekilmektedir.

---

**Son Güncelleme:** Ocak 2026  
**Versiyon:** 1.0.0
