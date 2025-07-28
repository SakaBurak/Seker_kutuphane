# Şeker Kütüphane Sistemi

## Proje Hakkında
Bu proje, kütüphane yönetim sistemi için Windows Forms uygulamasıdır. Kullanıcı kayıt, giriş ve şifre yenileme işlemlerini destekler.

## Özellikler
- ✅ Kullanıcı Girişi (TC Kimlik No ile)
- ✅ Kullanıcı Kayıt
- ✅ Şifre Yenileme
- ✅ Dashboard (Rol bazlı erişim)

## API Bağlantısı
- **API URL**: `http://10.100.74.48:5000`
- **Authentication**: Basic Auth (sbuhs:sekerstajekip)

## Kayıt İşlemi Sorunu ve Çözümü

### Sorun
Kayıt olma işleminde "Bad Request" hatası alınıyordu.

### Yapılan Düzeltmeler

1. **Debug Bilgileri Eklendi**: 
   - Gönderilen JSON verisi gösteriliyor
   - API yanıtı detaylı olarak loglanıyor

2. **Veri Doğrulama Geliştirildi**:
   - Email format kontrolü
   - Telefon numarası uzunluk kontrolü
   - TC kimlik numarası format kontrolü

3. **Hata Yakalama İyileştirildi**:
   - HTTP hataları detaylı olarak yakalanıyor
   - Kullanıcıya anlamlı hata mesajları gösteriliyor

4. **API Endpoint Test Metodu Eklendi**:
   - Farklı endpoint'lerin test edilmesi için metod eklendi

### Kullanım

1. **Kayıt Olma**:
   - Tüm alanları doldurun
   - Geçerli email adresi girin
   - 11 haneli TC kimlik numarası girin
   - Şifrelerin eşleştiğinden emin olun

2. **Giriş Yapma**:
   - TC kimlik numarası ile giriş yapın
   - Şifrenizi girin

3. **Şifre Yenileme**:
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