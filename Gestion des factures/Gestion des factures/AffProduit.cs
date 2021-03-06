﻿using System;
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
    public partial class AffProduit : Form
    {
        private readonly Acceuil FrmAcc;
        public AffProduit(Acceuil frmA)
        {
            InitializeComponent();
            FrmAcc = frmA;
        }
        DataSet ds = new DataSet();
        SQLiteDataAdapter dta = new SQLiteDataAdapter("select p.NumPrd as 'الرقم', p.Desingation as 'الإسم', s.QttProd as 'الكمية', s.QttPrsFini as 'الكمية الأدنى', p.prxAchat as 'ثمن الشراء' , pa.Prix as 'ثمن A', pb.Prix as 'ثمن B', pc.prix as 'ثمن C', tp.NomType as 'النوع', s.DateAjout as 'تاريخ اللإضافة' from Stocks s, Produits p, TypePrixA pa, TypePrixB pb, TypePrixC pc, Types tp where tp.NumType = p.NuType AND s.NuPrd = p.NumPrd AND p.NumPrd = pa.NuPrd AND p.NumPrd =  pb.NuPrd AND p.NumPrd =  pc.NuPrd", Acceuil.cnx);
        SQLiteDataAdapter dta2 = new SQLiteDataAdapter("select NumType, NomType from Types", Acceuil.cnx);
        public string tpPrix = "";
        public void RefreshAffPrd()
        {
            SQLiteDataAdapter dap = new SQLiteDataAdapter("select p.NumPrd as 'رقم السلعة', p.Desingation as 'الإسم', s.QttProd as 'الكمية', s.QttPrsFini as 'الكمية الأدنى', p.prxAchat as 'ثمن الشراء' , pa.Prix as 'ثمن A', pb.Prix as 'ثمن B', pc.prix as 'ثمن C', tp.NomType as 'النوع', s.DateAjout as 'تاريخ اللإضافة' from Stocks s, Produits p, TypePrixA pa, TypePrixB pb, TypePrixC pc, Types tp where tp.NumType = p.NuType AND s.NuPrd = p.NumPrd AND p.NumPrd = pa.NuPrd AND p.NumPrd =  pb.NuPrd AND p.NumPrd =  pc.NuPrd", Acceuil.cnx);
            SQLiteDataAdapter dap2 = new SQLiteDataAdapter("select NumType, NomType from Types", Acceuil.cnx);
            DataSet nds = new DataSet();
            dap.Fill(nds, "MddfAjt");
            ds.Tables["ProduitsAjt"].Reset();
            dta.Fill(ds, "ProduitsAjt");
            dap2.Fill(nds, "Types");
            dgv_AfficheProd.DataSource = nds.Tables["MddfAjt"];
            DataRow rw = nds.Tables["Types"].NewRow();
            rw["NomType"] = "جميع الأنواع";
            rw["NumType"] = 0;
            nds.Tables["Types"].Rows.InsertAt(rw, 0);
            cb_type.ValueMember = "NumType";
            cb_type.DisplayMember = "NomType";
            cb_type.DataSource = nds.Tables["Types"];
            lbl_nmProd.Text = nds.Tables["MddfAjt"].Rows.Count.ToString();
            dgv_AfficheProd.ClearSelection();
            dgv_AfficheProd.Sort(dgv_AfficheProd.Columns["الإسم"], ListSortDirection.Ascending);
            ColorEmp();

        }
        public void GetAllProduct()
        {
            dta.Fill(ds, "ProduitsAjt");
            dta2.Fill(ds, "Types");
            dgv_AfficheProd.DataSource = ds.Tables["ProduitsAjt"];
            DataRow rw = ds.Tables["Types"].NewRow();
            rw["NomType"] = "جميع الأنواع";
            rw["NumType"] = 0;
            ds.Tables["Types"].Rows.InsertAt(rw, 0);
            cb_type.ValueMember = "NumType";
            cb_type.DisplayMember = "NomType";
            cb_type.DataSource = ds.Tables["Types"];
            lbl_nmProd.Text = ds.Tables["ProduitsAjt"].Rows.Count.ToString();
            dgv_AfficheProd.ClearSelection();
            dgv_AfficheProd.Sort(dgv_AfficheProd.Columns["الإسم"], ListSortDirection.Ascending);
        }
        public DataTable GetEmptyProducts()
        {
            DataView dv = ds.Tables["ProduitsAjt"].DefaultView;
            dv.RowFilter = "الكمية = 0";
            lbl_nmProd.Text = dv.ToTable().Rows.Count.ToString();
            dgv_AfficheProd.ClearSelection();
            return dv.ToTable();

        }
        public DataTable GetAlmEmpProducts()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select p.NumPrd as 'رقم السلعة', p.Desingation as 'الإسم', s.QttProd as 'الكمية', s.QttPrsFini as 'الكمية الأدنى', p.prxAchat as 'ثمن الشراء' , pa.Prix as 'ثمن A', pb.Prix as 'ثمن B', pc.prix as 'ثمن C', tp.NomType as 'النوع', s.DateAjout as 'تاريخ اللإضافة' from Stocks s, Produits p, TypePrixA pa, TypePrixB pb, TypePrixC pc, Types tp where tp.NumType = p.NuType AND s.NuPrd = p.NumPrd AND p.NumPrd = pa.NuPrd AND p.NumPrd =  pb.NuPrd AND p.NumPrd =  pc.NuPrd AND s.QttProd <= s.QttPrsFini AND s.QttProd <> 0", Acceuil.cnx);
            DataSet dts = new DataSet();
            da.Fill(dts, "PrduiPrsFini");
            lbl_nmProd.Text = dts.Tables["PrduiPrsFini"].Rows.Count.ToString();
            dgv_AfficheProd.ClearSelection();
            return dts.Tables["PrduiPrsFini"];

        }
        public DataTable GetFiltredData(string nuPr, string NmPr, string TpPr, string prPr,string tP, string dtPr)
        {
            String flPrix = "";
            if (tP == "A") flPrix = (prPr != "") ? " AND pa.Prix LIKE '%" + prPr +"%'": "";
            if (tP == "B") flPrix = (prPr != "") ? " AND pb.Prix LIKE '%" + prPr +"%'" : "";
            if (tP == "C") flPrix = (prPr != "") ? " AND pc.Prix LIKE '%" + prPr + "%'" : "";
            String flNum = (nuPr != "") ? " AND p.NumPrd = "+nuPr : "";
            String flNom = (NmPr != "") ? " AND p.Desingation LIKE '%" + NmPr + "%'" : "";
            String fltype = (cb_type.SelectedValue.ToString() != "0") ? " AND tp.NumType = " + TpPr : "";
            String flDate = (!ch_ShDt.Checked) ? " AND s.DateAjout = '" + dtPr + "'" : "";
            string rqt = "select p.NumPrd as 'رقم السلعة', p.Desingation as 'الإسم', s.QttProd as 'الكمية', s.QttPrsFini as 'الكمية الأدنى', p.prxAchat as 'ثمن الشراء' , pa.Prix as 'ثمن A', pb.Prix as 'ثمن B', pc.prix as 'ثمن C', tp.NomType as 'النوع', s.DateAjout as 'تاريخ اللإضافة'" +
                " from Stocks s, Produits p, TypePrixA pa, TypePrixB pb, TypePrixC pc, Types tp "+
                "where tp.NumType = p.NuType AND s.NuPrd = p.NumPrd AND p.NumPrd = pa.NuPrd AND p.NumPrd =  pb.NuPrd AND p.NumPrd =  pc.NuPrd"+
                flNum + " " + flNom + " " + fltype + " " + flPrix + " " + flDate;
            SQLiteDataAdapter da = new SQLiteDataAdapter(rqt, Acceuil.cnx);
            DataSet dst = new DataSet();
            da.Fill(dst, "Prduifiltrd");
            lbl_nmProd.Text = dst.Tables["Prduifiltrd"].Rows.Count.ToString();
            lbl_titrLstProd.Text = "بحث متخصص";
            dgv_AfficheProd.ClearSelection();
            return dst.Tables["Prduifiltrd"];
        }
        void ClearDgv() {
            if (dgv_AfficheProd.DataSource != null)
            {
                dgv_AfficheProd.DataSource = null;
            }
        }
        void ColorEmp() {
            foreach (DataGridViewRow grow in dgv_AfficheProd.Rows)
            {
                if (float.Parse(grow.Cells[2].Value.ToString()) <= float.Parse(grow.Cells[3].Value.ToString()) && float.Parse(grow.Cells[2].Value.ToString()) != 0)
                {
                    grow.DefaultCellStyle.BackColor = Color.Orange;
                }
                if (float.Parse(grow.Cells[2].Value.ToString()) == 0)
                {
                    grow.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        private void AffProduit_Load(object sender, EventArgs e)
        {
            try{
                GetAllProduct();
                ColorEmp();
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
            try{
                button3.PerformClick();
                dgv_AfficheProd.DataSource = ds;
                dgv_AfficheProd.DataMember = "ProduitsAjt";
                ColorEmp();
                lbl_nmProd.Text = ds.Tables["ProduitsAjt"].Rows.Count.ToString();
                lbl_titrLstProd.Text = button4.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                button3.PerformClick(); 
                dgv_AfficheProd.DataSource = GetEmptyProducts();
                dgv_AfficheProd.Sort(dgv_AfficheProd.Columns["الإسم"], ListSortDirection.Ascending);
                lbl_titrLstProd.Text = button2.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                button3.PerformClick();
                dgv_AfficheProd.DataSource = GetAlmEmpProducts();
                dgv_AfficheProd.Sort(dgv_AfficheProd.Columns["الإسم"], ListSortDirection.Ascending);
                lbl_titrLstProd.Text = button1.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dgv_AfficheProd_Sorted(object sender, EventArgs e)
        {
            ColorEmp();
        }
        
        private void txt_prix_TextChanged(object sender, EventArgs e)
        {
            try{
                float prx;
                if (float.TryParse(txt_prix.Text, out prx) || txt_prix.Text == "")
                {
                    dgv_AfficheProd.DataSource = GetFiltredData(txt_nuProd.Text, txt_NomProd.Text, cb_type.SelectedValue.ToString(), txt_prix.Text, tpPrix, dtp_datAjout.Text);
                    ColorEmp();
                 }
                else {
                    MessageBox.Show("الثمن الذي أدخلته غير مقبول", "خطأ في إدخال الثمن", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        
        }

        private void dtp_datAjout_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dgv_AfficheProd.DataSource = GetFiltredData(txt_nuProd.Text, txt_NomProd.Text, cb_type.SelectedValue.ToString(), txt_prix.Text, tpPrix, dtp_datAjout.Text);
                ColorEmp();
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void rb_a_CheckedChanged(object sender, EventArgs e)
        {
            tpPrix = (rb_a.Checked) ? "A" : "";
            txt_prix.Enabled = true;
        }

        private void rb_b_CheckedChanged(object sender, EventArgs e)
        {
            tpPrix = (rb_b.Checked) ? "B" : "";
            txt_prix.Enabled = true;
        }

        private void rb_c_CheckedChanged(object sender, EventArgs e)
        {
            tpPrix = (rb_c.Checked) ? "C" : "";
            txt_prix.Enabled = true;
        }

        private void rb_sansprx_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_sansprx.Checked)
	        {
		        tpPrix = "";
                txt_prix.Enabled = false;
	        }
                    
        }

        private void txt_nuProd_TextChanged(object sender, EventArgs e)
        {
            try{
                int prx;
                if (int.TryParse(txt_nuProd.Text, out prx) || txt_nuProd.Text == "")
                {
                    dgv_AfficheProd.DataSource = GetFiltredData(txt_nuProd.Text, txt_NomProd.Text, cb_type.SelectedValue.ToString(), txt_prix.Text, tpPrix, dtp_datAjout.Text);
                    ColorEmp();   
                }
                else MessageBox.Show("رقم السلعة الذي أدخلته غير مقبول", "خطأ في إدخال رقم السلعة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }

        }

        private void txt_NomProd_TextChanged(object sender, EventArgs e)
        {
            try{
                dgv_AfficheProd.DataSource = GetFiltredData(txt_nuProd.Text, txt_NomProd.Text, cb_type.SelectedValue.ToString(), txt_prix.Text, tpPrix, dtp_datAjout.Text);
                ColorEmp();
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txt_prix.Text = "";
            txt_nuProd.Text = "";
            txt_NomProd.Text = "";
            cb_type.SelectedValue = 0;
            ch_ShDt.Checked = true;
            rb_sansprx.Checked = true;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AffProduit_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmAcc.RefreshAccui();
        }

        private void dgv_AfficheProd_SelectionChanged(object sender, EventArgs e)
        {
            button5.Enabled = (dgv_AfficheProd.SelectedRows.Count == 1)? true : false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtp_datAjout.Enabled = !ch_ShDt.Checked;
                dgv_AfficheProd.DataSource = GetFiltredData(txt_nuProd.Text, txt_NomProd.Text, cb_type.SelectedValue.ToString(), txt_prix.Text, tpPrix, dtp_datAjout.Text);
                ColorEmp();
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
                MdfProduit frmMdf = new MdfProduit(int.Parse(dgv_AfficheProd.CurrentRow.Cells[0].Value.ToString()), this);
                frmMdf.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void cb_type_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try {
                dgv_AfficheProd.DataSource = GetFiltredData(txt_nuProd.Text, txt_NomProd.Text, cb_type.SelectedValue.ToString(), txt_prix.Text, tpPrix, dtp_datAjout.Text);
                ColorEmp();
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
                if (dgv_AfficheProd.SelectedRows.Count == 1)
                {
                    var rep = MessageBox.Show("هل تريد حذف المنتوج المختار؟  ", "حذف المنتوج", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    if (rep == DialogResult.Yes)
                    {
                        using (TransactionScope trans = new TransactionScope())
                        {
                            // All this work because on delete cascade doesn't work in desconnected mode !!
                            Acceuil.cnx.Open();
                            int idP = int.Parse(dgv_AfficheProd.CurrentRow.Cells[0].Value.ToString());
                            ds.Tables["ProduitsAjt"].Rows.Remove((ds.Tables["ProduitsAjt"].Select("الرقم = " + idP)[0]));
                            SQLiteDataAdapter toDelP = new SQLiteDataAdapter("Select * from Produits", Acceuil.cnx);
                            toDelP.Fill(ds, "ProductToDel");
                            SQLiteDataAdapter toDelS = new SQLiteDataAdapter("Select * from Stocks", Acceuil.cnx);
                            toDelS.Fill(ds, "StockToDel");
                            SQLiteDataAdapter toDelPA = new SQLiteDataAdapter("Select * from typePrixA", Acceuil.cnx);
                            toDelPA.Fill(ds, "PrAToDel");
                            SQLiteDataAdapter toDelPB = new SQLiteDataAdapter("Select * from typePrixB", Acceuil.cnx);
                            toDelPB.Fill(ds, "PrBToDel");
                            SQLiteDataAdapter toDelPC = new SQLiteDataAdapter("Select * from typePrixC", Acceuil.cnx);
                            toDelPC.Fill(ds, "PrCToDel");
                            DataView dvP = new DataView(ds.Tables["ProductToDel"], "NumPrd = " + idP, "", DataViewRowState.CurrentRows);
                            dvP[0].Delete();
                            DataView dvS = new DataView(ds.Tables["StockToDel"], "NuPrd = " + idP, "", DataViewRowState.CurrentRows);
                            dvS[0].Delete();
                            DataView dvPA = new DataView(ds.Tables["PrAToDel"], "NuPrd = " + idP, "", DataViewRowState.CurrentRows);
                            dvPA[0].Delete();
                            DataView dvPB = new DataView(ds.Tables["PrBToDel"], "NuPrd = " + idP, "", DataViewRowState.CurrentRows);
                            dvPB[0].Delete();
                            DataView dvPC = new DataView(ds.Tables["PrCToDel"], "NuPrd = " + idP, "", DataViewRowState.CurrentRows);
                            dvPC[0].Delete();
                            SQLiteCommandBuilder cmdb = new SQLiteCommandBuilder(toDelP);
                            toDelP.Update(ds, "ProductToDel");
                            cmdb = new SQLiteCommandBuilder(toDelS);
                            toDelS.Update(ds, "StockToDel");
                            cmdb = new SQLiteCommandBuilder(toDelPA);
                            toDelPA.Update(ds, "PrAToDel");
                            cmdb = new SQLiteCommandBuilder(toDelPA);
                            toDelPA.Update(ds, "PrAToDel");
                            cmdb = new SQLiteCommandBuilder(toDelPA);
                            toDelPA.Update(ds, "PrAToDel");
                            lbl_nmProd.Text = ds.Tables["ProduitsAjt"].Rows.Count.ToString();
                            button4.PerformClick();
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dgv_AfficheProd_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void dgv_AfficheProd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_AfficheProd.SelectedRows.Count == 1)
                {
                    MdfProduit frmMdf = new MdfProduit(int.Parse(dgv_AfficheProd.CurrentRow.Cells[0].Value.ToString()), this);
                    frmMdf.ShowDialog();
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
