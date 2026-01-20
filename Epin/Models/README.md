# 📁 Models

Bu klasör, Entity Framework Core entity sınıflarını içermektedir.

## 📋 Entity Listesi

### 👤 Kullanıcı & Yetkilendirme
| Model | Açıklama |
|-------|----------|
| `Users` | Kullanıcı bilgileri (email, şifre, GoogleId) |
| `Role` | Roller (Admin, Customer, Seller, Manager) |

### 🛒 E-ticaret
| Model | Açıklama |
|-------|----------|
| `Product` | Ürün bilgileri, fiyat, indirim |
| `EpinCode` | Dijital kodlar (satılmamış/satılmış) |
| `Order` | Sipariş ana kaydı |
| `OrderItem` | Sipariş kalemleri |
| `Payment` | Ödeme detayları ve hata logları |

### 🎫 Kupon & Kampanya
| Model | Açıklama |
|-------|----------|
| `Coupon` | İndirim kuponları |
| `CouponUsage` | Kupon kullanım kayıtları |

### 🎁 Çekiliş
| Model | Açıklama |
|-------|----------|
| `Raffle` | Çekiliş bilgileri |
| `RaffleParticipant` | Katılımcılar |

### 📊 Referans/Bayi
| Model | Açıklama |
|-------|----------|
| `Cell` | Bayi/Referans bilgileri |
| `CellLog` | Referans aktivite logları |
| `CellFraudDetection` | Fraud tespitleri |

### 📢 Diğer
| Model | Açıklama |
|-------|----------|
| `Banner` | Ana sayfa banner görselleri |
| `Notification` | Kullanıcı bildirimleri |
| `ProductReview` | Ürün yorumları |
| `PasswordResetToken` | Şifre sıfırlama tokenları |

---

> ⚠️ **Not:** Kaynak kod özeldir. Sadece örnek dosyalar paylaşılmaktadır.
