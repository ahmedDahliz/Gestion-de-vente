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
    public partial class AffProduit : Form
    {
        public AffProduit()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        SQLiteDataAdapter dta = new SQLiteDataAdapter("select p.NumPrd as 'رقم السلعة', p.Desingation as 'الإسم', s.QttProd as 'الكمية', s.QttPrsFini as 'الكمية الأدنى', pa.Prix as 'ثمن A', pb.Prix as 'ثمن B', pc.prix as 'ثمن C', tp.NomType as 'النوع', s.DateAjout as 'تاريخ اللإضافة' from Stocks s, Produits p, TypePrixA pa, TypePrixB pb, TypePrixC pc, Types tp where tp.NumType = p.NuType AND s.NuPrd = p.NumPrd AND p.NumPrd = pa.NuPrd AND p.NumPrd =  pb.NuPrd AND p.NumPrd =  pc.NuPrd", Acceuil.cnx);
        SQLiteDataAdapter dta2 = new SQLiteDataAdapter("select NumType, NomType from Types", Acceuil.cnx);
        public string tpPrix = "";
        public void GetAllProduct()
        {
            dta.Fill(ds, "ProduitsAjt");
            dta2.Fill(ds, "Types");
            dgv_AfficheProd.DataSource = ds.Tables["ProduitsAjt"];
            DataRow rw = ds.Tables["Types"].NewRow();
            rw["NomType"] = "جميع الأنواع";
            rw["NumType"] = 0;
            ds.Tables["Types"].Rows.InsertAt(rw, 0);
            cb_type.ValueMember = "NumType";
            cb_type.DisplayMember = "NomType";
            cb_type.DataSource = ds.Tables["Types"];
            lbl_nmProd.Text = ds.Tables["ProduitsAjt"].Rows.Count.ToString();
        }
        public DataTable GetEmptyProducts()
        {
            DataView dv = ds.Tables["ProduitsAjt"].DefaultView;
            dv.RowFilter = "الكمية = 0";
            lbl_nmProd.Text = dv.ToTable().Rows.Count.ToString();
            return dv.ToTable();

        }
        public DataTable GetAlmEmpProducts()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select p.NumPrd as 'رقم السلعة', p.Desingation as 'الإسم', s.QttProd as 'الكمية', s.QttPrsFini as 'الكمية الأدنى', pa.Prix as 'ثمن A', pb.Prix as 'ثمن B', pc.prix as 'ثمن C', tp.NomType as 'النوع', s.DateAjout as 'تاريخ اللإضافة' from Stocks s, Produits p, TypePrixA pa, TypePrixB pb, TypePrixC pc, Types tp where tp.NumType = p.NuType AND s.NuPrd = p.NumPrd AND p.NumPrd = pa.NuPrd AND p.NumPrd =  pb.NuPrd AND p.NumPrd =  pc.NuPrd AND s.QttProd <= s.QttPrsFini AND s.QttProd <> 0", Acceuil.cnx);
            DataSet dts = new DataSet();
            da.Fill(dts, "PrduiPrsFini");
            lbl_nmProd.Text = dts.Tables["PrduiPrsFini"].Rows.Count.ToString();
            return dts.Tables["PrduiPrsFini"];

        }
        //public DataTable GetFiltredData(String Filter) {
        //    SQLiteDataAdapter da = new SQLiteDataAdapter("select p.NumPrd as 'رقم السلعة', p.Desingation as 'الإسم', s.QttProd as 'الكمية', s.QttPrsFini as 'الكمية الأدنى', pa.Prix as 'ثمن A', pb.Prix as 'ثمن B', pc.prix as 'ثمن C', tp.NomType as 'النوع', s.DateAjout as 'تاريخ اللإضافة' from Stocks s, Produits p, TypePrixA pa, TypePrixB pb, TypePrixC pc, Types tp where tp.NumType = p.NuType AND s.NuPrd = p.NumPrd AND p.NumPrd = pa.NuPrd AND p.NumPrd =  pb.NuPrd AND p.NumPrd =  pc.NuPrd "+Filter, Acceuil.cnx);
        //    DataSet dst = new DataSet();
        //    da.Fill(dst, "Prduifiltrd");
        //    lbl_nmProd.Text = dst.Tables["Prduifiltrd"].Rows.Count.ToString();
        //    return dst.Tables["Prduifiltrd"];
        //}
        public DataTable GetFiltredData(string nuPr, string NmPr, string TpPr, string prPr,string tP, string dtPr)
        {
            String flPrix = "";
            if (tP == "A") flPrix = (prPr != "") ? " AND pa.Prix = " + prPr : "";
            if (tP == "B") flPrix = (prPr != "") ? " AND pb.Prix = " + prPr : "";
            if (tP == "C") flPrix = (prPr != "") ? " AND pc.Prix = " + prPr : "";
            String flNum = (nuPr != "") ? " AND p.NumPrd = "+nuPr : "";
            String flNom = (NmPr != "") ? " AND p.Desingation = '" + NmPr : "'";
            String fltype = (TpPr != "") ? " AND tp.NumType = " + TpPr : "";
            String flDate = (dtPr != "") ? " AND s.DateAjout = " + dtPr : "";
            string rqt = "select p.NumPrd as 'رقم السلعة', p.Desingation as 'الإسم', s.QttProd as 'الكمية', s.QttPrsFini as 'الكمية الأدنى', pa.Prix as 'ثمن A', pb.Prix as 'ثمن B', pc.prix as 'ثمن C', tp.NomType as 'النوع', s.DateAjout as 'تاريخ اللإضافة'"+
                " from Stocks s, Produits p, TypePrixA pa, TypePrixB pb, TypePrixC pc, Types tp "+
                "where tp.NumType = p.NuType AND s.NuPrd = p.NumPrd AND p.NumPrd = pa.NuPrd AND p.NumPrd =  pb.NuPrd AND p.NumPrd =  pc.NuPrd"+
                flNum + " " + flNom + " " + fltype + " " + flPrix + " " + flDate;
            SQLiteDataAdapter da = new SQLiteDataAdapter(rqt, Acceuil.cnx);
            DataSet dst = new DataSet();
            da.Fill(dst, "Prduifiltrd");
            lbl_nmProd.Text = dst.Tables["Prduifiltrd"].Rows.Count.ToString();
            return dst.Tables["Prduifiltrd"];
        }
        void ClearDgv() {
            if (dgv_AfficheProd.DataSource != null)
            {
                dgv_AfficheProd.DataSource = null;
            }
        }
        void CheckAlEmp() {
            foreach (DataGridViewRow grow in dgv_AfficheProd.Rows)
            {
                if (float.Parse(grow.Cells[2].Value.ToString()) <= float.Parse(grow.Cells[3].Value.ToString()) && float.Parse(grow.Cells[2].Value.ToString()) != 0)
                {
                    grow.DefaultCellStyle.BackColor = Color.Orange;
                }
                if (float.Parse(grow.Cells[2].Value.ToString()) == 0)
                {
                    grow.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        private void AffProduit_Load(object sender, EventArgs e)
        {
            GetAllProduct();
            CheckAlEmp();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgv_AfficheProd.DataSource = ds;
            dgv_AfficheProd.DataMember = "ProduitsAjt";
            CheckAlEmp();
            lbl_nmProd.Text = ds.Tables["ProduitsAjt"].Rows.Count.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgv_AfficheProd.DataSource = GetEmptyProducts();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            dgv_AfficheProd.DataSource = GetAlmEmpProducts();
        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tp = cb_type.SelectedValue.ToString();
            if (cb_type.SelectedValue.ToString() == "0")
            {
                tp = "";
            }
            dgv_AfficheProd.DataSource = GetFiltredData(txt_nuProd.Text, txt_NomProd.Text, tp, txt_prix.Text, tpPrix, dtp_datAjout.Text);
            CheckAlEmp();
        }

        private void dgv_AfficheProd_Sorted(object sender, EventArgs e)
        {
            CheckAlEmp();
        }
        
        private void txt_prix_TextChanged(object sender, EventArgs e)
        {
            float prx;
           
            if (float.TryParse(txt_prix.Text, out prx))
            {
                if (txt_nuProd.Text == ""  )
                {
                    
                }
            }
            else {
                MessageBox.Show("الثمن الذي أدخلته غير مقبول", "خطأ في إدخال الثمن", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtp_datAjout_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show(dtp_datAjout.Text);
        } 
    }
}
