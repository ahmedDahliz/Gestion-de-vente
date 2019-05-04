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
        private readonly Acceuil FrmAcc;
        public AffVente()
        {
            InitializeComponent();
        }
        public AffVente(Acceuil frm)
        {
            InitializeComponent();
            FrmAcc = frm;
        }
       
        SQLiteDataAdapter dtaLCmd = new SQLiteDataAdapter("select NumLgCmd as 'رقم', nmClt as 'الزبون' , PrixTotal as 'مجموع الأداء' , DateCmd as 'تاريخ' from Ling_commande", Acceuil.cnx);
        DataSet ds = new DataSet();
        public DataTable GetFilterdFacture(string idF, string nmC, string dateF)
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
            lbl_prxtt.Text = "0";
            foreach (DataRow prd in dst.Tables["Dettefiltrd"].Rows)
            {
                lbl_prxtt.Text = (double.Parse(lbl_prxtt.Text) + double.Parse(prd["مجموع الأداء"].ToString())).ToString();
            }
            dgv_Facture.ClearSelection();
            return dst.Tables["Dettefiltrd"];
        }
        public void RefreshFactures()
        {
            string rqt = "select distinct NumCmd as 'رقم', nmClt as 'الزبون' , PrixTotal as 'مجموع الأداء' , DateCmd as 'تاريخ' from Ling_commande l, Commande c where l.NumLgCmd = c.NumCmd";
            SQLiteDataAdapter da = new SQLiteDataAdapter(rqt, Acceuil.cnx);
            DataSet dst = new DataSet();
            da.Fill(dst, "FctRefresh");
            lbl_VentAp.Text = dst.Tables["FctRefresh"].Rows.Count.ToString();
            lbl_prxtt.Text = "0";
            foreach (DataRow prd in dst.Tables["FctRefresh"].Rows)
            {
                lbl_prxtt.Text = (Decimal.Parse(lbl_prxtt.Text) + Decimal.Parse(prd["مجموع الأداء"].ToString())).ToString();
            }
            dgv_Facture.ClearSelection();
            dgv_Facture.DataSource = dst.Tables["FctRefresh"];
        }
       
        bool first = true;
        private void AffVente_Load(object sender, EventArgs e)
        {
            try{
                dtaLCmd.Fill(ds, "LignCmd");
                dgv_Facture.DataSource = ds.Tables["LignCmd"];
                dgv_Facture.ClearSelection();
                lbl_VentAp.Text = ds.Tables["LignCmd"].Rows.Count.ToString();
                lbl_prxtt.Text = "0";
                foreach (DataRow prd in ds.Tables["LignCmd"].Rows)
                {
                    lbl_prxtt.Text = (double.Parse(lbl_prxtt.Text) + double.Parse(prd["مجموع الأداء"].ToString())).ToString();
                }
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
                    button1.Enabled = (dgv_Facture.SelectedRows.Count == 1);
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
                string file = path + "\\" + "No" + dgv_Facture.CurrentRow.Cells[0].Value.ToString() + "_" + dtn + ".pdf";
                if (File.Exists(file))
                {
                    Acceuil.idPDF = System.Diagnostics.Process.Start(file).Id;
                }
                else { 
                     MessageBox.Show("الفاتورة المختارة غير موجودة في المجلد", "الملف غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString()+" ; Event: "+e.ToString()+"] __ ExceptionMessage : "+ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv_Facture.SelectedRows.Count == 1)
            {
                DateTime dt = DateTime.Parse(dgv_Facture.CurrentRow.Cells[3].Value.ToString());
                string dtn = dt.Day + "_" + dt.Month + "_" + dt.Year;
                string fileName = "\\" + "No" + dgv_Facture.CurrentRow.Cells[0].Value.ToString() + "_" + dtn + ".pdf";
                AjtVente mdVnt = new AjtVente(int.Parse(dgv_Facture.CurrentRow.Cells[0].Value.ToString()), this, fileName, FrmAcc);
                mdVnt.ShowDialog();
            }
        }

        private void dgv_Facture_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_Facture.SelectedRows.Count == 1)
                {
                    DateTime dt = DateTime.Parse(dgv_Facture.CurrentRow.Cells[3].Value.ToString());
                    string dtn = dt.Day + "_" + dt.Month + "_" + dt.Year;
                    string fileName = "\\" + "No" + dgv_Facture.CurrentRow.Cells[0].Value.ToString() + "_" + dtn + ".pdf";
                    AjtVente mdVnt = new AjtVente(int.Parse(dgv_Facture.CurrentRow.Cells[0].Value.ToString()), this, fileName, FrmAcc);
                    mdVnt.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }
    }
}
