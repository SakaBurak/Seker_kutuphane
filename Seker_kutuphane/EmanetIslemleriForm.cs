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
    public partial class EmanetIslemleriForm : Form
    {
        private ApiHelper apiHelper;
        private string kullaniciAdi;
        private string rol;
        private dynamic userData;
        private DataTable emanetTable;

        public EmanetIslemleriForm(string kullaniciAdi, string rol, dynamic userData = null)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
            this.rol = rol;
            this.userData = userData;
            this.apiHelper = new ApiHelper();
            InitializeEmanetTable();
            LoadEmanetler();
        }

        private void InitializeEmanetTable()
        {
            emanetTable = new DataTable();
            emanetTable.Columns.Add("EmanetId", typeof(int));
            emanetTable.Columns.Add("KullaniciAdi", typeof(string));
            emanetTable.Columns.Add("KitapAdi", typeof(string));
            emanetTable.Columns.Add("OduncTarihi", typeof(DateTime));
            emanetTable.Columns.Add("BeklenenTeslim", typeof(DateTime));
            emanetTable.Columns.Add("TeslimTarihi", typeof(DateTime));
            emanetTable.Columns.Add("Durum", typeof(string));
            emanetTable.Columns.Add("KullaniciId", typeof(int));
            emanetTable.Columns.Add("KitapId", typeof(int));

            dataGridViewEmanetler.DataSource = emanetTable;
            dataGridViewEmanetler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private async void LoadEmanetler()
        {
            try
            {
                var emanetler = await apiHelper.GetAllEmanetlerAsync();
                emanetTable.Clear();

                // Debug: API yanıtını kontrol et
                Console.WriteLine($"API Response Type: {emanetler?.GetType()}");
                Console.WriteLine($"API Response: {emanetler}");

                if (emanetler is Newtonsoft.Json.Linq.JArray emanetArray)
                {
                    Console.WriteLine($"JArray Count: {emanetArray.Count}");
                    foreach (var emanet in emanetArray)
                    {
                        Console.WriteLine($"Processing emanet: {emanet}");
                        var row = emanetTable.NewRow();
                        
                        try
                        {
                            // API'deki alan adlarına göre uyarlama
                            row["EmanetId"] = emanet["odunc_id"]?.ToString() != null ? int.Parse(emanet["odunc_id"].ToString()) : 0;
                            row["KullaniciAdi"] = $"{emanet["ad"]?.ToString() ?? ""} {emanet["soyad"]?.ToString() ?? ""}".Trim();
                            row["KitapAdi"] = emanet["title"]?.ToString() ?? "";
                            row["OduncTarihi"] = DateTime.Parse(emanet["odunc_tarihi"]?.ToString() ?? DateTime.Now.ToString());
                            row["BeklenenTeslim"] = DateTime.Parse(emanet["iade_tarihi"]?.ToString() ?? DateTime.Now.AddDays(30).ToString());
                            row["TeslimTarihi"] = emanet["iade_tarihi"] != null && emanet["teslim_edildi"]?.ToString() == "1" ? DateTime.Parse(emanet["iade_tarihi"].ToString()) : DBNull.Value;
                            row["Durum"] = emanet["teslim_edildi"]?.ToString() == "1" ? "İade Edildi" : "İade Edilmedi";
                            row["KullaniciId"] = emanet["kullanici_id"]?.ToString() != null ? int.Parse(emanet["kullanici_id"].ToString()) : 0;
                            row["KitapId"] = emanet["id"]?.ToString() != null ? int.Parse(emanet["id"].ToString()) : 0;
                            emanetTable.Rows.Add(row);
                            Console.WriteLine($"Added row: {row["EmanetId"]} - {row["KullaniciAdi"]} - {row["KitapAdi"]}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error processing emanet: {ex.Message}");
                        }
                    }
                }
                else if (emanetler is Newtonsoft.Json.Linq.JObject)
                {
                    // Tek bir emanet objesi olabilir
                    var emanet = (Newtonsoft.Json.Linq.JObject)emanetler;
                    var row = emanetTable.NewRow();
                    row["EmanetId"] = emanet["odunc_id"]?.ToString() != null ? int.Parse(emanet["odunc_id"].ToString()) : 0;
                    row["KullaniciAdi"] = $"{emanet["ad"]?.ToString() ?? ""} {emanet["soyad"]?.ToString() ?? ""}".Trim();
                    row["KitapAdi"] = emanet["title"]?.ToString() ?? "";
                    row["OduncTarihi"] = DateTime.Parse(emanet["odunc_tarihi"]?.ToString() ?? DateTime.Now.ToString());
                    row["BeklenenTeslim"] = DateTime.Parse(emanet["iade_tarihi"]?.ToString() ?? DateTime.Now.AddDays(30).ToString());
                    row["TeslimTarihi"] = emanet["iade_tarihi"] != null && emanet["teslim_edildi"]?.ToString() == "1" ? DateTime.Parse(emanet["iade_tarihi"].ToString()) : DBNull.Value;
                    row["Durum"] = emanet["teslim_edildi"]?.ToString() == "1" ? "İade Edildi" : "İade Edilmedi";
                    row["KullaniciId"] = emanet["kullanici_id"]?.ToString() != null ? int.Parse(emanet["kullanici_id"].ToString()) : 0;
                    row["KitapId"] = emanet["id"]?.ToString() != null ? int.Parse(emanet["id"].ToString()) : 0;
                    emanetTable.Rows.Add(row);
                }
                else
                {
                    Console.WriteLine($"Unexpected response type: {emanetler?.GetType()}");
                }

                Console.WriteLine($"Total rows in table: {emanetTable.Rows.Count}");
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LoadEmanetler Error: {ex.Message}");
                MessageBox.Show($"Emanetler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics()
        {
            int toplamEmanet = emanetTable.Rows.Count;
            int aktifEmanet = 0;
            int gecikmisEmanet = 0;

            foreach (DataRow row in emanetTable.Rows)
            {
                if (row["Durum"].ToString() == "AKTİF")
                {
                    aktifEmanet++;
                    var beklenenTeslim = (DateTime)row["BeklenenTeslim"];
                    if (DateTime.Now > beklenenTeslim)
                    {
                        gecikmisEmanet++;
                    }
                }
            }

            lblToplamEmanet.Text = toplamEmanet.ToString();
            lblAktifEmanet.Text = aktifEmanet.ToString();
            lblGecikmisEmanet.Text = gecikmisEmanet.ToString();
        }

        private async void btnYeniEmanet_Click(object sender, EventArgs e)
        {
            var yeniEmanetForm = new YeniEmanetForm(apiHelper);
            if (yeniEmanetForm.ShowDialog() == DialogResult.OK)
            {
                LoadEmanetler();
            }
        }

        private async void btnIadeEt_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmanetler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen iade edilecek emaneti seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridViewEmanetler.SelectedRows[0];
            int emanetId = (int)selectedRow.Cells["EmanetId"].Value;
            string kullaniciAdi = selectedRow.Cells["KullaniciAdi"].Value.ToString();
            string kitapAdi = selectedRow.Cells["KitapAdi"].Value.ToString();

            if (selectedRow.Cells["Durum"].Value.ToString() != "AKTİF")
            {
                MessageBox.Show("Bu emanet zaten iade edilmiş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"{kullaniciAdi} adlı kullanıcının '{kitapAdi}' kitabını iade etmek istediğinizden emin misiniz?",
                "Emanet İade Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await apiHelper.ReturnEmanetAsync(emanetId);
                    MessageBox.Show("Emanet başarıyla iade edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmanetler();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Emanet iade edilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void txtArama_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtArama.Text))
            {
                LoadEmanetler();
                return;
            }

            try
            {
                var aramaSonuclari = await apiHelper.SearchEmanetlerAsync(txtArama.Text);
                emanetTable.Clear();

                if (aramaSonuclari is Newtonsoft.Json.Linq.JArray sonucArray)
                {
                    foreach (var emanet in sonucArray)
                    {
                        var row = emanetTable.NewRow();
                        row["EmanetId"] = emanet["emanet_id"]?.ToString() != null ? int.Parse(emanet["emanet_id"].ToString()) : 0;
                        row["KullaniciAdi"] = emanet["kullanici_adi"]?.ToString() ?? "";
                        row["KitapAdi"] = emanet["kitap_adi"]?.ToString() ?? "";
                        row["OduncTarihi"] = DateTime.Parse(emanet["odunc_tarihi"]?.ToString() ?? DateTime.Now.ToString());
                        row["BeklenenTeslim"] = DateTime.Parse(emanet["beklenen_teslim"]?.ToString() ?? DateTime.Now.AddDays(30).ToString());
                        row["TeslimTarihi"] = emanet["teslim_tarihi"] != null ? DateTime.Parse(emanet["teslim_tarihi"].ToString()) : DBNull.Value;
                        row["Durum"] = emanet["durum"]?.ToString() ?? "";
                        row["KullaniciId"] = emanet["kullanici_id"]?.ToString() != null ? int.Parse(emanet["kullanici_id"].ToString()) : 0;
                        row["KitapId"] = emanet["kitap_id"]?.ToString() != null ? int.Parse(emanet["kitap_id"].ToString()) : 0;
                        emanetTable.Rows.Add(row);
                    }
                }

                UpdateStatistics();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Arama hatası: {ex.Message}");
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            LoadEmanetler();
        }

        // Test butonu için event handler
        private void btnTestAPI_Click(object sender, EventArgs e)
        {
            var testForm = new EmanetTestForm();
            testForm.Show();
        }

        // Ana dashboard'a dönüş butonu için event handler
        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            // Dashboard'ı tekrar aç
            var dashboard = new Dashboard(kullaniciAdi, rol, userData);
            dashboard.Show();
            this.Close();
        }

        private void dataGridViewEmanetler_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewEmanetler.Columns["Durum"].Index && e.Value != null)
            {
                var cell = dataGridViewEmanetler.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (e.Value.ToString() == "AKTİF")
                {
                    cell.Style.BackColor = Color.LightGreen;
                    cell.Style.ForeColor = Color.DarkGreen;
                }
                else if (e.Value.ToString() == "İADE EDİLDİ")
                {
                    cell.Style.BackColor = Color.LightBlue;
                    cell.Style.ForeColor = Color.DarkBlue;
                }
            }

            if (e.ColumnIndex == dataGridViewEmanetler.Columns["BeklenenTeslim"].Index && e.Value != null)
            {
                var beklenenTeslim = (DateTime)e.Value;
                var oduncTarihi = (DateTime)dataGridViewEmanetler.Rows[e.RowIndex].Cells["OduncTarihi"].Value;
                var durum = dataGridViewEmanetler.Rows[e.RowIndex].Cells["Durum"].Value.ToString();

                if (durum == "AKTİF" && DateTime.Now > beklenenTeslim)
                {
                    dataGridViewEmanetler.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }
    }
} 