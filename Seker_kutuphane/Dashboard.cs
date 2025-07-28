using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seker_kutuphane
{
    public partial class Form2 : Form
    {
        private string kullaniciAdi;
        private string rol;
        
        public Form2(string kullaniciAdi, string rol)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
            this.rol = rol;
            SetupRoleBasedAccess();
        }

        private void SetupRoleBasedAccess()
        {
            // Kullanıcı bilgisi göster
            lblKullanici.Text = $"Kullanıcı: {kullaniciAdi}  |  Rol: {rol}";
            
            // Tüm butonları varsayılan olarak gizle
            btnUyeler.Visible = false;
            btnEmanetler.Visible = false;
            btnRaporlar.Visible = false;
            btnYonetim.Visible = false;
            
            // Rol bazlı yetki ayarları
            switch (rol.ToLower())
            {
                case "üye":
                case "uye":
                case "kullanici":
                case "user":
                case "member":
                    SetupUyePermissions();
                    break;
                    
                case "kütüphane görevlisi":
                case "kutuphane gorevlisi":
                case "kütüphane yetkilisi":
                case "kutuphane yetkilisi":
                case "görevli":
                case "gorevli":
                case "yetkili":
                case "librarian":
                case "staff":
                    SetupGorevliPermissions();
                    break;
                    
                case "admin":
                case "yönetici":
                case "yonetici":
                case "administrator":
                    SetupAdminPermissions();
                    break;
                    
                default:
                    // Bilinmeyen rol için sadece temel yetkiler
                    SetupUyePermissions();
                    break;
            }
        }

        private void SetupUyePermissions()
        {
            // Üye yetkileri: Sadece kitap arama ve profil güncelleme
            btnKitaplar.Visible = true;
            btnKitaplar.Text = "Kitap Ara";
            
            // Üye için özel butonlar
            btnUyeler.Visible = true;
            btnUyeler.Text = "Profilim";
            
            // Diğer butonlar gizli
            btnEmanetler.Visible = false;
            btnRaporlar.Visible = false;
            btnYonetim.Visible = false;
        }

        private void SetupGorevliPermissions()
        {
            // Kütüphane görevlisi yetkileri: Kitap arama + üye yönetimi + emanet işlemleri
            btnKitaplar.Visible = true;
            btnKitaplar.Text = "Kitap Yönetimi";
            
            btnUyeler.Visible = true;
            btnUyeler.Text = "Üye Yönetimi";
            
            btnEmanetler.Visible = true;
            btnEmanetler.Text = "Emanet İşlemleri";
            
            // Raporlar ve yönetim gizli (sadece admin)
            btnRaporlar.Visible = false;
            btnYonetim.Visible = false;
        }

        private void SetupAdminPermissions()
        {
            // Admin yetkileri: Tüm yetkiler
            btnKitaplar.Visible = true;
            btnKitaplar.Text = "Kitap Yönetimi";
            
            btnUyeler.Visible = true;
            btnUyeler.Text = "Üye Yönetimi";
            
            btnEmanetler.Visible = true;
            btnEmanetler.Text = "Emanet İşlemleri";
            
            btnRaporlar.Visible = true;
            btnRaporlar.Text = "Raporlar";
            
            btnYonetim.Visible = true;
            btnYonetim.Text = "Sistem Yönetimi";
        }

        private async void Form2_Load(object? sender, EventArgs e)
        {
            // Form yüklendiğinde rol bilgisini logla
            Console.WriteLine($"Dashboard yüklendi - Kullanıcı: {kullaniciAdi}, Rol: {rol}");
        }

        private void btnKitaplar_Click(object sender, EventArgs e)
        {
            // Rol bazlı kitap işlemleri
            switch (rol.ToLower())
            {
                case "üye":
                case "uye":
                case "kullanici":
                    MessageBox.Show("Kitap arama sayfası açılıyor...", "Kitap Ara");
                    // KitapAramaForm.Show();
                    break;
                    
                case "kütüphane görevlisi":
                case "kutuphane gorevlisi":
                case "görevli":
                case "gorevli":
                    MessageBox.Show("Kitap yönetimi sayfası açılıyor...", "Kitap Yönetimi");
                    // KitapYonetimForm.Show();
                    break;
                    
                case "admin":
                case "yönetici":
                case "yonetici":
                    MessageBox.Show("Tam kitap yönetimi sayfası açılıyor...", "Kitap Yönetimi (Admin)");
                    // KitapAdminForm.Show();
                    break;
            }
        }

        private void btnUyeler_Click(object sender, EventArgs e)
        {
            // Rol bazlı üye işlemleri
            switch (rol.ToLower())
            {
                case "üye":
                case "uye":
                case "kullanici":
                    MessageBox.Show("Profil güncelleme sayfası açılıyor...", "Profilim");
                    // ProfilGuncellemeForm.Show();
                    break;
                    
                case "kütüphane görevlisi":
                case "kutuphane gorevlisi":
                case "görevli":
                case "gorevli":
                    MessageBox.Show("Üye yönetimi sayfası açılıyor...", "Üye Yönetimi");
                    // UyeYonetimForm.Show();
                    break;
                    
                case "admin":
                case "yönetici":
                case "yonetici":
                    MessageBox.Show("Tam üye yönetimi sayfası açılıyor...", "Üye Yönetimi (Admin)");
                    // UyeAdminForm.Show();
                    break;
            }
        }

        private void btnEmanetler_Click(object sender, EventArgs e)
        {
            // Emanet işlemleri (sadece görevli ve admin)
            MessageBox.Show("Emanet işlemleri sayfası açılıyor...", "Emanet İşlemleri");
            // EmanetIslemleriForm.Show();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            // Raporlar (sadece admin)
            MessageBox.Show("Raporlar sayfası açılıyor...", "Raporlar");
            // RaporlarForm.Show();
        }

        private void btnYonetim_Click(object sender, EventArgs e)
        {
            // Sistem yönetimi (sadece admin)
            MessageBox.Show("Sistem yönetimi sayfası açılıyor...", "Sistem Yönetimi");
            // SistemYonetimForm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            // Çıkış işlemi
            Application.Exit();
        }
    }
}
