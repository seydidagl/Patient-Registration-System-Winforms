using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Odev2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }
        


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://egehastane.ege.edu.tr/");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            foreach (TabPage page in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(page);
            }
        }

        private void btnHstn_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Contains(tabPageHsthne) == true)
            {
                tabControl1.SelectedTab = tabPageHsthne;
            }
            else
            {
                tabControl1.Visible = true;
                tabControl1.TabPages.Add(tabPageHsthne);
            }
        }

        private void btnHsta_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Contains(tabPageHsta) == true)
            {
                tabControl1.SelectedTab = tabPageHsta;
            }
            else
            {
                tabControl1.Visible = true;
                tabControl1.TabPages.Add(tabPageHsta);
            }
        }

        private void btnDktr_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Contains(tabPageDktr) == true)
            {
                tabControl1.SelectedTab = tabPageDktr;
            }
            else
            {
                tabControl1.Visible = true;
                tabControl1.TabPages.Add(tabPageDktr);
            }
        }

        private void btnRndv_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Contains(tabPageRndv) == true)
            {
                tabControl1.SelectedTab = tabPageRndv;
            }
            else
            {
                tabControl1.Visible = true;
                tabControl1.TabPages.Add(tabPageRndv);
            }
        }

        private void btnTshs_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Contains(tabPageTeshis) == true)
            {
                tabControl1.SelectedTab = tabPageTeshis;
            }
            else
            {
                tabControl1.Visible = true;
                tabControl1.TabPages.Add(tabPageTeshis);
            }
        }

        private void btnTst_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Contains(tabPageTest) == true)
            {
                tabControl1.SelectedTab = tabPageTest;
            }
            else
            {
                tabControl1.Visible = true;
                tabControl1.TabPages.Add(tabPageTest);
            }
        }

        private void tabPageHsthne_MouseClick(object sender, MouseEventArgs e)
        {
            if ( e.Button == MouseButtons.Right )
            {
                tabControl1.TabPages.Remove(tabPageHsthne);
            }
        }

        private void tabPageHsta_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tabControl1.TabPages.Remove(tabPageHsta);
            }
        }

        private void tabPageDktr_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tabControl1.TabPages.Remove(tabPageDktr);
            }
        }

        private void tabPageRndv_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tabControl1.TabPages.Remove(tabPageRndv);
            }
        }

        private void tabPageTeshis_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tabControl1.TabPages.Remove(tabPageTeshis);
            }
        }

        private void tabPageTest_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tabControl1.TabPages.Remove(tabPageTest);
            }
        }


        private void txtHstad_TextChanged(object sender, EventArgs e)
        {
            string ad = txtHstad.Text;
            txtHstamad.Text = ad;
        }

        private void txtHstsoyad_TextChanged(object sender, EventArgs e)
        {
            string soyad = txtHstsoyad.Text;
            txtHstamad.Text = $"{txtHstad.Text} {soyad}";
        }

        public class Doktor
        {
            public string DoktorIsm { get; set; }
            public string DoktorMail { get; set; }

            public string DoktorTel { get; set; }

            public string CalısmDurumu { get; set; }
        }
        public class Hastahane
        {
            public string HastahaneAd { get; set; }
            public string HastahaneSehir { get; set; }

            public string HastahaneTel { get; set; }

            public decimal HastahaneKapasite { get; set; }

        }
        public class Hasta
        {
            public string HastaAdSoyad { get; set; }
            public string HastaAdres { get; set; }
            
            public string HastaMail { get; set; }

            public string HastaTel { get; set; }

            public string HastaMeslek { get; set; }

            public string HastaCinsiyet { get; set; }



            // İsteğe bağlı olarak başka özellikler ekleyebilirsiniz
        }
        public class Randevu
        {
            public DateTime RandevuTime { get; set; } 
           
        }

        public class Teshis
        {
            public string Teshiss { get; set;}
        }
        private List<Hasta> Hastalar = new List<Hasta>();

        private List<Hastahane> Hastahaneler = new List<Hastahane>();

        private List<Doktor> Doktorlar = new List<Doktor>();

        public string Hastcinsiyet;

        public string calısma;

        private List<Randevu> Randevular = new List<Randevu>();

        private List<Teshis> Teshisler = new List<Teshis>();



        private void btnKydt_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageHsta)
            {
                if (rdbtnerkek.Checked)
                {
                    Hastcinsiyet = "erkek";
                }
                else if (rdbtnkadın.Checked)
                {
                    Hastcinsiyet = "kadın";
                }
                else
                {
                    Hastcinsiyet = "";
                }

                string adsoyad = txtHstamad.Text;
                string adres = txtHstadres.Text;
                string mail = txtHstMail.Text;
                string tel = txtHstaTel.Text;
                string meslek = cmboxMslk.Text;

                Hasta yenihasta = new Hasta
                {
                    HastaAdSoyad = adsoyad,
                    HastaAdres = adres,
                    HastaMail = mail,
                    HastaTel = tel,
                    HastaCinsiyet = Hastcinsiyet,
                    HastaMeslek = meslek,

                };

                Hastalar.Add(yenihasta);

                listBoxHsta.Items.Add($"{adsoyad} {adres} {mail} {tel} {Hastcinsiyet} {meslek} ");

                txtHstad.Clear();
                txtHstsoyad.Clear();
                txtHstamad.Clear();
                txtHstMail.Clear();
                txtHstaTel.Clear();
                

                comboBox1.Items.Add(adsoyad);
                comboBox2.Items.Add(adsoyad);
                comboBox3.Items.Add(adsoyad);


            }
            else if (tabControl1.SelectedTab == tabPageHsthne)
            {

                string hastaneisim = txtHstanisim.Text;
                string hastanetel = txtHstnTel.Text;
                string hastanesehir = comboBoxHstaSehir.Text;
                decimal kapasite = numericUpDownHstan.Value;

                Hastahane yenihastahane = new Hastahane
                {
                    HastahaneAd = hastaneisim,
                    HastahaneTel = hastanetel,
                    HastahaneKapasite = kapasite,
                    HastahaneSehir = hastanesehir,
                };

                Hastahaneler.Add(yenihastahane);

                listBoxHsthne.Items.Add($"{hastaneisim} {hastanesehir} {hastanetel} {kapasite} ");

                txtHstanisim.Clear();
                txtHstnTel.Clear();
                
                
            }
            else if (tabControl1.SelectedTab == tabPageDktr)
            {
                if (chckBoxDktr.Checked == true)
                {
                    calısma = "çalışıyor";
                }
                else
                {
                    calısma = "çalışmıyor";
                }
                string isim = txtDktrIsm.Text;
                string mail = txtDktrMail.Text;
                string tel = txtDktrTel.Text;
                
                

                Doktor yenidoktor = new Doktor
                {
                    DoktorIsm = isim,
                    DoktorMail = mail,
                    DoktorTel = tel,
                    CalısmDurumu = calısma,
                };

                Doktorlar.Add(yenidoktor);

                listBoxDktr.Items.Add($"{isim} {mail} {tel} {calısma} ");

                txtDktrIsm.Clear();
                txtDktrMail.Clear();
                txtDktrTel.Clear();


            }
            else if (tabControl1.SelectedTab == tabPageRndv)
            {

                string adsoyad = comboBox1.Text;
                string randevudate = dateTimePickerRandevu.Text;

                Randevu yenirandevu = new Randevu
                {
                     

                };

            }
            else if (tabControl1.SelectedTab == tabPageTeshis)
            {

              

            }
            else
            {

                

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Dialog penceresinde görünen başlık
            openFileDialog.Title = "Fotoğraf Seç";

            // İzin verilen dosya türleri (örneğin, sadece resim dosyaları)
            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif|Tüm Dosyalar|*.*";

            // Varsa varsayılan olarak seçilecek dosya türü
            openFileDialog.FilterIndex = 1;

            // Dialog penceresinde "Aç" düğmesine tıklandığında
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Seçilen resmin yolunu al
                    string selectedImagePath = openFileDialog.FileName;

                    // Seçilen resmi PictureBox kontrolüne yükle
                    pictureBox1.Image = new System.Drawing.Bitmap(selectedImagePath);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }

        }

        private void btnSc_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageHsta) 
            {
                int selectedIndex = listBoxHsta.SelectedIndex;

                if (selectedIndex != -1)
                {

                    Hasta yenihasta = Hastalar[selectedIndex];


                    txtHstad.Text = yenihasta.HastaAdSoyad;
                    txtHstamad.Text = yenihasta.HastaAdSoyad;
                    txtHstsoyad.Text = yenihasta.HastaAdSoyad;
                    txtHstadres.Text = yenihasta.HastaAdres;
                    txtHstMail.Text = yenihasta.HastaMail;
                    txtHstaTel.Text = yenihasta.HastaTel;



                }
            }


            else if (tabControl1.SelectedTab == tabPageHsthne)
            {

                int selectedIndex = listBoxHsthne.SelectedIndex;


                if (selectedIndex != -1)
                {

                    Hastahane yenihastane = Hastahaneler[selectedIndex];

                    txtHstanisim.Text = yenihastane.HastahaneAd;
                    txtHstnTel.Text = yenihastane.HastahaneTel;
                    comboBoxHstaSehir.Text = yenihastane.HastahaneSehir;
                    numericUpDownHstan.Value = yenihastane.HastahaneKapasite;

                    



                }
            }

            else if (tabControl1.SelectedTab == tabPageDktr) 
            {

                int selectedIndex = listBoxDktr.SelectedIndex;


                if (selectedIndex != -1)
                {

                    Doktor yenidoktor = Doktorlar[selectedIndex];


                    txtDktrIsm.Text = yenidoktor.DoktorIsm;
                    txtDktrMail.Text = yenidoktor.DoktorMail;
                    txtDktrTel.Text = yenidoktor.DoktorTel;
                    if (calısma == "çalışıyor") 
                    {
                        chckBoxDktr.Checked = true;
                    }
                    else
                    {
                        chckBoxDktr.Checked = false;
                    }
                   


                }
            }


            else if (tabControl1.SelectedTab == tabPageRndv)
            {

                // ListBox'ta bir öğe seçildiğinde bu metod çağrılır

                // Seçilen öğenin indeksini al
                int selectedIndex = listBoxRndv.SelectedIndex;

                // Eğer bir öğe seçilmişse
                if (selectedIndex != -1)
                {
                    // Seçilen kişiyi al
                    Hasta yenihasta = Hastalar[selectedIndex];

                    // TextBox'ları seçilen kişinin bilgileri ile doldur
                    txtHstad.Text = yenihasta.HastaAdSoyad;
                    txtHstamad.Text = yenihasta.HastaAdSoyad;
                    txtHstsoyad.Text = yenihasta.HastaAdSoyad;
                    txtHstadres.Text = yenihasta.HastaAdres;
                    txtHstMail.Text = yenihasta.HastaMail;
                    txtHstaTel.Text = yenihasta.HastaTel;



                }

            }
            else if (tabControl1.SelectedTab == tabPageTeshis)
            {

                // ListBox'ta bir öğe seçildiğinde bu metod çağrılır

                // Seçilen öğenin indeksini al
                int selectedIndex = listBoxHsta.SelectedIndex;

                // Eğer bir öğe seçilmişse
                if (selectedIndex != -1)
                {
                    // Seçilen kişiyi al
                    Hasta yenihasta = Hastalar[selectedIndex];

                    // TextBox'ları seçilen kişinin bilgileri ile doldur
                    txtHstad.Text = yenihasta.HastaAdSoyad;
                    txtHstamad.Text = yenihasta.HastaAdSoyad;
                    txtHstsoyad.Text = yenihasta.HastaAdSoyad;
                    txtHstadres.Text = yenihasta.HastaAdres;
                    txtHstMail.Text = yenihasta.HastaMail;
                    txtHstaTel.Text = yenihasta.HastaTel;



                }

            }
            else
            {

                // ListBox'ta bir öğe seçildiğinde bu metod çağrılır

                // Seçilen öğenin indeksini al
                int selectedIndex = listBoxHsta.SelectedIndex;

                // Eğer bir öğe seçilmişse
                if (selectedIndex != -1)
                {
                    // Seçilen kişiyi al
                    Hasta yenihasta = Hastalar[selectedIndex];

                    // TextBox'ları seçilen kişinin bilgileri ile doldur
                    txtHstad.Text = yenihasta.HastaAdSoyad;
                    txtHstamad.Text = yenihasta.HastaAdSoyad;
                    txtHstsoyad.Text = yenihasta.HastaAdSoyad;
                    txtHstadres.Text = yenihasta.HastaAdres;
                    txtHstMail.Text = yenihasta.HastaMail;
                    txtHstaTel.Text = yenihasta.HastaTel;



                }

            }

        }

        private void btnGncll_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageHsta)
            {

            }


            else if (tabControl1.SelectedTab == tabPageHsthne)
            {

            }

            else if (tabControl1.SelectedTab == tabPageDktr)
            {

            }


            else if (tabControl1.SelectedTab == tabPageRndv)
            {



            }
            else if (tabControl1.SelectedTab == tabPageTeshis)
            {



            }
            else
            {



            }

        }

        private void btnSl_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageHsta)
            {

            }


            else if (tabControl1.SelectedTab == tabPageHsthne)
            {

            }

            else if (tabControl1.SelectedTab == tabPageDktr)
            {

            }


            else if (tabControl1.SelectedTab == tabPageRndv)
            {



            }
            else if (tabControl1.SelectedTab == tabPageTeshis)
            {



            }
            else
            {



            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
        