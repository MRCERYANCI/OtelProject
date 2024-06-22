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
    public partial class FrmUlke : Form
    {
        public FrmUlke()
        {
            InitializeComponent();
        }
        DbOtelEntities dbOtelEntities = new DbOtelEntities();
        private void FrmUlke_Load(object sender, EventArgs e)
        {
            dbOtelEntities.TblUlke.Load();
            bindingSource1.DataSource = dbOtelEntities.TblUlke.Local;
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
