# Şeker Kütüphane Sistemi

## Proje Hakkında
Bu proje, kütüphane yönetim sistemi için Windows Forms uygulamasıdır. Kullanıcı kayıt, giriş ve şifre yenileme işlemlerini destekler.

## Özellikler
- ✅ Kullanıcı Girişi (TC Kimlik No ile)
- ✅ Kullanıcı Kayıt
- ✅ Şifre Yenileme
- ✅ **Rol Bazlı Dashboard** (Çözüldü!)
- ✅ Hiyerarşik Yetki Sistemi
- ✅ **Çoklu Rol Desteği** (Yeni!)
- ✅ **Modern ve Tutarlı Tasarım** (Yeni!)

## Rol Sistemi ve Yetkiler

### 🎯 Hiyerarşi
```
Admin > Kütüphane Yetkilisi/Görevlisi > Üye
```

### 👤 Üye Yetkileri
- **Kitap Ara**: Kitap arama ve görüntüleme
- **Profilim**: Profil bilgilerini güncelleme
- **Sınırlı Erişim**: Sadece temel işlemler

### 👨‍💼 Kütüphane Yetkilisi/Görevlisi Yetkileri
- **Kitap Yönetimi**: Kitap arama, ekleme, düzenleme
- **Üye Yönetimi**: Üye ekleme, düzenleme, ceza verme
- **Emanet İşlemleri**: Kitap ödünç verme, alma
- **Orta Seviye Erişim**: Üye yönetimi + emanet işlemleri

### 👑 Admin Yetkileri
- **Kitap Yönetimi**: Tam kitap yönetimi (ekleme, düzenleme, silme)
- **Üye Yönetimi**: Tam üye yönetimi (ekleme, düzenleme, ceza verme, silme)
- **Emanet İşlemleri**: Tüm emanet işlemleri + geçmiş
- **Raporlar**: Detaylı raporlar ve istatistikler
- **Sistem Yönetimi**: Görevli yönetimi, sistem ayarları
- **Tam Erişim**: Tüm yetkiler

## API Bağlantısı
- **API URL**: `http://10.100.74.48:5000`
- **Authentication**: Basic Auth (sbuhs:sekerstajekip)

## Çözülen Sorunlar

### 🔧 Rol Bilgisi Sorunu (Çözüldü!)
**Sorun**: API'den gelen rol bilgisi doğru şekilde çekilemiyordu.

**Çözüm**: 
- API'den gelen `rol_adlari` array'i kullanılıyor
- Çoklu rol desteği eklendi
- En yüksek yetkili rol otomatik seçiliyor

**API Yanıt Formatı**:
```json
{
  "kullanici_id": 1,
  "ad": "Admin",
  "soyad": "Hesabı",
  "rol_ids": [1, 2, 3],
  "rol_adlari": ["Üye", "Kütüphane Yetkilisi", "Admin"]
}
```

**Rol Seçim Mantığı**:
1. `rol_adlari` array'i kontrol edilir
2. En yüksek yetkili rol seçilir: Admin > Kütüphane Yetkilisi > Üye
3. Dashboard bu role göre ayarlanır

### 🎯 Kayıt İşlemi Sorunu (Çözüldü!)
**Sorun**: Kayıt olma işleminde "Bad Request" hatası alınıyordu.

**Çözüm**:
1. **Debug Bilgileri Eklendi**: Gönderilen JSON ve API yanıtı loglanıyor
2. **Veri Doğrulama Geliştirildi**: Email, telefon, TC format kontrolleri
3. **Hata Yakalama İyileştirildi**: Detaylı hata mesajları
4. **API Endpoint Test Metodu**: Farklı endpoint'lerin test edilmesi

### 🎨 Tasarım Sorunu (Çözüldü!)
**Sorun**: Butonların yerleri değişiyordu ve tasarım tutarsızdı.

**Çözüm**:
1. **Tutarlı Buton Yerleşimi**: Tüm butonlar her zaman aynı yerde
2. **Modern Tasarım**: Flat design, hover efektleri
3. **Görsel Geri Bildirim**: Devre dışı butonlar gri renkte
4. **Kullanıcı Dostu**: Hover efektleri ve renk kodlaması

## Dashboard Sistemi

### 🎨 Tek Dashboard + Rol Bazlı Görünürlük
- **Avantaj**: Kod tekrarı yok, tutarlı UX, kolay bakım
- **Yaklaşım**: Aynı dashboard, farklı yetkiler
- **Dinamik**: Rol değişikliği anında yansır
- **Çoklu Rol**: Birden fazla rolü olan kullanıcılar için en yüksek yetki
- **Modern Tasarım**: Flat design, hover efektleri, tutarlı renk paleti

