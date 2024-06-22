using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelProject.Formlar.Araclar
{
    public partial class FrmYouTube : Form
    {
        public FrmYouTube()
        {
            InitializeComponent();
        }

        private void FrmYouTube_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.youtube.com/");
        }
    }
}
