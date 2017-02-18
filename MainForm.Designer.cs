namespace YuzTanima
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_refresh_camerlist = new System.Windows.Forms.Button();
            this.btn_stop_capture = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbCamIndex = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lb_autorun = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_facename_file = new System.Windows.Forms.Label();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tbLog = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tanımlıYüzleriGörToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tanimliyuzlerisilmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLogOfDetectedFacesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tanımlanmışYüzLogKayıtlarınıSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kameraotomatikcalistirmaAyarla = new System.Windows.Forms.ToolStripMenuItem();
            this.kameraotomatikcalistirmaKapat = new System.Windows.Forms.ToolStripMenuItem();
            this.otomatikbaglantikur = new System.Windows.Forms.ToolStripMenuItem();
            this.otomatikbaglantikaldir = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(217, 279);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "2. Yüz Ekle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 297);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 22);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Kişinin Adı";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.imageBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(441, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(341, 327);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yüz Tanımlama :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 300);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "İsim : ";
            // 
            // imageBox1
            // 
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox1.Location = new System.Drawing.Point(15, 22);
            this.imageBox1.Margin = new System.Windows.Forms.Padding(4);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(307, 249);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox1.TabIndex = 5;
            this.imageBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(7, 523);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1041, 83);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sonuçlar : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 37);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "Ekranda Tanımlanan Kişi :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(270, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 23);
            this.label4.TabIndex = 16;
            this.label4.Text = "Hiçkimse";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(797, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(553, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tespit Edilen Yüz Sayısı : ";
            // 
            // btn_refresh_camerlist
            // 
            this.btn_refresh_camerlist.Location = new System.Drawing.Point(863, 236);
            this.btn_refresh_camerlist.Name = "btn_refresh_camerlist";
            this.btn_refresh_camerlist.Size = new System.Drawing.Size(165, 29);
            this.btn_refresh_camerlist.TabIndex = 19;
            this.btn_refresh_camerlist.Text = "Kamera Listesini Yenile";
            this.btn_refresh_camerlist.UseVisualStyleBackColor = true;
            this.btn_refresh_camerlist.Click += new System.EventHandler(this.btn_refresh_camerlist_Click);
            // 
            // btn_stop_capture
            // 
            this.btn_stop_capture.Location = new System.Drawing.Point(863, 100);
            this.btn_stop_capture.Name = "btn_stop_capture";
            this.btn_stop_capture.Size = new System.Drawing.Size(147, 38);
            this.btn_stop_capture.TabIndex = 18;
            this.btn_stop_capture.Text = "3. Algılamayı Durdur";
            this.btn_stop_capture.UseVisualStyleBackColor = true;
            this.btn_stop_capture.Click += new System.EventHandler(this.btn_stop_capture_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(860, 184);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Kamera Seç : ";
            // 
            // cbCamIndex
            // 
            this.cbCamIndex.FormattingEnabled = true;
            this.cbCamIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbCamIndex.Location = new System.Drawing.Point(863, 205);
            this.cbCamIndex.Margin = new System.Windows.Forms.Padding(4);
            this.cbCamIndex.Name = "cbCamIndex";
            this.cbCamIndex.Size = new System.Drawing.Size(149, 24);
            this.cbCamIndex.TabIndex = 14;
            this.cbCamIndex.Text = "0";
            this.cbCamIndex.SelectedIndexChanged += new System.EventHandler(this.cbCamIndex_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(863, 55);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "1. Yüz Algıla ve Tanı";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btn_refresh_camerlist);
            this.groupBox3.Controls.Add(this.cbCamIndex);
            this.groupBox3.Controls.Add(this.lb_autorun);
            this.groupBox3.Controls.Add(this.btn_stop_capture);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lb_facename_file);
            this.groupBox3.Controls.Add(this.imageBoxFrameGrabber);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 141);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1056, 375);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Yüz Algılama";
            // 
            // lb_autorun
            // 
            this.lb_autorun.AutoSize = true;
            this.lb_autorun.Location = new System.Drawing.Point(578, 20);
            this.lb_autorun.Name = "lb_autorun";
            this.lb_autorun.Size = new System.Drawing.Size(54, 17);
            this.lb_autorun.TabIndex = 16;
            this.lb_autorun.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(462, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Otomatik Başlat :";
            // 
            // lb_facename_file
            // 
            this.lb_facename_file.AutoSize = true;
            this.lb_facename_file.Location = new System.Drawing.Point(679, 18);
            this.lb_facename_file.Name = "lb_facename_file";
            this.lb_facename_file.Size = new System.Drawing.Size(156, 17);
            this.lb_facename_file.TabIndex = 14;
            this.lb_facename_file.Text = "Yüz Log Dosya Boyutu:";
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(7, 22);
            this.imageBoxFrameGrabber.Margin = new System.Windows.Forms.Padding(4);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(426, 346);
            this.imageBoxFrameGrabber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxFrameGrabber.TabIndex = 4;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 2000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.Color.Black;
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbLog.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLog.ForeColor = System.Drawing.Color.White;
            this.tbLog.Location = new System.Drawing.Point(0, 614);
            this.tbLog.Margin = new System.Windows.Forms.Padding(4);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(1056, 88);
            this.tbLog.TabIndex = 11;
            this.tbLog.TextChanged += new System.EventHandler(this.tbLog_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1056, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tanımlıYüzleriGörToolStripMenuItem,
            this.tanimliyuzlerisilmenu});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.fileToolStripMenuItem.Text = "Tanımlı Yüz İşlemleri";
            // 
            // tanımlıYüzleriGörToolStripMenuItem
            // 
            this.tanımlıYüzleriGörToolStripMenuItem.Name = "tanımlıYüzleriGörToolStripMenuItem";
            this.tanımlıYüzleriGörToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.tanımlıYüzleriGörToolStripMenuItem.Text = "Tanımlı Yüzleri Gör";
            this.tanımlıYüzleriGörToolStripMenuItem.Click += new System.EventHandler(this.tanımlıYüzleriGörToolStripMenuItem_Click);
            // 
            // tanimliyuzlerisilmenu
            // 
            this.tanimliyuzlerisilmenu.Name = "tanimliyuzlerisilmenu";
            this.tanimliyuzlerisilmenu.Size = new System.Drawing.Size(230, 24);
            this.tanimliyuzlerisilmenu.Text = "Tanımlanmış Yüzleri Sil";
            this.tanimliyuzlerisilmenu.Click += new System.EventHandler(this.deleteLearnedFacesToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewLogOfDetectedFacesToolStripMenuItem,
            this.tanımlanmışYüzLogKayıtlarınıSilToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.viewToolStripMenuItem.Text = "Log İşlemleri";
            // 
            // viewLogOfDetectedFacesToolStripMenuItem
            // 
            this.viewLogOfDetectedFacesToolStripMenuItem.Name = "viewLogOfDetectedFacesToolStripMenuItem";
            this.viewLogOfDetectedFacesToolStripMenuItem.Size = new System.Drawing.Size(308, 24);
            this.viewLogOfDetectedFacesToolStripMenuItem.Text = "Tanımlı Yüz Log Kayıtlarını Gör";
            this.viewLogOfDetectedFacesToolStripMenuItem.Click += new System.EventHandler(this.viewLogOfDetectedFacesToolStripMenuItem_Click);
            // 
            // tanımlanmışYüzLogKayıtlarınıSilToolStripMenuItem
            // 
            this.tanımlanmışYüzLogKayıtlarınıSilToolStripMenuItem.Name = "tanımlanmışYüzLogKayıtlarınıSilToolStripMenuItem";
            this.tanımlanmışYüzLogKayıtlarınıSilToolStripMenuItem.Size = new System.Drawing.Size(308, 24);
            this.tanımlanmışYüzLogKayıtlarınıSilToolStripMenuItem.Text = "Tanımlanmış Yüz Log Kayıtlarını Sil";
            this.tanımlanmışYüzLogKayıtlarınıSilToolStripMenuItem.Click += new System.EventHandler(this.tanımlanmışYüzLogKayıtlarınıSilToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kameraotomatikcalistirmaAyarla,
            this.kameraotomatikcalistirmaKapat,
            this.otomatikbaglantikur,
            this.otomatikbaglantikaldir});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.optionsToolStripMenuItem.Text = "Seçenekler";
            // 
            // kameraotomatikcalistirmaAyarla
            // 
            this.kameraotomatikcalistirmaAyarla.Name = "kameraotomatikcalistirmaAyarla";
            this.kameraotomatikcalistirmaAyarla.Size = new System.Drawing.Size(337, 24);
            this.kameraotomatikcalistirmaAyarla.Text = "Kamerayı Otomatik Çalıştırmaya Ayarla";
            this.kameraotomatikcalistirmaAyarla.Click += new System.EventHandler(this.kameraotomatikcalistirmaAyarla_Click);
            // 
            // kameraotomatikcalistirmaKapat
            // 
            this.kameraotomatikcalistirmaKapat.Name = "kameraotomatikcalistirmaKapat";
            this.kameraotomatikcalistirmaKapat.Size = new System.Drawing.Size(337, 24);
            this.kameraotomatikcalistirmaKapat.Text = "Kamera Otomatik Çalıştırmayı Kapat";
            this.kameraotomatikcalistirmaKapat.Click += new System.EventHandler(this.kameraotomatikcalistirmaKapat_Click);
            // 
            // otomatikbaglantikur
            // 
            this.otomatikbaglantikur.Name = "otomatikbaglantikur";
            this.otomatikbaglantikur.Size = new System.Drawing.Size(337, 24);
            this.otomatikbaglantikur.Text = "Otomatik Bağlantı Kur";
            this.otomatikbaglantikur.Click += new System.EventHandler(this.otomatikbaglantikur_Click);
            // 
            // otomatikbaglantikaldir
            // 
            this.otomatikbaglantikaldir.Name = "otomatikbaglantikaldir";
            this.otomatikbaglantikaldir.Size = new System.Drawing.Size(337, 24);
            this.otomatikbaglantikaldir.Text = "Otomatik Bağlantıyı Kaldır";
            this.otomatikbaglantikaldir.Click += new System.EventHandler(this.otomatikbaglantikaldir_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.aboutToolStripMenuItem.Text = "Yardım";
            // 
            // instructionsToolStripMenuItem
            // 
            this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.instructionsToolStripMenuItem.Text = "Açıklama";
            this.instructionsToolStripMenuItem.Click += new System.EventHandler(this.instructionsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(140, 24);
            this.aboutToolStripMenuItem1.Text = "Hakkında";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1056, 141);
            this.panel1.TabIndex = 10;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 702);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPrincipal";
            this.Text = "Yüz Tanıma Sistemi";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbCamIndex;
        private System.Windows.Forms.Button btn_stop_capture;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_facename_file;
        private System.Windows.Forms.Button btn_refresh_camerlist;
        private System.Windows.Forms.Label lb_autorun;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tanımlıYüzleriGörToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tanimliyuzlerisilmenu;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLogOfDetectedFacesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tanımlanmışYüzLogKayıtlarınıSilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kameraotomatikcalistirmaAyarla;
        private System.Windows.Forms.ToolStripMenuItem kameraotomatikcalistirmaKapat;
        private System.Windows.Forms.ToolStripMenuItem otomatikbaglantikur;
        private System.Windows.Forms.ToolStripMenuItem otomatikbaglantikaldir;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
    }
}

