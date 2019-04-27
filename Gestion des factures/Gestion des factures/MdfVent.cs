using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gestion_des_factures
{
    public partial class MdfVent : Form
    {
        private readonly int idvt;
        private readonly AffVente frm;
        public MdfVent(int idV, AffVente f)
        {
            InitializeComponent();
            idvt = idV;
            frm = f;
        }

        public MdfVent()
        {
            InitializeComponent();
        }

        private void MdfVent_Load(object sender, EventArgs e)
        {

        }
    }
}
