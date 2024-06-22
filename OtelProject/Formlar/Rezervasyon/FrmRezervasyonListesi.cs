﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtelProject.Entity;
namespace OtelProject.Formlar.Rezervasyon
{
    public partial class FrmRezervasyonListesi : Form
    {
        public FrmRezervasyonListesi()
        {
            InitializeComponent();
        }
        DbOtelEntities dbOtelEntities = new DbOtelEntities();
        private void FrmRezervasyonListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in dbOtelEntities.TblRezervasyon
                                       select new
                                       {
                                           x.RezervasyonId,
                                           AdSoyad = x.TblMisafir.Ad + " " + x.TblMisafir.Soyad,
                                           x.GirisTarih,
                                           x.CikisTarih,
                                           x.Kisi,
                                           x.TblOda.OdaNo,
                                           x.Telefon,
                                           x.TblDurum.DurumAd
                                       }).ToList();
        }
    }
}
