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
    public partial class AffVente : Form
    {
        public AffVente()
        {
            InitializeComponent();
        }
        int i = 0;
        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

           
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            label8.Text = (i++).ToString();
        }
    }
}
