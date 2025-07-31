using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Seker_kutuphane
{
    public partial class SifreDegistirForm : Form
    {
        private int kullaniciId;
        private ApiHelper apiHelper;

        public SifreDegistirForm(int kullaniciId)
        {
            InitializeComponent();
            this.kullaniciId = kullaniciId;
            this.apiHelper = new ApiHelper();
        }

        private void InitializeComponent()
        {
            this.panelMain = new Panel();
            this.lblBaslik = new Label();
            this.lblMevcutSifre = new Label();
            this.txtMevcutSifre = new TextBox();
            this.lblYeniSifre = new Label();
            this.txtYeniSifre = new TextBox();
            this.lblYeniSifreTekrar = new Label();
            this.txtYeniSifreTekrar = new TextBox();
            this.btnGuncelle = new Button();
            this.btnIptal = new Button();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();

            // panelMain
            this.panelMain.BackColor = Color.FromArgb(245, 245, 245);
            this.panelMain.Controls.Add(this.lblBaslik);
            this.panelMain.Controls.Add(this.lblMevcutSifre);
            this.panelMain.Controls.Add(this.txtMevcutSifre);
            this.panelMain.Controls.Add(this.lblYeniSifre);
            this.panelMain.Controls.Add(this.txtYeniSifre);
            this.panelMain.Controls.Add(this.lblYeniSifreTekrar);
            this.panelMain.Controls.Add(this.txtYeniSifreTekrar);
            this.panelMain.Controls.Add(this.btnGuncelle);
            this.panelMain.Controls.Add(this.btnIptal);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new Size(450, 300);
            this.panelMain.TabIndex = 0;

            // lblBaslik
            this.lblBaslik.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblBaslik.ForeColor = Color.FromArgb(0, 128, 0);
            this.lblBaslik.Location = new Point(20, 20);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(410, 40);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Şifre Değiştir";
            this.lblBaslik.TextAlign = ContentAlignment.MiddleCenter;

            // lblMevcutSifre
            this.lblMevcutSifre.AutoSize = true;
            this.lblMevcutSifre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblMevcutSifre.ForeColor = Color.FromArgb(0, 128, 0);
            this.lblMevcutSifre.Location = new Point(50, 80);
            this.lblMevcutSifre.Name = "lblMevcutSifre";
            this.lblMevcutSifre.Size = new Size(100, 19);
            this.lblMevcutSifre.TabIndex = 1;
            this.lblMevcutSifre.Text = "Mevcut Şifre:";

            // txtMevcutSifre
            this.txtMevcutSifre.Font = new Font("Segoe UI", 10F);
            this.txtMevcutSifre.Location = new Point(200, 77);
            this.txtMevcutSifre.Name = "txtMevcutSifre";
            this.txtMevcutSifre.PasswordChar = '●';
            this.txtMevcutSifre.Size = new Size(200, 25);
            this.txtMevcutSifre.TabIndex = 2;

            // lblYeniSifre
            this.lblYeniSifre.AutoSize = true;
            this.lblYeniSifre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblYeniSifre.ForeColor = Color.FromArgb(0, 128, 0);
            this.lblYeniSifre.Location = new Point(50, 120);
            this.lblYeniSifre.Name = "lblYeniSifre";
            this.lblYeniSifre.Size = new Size(80, 19);
            this.lblYeniSifre.TabIndex = 3;
            this.lblYeniSifre.Text = "Yeni Şifre:";

            // txtYeniSifre
            this.txtYeniSifre.Font = new Font("Segoe UI", 10F);
            this.txtYeniSifre.Location = new Point(200, 117);
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.PasswordChar = '●';
            this.txtYeniSifre.Size = new Size(200, 25);
            this.txtYeniSifre.TabIndex = 4;

            // lblYeniSifreTekrar
            this.lblYeniSifreTekrar.AutoSize = true;
            this.lblYeniSifreTekrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblYeniSifreTekrar.ForeColor = Color.FromArgb(0, 128, 0);
            this.lblYeniSifreTekrar.Location = new Point(50, 160);
            this.lblYeniSifreTekrar.Name = "lblYeniSifreTekrar";
            this.lblYeniSifreTekrar.Size = new Size(140, 19);
            this.lblYeniSifreTekrar.TabIndex = 5;
            this.lblYeniSifreTekrar.Text = "Yeni Şifre (Tekrar):";

            // txtYeniSifreTekrar
            this.txtYeniSifreTekrar.Font = new Font("Segoe UI", 10F);
            this.txtYeniSifreTekrar.Location = new Point(200, 157);
            this.txtYeniSifreTekrar.Name = "txtYeniSifreTekrar";
            this.txtYeniSifreTekrar.PasswordChar = '●';
            this.txtYeniSifreTekrar.Size = new Size(200, 25);
            this.txtYeniSifreTekrar.TabIndex = 6;

            // btnGuncelle
            this.btnGuncelle.BackColor = Color.FromArgb(76, 175, 80);
            this.btnGuncelle.FlatAppearance.BorderSize = 0;
            this.btnGuncelle.FlatStyle = FlatStyle.Flat;
            this.btnGuncelle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnGuncelle.ForeColor = Color.White;
            this.btnGuncelle.Location = new Point(200, 200);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new Size(120, 40);
            this.btnGuncelle.TabIndex = 7;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += btnGuncelle_Click;

            // btnIptal
            this.btnIptal.BackColor = Color.FromArgb(158, 158, 158);
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = FlatStyle.Flat;
            this.btnIptal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnIptal.ForeColor = Color.White;
            this.btnIptal.Location = new Point(340, 200);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new Size(120, 40);
            this.btnIptal.TabIndex = 8;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += btnIptal_Click;

            // SifreDegistirForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(450, 300);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SifreDegistirForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Şifre Değiştir";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
        }

        private Panel panelMain;
        private Label lblBaslik;
        private Label lblMevcutSifre;
        private TextBox txtMevcutSifre;
        private Label lblYeniSifre;
        private TextBox txtYeniSifre;
        private Label lblYeniSifreTekrar;
        private TextBox txtYeniSifreTekrar;
        private Button btnGuncelle;
        private Button btnIptal;

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            // Validasyon
            if (string.IsNullOrEmpty(txtMevcutSifre.Text.Trim()))
            {
                MessageBox.Show("Lütfen mevcut şifrenizi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMevcutSifre.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtYeniSifre.Text.Trim()))
            {
                MessageBox.Show("Lütfen yeni şifrenizi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYeniSifre.Focus();
                return;
            }

            if (txtYeniSifre.Text.Trim().Length < 6)
            {
                MessageBox.Show("Yeni şifre en az 6 karakter olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYeniSifre.Focus();
                return;
            }

            if (txtYeniSifre.Text.Trim() != txtYeniSifreTekrar.Text.Trim())
            {
                MessageBox.Show("Yeni şifreler eşleşmiyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYeniSifreTekrar.Focus();
                return;
            }

            try
            {
                btnGuncelle.Enabled = false;
                btnGuncelle.Text = "Güncelleniyor...";

                // Hem mevcut şifreyi hem de yeni şifreyi hash'le (API hashleme yapmıyor)
                string hashedMevcutSifre = Sha256Hash(txtMevcutSifre.Text.Trim());
                string hashedYeniSifre = Sha256Hash(txtYeniSifre.Text.Trim());
                var result = await apiHelper.UpdatePasswordAsync(kullaniciId, hashedMevcutSifre, hashedYeniSifre);
                
                MessageBox.Show("Şifreniz başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şifre güncelleme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuncelle.Enabled = true;
                btnGuncelle.Text = "Güncelle";
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string Sha256Hash(string value)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
} 