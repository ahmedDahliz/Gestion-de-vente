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
        private readonly Acceuil FrmAcc;
        public AjtProduits(Acceuil ac)
        {
            InitializeComponent();
            FrmAcc = ac;
        }
        SQLiteDataAdapter dtaType = new SQLiteDataAdapter("Select * from Types", Acceuil.cnx);
        SQLiteDataAdapter dtaProduit = new SQLiteDataAdapter("Select * from Produits", Acceuil.cnx);
        SQLiteDataAdapter dtaStocke = new SQLiteDataAdapter("Select * from Stocks", Acceuil.cnx);
        SQLiteDataAdapter dtaPxA = new SQLiteDataAdapter("Select * from TypePrixA", Acceuil.cnx);
        SQLiteDataAdapter dtaPxB = new SQLiteDataAdapter("Select * from TypePrixB", Acceuil.cnx);
        SQLiteDataAdapter dtaPxC = new SQLiteDataAdapter("Select * from TypePrixC", Acceuil.cnx);
        DataSet ds = new DataSet();
        DataTable dtnp = new DataTable();
        DataTable dtnt = new DataTable();
        int idT,idP;
        Boolean saved = true;
        private void nud_qttMn_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void nud_qtt_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                nud_qttMn.Maximum = nud_qtt.Value;
                nud_qttMn.Enabled = (nud_qtt.Value > 0) ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }
        bool CheckInDt(DataTable dt, string val, string Column)
        {
            DataRow[] found = dt.Select(Column + " = " + val);
            if (found.Length != 0)
            {
                return true;
            }
            return false;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                float pac, pa, pb, pc;
                if (txt_nomPrd.Text != "" && txt_prxAch.Text != ""  && txt_prxA.Text != "" && txt_prxB.Text != "" && txt_prxC.Text != "")
                {
                    if (!CheckInDt(ds.Tables["Produits"], "'" + txt_nomPrd.Text + "'", "Desingation"))
                    {
                        if (nud_qtt.Value != 0)
                        {
                            if (float.TryParse(txt_prxAch.Text, out pac) && float.TryParse(txt_prxA.Text, out pa) && float.TryParse(txt_prxB.Text, out pb) && float.TryParse(txt_prxB.Text, out pc))
                            {
                                DataRow ligneP = ds.Tables["Produits"].NewRow();
                                DataRow ligneS = ds.Tables["Stocks"].NewRow();
                                DataRow lignePrA = ds.Tables["TypPA"].NewRow();
                                DataRow lignePrB = ds.Tables["TypPB"].NewRow();
                                DataRow lignePrC = ds.Tables["TypPC"].NewRow();
                                DataRow ligneDgv = dtnp.NewRow();
                                ligneP[1] = txt_nomPrd.Text;
                                ligneP[2] = cb_tpPrd.SelectedValue.ToString();
                                ligneP[3] = txt_prxAch.Text;
                                ds.Tables["Produits"].Rows.Add(ligneP);
                                idP++;
                                lignePrA[1] = txt_prxA.Text;
                                lignePrA[2] = idP;
                                ds.Tables["TypPA"].Rows.Add(lignePrA);
                                lignePrB[1] = txt_prxB.Text;
                                lignePrB[2] = idP;
                                ds.Tables["TypPB"].Rows.Add(lignePrB);
                                lignePrC[1] = txt_prxC.Text;
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
                                ligneDgv[4] = txt_prxAch.Text;
                                ligneDgv[5] = txt_prxA.Text;
                                ligneDgv[6] = txt_prxB.Text;
                                ligneDgv[7] = txt_prxC.Text;
                                ligneDgv[8] = cb_tpPrd.Text;
                                ligneDgv[9] = DateTime.Now.ToShortDateString();
                                dtnp.Rows.Add(ligneDgv);
                                saved = false;
                                button1.PerformClick();
                                lbl_prdAjt.Text = dtnp.Rows.Count.ToString();
                                dgr_nvProd.ClearSelection();


                            }
                            else MessageBox.Show("أحد الأثمنة غير مقبولة", "خطأ في إدخال الأثمنة", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else MessageBox.Show("عدد السلعة يساوي 0, المرجوا إدخال عدد السلعة", "عدد السلعة فارغ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("إسم المنتوج الذي أذخلته موجود سابقا ", "إسم المنتوج مكرر", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                }
                else MessageBox.Show("المرجو ملأ الحقول الفارغة", "أحد الحقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void AjtProduits_Load(object sender, EventArgs e)
        {
            try
            {
                SQLiteDataAdapter dtaIdP = new SQLiteDataAdapter("Select * from sqlite_sequence where name='Produits'", Acceuil.cnx);
                SQLiteDataAdapter dtaIdT = new SQLiteDataAdapter("Select * from sqlite_sequence where name='Types'", Acceuil.cnx);
                dtaType.Fill(ds, "Types");
                dtaProduit.Fill(ds, "Produits");
                dtaStocke.Fill(ds, "Stocks");
                dtaPxA.Fill(ds, "TypPA");
                dtaPxB.Fill(ds, "TypPB");
                dtaPxC.Fill(ds, "TypPC");
                dtaIdP.Fill(ds, "idP");
                dtaIdT.Fill(ds, "idT");
                cb_tpPrd.ValueMember = "NumType";
                cb_tpPrd.DisplayMember = "NomType";
                cb_tpPrd.DataSource = ds.Tables["Types"];
                idT = int.Parse(ds.Tables["IdT"].Rows[0]["seq"].ToString());
                idP = int.Parse(ds.Tables["IdP"].Rows[0]["seq"].ToString());
                dtnp.Columns.Add("الرقم");
                dtnp.Columns.Add("الإسم");
                dtnp.Columns.Add("الكمية");
                dtnp.Columns.Add("الكمية الأدنى");
                dtnp.Columns.Add("ثمن الشراء");
                dtnp.Columns.Add("ثمن A");
                dtnp.Columns.Add("ثمن B");
                dtnp.Columns.Add("ثمن C");
                dtnp.Columns.Add("النوع");
                dtnp.Columns.Add("تاريخ اللإضافة");
                dtnt.Columns.Add("NumType");
                dtnt.Columns.Add("NomType");
                cb_nvType.ValueMember = "NumType";
                cb_nvType.DisplayMember = "NomType";
                cb_nvType.DataSource = dtnt;
                dgr_nvProd.DataSource = dtnp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nomTp.Text != "")
                {
                    idT++;
                    DataRow ligne = dtnt.NewRow();
                    ligne[0] = idT;
                    ligne[1] = txt_nomTp.Text;
                    dtnt.Rows.Add(ligne);
                    ligne = ds.Tables["Types"].NewRow();
                    ligne[0] = idT;
                    ligne[1] = txt_nomTp.Text;
                    ds.Tables["Types"].Rows.Add(ligne);
                    saved = false;
                    button3.PerformClick();
                }
                else MessageBox.Show("المرجو ملأ حقل الخاص بنوع السلع", "الحقل الخاص بنوع السلع فارغ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
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
                MessageBox.Show("تم حفض المعلومات بنجاح", " حفض المعلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }
        bool ex = true;
        private void button6_Click(object sender, EventArgs e)
        {
            if(saved){
                FrmAcc.RefreshAccui();
                Close();
            }else {
                var rep = MessageBox.Show("لم تقم بحفض المعلومات, سيتم إلغاء الإضافات الجديدة !, هل تريد الإستمرار في الخروج ؟ ","إلغاء العملية", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                if (rep == DialogResult.Yes) {
                    ex = false;
                    Close();
                }      
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_nomPrd.Text = "";
            cb_tpPrd.SelectedValue = 0;
            nud_qtt.Value = 0;
            txt_prxAch.Text = "";
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
            button7.Enabled = (dgr_nvProd.SelectedRows.Count == 1);
            button9.Enabled = (dgr_nvProd.SelectedRows.Count == 1);
        }
        public string DesP,idPr;
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgr_nvProd.SelectedRows.Count == 1)
                {
                    DesP = dtnp.Rows[dgr_nvProd.CurrentRow.Index][1].ToString();
                    idPr = dtnp.Rows[dgr_nvProd.CurrentRow.Index][0].ToString();
                    txt_nomPrd.Text = dgr_nvProd.CurrentRow.Cells[1].Value.ToString();
                    nud_qtt.Value = int.Parse(dgr_nvProd.CurrentRow.Cells[2].Value.ToString());
                    nud_qttMn.Value = int.Parse(dgr_nvProd.CurrentRow.Cells[3].Value.ToString());
                    txt_prxAch.Text = dgr_nvProd.CurrentRow.Cells[4].Value.ToString();
                    txt_prxA.Text = dgr_nvProd.CurrentRow.Cells[5].Value.ToString();
                    txt_prxB.Text = dgr_nvProd.CurrentRow.Cells[6].Value.ToString();
                    txt_prxC.Text = dgr_nvProd.CurrentRow.Cells[7].Value.ToString();
                    cb_tpPrd.SelectedIndex = cb_tpPrd.FindStringExact(dgr_nvProd.CurrentRow.Cells[8].Value.ToString());
                    button8.Visible = true;
                    button2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                int iP = ds.Tables["Produits"].Rows.IndexOf(ds.Tables["Produits"].Select("Desingation = '" + DesP + "'")[0]);
                int iPA = ds.Tables["TypPA"].Rows.IndexOf(ds.Tables["TypPA"].Select("NuPrd = " + idPr)[0]);
                int iPB = ds.Tables["TypPB"].Rows.IndexOf(ds.Tables["TypPB"].Select("NuPrd = " + idPr)[0]);
                int iPC = ds.Tables["TypPC"].Rows.IndexOf(ds.Tables["TypPC"].Select("NuPrd = " + idPr)[0]);
                int iS = ds.Tables["Stocks"].Rows.IndexOf(ds.Tables["Stocks"].Select("NuPrd = " + idPr)[0]);
                int idg = dtnp.Rows.IndexOf(dtnp.Select("الرقم = " + idPr)[0]);
                //Update DataTable Product
                ds.Tables["Produits"].Rows[iP].BeginEdit();
                ds.Tables["Produits"].Rows[iP]["Desingation"] = txt_nomPrd.Text;
                ds.Tables["Produits"].Rows[iP]["NuType"] = cb_tpPrd.SelectedValue;
                ds.Tables["Produits"].Rows[iP]["prxAchat"] = txt_prxAch.Text;
                ds.Tables["Produits"].Rows[iP].EndEdit();
                //Update DataTable TypPA
                ds.Tables["TypPA"].Rows[iPA].BeginEdit();
                ds.Tables["TypPA"].Rows[iPA]["Prix"] = txt_prxA.Text;
                ds.Tables["TypPA"].Rows[iPA].EndEdit();
                //Update DatTable TypPB
                ds.Tables["TypPB"].Rows[iPB].BeginEdit();
                ds.Tables["TypPB"].Rows[iPB]["Prix"] = txt_prxB.Text;
                ds.Tables["TypPB"].Rows[iPB].EndEdit();
                //Update DataTable TypPC
                ds.Tables["TypPC"].Rows[iPC].BeginEdit();
                ds.Tables["TypPC"].Rows[iPC]["Prix"] = txt_prxC.Text;
                ds.Tables["TypPC"].Rows[iPC].EndEdit();
                //Update DataTable Stock
                ds.Tables["Stocks"].Rows[iS].BeginEdit();
                ds.Tables["Stocks"].Rows[iS]["QttPrsFini"] = nud_qttMn.Value;
                ds.Tables["Stocks"].Rows[iS]["QttProd"] = nud_qtt.Value;
                ds.Tables["Stocks"].Rows[iS].EndEdit();
                //Update DataTable DTNP of GridView
                dtnp.Rows[idg].BeginEdit();
                dtnp.Rows[idg]["الإسم"] = txt_nomPrd.Text;
                dtnp.Rows[idg]["الكمية"] = nud_qtt.Value;
                dtnp.Rows[idg]["الكمية الأدنى"] = nud_qttMn.Value;
                dtnp.Rows[idg]["ثمن الشراء"] = nud_qttMn.Value;
                dtnp.Rows[idg]["ثمن A"] = txt_prxA.Text;
                dtnp.Rows[idg]["ثمن B"] = txt_prxB.Text;
                dtnp.Rows[idg]["ثمن C"] = txt_prxB.Text;
                dtnp.Rows[idg]["النوع"] = cb_tpPrd.Text;
                dtnp.Rows[idg].EndEdit();
                button8.Visible = false;
                button2.Visible = true;
                button1.PerformClick();
                MessageBox.Show("تم تعديل المعلومات بنجاح", " تعديل المعلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
          }

        private void AjtProduits_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saved)
            {
                FrmAcc.RefreshAccui();
            }
            else
            {
                if (ex)
                {
                    var rep = MessageBox.Show("لم تقم بحفض المعلومات, سيتم إلغاء الإضافات الجديدة !, هل تريد الإستمرار في الخروج ؟ ", "إلغاء العملية", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    e.Cancel = (rep == DialogResult.No);
                }
               
            }
        }

        private void groubbox1_Enter(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgr_nvProd.SelectedRows.Count == 1)
                {
                    var rep = MessageBox.Show("هل تريد حذف المعلومات المختارة ", "حذف المعلومات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    if (rep == DialogResult.Yes)
                    {
                        DesP = dtnp.Rows[dgr_nvProd.CurrentRow.Index][1].ToString();
                        idPr = dtnp.Rows[dgr_nvProd.CurrentRow.Index][0].ToString();
                        ds.Tables["Produits"].Rows.Remove((ds.Tables["Produits"].Select("Desingation = '" + DesP + "'")[0]));
                        ds.Tables["Stocks"].Rows.Remove((ds.Tables["Stocks"].Select("NuPrd = '" + idPr + "'")[0]));
                        ds.Tables["TypPA"].Rows.Remove((ds.Tables["TypPA"].Select("NuPrd = '" + idPr + "'")[0]));
                        ds.Tables["TypPB"].Rows.Remove((ds.Tables["TypPB"].Select("NuPrd = '" + idPr + "'")[0]));
                        ds.Tables["TypPC"].Rows.Remove((ds.Tables["TypPC"].Select("NuPrd = '" + idPr + "'")[0]));
                        dtnp.Rows.RemoveAt(dgr_nvProd.CurrentRow.Index);
                        dgr_nvProd.Text = dtnp.Rows.Count.ToString();
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
        int iT,inT;
        private void cb_nvType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txt_nomTp.Text = cb_nvType.Text;
            iT = ds.Tables["Types"].Rows.IndexOf(ds.Tables["Types"].Select("NumType = " + cb_nvType.SelectedValue.ToString())[0]);
            inT = int.Parse(cb_nvType.SelectedIndex.ToString());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                ds.Tables["Types"].Rows.Remove(ds.Tables["Types"].Select("NumType = " + cb_nvType.SelectedValue.ToString())[0]);
                dtnt.Rows.RemoveAt(int.Parse(cb_nvType.SelectedIndex.ToString()));
                button3.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                ds.Tables["types"].Rows[iT].BeginEdit();
                ds.Tables["types"].Rows[iT][1] = txt_nomTp.Text;
                ds.Tables["types"].Rows[iT].EndEdit();
                dtnt.Rows[inT].BeginEdit();
                dtnt.Rows[inT][1] = txt_nomTp.Text;
                dtnt.Rows[inT].EndEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void cb_nvType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_nomTp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_prxA_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
