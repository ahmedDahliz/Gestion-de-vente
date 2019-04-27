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
using System.Drawing.Printing;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Diagnostics;

namespace Gestion_des_factures
{
    public partial class AjtVente : Form
    {

        private readonly Acceuil FrmAcc;
        private bool isModification;
        public AjtVente(Acceuil FAcc)
        {
            InitializeComponent();
            FrmAcc = FAcc;
            isModification = false;
        }
        private readonly int idvtPassed;
        private readonly AffVente frm;
        private readonly String fileNameToEdit;
        public AjtVente(int idV, AffVente f, String fileNameToEdit)
        {
            InitializeComponent();
            idvtPassed = idV;
            frm = f;
            this.fileNameToEdit = fileNameToEdit;
            isModification = true;
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
        public void RefreshAjtVnt()
        {
            SQLiteDataAdapter dtaTypeU = new SQLiteDataAdapter("Select * from Types", Acceuil.cnx);
            SQLiteDataAdapter dtaProduitU = new SQLiteDataAdapter("Select * from Produits", Acceuil.cnx);
            SQLiteDataAdapter dtaStockeU = new SQLiteDataAdapter("Select * from Stocks", Acceuil.cnx);
            SQLiteDataAdapter dtaPxAU = new SQLiteDataAdapter("Select * from TypePrixA", Acceuil.cnx);
            SQLiteDataAdapter dtaPxBU = new SQLiteDataAdapter("Select * from TypePrixB", Acceuil.cnx);
            SQLiteDataAdapter dtaPxCU = new SQLiteDataAdapter("Select * from TypePrixC", Acceuil.cnx);
            ds.Tables["Types"].Clear();
            ds.Tables["Produits"].Clear();
            ds.Tables["Stocks"].Clear();
            ds.Tables["TypPA"].Clear();
            ds.Tables["TypPB"].Clear();
            ds.Tables["TypPC"].Clear();
            dtaTypeU.Fill(ds, "Types");
            dtaProduitU.Fill(ds, "Produits");
            dtaStockeU.Fill(ds, "Stocks");
            dtaPxAU.Fill(ds, "TypPA");
            dtaPxBU.Fill(ds, "TypPB");
            dtaPxCU.Fill(ds, "TypPC");
            cb_Prod.ValueMember = "NumPrd";
            cb_Prod.DisplayMember = "Desingation";
            cb_Prod.DataSource = ds.Tables["Produits"];
            cb_Prod.SelectedIndexChanged += new EventHandler(cb_Prod_SelectedIndexChanged);
            DataRow rw = ds.Tables["Types"].NewRow();
            rw["NomType"] = "جميع الأنواع";
            rw["NumType"] = 0;
            ds.Tables["Types"].Rows.InsertAt(rw, 0);
            cb_typePrd.SelectedIndex = 0;
            txt_numP.Text = "";
            txt_nomPrd.Text = "";
            cb_Prod_SelectedIndexChanged(cb_Prod, EventArgs.Empty);
            
        }
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
                
                this.WindowState = FormWindowState.Maximized;
                SQLiteDataAdapter dtaIdCmd = new SQLiteDataAdapter("Select * from Commande order by NumCmd DESC LIMIT 1", Acceuil.cnx);
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
                cb_typePrd.DropDownHeight = 300;  
                cb_typePrd.ValueMember = "NumType";
                cb_typePrd.DisplayMember = "NomType";
                cb_typePrd.DataSource = ds.Tables["Types"];
                // load list of Products
                cb_Prod.DropDownHeight = 400;
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
                idCmd = int.Parse(ds.Tables["IdCmd"].Rows[0]["NumCmd"].ToString());
                idLCmd = int.Parse(ds.Tables["idLign"].Rows[0]["seq"].ToString());
                idLCmd++;
                dtnv.Columns.Add("الرقم");
                dtnv.Columns.Add("الكمية");
                dtnv.Columns.Add("السلعة");
                dtnv.Columns.Add("ثمن الوحدة");
                dtnv.Columns.Add("الواجب");
                dgv_ProdV.DataSource = dtnv;
                lbl_datAjr.Text = DateTime.Today.ToShortDateString();
                if (isModification)
                {
                    this.Text = "تعديل البيع";
                    SQLiteDataAdapter dtaCmdEdit = new SQLiteDataAdapter("select p.NumPrd 'الرقم', c.QttCmd 'الكمية', p.Desingation 'السلعة', c.PrixU 'ثمن الوحدة', c.PrixCmd 'الواجب'  from Produits p, Commande c where p.NumPrd = c.NuPrd AND c.NumCmd = " + idvtPassed, Acceuil.cnx);
                    dtaCmdEdit.Fill(dtnv);
                    lbl_qttV.Text = dtnv.Rows.Count.ToString();
                    DataView dv = new DataView(ds.Tables["LignCmd"], "NuCmd = " + idvtPassed, "", DataViewRowState.CurrentRows);
                    txt_nomC.Text = dv[0]["NmClt"].ToString();
                    lbl_datAjr.Text = dv[0]["DateCmd"].ToString();
                    calculatePrice(Decimal.Parse(dv[0]["PrixTotal"].ToString()), true);
                    button9.Visible = false;
                    button8.Visible = false;
                    button2.Enabled = true;
                    idLCmd = int.Parse(dv[0]["NumLgCmd"].ToString());
                    panel1.Visible = true;
                    label22.Text += idvtPassed;
                }
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
            else txt_prx.Focus();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            EnableMskPx(false);
            lbl_prix.Text = pa;
            Decimal qtt = (nud_qtt.Text != "") ? Decimal.Parse(nud_qtt.Text) : 0;
            lbl_prxQtt.Text = (Decimal.Parse(lbl_prix.Text) * qtt).ToString("0.#####");
        }

