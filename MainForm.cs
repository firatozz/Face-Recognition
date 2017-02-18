using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using System.Media;
using System.Net.Sockets;
using DirectShowLib;
using System.IO.Ports;


namespace YuzTanima
{
    public partial class FrmPrincipal : Form
    {
        //Tüm değişkenler, vektörler ve haarcascade burada tanımlanıyor
        Image<Bgr, Byte> gecerliKare;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> sonucResim, egitimliYuz = null;
        Image<Gray, byte> gri = null;
        List<Image<Gray, byte>> egitimliResimler = new List<Image<Gray, byte>>();
        List<string> etiketler= new List<string>();
        List<string> KisiAdlari = new List<string>(); 
        int sayac, NumEtikets, t;      //Kaydedilen resimleri numarandırmak ve isimlendirmek için değişken
        string isim, isimler = null;

        bool Yaklamaİslemi = false;
        bool CapRunning = false;
        private int KameraIndex;
        bool CamAuto = false;
        bool ConnectAuto = false;
        string versiyon = "1.0.0";

        public FrmPrincipal()
        {
            
  
            InitializeComponent();
            //Yüz Algılama için haarcascade yükleme
            face = new HaarCascade("haarcascade_frontalface_default.xml");
           // eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                //Her resim için bir önceki öğrenilmiş yüzleri etiketleme 
                string isimEtiketBilgi = File.ReadAllText(Application.StartupPath + "/EgitilmisYuzler/EgitilmisEtiketler.txt");
                string[] isimEtiketleri = isimEtiketBilgi.Split('%');
                NumEtikets = Convert.ToInt16(isimEtiketleri[0]);
                sayac = NumEtikets;
                string YukluYuzler;

                for (int tf = 1; tf < NumEtikets+1; tf++)
                {
                    YukluYuzler = "face" + tf + ".bmp";
                    egitimliResimler.Add(new Image<Gray, byte>(Application.StartupPath + "/EgitilmisYuzler/" + YukluYuzler));
                    etiketler.Add(isimEtiketleri[tf]);
                }
            }
            catch(Exception e)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("Sistemde yüz bulunamadı.Lütfen uygulamayı başlatın ve bir yüz ekleyin.Zaten başlattıysanız bir yüzün algılanmasını bekleyin.", "Yüz Tanıma", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //combobox ta seçilecek kamerayı ayarla        
            //Görüntü Yakalama Başlatılıyor.
            grabber = new Capture(KameraIndex);
            grabber.QueryFrame();
            //FrameGraber(yüz yakalama) olayı başlatılıyor.
            Application.Idle += new EventHandler(FrameGrabber);
            button1.Enabled = false;
            Yaklamaİslemi = true;
            btn_stop_capture.Enabled = true;
            groupBox1.Enabled = true;
            CapRunning = true;

        }


