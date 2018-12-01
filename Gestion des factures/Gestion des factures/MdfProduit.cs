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
    public partial class MdfProduit : Form
    {
        private readonly int idpr;
        public MdfProduit(int idP)
        {
            InitializeComponent();
            idpr = idP; 
        }
        public MdfProduit()
        {
            InitializeComponent();
        }

        private void MdfProduit_Load(object sender, EventArgs e)
        {

        }
    }
}
