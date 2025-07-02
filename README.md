# 📝 Blog Management System with ASP.NET Core

Bu proje, modern web geliştirme pratiklerini barındıran kapsamlı bir blog yönetim sistemidir. ASP.NET Core ve Entity Framework ile inşa edilen sistem; kullanıcı yönetimi, içerik kontrolü, yorum mekanizması ve daha fazlasını dinamik bir yapıda sunmaktadır.

## 🚀 Öne Çıkan Özellikler

### 👤 Kullanıcı Yönetimi
- ASP.NET Core Identity ile güvenli kullanıcı girişi ve kaydı
- Kullanıcı profili düzenleme ve profil görseli güncelleme

### ✍️ İçerik Yönetimi
- Makale ekleme, silme, güncelleme ve detaylı görüntüleme
- Makalelere kategori atama ve kategori bazlı listeleme
- Gelişmiş admin paneli ile içerik ve yorum yönetimi

### 💬 Yorum Sistemi
- AJAX destekli yorum gönderimi (ViewComponent ile entegre yapı)
- Toksik içerik kontrolü (HuggingFace - ToxicBERT modeli ile)
- TR-EN arası çeviri özelliği (HuggingFace Translation API ile)

### 🎨 Arayüz ve Etkileşim
- ViewComponent, Partial View ve jQuery AJAX ile modern yaklaşım
- Tam responsive tasarım (mobil, tablet ve masaüstü uyumlu)

### 📊 Yönetici Paneli
- Dashboard üzerinde içerik, kategori ve yorum istatistikleri
- Yetkili kullanıcılar için içerik ve kullanıcı kontrolü

## 🧰 Kullanılan Teknolojiler
- **Backend:** ASP.NET Core 8.0, Entity Framework Core
- **Frontend:** Razor View Engine, jQuery, Bootstrap 5, SweetAlert2
- **AI Servisleri:** HuggingFace (ToxicBERT & Translation API)
- **Veritabanı:** MS SQL Server