        private void button2_Click(object sender, System.EventArgs e)
        {
            try
            {
                //Eğitimli yüz sayacı
                sayac = sayac + 1;

                //Yakalanan resmi griye çevirme
                gri = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Yüz Algılayıcı
                MCvAvgComp[][] yuz_Algilama = gri.DetectHaarCascade(
                face,
                1.1,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));

                //Farklı yüzleri yakalama.
                foreach (MCvAvgComp f in yuz_Algilama[0])
                {
                    egitimliYuz = gecerliKare.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }

                // kübik kuvvet interpolasyon tipi yöntemi ile görüntüyü aynı boyutla karşılaştırmak için yüz algılandığında 
                //görüntüyü yeniden boyutlandırma.
                egitimliYuz = sonucResim.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                egitimliResimler.Add(egitimliYuz);
                etiketler.Add(textBox1.Text);

                //Gri resmi gösterme
                imageBox1.Image = egitimliYuz;

                //Eğitilmiş yüzleri text dosyasında numaralandırma
                File.WriteAllText(Application.StartupPath + "/EgitilmisYuzler/EgitilmisEtiketler.txt", egitimliResimler.ToArray().Length.ToString() + "%");

                //Eğitilmiş yüzleri text dosyasında etiketlerini yazdırma
                for (int i = 1; i < egitimliResimler.ToArray().Length + 1; i++)
                {
                    egitimliResimler.ToArray()[i - 1].Save(Application.StartupPath + "/EgitilmisYuzler/face" + i + ".bmp");
                    File.AppendAllText(Application.StartupPath + "/EgitilmisYuzler/EgitilmisEtiketler.txt", etiketler.ToArray()[i - 1] + "%");
                }

                MessageBox.Show(textBox1.Text + "´'in yüzü algılandı ve eklendi.", "Eğitim OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("İlk Olarak Yüz Tanımayı Etkinleştirin.", "Eğitim Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        void FrameGrabber(object sender, EventArgs e)
        {
            label3.Text = "0";
            //label4.Text = "";
            KisiAdlari.Add("");

            //Uygulamada en sık hatalarla karşılaşılan kısım
            //Yakalama aygıtından geçerli kareyi alma
            gecerliKare = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Gri Seviyeye Çevirme
            gri = gecerliKare.Convert<Gray, Byte>();

            //Yüz Algılayıcı
            MCvAvgComp[][] yuz_Algilama = gri.DetectHaarCascade(
          face,
          1.2,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));

            //Farklı yüzleri algılama
            foreach (MCvAvgComp f in yuz_Algilama[0])
            {
                t = t + 1;
                sonucResim = gecerliKare.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //mavi renk ile 0. (gri) kanal tespit edilen yüzü çizme
                gecerliKare.Draw(f.rect, new Bgr(Color.Red), 2);


                if (egitimliResimler.ToArray().Length != 0)
                {
                    //Maksimum İterasyon gibi eğitilmiş görüntülerin numaraları ile yüz tanıma (termCritaria)
                    MCvTermCriteria termCrit = new MCvTermCriteria(sayac, 0.001);

                    //Eigen yüz tanıyıcı
                    EigenObjectRecognizer taniyici = new EigenObjectRecognizer(
                       egitimliResimler.ToArray(),
                       etiketler.ToArray(),
                       3000,
                       ref termCrit);

                    isim = taniyici.Recognize(sonucResim);
                   // richTextBox1.Text += label4.Text+"  'yüzü tanındı." + "  " + DateTime.Today + "  " + DateTime.Now.ToLongTimeString() + Environment.NewLine;

                    //Her algılanan yüz için etiket çizme
                    gecerliKare.Draw(isim, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));

                    
                }

                KisiAdlari[t - 1] = isim;
                KisiAdlari.Add("");


                //sahnede algılanan yüzlerin sayısını belirleme
                label3.Text = yuz_Algilama[0].Length.ToString();

                /*
                       //yüzündeki ilgili bölgeyi ayarlayın
                        
                       gray.ROI = f.rect;
                       MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                          eye,
                          1.1,
                          10,
                          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                          new Size(20, 20));
                       gray.ROI = Rectangle.Empty;

                       foreach (MCvAvgComp ey in eyesDetected[0])
                       {
                           Rectangle eyeRect = ey.rect;
                           eyeRect.Offset(f.rect.X, f.rect.Y);
                           currentFrame.Draw(eyeRect, new Bgr(Color.Blue), 2);
                       }
                        */
            }
            t = 0;

            //tanınan kişilerin isimlerini birleştirme 
            for (int nnn = 0; nnn < yuz_Algilama[0].Length; nnn++)
            {
                isimler = isimler + KisiAdlari[nnn] + ", ";
            }
            //İşlenmiş ve tanınmış yüzleri göster
            imageBoxFrameGrabber.Image = gecerliKare;
            label4.Text = isimler;
            isimler = "";
            //İsimler Listesini Temizle
            KisiAdlari.Clear();

            if (String.IsNullOrEmpty(isimler))
            {
                //hiçbirşey
            }
            else
            {
                File.AppendAllText(Application.StartupPath + "/RecognitionLog/facelog.txt",
                         isimler + DateTime.Now.ToString() + Environment.NewLine);
            }

            //
            //otomatik olarak adını gönderir - Etkin veya devredışı olabilir.
            //
            tbLog.Text = "\"" + isimler + "\"";
            
            //btngetX.PerformClick(); 
            //tanıma duruncaya kadar sadece çalışır - EZ-Builder bilgi alır
            //Bir sonraki yüz tanınması için isim değerini temizler
            isimler = "";
            //İsimler Listesini temizler
            KisiAdlari.Clear();
            
          
           
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            this.Text = "Yüz Tanıma Sistemi " + versiyon;
            if (File.Exists(Application.StartupPath + "/RecognitionLog/facelog.txt"))
            {
                var fileName = (Application.StartupPath + "/RecognitionLog/facelog.txt");
                FileInfo fi = new FileInfo(fileName);
                var size = fi.Length;
                lb_facename_file.Text = "Yüz Log Dosya Boyutu:          " + size;
            }
            if (CamAuto == true)
            {
                lb_autorun.Text = "Etkin";
                button1.PerformClick();
            }
            else
            {
                lb_autorun.Text = "Pasif";
            }
        }

        private void Log(object txt, params object[] vals)
        {
            tbLog.AppendText(string.Format(txt.ToString(), vals));
            tbLog.AppendText(Environment.NewLine);
        }

 
        private void btnSetX_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_stop_capture_Click(object sender, EventArgs e)
        {
            {
                if (Yaklamaİslemi == true)
                {
                    Application.Idle -= FrameGrabber;
                    grabber.Dispose();
                }
                else
                {
                    Application.Idle += FrameGrabber;
                }
            } 
            button1.Enabled = true;
            btn_stop_capture.Enabled = false;
            groupBox1.Enabled = false;
            imageBoxFrameGrabber.Image = null;  //ImageBox daki yüz çerçevesi (kare) temizlenir.
            imageBox1.Image = null; // ImageBox boş hale getirilir.
        }



