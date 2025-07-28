namespace Seker_kutuphane
{
    partial class KitapAramaForm
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
        private void InitializeComponent()
        {
            lblBaslik = new Label();
            txtArama = new TextBox();
            btnAra = new Button();
            btnTemizle = new Button();
            dgvKitaplar = new DataGridView();
            btnGeri = new Button();
            lblSonuc = new Label();
            panelArama = new Panel();
            panelSonuc = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvKitaplar).BeginInit();
            panelArama.SuspendLayout();
            panelSonuc.SuspendLayout();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            lblBaslik.Dock = DockStyle.Top;
            lblBaslik.Location = new Point(0, 0);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(1000, 60);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "Kitap Arama Motoru";
            // 
            // panelArama
            // 
            panelArama.BackColor = Color.White;
            panelArama.Controls.Add(btnTemizle);
            panelArama.Controls.Add(btnAra);
            panelArama.Controls.Add(txtArama);
            panelArama.Dock = DockStyle.Top;
            panelArama.Location = new Point(0, 60);
            panelArama.Name = "panelArama";
            panelArama.Padding = new Padding(20);
            panelArama.Size = new Size(1000, 80);
            panelArama.TabIndex = 1;
            // 
            // txtArama
            // 
            txtArama.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtArama.Location = new Point(20, 20);
            txtArama.Name = "txtArama";
            txtArama.Size = new Size(800, 40);
            txtArama.TabIndex = 0;
            txtArama.KeyPress += txtArama_KeyPress;
            // 
            // btnAra
            // 
            btnAra.Anchor = AnchorStyles.Right;
            btnAra.Location = new Point(700, 20);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(120, 40);
            btnAra.TabIndex = 1;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = false;
            btnAra.Click += btnAra_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.Anchor = AnchorStyles.Right;
            btnTemizle.Location = new Point(840, 20);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(120, 40);
            btnTemizle.TabIndex = 2;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;

            // panelSonuc
            // 
            panelSonuc.BackColor = Color.White;
            panelSonuc.Controls.Add(lblSonuc);
            panelSonuc.Controls.Add(btnGeri);
            panelSonuc.Dock = DockStyle.Bottom;
            panelSonuc.Location = new Point(0, 650);
            panelSonuc.Name = "panelSonuc";
            panelSonuc.Padding = new Padding(20);
            panelSonuc.Size = new Size(1000, 50);
            panelSonuc.TabIndex = 3;
            // 
            // lblSonuc
            // 
            lblSonuc.Anchor = AnchorStyles.Left;
            lblSonuc.AutoSize = true;
            lblSonuc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSonuc.ForeColor = Color.FromArgb(0, 128, 0);
            lblSonuc.Location = new Point(20, 15);
            lblSonuc.Name = "lblSonuc";
            lblSonuc.Size = new Size(0, 19);
            lblSonuc.TabIndex = 0;
            // 
            // btnGeri
            // 
            btnGeri.Anchor = AnchorStyles.Right;
            btnGeri.Location = new Point(860, 10);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(120, 30);
            btnGeri.TabIndex = 1;
            btnGeri.Text = "Geri Dön";
            btnGeri.UseVisualStyleBackColor = false;
            btnGeri.Click += btnGeri_Click;
            // 
            // dgvKitaplar
            // 
            dgvKitaplar.AllowUserToAddRows = false;
            dgvKitaplar.AllowUserToDeleteRows = false;
            dgvKitaplar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKitaplar.BackgroundColor = Color.White;
            dgvKitaplar.BorderStyle = BorderStyle.None;
            dgvKitaplar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKitaplar.Dock = DockStyle.Fill;
            dgvKitaplar.GridColor = Color.FromArgb(224, 224, 224);
            dgvKitaplar.Location = new Point(0, 140);
            dgvKitaplar.Name = "dgvKitaplar";
            dgvKitaplar.ReadOnly = true;
            dgvKitaplar.RowHeadersVisible = false;
            dgvKitaplar.RowTemplate.Height = 25;
            dgvKitaplar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKitaplar.Size = new Size(1000, 440);
            dgvKitaplar.TabIndex = 4;
            // 
            // KitapAramaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(dgvKitaplar);
            Controls.Add(panelSonuc);
            Controls.Add(panelArama);
            Controls.Add(lblBaslik);
            Name = "KitapAramaForm";
            Text = "Kitap Arama";
            FormClosing += KitapAramaForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvKitaplar).EndInit();
            panelArama.ResumeLayout(false);
            panelArama.PerformLayout();
            panelSonuc.ResumeLayout(false);
            panelSonuc.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblBaslik;
        private TextBox txtArama;
        private Button btnAra;
        private Button btnTemizle;
        private DataGridView dgvKitaplar;
        private Button btnGeri;
        private Label lblSonuc;
        private Panel panelArama;
        private Panel panelSonuc;
    }
} 