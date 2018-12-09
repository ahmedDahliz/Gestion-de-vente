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
    public partial class MdfDette : Form
    {
        public MdfDette()
        {
            InitializeComponent();
        }
        SQLiteDataAdapter dtaDette = new SQLiteDataAdapter("Select * from Dettes", Acceuil.cnx);
        SQLiteDataAdapter dtaClt = new SQLiteDataAdapter("Select * from Clients", Acceuil.cnx);
        DataSet ds = new DataSet();
        int idC;
        bool saved = true;
        private void MdfDette_Load(object sender, EventArgs e)
        {
            dtaDette.Fill(ds, "Dettes");
            dtaClt.Fill(ds, "Client");
            if (ds.Tables["Client"].Rows.Count != 0)
            {
                idC = int.Parse(ds.Tables["Client"].Rows[ds.Tables["Client"].Rows.Count - 1]["NumClt"].ToString());
            }
            else idC = 0;
            DataRow rw = ds.Tables["Client"].NewRow();
            rw["NomClt"] = "إختر إسم";
            rw["NumClt"] = 0;
            ds.Tables["Client"].Rows.InsertAt(rw, 0);
            cb_nmC.ValueMember = "NumClt";
            cb_nmC.DisplayMember = "NomClt";
            cb_nmC.DataSource = ds.Tables["Client"];


        }

        private void button3_Click(object sender, EventArgs e)
        {
            txt_nmC.Text = "";
            txt_pxD.Text = "";
            txt_pxD.Text = "";
            msk_teleC.Clear();
            cb_nmC.SelectedIndex = 0;
        }

        private void cb_nmC_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow[] drC = ds.Tables["Client"].Select("NumClt = "+cb_nmC.SelectedValue.ToString());
            DataRow[] drD = ds.Tables["Dettes"].Select("NuClt = " + cb_nmC.SelectedValue.ToString());
            if (drC.Length > 0 & drD.Length > 0)
            {
                txt_numD.Text = drD[0]["NumDette"].ToString();
                txt_nmC.Text = drC[0]["NomClt"].ToString();
                msk_teleC.Text = drC[0]["tele"].ToString();
                txt_adress.Text = drC[0]["Adresse"].ToString();
                txt_pxD.Text = drD[0]["PrixDette"].ToString();
                label5.Visible = false;
            }
        }

        private void txt_numD_TextChanged(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(txt_numD.Text, out id) || txt_numD.Text == "")
            {
                DataRow[] drD = ds.Tables["Dettes"].Select("NumDette = " + txt_numD.Text);
                if (drD.Length > 0)
                {
                    DataRow[] drC = ds.Tables["Client"].Select("NumClt = " + drD[0]["NuClt"].ToString());
                    if (drC.Length > 0)
                    {
                        txt_nmC.Text = drC[0]["NomClt"].ToString();
                        msk_teleC.Text = drC[0]["tele"].ToString();
                        txt_adress.Text = drC[0]["Adresse"].ToString();
                        txt_pxD.Text = drD[0]["PrixDette"].ToString();
                        cb_nmC.SelectedValue = drC[0]["NumClt"].ToString();
                        label5.Visible = false;
                    }
                }
            }else MessageBox.Show("رقم الدين الذي أدخلته غير مقبول", "خطأ في إدخال رقم الدين", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float pd;
            if (txt_nmC.Text != "" && txt_pxD.Text != "" && txt_adress.Text != "" && msk_teleC.Text != "")
            {
                if (float.TryParse(txt_pxD.Text, out pd))
                {
                   
                    DataView dv = new DataView(ds.Tables["Client"], "NumClt= " + cb_nmC.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);
                    dv[0].BeginEdit();
                    dv[0][1] = txt_nmC.Text;
                    dv[0][2] = msk_teleC.Text;
                    dv[0][3] = txt_adress.Text;
                    dv[0].EndEdit();
                    dv = new DataView(ds.Tables["Dettes"], "NuClt = " + cb_nmC.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);
                    dv[0].BeginEdit();
                    dv[0][1] = pd;
                    dv[0].EndEdit();
                    label5.Visible = true;
                }
                else MessageBox.Show("أحد الأثمنة غير مقبولة", "خطأ في إدخال الأثمنة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("المرجو ملأ الحقول الفارغة", "أحد الحقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Acceuil.cnx.Open();
            ds.Tables["Client"].Rows.RemoveAt(0);
            SQLiteCommandBuilder cmdb = new SQLiteCommandBuilder(dtaClt);
            dtaClt.Update(ds, "Client");
            cmdb = new SQLiteCommandBuilder(dtaDette);
            dtaDette.Update(ds, "Dettes");
            saved = true;
            Acceuil.cnx.Close();
            MessageBox.Show("تم حفض المعلومات بنجاح", " حفض المعلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

        }
        bool ex = true;
        private void button6_Click(object sender, EventArgs e)
        {
            if (saved)
            {
                Close();
            }
            else
            {
                var rep = MessageBox.Show("لم تقم بحفض المعلومات, سيتم إلغاء الإضافات الجديدة !, هل تريد الإستمرار في الخروج ؟ ", "إلغاء العملية", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                if (rep == DialogResult.Yes)
                {
                    ex = false;
                    Close();
                }
            }
        }

        private void MdfDette_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                if (ex)
                {
                    var rep = MessageBox.Show("لم تقم بحفض المعلومات, سيتم إلغاء الإضافات الجديدة !, هل تريد الإستمرار في الخروج ؟ ", "إلغاء العملية", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    e.Cancel = (rep == DialogResult.No);
                }
            }
        }

        private void cb_nmC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_nmC_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        
    }
}
