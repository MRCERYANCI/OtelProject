using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelProject.Entity;
using OtelProject.Repositories;

namespace OtelProject.Formlar.Misafir
{
    public partial class FrmMisafirKarti : Form
    {
        public FrmMisafirKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities dbOtelEntities = new DbOtelEntities();
        public int? MisafirId;
        string ImageYol1, ImageYol2;
        private void FrmMisafirKarti_Load(object sender, EventArgs e)
        {
            lookUpEditUlke.Properties.DataSource = (from x in dbOtelEntities.TblUlke
                                                    select new
                                                    {
                                                        x.UlkeId,
                                                        x.UlkeAd
                                                    }).ToList();

            lookUpEditil.Properties.DataSource = (from x in dbOtelEntities.iller
                                                  select new
                                                  {
                                                      x.id,
                                                      x.sehiradi
                                                  }).ToList();

            try
            {
                if (MisafirId != null)
                {
                    GenericRepository<TblMisafir> genericRepository = new GenericRepository<TblMisafir>();
                    var PersonelListesi = genericRepository.GetById(int.Parse(MisafirId.ToString()));
                    txtAdSoyad.Text = PersonelListesi.Ad + " " + PersonelListesi.Soyad;
                    txtTc.Text = PersonelListesi.TC;
                    txtTel.Text = PersonelListesi.Telefon;
                    txtMail.Text = PersonelListesi.Mail;
                    memoAciklama.Text = PersonelListesi.Aciklama;
                    memoAdres.Text = PersonelListesi.Adres;
                    lookUpEditUlke.EditValue = PersonelListesi.Ulke;
                    lookUpEditil.EditValue = PersonelListesi.Il;
                    lookUpEditiller.EditValue = PersonelListesi.Ilce;

                    if (PersonelListesi.KimlikFoto1 != null)
                    {
                        kimlikOn.Image = Image.FromFile(PersonelListesi.KimlikFoto1);
                    }
                    if (PersonelListesi.KimlikFoto2 != null)
                    {
                        kimlikArka.Image = Image.FromFile(PersonelListesi.KimlikFoto2);
                    }
                    ImageYol1 = PersonelListesi.KimlikFoto1;
                    ImageYol2 = PersonelListesi.KimlikFoto2;

                    btnKaydet.Enabled = false;
                }
            }
            catch (Exception Error)
            {
                XtraMessageBox.Show(Error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lookUpEditil_EditValueChanged(object sender, EventArgs e)
        {
            int plakaKodu= int.Parse(lookUpEditil.EditValue.ToString());
            lookUpEditiller.Properties.DataSource = (from x in dbOtelEntities.ilceler where x.sehirid==plakaKodu
                                                  select new
                                                  {
                                                      x.id,
                                                      x.ilceadi
                                                  }).ToList();
        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GenericRepository<TblMisafir> genericRepository = new GenericRepository<TblMisafir>();
            var MusteriListesi = genericRepository.GetById(int.Parse(MisafirId.ToString()));
            string[] AdSoyadParcasi = txtAdSoyad.Text.Split(' ');
            MusteriListesi.Ad = AdSoyadParcasi[0];
            MusteriListesi.Soyad = AdSoyadParcasi[1];
            MusteriListesi.Mail = txtMail.Text;
            MusteriListesi.TC = txtTc.Text;
            MusteriListesi.Adres = memoAdres.Text;
            MusteriListesi.Aciklama = memoAciklama.Text;
            MusteriListesi.KimlikFoto1 = ImageYol1;
            MusteriListesi.KimlikFoto2 = ImageYol2;
            MusteriListesi.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
            MusteriListesi.Il = int.Parse(lookUpEditil.EditValue.ToString());
            MusteriListesi.Ilce = int.Parse(lookUpEditiller.EditValue.ToString());
            genericRepository.Update(MusteriListesi);
            XtraMessageBox.Show("Misafir Başarıyla Güncellenmiştir", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            GenericRepository<TblMisafir> genericRepository = new GenericRepository<TblMisafir>();
            TblMisafir tblMisafir = new TblMisafir();
            string[] AdSoyadParcasi = txtAdSoyad.Text.Split(' ');
            tblMisafir.Ad = AdSoyadParcasi[0];
            tblMisafir.Soyad = AdSoyadParcasi[1];
            tblMisafir.TC = txtTc.Text;
            tblMisafir.Ulke= int.Parse(lookUpEditUlke.EditValue.ToString());
            tblMisafir.Il= int.Parse(lookUpEditil.EditValue.ToString());
            tblMisafir.Ilce= int.Parse(lookUpEditiller.EditValue.ToString());
            tblMisafir.Mail = txtMail.Text;
            tblMisafir.Telefon = txtTel.Text;
            tblMisafir.Aciklama = memoAciklama.Text;
            tblMisafir.Adres = memoAdres.Text;
            if (kimlikOn.GetLoadedImageLocation() != null)
            {
                tblMisafir.KimlikFoto1 = kimlikOn.GetLoadedImageLocation();
                if (kimlikArka.GetLoadedImageLocation() != null)
                {
                    tblMisafir.KimlikFoto2 = kimlikArka.GetLoadedImageLocation();
                }
            }
            tblMisafir.Durum = 1;
            genericRepository.Insert(tblMisafir);
            XtraMessageBox.Show("Misafir Başarıyla Kayıt Edilmiştir", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
