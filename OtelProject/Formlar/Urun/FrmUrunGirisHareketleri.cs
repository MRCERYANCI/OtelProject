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
    public partial class FrmUrunGirisHareketleri : Form
    {
        public FrmUrunGirisHareketleri()
        {
            InitializeComponent();
        }
        DbOtelEntities dbOtelEntities = new DbOtelEntities();
        private void FrmUrunGirisHareketleri_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in dbOtelEntities.TblHareket
                                    where x.HareketTuru == "Giriş"
                                    select new
                                    {
                                        x.HareketId,
                                        x.TblUrun.UrunAd,
                                        x.Miktar,
                                        x.Tarih
                                    }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Formlar.Urun.FrmUrunHareketTanimi frmUrunHareketTanimi = new Formlar.Urun.FrmUrunHareketTanimi();
            frmUrunHareketTanimi.HareketId = int.Parse(gridView1.GetFocusedRowCellValue("HareketId").ToString());
            frmUrunHareketTanimi.Show();
        }
    }
}
