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
    public partial class YeniOduncForm : Form
    {
        private ApiHelper apiHelper;
        private DataTable kullanicilarTable;
        private DataTable kitaplarTable;

        public YeniOduncForm(ApiHelper apiHelper)
        {
            InitializeComponent();
            this.apiHelper = apiHelper;
            InitializeTables();
            LoadKullanicilar();
            LoadKitaplar();
        }

        private void InitializeTables()
        {
            // Kullanıcılar tablosu
            kullanicilarTable = new DataTable();
            kullanicilarTable.Columns.Add("KullaniciId", typeof(int));
            kullanicilarTable.Columns.Add("AdSoyad", typeof(string));
            kullanicilarTable.Columns.Add("TC", typeof(string));
            kullanicilarTable.Columns.Add("Email", typeof(string));

            // Kitaplar tablosu
            kitaplarTable = new DataTable();
            kitaplarTable.Columns.Add("KitapId", typeof(int));
            kitaplarTable.Columns.Add("KitapAdi", typeof(string));
            kitaplarTable.Columns.Add("Yazar", typeof(string));
            kitaplarTable.Columns.Add("Stok", typeof(int));
            kitaplarTable.Columns.Add("Yayinevi", typeof(string));
        }

        private async void LoadKullanicilar()
        {
            try
            {
                var kullanicilar = await apiHelper.GetAllUsersAsync();
                kullanicilarTable.Clear();

                Console.WriteLine($"Kullanıcılar API Response: {kullanicilar}");

                if (kullanicilar is Newtonsoft.Json.Linq.JArray kullaniciArray)
                {
                    Console.WriteLine($"Kullanıcı sayısı: {kullaniciArray.Count}");
                    foreach (var kullanici in kullaniciArray)
                    {
                        try
                        {
                            var row = kullanicilarTable.NewRow();
                            row["KullaniciId"] = kullanici["kullanici_id"]?.ToString() != null ? int.Parse(kullanici["kullanici_id"].ToString()) : 0;
                            row["AdSoyad"] = $"{kullanici["ad"]?.ToString() ?? ""} {kullanici["soyad"]?.ToString() ?? ""}".Trim();
                            row["TC"] = kullanici["tc"]?.ToString() ?? "";
                            row["Email"] = kullanici["email"]?.ToString() ?? "";
                            kullanicilarTable.Rows.Add(row);
                            Console.WriteLine($"Added user: {row["AdSoyad"]} - {row["TC"]}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error processing user: {ex.Message}");
                        }
                    }
                }

                Console.WriteLine($"Total users in table: {kullanicilarTable.Rows.Count}");
                comboBoxKullanici.DataSource = kullanicilarTable;
                comboBoxKullanici.DisplayMember = "AdSoyad";
                comboBoxKullanici.ValueMember = "KullaniciId";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LoadKullanicilar Error: {ex.Message}");
                MessageBox.Show($"Kullanıcılar yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadKitaplar()
        {
            try
            {
                var kitaplar = await apiHelper.GetAllBooksAsync();
                kitaplarTable.Clear();

                Console.WriteLine($"Kitaplar API Response: {kitaplar}");

                if (kitaplar is Newtonsoft.Json.Linq.JArray kitapArray)
                {
                    Console.WriteLine($"Kitap sayısı: {kitapArray.Count}");
                    foreach (var kitap in kitapArray)
                    {
                        try
                        {
                            var row = kitaplarTable.NewRow();
                            row["KitapId"] = kitap["id"]?.ToString() != null ? int.Parse(kitap["id"].ToString()) : 0;
                            row["KitapAdi"] = kitap["title"]?.ToString() ?? "";
                            row["Yazar"] = kitap["author"]?.ToString() ?? "";
                            row["Stok"] = kitap["mevcut"]?.ToString() != null ? int.Parse(kitap["mevcut"].ToString()) : 0;
                            row["Yayinevi"] = kitap["yayinevi"]?.ToString() ?? "";
                            kitaplarTable.Rows.Add(row);
                            Console.WriteLine($"Added book: {row["KitapAdi"]} - {row["Yazar"]} - Stok: {row["Stok"]}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error processing book: {ex.Message}");
                        }
                    }
                }

                Console.WriteLine($"Total books in table: {kitaplarTable.Rows.Count}");
                comboBoxKitap.DataSource = kitaplarTable;
                comboBoxKitap.DisplayMember = "KitapAdi";
                comboBoxKitap.ValueMember = "KitapId";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LoadKitaplar Error: {ex.Message}");
                MessageBox.Show($"Kitaplar yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxKitap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKitap.SelectedItem != null)
            {
                var selectedRow = (DataRowView)comboBoxKitap.SelectedItem;
                int stok = (int)selectedRow["Stok"];
                string yazar = selectedRow["Yazar"].ToString();
                string yayinevi = selectedRow["Yayinevi"].ToString();

                lblStok.Text = $"Stok: {stok}";
                lblYazar.Text = $"Yazar: {yazar}";
                lblYayinevi.Text = $"Yayınevi: {yayinevi}";

                // Stok kontrolü
                if (stok <= 0)
                {
                    btnOduncVer.Enabled = false;
                    lblStok.ForeColor = Color.Red;
                    lblStok.Text += " (Stokta kitap yok!)";
                }
                else
                {
                    btnOduncVer.Enabled = true;
                    lblStok.ForeColor = Color.Green;
                }
            }
        }

        private async void btnOduncVer_Click(object sender, EventArgs e)
        {
            if (comboBoxKullanici.SelectedItem == null || comboBoxKitap.SelectedItem == null)
            {
                MessageBox.Show("Lütfen kullanıcı ve kitap seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var kullaniciRow = (DataRowView)comboBoxKullanici.SelectedItem;
            var kitapRow = (DataRowView)comboBoxKitap.SelectedItem;

            int kullaniciId = (int)kullaniciRow["KullaniciId"];
            int kitapId = (int)kitapRow["KitapId"];
            int stok = (int)kitapRow["Stok"];

            if (stok <= 0)
            {
                MessageBox.Show("Seçilen kitabın stokta kopyası bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ödünç süresi 30 gün
            DateTime oduncTarihi = DateTime.Now;
            DateTime iadeTarihi = oduncTarihi.AddDays(30);

            var oduncData = new
            {
                kullanici_id = kullaniciId,
                kitap_id = kitapId,
                odunc_tarihi = oduncTarihi.ToString("yyyy-MM-dd"),
                iade_tarihi = iadeTarihi.ToString("yyyy-MM-dd"),
                durum = "AKTİF"
            };

            try
            {
                await apiHelper.CreateOduncAsync(oduncData);
                MessageBox.Show("Ödünç başarıyla oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ödünç oluşturulurken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtAramaKullanici_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAramaKullanici.Text))
                {
                    comboBoxKullanici.DataSource = kullanicilarTable;
                }
                else
                {
                    var filteredTable = kullanicilarTable.Clone();
                    var searchTerm = txtAramaKullanici.Text.ToLower();
                    
                    foreach (DataRow row in kullanicilarTable.Rows)
                    {
                        var adSoyad = row["AdSoyad"].ToString().ToLower();
                        var tc = row["TC"].ToString().ToLower();
                        
                        if (adSoyad.Contains(searchTerm) || tc.Contains(searchTerm))
                        {
                            filteredTable.ImportRow(row);
                        }
                    }
                    
                    comboBoxKullanici.DataSource = filteredTable;
                    comboBoxKullanici.DisplayMember = "AdSoyad";
                    comboBoxKullanici.ValueMember = "KullaniciId";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kullanıcı arama hatası: {ex.Message}");
            }
        }

        private void txtAramaKitap_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAramaKitap.Text))
                {
                    comboBoxKitap.DataSource = kitaplarTable;
                }
                else
                {
                    var filteredTable = kitaplarTable.Clone();
                    var searchTerm = txtAramaKitap.Text.ToLower();
                    
                    foreach (DataRow row in kitaplarTable.Rows)
                    {
                        var kitapAdi = row["KitapAdi"].ToString().ToLower();
                        var yazar = row["Yazar"].ToString().ToLower();
                        
                        if (kitapAdi.Contains(searchTerm) || yazar.Contains(searchTerm))
                        {
                            filteredTable.ImportRow(row);
                        }
                    }
                    
                    comboBoxKitap.DataSource = filteredTable;
                    comboBoxKitap.DisplayMember = "KitapAdi";
                    comboBoxKitap.ValueMember = "KitapId";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kitap arama hatası: {ex.Message}");
            }
        }
    }
} 