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
using System.IO;


namespace Gestion_des_factures
{
    public partial class Acceuil : Form
    {
        public Acceuil()
        {
            InitializeComponent();
        }
        private readonly Connexion FrmConnex;
        public Acceuil(Connexion frm)
        {
            InitializeComponent();
            FrmConnex = frm;
        }
        public static SQLiteConnection cnx = new SQLiteConnection("Data Source="+Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\GestionFactures\db\GestionStckFct.db;Version=3;");
        public static DataSet ds = new DataSet();
        public static void WriteLog(string msg) {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GestionFactures\\Log";
            DirectoryInfo di = Directory.CreateDirectory(path);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "Exceptions.log"), true))
            {
                    outputFile.WriteLine(msg);
            }
        }
        //fonction pour ouvrir les fenaitre depuis la bare menu
        public void OpenForm(Form f)
        {
            Form form = f;
            form.ShowDialog();
        }
        public void RefreshAccui() {
            try {
                SQLiteDataAdapter dap = new SQLiteDataAdapter("select * from Stocks s, Produits p where s.NuPrd = p.NumPrd", cnx);
                DataSet nds = new DataSet();
                dap.Fill(nds, "Stocks");
                lbl_nbrPrdStk.Text = nds.Tables["Stocks"].Rows.Count.ToString();
                dap = new SQLiteDataAdapter("select p.NumPrd as 'رقم السلعة', p.Desingation as 'الإسم', s.QttProd as 'الكمية', s.QttPrsFini as 'الكمية الأدنى', s.DateAjout as 'تاريخ اللإضافة' from Stocks s, Produits p where s.NuPrd = p.NumPrd order by p.NumPrd DESC LIMIT 10", cnx);
                dap.Fill(nds, "DerProduitsAjt");
                SQLiteDataAdapter dta2 = new SQLiteDataAdapter("select p.NumPrd as 'رقم السلعة', p.Desingation as 'الإسم', s.QttProd as 'الكمية', s.DateAjout as 'تاريخ اللإضافة' from Stocks s, Produits p where s.NuPrd = p.NumPrd AND s.QttProd = 0", cnx);
                dta2.Fill(nds, "ProduitsFini");
                dgv_dernProdajt.DataSource = nds.Tables["DerProduitsAjt"];
                dgv_prodFini.DataSource = nds.Tables["ProduitsFini"];
                RefreshLabels(nds.Tables["Stocks"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: Actualisation de page d'acceuil ; Event: ] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }
        public void LoadForm()
        {
            SQLiteDataAdapter dta = new SQLiteDataAdapter("select * from Stocks s, Produits p where s.NuPrd = p.NumPrd", cnx);
            dta.Fill(ds, "Stocks");
            lbl_nbrPrdStk.Text = ds.Tables["Stocks"].Rows.Count.ToString();
            RefreshLabels(ds.Tables["Stocks"]);
            SQLiteDataAdapter dta2 = new SQLiteDataAdapter("select p.NumPrd as 'رقم السلعة', p.Desingation as 'الإسم', s.QttProd as 'الكمية', s.DateAjout as 'تاريخ اللإضافة' from Stocks s, Produits p where s.NuPrd = p.NumPrd AND s.QttProd = 0", cnx);
            dta2.Fill(ds, "ProduitsFini");
            dta2 = new SQLiteDataAdapter("select p.NumPrd as 'رقم السلعة', p.Desingation as 'الإسم', s.QttProd as 'الكمية', s.QttPrsFini as 'الكمية الأدنى', s.DateAjout as 'تاريخ اللإضافة' from Stocks s, Produits p where s.NuPrd = p.NumPrd order by p.NumPrd DESC LIMIT 10", cnx);
            dta2.Fill(ds, "DerProduitsAjt");
            dgv_prodFini.DataSource = ds.Tables["ProduitsFini"];
            dgv_dernProdajt.DataSource = ds.Tables["DerProduitsAjt"];
            dgv_dernProdajt.ClearSelection();
            dgv_prodFini.ClearSelection();
        }

        private void RefreshLabels(DataTable tbl)
        {
            var dv = tbl.DefaultView;
            dv.RowFilter = "QttProd <= QttPrsFini AND QttProd <> 0";
            lbl_PrdPrsqFini.Text = dv.ToTable().Rows.Count.ToString();
            if (lbl_PrdPrsqFini.Text != "0")
            {
                lbl_PrdPrsqFini.ForeColor = Color.OrangeRed;
                lbl_Nmpsf.ForeColor = Color.DarkOrange;
            }
            dv.RowFilter = "QttProd = 0";
            lbl_PrdFini.Text = dv.ToTable().Rows.Count.ToString();
            if (lbl_PrdFini.Text != "0")
            {
                lbl_PrdFini.ForeColor = Color.Red;
                lbl_Nmpf.ForeColor = Color.Red;
            }
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            try{
                LoadForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void AjtVentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new AjtVente(this));
        }

        private void ttVentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new AffVente());
        }

        private void AffProdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new AffProduit(this));
        }

        private void AjtProdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new AjtProduits(this));
        }

        private void MdfProdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new MdfProduit());
        }

        private void AffDtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new AffDette());
        }

        private void AjtDtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new AjtDette());
        }

        private void MdfDtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new MdfDette());
        }

        private void تعديلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new MfdConnexion());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                FrmConnex.ConnexionShow(this);

            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                WriteLog(Err);
            }
        
        }

        private void Acceuil_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Factures    ";
                System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(path);
                if (System.IO.Directory.Exists(path)) 
                System.Diagnostics.Process.Start((path));
            } catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString()+" ; Event: "+e.ToString()+"] __ ExceptionMessage : "+ex.Message;
                WriteLog(Err);
            }

        }

        

    }
}
