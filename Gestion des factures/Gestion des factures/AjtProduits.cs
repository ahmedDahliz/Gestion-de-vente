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
    public partial class AjtProduits : Form
    {
        public AjtProduits()
        {
            InitializeComponent();
        }
        SQLiteDataAdapter dtaType = new SQLiteDataAdapter("Select * from Types", Acceuil.cnx);
        SQLiteDataAdapter dtaProduit = new SQLiteDataAdapter("Select * from Produits", Acceuil.cnx);
        SQLiteDataAdapter dtaStocke = new SQLiteDataAdapter("Select * from Stocks", Acceuil.cnx);
        SQLiteDataAdapter dtaPxA = new SQLiteDataAdapter("Select * from TypePrixA", Acceuil.cnx);
        SQLiteDataAdapter dtaPxB = new SQLiteDataAdapter("Select * from TypePrixB", Acceuil.cnx);
        SQLiteDataAdapter dtaPxC = new SQLiteDataAdapter("Select * from TypePrixC", Acceuil.cnx);
        DataSet ds = new DataSet();
        DataTable dtnp = new DataTable();
        int idT,idP;
        Boolean saved = true;
        private void nud_qttMn_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void nud_qtt_ValueChanged(object sender, EventArgs e)
        {
            nud_qttMn.Maximum = nud_qtt.Value;
            nud_qttMn.Enabled = (nud_qtt.Value > 0)? true : false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float pa, pb, pc;
            if (txt_nomPrd.Text != "" && txt_prxA.Text != "" && txt_prxB.Text != "" && txt_prxC.Text != "")
            {
                if (float.TryParse(txt_prxA.Text, out pa) && float.TryParse(txt_prxB.Text, out pb) && float.TryParse(txt_prxB.Text, out pc))
                {
                    if (nud_qtt.Value != 0)
                    {
                        DataRow ligneP = ds.Tables["Produits"].NewRow();
                        DataRow ligneS = ds.Tables["Stocks"].NewRow();
                        DataRow lignePrA = ds.Tables["TypPA"].NewRow();
                        DataRow lignePrB = ds.Tables["TypPB"].NewRow();
                        DataRow lignePrC = ds.Tables["TypPC"].NewRow();
                        DataRow ligneDgv = dtnp.NewRow();
                        ligneP[1] = txt_nomPrd.Text;
                        ligneP[2] = cb_tpPrd.SelectedValue.ToString();
                        ds.Tables["Produits"].Rows.Add(ligneP);
                        idP++;
                        lignePrA[1] = txt_prxA.Text;
                        lignePrA[2] = idP;
                        ds.Tables["TypPA"].Rows.Add(lignePrA);
                        lignePrB[1] = txt_prxA.Text;
                        lignePrB[2] = idP;
                        ds.Tables["TypPB"].Rows.Add(lignePrB);
                        lignePrC[1] = txt_prxA.Text;
                        lignePrC[2] = idP;
                        ds.Tables["TypPC"].Rows.Add(lignePrC);
                        ligneS[1] = nud_qtt.Value;
                        ligneS[2] = nud_qttMn.Value;
                        ligneS[3] = DateTime.Now.ToShortDateString();
                        ligneS[4] = idP;
                        ds.Tables["Stocks"].Rows.Add(ligneS);
                        ligneDgv[0] = idP;
                        ligneDgv[1] = txt_nomPrd.Text;
                        ligneDgv[2] = nud_qtt.Value;
                        ligneDgv[3] = nud_qttMn.Value;
                        ligneDgv[4] = txt_prxA.Text;
                        ligneDgv[5] = txt_prxB.Text;
                        ligneDgv[6] = txt_prxC.Text;
                        ligneDgv[7] = cb_tpPrd.Text;
                        ligneDgv[8] = DateTime.Now.ToShortDateString();
                        dtnp.Rows.Add(ligneDgv);
                        saved = false;
                        button1.PerformClick();
                        lbl_prdAjt.Text = dtnp.Rows.Count.ToString();

                    }
                    else MessageBox.Show("عدد السلعة يساوي 0, المرجوا إدخال عدد السلعة", "عدد السلعة فارغ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }else MessageBox.Show("أحد الأثمنة غير مقبولة", "خطأ في إدخال الأثمنة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }else MessageBox.Show("المرجو ملأ الحقول الفارغة", "أحد الحقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AjtProduits_Load(object sender, EventArgs e)
        {
            dtaType.Fill(ds, "Types");
            dtaProduit.Fill(ds, "Produits");
            dtaStocke.Fill(ds, "Stocks");
            dtaPxA.Fill(ds, "TypPA");
            dtaPxA.Fill(ds, "TypPB");
            dtaPxA.Fill(ds, "TypPC");
            cb_tpPrd.ValueMember = "NumType";
            cb_tpPrd.DisplayMember = "NomType";
            cb_tpPrd.DataSource = ds.Tables["Types"];
            idT = int.Parse(ds.Tables["Types"].Rows[ds.Tables["Types"].Rows.Count - 1]["NumType"].ToString());
            idP = int.Parse(ds.Tables["Produits"].Rows[ds.Tables["Produits"].Rows.Count - 1]["NumPrd"].ToString());
            dtnp.Columns.Add("رقم السلعة");
            dtnp.Columns.Add("الإسم");
            dtnp.Columns.Add("الكمية");
            dtnp.Columns.Add("الكمية الأدنى");
            dtnp.Columns.Add("ثمن A");
            dtnp.Columns.Add("ثمن B");
            dtnp.Columns.Add("ثمن C");
            dtnp.Columns.Add("النوع");
            dtnp.Columns.Add("تاريخ اللإضافة");
            dgr_nvProd.DataSource = dtnp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txt_nomTp.Text != "")
            {
                idT++;
                DataRow ligne = ds.Tables["Types"].NewRow();
                ligne[0] = idT;
                ligne[1] = txt_nomTp.Text;
                ds.Tables["Types"].Rows.Add(ligne);
                saved = false;
                button3.PerformClick();
            }
            else MessageBox.Show("المرجو ملأ حقل الخاص بنوع السلع", "الحقل الخاص بنوع السلع فارغ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cb_tpPrd_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Acceuil.cnx.Open();
            SQLiteCommandBuilder cmdb = new SQLiteCommandBuilder(dtaType);
            dtaType.Update(ds, "Types");
            cmdb = new SQLiteCommandBuilder(dtaProduit);
            dtaProduit.Update(ds, "Produits");
            cmdb = new SQLiteCommandBuilder(dtaPxA);
            dtaPxA.Update(ds, "TypPA");
            cmdb = new SQLiteCommandBuilder(dtaPxB);
            dtaPxB.Update(ds, "TypPB");
            cmdb = new SQLiteCommandBuilder(dtaPxC);
            dtaPxC.Update(ds, "TypPC");
            cmdb = new SQLiteCommandBuilder(dtaStocke);
            dtaStocke.Update(ds, "Stocks");
            saved = true;
            Acceuil.cnx.Close();
            MessageBox.Show("تم حفض المعلومات بنجاح", " حفض المعلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Acceuil a = new Acceuil();
            if(saved){
                a.RefreshGv();
                Close();
            }
                //    if (rep = )
            //    {
                    
            //    }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_nomPrd.Text = "";
            cb_tpPrd.SelectedValue = 0;
            nud_qtt.Value = 0;
            txt_prxA.Text = "";
            txt_prxB.Text = "";
            txt_prxC.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txt_nomTp.Text = "";
        }

        private void dgr_nvProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgr_nvProd_SelectionChanged(object sender, EventArgs e)
        {
            
        }
    }
}
