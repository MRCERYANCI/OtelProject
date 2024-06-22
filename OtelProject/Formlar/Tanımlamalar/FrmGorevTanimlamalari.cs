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
    public partial class FrmGorevTanimlamalari : Form
    {
        public FrmGorevTanimlamalari()
        {
            InitializeComponent();
        }
        DbOtelEntities dbOtelEntities = new DbOtelEntities();
        private void FrmGorevTanimlamalari_Load(object sender, EventArgs e)
        {
            dbOtelEntities.TblGorev.Load();
            bindingSource1.DataSource = dbOtelEntities.TblGorev.Local;

            repositoryItemLookUpEdit1.DataSource = (from x in dbOtelEntities.TblDurum
                                                    select new
                                                    {
                                                        x.DurumID,
                                                        x.DurumAd
                                                    }).ToList();

            repositoryItemLookUpEdit2.DataSource = (from x in dbOtelEntities.TblDepartman
                                                    select new
                                                    {
                                                        x.DepartmanID,
                                                        x.DepartmanAd
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
