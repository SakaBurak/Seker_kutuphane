using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Seker_kutuphane
{
    public partial class KitapAramaForm : Form
    {
        private ApiHelper apiHelper;
        private Form2 dashboardForm;

        public KitapAramaForm(Form2 dashboardForm)
        {
            InitializeComponent();
            this.dashboardForm = dashboardForm;
            this.apiHelper = new ApiHelper();
            SetupFormDesign();
            LoadInitialData();
        }

        private void SetupFormDesign()
        {
            // Form ayarları
            this.Text = "Kitap Arama - Kayseri Şeker Kütüphane";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1000, 700);
            this.BackColor = Color.FromArgb(245, 245, 245);

            // Başlık
            lblBaslik.Text = "Kitap Arama Motoru";
            lblBaslik.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblBaslik.ForeColor = Color.FromArgb(0, 128, 0);
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;

            // Arama kutusu
            txtArama.Font = new Font("Segoe UI", 12);
            txtArama.PlaceholderText = "Kitap adı, yazar, yayınevi veya yıl ile arama yapın...";
            txtArama.BorderStyle = BorderStyle.FixedSingle;

            // Arama butonu
            btnAra.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnAra.BackColor = Color.FromArgb(76, 175, 80);
            btnAra.ForeColor = Color.White;
            btnAra.FlatStyle = FlatStyle.Flat;
            btnAra.FlatAppearance.BorderSize = 0;

            // Temizle butonu
            btnTemizle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnTemizle.BackColor = Color.FromArgb(255, 152, 0);
            btnTemizle.ForeColor = Color.White;
            btnTemizle.FlatStyle = FlatStyle.Flat;
            btnTemizle.FlatAppearance.BorderSize = 0;

            // Geri butonu
            btnGeri.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnGeri.BackColor = Color.FromArgb(244, 67, 54);
            btnGeri.ForeColor = Color.White;
            btnGeri.FlatStyle = FlatStyle.Flat;
            btnGeri.FlatAppearance.BorderSize = 0;

            // DataGridView ayarları
            dgvKitaplar.BackgroundColor = Color.White;
            dgvKitaplar.BorderStyle = BorderStyle.None;
            dgvKitaplar.GridColor = Color.FromArgb(224, 224, 224);
            dgvKitaplar.Font = new Font("Segoe UI", 9);
            dgvKitaplar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
            dgvKitaplar.RowHeadersVisible = false;
            dgvKitaplar.AllowUserToAddRows = false;
            dgvKitaplar.AllowUserToDeleteRows = false;
            dgvKitaplar.ReadOnly = true;
            dgvKitaplar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKitaplar.MultiSelect = false;

            // Hover efektleri
            SetupHoverEffects();
        }

        private void SetupHoverEffects()
        {
            btnAra.MouseEnter += (s, e) => btnAra.BackColor = Color.FromArgb(129, 199, 132);
            btnAra.MouseLeave += (s, e) => btnAra.BackColor = Color.FromArgb(76, 175, 80);

            btnTemizle.MouseEnter += (s, e) => btnTemizle.BackColor = Color.FromArgb(255, 167, 38);
            btnTemizle.MouseLeave += (s, e) => btnTemizle.BackColor = Color.FromArgb(255, 152, 0);

            btnGeri.MouseEnter += (s, e) => btnGeri.BackColor = Color.FromArgb(239, 83, 80);
            btnGeri.MouseLeave += (s, e) => btnGeri.BackColor = Color.FromArgb(244, 67, 54);
        }

        private async void LoadInitialData()
        {
            try
            {
                // Örnek kitap verilerini yükle
                await LoadSampleBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadSampleBooks()
        {
            try
            {
                // API'den tüm kitap verilerini al
                var books = await apiHelper.SearchBooksAsync();
                
                // DataGridView'ı temizle ve yeni veriyi yükle
                dgvKitaplar.DataSource = null;
                dgvKitaplar.DataSource = books;
                
                // Veri yüklendikten sonra sütun ayarlarını yap
                SetupDataGridView();
                lblSonuc.Text = $"Toplam {books.Count} kitap mevcut. Arama yapmak için yukarıdaki kutuya yazın.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kitap verileri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            try
            {
                if (dgvKitaplar.Columns.Count > 0)
                {
                    // KitapAdi sütunu
                    if (dgvKitaplar.Columns.Contains("KitapAdi"))
                    {
                        dgvKitaplar.Columns["KitapAdi"].HeaderText = "Kitap Adı";
                        dgvKitaplar.Columns["KitapAdi"].Width = 200;
                        dgvKitaplar.Columns["KitapAdi"].DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    }

                    // Yazar sütunu
                    if (dgvKitaplar.Columns.Contains("Yazar"))
                    {
                        dgvKitaplar.Columns["Yazar"].HeaderText = "Yazar";
                        dgvKitaplar.Columns["Yazar"].Width = 150;
                    }

                    // Yayinevi sütunu
                    if (dgvKitaplar.Columns.Contains("Yayinevi"))
                    {
                        dgvKitaplar.Columns["Yayinevi"].HeaderText = "Yayınevi";
                        dgvKitaplar.Columns["Yayinevi"].Width = 180;
                    }

                    // Yil sütunu
                    if (dgvKitaplar.Columns.Contains("Yil"))
                    {
                        dgvKitaplar.Columns["Yil"].HeaderText = "Yıl";
                        dgvKitaplar.Columns["Yil"].Width = 80;
                        dgvKitaplar.Columns["Yil"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // Stok sütunu
                    if (dgvKitaplar.Columns.Contains("Stok"))
                    {
                        dgvKitaplar.Columns["Stok"].HeaderText = "Stok";
                        dgvKitaplar.Columns["Stok"].Width = 80;
                        dgvKitaplar.Columns["Stok"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // Durum sütunu
                    if (dgvKitaplar.Columns.Contains("Durum"))
                    {
                        dgvKitaplar.Columns["Durum"].HeaderText = "Durum";
                        dgvKitaplar.Columns["Durum"].Width = 100;
                        dgvKitaplar.Columns["Durum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // Header stilleri
                    dgvKitaplar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 128, 0);
                    dgvKitaplar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgvKitaplar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    dgvKitaplar.ColumnHeadersHeight = 40;
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda sadece log yaz, kullanıcıya gösterme
                Console.WriteLine($"DataGridView ayarlanırken hata: {ex.Message}");
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void txtArama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PerformSearch();
                e.Handled = true;
            }
        }

        private async void PerformSearch()
        {
            string searchTerm = txtArama.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                // Arama terimi boşsa tüm kitapları göster
                await LoadSampleBooks();
                return;
            }

            try
            {
                // API'den arama yap (tüm alanlarda arama)
                var books = await apiHelper.SearchBooksAsync(searchTerm);
                
                // DataGridView'ı temizle ve yeni veriyi yükle
                dgvKitaplar.DataSource = null;
                dgvKitaplar.DataSource = books;
                
                // Veri yüklendikten sonra sütun ayarlarını yap
                SetupDataGridView();

                if (books.Count == 0)
                {
                    MessageBox.Show($"'{searchTerm}' ile ilgili kitap bulunamadı.", "Arama Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblSonuc.Text = "Aradığınız kitap bulunamadı.";
                    // DataGridView'ı temizle
                    dgvKitaplar.DataSource = null;
                }
                else
                {
                    lblSonuc.Text = $"'{searchTerm}' için {books.Count} kitap bulundu.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Arama sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnTemizle_Click(object sender, EventArgs e)
        {
            // Arama kutusunu temizle
            txtArama.Text = "";
            
            // Tüm kitapları göster
            LoadSampleBooks();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
            dashboardForm.Show();
        }

        private void KitapAramaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dashboardForm.Show();
        }
    }
} 