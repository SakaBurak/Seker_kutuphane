using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Seker_kutuphane
{
    public partial class UyelikIslemleriForm : Form
    {
        private ApiHelper apiHelper;
        private DataTable kullanicilarTable;
        private bool isAdmin; // Admin kontrolü için

        public UyelikIslemleriForm(bool isAdmin = false)
        {
            InitializeComponent();
            this.apiHelper = new ApiHelper();
            this.kullanicilarTable = new DataTable();
            this.isAdmin = isAdmin;
            SetupDataGridView();
            LoadKullanicilar();
        }

        private void InitializeComponent()
        {
            this.panelMain = new Panel();
            this.lblBaslik = new Label();
            this.dgvKullanicilar = new DataGridView();
            this.btnYeniKullanici = new Button();
            this.btnGuncelle = new Button();
            this.btnSil = new Button();
            this.btnYenile = new Button();
            this.btnKapat = new Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).BeginInit();
            this.SuspendLayout();

            // panelMain
            this.panelMain.BackColor = Color.FromArgb(245, 245, 245);
            this.panelMain.Controls.Add(this.lblBaslik);
            this.panelMain.Controls.Add(this.dgvKullanicilar);
            this.panelMain.Controls.Add(this.btnYeniKullanici);
            this.panelMain.Controls.Add(this.btnGuncelle);
            this.panelMain.Controls.Add(this.btnSil);
            this.panelMain.Controls.Add(this.btnYenile);
            this.panelMain.Controls.Add(this.btnKapat);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new Size(900, 600);
            this.panelMain.TabIndex = 0;

            // lblBaslik
            this.lblBaslik.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblBaslik.ForeColor = Color.FromArgb(0, 128, 0);
            this.lblBaslik.Location = new Point(20, 20);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(860, 40);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Üyelik İşlemleri";
            this.lblBaslik.TextAlign = ContentAlignment.MiddleCenter;

            // dgvKullanicilar
            this.dgvKullanicilar.AllowUserToAddRows = false;
            this.dgvKullanicilar.AllowUserToDeleteRows = false;
            this.dgvKullanicilar.AutoGenerateColumns = true;
            this.dgvKullanicilar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKullanicilar.BackgroundColor = Color.White;
            this.dgvKullanicilar.BorderStyle = BorderStyle.None;
            this.dgvKullanicilar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKullanicilar.Location = new Point(20, 80);
            this.dgvKullanicilar.MultiSelect = false;
            this.dgvKullanicilar.Name = "dgvKullanicilar";
            this.dgvKullanicilar.ReadOnly = true;
            this.dgvKullanicilar.RowTemplate.Height = 25;
            this.dgvKullanicilar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvKullanicilar.Size = new Size(860, 400);
            this.dgvKullanicilar.TabIndex = 1;
            this.dgvKullanicilar.CellClick += dgvKullanicilar_CellClick;

            // btnYeniKullanici
            this.btnYeniKullanici.BackColor = Color.FromArgb(76, 175, 80);
            this.btnYeniKullanici.FlatAppearance.BorderSize = 0;
            this.btnYeniKullanici.FlatStyle = FlatStyle.Flat;
            this.btnYeniKullanici.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnYeniKullanici.ForeColor = Color.White;
            this.btnYeniKullanici.Location = new Point(20, 500);
            this.btnYeniKullanici.Name = "btnYeniKullanici";
            this.btnYeniKullanici.Size = new Size(150, 40);
            this.btnYeniKullanici.TabIndex = 2;
            this.btnYeniKullanici.Text = "Yeni Kullanıcı";
            this.btnYeniKullanici.UseVisualStyleBackColor = false;
            this.btnYeniKullanici.Click += btnYeniKullanici_Click;

            // btnGuncelle
            this.btnGuncelle.BackColor = Color.FromArgb(33, 150, 243);
            this.btnGuncelle.FlatAppearance.BorderSize = 0;
            this.btnGuncelle.FlatStyle = FlatStyle.Flat;
            this.btnGuncelle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnGuncelle.ForeColor = Color.White;
            this.btnGuncelle.Location = new Point(190, 500);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new Size(150, 40);
            this.btnGuncelle.TabIndex = 3;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += btnGuncelle_Click;

            // btnSil
            this.btnSil.BackColor = Color.FromArgb(244, 67, 54);
            this.btnSil.FlatAppearance.BorderSize = 0;
            this.btnSil.FlatStyle = FlatStyle.Flat;
            this.btnSil.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSil.ForeColor = Color.White;
            this.btnSil.Location = new Point(360, 500);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new Size(150, 40);
            this.btnSil.TabIndex = 4;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += btnSil_Click;

            // btnYenile
            this.btnYenile.BackColor = Color.FromArgb(255, 152, 0);
            this.btnYenile.FlatAppearance.BorderSize = 0;
            this.btnYenile.FlatStyle = FlatStyle.Flat;
            this.btnYenile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnYenile.ForeColor = Color.White;
            this.btnYenile.Location = new Point(530, 500);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new Size(150, 40);
            this.btnYenile.TabIndex = 5;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.UseVisualStyleBackColor = false;
            this.btnYenile.Click += btnYenile_Click;

            // btnKapat
            this.btnKapat.BackColor = Color.FromArgb(158, 158, 158);
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = FlatStyle.Flat;
            this.btnKapat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnKapat.ForeColor = Color.White;
            this.btnKapat.Location = new Point(700, 500);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(150, 40);
            this.btnKapat.TabIndex = 6;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += btnKapat_Click;

            // UyelikIslemleriForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 600);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UyelikIslemleriForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Üyelik İşlemleri";
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).EndInit();
            this.ResumeLayout(false);
        }

        private Panel panelMain;
        private Label lblBaslik;
        private DataGridView dgvKullanicilar;
        private Button btnYeniKullanici;
        private Button btnGuncelle;
        private Button btnSil;
        private Button btnYenile;
        private Button btnKapat;

        private void SetupDataGridView()
        {
            // DataGridView sütunlarını ayarla
            kullanicilarTable.Columns.Add("kullanici_id", typeof(int));
            kullanicilarTable.Columns.Add("ad", typeof(string));
            kullanicilarTable.Columns.Add("soyad", typeof(string));
            kullanicilarTable.Columns.Add("tc", typeof(string));
            kullanicilarTable.Columns.Add("telefon", typeof(string));
            kullanicilarTable.Columns.Add("email", typeof(string));
            kullanicilarTable.Columns.Add("rol_adlari", typeof(string));
            kullanicilarTable.Columns.Add("status", typeof(int));

            dgvKullanicilar.DataSource = kullanicilarTable;
        }

        private async void LoadKullanicilar()
        {
            try
            {
                btnYenile.Enabled = false;
                btnYenile.Text = "Yükleniyor...";

                var response = await apiHelper.GetAllUsersAsync();
                
                if (response is Newtonsoft.Json.Linq.JArray kullaniciArray)
                {
                    kullanicilarTable.Clear();

                    foreach (var kullanici in kullaniciArray)
                    {
                        // Sadece aktif kullanıcıları göster (status = 1 veya null)
                        var status = kullanici["status"];
                        if (status != null && Convert.ToInt32(status) == 0)
                        {
                            continue; // Bu kullanıcıyı atla (silinmiş)
                        }

                        string rolAdlari = "";
                        if (kullanici["rol_adlari"] != null)
                        {
                            var roller = kullanici["rol_adlari"] as Newtonsoft.Json.Linq.JArray;
                            if (roller != null)
                            {
                                rolAdlari = string.Join(", ", roller.Select(r => r.ToString()));
                            }
                        }

                        kullanicilarTable.Rows.Add(
                            kullanici["kullanici_id"],
                            kullanici["ad"]?.ToString() ?? "",
                            kullanici["soyad"]?.ToString() ?? "",
                            kullanici["tc"]?.ToString() ?? "",
                            kullanici["telefon"]?.ToString() ?? "",
                            kullanici["email"]?.ToString() ?? "",
                            rolAdlari,
                            kullanici["status"]
                        );
                    }
                }

                lblBaslik.Text = $"Üyelik İşlemleri - Toplam {kullanicilarTable.Rows.Count} Kullanıcı";
                
                // Status sütununu gizle (sadece veri için kullanılacak)
                if (dgvKullanicilar.Columns.Contains("status"))
                {
                    dgvKullanicilar.Columns["status"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcılar yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnYenile.Enabled = true;
                btnYenile.Text = "Yenile";
            }
        }

        private void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvKullanicilar.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnYeniKullanici_Click(object sender, EventArgs e)
        {
            // Yeni kullanıcı ekleme dialog'u aç (Admin kontrolü ile)
            using (var ekleForm = new KullaniciEkleForm(isAdmin))
            {
                if (ekleForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Yeni kullanıcı başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Listeyi yenile
                    LoadKullanicilar();
                }
            }
        }

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvKullanicilar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellenecek kullanıcıyı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvKullanicilar.SelectedRows[0];
            int kullaniciId = Convert.ToInt32(selectedRow.Cells["kullanici_id"].Value);
            string kullaniciAdi = selectedRow.Cells["ad"].Value.ToString() + " " + selectedRow.Cells["soyad"].Value.ToString();

            // Kullanıcı güncelleme dialog'u aç (Admin kontrolü ile)
            using (var guncelleForm = new KullaniciGuncelleForm(kullaniciId, selectedRow, isAdmin))
            {
                if (guncelleForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show($"'{kullaniciAdi}' adlı kullanıcının bilgileri başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Listeyi yenile
                    LoadKullanicilar();
                }
            }
        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvKullanicilar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek kullanıcıyı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvKullanicilar.SelectedRows[0];
            int kullaniciId = Convert.ToInt32(selectedRow.Cells["kullanici_id"].Value);
            string kullaniciAdi = selectedRow.Cells["ad"].Value.ToString() + " " + selectedRow.Cells["soyad"].Value.ToString();

            var result = MessageBox.Show(
                $"'{kullaniciAdi}' adlı kullanıcıyı silmek istediğinizden emin misiniz?\n\nBu işlem geri alınamaz!",
                "Kullanıcı Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    btnSil.Enabled = false;
                    btnSil.Text = "Siliniyor...";

                    // Soft delete işlemi - özel silme metodu kullan
                    var response = await apiHelper.DeleteUserAsync(kullaniciId);
                    
                    MessageBox.Show("Kullanıcı başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Listeyi yenile
                    LoadKullanicilar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Kullanıcı silinirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnSil.Enabled = true;
                    btnSil.Text = "Sil";
                }
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            LoadKullanicilar();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 