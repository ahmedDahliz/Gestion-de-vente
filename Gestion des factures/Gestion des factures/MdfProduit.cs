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
    public partial class MdfProduit : Form
    {
        private readonly int idpr;
        private readonly AffProduit frm;
        public MdfProduit(int idP, AffProduit f)
        {
            InitializeComponent();
            idpr = idP;
            frm = f;

        }
        public MdfProduit()
        {
            InitializeComponent();
        }
        
        SQLiteDataAdapter dta,dt2;
        SQLiteDataAdapter dtaProduit = new SQLiteDataAdapter("Select * from Produits", Acceuil.cnx);
        SQLiteDataAdapter dtaStocke = new SQLiteDataAdapter("Select * from Stocks", Acceuil.cnx);
        SQLiteDataAdapter dtaPxA = new SQLiteDataAdapter("Select * from TypePrixA", Acceuil.cnx);
        SQLiteDataAdapter dtaPxB = new SQLiteDataAdapter("Select * from TypePrixB", Acceuil.cnx);
        SQLiteDataAdapter dtaPxC = new SQLiteDataAdapter("Select * from TypePrixC", Acceuil.cnx);
        DataSet ds = new DataSet();
        bool svd = true;
        bool ex = true;
        void saved(object sender, EventArgs e)
        {
            label3.Visible = false;
        }
        private void MdfProduit_Load(object sender, EventArgs e)
        {
            dtaProduit.Fill(ds, "Produits");
            dtaStocke.Fill(ds, "Stocks");
            dtaPxA.Fill(ds, "TypPA");
            dtaPxB.Fill(ds, "TypPB");
            dtaPxC.Fill(ds, "TypPC");
            dta = new SQLiteDataAdapter("select p.NumPrd, p.Desingation, s.QttProd, s.QttPrsFini, pa.Prix, pb.Prix, pc.prix, p.NuType from Stocks s, Produits p, TypePrixA pa, TypePrixB pb, TypePrixC pc where s.NuPrd = p.NumPrd AND p.NumPrd = pa.NuPrd AND p.NumPrd =  pb.NuPrd AND p.NumPrd = pc.NuPrd AND p.NumPrd = " + idpr, Acceuil.cnx);
            dta.Fill(ds, "EdtPrd");
            dt2 = new SQLiteDataAdapter("select * from Types", Acceuil.cnx);
            dt2.Fill(ds, "types");
            dt2.Fill(ds, "typesMdf");
            cb_tpPrd.ValueMember = "NumType";
            cb_tpPrd.DisplayMember = "NomType";
            cb_chngType.ValueMember = "NumType";
            cb_chngType.DisplayMember = "NomType";
            cb_tpPrd.DataSource = ds.Tables["types"];
            cb_chngType.DataSource = ds.Tables["typesMdf"];
            label1.Text += idpr;
            txt_nmPrd.Text = ds.Tables["EdtPrd"].Rows[0][1].ToString();
            nud_qtt.Value = int.Parse(ds.Tables["EdtPrd"].Rows[0][2].ToString());
            nud_qttMn.Value = int.Parse(ds.Tables["EdtPrd"].Rows[0][3].ToString());
            txt_pa.Text = ds.Tables["EdtPrd"].Rows[0][4].ToString();
            txt_pb.Text = ds.Tables["EdtPrd"].Rows[0][5].ToString();
            txt_pc.Text = ds.Tables["EdtPrd"].Rows[0][6].ToString();
            cb_tpPrd.SelectedValue = ds.Tables["EdtPrd"].Rows[0][7].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Acceuil.cnx.Open();
            SQLiteCommandBuilder cmdb = new SQLiteCommandBuilder(dtaProduit);
            dtaProduit.Update(ds, "Produits");
            cmdb = new SQLiteCommandBuilder(dtaPxA);
            dtaPxA.Update(ds, "TypPA");
            cmdb = new SQLiteCommandBuilder(dtaPxB);
            dtaPxB.Update(ds, "TypPB");
            cmdb = new SQLiteCommandBuilder(dtaPxC);
            dtaPxC.Update(ds, "TypPC");
            cmdb = new SQLiteCommandBuilder(dtaStocke);
            dtaStocke.Update(ds, "Stocks");
            cmdb = new SQLiteCommandBuilder(dt2);
            dt2.Update(ds, "typesMdf");
            Acceuil.cnx.Close();
            svd = true;
            MessageBox.Show("تم حفض التغييرات بنجاح", " حفض التغييرات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (svd)
            {
                Close();
            }
            else
            {
                var rep = MessageBox.Show("لم تقم بحفض المعلومات, سيتم إلغاء التغييرات الجديدة !, هل تريد الإستمرار في الخروج ؟ ", "إلغاء العملية", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                if (rep == DialogResult.Yes)
                {
                    svd = true;
                    ex = false;
                    Close();
                }
            }
        }
        int i;
        private void cb_chngType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_nmType.Text = cb_chngType.Text;
            i = int.Parse(cb_chngType.SelectedIndex.ToString());
        }

        private void MdfProduit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (svd)
            {
                if (ex) frm.RefreshAffPrd();
            }
            else
            {
                var rep = MessageBox.Show("لم تقم بحفض المعلومات, سيتم إلغاء التغييرات الجديدة !, هل تريد الإستمرار في الخروج ؟ ", "إلغاء العملية", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                e.Cancel = (rep == DialogResult.No);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds.Tables["typesMdf"].Rows[i].BeginEdit();
            ds.Tables["typesMdf"].Rows[i][1] = txt_nmType.Text;
            ds.Tables["typesMdf"].Rows[i].EndEdit();
            ds.Tables["types"].Rows[i].BeginEdit();
            ds.Tables["types"].Rows[i][1] = txt_nmType.Text;
            ds.Tables["types"].Rows[i].EndEdit();
            svd = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            float pa, pb, pc;
            if (txt_nmPrd.Text != "" && txt_pa.Text != "" && txt_pb.Text != "" && txt_pc.Text != "")
            {
                if (float.TryParse(txt_pa.Text, out pa) && float.TryParse(txt_pb.Text, out pb) && float.TryParse(txt_pc.Text, out pc))
                {
                    DataView dv = new DataView(ds.Tables["Produits"], "NumPrd = " + idpr, "", DataViewRowState.CurrentRows);
                    dv[0].BeginEdit();
                    dv[0][1] = txt_nmPrd.Text;
                    dv[0][2] = cb_tpPrd.SelectedValue;
                    dv[0].EndEdit();
                    dv = new DataView(ds.Tables["Stocks"], "NuPrd = " + idpr, "", DataViewRowState.CurrentRows);
                    dv[0].BeginEdit();
                    dv[0][1] = nud_qtt.Value;
                    dv[0][2] = nud_qttMn.Value;
                    dv[0].EndEdit();
                    dv = new DataView(ds.Tables["TypPA"], "NuPrd = " + idpr, "", DataViewRowState.CurrentRows);
                    dv[0].BeginEdit();
                    dv[0][1] = pa;
                    dv[0].EndEdit();
                    dv = new DataView(ds.Tables["TypPB"], "NuPrd = " + idpr, "", DataViewRowState.CurrentRows);
                    dv[0].BeginEdit();
                    dv[0][1] = pb;
                    dv[0].EndEdit();
                    dv = new DataView(ds.Tables["TypPC"], "NuPrd = " + idpr, "", DataViewRowState.CurrentRows);
                    dv[0].BeginEdit();
                    dv[0][1] = pc;
                    dv[0].EndEdit();
                    ds.Tables["EdtPrd"].Rows[0].EndEdit();
                    label3.Visible = true;
                }
                else MessageBox.Show("أحد الأثمنة غير مقبولة", "خطأ في إدخال الأثمنة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("المرجو ملأ الحقول الفارغة", "أحد الحقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cb_tpPrd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
