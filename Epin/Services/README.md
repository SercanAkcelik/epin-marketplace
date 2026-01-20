# 📁 Services

Bu klasör, iş mantığı servislerini içermektedir.

## 📋 Servis Listesi

### 💳 Ödeme
| Servis | Açıklama |
|--------|----------|
| `IyzicoPaymentService` | Iyzico 3D Secure ödeme entegrasyonu |
| `PaymentErrorHandler` | Ödeme hatası kategorize ve loglama |

### 🔐 Güvenlik
| Servis | Açıklama |
|--------|----------|
| `PasswordService` | BCrypt şifre hashleme/doğrulama |
| `PasswordResetService` | Token oluşturma, doğrulama, rate limiting |

### 📧 İletişim
| Servis | Açıklama |
|--------|----------|
| `EmailService` | SMTP email gönderimi |
| `NotificationService` | Kullanıcı bildirimleri |

### 📊 Referans/Bayi
| Servis | Açıklama |
|--------|----------|
| `CellService` | Bayi CRUD işlemleri |
| `CellTrackingService` | Aktivite loglama, fraud detection |

### 🎁 Diğer
| Servis | Açıklama |
|--------|----------|
| `RaffleService` | Çekiliş yönetimi, kazanan seçimi |
| `ReportService` | Satış raporları, istatistikler |
| `ReviewService` | Ürün yorum yönetimi |

## 🏗️ Mimari

Tüm servisler Dependency Injection ile yönetilir:

```csharp
// Program.cs
builder.Services.AddScoped<IyzicoPaymentService>();
builder.Services.AddScoped<CellService>();
builder.Services.AddScoped<RaffleService>();
// ...
```

---

> ⚠️ **Not:** Kaynak kod özeldir. Sadece örnek dosyalar paylaşılmaktadır.
