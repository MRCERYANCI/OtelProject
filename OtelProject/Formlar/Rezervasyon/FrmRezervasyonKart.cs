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

namespace OtelProject.Formlar.Rezervasyon
{
    public partial class FrmRezervasyonKart : Form
    {
        public FrmRezervasyonKart()
        {
            InitializeComponent();
        }
        DbOtelEntities dbOtelEntities = new DbOtelEntities();
        GenericRepository<TblRezervasyon> genericRepository = new GenericRepository<TblRezervasyon>();
        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmRezervasyonKart_Load(object sender, EventArgs e)
        {
            lookUpEditMisafir.Properties.DataSource = (from x in dbOtelEntities.TblMisafir
                                                       select new
                                                       {
                                                           x.MisafirId,
                                                           AdSoyad = x.Ad + " " + x.Soyad
                                                       }).ToList();
            lookUpEditOda.Properties.DataSource = (from x in dbOtelEntities.TblOda
                                                   where x.Durum == 1
                                                   select new
                                                   {
                                                       x.OdaId,
                                                       x.OdaNo
                                                   }).ToList();
            lookUpEditDurum.Properties.DataSource = (from x in dbOtelEntities.TblDurum
                                                     select new
                                                     {
                                                         x.DurumID,
                                                         x.DurumAd
                                                     }).ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TblRezervasyon tblRezervasyon = new TblRezervasyon();
            tblRezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
            tblRezervasyon.GirisTarih = DateTime.Parse(dateEditGiris.Text);
            tblRezervasyon.CikisTarih = DateTime.Parse(dateEditCikis.Text);
            tblRezervasyon.Kisi = numericUpDownKisiSayisi.Value.ToString();
            tblRezervasyon.Oda = int.Parse(lookUpEditOda.EditValue.ToString());
            tblRezervasyon.RezervasyonAdSoyad = textEditAdSoyad.Text;
            tblRezervasyon.Telefon = textEditTelefon.Text;
            tblRezervasyon.Aciklama = memoAciklama.Text;
            tblRezervasyon.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            genericRepository.Insert(tblRezervasyon);
            XtraMessageBox.Show("Rezervasyon Başarıyla Sisteme Kayıt Yapılmıştır", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
