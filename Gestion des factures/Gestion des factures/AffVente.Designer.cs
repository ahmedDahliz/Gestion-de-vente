namespace Gestion_des_factures
{
    partial class AffVente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ch_ShDt = new System.Windows.Forms.CheckBox();
            this.txt_numFact = new System.Windows.Forms.TextBox();
            this.txt_nomC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_dateFact = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Facture = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_NbrProd = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_VentAp = new System.Windows.Forms.Label();
            this.dgv_DetailFacture = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Facture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DetailFacture)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ch_ShDt);
            this.groupBox2.Controls.Add(this.txt_numFact);
            this.groupBox2.Controls.Add(this.txt_nomC);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtp_dateFact);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(11, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(791, 99);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "بحث حسب";
            // 
            // ch_ShDt
            // 
            this.ch_ShDt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ch_ShDt.AutoSize = true;
            this.ch_ShDt.Checked = true;
            this.ch_ShDt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ch_ShDt.Location = new System.Drawing.Point(181, 58);
            this.ch_ShDt.Name = "ch_ShDt";
            this.ch_ShDt.Size = new System.Drawing.Size(98, 17);
            this.ch_ShDt.TabIndex = 35;
            this.ch_ShDt.Text = "بحث بدون تاريخ";
            this.ch_ShDt.UseVisualStyleBackColor = true;
            this.ch_ShDt.CheckedChanged += new System.EventHandler(this.ch_ShDt_CheckedChanged);
            // 
            // txt_numFact
            // 
            this.txt_numFact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_numFact.Location = new System.Drawing.Point(603, 22);
            this.txt_numFact.Name = "txt_numFact";
            this.txt_numFact.Size = new System.Drawing.Size(95, 20);
            this.txt_numFact.TabIndex = 28;
            this.txt_numFact.TextChanged += new System.EventHandler(this.txt_numFact_TextChanged);
            // 
            // txt_nomC
            // 
            this.txt_nomC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_nomC.Location = new System.Drawing.Point(307, 22);
            this.txt_nomC.Name = "txt_nomC";
            this.txt_nomC.Size = new System.Drawing.Size(186, 20);
            this.txt_nomC.TabIndex = 28;
            this.txt_nomC.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "تاريخ الفاتورة : ";
            // 
            // dtp_dateFact
            // 
            this.dtp_dateFact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_dateFact.Enabled = false;
            this.dtp_dateFact.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_dateFact.Location = new System.Drawing.Point(100, 22);
            this.dtp_dateFact.Name = "dtp_dateFact";
            this.dtp_dateFact.Size = new System.Drawing.Size(96, 20);
            this.dtp_dateFact.TabIndex = 26;
            this.dtp_dateFact.ValueChanged += new System.EventHandler(this.dtp_dateFact_ValueChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(505, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "إسم الزبون : ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(707, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "رقم الفاتورة : ";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(684, 67);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "جميع المبيعات";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(307, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 44);
            this.label1.TabIndex = 36;
            this.label1.Text = "لائحة المبيعات";
            // 
            // dgv_Facture
            // 
            this.dgv_Facture.AllowUserToAddRows = false;
            this.dgv_Facture.AllowUserToDeleteRows = false;
            this.dgv_Facture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Facture.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Facture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Facture.Location = new System.Drawing.Point(12, 163);
            this.dgv_Facture.Name = "dgv_Facture";
            this.dgv_Facture.ReadOnly = true;
            this.dgv_Facture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Facture.Size = new System.Drawing.Size(790, 278);
            this.dgv_Facture.TabIndex = 37;
            this.dgv_Facture.TabStop = false;
            this.dgv_Facture.SelectionChanged += new System.EventHandler(this.dgv_Facture_SelectionChanged);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(718, 827);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 36);
            this.button6.TabIndex = 38;
            this.button6.Text = "إغلاق";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(12, 451);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 36);
            this.button2.TabIndex = 39;
            this.button2.Text = "إظهار الفاتورة";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 839);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "عدد المنتوجات : ";
            // 
            // lbl_NbrProd
            // 
            this.lbl_NbrProd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_NbrProd.AutoSize = true;
            this.lbl_NbrProd.Location = new System.Drawing.Point(113, 839);
            this.lbl_NbrProd.Name = "lbl_NbrProd";
            this.lbl_NbrProd.Size = new System.Drawing.Size(13, 13);
            this.lbl_NbrProd.TabIndex = 40;
            this.lbl_NbrProd.Text = "0";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(673, 463);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "المبيعات الظاهرة : ";
            // 
            // lbl_VentAp
            // 
            this.lbl_VentAp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_VentAp.AutoSize = true;
            this.lbl_VentAp.Location = new System.Drawing.Point(783, 463);
            this.lbl_VentAp.Name = "lbl_VentAp";
            this.lbl_VentAp.Size = new System.Drawing.Size(13, 13);
            this.lbl_VentAp.TabIndex = 40;
            this.lbl_VentAp.Text = "0";
            // 
            // dgv_DetailFacture
            // 
            this.dgv_DetailFacture.AllowUserToAddRows = false;
            this.dgv_DetailFacture.AllowUserToDeleteRows = false;
            this.dgv_DetailFacture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_DetailFacture.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_DetailFacture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DetailFacture.Location = new System.Drawing.Point(12, 546);
            this.dgv_DetailFacture.Name = "dgv_DetailFacture";
            this.dgv_DetailFacture.ReadOnly = true;
            this.dgv_DetailFacture.Size = new System.Drawing.Size(790, 275);
            this.dgv_DetailFacture.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 517);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "المنتوجات : ";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.Teal;
            this.label11.Location = new System.Drawing.Point(43, 502);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(731, 3);
            this.label11.TabIndex = 52;
            // 
            // AffVente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 875);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbl_VentAp);
            this.Controls.Add(this.lbl_NbrProd);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dgv_DetailFacture);
            this.Controls.Add(this.dgv_Facture);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Name = "AffVente";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "لائحة المبيعات";
            this.Load += new System.EventHandler(this.AffVente_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Facture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DetailFacture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_dateFact;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nomC;
        private System.Windows.Forms.DataGridView dgv_Facture;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_NbrProd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_VentAp;
        private System.Windows.Forms.TextBox txt_numFact;
        private System.Windows.Forms.DataGridView dgv_DetailFacture;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox ch_ShDt;
    }
}