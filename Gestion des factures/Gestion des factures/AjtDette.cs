using System;
using System.Transactions;
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
    public partial class AjtDette : Form
    {
        public AjtDette()
        {
            InitializeComponent();
        }
        SQLiteDataAdapter dtaDette = new SQLiteDataAdapter("Select * from Dettes", Acceuil.cnx);
        SQLiteDataAdapter dtaClt = new SQLiteDataAdapter("Select * from Clients", Acceuil.cnx);
        DataSet ds = new DataSet();
        DataTable dtnp = new DataTable();
        bool saved = true;
        int idC;
        bool CheckInDt(DataTable dt, string val, string Column)
        {
            DataRow[] found = dt.Select(Column + " = " + val);
            if (found.Length != 0)
            {
                return true;
            }
            return false;
        }
        private void AjtDette_Load(object sender, EventArgs e)
        {
            try {
                SQLiteDataAdapter dtaId = new SQLiteDataAdapter("Select * from sqlite_sequence where name='Clients'", Acceuil.cnx);
                dtaDette.Fill(ds, "Dettes");
                dtaClt.Fill(ds, "Client");
                dtaId.Fill(ds, "IdC");
                idC = int.Parse(ds.Tables["IdC"].Rows[0]["seq"].ToString());
                dtnp.Columns.Add("الرقم");
                dtnp.Columns.Add("إسم الزبون");
                dtnp.Columns.Add("الهاتف");
                dtnp.Columns.Add("العنوان");
                dtnp.Columns.Add("مبلغ الدين");
                dgv_AjtDette.DataSource = dtnp;
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
            try
            {
                float pd;
                if (txt_nmClt.Text !="")
                {
                    if (!CheckInDt(ds.Tables["Client"], "'" + txt_nmClt.Text + "'", "NomClt"))
                    {
                        if (txt_pxDtt.Text == "")
                        {
                            txt_pxDtt.Text = "0";
                        }
                        if (float.TryParse(txt_pxDtt.Text, out pd))
                        {
                            DataRow ligneC = ds.Tables["Client"].NewRow();
                            DataRow ligneD = ds.Tables["Dettes"].NewRow();
                            DataRow ligneDgv = dtnp.NewRow();
                            ligneC[1] = txt_nmClt.Text;
                            ligneC[2] = mst_teleClt.Text.Replace(" ", "");
                            ligneC[3] = txt_Adrss.Text;
                            ds.Tables["Client"].Rows.Add(ligneC);
                            idC++;
                            ligneD[1] = txt_pxDtt.Text;
                            ligneD[2] = idC;
                            ligneD[3] = DateTime.Now.ToShortDateString();
                            ds.Tables["Dettes"].Rows.Add(ligneD);
                            ligneDgv[0] = idC;
                            ligneDgv[1] = txt_nmClt.Text;
                            ligneDgv[2] = mst_teleClt.Text.Replace(" ", "");
                            ligneDgv[3] = txt_Adrss.Text;
                            ligneDgv[4] = txt_pxDtt.Text;
                            dtnp.Rows.Add(ligneDgv);
                            saved = false;
                            button3.PerformClick();
                            lbl_DetteAjt.Text = dtnp.Rows.Count.ToString();
                            dgv_AjtDette.ClearSelection();
                        }
                        else MessageBox.Show("ثمن الدين غير مقبول", "خطأ في إدخال ثمن الدين", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    }
                    else MessageBox.Show("إسم الزبون الذي أذخلته موجود سابقا ", "إسم الزبون مكرر", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                }
                else MessageBox.Show(" المرجو إدخال إسم الزبون", "إسم الزبون فارغ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txt_nmClt.Text = "";
            txt_Adrss.Text = "";
            txt_pxDtt.Text = "";
            mst_teleClt.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    Acceuil.cnx.Open();
                    SQLiteCommandBuilder cmdb = new SQLiteCommandBuilder(dtaClt);
                    dtaClt.Update(ds, "Client");
                    cmdb = new SQLiteCommandBuilder(dtaDette);
                    dtaDette.Update(ds, "Dettes");
                    saved = true;
                    dtnp.Rows.Clear();
                    Acceuil.cnx.Close();
                    trans.Complete();
                    MessageBox.Show("تم حفض المعلومات بنجاح", " حفض المعلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
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

        private void AjtDette_FormClosing(object sender, FormClosingEventArgs e)
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
        String numC, nomC;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_AjtDette.SelectedRows.Count == 1)
                {
                    numC = dtnp.Rows[dgv_AjtDette.CurrentRow.Index][0].ToString();
                    nomC = dtnp.Rows[dgv_AjtDette.CurrentRow.Index][1].ToString();
                    txt_nmClt.Text = dgv_AjtDette.CurrentRow.Cells[1].Value.ToString();
                    mst_teleClt.Text = dgv_AjtDette.CurrentRow.Cells[2].Value.ToString();
                    txt_Adrss.Text = dgv_AjtDette.CurrentRow.Cells[3].Value.ToString();
                    txt_pxDtt.Text = dgv_AjtDette.CurrentRow.Cells[4].Value.ToString();
                    button5.Visible = true;
                    button4.Visible = false;
                    button2.Enabled = false;
                    dgv_AjtDette.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void dgv_AjtDette_SelectionChanged(object sender, EventArgs e)
        {
            button2.Enabled = (dgv_AjtDette.SelectedRows.Count == 1);
            button7.Enabled = (dgv_AjtDette.SelectedRows.Count == 1);
        }

        private void txt_nmClt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                float pd;
                if (txt_nmClt.Text != "" && txt_pxDtt.Text != "")
                {
                    if (!CheckInDt(ds.Tables["Client"], "'" + txt_nmClt.Text + "'", "NomClt"))
                    {
                        if (float.TryParse(txt_pxDtt.Text, out pd))
                        {
                            int iC = ds.Tables["Client"].Rows.IndexOf(ds.Tables["Client"].Select("NomClt = '" + nomC + "'")[0]);
                            int iD = ds.Tables["Dettes"].Rows.IndexOf(ds.Tables["Dettes"].Select("NuClt = " + numC)[0]);
                            int idg = dtnp.Rows.IndexOf(dtnp.Select("الرقم = " + numC)[0]);
                            //Update DataTable Client
                            ds.Tables["Client"].Rows[iC].BeginEdit();
                            ds.Tables["Client"].Rows[iC]["NomClt"] = txt_nmClt.Text;
                            ds.Tables["Client"].Rows[iC]["Tele"] = mst_teleClt.Text.Replace(" ", "");
                            ds.Tables["Client"].Rows[iC]["Adresse"] = txt_Adrss.Text;
                            ds.Tables["Client"].Rows[iC].EndEdit();
                            //Update DataTable Dettes
                            ds.Tables["Dettes"].Rows[iD].BeginEdit();
                            ds.Tables["Dettes"].Rows[iD]["PrixDette"] = txt_pxDtt.Text;
                            ds.Tables["Dettes"].Rows[iD].EndEdit();
                            //Update DataTable DTNP of GridView
                            dtnp.Rows[idg].BeginEdit();
                            dtnp.Rows[idg]["إسم الزبون"] = txt_nmClt.Text;
                            dtnp.Rows[idg]["الهاتف"] = mst_teleClt.Text.Replace(" ", "");
                            dtnp.Rows[idg]["العنوان"] = txt_Adrss.Text;
                            dtnp.Rows[idg]["مبلغ الدين"] = txt_pxDtt.Text;
                            dtnp.Rows[idg].EndEdit();
                            button5.Visible = false;
                            button4.Visible = true;
                            button3.PerformClick();
                            MessageBox.Show("تم تعديل المعلومات بنجاح", " تعديل المعلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                        }
                        else MessageBox.Show("أحد الأثمنة غير مقبولة", "خطأ في إدخال الأثمنة", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    }
                    else MessageBox.Show("إسم الزبون الذي أذخلته موجود سابقا ", "إسم الزبون مكرر", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                }
                else MessageBox.Show("الإسم الزبون و الثمن ضروريان  ", "أحد الحقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_AjtDette.SelectedRows.Count == 1)
                {
                    var rep = MessageBox.Show("هل تريد حدف الدين المختار  ", "حذف الدين", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    if (rep == DialogResult.Yes)
                    {
                        numC = dtnp.Rows[dgv_AjtDette.CurrentRow.Index][0].ToString();
                        nomC = dtnp.Rows[dgv_AjtDette.CurrentRow.Index][1].ToString();
                        ds.Tables["Client"].Rows.Remove((ds.Tables["Client"].Select("NomClt = '" + nomC + "'")[0]));
                        ds.Tables["Dettes"].Rows.Remove((ds.Tables["Dettes"].Select("NuClt = '" + numC + "'")[0]));
                        dtnp.Rows.RemoveAt(dgv_AjtDette.CurrentRow.Index);
                        lbl_DetteAjt.Text = dtnp.Rows.Count.ToString();
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

        private void txt_pxDtt_TextChanged(object sender, EventArgs e)
        {

        }

        private void mst_teleClt_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
