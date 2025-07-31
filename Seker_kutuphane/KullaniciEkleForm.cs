using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks; // Added missing import for Task
using System.Linq; // Added for LINQ methods

namespace Seker_kutuphane
{
    public partial class KullaniciEkleForm : Form
    {
        private ApiHelper apiHelper;

        public KullaniciEkleForm()
        {
            InitializeComponent();
            this.apiHelper = new ApiHelper();
            SetupInputRestrictions();
        }

        private void InitializeComponent()
        {
            this.panelMain = new Panel();
            this.lblBaslik = new Label();
            this.lblAd = new Label();
            this.txtAd = new TextBox();
            this.lblSoyad = new Label();
            this.txtSoyad = new TextBox();
            this.lblTC = new Label();
            this.txtTC = new TextBox();
            this.lblTelefon = new Label();
            this.txtTelefon = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblSifre = new Label();
            this.txtSifre = new TextBox();
            this.lblSifreTekrar = new Label();
            this.txtSifreTekrar = new TextBox();
            this.lblRol = new Label();
            this.clbRoller = new CheckedListBox();
            this.btnEkle = new Button();
            this.btnIptal = new Button();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();

            // panelMain
            this.panelMain.BackColor = Color.FromArgb(245, 245, 245);
            this.panelMain.Controls.Add(this.lblBaslik);
            this.panelMain.Controls.Add(this.lblAd);
            this.panelMain.Controls.Add(this.txtAd);
            this.panelMain.Controls.Add(this.lblSoyad);
            this.panelMain.Controls.Add(this.txtSoyad);
            this.panelMain.Controls.Add(this.lblTC);
            this.panelMain.Controls.Add(this.txtTC);
            this.panelMain.Controls.Add(this.lblTelefon);
            this.panelMain.Controls.Add(this.txtTelefon);
            this.panelMain.Controls.Add(this.lblEmail);
            this.panelMain.Controls.Add(this.txtEmail);
            this.panelMain.Controls.Add(this.lblSifre);
            this.panelMain.Controls.Add(this.txtSifre);
            this.panelMain.Controls.Add(this.lblSifreTekrar);
            this.panelMain.Controls.Add(this.txtSifreTekrar);
            this.panelMain.Controls.Add(this.lblRol);
            this.panelMain.Controls.Add(this.clbRoller);
            this.panelMain.Controls.Add(this.btnEkle);
            this.panelMain.Controls.Add(this.btnIptal);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new Size(500, 550);
            this.panelMain.TabIndex = 0;

            // lblBaslik
            this.lblBaslik.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblBaslik.ForeColor = Color.FromArgb(0, 128, 0);
            this.lblBaslik.Location = new Point(20, 20);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(460, 40);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Yeni Kullanıcı Ekle";
            this.lblBaslik.TextAlign = ContentAlignment.MiddleCenter;

            // lblAd
            this.lblAd.AutoSize = true;
            this.lblAd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblAd.ForeColor = Color.FromArgb(0, 128, 0);
            this.lblAd.Location = new Point(50, 80);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new Size(32, 19);
            this.lblAd.TabIndex = 1;
            this.lblAd.Text = "Ad:";

            // txtAd
            this.txtAd.Font = new Font("Segoe UI", 10F);
            this.txtAd.Location = new Point(150, 77);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new Size(300, 25);
            this.txtAd.TabIndex = 2;

            // lblSoyad
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblSoyad.ForeColor = Color.FromArgb(0, 128, 0);
            this.lblSoyad.Location = new Point(50, 120);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new Size(55, 19);
            this.lblSoyad.TabIndex = 3;
            this.lblSoyad.Text = "Soyad:";

            // txtSoyad
            this.txtSoyad.Font = new Font("Segoe UI", 10F);
            this.txtSoyad.Location = new Point(150, 117);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new Size(300, 25);
            this.txtSoyad.TabIndex = 4;

            // lblTC
            this.lblTC.AutoSize = true;
            this.lblTC.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTC.ForeColor = Color.FromArgb(0, 128, 0);
            this.lblTC.Location = new Point(50, 160);
            this.lblTC.Name = "lblTC";
            this.lblTC.Size = new Size(100, 19);
            this.lblTC.TabIndex = 5;
            this.lblTC.Text = "TC Kimlik No:";

            // txtTC
            this.txtTC.Font = new Font("Segoe UI", 10F);
            this.txtTC.Location = new Point(150, 157);
            this.txtTC.Name = "txtTC";
            this.txtTC.Size = new Size(300, 25);
            this.txtTC.TabIndex = 6;

            // lblTelefon
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTelefon.ForeColor = Color.FromArgb(0, 128, 0);
            this.lblTelefon.Location = new Point(50, 200);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new Size(62, 19);
            this.lblTelefon.TabIndex = 7;
            this.lblTelefon.Text = "Telefon:";

            // txtTelefon
            this.txtTelefon.Font = new Font("Segoe UI", 10F);
            this.txtTelefon.Location = new Point(150, 197);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new Size(300, 25);
            this.txtTelefon.TabIndex = 8;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblEmail.ForeColor = Color.FromArgb(0, 128, 0);
            this.lblEmail.Location = new Point(50, 240);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(55, 19);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "E-mail:";

            // txtEmail
            this.txtEmail.Font = new Font("Segoe UI", 10F);
            this.txtEmail.Location = new Point(150, 237);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(300, 25);
            this.txtEmail.TabIndex = 10;

            // lblSifre
            this.lblSifre.AutoSize = true;
            this.lblSifre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblSifre.ForeColor = Color.FromArgb(0, 128, 0);
            this.lblSifre.Location = new Point(50, 280);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new Size(45, 19);
            this.lblSifre.TabIndex = 11;
            this.lblSifre.Text = "Şifre:";

            // txtSifre
            this.txtSifre.Font = new Font("Segoe UI", 10F);
            this.txtSifre.Location = new Point(150, 277);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '●';
            this.txtSifre.Size = new Size(300, 25);
            this.txtSifre.TabIndex = 12;

            // lblSifreTekrar
            this.lblSifreTekrar.AutoSize = true;
            this.lblSifreTekrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblSifreTekrar.ForeColor = Color.FromArgb(0, 128, 0);
            this.lblSifreTekrar.Location = new Point(50, 320);
            this.lblSifreTekrar.Name = "lblSifreTekrar";
            this.lblSifreTekrar.Size = new Size(100, 19);
            this.lblSifreTekrar.TabIndex = 13;
            this.lblSifreTekrar.Text = "Şifre (Tekrar):";

            // txtSifreTekrar
            this.txtSifreTekrar.Font = new Font("Segoe UI", 10F);
            this.txtSifreTekrar.Location = new Point(150, 317);
            this.txtSifreTekrar.Name = "txtSifreTekrar";
            this.txtSifreTekrar.PasswordChar = '●';
            this.txtSifreTekrar.Size = new Size(300, 25);
            this.txtSifreTekrar.TabIndex = 14;

            // lblRol
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblRol.ForeColor = Color.FromArgb(0, 128, 0);
            this.lblRol.Location = new Point(50, 360);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new Size(35, 19);
            this.lblRol.TabIndex = 15;
            this.lblRol.Text = "Rol:";

            // clbRoller
            this.clbRoller.Font = new Font("Segoe UI", 10F);
            this.clbRoller.Location = new Point(150, 357);
            this.clbRoller.Name = "clbRoller";
            this.clbRoller.Size = new Size(300, 80);
            this.clbRoller.TabIndex = 16;
            this.clbRoller.CheckOnClick = true;

            // btnEkle
            this.btnEkle.BackColor = Color.FromArgb(76, 175, 80);
            this.btnEkle.FlatAppearance.BorderSize = 0;
            this.btnEkle.FlatStyle = FlatStyle.Flat;
            this.btnEkle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnEkle.ForeColor = Color.White;
            this.btnEkle.Location = new Point(150, 450);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new Size(120, 40);
            this.btnEkle.TabIndex = 17;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += btnEkle_Click;

            // btnIptal
            this.btnIptal.BackColor = Color.FromArgb(158, 158, 158);
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = FlatStyle.Flat;
            this.btnIptal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnIptal.ForeColor = Color.White;
            this.btnIptal.Location = new Point(290, 450);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new Size(120, 40);
            this.btnIptal.TabIndex = 18;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += btnIptal_Click;

            // KullaniciEkleForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 500);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KullaniciEkleForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Yeni Kullanıcı Ekle";
            this.Load += KullaniciEkleForm_Load;
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
        }

