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

namespace OtelProject.Formlar.Misafir
{
    public partial class FrmMisafirListesi : Form
    {
        public FrmMisafirListesi()
        {
            InitializeComponent();
        }
        DbOtelEntities dbOtelEntities = new DbOtelEntities();
        private void FrmMisafirListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in dbOtelEntities.TblMisafir
                                       where x.Durum == 1
                                       select new
                                       {
                                           x.MisafirId,
                                           x.Ad,
                                           x.Soyad,
                                           x.TC,
                                           x.Telefon,
                                           x.Mail,
                                           x.iller.sehiradi,
                                           x.ilceler.ilceadi
                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Formlar.Misafir.FrmMisafirKarti frmMisafirKarti = new Formlar.Misafir.FrmMisafirKarti();
            frmMisafirKarti.MisafirId = int.Parse(gridView1.GetFocusedRowCellValue("MisafirId").ToString());
            frmMisafirKarti.Show();
        }
    }
}
