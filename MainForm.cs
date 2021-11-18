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
            //Installing haarcascade for Face Detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
           // eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                //Labeling previously learned faces for each image
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
            //set camera to select in combobox       
            //Starting Image Capture.
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
                //Trained face counter
                sayac = sayac + 1;

                //Turn captured image gray
                gri = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Face Detector
                MCvAvgComp[][] yuz_Algilama = gri.DetectHaarCascade(
                face,
                1.1,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));

                //Capturing different faces.
                foreach (MCvAvgComp f in yuz_Algilama[0])
                {
                    egitimliYuz = gecerliKare.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }

                // Resize image when face is detected to compare image with same size by cubic force interpolation type method.
                egitimliYuz = sonucResim.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                egitimliResimler.Add(egitimliYuz);
                etiketler.Add(textBox1.Text);

                //Showing gray
                imageBox1.Image = egitimliYuz;

                //Enumerate trained faces in a text file
                File.WriteAllText(Application.StartupPath + "/EgitilmisYuzler/EgitilmisEtiketler.txt", egitimliResimler.ToArray().Length.ToString() + "%");

                //labels of trained faces in text file
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

            //Getting the current frame from the capture device
            gecerliKare = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Gri Seviyeye Çevirme
            gri = gecerliKare.Convert<Gray, Byte>();

            //Face detector
            MCvAvgComp[][] yuz_Algilama = gri.DetectHaarCascade(
          face,
          1.2,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));

            //Detecting different faces
            foreach (MCvAvgComp f in yuz_Algilama[0])
            {
                t = t + 1;
                sonucResim = gecerliKare.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //drawing face with 0th (grey) channel detected with blue color
                gecerliKare.Draw(f.rect, new Bgr(Color.Red), 2);


                if (egitimliResimler.ToArray().Length != 0)
                {
                    //Face recognition (termCriteria) with numbers of trained images such as Maximum Iteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(sayac, 0.001);

                    //Eigen face recognizer
                    EigenObjectRecognizer taniyici = new EigenObjectRecognizer(
                       egitimliResimler.ToArray(),
                       etiketler.ToArray(),
                       3000,
                       ref termCrit);

                    isim = taniyici.Recognize(sonucResim);
                   // richTextBox1.Text += label4.Text+"  'yüzü tanındı." + "  " + DateTime.Today + "  " + DateTime.Now.ToLongTimeString() + Environment.NewLine;

                    //Drawing labels for each detected face
                    gecerliKare.Draw(isim, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));

                    
                }

                KisiAdlari[t - 1] = isim;
                KisiAdlari.Add("");


                //determining the number of faces detected in the scene
                label3.Text = yuz_Algilama[0].Length.ToString();
            }
            t = 0;

            //combining the names of well-known people
            for (int nnn = 0; nnn < yuz_Algilama[0].Length; nnn++)
            {
                isimler = isimler + KisiAdlari[nnn] + ", ";
            }
            //Show rendered and recognized faces
            imageBoxFrameGrabber.Image = gecerliKare;
            label4.Text = isimler;
            isimler = "";
            //Clear Name List
            KisiAdlari.Clear();

            if (String.IsNullOrEmpty(isimler))
            {
                return;
            }
            else
            {
                File.AppendAllText(Application.StartupPath + "/RecognitionLog/facelog.txt",
                         isimler + DateTime.Now.ToString() + Environment.NewLine);
            }

            //
            //automatically sends its name - Can be enabled or disabled.
            //
            tbLog.Text = "\"" + isimler + "\"";
            
           
            isimler = "";
            //Clear Name Lis
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
            imageBoxFrameGrabber.Image = null;  //The face frame (square) in the ImageBox is cleared.
            imageBox1.Image = null; // The ImageBox is made empty.
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
            if (File.Exists(Application.StartupPath + "/RecognitionLog/facelog.txt")) //The path to the folder where the log records are kept in bin-debug and txt
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

                if (boyut > 1000000) //If the file is larger than 1 mb it will be deleted
                {
                    File.Delete(Application.StartupPath + "/RecognitionLog/facelog.txt");
                }
            }
        }

        private void cbCamIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-> selected item from combobox
             KeyValuePair<int, string> SelectedItem = (KeyValuePair<int, string>)cbCamIndex.SelectedItem;
            //-> The selected camera is assigned to the specified variable.
            KameraIndex = SelectedItem.Key;
        }

        private void btn_refresh_camerlist_Click(object sender, EventArgs e)
        {
            //-> Keeping cameras listed in Combobox
            List<KeyValuePair<int, string>> ListCamerasData = new List<KeyValuePair<int, string>>();
            //-> Finding system cameras with DirectShow.Net dll
            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            int _DeviceIndex = 0;
            foreach (DirectShowLib.DsDevice _Camera in _SystemCamereas)
            {
                ListCamerasData.Add(new KeyValuePair<int, string>(_DeviceIndex, _Camera.Name));
                _DeviceIndex++;
            }
            //-> clear combobox
                cbCamIndex.DataSource = null;
                cbCamIndex.Items.Clear();
            //-> upload combobox
                cbCamIndex.DataSource = new BindingSource(ListCamerasData, null);
                cbCamIndex.DisplayMember = "Value";
                cbCamIndex.ValueMember = "Key";
            //DirectShowLib-2005 must be added as a reference in the bin folder
        }
        private void kameraotomatikcalistirmaKapat_Click(object sender, EventArgs e)
        {
            // Turn off camera autorun - performs the menu operation.
            CamAuto = false;
            lb_autorun.Text = "Pasif";
            MessageBox.Show("Unutmayın, tüm kullanıcı ayarlarının doğru değerlere sahip olduğundan emin olun. - Daha sonra Dosya/Kullanıcı Ayarlarını Kaydet yolunu takip edin.", "Yüz Tanıma", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
       
        private void kameraotomatikcalistirmaAyarla_Click(object sender, EventArgs e)
        {
            //Turn on camera autorun - performs the menu operation.
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
