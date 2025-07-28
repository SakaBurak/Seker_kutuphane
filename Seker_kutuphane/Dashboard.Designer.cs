namespace Seker_kutuphane
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnKitaplar;
        private System.Windows.Forms.Button btnUyeler;
        private System.Windows.Forms.Button btnEmanetler;
        private System.Windows.Forms.Button btnRaporlar;
        private System.Windows.Forms.Button btnYonetim;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblKullanici;
        private void InitializeComponent()
        {
            panelMenu = new Panel();
            btnKitaplar = new Button();
            btnUyeler = new Button();
            btnEmanetler = new Button();
            btnRaporlar = new Button();
            btnYonetim = new Button();
            btnCikis = new Button();
            lblBaslik = new Label();
            lblKullanici = new Label();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(0, 128, 0);
            panelMenu.Controls.Add(btnKitaplar);
            panelMenu.Controls.Add(btnUyeler);
            panelMenu.Controls.Add(btnEmanetler);
            panelMenu.Controls.Add(btnRaporlar);
            panelMenu.Controls.Add(btnYonetim);
            panelMenu.Controls.Add(btnCikis);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(180, 450);
            panelMenu.TabIndex = 2;
            // 
            // btnKitaplar
            // 
            btnKitaplar.Location = new Point(10, 60);
            btnKitaplar.Name = "btnKitaplar";
            btnKitaplar.Size = new Size(160, 35);
            btnKitaplar.TabIndex = 0;
            btnKitaplar.Text = "Kitaplar";
            btnKitaplar.Click += btnKitaplar_Click;
            // 
            // btnUyeler
            // 
            btnUyeler.Location = new Point(10, 105);
            btnUyeler.Name = "btnUyeler";
            btnUyeler.Size = new Size(160, 35);
            btnUyeler.TabIndex = 1;
            btnUyeler.Text = "Üyeler";
            // 
            // btnEmanetler
            // 
            btnEmanetler.Location = new Point(10, 150);
            btnEmanetler.Name = "btnEmanetler";
            btnEmanetler.Size = new Size(160, 35);
            btnEmanetler.TabIndex = 2;
            btnEmanetler.Text = "Emanetler";
            // 
            // btnRaporlar
            // 
            btnRaporlar.Location = new Point(10, 195);
            btnRaporlar.Name = "btnRaporlar";
            btnRaporlar.Size = new Size(160, 35);
            btnRaporlar.TabIndex = 3;
            btnRaporlar.Text = "Raporlar";
            // 
            // btnYonetim
            // 
            btnYonetim.Location = new Point(10, 240);
            btnYonetim.Name = "btnYonetim";
            btnYonetim.Size = new Size(160, 35);
            btnYonetim.TabIndex = 4;
            btnYonetim.Text = "Yönetim";
            // 
            // btnCikis
            // 
            btnCikis.Location = new Point(10, 285);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(160, 35);
            btnCikis.TabIndex = 5;
            btnCikis.Text = "Çıkış";
            // 
            // lblBaslik
            // 
            lblBaslik.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBaslik.ForeColor = Color.FromArgb(0, 128, 0);
            lblBaslik.Location = new Point(200, 20);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(400, 40);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "Kayseri Şeker Kütüphane Sistemi";
            // 
            // lblKullanici
            // 
            lblKullanici.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblKullanici.Font = new Font("Segoe UI", 10F);
            lblKullanici.ForeColor = Color.FromArgb(0, 128, 0);
            lblKullanici.Location = new Point(600, 20);
            lblKullanici.Name = "lblKullanici";
            lblKullanici.Size = new Size(180, 25);
            lblKullanici.TabIndex = 1;
            lblKullanici.Text = "Kullanıcı: - Rol: -";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblBaslik);
            Controls.Add(lblKullanici);
            Controls.Add(panelMenu);
            Name = "Form2";
            Text = "Dashboard";
            Load += Form2_Load;
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}