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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //fonction pour ouvrir les fenaitre depuis la bare menu
        public void OuvrirForm(Form f)
        {
            Form form = f;
            form.ShowDialog();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AjtVentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OuvrirForm(new AjtVente());
        }

        private void ttVentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OuvrirForm(new AffVente());
        }

        private void AffProdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OuvrirForm(new AffProduit());
        }

        private void AjtProdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OuvrirForm(new AjtProduits());
        }

        private void MdfProdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OuvrirForm(new MdfProduit());
        }

        private void AffDtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OuvrirForm(new AffDette());
        }

        private void AjtDtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OuvrirForm(new AjtDette());
        }

        private void MdfDtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OuvrirForm(new MdfDette());
        }

        private void تعديلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OuvrirForm(new MfdConnexion());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            OuvrirForm(new Connexion());
        }

        

    }
}
