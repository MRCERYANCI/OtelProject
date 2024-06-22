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
    public partial class FrmUrunHareketTanimi : Form
    {
        public FrmUrunHareketTanimi()
        {
            InitializeComponent();
        }
        DbOtelEntities dbOtelEntities = new DbOtelEntities();
        GenericRepository<TblHareket> genericRepository = new GenericRepository<TblHareket>();
        TblHareket tblHareket = new TblHareket();
        public int? HareketId;
        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmUrunHareketTanimi_Load(object sender, EventArgs e)
        {
            lookUpEditUrun.Properties.DataSource = (from x in dbOtelEntities.TblUrun
                                                    select new
                                                    {
                                                        x.UrunId,
                                                        x.UrunAd
                                                    }).ToList();

            if (HareketId != null)
            {
                var HareketVerisi = genericRepository.GetById(int.Parse(HareketId.ToString()));
                lookUpEditUrun.EditValue = HareketVerisi.Urun;
                comboBoxHareket.Text = HareketVerisi.HareketTuru;
                memoAciklama.Text = HareketVerisi.Aciklama;
                dateEditTarih.Text = HareketVerisi.Tarih.ToString();
                txtMiktar.Text = HareketVerisi.Miktar.ToString();
                btnKaydet.Enabled = false;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            tblHareket.Urun = short.Parse(lookUpEditUrun.EditValue.ToString());
            tblHareket.HareketTuru = comboBoxHareket.Text;
            tblHareket.Miktar = int.Parse(txtMiktar.Text);
            tblHareket.Tarih = DateTime.Parse(dateEditTarih.Text);
            tblHareket.Aciklama = memoAciklama.Text;
            genericRepository.Insert(tblHareket);
            XtraMessageBox.Show("Ürün Hareketi Sisteme Kayıt Edilmitir", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var HareketVerisi = genericRepository.GetById(int.Parse(HareketId.ToString()));
            HareketVerisi.Urun = short.Parse(lookUpEditUrun.EditValue.ToString());
            HareketVerisi.HareketTuru = comboBoxHareket.Text;
            HareketVerisi.Miktar = int.Parse(txtMiktar.Text);
            HareketVerisi.Tarih = DateTime.Parse(dateEditTarih.Text);
            HareketVerisi.Aciklama = memoAciklama.Text;
            genericRepository.Update(HareketVerisi);
            XtraMessageBox.Show("Ürün Hareketi Başarıyla Güncellenmiştir", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
