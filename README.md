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
- Üyelik sistemi ve kullanıcı profili ve yönetimi.
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

3. Terminal üzerinden veritabanını oluşturun:
```bash
    dotnet ef database update
```
4. Projeyi çalıştırın:
```bash
    dotnet run
```

# Ekran Görüntüleri

<img width="1919" height="1079" alt="Account-Create" src="https://github.com/user-attachments/assets/3ba2b08f-f61b-4285-9011-65d4cbc9b246" />

-------------

<img width="1671" height="843" alt="Account-Login" src="https://github.com/user-attachments/assets/7fa0b93d-908b-4936-b0f8-e44cb187d0e6" />

-------------

<img width="1920" height="1080" alt="Account-EditUser" src="https://github.com/user-attachments/assets/43e768c9-32b7-432f-88c1-9f30e3341cfd" />

-------------

<img width="1920" height="1080" alt="Account-OrderList" src="https://github.com/user-attachments/assets/cc744ec9-e51b-4e65-a60d-3be105e46bc4" />

-------------

<img width="1920" height="1080" alt="Account-ChangePassword" src="https://github.com/user-attachments/assets/812f8a2e-5a74-4f8d-abec-814b1c197b77" />

-------------

<img width="1920" height="1080" alt="Home-Index-1" src="https://github.com/user-attachments/assets/064c8222-cb9a-4d72-a9ed-c82e8561c98d" />

-------------

<img width="1920" height="1080" alt="Home-Index-2-2" src="https://github.com/user-attachments/assets/501dfccb-08f7-4a92-a80b-3f8beaa12a89" />

-------------

<img width="1920" height="1080" alt="Urunler-Query" src="https://github.com/user-attachments/assets/30f2dd50-0c2e-4060-aef3-ef9bd1e293bf" />

-------------

<img width="1920" height="1080" alt="Urun-Details" src="https://github.com/user-attachments/assets/c5457d34-b5e2-41ec-ab7e-eeaf31dd68de" />

-------------

<img width="1920" height="1080" alt="Urunler-Details-2" src="https://github.com/user-attachments/assets/67470c29-380f-4d53-b379-97ea93e6ec14" />

-------------

<img width="1920" height="1080" alt="Admin-Shopping-Cart" src="https://github.com/user-attachments/assets/059b7954-cb33-4176-b2f3-284fb0e6ebd0" />

-------------

<img width="1920" height="1080" alt="Order-Checkout-1" src="https://github.com/user-attachments/assets/72f0b7ec-bc90-413a-bb8e-7bfe74a2b2f7" />

-------------

<img width="1382" height="785" alt="Admin-Index" src="https://github.com/user-attachments/assets/eef57b54-06bc-4c78-a7a0-5fffb1cd8399" />

-------------

<img width="1404" height="723" alt="Admin-Kategori" src="https://github.com/user-attachments/assets/7286eb3a-9336-4096-be82-56c78ec8b0d8" />

-------------

<img width="1919" height="1079" alt="Admin-Urun" src="https://github.com/user-attachments/assets/433dfc60-bdfb-4d71-817f-d4cda039cfbe" />

-------------

<img width="1426" height="779" alt="Admin-Urun-Create" src="https://github.com/user-attachments/assets/32eae456-04e6-4571-bfa9-ca2ad321bf75" />

-------------

<img width="1392" height="596" alt="Admin-Urun-Edit" src="https://github.com/user-attachments/assets/a83afc42-1399-4c9f-bc96-3ecb8a8d8f48" />

-------------

<img width="1491" height="884" alt="Admin-Slider" src="https://github.com/user-attachments/assets/1def0663-2e87-435d-acb6-d166d0196de6" />

-------------

<img width="1446" height="591" alt="Admin-Slider-Create" src="https://github.com/user-attachments/assets/a51f4bb5-aa6d-49d6-b13b-0bc3aa51ac6f" />

-------------

<img width="1451" height="933" alt="Admin-Slider-Edit" src="https://github.com/user-attachments/assets/edd880f7-598c-4dba-bc40-6385c352372c" />

-------------

<img width="1593" height="868" alt="Admin-User" src="https://github.com/user-attachments/assets/ff45abf2-7b11-4de9-81e2-3134957e8869" />

-------------

<img width="1451" height="463" alt="Admin-User-Create" src="https://github.com/user-attachments/assets/685e80d5-4c92-465d-a734-2f5e1f40186a" />

-------------

<img width="1408" height="830" alt="Admin-User-Edit" src="https://github.com/user-attachments/assets/c75c251d-b351-41e2-b788-5105c1d52105" />

-------------

<img width="1442" height="607" alt="Admin-Order" src="https://github.com/user-attachments/assets/ddcbbe11-167d-48a1-9985-8f2e64fbbc89" />

-------------

<img width="1447" height="774" alt="Admin-Order-Details" src="https://github.com/user-attachments/assets/cecd7d53-569f-4eff-875b-65b62cae4f48" />
