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

        private async void Form2_Load(object? sender, EventArgs e)
        {
            // API üzerinden kullanıcı ve rol bilgisi almak için örnek:
            // ApiHelper api = new ApiHelper();
            // var user = await api.KullaniciGetirAsync("admin@seker.com");
            // if (user != null && user.Count > 0)
            // {
            //     int kullaniciId = (int)user[0].kullanici_id;
            //     string rol = await api.KullaniciRolGetirAsync(kullaniciId);
            //     // ...
            // }
        }

        private void btnKitaplar_Click(object sender, EventArgs e)
        {

        }
    }
}
