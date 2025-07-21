using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seker_kutuphane
{
    public partial class Form2 : Form
    {
        private string kullaniciAdi;
        private string rol;
        public Form2(string kullaniciAdi, string rol)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
            this.rol = rol;
            lblKullanici.Text = $"Kullanıcı: {kullaniciAdi}  |  Rol: {rol}";
            // Rol bazlı buton görünürlüğü
            if (rol == "Kullanici")
            {
                btnUyeler.Visible = false;
                btnRaporlar.Visible = false;
                btnYonetim.Visible = false;
            }
            else if (rol == "Yönetici")
            {
                btnUyeler.Visible = true;
                btnRaporlar.Visible = true;
                btnYonetim.Visible = true;
            }
            // Diğer roller için ek kurallar eklenebilir
        }

        private void Form2_Load(object? sender, EventArgs e)
        {
           DatabaseHelper db = new DatabaseHelper();
            // Örnek: admin@seker.com kullanıcısını test ediyoruz
            /*var dt = db.KullaniciGetir("admin@seker.com");
            if (dt.Rows.Count > 0)
            {
                int kullaniciId = Convert.ToInt32(dt.Rows[0]["kullanici_id"]);
                string rol = db.KullaniciRolGetir(kullaniciId);
                // MessageBox.Show($"Kullanıcı: {dt.Rows[0]["ad"]} | Rol: {rol}"); // Bu satırı kaldırıyorum
            }
            else
            {
                // MessageBox.Show("Kullanıcı bulunamadı!"); // Bu satırı da kaldırıyorum
            }*/
        }
    }
}
