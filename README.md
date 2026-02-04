# 🚀 ASP.NET Core 9 - E-Commerce Web Application

Bu proje, Udemy - Sadık Turan rehberliğindeki "Komple Uygulamalı Web Geliştirme" eğitimi kapsamında geliştirilen, modern web teknolojilerini ve yazılım mimarilerini barındıran tam kapsamlı bir E-Ticaret projesidir.

# 📝 Proje Hakkında

Bu uygulama, bir E-Ticaret sitesinin sahip olması gereken temel kullanıcı süreçlerini ve kapsamlı bir yönetici (Admin) panelini içermektedir. Proje, sadece bir arayüz çalışması değil; ödeme sistemlerinden mail servislerine, veritabanı yönetiminden yayına alma (deployment) süreçlerine kadar uçtan uca bir deneyimi temsil etmektedir.

# 🛠️ Kullanılan Teknolojiler

**Backend:** ASP.NET Core 9 MVC

**Database:** MS SQL Server & Entity Framework Core

**Frontend:** HTML5, CSS3, Bootstrap 5

**Patterns:** Dependency Injection (DI)

**Integrations:**

- **İyzico API:** Güvenli ödeme sistemleri entegrasyonu.
- **Gmail Service:** Şifre değiştirme süreçleri için SMTP mail entegrasyonu.

**Deployment:** Hosting.com.tr üzerinden canlıya alınmıştır.

# ✨ Öne Çıkan Özellikler

**Kullanıcı Tarafı**

- Üyelik sistemi ve kullanıcı profili.
- Ürün listeleme, filtreleme ve detaylı inceleme.
- Sepet yönetimi ve dinamik alışveriş deneyimi.
- İyzico entegrasyonu ile güvenli ödeme adımları.

**Yönetim (Admin) Paneli**

- Full CRUD: Kategori, ürün, slider, rol ve kullanıcı yönetimi işlemleri.
- Sipariş Yönetimi: Gelen siparişleri takip etme, detay.

# 🏗️ Mimari Yapı (Key Concepts)

Proje geliştirilirken aşağıdaki mühendislik yaklaşımlarına dikkat edilmiştir:

**Dependency Injection:** Servislerin ve repository'lerin yönetimi constructor injection yöntemiyle yapılmıştır.

**Data Seeding:** Proje ilk ayağa kalktığında örnek verilerin otomatik oluşması sağlandı.

**Client-Side Validation:** Kullanıcı deneyimini artırmak için form doğrulamaları entegre edildi.

# 🚀 Kurulum ve Çalıştırma

Projeyi yerel bilgisayarınızda çalıştırmak isterseniz:

1. Bu depoyu klonlayın:

```bash
    git clone https://github.com/nureddincan/dotnet-ecommerce-app
```

2. **appsettings.Development.json** dosyasındaki ConnectionStrings bölümünü kendi SQL Server bilgilerinize göre güncelleyin.

3. Terminale üzerinden veritabanını oluşturun:
```bash
    dotnet ef database update
```
4. Projeyi çalıştırın:
```bash
    dotnet run
```