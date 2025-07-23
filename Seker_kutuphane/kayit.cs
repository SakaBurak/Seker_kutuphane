using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seker_kutuphane;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace Seker_kutuphane
{
    public partial class Kayit : Form
    {
        public Kayit()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            v.SmoothingMode = SmoothingMode.AntiAlias;
            v.Clear(panel1.BackColor);
            GraphicsPath p = new GraphicsPath();
            int radius = 20;
            p.AddArc(new Rectangle(0, 0, 2 * radius, 2 * radius), 180, 90);
            p.AddLine(new Point(radius, 0), new Point(panel1.Width - radius, 0));
            p.AddArc(new Rectangle(panel1.Width - 2 * radius, 0, 2 * radius, 2 * radius), -90, 90);
            p.AddLine(new Point(panel1.Width, radius), new Point(panel1.Width, panel1.Height - radius));
            p.AddArc(new Rectangle(panel1.Width - 2 * radius, panel1.Height - 2 * radius, 2 * radius, 2 * radius), 0, 90);
            p.AddLine(new Point(panel1.Width - radius, panel1.Height), new Point(radius, panel1.Height));
            p.AddArc(new Rectangle(0, panel1.Height - 2 * radius, 2 * radius, 2 * radius), 90, 90);
            p.CloseFigure();
            panel1.Region = new Region(p);
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

        private async void button1_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text.Trim();
            string soyad = textBox2.Text.Trim();
            string tc = textBox7.Text.Trim();
            string telefon = textBox4.Text.Trim();
            string email = textBox3.Text.Trim();
            string sifre = textBox5.Text.Trim();
            string sifreTekrar = textBox6.Text.Trim();

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(telefon) || string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(sifreTekrar) || string.IsNullOrEmpty(tc))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }
            if (sifre != sifreTekrar)
            {
                MessageBox.Show("Şifreler eşleşmiyor!");
                return;
            }
            if (tc.Length != 11 || !tc.All(char.IsDigit))
            {
                MessageBox.Show("TC Kimlik numarası 11 haneli olmalı ve sadece rakamlardan oluşmalıdır.");
                return;
            }
            // Sadece şifre hashleniyor, TC düz gönderilecek
            string hashedSifre = Sha256Hash(sifre);
            var userData = new {
                ad,
                soyad,
                tc,
                telefon,
                email,
                sifre = hashedSifre
            };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(userData);
            MessageBox.Show("Gönderilen JSON:\n" + json);
            ApiHelper api = new ApiHelper();
            try
            {
                var result = await api.RegisterAsync(userData);
                MessageBox.Show("Kayıt başarılı! Giriş ekranına yönlendiriliyorsunuz.");
                Login girisform = new Login();
                girisform.Show();
                this.Hide();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Kayıt başarısız: {ex.Message}\nDetay: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt başarısız: {ex.Message}");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login girisform = new Login();  // Class ismine dikkat, büyük harfle
            girisform.Show();
            this.Hide();
        }

        private void cikisClk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
