namespace Police_Takip
{
    partial class Police_Ekle_UC
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tc_vergi = new System.Windows.Forms.TextBox();
            this.tam_ad = new System.Windows.Forms.TextBox();
            this.tel_no = new System.Windows.Forms.TextBox();
            this.sigorta_ettiren = new System.Windows.Forms.TextBox();
            this.police_teklif = new System.Windows.Forms.TextBox();
            this.plaka = new System.Windows.Forms.TextBox();
            this.belge_seri = new System.Windows.Forms.TextBox();
            this.asil = new System.Windows.Forms.TextBox();
            this.brut = new System.Windows.Forms.TextBox();
            this.net = new System.Windows.Forms.TextBox();
            this.ucret = new System.Windows.Forms.TextBox();
            this.aciklama = new System.Windows.Forms.RichTextBox();
            this.sigorta = new System.Windows.Forms.ComboBox();
            this.police = new System.Windows.Forms.ComboBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.asil_turu = new System.Windows.Forms.ComboBox();
            this.brut_turu = new System.Windows.Forms.ComboBox();
            this.taksit = new System.Windows.Forms.ComboBox();
            this.tanzim = new System.Windows.Forms.DateTimePicker();
            this.baslangic = new System.Windows.Forms.DateTimePicker();
            this.bitis = new System.Windows.Forms.DateTimePicker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(70, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sigorta Şirketi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(90, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Poliçe Türü:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(73, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "TC / Vergi No:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(113, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tam Adı:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(126, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tel No:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(68, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Sigorta Ettiren:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(48, 341);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Poliçe / Teklif No:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(98, 389);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Plaka / No:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(536, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(207, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Belge Seri / Diğer / UAVT:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(627, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Tanzim Tarihi:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(608, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Başlangıç Tarihi:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(644, 199);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 20);
            this.label12.TabIndex = 2;
            this.label12.Text = "Bitiş Tarihi:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(619, 244);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "Asıl Komisyon:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(653, 288);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 20);
            this.label14.TabIndex = 2;
            this.label14.Text = "Brüt Prim:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(659, 333);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 20);
            this.label15.TabIndex = 2;
            this.label15.Text = "Net Prim:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(633, 375);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 20);
            this.label16.TabIndex = 2;
            this.label16.Text = "Alınan Ücret:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(657, 417);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 20);
            this.label17.TabIndex = 2;
            this.label17.Text = "Açıklama:";
            // 
            // tc_vergi
            // 
            this.tc_vergi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tc_vergi.Location = new System.Drawing.Point(220, 141);
            this.tc_vergi.Name = "tc_vergi";
            this.tc_vergi.Size = new System.Drawing.Size(248, 27);
            this.tc_vergi.TabIndex = 3;
            this.tc_vergi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // tam_ad
            // 
            this.tam_ad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tam_ad.Location = new System.Drawing.Point(220, 191);
            this.tam_ad.Name = "tam_ad";
            this.tam_ad.Size = new System.Drawing.Size(248, 27);
            this.tam_ad.TabIndex = 3;
            // 
            // tel_no
            // 
            this.tel_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tel_no.Location = new System.Drawing.Point(220, 241);
            this.tel_no.Name = "tel_no";
            this.tel_no.Size = new System.Drawing.Size(248, 27);
            this.tel_no.TabIndex = 3;
            this.tel_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // sigorta_ettiren
            // 
            this.sigorta_ettiren.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sigorta_ettiren.Location = new System.Drawing.Point(220, 291);
            this.sigorta_ettiren.Name = "sigorta_ettiren";
            this.sigorta_ettiren.Size = new System.Drawing.Size(248, 27);
            this.sigorta_ettiren.TabIndex = 3;
            // 
            // police_teklif
            // 
            this.police_teklif.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.police_teklif.Location = new System.Drawing.Point(220, 338);
            this.police_teklif.Name = "police_teklif";
            this.police_teklif.Size = new System.Drawing.Size(248, 27);
            this.police_teklif.TabIndex = 3;
            // 
            // plaka
            // 
            this.plaka.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plaka.Location = new System.Drawing.Point(220, 386);
            this.plaka.Name = "plaka";
            this.plaka.Size = new System.Drawing.Size(248, 27);
            this.plaka.TabIndex = 3;
            // 
            // belge_seri
            // 
            this.belge_seri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.belge_seri.Location = new System.Drawing.Point(779, 48);
            this.belge_seri.Name = "belge_seri";
            this.belge_seri.Size = new System.Drawing.Size(248, 27);
            this.belge_seri.TabIndex = 3;
            // 
            // asil
            // 
            this.asil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.asil.Location = new System.Drawing.Point(880, 240);
            this.asil.Name = "asil";
            this.asil.Size = new System.Drawing.Size(147, 27);
            this.asil.TabIndex = 3;
            this.asil.TextChanged += new System.EventHandler(this.brut_TextChanged);
            this.asil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // brut
            // 
            this.brut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.brut.Location = new System.Drawing.Point(880, 285);
            this.brut.Name = "brut";
            this.brut.Size = new System.Drawing.Size(147, 27);
            this.brut.TabIndex = 3;
            this.brut.TextChanged += new System.EventHandler(this.brut_TextChanged);
            this.brut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // net
            // 
            this.net.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.net.Location = new System.Drawing.Point(779, 330);
            this.net.Name = "net";
            this.net.Size = new System.Drawing.Size(248, 27);
            this.net.TabIndex = 3;
            this.net.TextChanged += new System.EventHandler(this.net_TextChanged);
            this.net.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // ucret
            // 
            this.ucret.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ucret.Location = new System.Drawing.Point(880, 372);
            this.ucret.Name = "ucret";
            this.ucret.Size = new System.Drawing.Size(147, 27);
            this.ucret.TabIndex = 3;
            this.ucret.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // aciklama
            // 
            this.aciklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aciklama.Location = new System.Drawing.Point(779, 417);
            this.aciklama.Name = "aciklama";
            this.aciklama.Size = new System.Drawing.Size(248, 135);
            this.aciklama.TabIndex = 4;
            this.aciklama.Text = "";
            // 
            // sigorta
            // 
            this.sigorta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sigorta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sigorta.FormattingEnabled = true;
            this.sigorta.Location = new System.Drawing.Point(220, 48);
            this.sigorta.Name = "sigorta";
            this.sigorta.Size = new System.Drawing.Size(248, 28);
            this.sigorta.TabIndex = 5;
            // 
            // police
            // 
            this.police.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.police.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.police.FormattingEnabled = true;
            this.police.Location = new System.Drawing.Point(220, 94);
            this.police.Name = "police";
            this.police.Size = new System.Drawing.Size(248, 28);
            this.police.TabIndex = 5;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 15;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.DarkCyan;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(220, 450);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(248, 45);
            this.guna2Button1.TabIndex = 7;
            this.guna2Button1.Text = "Kaydet";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderRadius = 15;
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.DarkCyan;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Location = new System.Drawing.Point(220, 507);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(248, 45);
            this.guna2Button2.TabIndex = 7;
            this.guna2Button2.Text = "Temizle";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // asil_turu
            // 
            this.asil_turu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.asil_turu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.asil_turu.FormattingEnabled = true;
            this.asil_turu.Items.AddRange(new object[] {
            "TL",
            "Yüzde"});
            this.asil_turu.Location = new System.Drawing.Point(779, 239);
            this.asil_turu.Name = "asil_turu";
            this.asil_turu.Size = new System.Drawing.Size(95, 28);
            this.asil_turu.TabIndex = 8;
            this.asil_turu.SelectedIndexChanged += new System.EventHandler(this.brut_TextChanged);
            // 
            // brut_turu
            // 
            this.brut_turu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.brut_turu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.brut_turu.FormattingEnabled = true;
            this.brut_turu.Items.AddRange(new object[] {
            "Nakit",
            "Kredi Kartı",
            "Politika Karşılığı"});
            this.brut_turu.Location = new System.Drawing.Point(779, 284);
            this.brut_turu.Name = "brut_turu";
            this.brut_turu.Size = new System.Drawing.Size(95, 28);
            this.brut_turu.TabIndex = 8;
            // 
            // taksit
            // 
            this.taksit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.taksit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.taksit.FormattingEnabled = true;
            this.taksit.Items.AddRange(new object[] {
            "Taksitsiz",
            "3 Taksit",
            "6 Taksit",
            "9 Taksit",
            "12 Taksit",
            "24 Taksit",
            "36 Taksit"});
            this.taksit.Location = new System.Drawing.Point(779, 371);
            this.taksit.Name = "taksit";
            this.taksit.Size = new System.Drawing.Size(95, 28);
            this.taksit.TabIndex = 8;
            this.taksit.SelectedIndexChanged += new System.EventHandler(this.net_TextChanged);
            // 
            // tanzim
            // 
            this.tanzim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tanzim.Location = new System.Drawing.Point(779, 98);
            this.tanzim.Name = "tanzim";
            this.tanzim.Size = new System.Drawing.Size(248, 27);
            this.tanzim.TabIndex = 9;
            // 
            // baslangic
            // 
            this.baslangic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.baslangic.Location = new System.Drawing.Point(779, 145);
            this.baslangic.Name = "baslangic";
            this.baslangic.Size = new System.Drawing.Size(248, 27);
            this.baslangic.TabIndex = 9;
            // 
            // bitis
            // 
            this.bitis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bitis.Location = new System.Drawing.Point(779, 194);
            this.bitis.Name = "bitis";
            this.bitis.Size = new System.Drawing.Size(248, 27);
            this.bitis.TabIndex = 9;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // Police_Ekle_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bitis);
            this.Controls.Add(this.baslangic);
            this.Controls.Add(this.tanzim);
            this.Controls.Add(this.taksit);
            this.Controls.Add(this.brut_turu);
            this.Controls.Add(this.asil_turu);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.police);
            this.Controls.Add(this.sigorta);
            this.Controls.Add(this.aciklama);
            this.Controls.Add(this.ucret);
            this.Controls.Add(this.net);
            this.Controls.Add(this.brut);
            this.Controls.Add(this.asil);
            this.Controls.Add(this.belge_seri);
            this.Controls.Add(this.plaka);
            this.Controls.Add(this.police_teklif);
            this.Controls.Add(this.sigorta_ettiren);
            this.Controls.Add(this.tel_no);
            this.Controls.Add(this.tam_ad);
            this.Controls.Add(this.tc_vergi);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Police_Ekle_UC";
            this.Size = new System.Drawing.Size(1100, 590);
            this.Load += new System.EventHandler(this.Police_Ekle_UC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tc_vergi;
        private System.Windows.Forms.TextBox tam_ad;
        private System.Windows.Forms.TextBox tel_no;
        private System.Windows.Forms.TextBox sigorta_ettiren;
        private System.Windows.Forms.TextBox police_teklif;
        private System.Windows.Forms.TextBox plaka;
        private System.Windows.Forms.TextBox belge_seri;
        private System.Windows.Forms.TextBox asil;
        private System.Windows.Forms.TextBox brut;
        private System.Windows.Forms.TextBox net;
        private System.Windows.Forms.TextBox ucret;
        private System.Windows.Forms.RichTextBox aciklama;
        private System.Windows.Forms.ComboBox sigorta;
        private System.Windows.Forms.ComboBox police;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private System.Windows.Forms.ComboBox asil_turu;
        private System.Windows.Forms.ComboBox brut_turu;
        private System.Windows.Forms.ComboBox taksit;
        private System.Windows.Forms.DateTimePicker tanzim;
        private System.Windows.Forms.DateTimePicker baslangic;
        private System.Windows.Forms.DateTimePicker bitis;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
