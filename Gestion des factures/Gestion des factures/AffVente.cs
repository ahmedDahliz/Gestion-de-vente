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
    public partial class AffVente : Form
    {
        public AffVente()
        {
            InitializeComponent();
        }
       
        SQLiteDataAdapter dtaLCmd = new SQLiteDataAdapter("select NumLgCmd as 'رقم', nmClt as 'الزبون' , PrixTotal as 'مجموع الأداء' , DateCmd as 'تاريخ' from Ling_commande", Acceuil.cnx);
        DataSet ds = new DataSet();
        DataTable GetFilterdFacture(string idF, string nmC, string dateF)
        {

            String flNum = (idF != "") ? " AND NumLgCmd = " + idF : "";
            String flNom = (nmC != "") ? " AND nmClt LIKE '%" + nmC + "%'" : "";
            String flDate = (!ch_ShDt.Checked) ? " AND DateCmd = '" + dateF + "'" : "";
            string rqt = "select distinct NumCmd as 'رقم', nmClt as 'الزبون' , PrixTotal as 'مجموع الأداء' , DateCmd as 'تاريخ' from Ling_commande l, Commande c where l.NumLgCmd = c.NumCmd" +
                flNum + " " + flNom + " " + flDate;
            SQLiteDataAdapter da = new SQLiteDataAdapter(rqt, Acceuil.cnx);
            DataSet dst = new DataSet();
            da.Fill(dst, "Dettefiltrd");
            lbl_VentAp.Text = dst.Tables["Dettefiltrd"].Rows.Count.ToString();
            dgv_Facture.ClearSelection();
            return dst.Tables["Dettefiltrd"];
        }
        bool first = true;
        private void AffVente_Load(object sender, EventArgs e)
        {
            try{
                dtaLCmd.Fill(ds, "LignCmd");
                dgv_Facture.DataSource = ds.Tables["LignCmd"];
                dgv_Facture.ClearSelection();
                lbl_VentAp.Text = ds.Tables["LignCmd"].Rows.Count.ToString();
                first = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try {
                dgv_Facture.DataSource = GetFilterdFacture(txt_numFact.Text, txt_nomC.Text, dtp_dateFact.Value.ToShortDateString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void ch_ShDt_CheckedChanged(object sender, EventArgs e)
        {
            try{
                dtp_dateFact.Enabled = !ch_ShDt.Checked;
                if (ch_ShDt.Checked)
                {
                    dgv_Facture.DataSource = GetFilterdFacture(txt_numFact.Text, txt_nomC.Text, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void dtp_dateFact_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dgv_Facture.DataSource = GetFilterdFacture(txt_numFact.Text, txt_nomC.Text, dtp_dateFact.Value.ToShortDateString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void txt_numFact_TextChanged(object sender, EventArgs e)
        {
            try {
                int n;
                if (int.TryParse(txt_numFact.Text, out n) || txt_numFact.Text == "")
                {
                    dgv_Facture.DataSource = GetFilterdFacture(txt_numFact.Text, txt_nomC.Text, dtp_dateFact.Value.ToShortDateString());
                } else MessageBox.Show(" رقم الفاتورة الذي أدخلته غير مقبول", "خطأ في إدخال رقم الفاتورة ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void dgv_Facture_SelectionChanged(object sender, EventArgs e)
        {
            try {
                if (!first)
                {
                    button2.Enabled = (dgv_Facture.SelectedRows.Count == 1);
                    if (dgv_Facture.SelectedRows.Count == 1)
                    {
                        SQLiteDataAdapter dtaCmd = new SQLiteDataAdapter("select p.NumPrd 'رقم المنتوج', p.Desingation 'إسم المنتوج', c.QttCmd 'الكمية', c.PrixU 'ثمن الوحدة', c.PrixCmd 'الواجب'  from Produits p, Commande c where p.NumPrd = c.NuPrd AND c.NumCmd = " + dgv_Facture.CurrentRow.Cells[0].Value.ToString(), Acceuil.cnx);
                        if (ds.Tables["Cmd"] != null) ds.Tables["Cmd"].Rows.Clear();
                        dtaCmd.Fill(ds, "Cmd");
                        dgv_DetailFacture.DataSource = ds.Tables["Cmd"];
                        lbl_NbrProd.Text = ds.Tables["Cmd"].Rows.Count.ToString();
                        first = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txt_nomC.Text = "";
            txt_numFact.Text = "";
            ch_ShDt.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Factures";
                DirectoryInfo di = Directory.CreateDirectory(path);
                DateTime dt = DateTime.Parse(dgv_Facture.CurrentRow.Cells[3].Value.ToString());
                string dtn = dt.Day + "_" + dt.Month + "_" + dt.Year;
                System.Diagnostics.Process.Start(path + "\\" + "N" + dgv_Facture.CurrentRow.Cells[0].Value.ToString() + "_" + dtn + ".pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString()+" ; Event: "+e.ToString()+"] __ ExceptionMessage : "+ex.Message;
                Acceuil.WriteLog(Err);
            }
        }
    }
}
