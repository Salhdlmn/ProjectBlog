# 📰 Modern Blog Sitesi – ASP.NET Core MVC

Bu proje, kullanıcıların makale yazabildiği, yorum yapabildiği ve içerikleri kategori bazlı takip edebildiği dinamik bir **blog platformudur**. ASP.NET Core teknolojileriyle geliştirilen sistem, yapay zeka destekli moderasyon ve modern kullanıcı deneyimiyle öne çıkıyor.

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

## 📷 Ekran Görüntüleri

Blog sitesine ait bazı temel ekran görüntüleri aşağıda yer almaktadır:

### Giriş, Kayıt ve Yazar Paneli
| Giriş Ekranı | Kayıt Sayfası | Yazar Paneli |
|-------------|----------------|--------------|
| ![Login](Images/Login.png) | ![Register](Images/Register.png) | ![Writer](Images/Writer.png) |

### Ana Sayfa, Dashboard ve Blog Oluşturma
| Ana Sayfa | Dashboard | Blog Oluşturma |
|----------|------------|----------------|
| ![BlogSite](Images/BlogSite.png) | ![Dashboard](Images/Dashboard.png) | ![CreateBlog](Images/CreateBlog.png) |

### Yorumlar, Hakkımda ve Son Makaleler
| Yorumlar | Hakkımda | Son Makaleler |
|----------|------------|----------------|
| ![Comment](Images/Comment.png) | ![AboutMe](Images/AboutMe.png) | ![LastArticle](Images/LastArticle.png) |

---

## 🧑‍💻 Geliştirici Notu

Bu proje, hem kullanıcı hem yönetici deneyimini merkeze alarak geliştirildi. Modern teknolojiler ve yapay zeka servisleriyle zenginleştirildi. Tamamen modüler yapısıyla yeni özellikler kolayca entegre edilebilir.
