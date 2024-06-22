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

namespace OtelProject.Formlar.Urun
{
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        DbOtelEntities dbOtelEntities = new DbOtelEntities();
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in dbOtelEntities.TblUrun
                                       select new
                                       {
                                           x.UrunId,
                                           x.TblUrunGrup.UrunGrupAd,
                                           x.UrunAd,
                                           x.Fiyat,
                                           x.TblBirim.BirimAd,
                                           x.Toplam
                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Formlar.Urun.FrmUrunKarti frmUrunKarti = new Formlar.Urun.FrmUrunKarti();
            frmUrunKarti.UrunId = int.Parse(gridView1.GetFocusedRowCellValue("UrunId").ToString());
            frmUrunKarti.Show();
        }
    }
}
