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
        DataSet ds = new DataSet();
        bool svd = true;
        void saved(object sender, EventArgs e)
        {
            svd = false; 
        }
        private void MdfProduit_Load(object sender, EventArgs e)
        {
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
            SQLiteCommandBuilder cmdb = new SQLiteCommandBuilder(dta);
            dta.Update(ds, "EdtPrd");
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
                frm.GetAllProduct();
                Close();
            }
            else
            {
                var rep = MessageBox.Show("لم تقم بحفض المعلومات, سيتم إلغاء التغييرات الجديدة !, هل تريد الإستمرار في الخروج ؟ ", "إلغاء العملية", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                if (rep == DialogResult.Yes)
                {
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
                frm.GetAllProduct();
                Close();
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float pa, pb, pc;
            if (txt_nmPrd.Text != "" && txt_pa.Text != "" && txt_pb.Text != "" && txt_pc.Text != "")
            {
                if (nud_qtt.Value != 0)
                {
                    if (float.TryParse(txt_pa.Text, out pa) && float.TryParse(txt_pb.Text, out pb) && float.TryParse(txt_pc.Text, out pc))
                    {

                        ds.Tables["EdtPrd"].Rows[0].BeginEdit();
                        ds.Tables["EdtPrd"].Rows[0][1] = txt_nmPrd.Text;
                        ds.Tables["EdtPrd"].Rows[0][2] = nud_qtt.Value;
                        ds.Tables["EdtPrd"].Rows[0][3] = nud_qttMn.Value;
                        ds.Tables["EdtPrd"].Rows[0][4] = txt_pa.Text;
                        ds.Tables["EdtPrd"].Rows[0][5] = txt_pb.Text;
                        ds.Tables["EdtPrd"].Rows[0][6] = txt_pc.Text;
                        ds.Tables["EdtPrd"].Rows[0][7] = cb_tpPrd.SelectedValue;
                        ds.Tables["EdtPrd"].Rows[0].EndEdit();
                       }
                    else MessageBox.Show("أحد الأثمنة غير مقبولة", "خطأ في إدخال الأثمنة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("عدد السلعة يساوي 0, المرجوا إدخال عدد السلعة", "عدد السلعة فارغ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("المرجو ملأ الحقول الفارغة", "أحد الحقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        
    }
}
