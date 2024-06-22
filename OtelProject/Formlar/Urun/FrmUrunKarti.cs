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

namespace OtelProject.Formlar.Urun
{
    public partial class FrmUrunKarti : Form
    {
        public FrmUrunKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities dbOtelEntities = new DbOtelEntities();
        public int? UrunId;
        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmUrunKarti_Load(object sender, EventArgs e)
        {
            lookUpEditBirim.Properties.DataSource = (from x in dbOtelEntities.TblBirim
                                                     select new
                                                     {
                                                         x.BirimID,
                                                         x.BirimAd
                                                     }).ToList();
            lookUpEditDurum.Properties.DataSource = (from x in dbOtelEntities.TblDurum
                                                     select new
                                                     {
                                                         x.DurumID,
                                                         x.DurumAd
                                                     }).ToList();
            lookUpEditrunGrup.Properties.DataSource = (from x in dbOtelEntities.TblUrunGrup
                                                     select new
                                                     {
                                                         x.UrunGrupId,
                                                         x.UrunGrupAd
                                                     }).ToList();

            if (UrunId != null)
            {
                GenericRepository<TblUrun> genericRepository = new GenericRepository<TblUrun>();
                var UrunDegeri = genericRepository.GetById(int.Parse(UrunId.ToString()));
                txtUrunAd.Text = UrunDegeri.UrunAd;
                txtFiyat.Text = UrunDegeri.Fiyat.ToString();
                txtToplam.Text = UrunDegeri.Toplam.ToString();
                txtKdv.Text = UrunDegeri.Kdv.ToString();
                lookUpEditBirim.EditValue = UrunDegeri.Birim;
                lookUpEditDurum.EditValue = UrunDegeri.Durum;
                lookUpEditrunGrup.EditValue = UrunDegeri.UrunGrup;

                btnKaydet.Enabled = false;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            GenericRepository<TblUrun> genericRepository = new GenericRepository<TblUrun>();
            TblUrun tblUrun = new TblUrun();
            tblUrun.UrunAd = txtUrunAd.Text;
            tblUrun.UrunGrup = byte.Parse(lookUpEditrunGrup.EditValue.ToString());
            tblUrun.Birim = byte.Parse(lookUpEditBirim.EditValue.ToString());
            tblUrun.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            tblUrun.Fiyat = decimal.Parse(txtFiyat.Text);
            tblUrun.Toplam = int.Parse(txtToplam.Text);
            tblUrun.Kdv = byte.Parse(txtKdv.Text);
            genericRepository.Insert(tblUrun);
            XtraMessageBox.Show("Ürün Başarıyla Sisteme Kayıt Edilmitir", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            GenericRepository<TblUrun> genericRepository = new GenericRepository<TblUrun>();
            var UrunDegeri = genericRepository.GetById(int.Parse(UrunId.ToString()));

            UrunDegeri.UrunAd = txtUrunAd.Text;
            UrunDegeri.Toplam = int.Parse(txtToplam.Text);
            UrunDegeri.Fiyat = decimal.Parse(txtFiyat.Text);
            UrunDegeri.Kdv = byte.Parse(txtKdv.Text);
            UrunDegeri.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            UrunDegeri.Birim = byte.Parse(lookUpEditBirim.EditValue.ToString());
            UrunDegeri.UrunGrup = byte.Parse(lookUpEditrunGrup.EditValue.ToString());
            genericRepository.Update(UrunDegeri);
            XtraMessageBox.Show("Ürün Başarıyla Güncellenmiştir", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtKdv.Text = "1";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtKdv.Text = "8";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtKdv.Text = "10";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            txtKdv.Text = "18";
        }
    }
}
