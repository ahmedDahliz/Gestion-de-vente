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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Gestion_des_factures
{
    public partial class AjtVente : Form
    {

        private readonly Acceuil FrmAcc;
        public AjtVente(Acceuil FAcc)
        {
            InitializeComponent();
            FrmAcc = FAcc;
        }
        SQLiteDataAdapter dtaType = new SQLiteDataAdapter("Select * from Types", Acceuil.cnx);
        SQLiteDataAdapter dtaProduit = new SQLiteDataAdapter("Select * from Produits", Acceuil.cnx);
        SQLiteDataAdapter dtaStocke = new SQLiteDataAdapter("Select * from Stocks", Acceuil.cnx);
        SQLiteDataAdapter dtaPxA = new SQLiteDataAdapter("Select * from TypePrixA", Acceuil.cnx);
        SQLiteDataAdapter dtaPxB = new SQLiteDataAdapter("Select * from TypePrixB", Acceuil.cnx);
        SQLiteDataAdapter dtaPxC = new SQLiteDataAdapter("Select * from TypePrixC", Acceuil.cnx);
        SQLiteDataAdapter dtaCmd = new SQLiteDataAdapter("Select * from Commande", Acceuil.cnx);
        SQLiteDataAdapter dtaClt = new SQLiteDataAdapter("Select * from Clients", Acceuil.cnx);
        SQLiteDataAdapter dtaLCmd = new SQLiteDataAdapter("Select * from Ling_commande", Acceuil.cnx);
        DataSet ds = new DataSet();
        DataTable dtnv = new DataTable();
        int idCmd, idLCmd;
        string pa = "0", pb = "0", pc = "0";
        bool saved = true;
        private void GetProduct(object sender, EventArgs e)
        {
            try
            {
                DataView dv = null;
                if (txt_numP.Text == "")
                {
                    if (cb_typePrd.SelectedIndex == 0)
                    {
                        if (txt_nomPrd.Text != "")
                        {
                            dv = new DataView(ds.Tables["Produits"], "Desingation LIKE '%" + txt_nomPrd.Text + "%'", "", DataViewRowState.CurrentRows);
                        }
                        else
                        {
                            //lbl_prix.Text = "0";
                            //lbl_prxavi.Text = "0";
                            cb_Prod.DataSource = ds.Tables["Produits"];
                            cb_Prod.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        if (txt_nomPrd.Text != "")
                        {
                            dv = new DataView(ds.Tables["Produits"], "Desingation LIKE '%" + txt_nomPrd.Text + "%' AND NuType = " + cb_typePrd.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);
                        }
                        else
                        {
                            dv = new DataView(ds.Tables["Produits"], "NuType = " + cb_typePrd.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);

                        }
                    }
                }
                else {
                    int np;
                    if(int.TryParse(txt_numP.Text, out np)) 
                        dv = new DataView(ds.Tables["Produits"], "NumPrd = " + np, "", DataViewRowState.CurrentRows); 
                }
                if (dv != null && dv.ToTable().Rows.Count != 0)
                {
                    cb_Prod.DataSource = dv.ToTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
                
        }

        private void AjtVente_Load(object sender, EventArgs e)
        {
            try
            {
                SQLiteDataAdapter dtaIdCmd = new SQLiteDataAdapter("Select * from sqlite_sequence where name='Commande'", Acceuil.cnx);
                SQLiteDataAdapter dtaIdLCmd = new SQLiteDataAdapter("Select * from sqlite_sequence where name='Ling_commande'", Acceuil.cnx);
                dtaType.Fill(ds, "Types");
                dtaProduit.Fill(ds, "Produits");
                dtaStocke.Fill(ds, "Stocks");
                dtaPxA.Fill(ds, "TypPA");
                dtaPxB.Fill(ds, "TypPB");
                dtaPxC.Fill(ds, "TypPC");
                dtaClt.Fill(ds, "Client");
                dtaLCmd.Fill(ds, "LignCmd");
                dtaCmd.Fill(ds, "Cmd");
                dtaIdLCmd.Fill(ds, "idLign");
                dtaIdCmd.Fill(ds, "idCmd");
                // load list of Types
                DataRow rw = ds.Tables["Types"].NewRow();
                rw["NomType"] = "جميع الأنواع";
                rw["NumType"] = 0;
                ds.Tables["Types"].Rows.InsertAt(rw, 0);
                cb_typePrd.ValueMember = "NumType";
                cb_typePrd.DisplayMember = "NomType";
                cb_typePrd.DataSource = ds.Tables["Types"];
                // load list of Products
                cb_Prod.ValueMember = "NumPrd";
                cb_Prod.DisplayMember = "Desingation";
                cb_Prod.DataSource = ds.Tables["Produits"];
                // load list of Clients
                rw = ds.Tables["Client"].NewRow();
                rw["Nomclt"] = "إختر زبون";
                rw["NumClt"] = 0;
                ds.Tables["Client"].Rows.InsertAt(rw, 0);
                cb_nomC.ValueMember = "NumClt";
                cb_nomC.DisplayMember = "Nomclt";
                cb_nomC.DataSource = ds.Tables["Client"];
                idCmd = int.Parse(ds.Tables["IdCmd"].Rows[0]["seq"].ToString());
                idLCmd = int.Parse(ds.Tables["idLign"].Rows[0]["seq"].ToString());
                idLCmd++;
                dtnv.Columns.Add("الرقم");
                dtnv.Columns.Add("الكمية");
                dtnv.Columns.Add("السلعة");
                dtnv.Columns.Add("ثمن الوحدة");
                dtnv.Columns.Add("الواجب");
                dgv_ProdV.DataSource = dtnv;
                lbl_datAjr.Text = DateTime.Today.ToShortDateString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }  
        }

        private void rb_persn_CheckedChanged(object sender, EventArgs e)
        {
            EnableMskPx(true);
            lbl_prix.Text = "0";
            lbl_prxQtt.Text = "0";
        }

        public void EnableMskPx(Boolean b)
        {
            txt_prx.Enabled = b;
            if (!b) txt_prx.Text = "";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            EnableMskPx(false);
            lbl_prix.Text = pa;
            lbl_prxQtt.Text = float.Parse((float.Parse(lbl_prix.Text) * int.Parse(nud_qtt.Value.ToString())).ToString()).ToString();
        }

        private void rd_B_CheckedChanged(object sender, EventArgs e)
        {
            EnableMskPx(false);
            lbl_prix.Text = pb;
            lbl_prxQtt.Text = float.Parse((float.Parse(lbl_prix.Text) * int.Parse(nud_qtt.Value.ToString())).ToString()).ToString();
        }

        private void rb_C_CheckedChanged(object sender, EventArgs e)
        {
            EnableMskPx(false);
            lbl_prix.Text = pc;
            lbl_prxQtt.Text = float.Parse((float.Parse(lbl_prix.Text) * int.Parse(nud_qtt.Value.ToString())).ToString()).ToString();
        }

        private void mskt_pxpresn_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mskt_pxpresn_TextChanged(object sender, EventArgs e)
        {
            lbl_prix.Text = txt_prx.Text;
        }

        private void rb_CltE_CheckedChanged(object sender, EventArgs e)
        {
            txt_nomC.Visible = rb_CltnE.Checked;
            cb_nomC.Visible = rb_CltE.Checked;
        }

        private void ch_ventADette_CheckedChanged(object sender, EventArgs e)
        {
            rb_CltnE.Enabled = !ch_ventADette.Checked;
            rb_CltE.Checked = ch_ventADette.Checked;
            rb_CltnE.Checked = !ch_ventADette.Checked;
            txt_AnvcD.Enabled = ch_ventADette.Checked;
            label16.Enabled = ch_ventADette.Checked; ;

        }

        private void cb_Prod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(ds.Tables["Stocks"], "NuPrd = " + cb_Prod.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);
                DataView dvp = new DataView(ds.Tables["Produits"], "NumPrd = " + cb_Prod.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);
                if (int.Parse(dv[0]["QttProd"].ToString()) == 0)
                {
                    lbl_ttrprxav.ForeColor = System.Drawing.Color.Red;
                    lbl_qttavi.ForeColor = System.Drawing.Color.Red;
                    button1.Enabled = false;

                }
                else
                {
                    button1.Enabled = true;
                    lbl_ttrprxav.ForeColor = System.Drawing.Color.Black;
                    lbl_qttavi.ForeColor = System.Drawing.Color.Black;
                    nud_qtt.Minimum = 1;
                }
                lbl_qttavi.Text = dv[0]["QttProd"].ToString();
                nud_qtt.Maximum = int.Parse(dv[0]["QttProd"].ToString());
                DataView dva = new DataView(ds.Tables["TypPA"], "NuPrd = " + cb_Prod.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);
                pa = dva[0]["Prix"].ToString();
                DataView dvb = new DataView(ds.Tables["TypPB"], "NuPrd = " + cb_Prod.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);
                pb = dvb[0]["Prix"].ToString();
                DataView dvc = new DataView(ds.Tables["TypPC"], "NuPrd = " + cb_Prod.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);
                pc = dvc[0]["Prix"].ToString();
                lbl_prix.Text = (rb_A.Checked) ? pa : (rd_B.Checked) ? pb : (rb_C.Checked) ? pc : "";
                lbl_prxQtt.Text = float.Parse((float.Parse(lbl_prix.Text) * int.Parse(nud_qtt.Value.ToString())).ToString()).ToString();
                lbl_prxAch.Text = dvp[0]["prxAchat"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }
        private void getNamClient(string str) {
            lbl_nomC.Text = str;

        }
        private void CreatePdf(String FileName) {
            Document document = new Document();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Factures";
            DirectoryInfo di = Directory.CreateDirectory(path);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path + "\\"+FileName, FileMode.Create));
            document.Open();
            string fontpath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\times.ttf";
            BaseFont basefont = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, true);
            iTextSharp.text.Font arabicFont = new iTextSharp.text.Font(basefont, 24, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLUE);
            var el = new Chunk();
            var e2 = new Chunk();
            iTextSharp.text.Font f2 = new iTextSharp.text.Font(basefont, e2.Font.Size, e2.Font.Style, e2.Font.Color);
            iTextSharp.text.Font f1 = new iTextSharp.text.Font(basefont, 16, el.Font.Style, el.Font.Color);
            el.Font = f1;
            e2.Font = f2;
            PdfPTable HeadTable = new PdfPTable(3);
            HeadTable.WidthPercentage = 100;
            HeadTable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            //Add header page
            addCell(e2, HeadTable, "رقم الفاتورة : " + idLCmd);
            addCell(el, HeadTable, "فاتورة البيع", true);
            addCell(e2, HeadTable, "بتاريخ : " + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day, false);
            addCell(e2, HeadTable, "إسم الزبون(ة) : السيد(ة) " + lbl_nomC.Text);
            addCell(e2, HeadTable, " ");
            addCell(e2, HeadTable, " ");
            document.Add(HeadTable);
            //add separator
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.Color.BLACK, Element.ALIGN_RIGHT, 1)));
            document.Add(p);
            document.Add(new Chunk("\n", f2));
            //add Product header
            PdfPTable tableProduct = new PdfPTable(dtnv.Columns.Count - 1);
            tableProduct.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            for (int i = 1; i < dtnv.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(10, dtnv.Columns[i].ColumnName, e2.Font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                tableProduct.AddCell(cell);
            }
            //add products
            for (int i = 0; i < dtnv.Rows.Count; i++)
            {
                for (int j = 1; j < dtnv.Columns.Count; j++)
                {
                    tableProduct.AddCell(new PdfPCell(new Phrase(dtnv.Rows[i][j].ToString(), e2.Font)));
                }
            }
            document.Add(tableProduct);
            document.Add(new Chunk("\n", f2));
            //add Sells Informations
            PdfPTable FootTable = new PdfPTable(1);
            FootTable.WidthPercentage = 100;
            FootTable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            addCell(e2, FootTable, "عدد السلع : " + lbl_qttV.Text);
            addCell(e2, FootTable, "الواجب أدائه  : " + lbl_prixTotal.Text + " درهم");
            document.Add(FootTable);
            //add debt informations if exit
            if (ch_ventADette.Checked)
            {
                SQLiteDataAdapter dtaDette = new SQLiteDataAdapter("Select * from Dettes", Acceuil.cnx);
                dtaDette.Fill(ds, "Dettes");
                //DataView dvD = new DataView(ds.Tables["Dettes"], "NuClt = " + cb_nomC.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);
                //float dt = float.Parse(dvD[0]["PrixDette"].ToString());
                DataView dvC = new DataView(ds.Tables["Client"], "NumClt = " + cb_nomC.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);
                //add separator
                document.Add(p);
                PdfPTable DetteTable = new PdfPTable(1);
                DetteTable.WidthPercentage = 100;
                DetteTable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                addCell(e2, DetteTable, "البيع بسلف ل : " + dvC[0]["NomClt"]);
                addCell(e2, DetteTable, "الهاتف : " + dvC[0]["Tele"]);
                addCell(e2, DetteTable, "العنوان : " + dvC[0]["Adresse"]);
                float pxd = float.Parse(lbl_prixTotal.Text);
                if (txt_AnvcD.Text != "")
                {
                    addCell(e2, DetteTable, "التسبيق   : " + txt_AnvcD.Text + " درهم");
                    pxd -= float.Parse(txt_AnvcD.Text);
                }
                addCell(e2, DetteTable, "ثمن الدين   : " + pxd + " درهم");
               // dt += float.Parse(lbl_prixTotal.Text);
                //addCell(e2, DetteTable, "مجموع الدين الحالي  : " + dt + " درهم");
                document.Add(DetteTable);
            }
            document.Close();
            // open pdf
            System.Diagnostics.Process.Start(path + "\\"+ FileName);
        }
        private void txt_prx_TextChanged(object sender, EventArgs e)
        {
            float px;
            if (txt_prx.Text != "")
            {
                if (float.TryParse(txt_prx.Text, out px))
                {
                    lbl_prix.Text = txt_prx.Text;
                    lbl_prxQtt.Text = float.Parse((float.Parse(lbl_prix.Text) * int.Parse(nud_qtt.Value.ToString())).ToString()).ToString();
                }
            }
            else {
                lbl_prix.Text = "0";
                lbl_prxQtt.Text = float.Parse((float.Parse(lbl_prix.Text) * int.Parse(nud_qtt.Value.ToString())).ToString()).ToString();
            }
            
        }

        private void nud_qtt_ValueChanged(object sender, EventArgs e)
        {
            lbl_prxQtt.Text = float.Parse((float.Parse(lbl_prix.Text) * int.Parse(nud_qtt.Value.ToString())).ToString()).ToString();
        }

        private void cb_nomC_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getNamClient((cb_nomC.SelectedIndex != 0)? cb_nomC.Text: "");  
        }

        private void txt_nomC_TextChanged(object sender, EventArgs e)
        {
            getNamClient(txt_nomC.Text);
        }
        float pxTTl = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_nomC.Text != "")
                {
                    DataRow dr = ds.Tables["Cmd"].NewRow();
                    dr[1] = idLCmd;
                    dr[2] = lbl_prix.Text;
                    dr[3] = lbl_prxQtt.Text;
                    dr[4] = nud_qtt.Value;
                    dr[5] = cb_Prod.SelectedValue.ToString();
                    ds.Tables["Cmd"].Rows.Add(dr);
                    //
                    dr = dtnv.NewRow();
                    dr[0] = cb_Prod.SelectedValue.ToString();
                    dr[1] = nud_qtt.Value;
                    dr[2] = cb_Prod.Text;
                    dr[3] = lbl_prix.Text;
                    dr[4] = lbl_prxQtt.Text;
                    dtnv.Rows.Add(dr);
                    ChangeQtt(cb_Prod.SelectedValue.ToString(), int.Parse(lbl_qttavi.Text) - nud_qtt.Value);
                    lbl_qttV.Text = dtnv.Rows.Count.ToString();
                    pxTTl += float.Parse(lbl_prxQtt.Text);
                    lbl_prixTotal.Text = pxTTl.ToString();
                    button8.Enabled = true;
                    button9.Enabled = true;
                    button2.Enabled = true;
                    txt_AnvcD.Enabled = true;
                }
                else MessageBox.Show("قم بتحديد إسم الزبون أولا", " إسم الزبون غير محدد", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
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
                SQLiteCommandBuilder cmdb;
                if (ch_ventADette.Checked)
                {   //add to table Dettes
                    SQLiteDataAdapter dtaDette = new SQLiteDataAdapter("Select * from Dettes", Acceuil.cnx);
                    dtaDette.Fill(ds, "Dettes");
                    DataView dv = new DataView(ds.Tables["Dettes"], "NuClt = " + cb_nomC.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);
                    float dt = float.Parse(dv[0]["PrixDette"].ToString());
                    float prx = float.Parse(lbl_prixTotal.Text);
                    if (txt_AnvcD.Text != "")
                    {
                        prx -= float.Parse(txt_AnvcD.Text);
                    }
                    dt += prx;
                    dv[0]["PrixDette"] = dt;
                    cmdb = new SQLiteCommandBuilder(dtaDette);
                    dtaDette.Update(ds, "Dettes");
                }
                DataRow dr = ds.Tables["LignCmd"].NewRow();
                idCmd++;
                dr[1] = lbl_nomC.Text;
                dr[2] = idCmd;
                dr[3] = lbl_prixTotal.Text;
                dr[4] = DateTime.Now.ToShortDateString();
                ds.Tables["LignCmd"].Rows.Add(dr);
                cmdb = new SQLiteCommandBuilder(dtaCmd);
                dtaCmd.Update(ds, "Cmd");
                cmdb = new SQLiteCommandBuilder(dtaLCmd);
                dtaLCmd.Update(ds, "LignCmd");
                cmdb = new SQLiteCommandBuilder(dtaStocke);
                dtaStocke.Update(ds, "Stocks");
                String dtn = DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year;
                CreatePdf("No" + idLCmd + "_" + dtn + ".pdf");
                button9.Enabled = false;
                NewSell();
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }
           

        private void dgv_ProdV_SelectionChanged(object sender, EventArgs e)
        {
            button5.Enabled = (dgv_ProdV.SelectedRows.Count == 1);
            button7.Enabled = (dgv_ProdV.SelectedRows.Count == 1);
        }
        string idPr;
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_ProdV.SelectedRows.Count == 1)
                {
                    idPr = dtnv.Rows[dgv_ProdV.CurrentRow.Index][0].ToString();
                    DataView dv = new DataView(ds.Tables["Stocks"], "NuPrd = " + idPr, "", DataViewRowState.CurrentRows);
                    ChangeQtt(cb_Prod.SelectedValue.ToString(), int.Parse(dv[0]["QttProd"].ToString()) + int.Parse(dgv_ProdV.CurrentRow.Cells[1].Value.ToString()));
                    cb_Prod.SelectedValue = idPr;
                    nud_qtt.Value = int.Parse(dgv_ProdV.CurrentRow.Cells[1].Value.ToString());
                    button6.Visible = true;
                    button1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int iV = ds.Tables["Cmd"].Rows.IndexOf(ds.Tables["Cmd"].Select("NumCmd = " + idLCmd + " AND NuPrd = " + idPr)[0]);
                int idg = dtnv.Rows.IndexOf(dtnv.Select("الرقم = " + idPr)[0]);
                ds.Tables["Cmd"].Rows[iV].BeginEdit();
                ds.Tables["Cmd"].Rows[iV]["PrixCmd"] = lbl_prxQtt.Text;
                ds.Tables["Cmd"].Rows[iV]["QttCmd"] = nud_qtt.Value;
                ds.Tables["Cmd"].Rows[iV]["NuPrd"] = cb_Prod.SelectedValue.ToString();
                ds.Tables["Cmd"].Rows[iV].EndEdit();
                //
                dtnv.Rows[idg].BeginEdit();
                dtnv.Rows[idg]["الرقم"] = cb_Prod.SelectedValue.ToString();
                dtnv.Rows[idg]["السلعة"] = cb_Prod.Text;
                dtnv.Rows[idg]["الكمية"] = nud_qtt.Value;
                dtnv.Rows[idg]["ثمن الوحدة"] = lbl_prix.Text;
                dtnv.Rows[idg]["الواجب"] = lbl_prxQtt.Text;
                dtnv.Rows[idg].EndEdit();
                ChangeQtt(cb_Prod.SelectedValue.ToString(), int.Parse(lbl_qttavi.Text) - nud_qtt.Value);
                button6.Visible = false;
                button1.Visible = true;
                MessageBox.Show("تم تعديل المعلومات بنجاح", " تعديل المعلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void ChangeQtt(string idp, decimal qtt)
        {
            int iP = ds.Tables["Stocks"].Rows.IndexOf(ds.Tables["Stocks"].Select("NuPrd = '" + idp + "'")[0]);
            ds.Tables["Stocks"].Rows[iP].BeginEdit();
            ds.Tables["Stocks"].Rows[iP]["QttProd"] = qtt;
            ds.Tables["Stocks"].Rows[iP].EndEdit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_ProdV.SelectedRows.Count == 1)
                {
                    var rep = MessageBox.Show("هل تريد حذف المعلومات المختارة ", "حذف المعلومات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    if (rep == DialogResult.Yes)
                    {
                        idPr = dtnv.Rows[dgv_ProdV.CurrentRow.Index][0].ToString();
                        DataView dv = new DataView(ds.Tables["Stocks"], "NuPrd = " + idPr, "", DataViewRowState.CurrentRows);
                        ChangeQtt(cb_Prod.SelectedValue.ToString(), int.Parse(dv[0]["QttProd"].ToString()) + int.Parse(dgv_ProdV.CurrentRow.Cells[1].Value.ToString()));
                        ds.Tables["Cmd"].Rows.Remove((ds.Tables["Cmd"].Select("NumCmd = " + idLCmd + " AND NuPrd = " + idPr)[0]));
                        dtnv.Rows.RemoveAt(dgv_ProdV.CurrentRow.Index);
                        dgv_ProdV.Text = dtnv.Rows.Count.ToString();
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
        
        private void button8_Click(object sender, EventArgs e)
        {
            var rep = MessageBox.Show("هل تريد القيام ببيع جديد ؟ ", "بيع جديد", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            if (rep == DialogResult.Yes)
            {
                NewSell();
            }
            
        }

        private void NewSell()
        {
            dtnv.Rows.Clear();
            idLCmd++;
            lbl_prixTotal.Text = "0";
            lbl_nomC.Text = "";
            lbl_qttV.Text = "";
            txt_nomPrd.Text = "";
            txt_numP.Text = "";
            cb_typePrd.SelectedIndex = 0;
            button8.Enabled = false;
            button9.Enabled = false;
            button2.Enabled = false;
            txt_AnvcD.Enabled = false;
        }
        void addCell(Chunk e, PdfPTable t,String str, bool AlignCenter)
        {
            PdfPCell cell = new PdfPCell(new Phrase(10, str, e.Font));
            cell.BorderColor = iTextSharp.text.Color.WHITE;
            if (AlignCenter) cell.HorizontalAlignment = Element.ALIGN_CENTER;
            else cell.HorizontalAlignment = Element.ALIGN_RIGHT; 
            t.AddCell(cell);
        }
        void addCell(Chunk e, PdfPTable t, String str)
        {
            PdfPCell cell = new PdfPCell(new Phrase(10, str, e.Font));
            cell.BorderColor = iTextSharp.text.Color.WHITE;
            t.AddCell(cell);
        }
        bool ex = true;
        private void button4_Click(object sender, EventArgs e)
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

        private void AjtVente_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmAcc.RefreshAccui();
            if (!saved)
            {
                if (ex)
                {
                    var rep = MessageBox.Show("لم تقم بحفض المعلومات, سيتم إلغاء الإضافات الجديدة !, هل تريد الإستمرار في الخروج ؟ ", "إلغاء العملية", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    e.Cancel = (rep == DialogResult.No);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var rep = MessageBox.Show("هل تريد القيام بإلغاء هذا البيع ؟ ", "إلغاء البيع", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            if (rep == DialogResult.Yes)
            {
                dtnv.Rows.Clear();
                lbl_prixTotal.Text = "0";
                lbl_nomC.Text = "";
                lbl_qttV.Text = "";
                txt_nomPrd.Text = "";
                txt_numP.Text = "";
                cb_typePrd.SelectedIndex = 0;
                button8.Enabled = false;
                button9.Enabled = false;
                button2.Enabled = false;
                txt_AnvcD.Enabled = false;
            }

        }

        private void txt_AnvcD_TextChanged(object sender, EventArgs e)
        {
            float px;
            if (txt_AnvcD.Text != "")
            {
                if (float.TryParse(txt_AnvcD.Text, out px))
                {
                    if (px >= float.Parse(lbl_prixTotal.Text))
                    {
                        MessageBox.Show("التسبيق بجب أن يكون أقل من الثمن الواجب أدائه", "خطأ في إدخال ثمن التسبيق", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    }
                }
                else MessageBox.Show("ثمن التسبيق غير مقبول", "خطأ في إدخال ثمن التسبيق", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            }

        }

        private void cb_typePrd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
        
    }
}