        private void deleteLearnedFacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Tüm Eğitilmiş Yüzleri Silmek İstediğinize Emin Misin?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (d == DialogResult.Yes)
                {
                    
                    if (CapRunning = true)
                    {
                        btn_stop_capture.PerformClick();
                    }
                    Array.ForEach(Directory.GetFiles(Application.StartupPath + "/EgitilmisYuzler"), File.Delete);
                        button1.Enabled = false;
                        DialogResult b = MessageBox.Show("Değişikliklerin Etkin Olması İçin Programı Kapatıp Yeniden Başlatmalısınız. ", "Yüz Tanıma Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            if (b == DialogResult.OK)
                            {
                                Application.Exit();
                            }
                }
                else if (d == DialogResult.No)
                {
                    // Hiç birşey yapma.
                }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var hakkinda = new hakkinda();
            hakkinda.revision = versiyon;
            hakkinda.Show();
        }

        

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\veriyolu\ReadMe.txt"))   // Beni Oku Dosyasını Açmak için
            {
                System.Diagnostics.Process.Start(@"C:\veri yolu\ReadMe.txt"); // Yazılacak txt dosyasının yolu belirtilecek.
            }
            else
            {
                MessageBox.Show("Oopss HATA. BeniOku.txt dosyası bulunamadı.", "Yüz Tanıma", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            
        }

       

        

        private void viewLogOfDetectedFacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/RecognitionLog/facelog.txt")) //bin-debug içinde log kayıtlarının tutuldugu klasör yolu ve txt
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "/RecognitionLog/facelog.txt");
            }
            else
            {
                MessageBox.Show("Oopss HATA. facelog.txt dosyası bulunamadı", "Yüz Tanıma", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/RecognitionLog/facelog.txt"))
            {
                var dosya_adi = (Application.StartupPath + "/RecognitionLog/facelog.txt");
                FileInfo fi = new FileInfo(dosya_adi);
                var boyut = fi.Length;
                lb_facename_file.Text = "Face Log File size:          " + boyut;

                if (boyut > 1000000) //Dosya 1 mb'dan büyük  ise silinecektir
                {
                    File.Delete(Application.StartupPath + "/RecognitionLog/facelog.txt");
                }
            }
        }

        private void cbCamIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-> combobox'tan seçili öğeyi alır
             KeyValuePair<int, string> SelectedItem = (KeyValuePair<int, string>)cbCamIndex.SelectedItem;
            //-> Seçilen kamera belirtilen değişkene atanır.
            KameraIndex = SelectedItem.Key;
        }

        private void btn_refresh_camerlist_Click(object sender, EventArgs e)
        {
            //-> Combobox'ta kameraları liste halinde tutma
            List<KeyValuePair<int, string>> ListCamerasData = new List<KeyValuePair<int, string>>();
            //-> Sistem kameralarını  DirectShow.Net dll  ile bulma
            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            int _DeviceIndex = 0;
            foreach (DirectShowLib.DsDevice _Camera in _SystemCamereas)
            {
                ListCamerasData.Add(new KeyValuePair<int, string>(_DeviceIndex, _Camera.Name));
                _DeviceIndex++;
            }
            //-> combobox  temizleme
                cbCamIndex.DataSource = null;
                cbCamIndex.Items.Clear();
            //-> combobox yükleme
                cbCamIndex.DataSource = new BindingSource(ListCamerasData, null);
                cbCamIndex.DisplayMember = "Value";
                cbCamIndex.ValueMember = "Key";
            //DirectShowLib-2005 must be added as a reference in the bin folder
        }
        private void kameraotomatikcalistirmaKapat_Click(object sender, EventArgs e)
        {
            // Kamera otomatik çalıştırmayı kapat - menü işlemini gerçekleştirir.
            CamAuto = false;
            lb_autorun.Text = "Pasif";
            MessageBox.Show("Unutmayın, tüm kullanıcı ayarlarının doğru değerlere sahip olduğundan emin olun. - Daha sonra Dosya/Kullanıcı Ayarlarını Kaydet yolunu takip edin.", "Yüz Tanıma", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
       
        private void kameraotomatikcalistirmaAyarla_Click(object sender, EventArgs e)
        {
            //Kamerayı otomatik çalıştırmaya ayarla - mennü işlemini  gerçeklştirir.
            CamAuto = true;
            lb_autorun.Text = "Etkin";
            MessageBox.Show("Unutmayın, tüm kullanıcı ayarlarının doğru değerlere sahip olduğundan emin olun. - Daha sonra Dosya/Kullanıcı Ayarlarını Kaydet yolunu takip edin.", "Yüz Tanıma", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void otomatikbaglantikur_Click(object sender, EventArgs e)
        {
           
        }
        private void otomatikbaglantikaldir_Click(object sender, EventArgs e)
        {
            
        }
       
        private void btngetX_Click(object sender, EventArgs e)
        {
           
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }

        private void tbLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void tanımlıYüzleriGörToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + "/EgitilmisYuzler");
        }

        private void tanımlanmışYüzLogKayıtlarınıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("facelog.txt dosyasını silmek istediğinize emin misiniz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (f == DialogResult.Yes)
            {
                if (File.Exists(Application.StartupPath + "/RecognitionLog/facelog.txt"))
                {
                    File.Delete(Application.StartupPath + "/RecognitionLog/facelog.txt");
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

        }

        
      
   }
}