### 🔧 Teknik Detaylar
- **SetupRoleBasedAccess()**: Rol bazlı yetki ayarları
- **SetupUyePermissions()**: Üye yetkileri
- **SetupGorevliPermissions()**: Görevli yetkileri  
- **SetupAdminPermissions()**: Admin yetkileri
- **Rol Array Parsing**: `rol_adlari` array'inden rol seçimi
- **Button Hover Effects**: Modern hover efektleri
- **Disabled Button Styling**: Devre dışı butonlar için özel tasarım

### 📋 Buton Görünürlük Matrisi

| Buton | Üye | Kütüphane Yetkilisi | Admin |
|-------|-----|---------------------|-------|
| Kitap Ara/Yönetimi | ✅ Aktif | ✅ Aktif | ✅ Aktif |
| Profilim/Üye Yönetimi | ✅ Aktif | ✅ Aktif | ✅ Aktif |
| Emanet İşlemleri | ❌ Devre Dışı | ✅ Aktif | ✅ Aktif |
| Raporlar | ❌ Devre Dışı | ❌ Devre Dışı | ✅ Aktif |
| Sistem Yönetimi | ❌ Devre Dışı | ❌ Devre Dışı | ✅ Aktif |

### 🎨 Tasarım Özellikleri
- **Renk Paleti**: Kayseri Şeker Kurumsal Renkleri
  - **Ana Yeşil**: #008000 (Koyu yeşil - panel arka planı)
  - **Buton Yeşili**: #4CAF50 (Açık yeşil - aktif butonlar)
  - **Hover Yeşili**: #81C784 (Daha açık yeşil - hover efekti)
  - **Çıkış Kırmızısı**: #F44336 (Kırmızı - çıkış butonu)
  - **Devre Dışı Gri**: #BDBDBD (Gri - devre dışı butonlar)
  - **Arka Plan**: #F5F5F5 (Açık gri - form arka planı)
- **Buton Tasarımı**: Flat design, borderless
- **Hover Efektleri**: Mouse üzerine gelince renk değişimi
- **Devre Dışı Butonlar**: Gri renk (#BDBDBD) + "(Yetkiniz Yok)" yazısı
- **Çıkış Butonu**: Kırmızı renk (#F44336)
- **Font**: Segoe UI, Bold

## Kullanım

1. **Kayıt Olma**:
   - Tüm alanları doldurun
   - Geçerli email adresi girin
   - 11 haneli TC kimlik numarası girin
   - Şifrelerin eşleştiğinden emin olun

2. **Giriş Yapma**:
   - TC kimlik numarası ile giriş yapın
   - Şifrenizi girin
   - **Rolünüz otomatik olarak belirlenir**
   - Dashboard rolünüze göre açılır

3. **Dashboard Kullanımı**:
   - **Tüm butonlar her zaman aynı yerde**
   - Aktif butonlar mavi renkte
   - Devre dışı butonlar gri renkte ve "(Yetkiniz Yok)" yazısı ile
   - Hover efektleri ile etkileşimli tasarım
   - Her buton rolünüze uygun işlem yapar
   - **Çoklu rolünüz varsa en yüksek yetki kullanılır**

4. **Şifre Yenileme**:
   - TC kimlik numaranızı girin
   - Yeni şifrenizi belirleyin

## Teknik Detaylar

### Veri Formatı
Kayıt işleminde gönderilen JSON formatı:
```json
{
  "ad": "Kullanıcı Adı",
  "soyad": "Kullanıcı Soyadı", 
  "tc": "12345678901",
  "telefon": "5551234567",
  "email": "kullanici@email.com",
  "sifre": "hashlenmiş_şifre"
}
```

### Şifre Hashleme
Şifreler SHA256 ile hashlenerek gönderilir.

### API Endpoint'leri
- `POST /register` - Kullanıcı kaydı
- `POST /login-tc` - TC ile giriş
- `POST /verify-tc` - TC doğrulama
- `POST /reset-password` - Şifre sıfırlama

## Sorun Giderme

Eğer hala "Bad Request" hatası alıyorsanız:

1. API sunucusunun çalıştığından emin olun
2. Network bağlantınızı kontrol edin
3. Debug mesajlarını kontrol ederek gönderilen veriyi inceleyin
4. API yanıtını kontrol ederek hata detayını görün

## Geliştirici Notları

- Proje .NET 8.0 kullanıyor
- Windows Forms uygulaması
- Newtonsoft.Json kullanılıyor
- Async/await pattern kullanılıyor
- **Rol bazlı erişim kontrolü (RBAC)** implementasyonu
- **Tek dashboard, çoklu yetki** yaklaşımı
- **Çoklu rol desteği** ve otomatik en yüksek yetki seçimi
- **Modern UI/UX tasarım** ve tutarlı kullanıcı deneyimi