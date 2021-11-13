using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KahveDukkani_Sinav
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] kahveler = {"Misto","Americano","Bianco","Cappucino","Macchiato","Con Panna","Mocha" };
        double[] kahveFiyatlari = { 4.5, 5.75, 6, 7.5, 6.75, 8, 7.75 };
        string[] sogukIcecekler= {"Ice Tea","Cola","Fanta","Sprite" };
        string[] sicakIcecekler = { "Çay", "Hot Chocolate", "Chai Tea Latte" };
        double[] sicakIcecekFiyatlari = { 3, 4.5, 6.5 };
        string[] siparisler = new string[0];
        
        

        double toplamTutar=0;
        int toplamUrun = 0;
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            KahveHesapla();
            sogukIcecekHesapla();

            SicakIcecekHesapla();
            lblSiparisTutari.Text = toplamTutar.ToString();
            SiparisDoldur();
        }
        void KahveHesapla()
        {
            double kahveSiparis = 0;

            if (cmbKahveler.SelectedIndex > -1 && nudKahveler.Value != 0)
            {
                toplamUrun += (int)nudKahveler.Value;
                double shot = 0;
                double kahveBoyu = 1;
                double sut = 0;
                string boy = "Tall";
                string sutsecim = "";
                string shotsecim = "";
                if (rdSoya.Checked)
                {
                    sut += 0.5;
                    sutsecim = "Soya";
                }
                else if (rdYagsiz.Checked)
                {
                    sut += 0.5;
                    sutsecim = "Yağsız";

                }
                else
                {
                    sutsecim = "Normal";
                }

                if (cbShot1.Checked && cbShot2.Checked)
                {
                    shot = 2.25;
                    shotsecim = "x3 Shot";
                }
                else if (cbShot1.Checked)
                {
                    shot = 0.75;
                    shotsecim = "x1 Shot";
                }
                else if (cbShot2.Checked)
                {
                    shot = 1.5;
                    shotsecim = "x2 Shot";
                }
                else
                {
                    shotsecim = "Shotsız";
                }

                if (rdGrande.Checked)
                {
                    kahveBoyu = 1.25;
                    boy = "Grande";
                }
                else if (rdTall.Checked)
                {
                    kahveBoyu = 1;
                    boy = "Tall";
                }
                else if (rdVenti.Checked)
                {
                    kahveBoyu = 1.75;
                    boy = "Venti";
                }
                int kahveIndex = Array.IndexOf(kahveler, cmbKahveler.SelectedItem);
                kahveSiparis = (kahveFiyatlari[kahveIndex] * (double)nudKahveler.Value * kahveBoyu) + shot + sut;
                Array.Resize(ref siparisler, siparisler.Length + 1);
                siparisler[siparisler.Length - 1] = boy + "," + kahveler[kahveIndex] + "," + shotsecim + "," + sutsecim + ": " + kahveSiparis + "TL";

            }
            toplamTutar += kahveSiparis;

        }
        void SicakIcecekHesapla()
        {
            double sicakSiparis = 0;

            if (cmbSicakIcecekler.SelectedIndex > -1 && nudSicakIcecekler.Value != 0)
            {
                toplamUrun += (int)nudSicakIcecekler.Value;
                int sicakIceceklerIndex = Array.IndexOf(sicakIcecekler, cmbSicakIcecekler.SelectedItem);
                sicakSiparis = sicakIcecekFiyatlari[sicakIceceklerIndex] * (double)nudSicakIcecekler.Value;
                Array.Resize(ref siparisler, siparisler.Length + 1);
                siparisler[siparisler.Length - 1] = sicakIcecekler[sicakIceceklerIndex] + ": " + sicakSiparis + "TL";


            }
            toplamTutar += sicakSiparis;
        }
        void sogukIcecekHesapla()
        {
            double sogukSiparis = 0;
            if (cmbSogukIcecekler.SelectedIndex > -1 && nudSogukIcecekler.Value != 0)
            {
                toplamUrun += (int)nudSogukIcecekler.Value;
                sogukSiparis = 5.5 * (double)nudSogukIcecekler.Value;
                Array.Resize(ref siparisler, siparisler.Length + 1);
                siparisler[siparisler.Length - 1] = cmbSogukIcecekler.SelectedItem + ": " + sogukSiparis + "TL";
            }
            toplamTutar += sogukSiparis;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ControlDoldur();
        }
        void ControlDoldur()
        {
            foreach (var item in kahveler)
            {
                cmbKahveler.Items.Add(item);
            }
            foreach (var item in sogukIcecekler)
            {
                cmbSogukIcecekler.Items.Add(item);
            }
            foreach (var item in sicakIcecekler)
            {
                cmbSicakIcecekler.Items.Add(item);
            }
        }
        void SiparisDoldur()
        {
            lsbSiparis.Items.Clear();
            foreach (var item in siparisler)
            {
                lsbSiparis.Items.Add(item);
            }
        }

        private void btnSiparisVer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("toplam "+toplamUrun+" adet ürününüz "+toplamTutar+"TL tutarındadır.");
        }
    }
}