        private void rd_B_CheckedChanged(object sender, EventArgs e)
        {
            EnableMskPx(false);
            lbl_prix.Text = pb;
            Decimal qtt = (nud_qtt.Text != "") ? Decimal.Parse(nud_qtt.Text) : 0;
            lbl_prxQtt.Text = (Decimal.Parse(lbl_prix.Text) * qtt).ToString("0.#####");
        }

        private void rb_C_CheckedChanged(object sender, EventArgs e)
        {
            EnableMskPx(false);
            lbl_prix.Text = pc;
            Decimal qtt = (nud_qtt.Text != "") ? Decimal.Parse(nud_qtt.Text) : 0;
            lbl_prxQtt.Text = (Decimal.Parse(lbl_prix.Text) * qtt).ToString("0.#####");
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
            txt_restPrx.Enabled = ch_ventADette.Checked;
            label16.Enabled = ch_ventADette.Checked;
            label21.Enabled = ch_ventADette.Checked;
            txt_nomC.Text = "";

        }
        Decimal minQtt = 1, maxQtt = 0; 
        private void cb_Prod_SelectedIndexChanged(object sender, EventArgs e)
        {
  
            //try
            //{
            DataView dv = new DataView(ds.Tables["Stocks"], "NuPrd = " + cb_Prod.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);
            DataView dvp = new DataView(ds.Tables["Produits"], "NumPrd = " + cb_Prod.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);
            if (float.Parse(dv[0]["QttProd"].ToString()) == 0)
            {
                lbl_ttrqtttav.ForeColor = System.Drawing.Color.Red;
                lbl_qttavi.ForeColor = System.Drawing.Color.Red;
                minQtt = 0;
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                lbl_ttrqtttav.ForeColor = System.Drawing.Color.Black;
                lbl_qttavi.ForeColor = System.Drawing.Color.Black;
                minQtt = 1;
            }
            nud_qtt.Text = "";
            lbl_qttavi.Text = dv[0]["QttProd"].ToString();
            //nud_qtt_old.Maximum = int.Parse(dv[0]["QttProd"].ToString());
            maxQtt = Decimal.Parse(dv[0]["QttProd"].ToString());
            DataView dva = new DataView(ds.Tables["TypPA"], "NuPrd = " + cb_Prod.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);
            pa = dva[0]["Prix"].ToString();
            DataView dvb = new DataView(ds.Tables["TypPB"], "NuPrd = " + cb_Prod.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);
            pb = dvb[0]["Prix"].ToString();
            DataView dvc = new DataView(ds.Tables["TypPC"], "NuPrd = " + cb_Prod.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);
            pc = dvc[0]["Prix"].ToString();
            txt_prx.Text = "0";
            lbl_prix.Text = (rb_A.Checked) ? pa : (rd_B.Checked) ? pb : (rb_C.Checked) ? pc : (rb_persn.Checked) ? txt_prx.Text : "";
            lbl_prxQtt.Text = (float.Parse(lbl_prix.Text) * 0).ToString("0.#####");
            lbl_prxAch.Text = dvp[0]["prxAchat"].ToString();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
            //    string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Contrôle : " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
            //    Acceuil.WriteLog(Err);
            //}
        }
        private void getNamClient(string str) {
            lbl_nomC.Text = str;

        }
        protected virtual bool IsFileinUse(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }
        private void CreatePdf(String FileName) {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Factures";
            if (isModification)
            {
                foreach (Process proc in Process.GetProcessesByName("AcroRd32"))
                {
                    proc.Kill();
                    proc.WaitForExit();
                }


                FileName = this.fileNameToEdit;
            }
            iTextSharp.text.Rectangle pageSize = new iTextSharp.text.Rectangle(100, 290);
            Document document = new Document(pageSize, 0, 0, 0, 0);
            DirectoryInfo di = Directory.CreateDirectory(path);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path + "\\"+FileName, FileMode.Create));
            document.Open();
            string fontpath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\times.ttf";
            BaseFont basefont = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, true);
            iTextSharp.text.Font arabicFont = new iTextSharp.text.Font(basefont, 24, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLUE);
            var e1 = new Chunk();
            var e2 = new Chunk();
            iTextSharp.text.Font f2 = new iTextSharp.text.Font(basefont, 4, e2.Font.Style, e2.Font.Color);
            iTextSharp.text.Font f1 = new iTextSharp.text.Font(basefont, 4, e1.Font.Style, e1.Font.Color);
            e1.Font = f1;
            e2.Font = f2;
            PdfPTable HeadTable = new PdfPTable(3);
            HeadTable.WidthPercentage = 100;
            HeadTable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            //Add header page
            addCell(e1, HeadTable, "رقم الفاتورة : " + idLCmd);
            addCell(e2, HeadTable, "فاتورة البيع", true);
            addCell(e1, HeadTable, DateTime.Now.ToShortTimeString() + " " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year, false);
            addCell(e1, HeadTable, "السيد(ة): " + lbl_nomC.Text,3);
            addCell(e1, HeadTable, " ");
            addCell(e1, HeadTable, " ");
            HeadTable.SpacingBefore = 0;
            HeadTable.SpacingAfter = 0;
            document.Add(HeadTable);
            //add separator
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.Color.BLACK, Element.ALIGN_RIGHT, 1)));
            p.SpacingBefore = 0;
            document.Add(p);
            //document.Add(new Chunk(" ", f2));
            //add Product header
            PdfPTable tableProduct = new PdfPTable(dtnv.Columns.Count - 1);
            tableProduct.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            tableProduct.WidthPercentage = 100;
            int[] widthsTab = { 7, 9, 28, 6};
            tableProduct.SetWidths(widthsTab);
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
            tableProduct.SpacingAfter = 5;
            tableProduct.SpacingBefore = 10;
            document.Add(tableProduct);
            //add Sells Informations
            PdfPTable FootTable = new PdfPTable(1);
            FootTable.WidthPercentage = 100;
            FootTable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            addCell(e2, FootTable, "عدد السلع : " + lbl_qttV.Text);
            addCell(e2, FootTable, "الواجب أدائه  : " + lbl_prixTotal.Text + " درهم");
            FootTable.SpacingAfter = 55;
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
                addCell(e2, DetteTable, "البيع بسلف لسيد(ة) : " + dvC[0]["NomClt"]);
                if (dvC[0]["Tele"].ToString() != "") addCell(e2, DetteTable, "الهاتف : " + dvC[0]["Tele"]);
                if (dvC[0]["Adresse"].ToString() != "") addCell(e2, DetteTable, "العنوان : " + dvC[0]["Adresse"]);
                Decimal pxd = Decimal.Parse(lbl_prixTotal.Text);
                if (txt_AnvcD.Text != "")
                {
                    addCell(e2, DetteTable, "التسبيق   : " + txt_AnvcD.Text + " درهم");
                    pxd -= Decimal.Parse(txt_AnvcD.Text);
                }
                Decimal restPrx = (txt_restPrx.Text != "") ? Decimal.Parse(txt_restPrx.Text) : 0;
                Decimal TtDette = (txt_restPrx.Text != "") ? restPrx + pxd : pxd;
                addCell(e2, DetteTable, "الباقي : " + restPrx + " درهم");
                addCell(e2, DetteTable, "المجموع : " + TtDette + " درهم");
                //dt += float.Parse(lbl_prixTotal.Text);
                //addCell(e2, DetteTable, "مجموع الدين الحالي  : " + dt + " درهم");
                document.Add(DetteTable);
            }
            PdfPTable underFootTable = new PdfPTable(1);
            underFootTable.WidthPercentage = 100;
            underFootTable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            addCell(e2, underFootTable, "**************************************", true);
            addCell(e2, underFootTable, "شـكـرا عـلـى زيـارتـكـم", true);
            document.Add(underFootTable);
            document.Close();
            // open pdf
            Acceuil.idPDF = Process.Start(path + "\\"+ FileName).Id;
        }
        private void txt_prx_TextChanged(object sender, EventArgs e)
        {
            Decimal px;
            Decimal qtt = (nud_qtt.Text != "") ? Decimal.Parse(nud_qtt.Text) : 0;
            if (txt_prx.Text != "")
            {
                if (Decimal.TryParse(txt_prx.Text, out px))
                {
                    lbl_prix.Text = txt_prx.Text;
                    lbl_prxQtt.Text = (Decimal.Parse(lbl_prix.Text) * qtt).ToString("0.#####");
                }
            }
            else {
                lbl_prix.Text = "0";
                lbl_prxQtt.Text = (Decimal.Parse(lbl_prix.Text) * qtt).ToString("0.#####");
            }
            
        }

        private void nud_qtt_ValueChanged(object sender, EventArgs e)
        {
            lbl_prxQtt.Text = (Decimal.Parse(lbl_prix.Text) * Decimal.Parse(nud_qtt.Text)).ToString("0.#####");
        }

        private void cb_nomC_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getNamClient((cb_nomC.SelectedIndex != 0)? cb_nomC.Text: "");  
        }

        private void txt_nomC_TextChanged(object sender, EventArgs e)
        {
            getNamClient(txt_nomC.Text.Trim());
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

        void calculatePrice(Decimal prx, bool isAddition) {
            if (isAddition) pxTTl += prx;
            else pxTTl -= prx;
            lbl_prixTotal.Text = pxTTl.ToString("0.#####");
        }

        Decimal pxTTl = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (nud_qtt.Text != "")
                {
                    if (lbl_nomC.Text != "")
                    {
                        if (!CheckInDt(dtnv, "'" + cb_Prod.Text + "'", "السلعة"))
                        {
                            DataRow dr = ds.Tables["Cmd"].NewRow();
                            dr[1] = idLCmd;
                            dr[2] = lbl_prix.Text;
                            dr[3] = lbl_prxQtt.Text.ToString();
                            dr[4] = nud_qtt.Text;
                            dr[5] = cb_Prod.SelectedValue.ToString();
                            ds.Tables["Cmd"].Rows.Add(dr);
                            //
                            dr = dtnv.NewRow();
                            dr[0] = cb_Prod.SelectedValue.ToString();
                            dr[1] = nud_qtt.Text;
                            dr[2] = cb_Prod.Text;
                            dr[3] = lbl_prix.Text;
                            dr[4] = lbl_prxQtt.Text;
                            dtnv.Rows.Add(dr);
                            ChangeQtt(cb_Prod.SelectedValue.ToString(), Decimal.Parse(lbl_qttavi.Text) -  Decimal.Parse(nud_qtt.Text));
                            lbl_qttV.Text = dtnv.Rows.Count.ToString();
                            //pxTTl += Decimal.Parse(lbl_prxQtt.Text);
                            //lbl_prixTotal.Text = pxTTl.ToString();
                            calculatePrice(Decimal.Parse(lbl_prxQtt.Text), true);
                            lbl_qttavi.Text = (Decimal.Parse(lbl_qttavi.Text) -  Decimal.Parse(nud_qtt.Text)).ToString();
                            if (Decimal.Parse(lbl_qttavi.Text) == 0)
                            {
                                lbl_ttrqtttav.ForeColor = System.Drawing.Color.Red;
                                lbl_qttavi.ForeColor = System.Drawing.Color.Red;
                                button1.Enabled = false;
                            }
                            nud_qtt.Text = minQtt.ToString();
                            button8.Enabled = true;
                            button9.Enabled = true;
                            button2.Enabled = true;
                            txt_AnvcD.Enabled = ch_ventADette.Checked;
                            saved = false;
                        }
                        else MessageBox.Show("المنتوج الذي أدخلته موجود في الفاتورة", "المنتوج موجود", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    }
                    else MessageBox.Show("قم بتحديد إسم الزبون أولا", "إسم الزبون غير محدد", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                }
                else MessageBox.Show("قم بتحديد عدد السلع أولا", "عدد السلع غير محدد", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

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
                using (TransactionScope tran = new TransactionScope())
                {
                    if (lbl_nomC.Text != "")
                    {
                         Acceuil.cnx.Open();
                        SQLiteCommandBuilder cmdb;
                        if (ch_ventADette.Checked)
                        {   //add to table Dettes
                            SQLiteDataAdapter dtaDette = new SQLiteDataAdapter("Select * from Dettes", Acceuil.cnx);
                            dtaDette.Fill(ds, "Dettes");
                            DataView dv = new DataView(ds.Tables["Dettes"], "NuClt = " + cb_nomC.SelectedValue.ToString(), "", DataViewRowState.CurrentRows);
                            Decimal dt = Decimal.Parse(dv[0]["PrixDette"].ToString());
                            Decimal prx = Decimal.Parse(lbl_prixTotal.Text);
                            if (txt_AnvcD.Text != "")
                            {
                                prx -= Decimal.Parse(txt_AnvcD.Text);
                            }
                            dt += prx;
                            dv[0]["PrixDette"] = dt;
                            cmdb = new SQLiteCommandBuilder(dtaDette);
                            dtaDette.Update(ds, "Dettes");
                        }
                        if (isModification)
                        {
                            DataView dvEdit = new DataView(ds.Tables["LignCmd"], "NuCmd = " + idvtPassed, "", DataViewRowState.CurrentRows);
                            dvEdit[0].BeginEdit();
                            dvEdit[0][1] = lbl_nomC.Text;
                            dvEdit[0][3] = lbl_prixTotal.Text;
                            dvEdit[0].EndEdit();
                        }
                        else
                        {
                            DataRow dr = ds.Tables["LignCmd"].NewRow();
                            idCmd++;
                            dr[1] = lbl_nomC.Text;
                            dr[2] = idCmd;
                            dr[3] = lbl_prixTotal.Text;
                            dr[4] = DateTime.Now.ToShortDateString();
                            ds.Tables["LignCmd"].Rows.Add(dr);
                        }
                        cmdb = new SQLiteCommandBuilder(dtaCmd);
                        dtaCmd.Update(ds, "Cmd");
                        cmdb = new SQLiteCommandBuilder(dtaLCmd);
                        dtaLCmd.Update(ds, "LignCmd");
                        cmdb = new SQLiteCommandBuilder(dtaStocke);
                        dtaStocke.Update(ds, "Stocks");
                        String dtn = DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year;
                        CreatePdf("No" + idLCmd + "_" + dtn + ".pdf");
                        Acceuil.cnx.Close();
                        button9.Enabled = false;
                        NewSell();
                        tran.Complete();
                        if (isModification) Close();
                    }
                    else MessageBox.Show("قم بتحديد إسم الزبون أولا", "إسم الزبون غير محدد", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                }
            }
            catch (Exception ex)
            {
                if (isModification)
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Factures";
                    FileInfo file = new FileInfo(path + "\\" + this.fileNameToEdit);
                    if (IsFileinUse(file))
                    {
                        MessageBox.Show("المرجو إغلاق ملف الفاتورة", "إغلاق الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    }

                }
                else {
                     MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
                }
               
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
            if (dgv_ProdV.SelectedRows.Count == 1)
            {
                idPr = dtnv.Rows[dgv_ProdV.CurrentRow.Index][0].ToString();
                DataView dv = new DataView(ds.Tables["Stocks"], "NuPrd = " + idPr, "", DataViewRowState.CurrentRows);
                cb_Prod.SelectedValue = idPr;
                cb_Prod.Enabled = false;
                ChangeQtt(cb_Prod.SelectedValue.ToString(), Decimal.Parse(dv[0]["QttProd"].ToString()) + Decimal.Parse(dgv_ProdV.CurrentRow.Cells[1].Value.ToString()));
                maxQtt = Decimal.Parse(dv[0]["QttProd"].ToString());
                lbl_qttavi.ForeColor = System.Drawing.Color.Black;
                lbl_ttrqtttav.ForeColor = System.Drawing.Color.Black;
                lbl_qttavi.Text = dv[0]["QttProd"].ToString();
                nud_qtt.Text = dgv_ProdV.CurrentRow.Cells[1].Value.ToString();
                //newPrice = float.Parse(lbl_prixTotal.Text) - float.Parse(dtnv.Rows[dgv_ProdV.CurrentRow.Index][4].ToString());
                calculatePrice(Decimal.Parse(dtnv.Rows[dgv_ProdV.CurrentRow.Index][4].ToString()), false);
                dgv_ProdV.Enabled = false;
                button5.Enabled = false;
                button9.Enabled = false;
                button8.Enabled = false;
                button7.Enabled = false;
                button6.Visible = true;
                button1.Visible = false;

            }
            try
            {
                
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
                int idg = dgv_ProdV.CurrentRow.Index;
                ds.Tables["Cmd"].Rows[iV].BeginEdit();
                ds.Tables["Cmd"].Rows[iV]["PrixCmd"] = lbl_prxQtt.Text;
                ds.Tables["Cmd"].Rows[iV]["QttCmd"] = nud_qtt.Text;
                ds.Tables["Cmd"].Rows[iV]["NuPrd"] = cb_Prod.SelectedValue.ToString();
                ds.Tables["Cmd"].Rows[iV].EndEdit();
                //
                dtnv.Rows[idg].BeginEdit();
                dtnv.Rows[idg]["الرقم"] = cb_Prod.SelectedValue.ToString();
                dtnv.Rows[idg]["السلعة"] = cb_Prod.Text;
                dtnv.Rows[idg]["الكمية"] = nud_qtt.Text;
                dtnv.Rows[idg]["ثمن الوحدة"] = lbl_prix.Text;
                dtnv.Rows[idg]["الواجب"] = lbl_prxQtt.Text;
                dtnv.Rows[idg].EndEdit();
                ChangeQtt(cb_Prod.SelectedValue.ToString(), int.Parse(lbl_qttavi.Text) - Decimal.Parse(nud_qtt.Text));
                lbl_qttavi.Text = (Decimal.Parse(lbl_qttavi.Text) - Decimal.Parse(nud_qtt.Text)).ToString();
                if (Decimal.Parse(lbl_qttavi.Text) == 0)
                {
                    lbl_ttrqtttav.ForeColor = System.Drawing.Color.Red;
                    lbl_qttavi.ForeColor = System.Drawing.Color.Red;
                    button1.Enabled = false;
                }
                //newPrice += float.Parse(lbl_prxQtt.Text);
                //lbl_prixTotal.Text = newPrice.ToString();
                calculatePrice(Decimal.Parse(lbl_prxQtt.Text), true);
                dgv_ProdV.Enabled = true;
                button5.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button6.Visible = false;
                button1.Visible = true;
                cb_Prod.Enabled = true;
                saved = false;
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
                        //ds.Tables["Cmd"].Rows.Remove(ds.Tables["Cmd"].Select("NumCmd = " + idLCmd + " AND NuPrd = " + idPr)[0]);
                        ds.Tables["Cmd"].Select("NumCmd = " + idLCmd + " AND NuPrd = " + idPr)[0].Delete();
                        //lbl_prixTotal.Text = (float.Parse(lbl_prixTotal.Text) - float.Parse(dtnv.Rows[dgv_ProdV.CurrentRow.Index][4].ToString())).ToString();
                        calculatePrice(Decimal.Parse(dtnv.Rows[dgv_ProdV.CurrentRow.Index][4].ToString()), false);
                        dtnv.Rows.RemoveAt(dgv_ProdV.CurrentRow.Index);
                        lbl_qttV.Text = dtnv.Rows.Count.ToString();
                        saved = false;
                        if (dtnv.Rows.Count == 0) {
                            txt_AnvcD.Enabled = false;
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
            saved = true;
            txt_nomC.Text = "";
            pxTTl = 0;
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
        void addCell(Chunk e, PdfPTable t, String str,int colspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(10, str, e.Font));
            cell.Colspan = colspan;
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
            if (!isModification) { 
                FrmAcc.RefreshAccui();
                frm.RefreshFactures();
            }
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
                txt_nomC.Text = "";
                cb_typePrd.SelectedIndex = 0;
                pxTTl = 0;
                button8.Enabled = false;
                button9.Enabled = false;
                button2.Enabled = false;
                txt_AnvcD.Enabled = false;
                saved = true;
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

        private void nud_qtt_ValueChanged(object sender, KeyEventArgs e)
        {

        }

        private void txt_prx_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            rb_persn.Checked = true;
        }

        private void txt_prx_DoubleClick(object sender, EventArgs e)
        {
            rb_persn.Checked = true;
        }

        private void AjtVente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txt_prx.ClientRectangle.Contains(e.Location))
            {
                rb_persn.Checked = true;
            }
        }

        private void nud_qtt_KeyUp(object sender, KeyEventArgs e)
        {
            lbl_prxQtt.Text = (Decimal.Parse(lbl_prix.Text) * Decimal.Parse(nud_qtt.Text)).ToString("0.#####");
        
        }

        private void txt_restPrx_TextChanged(object sender, EventArgs e)
        {
             try{
                float prx;
                if (!float.TryParse(txt_restPrx.Text, out prx) || txt_restPrx.Text == "")
                {
                    MessageBox.Show("الباقي الذي أدخلته غير مقبول", "خطأ في الباقي", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    
             }
             catch (Exception ex)
             {
                 MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                 string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Controle: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                 Acceuil.WriteLog(Err);
             }
        }
        private void nud_qtt_TextChanged(object sender, EventArgs e)
        {
            nud_qtt.Text = nud_qtt.Text.Replace('.', ',');
            Regex rgx = new Regex("[^0-9.,]");
            nud_qtt.Text = rgx.Replace(nud_qtt.Text, "");
            Decimal qtt;
            if (Decimal.TryParse(nud_qtt.Text, out qtt))
            {
                if (qtt > maxQtt)
                {
                    nud_qtt.Text = maxQtt.ToString();
                }
                if (qtt < minQtt)
                {
                    nud_qtt.Text = minQtt.ToString();
                }
                lbl_prxQtt.Text = (Decimal.Parse(nud_qtt.Text) * Decimal.Parse(lbl_prix.Text)).ToString("0.#####");
            }
            if (nud_qtt.Text == "")
            {
                lbl_prxQtt.Text = "0";
            }
            nud_qtt.SelectionStart = nud_qtt.Text.Length;
            nud_qtt.SelectionLength = 0;
           
        }

        private void nud_qtt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
         
                label17.Visible = cb_showPrxAch.Checked;
                label14.Visible = cb_showPrxAch.Checked;
                lbl_prxAch.Visible = cb_showPrxAch.Checked;
         
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cb_Prod.SelectedIndexChanged -= new EventHandler(cb_Prod_SelectedIndexChanged);
            MdfProduit mp = new MdfProduit(int.Parse(cb_Prod.SelectedValue.ToString()), this);
            mp.ShowDialog();
        }
  
    }
}
