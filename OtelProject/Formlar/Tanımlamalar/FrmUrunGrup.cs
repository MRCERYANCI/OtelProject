using DevExpress.XtraEditors;
using OtelProject.Entity;
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

namespace OtelProject.Formlar.Tanımlamalar
{
    public partial class FrmUrunGrup : Form
    {
        public FrmUrunGrup()
        {
            InitializeComponent();
        }
        DbOtelEntities dbOtelEntities = new DbOtelEntities();
        private void FrmUrunGrup_Load(object sender, EventArgs e)
        {
            dbOtelEntities.TblUrunGrup.Load();
            bindingSource1.DataSource = dbOtelEntities.TblUrunGrup.Local;

            repositoryItemLookUpEdit2.DataSource = (from x in dbOtelEntities.TblDurum
                                                    select new
                                                    {
                                                        x.DurumID,
                                                        x.DurumAd
                                                    }).ToList();
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
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
