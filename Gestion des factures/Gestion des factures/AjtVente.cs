using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_des_factures
{
    public partial class AjtVente : Form
    {
        public AjtVente()
        {
            InitializeComponent();
        }

        private void AjtVente_Load(object sender, EventArgs e)
        {
            lbl_datAjr.Text = DateTime.Today.ToShortDateString();
           
        }

        private void rb_persn_CheckedChanged(object sender, EventArgs e)
        {
            EnableMskPx(true);
        }

        public void EnableMskPx(Boolean b)
        {
            mskt_pxpresn.Enabled = b;
            if (!b) mskt_pxpresn.Text = "";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            EnableMskPx(false);
        }

        private void rd_B_CheckedChanged(object sender, EventArgs e)
        {
            EnableMskPx(false);
        }

        private void rb_C_CheckedChanged(object sender, EventArgs e)
        {
            EnableMskPx(false);
        }
        
    }
}
