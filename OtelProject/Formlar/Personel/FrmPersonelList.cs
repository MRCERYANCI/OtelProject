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

namespace OtelProject.Formlar.Personel
{
    public partial class FrmPersonelList : Form
    {
        public FrmPersonelList()
        {
            InitializeComponent();
        }
        DbOtelEntities dbOtelEntities = new DbOtelEntities();
        private void FrmPersonelList_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in dbOtelEntities.TblPersonel
                                       select new
                                       {
                                           x.PersonelId,
                                           x.Ad,
                                           x.Soyad,
                                           x.TC,
                                           x.Telefon,
                                           x.Mail,
                                           x.TblDepartman.DepartmanAd,
                                           x.TblGorev.GorevAd,
                                           x.TblDurum.DurumAd
                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Formlar.Personel.FrmPersonelKart frmPersonelKart = new FrmPersonelKart();
            frmPersonelKart.PersonelId = int.Parse(gridView1.GetFocusedRowCellValue("PersonelId").ToString());
            frmPersonelKart.Show();
        }
    }
}
