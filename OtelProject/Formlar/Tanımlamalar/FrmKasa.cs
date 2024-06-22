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
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }
        DbOtelEntities dbOtelEntities = new DbOtelEntities();
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

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            dbOtelEntities.TblKasa.Load();
            bindingSource1.DataSource = dbOtelEntities.TblKasa.Local;

            repositoryItemLookUpEdit3.DataSource = (from x in dbOtelEntities.TblDurum
                                                    select new
                                                    {
                                                        x.DurumID,
                                                        x.DurumAd
                                                    }).ToList();

        }
    }
}
