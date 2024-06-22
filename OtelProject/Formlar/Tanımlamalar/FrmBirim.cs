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
    public partial class FrmBirim : Form
    {
        public FrmBirim()
        {
            InitializeComponent();
        }
        DbOtelEntities dbOtelEntities = new DbOtelEntities();
        private void FrmBirim_Load(object sender, EventArgs e)
        {
            dbOtelEntities.TblBirim.Load();
            bindingSource1.DataSource = dbOtelEntities.TblBirim.Local;

            repositoryItemLookUpEditDurum.DataSource = (from x in dbOtelEntities.TblDurum
                                                        select new
                                                        {
                                                            x.DurumID,
                                                            x.DurumAd
                                                        }).ToList();
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
    }
}
