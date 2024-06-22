using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtelProject.Entity;
using OtelProject.Repositories;

namespace OtelProject.Formlar.Personel
{
    public partial class FrmPersonelKart : Form
    {
        public FrmPersonelKart()
        {
            InitializeComponent();
        }
        DbOtelEntities dbOtelEntities=new DbOtelEntities();
       
        public int? PersonelId;
        string ImageYol1, ImageYol2;
        private void FrmPersonelKart_Load(object sender, EventArgs e)
        {
            lookUpEditDepartman.Properties.DataSource = (from x in dbOtelEntities.TblDepartman
                                                    select new
                                                    {
                                                        x.DepartmanID,
                                                        x.DepartmanAd
                                                    }).ToList();

            lookUpEditGorev.Properties.DataSource = (from x in dbOtelEntities.TblGorev
                                                         select new
                                                         {
                                                             x.GorevId,
                                                             x.GorevAd
                                                         }).ToList();

            if (PersonelId != null)
            {
                GenericRepository<TblPersonel> genericRepository = new GenericRepository<TblPersonel>();
                var PersonelListesi = genericRepository.GetById(int.Parse(PersonelId.ToString()));
                txtAdSoyad.Text = PersonelListesi.Ad + " " + PersonelListesi.Soyad;
                txtTc.Text = PersonelListesi.TC;
                txtTel.Text = PersonelListesi.Telefon;
                txtMail.Text = PersonelListesi.Mail;
                memoAciklama.Text = PersonelListesi.Aciklama;
                memoAdres.Text = PersonelListesi.Adres;
                txtSifre.Text = PersonelListesi.Sifre;
                lookUpEditDepartman.EditValue = PersonelListesi.Departman;
                lookUpEditGorev.EditValue = PersonelListesi.Gorev;
                dateGiris.Text = PersonelListesi.IseGirisTarih.ToString();
                if (PersonelListesi.KimlikOn != null)
                {
                    kimlikOn.Image = Image.FromFile(PersonelListesi.KimlikOn);
                }
                if (PersonelListesi.KimlikArka != null)
                {
                    kimlikArka.Image = Image.FromFile(PersonelListesi.KimlikArka);
                }
                ImageYol1 = PersonelListesi.KimlikOn;
                ImageYol2 = PersonelListesi.KimlikArka;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            GenericRepository<TblPersonel> genericRepository = new GenericRepository<TblPersonel>();
            TblPersonel tblPersonel = new TblPersonel();
            string[] AdSoyadParcasi = txtAdSoyad.Text.Split(' ');
            tblPersonel.Ad = AdSoyadParcasi[0];
            tblPersonel.Soyad = AdSoyadParcasi[1];
            tblPersonel.TC = txtTc.Text;
            tblPersonel.Adres = memoAdres.Text;
            tblPersonel.Telefon = txtTel.Text;
            tblPersonel.Mail = txtMail.Text;
            tblPersonel.IseGirisTarih = DateTime.Parse(dateGiris.Text);
            tblPersonel.Aciklama = memoAciklama.Text;
            tblPersonel.Sifre = txtSifre.Text;
            tblPersonel.Durum = 1;
            tblPersonel.Departman = int.Parse(lookUpEditDepartman.EditValue.ToString());
            tblPersonel.Gorev = int.Parse(lookUpEditGorev.EditValue.ToString());

            if (kimlikOn.GetLoadedImageLocation() != null)
            {
                tblPersonel.KimlikOn = kimlikOn.GetLoadedImageLocation();
                if (kimlikArka.GetLoadedImageLocation() != null)
                {
                    tblPersonel.KimlikArka = kimlikArka.GetLoadedImageLocation();
                }
            }
            tblPersonel.Sifre = txtSifre.Text;
            genericRepository.Insert(tblPersonel);
            MessageBox.Show("Personel Kaydı Başarıyla Gerçekleşmiştir.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GenericRepository<TblPersonel> genericRepository = new GenericRepository<TblPersonel>();
            var PersonelListesi = genericRepository.GetById(int.Parse(PersonelId.ToString()));
            string[] AdSoyadParcasi = txtAdSoyad.Text.Split(' ');
            PersonelListesi.Ad = AdSoyadParcasi[0];
            PersonelListesi.Soyad = AdSoyadParcasi[1];
            PersonelListesi.Mail = txtMail.Text;
            PersonelListesi.TC = txtTc.Text;
            PersonelListesi.Adres = memoAdres.Text;
            PersonelListesi.Aciklama = memoAciklama.Text;
            PersonelListesi.Sifre = txtSifre.Text;
            PersonelListesi.KimlikOn = ImageYol1;
            PersonelListesi.KimlikArka = ImageYol2;
            PersonelListesi.Departman = int.Parse(lookUpEditDepartman.EditValue.ToString());
            PersonelListesi.Gorev = int.Parse(lookUpEditGorev.EditValue.ToString());
            genericRepository.Update(PersonelListesi);
            MessageBox.Show("Personel Başarıyla Güncellenmiştir", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void kimlikArka_EditValueChanged(object sender, EventArgs e)
        {
            ImageYol2 = kimlikArka.GetLoadedImageLocation();
        }

        private void kimlikOn_EditValueChanged(object sender, EventArgs e)
        {
            ImageYol1 = kimlikOn.GetLoadedImageLocation();
        }
    }
}
