using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Seker_kutuphane
{
    public partial class KullaniciGuncelleForm : Form
    {
        private int kullaniciId;
        private DataGridViewRow selectedRow;
        private ApiHelper apiHelper;
        private bool isAdmin; // Admin kontrolü için

        public KullaniciGuncelleForm(int kullaniciId, DataGridViewRow selectedRow, bool isAdmin = false)
        {
            InitializeComponent();
            this.kullaniciId = kullaniciId;
            this.selectedRow = selectedRow;
            this.apiHelper = new ApiHelper();
            this.isAdmin = isAdmin;
            LoadKullaniciData();
            SetupEnterKeyEvents();
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
            this.lblRol = new Label();
            this.clbRoller = new CheckedListBox();
            this.btnGuncelle = new Button();
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
            this.panelMain.Controls.Add(this.lblRol);
            this.panelMain.Controls.Add(this.clbRoller);
            this.panelMain.Controls.Add(this.btnGuncelle);
            this.panelMain.Controls.Add(this.btnIptal);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new Size(500, 450);
            this.panelMain.TabIndex = 0;

            // lblBaslik
            this.lblBaslik.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblBaslik.ForeColor = Color.FromArgb(0, 128, 0);
            this.lblBaslik.Location = new Point(20, 20);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(460, 40);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Kullanıcı Güncelle";
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

            // lblRol
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblRol.ForeColor = Color.FromArgb(0, 128, 0);
            this.lblRol.Location = new Point(50, 280);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new Size(65, 19);
            this.lblRol.TabIndex = 11;
            this.lblRol.Text = "Roller:";

            // clbRoller
            this.clbRoller.Font = new Font("Segoe UI", 10F);
            this.clbRoller.Location = new Point(150, 277);
            this.clbRoller.Name = "clbRoller";
            this.clbRoller.Size = new Size(300, 80);
            this.clbRoller.TabIndex = 12;
            this.clbRoller.CheckOnClick = true;
            this.clbRoller.Enabled = isAdmin; // Sadece Admin rol değiştirebilir

            // btnGuncelle
            this.btnGuncelle.BackColor = Color.FromArgb(76, 175, 80);
            this.btnGuncelle.FlatAppearance.BorderSize = 0;
            this.btnGuncelle.FlatStyle = FlatStyle.Flat;
            this.btnGuncelle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnGuncelle.ForeColor = Color.White;
            this.btnGuncelle.Location = new Point(150, 370);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new Size(120, 40);
            this.btnGuncelle.TabIndex = 13;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += btnGuncelle_Click;

            // btnIptal
            this.btnIptal.BackColor = Color.FromArgb(158, 158, 158);
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = FlatStyle.Flat;
            this.btnIptal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnIptal.ForeColor = Color.White;
            this.btnIptal.Location = new Point(290, 370);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new Size(120, 40);
            this.btnIptal.TabIndex = 14;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += btnIptal_Click;

            // KullaniciGuncelleForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 450);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KullaniciGuncelleForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Kullanıcı Güncelle";
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
        private Label lblRol;
        private CheckedListBox clbRoller;
        private Button btnGuncelle;
        private Button btnIptal;

        private async void LoadKullaniciData()
        {
            // Seçilen satırdan kullanıcı verilerini yükle
            txtAd.Text = selectedRow.Cells["ad"].Value?.ToString() ?? "";
            txtSoyad.Text = selectedRow.Cells["soyad"].Value?.ToString() ?? "";
            txtTC.Text = selectedRow.Cells["tc"].Value?.ToString() ?? "";
            txtTelefon.Text = selectedRow.Cells["telefon"].Value?.ToString() ?? "";
            txtEmail.Text = selectedRow.Cells["email"].Value?.ToString() ?? "";

            // Form başlığını güncelle
            this.Text = $"Kullanıcı Güncelle - {txtAd.Text} {txtSoyad.Text}";

            // CheckedListBox'ı Admin durumuna göre aktif/pasif yap
            clbRoller.Enabled = isAdmin;

            // Roller yükle
            await LoadRoller();
        }

        private async Task LoadRoller()
        {
            try
            {
                // Tüm roller yükle
                var response = await apiHelper.GetRolesAsync();
                if (response is Newtonsoft.Json.Linq.JArray rollerArray)
                {
                    clbRoller.Items.Clear();
                    
                    foreach (var rol in rollerArray)
                    {
                        string rolAdi = rol["rol_adi"]?.ToString() ?? "";
                        if (!string.IsNullOrEmpty(rolAdi))
                        {
                            clbRoller.Items.Add(rolAdi, false);
                        }
                    }

                    // Kullanıcının mevcut rollerini işaretle
                    string currentRoles = selectedRow.Cells["rol_adlari"].Value?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(currentRoles))
                    {
                        string[] roles = currentRoles.Split(',');
                        foreach (string role in roles)
                        {
                            string trimmedRole = role.Trim();
                            for (int i = 0; i < clbRoller.Items.Count; i++)
                            {
                                if (clbRoller.Items[i].ToString() == trimmedRole)
                                {
                                    clbRoller.SetItemChecked(i, true);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Roller yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuncelle_Click(object sender, EventArgs e)
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

            try
            {
                btnGuncelle.Enabled = false;
                btnGuncelle.Text = "Güncelleniyor...";

                // Güncelleme verilerini hazırla
                var updateData = new
                {
                    kullanici_id = kullaniciId,
                    ad = txtAd.Text.Trim(),
                    soyad = txtSoyad.Text.Trim(),
                    tc = txtTC.Text.Trim(),
                    telefon = txtTelefon.Text.Trim(),
                    email = txtEmail.Text.Trim()
                };

                var response = await apiHelper.UpdateUserProfileAsync(updateData);

                // Eğer Admin ise ve roller değiştirildiyse, rolleri güncelle
                if (isAdmin)
                {
                    await UpdateUserRoles();
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcı güncellenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuncelle.Enabled = true;
                btnGuncelle.Text = "Güncelle";
            }
        }

        private async Task UpdateUserRoles()
        {
            try
            {
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

                // Kullanıcının mevcut rollerini al
                var allUsers = await apiHelper.GetAllUsersAsync();
                dynamic currentUser = null;
                
                if (allUsers is Newtonsoft.Json.Linq.JArray usersArray)
                {
                    foreach (var user in usersArray)
                    {
                        if (Convert.ToInt32(user["kullanici_id"]) == kullaniciId)
                        {
                            currentUser = user;
                            break;
                        }
                    }
                }

                if (currentUser != null)
                {
                    // Güncelleme verisi hazırla
                    var updateData = new
                    {
                        kullanici_id = kullaniciId,
                        ad = currentUser["ad"],
                        soyad = currentUser["soyad"],
                        tc = currentUser["tc"],
                        telefon = currentUser["telefon"],
                        email = currentUser["email"],
                        rol_ids = selectedRoleIds.ToArray()
                    };

                    await apiHelper.UpdateUserProfileAsync(updateData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Roller güncellenirken hata oluştu: {ex.Message}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                
                return 1; // Varsayılan
            }
            catch
            {
                return 1; // Varsayılan
            }
        }

        private void SetupEnterKeyEvents()
        {
            // Tüm textbox'lara Enter tuşu desteği ekle
            txtAd.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Enter) btnGuncelle.PerformClick(); };
            txtSoyad.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Enter) btnGuncelle.PerformClick(); };
            txtTC.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Enter) btnGuncelle.PerformClick(); };
            txtTelefon.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Enter) btnGuncelle.PerformClick(); };
            txtEmail.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Enter) btnGuncelle.PerformClick(); };
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
} 