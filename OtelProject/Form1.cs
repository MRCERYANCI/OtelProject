using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnDurumTanimlamalari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmDurum frmDurum = new Formlar.Tanımlamalar.FrmDurum();
            frmDurum.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmBirim frmBirim = new Formlar.Tanımlamalar.FrmBirim();
            frmBirim.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmDepartman frmDepartman = new Formlar.Tanımlamalar.FrmDepartman();
            frmDepartman.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmGorevTanimlamalari frmGorevTanimlamalari = new Formlar.Tanımlamalar.FrmGorevTanimlamalari();
            frmGorevTanimlamalari.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmKasa frmKasa = new Formlar.Tanımlamalar.FrmKasa();
            frmKasa.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmKur frmKur = new Formlar.Tanımlamalar.FrmKur();
            frmKur.ShowDialog();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmOda frmOda = new Formlar.Tanımlamalar.FrmOda();
            frmOda.ShowDialog();
        }
        
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmTelefon frmTelefon = new Formlar.Tanımlamalar.FrmTelefon();
            frmTelefon.ShowDialog();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmUlke frmUlke  = new Formlar.Tanımlamalar.FrmUlke();
            frmUlke.ShowDialog();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmUrunGrup frmUrunGrup = new Formlar.Tanımlamalar.FrmUrunGrup();
            frmUrunGrup.ShowDialog();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Personel.FrmPersonelKart frmPersonelKart = new Formlar.Personel.FrmPersonelKart();
            frmPersonelKart.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Personel.FrmPersonelList frmPersonelList = new Formlar.Personel.FrmPersonelList();
            frmPersonelList.MdiParent = this;
            frmPersonelList.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Misafir.FrmMisafirKarti frmMisafirKarti = new Formlar.Misafir.FrmMisafirKarti();
            frmMisafirKarti.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Misafir.FrmMisafirListesi frmMisafirListesi = new Formlar.Misafir.FrmMisafirListesi();
            frmMisafirListesi.MdiParent = this;
            frmMisafirListesi.Show();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Urun.FrmUrunListesi frmUrunListesi = new Formlar.Urun.FrmUrunListesi();
            frmUrunListesi.MdiParent = this;
            frmUrunListesi.Show();
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Urun.FrmUrunKarti frmUrunKarti = new Formlar.Urun.FrmUrunKarti();
            frmUrunKarti.Show();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Urun.FrmUrunGirisHareketleri frmUrunGirisHareketleri = new Formlar.Urun.FrmUrunGirisHareketleri();
            frmUrunGirisHareketleri.MdiParent = this;
            frmUrunGirisHareketleri.Show();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Urun.FrmUrunCikisHareketleri frmUrunCikisHareketleri = new Formlar.Urun.FrmUrunCikisHareketleri();
            frmUrunCikisHareketleri.MdiParent = this;
            frmUrunCikisHareketleri.Show();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Urun.FrmUrunHareketTanimi frmUrunHareketTanimi = new Formlar.Urun.FrmUrunHareketTanimi();
            frmUrunHareketTanimi.Show();
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Araclar.FrmYouTube frmYouTube = new Formlar.Araclar.FrmYouTube();
            frmYouTube.MdiParent = this;
            frmYouTube.Show();
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Araclar.FrmGoogle frmGoogle = new Formlar.Araclar.FrmGoogle();
            frmGoogle.MdiParent = this;
            frmGoogle.Show();
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("winword");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("excel");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Araclar.FrmKur frmKur = new Formlar.Araclar.FrmKur();
            frmKur.MdiParent = this;
            frmKur.Show();
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Rezervasyon.FrmRezervasyonKart frmRezervasyonKart = new Formlar.Rezervasyon.FrmRezervasyonKart();
            frmRezervasyonKart.Show();
        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Rezervasyon.FrmRezervasyonListesi frmRezervasyonListesi = new Formlar.Rezervasyon.FrmRezervasyonListesi();
            frmRezervasyonListesi.MdiParent = this;
            frmRezervasyonListesi.Show();
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Rezervasyon.FrmAktiRezervasyon frmAktiRezervasyon = new Formlar.Rezervasyon.FrmAktiRezervasyon();
            frmAktiRezervasyon.MdiParent = this;
            frmAktiRezervasyon.Show();
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Rezervasyon.FrmİptalRezervasyonlar frmİptalRezervasyonlar = new Formlar.Rezervasyon.FrmİptalRezervasyonlar();
            frmİptalRezervasyonlar.MdiParent = this;
            frmİptalRezervasyonlar.Show();
        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Rezervasyon.FrmGecmisRezervasonlar frmGecmisRezervasonlar = new Formlar.Rezervasyon.FrmGecmisRezervasonlar();
            frmGecmisRezervasonlar.MdiParent = this;
            frmGecmisRezervasonlar.Show();
        }

        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Rezervasyon.FrmGelecekRezervasyon frmGelecekRezervasyon = new Formlar.Rezervasyon.FrmGelecekRezervasyon();
            frmGelecekRezervasyon.MdiParent = this;
            frmGelecekRezervasyon.Show();
        }
    }
}
