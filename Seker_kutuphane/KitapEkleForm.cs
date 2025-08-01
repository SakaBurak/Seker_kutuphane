using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Seker_kutuphane
{
    public partial class KitapEkleForm : Form
    {
        private ApiHelper apiHelper;

        public KitapEkleForm()
        {
            InitializeComponent();
            this.apiHelper = new ApiHelper();
            SetupEnterKeyEvents();
        }

        private void InitializeComponent()
        {
            panelMain = new Panel();
            lblBaslik = new Label();
            lblKitapAdi = new Label();
            txtKitapAdi = new TextBox();
            lblYazar = new Label();
            txtYazar = new TextBox();
            lblYayinevi = new Label();
            txtYayinevi = new TextBox();
            lblYil = new Label();
            dtpYil = new DateTimePicker();
            lblAdet = new Label();
            txtAdet = new TextBox();
            lblSayfaSayisi = new Label();
            txtSayfaSayisi = new TextBox();
            btnEkle = new Button();
            btnIptal = new Button();
            panelMain.SuspendLayout();
            SuspendLayout();

            // panelMain
            panelMain.BackColor = Color.FromArgb(245, 245, 245);
            panelMain.Controls.Add(lblBaslik);
            panelMain.Controls.Add(lblKitapAdi);
            panelMain.Controls.Add(txtKitapAdi);
            panelMain.Controls.Add(lblYazar);
            panelMain.Controls.Add(txtYazar);
            panelMain.Controls.Add(lblYayinevi);
            panelMain.Controls.Add(txtYayinevi);
            panelMain.Controls.Add(lblYil);
            panelMain.Controls.Add(dtpYil);
            panelMain.Controls.Add(lblAdet);
            panelMain.Controls.Add(txtAdet);
            panelMain.Controls.Add(lblSayfaSayisi);
            panelMain.Controls.Add(txtSayfaSayisi);
            panelMain.Controls.Add(btnEkle);
            panelMain.Controls.Add(btnIptal);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(500, 520);
            panelMain.TabIndex = 0;

            // lblBaslik
            lblBaslik.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBaslik.ForeColor = Color.FromArgb(0, 128, 0);
            lblBaslik.Location = new Point(20, 20);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(460, 40);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "Yeni Kitap Ekle";
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;

            // lblKitapAdi
            lblKitapAdi.AutoSize = true;
            lblKitapAdi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblKitapAdi.ForeColor = Color.FromArgb(0, 128, 0);
            lblKitapAdi.Location = new Point(50, 80);
            lblKitapAdi.Name = "lblKitapAdi";
            lblKitapAdi.Size = new Size(80, 19);
            lblKitapAdi.TabIndex = 1;
            lblKitapAdi.Text = "Kitap Adı:";

            // txtKitapAdi
            txtKitapAdi.Font = new Font("Segoe UI", 10F);
            txtKitapAdi.Location = new Point(150, 77);
            txtKitapAdi.Name = "txtKitapAdi";
            txtKitapAdi.Size = new Size(300, 25);
            txtKitapAdi.TabIndex = 2;

            // lblYazar
            lblYazar.AutoSize = true;
            lblYazar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblYazar.ForeColor = Color.FromArgb(0, 128, 0);
            lblYazar.Location = new Point(50, 120);
            lblYazar.Name = "lblYazar";
            lblYazar.Size = new Size(50, 19);
            lblYazar.TabIndex = 3;
            lblYazar.Text = "Yazar:";

            // txtYazar
            txtYazar.Font = new Font("Segoe UI", 10F);
            txtYazar.Location = new Point(150, 117);
            txtYazar.Name = "txtYazar";
            txtYazar.Size = new Size(300, 25);
            txtYazar.TabIndex = 4;

            // lblYayinevi
            lblYayinevi.AutoSize = true;
            lblYayinevi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblYayinevi.ForeColor = Color.FromArgb(0, 128, 0);
            lblYayinevi.Location = new Point(50, 160);
            lblYayinevi.Name = "lblYayinevi";
            lblYayinevi.Size = new Size(70, 19);
            lblYayinevi.TabIndex = 5;
            lblYayinevi.Text = "Yayınevi:";

            // txtYayinevi
            txtYayinevi.Font = new Font("Segoe UI", 10F);
            txtYayinevi.Location = new Point(150, 157);
            txtYayinevi.Name = "txtYayinevi";
            txtYayinevi.Size = new Size(300, 25);
            txtYayinevi.TabIndex = 6;

            // lblYil
            lblYil.AutoSize = true;
            lblYil.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblYil.ForeColor = Color.FromArgb(0, 128, 0);
            lblYil.Location = new Point(50, 200);
            lblYil.Name = "lblYil";
            lblYil.Size = new Size(30, 19);
            lblYil.TabIndex = 7;
            lblYil.Text = "Yıl:";

            // dtpYil
            dtpYil.Font = new Font("Segoe UI", 10F);
            dtpYil.Location = new Point(150, 197);
            dtpYil.Name = "dtpYil";
            dtpYil.Size = new Size(300, 25);
            dtpYil.TabIndex = 8;
            dtpYil.Format = DateTimePickerFormat.Short;
            dtpYil.Value = DateTime.Now;

            // lblAdet
            lblAdet.AutoSize = true;
            lblAdet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAdet.ForeColor = Color.FromArgb(0, 128, 0);
            lblAdet.Location = new Point(50, 240);
            lblAdet.Name = "lblAdet";
            lblAdet.Size = new Size(45, 19);
            lblAdet.TabIndex = 9;
            lblAdet.Text = "Adet:";

            // txtAdet
            txtAdet.Font = new Font("Segoe UI", 10F);
            txtAdet.Location = new Point(150, 237);
            txtAdet.Name = "txtAdet";
            txtAdet.Size = new Size(300, 25);
            txtAdet.TabIndex = 10;

            // lblSayfaSayisi
            lblSayfaSayisi.AutoSize = true;
            lblSayfaSayisi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSayfaSayisi.ForeColor = Color.FromArgb(0, 128, 0);
            lblSayfaSayisi.Location = new Point(50, 280);
            lblSayfaSayisi.Name = "lblSayfaSayisi";
            lblSayfaSayisi.Size = new Size(90, 19);
            lblSayfaSayisi.TabIndex = 11;
            lblSayfaSayisi.Text = "Sayfa Sayısı:";

            // txtSayfaSayisi
            txtSayfaSayisi.Font = new Font("Segoe UI", 10F);
            txtSayfaSayisi.Location = new Point(150, 277);
            txtSayfaSayisi.Name = "txtSayfaSayisi";
            txtSayfaSayisi.Size = new Size(300, 25);
            txtSayfaSayisi.TabIndex = 12;

            // btnEkle
            btnEkle.BackColor = Color.FromArgb(76, 175, 80);
            btnEkle.FlatAppearance.BorderSize = 0;
            btnEkle.FlatStyle = FlatStyle.Flat;
            btnEkle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEkle.ForeColor = Color.White;
            btnEkle.Location = new Point(150, 340);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(120, 40);
            btnEkle.TabIndex = 13;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += btnEkle_Click;

            // btnIptal
            btnIptal.BackColor = Color.FromArgb(158, 158, 158);
            btnIptal.FlatAppearance.BorderSize = 0;
            btnIptal.FlatStyle = FlatStyle.Flat;
            btnIptal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnIptal.ForeColor = Color.White;
            btnIptal.Location = new Point(290, 340);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(120, 40);
            btnIptal.TabIndex = 14;
            btnIptal.Text = "İptal";
            btnIptal.UseVisualStyleBackColor = false;
            btnIptal.Click += btnIptal_Click;

            // KitapEkleForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 520);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "KitapEkleForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Yeni Kitap Ekle";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelMain;
        private Label lblBaslik;
        private Label lblKitapAdi;
        private TextBox txtKitapAdi;
        private Label lblYazar;
        private TextBox txtYazar;
        private Label lblYayinevi;
        private TextBox txtYayinevi;
        private Label lblYil;
        private DateTimePicker dtpYil;
        private Label lblAdet;
        private TextBox txtAdet;
        private Label lblSayfaSayisi;
        private TextBox txtSayfaSayisi;
        private Button btnEkle;
        private Button btnIptal;

        private void SetupEnterKeyEvents()
        {
            // Tüm textbox'lara Enter tuşu desteği ekle
            txtKitapAdi.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Enter) btnEkle.PerformClick(); };
            txtYazar.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Enter) btnEkle.PerformClick(); };
            txtYayinevi.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Enter) btnEkle.PerformClick(); };
            dtpYil.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Enter) btnEkle.PerformClick(); };
            txtAdet.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Enter) btnEkle.PerformClick(); };
            txtSayfaSayisi.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Enter) btnEkle.PerformClick(); };
        }

        private async void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                // Form verilerini al
                string kitapAdi = txtKitapAdi.Text.Trim();
                string yazar = txtYazar.Text.Trim();
                string yayinevi = txtYayinevi.Text.Trim();
                DateTime secilenTarih = dtpYil.Value;
                string adet = txtAdet.Text.Trim();
                string sayfaSayisi = txtSayfaSayisi.Text.Trim();

                // Validasyon
                if (string.IsNullOrEmpty(kitapAdi) || string.IsNullOrEmpty(yazar) || 
                    string.IsNullOrEmpty(yayinevi) || string.IsNullOrEmpty(adet))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tarih kontrolü
                if (secilenTarih.Year < 1900 || secilenTarih.Year > DateTime.Now.Year)
                {
                    MessageBox.Show("Geçerli bir yıl seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Adet kontrolü
                if (!int.TryParse(adet, out int adetInt) || adetInt <= 0)
                {
                    MessageBox.Show("Geçerli bir adet giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // API'ye gönderilecek veri
                var kitapData = new
                {
                    kitap_adi = kitapAdi,
                    yazar = yazar,
                    yayinevi = yayinevi,
                    basim_yili = secilenTarih.ToString("yyyy-MM-dd"), // API'de basim_yili olarak tanımlı
                    kitap_adet = adetInt,
                    sayfa_sayisi = !string.IsNullOrEmpty(sayfaSayisi) ? int.Parse(sayfaSayisi) : (int?)null
                };

                btnEkle.Enabled = false;
                btnEkle.Text = "Ekleniyor...";

                // API'ye gönder
                var result = await apiHelper.AddBookAsync(kitapData);
                
                MessageBox.Show("Kitap başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kitap eklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEkle.Enabled = true;
                btnEkle.Text = "Ekle";
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 