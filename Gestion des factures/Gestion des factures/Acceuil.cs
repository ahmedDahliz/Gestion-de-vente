using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace Gestion_des_factures
{
    public partial class Acceuil : Form
    {
        public static SQLiteConnection cnx = new SQLiteConnection(@"Data Source=C:\Users\Ahmed\AppData\Roaming\GestionFactures\db\GestionStckFct.db;Version=3;");
        DataSet ds = new DataSet();
        public Acceuil()
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
            SQLiteDataAdapter dta = new SQLiteDataAdapter("select * from Stocks", cnx);
            dta.Fill(ds, "Stocks");
            lbl_nbrPrdStk.Text = ds.Tables["Stocks"].Rows.Count.ToString();
            var dv = ds.Tables["Stocks"].DefaultView;
            dv.RowFilter = "QttProd <= QttPrsFini AND QttProd <> 0";
            lbl_PrdPrsqFini.Text = dv.ToTable().Rows.Count.ToString();
            if (lbl_PrdPrsqFini.Text != "0") lbl_PrdPrsqFini.ForeColor = Color.Orange;
            dv.RowFilter = "QttProd = 0";
            lbl_PrdFini.Text = dv.ToTable().Rows.Count.ToString();
            if (lbl_PrdFini.Text != "0") lbl_PrdFini.ForeColor = Color.Red;
            SQLiteDataAdapter dta2 = new SQLiteDataAdapter("select p.NumPrd as 'رقم السلعة', p.Desingation as 'الإسم', s.QttProd as 'الكمية', s.DateAjout as 'تاريخ اللإضافة' from Stocks s, Produits p where s.NuPrd = p.NumPrd AND s.QttProd = 0", cnx);
            dta2.Fill(ds, "ProduitsFini");
                dta2 = new SQLiteDataAdapter("select * from Produits order by NumPrd LIMIT 10", cnx);
                dta2.Fill(ds, "DerProduitsAjt");
            dgv_prodFini.DataSource = ds.Tables["ProduitsFini"];
            dgv_dernProdajt.DataSource = ds.Tables["DerProduitsAjt"];

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