        private Panel panelMain;
        private Label lblBaslik;
        private Label lblAd;
        private TextBox txtAd;
        private Label lblSoyad;
        private TextBox txtSoyad;
        private Label lblTC;
        private TextBox txtTC;
        private Label lblTelefon;
        private TextBox txtTelefon;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblSifre;
        private TextBox txtSifre;
        private Label lblSifreTekrar;
        private TextBox txtSifreTekrar;
        private Label lblRol;
        private CheckedListBox clbRoller;
        private Button btnEkle;
        private Button btnIptal;

        private void SetupInputRestrictions()
        {
            // TC kimlik numarası için kısıtlamalar
            txtTC.MaxLength = 11;
            txtTC.KeyPress += TxtTC_KeyPress;
            txtTC.TextChanged += TxtTC_TextChanged;

            // Telefon numarası için kısıtlamalar
            txtTelefon.MaxLength = 11;
            txtTelefon.KeyPress += TxtTelefon_KeyPress;
            txtTelefon.TextChanged += TxtTelefon_TextChanged;
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

        private async void KullaniciEkleForm_Load(object sender, EventArgs e)
        {
            await LoadRoller();
        }

        private async Task LoadRoller()
        {
            try
            {
                var response = await apiHelper.GetRolesAsync();
                
                if (response is Newtonsoft.Json.Linq.JArray rollerArray)
                {
                    clbRoller.Items.Clear();
                    
                    foreach (var rol in rollerArray)
                    {
                        string rolAdi = rol["rol_adi"]?.ToString() ?? "";
                        if (!string.IsNullOrEmpty(rolAdi))
                        {
                            clbRoller.Items.Add(rolAdi, false); // Hiçbiri seçili değil
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Roller yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEkle_Click(object sender, EventArgs e)
        {
            // Validasyon
            if (string.IsNullOrEmpty(txtAd.Text.Trim()) ||
                string.IsNullOrEmpty(txtSoyad.Text.Trim()) ||
                string.IsNullOrEmpty(txtTC.Text.Trim()) ||
                string.IsNullOrEmpty(txtTelefon.Text.Trim()) ||
                string.IsNullOrEmpty(txtEmail.Text.Trim()) ||
                string.IsNullOrEmpty(txtSifre.Text.Trim()) ||
                string.IsNullOrEmpty(txtSifreTekrar.Text.Trim()) ||
                clbRoller.CheckedItems.Count == 0)
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

            if (txtSifre.Text.Length < 6)
            {
                MessageBox.Show("Şifre en az 6 karakter olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtSifre.Text != txtSifreTekrar.Text)
            {
                MessageBox.Show("Şifreler eşleşmiyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnEkle.Enabled = false;
                btnEkle.Text = "Ekleniyor...";

                // Şifreyi hash'le
                string hashedSifre = Sha256Hash(txtSifre.Text.Trim());

                // Seçilen rollerin ID'lerini bul
                var selectedRoleIds = new List<int>();
                var selectedRoleNames = new List<string>();
                
                for (int i = 0; i < clbRoller.Items.Count; i++)
                {
                    if (clbRoller.GetItemChecked(i))
                    {
                        string rolAdi = clbRoller.Items[i].ToString();
                        int rolId = await GetRolId(rolAdi);
                        selectedRoleIds.Add(rolId);
                        selectedRoleNames.Add(rolAdi);
                    }
                }

                // Kullanıcı verilerini hazırla
                var userData = new
                {
                    ad = txtAd.Text.Trim(),
                    soyad = txtSoyad.Text.Trim(),
                    tc = txtTC.Text.Trim(),
                    telefon = txtTelefon.Text.Trim(),
                    email = txtEmail.Text.Trim(),
                    sifre = hashedSifre
                    // API rol parametrelerini görmezden geliyor, bu yüzden kaldırdık
                };

                var response = await apiHelper.RegisterAsync(userData);
                
                // Kullanıcı başarıyla oluşturulduysa, seçilen roller de ekle
                if (response != null && response.user != null)
                {
                    int yeniKullaniciId = Convert.ToInt32(response.user.kullanici_id);
                    int addedRolesCount = 0;
                    
                    // Seçilen her rol için ekleme yap
                    foreach (int rolId in selectedRoleIds)
                    {
                        // Seçilen rol "Üye" değilse ekle (çünkü API zaten "Üye" rolünü atıyor)
                        if (rolId != 1) // 1 = Üye rolü
                        {
                            try
                            {
                                await apiHelper.AddRoleToUserAsync(yeniKullaniciId, rolId);
                                addedRolesCount++;
                            }
                            catch (Exception roleEx)
                            {
                                MessageBox.Show($"'{selectedRoleNames[selectedRoleIds.IndexOf(rolId)]}' rolü eklenirken hata oluştu: {roleEx.Message}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    
                    if (addedRolesCount > 0)
                    {
                        string rolesText = string.Join(", ", selectedRoleNames.Where(name => name != "Üye"));
                        MessageBox.Show($"Kullanıcı başarıyla oluşturuldu ve şu roller eklendi: {rolesText}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı başarıyla oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcı eklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEkle.Enabled = true;
                btnEkle.Text = "Ekle";
            }
        }

        private async Task<int> GetRolId(string rolAdi)
        {
            try
            {
                var response = await apiHelper.GetRolesAsync();
                
                if (response is Newtonsoft.Json.Linq.JArray rollerArray)
                {
                    foreach (var rol in rollerArray)
                    {
                        if (rol["rol_adi"]?.ToString() == rolAdi)
                        {
                            return Convert.ToInt32(rol["rol_id"]);
                        }
                    }
                }
                
                // Varsayılan olarak "Üye" rolü ID'si (genellikle 1)
                return 1;
            }
            catch
            {
                return 1; // Varsayılan
            }
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

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
} 