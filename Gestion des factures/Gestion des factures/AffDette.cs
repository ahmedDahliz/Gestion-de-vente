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
using System.Transactions;

namespace Gestion_des_factures
{
    public partial class AffDette : Form
    {
        public AffDette()
        {
            InitializeComponent();
        }
        SQLiteDataAdapter dta = new SQLiteDataAdapter("Select d.NumDette as 'الرقم', c.NomClt as 'إسم الزبون', c.Tele 'هاتف الزبون' , c.Adresse as 'عنوان الزبون', d.PrixDette as 'ثمن الدين', d.DateDette as 'تاريخ الإضافة' from Dettes d, Clients c where d.NuClt = c.NumClt", Acceuil.cnx);
        DataSet ds = new DataSet();
        void GetDette() {
            dta.Fill(ds, "Dettes");
            dgv_affDette.DataSource = ds.Tables["Dettes"];
            lbl_nmDett.Text = ds.Tables["Dettes"].Rows.Count.ToString();
        }
        DataTable GetFilterdDette(string idD, string nmC, string tele, string pxd, string dateD) { 

            String flNum = (idD != "") ? " AND d.NumDette = "+ idD : "";
            String flNom = (nmC != "") ? " AND c.NomClt LIKE '%" + nmC + "%'" : "";
            String flTele = (tele != "") ? " AND c.Tele LIKE '%" + tele + "%'" : "";
            String flpx = (pxd != "") ? " AND d.PrixDette LIKE '%" + pxd + "%'" : "";
            String flDate = (!ch_ShDt.Checked) ? " AND d.DateDette = '" + dateD + "'" : "";
            string rqt = "Select d.NumDette as 'الرقم', c.NomClt as 'إسم الزبون', c.Tele 'هاتف الزبون' , c.Adresse as 'عنوان الزبون', d.PrixDette as 'ثمن الدين', d.DateDette as 'تاريخ الإضافة' " +
                "from Dettes d, Clients c where d.NuClt = c.NumClt " +
                flNum + " " + flNom + " " + flTele + " " + flpx + " " + flDate;
            SQLiteDataAdapter da = new SQLiteDataAdapter(rqt, Acceuil.cnx);
            DataSet dst = new DataSet();
            da.Fill(dst, "Dettefiltrd");
            lbl_nmDett.Text = dst.Tables["Dettefiltrd"].Rows.Count.ToString();
            dgv_affDette.ClearSelection();
            return dst.Tables["Dettefiltrd"];

        }
        
        private void AffDette_Load(object sender, EventArgs e)
        {
            try {
             GetDette();
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
            try{
                txt_numD.Text = "";
                txt_nmC.Text = "";
                txt_teleC.Text = "";
                txt_pxD.Text = "";
                ch_ShDt.Checked = true;
            }catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString()+" ; Event: "+e.ToString()+"] __ ExceptionMessage : "+ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void txt_nmV_TextChanged_1(object sender, EventArgs e)
        {
            try{
                int id,tele;
                float px;
                if (int.TryParse(txt_numD.Text, out id) || txt_numD.Text == "")
                {
                    if (int.TryParse(txt_teleC.Text, out tele) || txt_teleC.Text == "")
                    {
                        if (float.TryParse(txt_pxD.Text, out px) || txt_pxD.Text == "")
                        {
                            dgv_affDette.DataSource = GetFilterdDette(txt_numD.Text, txt_nmC.Text, txt_teleC.Text, txt_pxD.Text, dtp_datAjout.Value.ToShortDateString());

                        }
                        else MessageBox.Show("الثمن الذي أدخلته غير مقبول", "خطأ في إدخال ثمن الدين ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("رقم الهاتف الذي أدخلته غير مقبول", "خطأ في إدخال رقم الهاتف", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("رقم الدين الذي أدخلته غير مقبول", "خطأ في إدخال رقم الدين", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dtp_datAjout.Enabled = !(ch_ShDt.Checked);
        }
        bool dl = false;
        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_affDette.SelectedRows.Count == 1)
                {
                    var rep = MessageBox.Show("هل تريد حذف الدين المختار؟  ", "حذف الدين", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    if (rep == DialogResult.Yes)
                    {
                        using (TransactionScope trans = new TransactionScope())
                        {
                            Acceuil.cnx.Open();
                            int idDt = int.Parse(ds.Tables["Dettes"].Rows[dgv_affDette.CurrentRow.Index][0].ToString());
                            ds.Tables["Dettes"].Rows.Remove((ds.Tables["Dettes"].Select("الرقم = " + idDt)[0]));
                            SQLiteDataAdapter toDelDabD = new SQLiteDataAdapter("Select * from Dettes", Acceuil.cnx);
                            toDelDabD.Fill(ds, "DetteToDel");
                            SQLiteDataAdapter toDelDabC = new SQLiteDataAdapter("Select * from Clients", Acceuil.cnx);
                            toDelDabC.Fill(ds, "ClientToDel");
                            DataView dvD = new DataView(ds.Tables["DetteToDel"], "NumDette = " + idDt, "", DataViewRowState.CurrentRows);
                            string idClt = dvD.ToTable().Rows[0]["NuClt"].ToString();
                            DataView dvC = new DataView(ds.Tables["ClientToDel"], "NumClt = " + idClt, "", DataViewRowState.CurrentRows);
                            dvD[0].Delete();
                            dvC[0].Delete();
                            SQLiteCommandBuilder cmdb = new SQLiteCommandBuilder(toDelDabD);
                            toDelDabD.Update(ds, "DetteToDel");
                            cmdb = new SQLiteCommandBuilder(toDelDabC);
                            toDelDabC.Update(ds, "ClientToDel");
                            lbl_nmDett.Text = ds.Tables["Dettes"].Rows.Count.ToString();
                            Acceuil.cnx.Close();
                            trans.Complete();
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void dgv_affDette_SelectionChanged(object sender, EventArgs e)
        {
            button1.Enabled = (dgv_affDette.SelectedRows.Count == 1);
        }

        private void AffDette_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dl)
            {
               
                
            }
        }
    }
}
