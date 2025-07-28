using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Seker_kutuphane
{
    public partial class ProfilForm : Form
    {
        private string kullaniciAdi;
        private string rol;
        private dynamic userData;

        public ProfilForm(string kullaniciAdi, string rol, dynamic userData)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
            this.rol = rol;
            this.userData = userData;
            LoadUserData();
            SetupTCRestrictions();
            SetupTelefonRestrictions();
        }

        private void LoadUserData()
        {
            // Kullanıcı bilgilerini form alanlarına yükle
            txtAd.Text = userData.ad?.ToString() ?? "";
            txtSoyad.Text = userData.soyad?.ToString() ?? "";
            txtTC.Text = userData.tc?.ToString() ?? "";
            txtTelefon.Text = userData.telefon?.ToString() ?? "";
            txtEmail.Text = userData.email?.ToString() ?? "";
            lblRol.Text = $"Rol: {rol}";
        }

        private void SetupTCRestrictions()
        {
            // TC kimlik numarası için kısıtlamalar
            txtTC.MaxLength = 11;
            txtTC.KeyPress += TxtTC_KeyPress;
            txtTC.TextChanged += TxtTC_TextChanged;
        }

        private void TxtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtTC_TextChanged(object sender, EventArgs e)
        {
            if (txtTC.Text.Contains(" "))
            {
                txtTC.Text = txtTC.Text.Replace(" ", "");
                txtTC.SelectionStart = txtTC.Text.Length;
            }
        }

        private void SetupTelefonRestrictions()
        {
            // Telefon numarası için kısıtlamalar
            txtTelefon.MaxLength = 11;
            txtTelefon.KeyPress += TxtTelefon_KeyPress;
            txtTelefon.TextChanged += TxtTelefon_TextChanged;
        }

        private void TxtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtTelefon_TextChanged(object sender, EventArgs e)
        {
            if (txtTelefon.Text.Contains(" "))
            {
                txtTelefon.Text = txtTelefon.Text.Replace(" ", "");
                txtTelefon.SelectionStart = txtTelefon.Text.Length;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // Validasyon
            if (string.IsNullOrEmpty(txtAd.Text.Trim()) || 
                string.IsNullOrEmpty(txtSoyad.Text.Trim()) ||
                string.IsNullOrEmpty(txtTC.Text.Trim()) ||
                string.IsNullOrEmpty(txtTelefon.Text.Trim()) ||
                string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtTC.Text.Length != 11)
            {
                MessageBox.Show("TC Kimlik Numarası 11 haneli olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtTelefon.Text.Length < 10)
            {
                MessageBox.Show("Telefon numarası en az 10 haneli olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Geçerli bir e-posta adresi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Güncelleme işlemi
            try
            {
                // Burada API çağrısı yapılacak
                MessageBox.Show("Profil bilgileriniz güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme başarısız: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            // Şifre değiştirme formu açılabilir
            MessageBox.Show("Şifre değiştirme özelliği yakında eklenecek.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
} 