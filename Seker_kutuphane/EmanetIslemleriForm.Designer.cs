namespace Seker_kutuphane
{
    partial class EmanetIslemleriForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnYeniEmanet = new System.Windows.Forms.Button();
            this.btnAnaSayfa = new System.Windows.Forms.Button();
            this.panelStats = new System.Windows.Forms.Panel();
            this.lblGecikmisEmanet = new System.Windows.Forms.Label();
            this.lblAktifEmanet = new System.Windows.Forms.Label();
            this.lblToplamEmanet = new System.Windows.Forms.Label();
            this.lblGecikmisEmanetTitle = new System.Windows.Forms.Label();
            this.lblAktifEmanetTitle = new System.Windows.Forms.Label();
            this.lblToplamEmanetTitle = new System.Windows.Forms.Label();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.lblArama = new System.Windows.Forms.Label();
            this.btnYenile = new System.Windows.Forms.Button();
            this.dataGridViewEmanetler = new System.Windows.Forms.DataGridView();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnIadeEt = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmanetler)).BeginInit();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.btnYeniEmanet);
            this.panelHeader.Controls.Add(this.btnAnaSayfa);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1200, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Emanet İşlemleri";
            // 
            // btnYeniEmanet
            // 
            this.btnYeniEmanet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYeniEmanet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(199)))), ((int)(((byte)(132)))));
            this.btnYeniEmanet.FlatAppearance.BorderSize = 0;
            this.btnYeniEmanet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniEmanet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnYeniEmanet.ForeColor = System.Drawing.Color.White;
            this.btnYeniEmanet.Location = new System.Drawing.Point(1050, 20);
            this.btnYeniEmanet.Name = "btnYeniEmanet";
            this.btnYeniEmanet.Size = new System.Drawing.Size(130, 40);
            this.btnYeniEmanet.TabIndex = 1;
            this.btnYeniEmanet.Text = "+ Yeni Emanet";
            this.btnYeniEmanet.UseVisualStyleBackColor = false;
            this.btnYeniEmanet.Click += new System.EventHandler(this.btnYeniEmanet_Click);
            // 
            // btnAnaSayfa
            // 
            this.btnAnaSayfa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnaSayfa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnAnaSayfa.FlatAppearance.BorderSize = 0;
            this.btnAnaSayfa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnaSayfa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAnaSayfa.ForeColor = System.Drawing.Color.White;
            this.btnAnaSayfa.Location = new System.Drawing.Point(900, 20);
            this.btnAnaSayfa.Name = "btnAnaSayfa";
            this.btnAnaSayfa.Size = new System.Drawing.Size(130, 40);
            this.btnAnaSayfa.TabIndex = 2;
            this.btnAnaSayfa.Text = "← Ana Sayfa";
            this.btnAnaSayfa.UseVisualStyleBackColor = false;
            this.btnAnaSayfa.Click += new System.EventHandler(this.btnAnaSayfa_Click);
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.White;
            this.panelStats.Controls.Add(this.lblGecikmisEmanet);
            this.panelStats.Controls.Add(this.lblAktifEmanet);
            this.panelStats.Controls.Add(this.lblToplamEmanet);
            this.panelStats.Controls.Add(this.lblGecikmisEmanetTitle);
            this.panelStats.Controls.Add(this.lblAktifEmanetTitle);
            this.panelStats.Controls.Add(this.lblToplamEmanetTitle);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 80);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(1200, 100);
            this.panelStats.TabIndex = 1;
            // 
            // lblGecikmisEmanet
            // 
            this.lblGecikmisEmanet.AutoSize = true;
            this.lblGecikmisEmanet.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGecikmisEmanet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.lblGecikmisEmanet.Location = new System.Drawing.Point(900, 30);
            this.lblGecikmisEmanet.Name = "lblGecikmisEmanet";
            this.lblGecikmisEmanet.Size = new System.Drawing.Size(37, 45);
            this.lblGecikmisEmanet.TabIndex = 5;
            this.lblGecikmisEmanet.Text = "0";
            // 
            // lblAktifEmanet
            // 
            this.lblAktifEmanet.AutoSize = true;
            this.lblAktifEmanet.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAktifEmanet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblAktifEmanet.Location = new System.Drawing.Point(500, 30);
            this.lblAktifEmanet.Name = "lblAktifEmanet";
            this.lblAktifEmanet.Size = new System.Drawing.Size(37, 45);
            this.lblAktifEmanet.TabIndex = 4;
            this.lblAktifEmanet.Text = "0";
            // 
            // lblToplamEmanet
            // 
            this.lblToplamEmanet.AutoSize = true;
            this.lblToplamEmanet.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblToplamEmanet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblToplamEmanet.Location = new System.Drawing.Point(100, 30);
            this.lblToplamEmanet.Name = "lblToplamEmanet";
            this.lblToplamEmanet.Size = new System.Drawing.Size(37, 45);
            this.lblToplamEmanet.TabIndex = 3;
            this.lblToplamEmanet.Text = "0";
            // 
            // lblGecikmisEmanetTitle
            // 
            this.lblGecikmisEmanetTitle.AutoSize = true;
            this.lblGecikmisEmanetTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGecikmisEmanetTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblGecikmisEmanetTitle.Location = new System.Drawing.Point(800, 75);
            this.lblGecikmisEmanetTitle.Name = "lblGecikmisEmanetTitle";
            this.lblGecikmisEmanetTitle.Size = new System.Drawing.Size(120, 19);
            this.lblGecikmisEmanetTitle.TabIndex = 2;
            this.lblGecikmisEmanetTitle.Text = "Gecikmiş Emanet";
            // 
            // lblAktifEmanetTitle
            // 
            this.lblAktifEmanetTitle.AutoSize = true;
            this.lblAktifEmanetTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAktifEmanetTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblAktifEmanetTitle.Location = new System.Drawing.Point(400, 75);
            this.lblAktifEmanetTitle.Name = "lblAktifEmanetTitle";
            this.lblAktifEmanetTitle.Size = new System.Drawing.Size(100, 19);
            this.lblAktifEmanetTitle.TabIndex = 1;
            this.lblAktifEmanetTitle.Text = "Aktif Emanet";
            // 
            // lblToplamEmanetTitle
            // 
            this.lblToplamEmanetTitle.AutoSize = true;
            this.lblToplamEmanetTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblToplamEmanetTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblToplamEmanetTitle.Location = new System.Drawing.Point(0, 75);
            this.lblToplamEmanetTitle.Name = "lblToplamEmanetTitle";
            this.lblToplamEmanetTitle.Size = new System.Drawing.Size(110, 19);
            this.lblToplamEmanetTitle.TabIndex = 0;
            this.lblToplamEmanetTitle.Text = "Toplam Emanet";
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.White;
            this.panelSearch.Controls.Add(this.txtArama);
            this.panelSearch.Controls.Add(this.lblArama);
            this.panelSearch.Controls.Add(this.btnYenile);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 180);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1200, 60);
            this.panelSearch.TabIndex = 2;
            // 
            // txtArama
            // 
            this.txtArama.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtArama.Location = new System.Drawing.Point(20, 20);
            this.txtArama.Name = "txtArama";
            this.txtArama.PlaceholderText = "🔍 Emanet ara...";
            this.txtArama.Size = new System.Drawing.Size(300, 29);
            this.txtArama.TabIndex = 2;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
            // 
            // lblArama
            // 
            this.lblArama.AutoSize = true;
            this.lblArama.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblArama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblArama.Location = new System.Drawing.Point(340, 23);
            this.lblArama.Name = "lblArama";
            this.lblArama.Size = new System.Drawing.Size(60, 21);
            this.lblArama.TabIndex = 1;
            this.lblArama.Text = "Arama:";
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnYenile.FlatAppearance.BorderSize = 0;
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYenile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnYenile.ForeColor = System.Drawing.Color.White;
            this.btnYenile.Location = new System.Drawing.Point(1100, 20);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(80, 30);
            this.btnYenile.TabIndex = 0;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.UseVisualStyleBackColor = false;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // dataGridViewEmanetler
            // 
            this.dataGridViewEmanetler.AllowUserToAddRows = false;
            this.dataGridViewEmanetler.AllowUserToDeleteRows = false;
            this.dataGridViewEmanetler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEmanetler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEmanetler.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewEmanetler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewEmanetler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmanetler.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewEmanetler.MultiSelect = false;
            this.dataGridViewEmanetler.Name = "dataGridViewEmanetler";
            this.dataGridViewEmanetler.ReadOnly = true;
            this.dataGridViewEmanetler.RowHeadersVisible = false;
            this.dataGridViewEmanetler.RowTemplate.Height = 25;
            this.dataGridViewEmanetler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEmanetler.Size = new System.Drawing.Size(1160, 400);
            this.dataGridViewEmanetler.TabIndex = 0;
            this.dataGridViewEmanetler.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewEmanetler_CellFormatting);
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.White;
            this.panelActions.Controls.Add(this.btnIadeEt);
            this.panelActions.Controls.Add(this.dataGridViewEmanetler);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActions.Location = new System.Drawing.Point(0, 240);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(1200, 460);
            this.panelActions.TabIndex = 3;
            // 
            // btnIadeEt
            // 
            this.btnIadeEt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIadeEt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnIadeEt.FlatAppearance.BorderSize = 0;
            this.btnIadeEt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIadeEt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnIadeEt.ForeColor = System.Drawing.Color.White;
            this.btnIadeEt.Location = new System.Drawing.Point(1050, 420);
            this.btnIadeEt.Name = "btnIadeEt";
            this.btnIadeEt.Size = new System.Drawing.Size(130, 35);
            this.btnIadeEt.TabIndex = 1;
            this.btnIadeEt.Text = "İade Et";
            this.btnIadeEt.UseVisualStyleBackColor = false;
            this.btnIadeEt.Click += new System.EventHandler(this.btnIadeEt_Click);
            // 
            // EmanetIslemleriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelHeader);
            this.Name = "EmanetIslemleriForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emanet İşlemleri";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmanetler)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private Button btnYeniEmanet;
        private Button btnAnaSayfa;
        private Panel panelStats;
        private Label lblGecikmisEmanet;
        private Label lblAktifEmanet;
        private Label lblToplamEmanet;
        private Label lblGecikmisEmanetTitle;
        private Label lblAktifEmanetTitle;
        private Label lblToplamEmanetTitle;
        private Panel panelSearch;
        private TextBox txtArama;
        private Label lblArama;
        private Button btnYenile;
        private DataGridView dataGridViewEmanetler;
        private Panel panelActions;
        private Button btnIadeEt;
    }
} 