using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seker_kutuphane;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace Seker_kutuphane
{
    public partial class Login : Form
    {
        public Login()
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

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Kayit kayitform = new Kayit();
            kayitform.Show();
            this.Hide();
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

        private async void btnGirisYap_Click(object sender, EventArgs e)
        {
            string tc = txtEmail.Text.Trim(); // txtEmail artık TC Kimlik No için kullanılacak
            string sifre = txtSifre.Text.Trim();
            string hashedSifre = Sha256Hash(sifre);
            MessageBox.Show($"Girişte gönderilen JSON: {{\"tc\": \"{tc}\", \"sifre\": \"{hashedSifre}\"}}");
            if (string.IsNullOrEmpty(tc) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen TC Kimlik No ve şifre giriniz.");
                return;
            }
            ApiHelper api = new ApiHelper();
            try
            {
                var (sessionId, user) = await api.LoginAsync(tc, hashedSifre); // email yerine tc gönderiliyor
                if (user != null)
                {
                    string ad = user.ad ?? "";
                    string rol = user.rol_adi ?? "";
                    Form2 dashboard = new Form2(ad, rol);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı bulunamadı veya bilgiler hatalı!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Giriş başarısız: {ex.Message}");
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifre_yenileme yenile = new sifre_yenileme();
            yenile.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
