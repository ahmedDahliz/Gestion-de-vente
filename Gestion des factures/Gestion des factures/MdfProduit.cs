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
using System.Text.RegularExpressions;

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
        void saved()
        {
            label3.Visible = false;
            button4.Enabled = false;
            button2.BackColor = Color.Orange;
        }
        private void MdfProduit_Load(object sender, EventArgs e)
        {
            try
            {
                dtaProduit.Fill(ds, "Produits");
                dtaStocke.Fill(ds, "Stocks");
                dtaPxA.Fill(ds, "TypPA");
                dtaPxB.Fill(ds, "TypPB");
                dtaPxC.Fill(ds, "TypPC");
                dta = new SQLiteDataAdapter("select p.NumPrd, p.Desingation, s.QttProd, s.QttPrsFini, pa.Prix, pb.Prix, pc.prix, p.NuType, p.prxAchat from Stocks s, Produits p, TypePrixA pa, TypePrixB pb, TypePrixC pc where s.NuPrd = p.NumPrd AND p.NumPrd = pa.NuPrd AND p.NumPrd =  pb.NuPrd AND p.NumPrd = pc.NuPrd AND p.NumPrd = " + idpr, Acceuil.cnx);
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
                nud_qtt.Text = ds.Tables["EdtPrd"].Rows[0][2].ToString();
                nud_qttMn.Text = ds.Tables["EdtPrd"].Rows[0][3].ToString();
                txt_pa.Text = ds.Tables["EdtPrd"].Rows[0][4].ToString();
                txt_pb.Text = ds.Tables["EdtPrd"].Rows[0][5].ToString();
                txt_pc.Text = ds.Tables["EdtPrd"].Rows[0][6].ToString();
                cb_tpPrd.SelectedValue = ds.Tables["EdtPrd"].Rows[0][7].ToString();
                txt_prxAch.Text = ds.Tables["EdtPrd"].Rows[0][8].ToString();
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
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }   
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
            try
            {
                ds.Tables["typesMdf"].Rows[i].BeginEdit();
                ds.Tables["typesMdf"].Rows[i][1] = txt_nmType.Text;
                ds.Tables["typesMdf"].Rows[i].EndEdit();
                ds.Tables["types"].Rows[i].BeginEdit();
                ds.Tables["types"].Rows[i][1] = txt_nmType.Text;
                ds.Tables["types"].Rows[i].EndEdit();
                Acceuil.cnx.Open();
                SQLiteCommandBuilder cmdb = new SQLiteCommandBuilder(dt2);
                dt2.Update(ds, "typesMdf");
                Acceuil.cnx.Close();
                svd = true;
                MessageBox.Show("تم تعديل و حفض التغييرات بنجاح", "حفض التغييرات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal pac, pa, pb, pc;
                if (txt_nmPrd.Text != "" && txt_pa.Text != "" && txt_pb.Text != "" && txt_pc.Text != "" && txt_prxAch.Text != "")
                {
                    if (Decimal.TryParse(txt_pa.Text, out pa) && Decimal.TryParse(txt_pb.Text, out pb) && Decimal.TryParse(txt_pc.Text, out pc) && Decimal.TryParse(txt_prxAch.Text, out pac))
                    {
                        DataView dv = new DataView(ds.Tables["Produits"], "NumPrd = " + idpr, "", DataViewRowState.CurrentRows);
                        dv[0].BeginEdit();
                        dv[0][1] = txt_nmPrd.Text;
                        dv[0][2] = cb_tpPrd.SelectedValue;
                        dv[0][3] = txt_prxAch.Text;
                        dv[0].EndEdit();
                        dv = new DataView(ds.Tables["Stocks"], "NuPrd = " + idpr, "", DataViewRowState.CurrentRows);
                        dv[0].BeginEdit();
                        dv[0][1] = nud_qtt.Text;
                        dv[0][2] = nud_qttMn.Text;
                        dv[0].EndEdit();
                        dv = new DataView(ds.Tables["TypPA"], "NuPrd = " + idpr, "", DataViewRowState.CurrentRows);
                        dv[0].BeginEdit();
                        dv[0][1] = txt_pa.Text;
                        dv[0].EndEdit();
                        dv = new DataView(ds.Tables["TypPB"], "NuPrd = " + idpr, "", DataViewRowState.CurrentRows);
                        dv[0].BeginEdit();
                        dv[0][1] = txt_pb.Text;
                        dv[0].EndEdit();
                        dv = new DataView(ds.Tables["TypPC"], "NuPrd = " + idpr, "", DataViewRowState.CurrentRows);
                        dv[0].BeginEdit();
                        dv[0][1] = txt_pc.Text;
                        dv[0].EndEdit();
                        ds.Tables["EdtPrd"].Rows[0].EndEdit();
                        label3.Visible = true;
                        button2.BackColor = SystemColors.Control;
                        button4.Enabled = true;
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
                        Acceuil.cnx.Close();
                        svd = true;
                    }
                    else MessageBox.Show("أحد الأثمنة غير مقبولة", "خطأ في إدخال الأثمنة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("المرجو ملأ الحقول الفارغة", "أحد الحقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void cb_tpPrd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb_chngType.SelectedValue != null)
                {
                    var rep = MessageBox.Show("هل تريد حذف النوع المختار؟  ", "حذف النوع", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    if (rep == DialogResult.Yes)
                    {
                        int idT = int.Parse(cb_chngType.SelectedValue.ToString());
                        ds.Tables["typesMdf"].Rows.Remove((ds.Tables["typesMdf"].Select("NumType = " + idT)[0]));
                        SQLiteDataAdapter toDelT = new SQLiteDataAdapter("Select * from Types", Acceuil.cnx);
                        toDelT.Fill(ds, "TypeToDel");
                        DataView dvT = new DataView(ds.Tables["typesMdf"], "NumType = " + idT, "", DataViewRowState.CurrentRows);
                        dvT[0].Delete();
                        SQLiteCommandBuilder cmdb = new SQLiteCommandBuilder(toDelT);
                        toDelT.Update(ds, "TypeToDel");
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
        Decimal maxQtt;
        private void nud_qtt_TextChanged(object sender, EventArgs e)
        {
            nud_qtt.Text = nud_qtt.Text.Replace('.', ',');
            Regex rgx = new Regex("[^0-9.,]");
            nud_qtt.Text = rgx.Replace(nud_qtt.Text, "");
            Decimal qtt;
            if (Decimal.TryParse(nud_qtt.Text, out qtt))
            {
                maxQtt = qtt;
                if (qtt < 1)
                {
                    nud_qtt.Text = "0";
                }
            }
            nud_qtt.SelectionStart = nud_qtt.Text.Length;
            nud_qtt.SelectionLength = 0;
            saved();
        }

        private void nud_qttMn_TextChanged(object sender, EventArgs e)
        {
            nud_qttMn.Text = nud_qttMn.Text.Replace('.', ',');
            Regex rgx = new Regex("[^0-9.,]");
            nud_qttMn.Text = rgx.Replace(nud_qttMn.Text, "");
            Decimal qtt;
            if (Decimal.TryParse(nud_qttMn.Text, out qtt))
            {
                if (qtt > maxQtt)
                {
                    nud_qttMn.Text = maxQtt.ToString();
                }
                if (qtt < 1)
                {
                    nud_qttMn.Text = "0";
                }
            }
            nud_qttMn.SelectionStart = nud_qttMn.Text.Length;
            nud_qttMn.SelectionLength = 0;
            saved();
        }

        private void txt_pa_TextChanged(object sender, EventArgs e)
        {
            txt_pa.Text = txt_pa.Text.Replace('.', ',');
            Regex rgx = new Regex("[^0-9.,]");
            txt_pa.Text = rgx.Replace(txt_pa.Text, "");
            txt_pa.SelectionStart = txt_pa.Text.Length;
            txt_pa.SelectionLength = 0;
            saved();
        }

        private void txt_pb_TextChanged(object sender, EventArgs e)
        {
            txt_pb.Text = txt_pb.Text.Replace('.', ',');
            Regex rgx = new Regex("[^0-9.,]");
            txt_pb.Text = rgx.Replace(txt_pb.Text, "");
            txt_pb.SelectionStart = txt_pb.Text.Length;
            txt_pb.SelectionLength = 0;
            saved();
        }

        private void txt_pc_TextChanged(object sender, EventArgs e)
        {
            txt_pc.Text = txt_pc.Text.Replace('.', ',');
            Regex rgx = new Regex("[^0-9.,]");
            txt_pc.Text = rgx.Replace(txt_pc.Text, "");
            txt_pc.SelectionStart = txt_pc.Text.Length;
            txt_pc.SelectionLength = 0;
            saved();
        }


        private void cb_tpPrd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            saved();
        }

        private void txt_nmPrd_TextChanged(object sender, EventArgs e)
        {
            saved();
        }


        private void txt_prxAch_TextChanged(object sender, EventArgs e)
        {
            txt_prxAch.Text = txt_prxAch.Text.Replace('.', ',');
            Regex rgx = new Regex("[^0-9.,]");
            txt_prxAch.Text = rgx.Replace(txt_prxAch.Text, "");
            txt_prxAch.SelectionStart = txt_prxAch.Text.Length;
            txt_prxAch.SelectionLength = 0;
            saved();
        }

        
    }
}
