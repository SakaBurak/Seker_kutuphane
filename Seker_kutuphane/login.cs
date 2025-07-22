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

namespace Seker_kutuphane
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Panel çizim işlemleri buraya eklenebilir.

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

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /* this.Close();
             var kayit = new Form();
             kayit.Show();*/

            Kayit kayitform = new Kayit(); 
            kayitform.Show();
            this.Hide();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string sifre = txtSifre.Text.Trim();
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen e-posta ve şifre giriniz.");
                return;
            }
            DatabaseHelper db = new DatabaseHelper();
            DataTable dt = db.KullaniciGetir(email);
            if (dt != null && dt.Rows.Count > 0)
            {
                string? dbSifre = dt.Rows[0]["sifre"]?.ToString();
                bool sifreDogru = false;
                if (!string.IsNullOrEmpty(dbSifre) && (dbSifre.StartsWith("$2a$") || dbSifre.StartsWith("$2b$")))
                {
                    sifreDogru = BCrypt.Net.BCrypt.Verify(sifre, dbSifre);
                }
                else
                {
                    sifreDogru = (dbSifre == sifre);
                }
                if (sifreDogru)
                {
                    int kullaniciId = Convert.ToInt32(dt.Rows[0]["kullanici_id"]);
                    string ad = dt.Rows[0]["ad"]?.ToString() ?? "";
                    string rol = db.KullaniciRolGetir(kullaniciId);
                    Form2 dashboard = new Form2(ad, rol);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Şifre yanlış!");
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı bulunamadı!");
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
