using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelProject.Entity;

namespace OtelProject.Formlar.Tanımlamalar
{
    public partial class FrmDurum : Form
    {
        public FrmDurum()
        {
            InitializeComponent();
        }
        DbOtelEntities dbOtelEntities = new DbOtelEntities();
        private void FrmDurum_Load(object sender, EventArgs e)
        {
            dbOtelEntities.TblDurum.Load();
            bindingSource1.DataSource = dbOtelEntities.TblDurum.Local;

            //var DurumListesi = (from x in dbOtelEntities.TblDurum
            //                    select new
            //                    {
            //                        x.DurumID,
            //                        x.DurumAd
            //                    });
            //gridControl1.DataSource = DurumListesi.ToList();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                dbOtelEntities.SaveChanges();
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(error.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();  //Üzerinde Aktif Olarak Çalıştığım Alanı Kaldır
            dbOtelEntities.SaveChanges();
        }
    }
}
