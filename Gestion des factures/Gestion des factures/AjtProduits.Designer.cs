﻿namespace Gestion_des_factures
{
    partial class AjtProduits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AjtProduits));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_nvType = new System.Windows.Forms.ComboBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_nomTp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_nomPrd = new System.Windows.Forms.TextBox();
            this.cb_tpPrd = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.nud_qttMn = new System.Windows.Forms.NumericUpDown();
            this.nud_qtt = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.dgr_nvProd = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groubbox1 = new System.Windows.Forms.GroupBox();
            this.txt_prxB = new System.Windows.Forms.TextBox();
            this.txt_prxC = new System.Windows.Forms.TextBox();
            this.txt_prxA = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.lbl_prdAjt = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_qttMn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_qtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgr_nvProd)).BeginInit();
            this.groubbox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(386, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 44);
            this.label1.TabIndex = 2;
            this.label1.Text = "إضافة السلع";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox2.Controls.Add(this.cb_nvType);
            this.groupBox2.Controls.Add(this.button11);
            this.groupBox2.Controls.Add(this.button10);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_nomTp);
            this.groupBox2.Location = new System.Drawing.Point(6, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 117);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "إضافة نوع السلعة";
            // 
            // cb_nvType
            // 
            this.cb_nvType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_nvType.FormattingEnabled = true;
            this.cb_nvType.Location = new System.Drawing.Point(119, 51);
            this.cb_nvType.Name = "cb_nvType";
            this.cb_nvType.Size = new System.Drawing.Size(126, 21);
            this.cb_nvType.TabIndex = 13;
            this.cb_nvType.SelectedIndexChanged += new System.EventHandler(this.cb_nvType_SelectedIndexChanged);
            this.cb_nvType.SelectionChangeCommitted += new System.EventHandler(this.cb_nvType_SelectionChangeCommitted);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(20, 82);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 12;
            this.button11.Text = "مسح";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(241, 82);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 12;
            this.button10.Text = "تعديل";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(130, 82);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "إفراغ الحقل";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(20, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "إضافة";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "الأنواع : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "إسم النوع : ";
            // 
            // txt_nomTp
            // 
            this.txt_nomTp.Location = new System.Drawing.Point(119, 22);
            this.txt_nomTp.Name = "txt_nomTp";
            this.txt_nomTp.Size = new System.Drawing.Size(126, 20);
            this.txt_nomTp.TabIndex = 9;
            this.txt_nomTp.TextChanged += new System.EventHandler(this.txt_nomTp_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(752, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "إسم السلعة : ";
            // 
            // txt_nomPrd
            // 
            this.txt_nomPrd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txt_nomPrd.Location = new System.Drawing.Point(517, 28);
            this.txt_nomPrd.Name = "txt_nomPrd";
            this.txt_nomPrd.Size = new System.Drawing.Size(195, 20);
            this.txt_nomPrd.TabIndex = 1;
            // 
            // cb_tpPrd
            // 
            this.cb_tpPrd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cb_tpPrd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tpPrd.FormattingEnabled = true;
            this.cb_tpPrd.Location = new System.Drawing.Point(572, 53);
            this.cb_tpPrd.Name = "cb_tpPrd";
            this.cb_tpPrd.Size = new System.Drawing.Size(140, 21);
            this.cb_tpPrd.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(779, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "النوع : ";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(435, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "الثمن A :";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(435, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "الثمن B :";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(435, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "الثمن C :";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(780, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "العدد : ";
            // 
            // nud_qttMn
            // 
            this.nud_qttMn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nud_qttMn.Enabled = false;
            this.nud_qttMn.Location = new System.Drawing.Point(608, 107);
            this.nud_qttMn.Name = "nud_qttMn";
            this.nud_qttMn.Size = new System.Drawing.Size(105, 20);
            this.nud_qttMn.TabIndex = 4;
            this.nud_qttMn.ValueChanged += new System.EventHandler(this.nud_qttMn_ValueChanged);
            // 
            // nud_qtt
            // 
            this.nud_qtt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nud_qtt.Location = new System.Drawing.Point(608, 80);
            this.nud_qtt.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nud_qtt.Name = "nud_qtt";
            this.nud_qtt.Size = new System.Drawing.Size(104, 20);
            this.nud_qtt.TabIndex = 3;
            this.nud_qtt.ValueChanged += new System.EventHandler(this.nud_qtt_ValueChanged);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(719, 109);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = " العدد الأدنى للتنبيه : ";
            // 
            // dgr_nvProd
            // 
            this.dgr_nvProd.AllowUserToAddRows = false;
            this.dgr_nvProd.AllowUserToDeleteRows = false;
            this.dgr_nvProd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgr_nvProd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgr_nvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgr_nvProd.Location = new System.Drawing.Point(12, 253);
            this.dgr_nvProd.MultiSelect = false;
            this.dgr_nvProd.Name = "dgr_nvProd";
            this.dgr_nvProd.ReadOnly = true;
            this.dgr_nvProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgr_nvProd.Size = new System.Drawing.Size(827, 260);
            this.dgr_nvProd.TabIndex = 27;
            this.dgr_nvProd.SelectionChanged += new System.EventHandler(this.dgr_nvProd_SelectionChanged);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Location = new System.Drawing.Point(12, 519);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 36);
            this.button5.TabIndex = 28;
            this.button5.Text = "حفض";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(751, 519);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 36);
            this.button6.TabIndex = 29;
            this.button6.Text = "إغلاق";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groubbox1
            // 
            this.groubbox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groubbox1.Controls.Add(this.txt_prxB);
            this.groubbox1.Controls.Add(this.txt_prxC);
            this.groubbox1.Controls.Add(this.txt_prxA);
            this.groubbox1.Controls.Add(this.button1);
            this.groubbox1.Controls.Add(this.button8);
            this.groubbox1.Controls.Add(this.button2);
            this.groubbox1.Controls.Add(this.label6);
            this.groubbox1.Controls.Add(this.txt_nomPrd);
            this.groubbox1.Controls.Add(this.groupBox2);
            this.groubbox1.Controls.Add(this.nud_qtt);
            this.groubbox1.Controls.Add(this.label13);
            this.groubbox1.Controls.Add(this.label8);
            this.groubbox1.Controls.Add(this.nud_qttMn);
            this.groubbox1.Controls.Add(this.cb_tpPrd);
            this.groubbox1.Controls.Add(this.label12);
            this.groubbox1.Controls.Add(this.label9);
            this.groubbox1.Controls.Add(this.label10);
            this.groubbox1.Controls.Add(this.label11);
            this.groubbox1.Location = new System.Drawing.Point(12, 75);
            this.groubbox1.Name = "groubbox1";
            this.groubbox1.Size = new System.Drawing.Size(827, 172);
            this.groubbox1.TabIndex = 30;
            this.groubbox1.TabStop = false;
            this.groubbox1.Text = "معلومات السلعة";
            this.groubbox1.Enter += new System.EventHandler(this.groubbox1_Enter);
            // 
            // txt_prxB
            // 
            this.txt_prxB.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txt_prxB.Location = new System.Drawing.Point(347, 51);
            this.txt_prxB.Name = "txt_prxB";
            this.txt_prxB.Size = new System.Drawing.Size(82, 20);
            this.txt_prxB.TabIndex = 6;
            // 
            // txt_prxC
            // 
            this.txt_prxC.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txt_prxC.Location = new System.Drawing.Point(347, 76);
            this.txt_prxC.Name = "txt_prxC";
            this.txt_prxC.Size = new System.Drawing.Size(82, 20);
            this.txt_prxC.TabIndex = 7;
            // 
            // txt_prxA
            // 
            this.txt_prxA.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txt_prxA.Location = new System.Drawing.Point(347, 25);
            this.txt_prxA.Name = "txt_prxA";
            this.txt_prxA.Size = new System.Drawing.Size(82, 20);
            this.txt_prxA.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(360, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 32);
            this.button1.TabIndex = 13;
            this.button1.Text = "إفراغ الحقول";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.Location = new System.Drawing.Point(453, 134);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(91, 32);
            this.button8.TabIndex = 7;
            this.button8.Text = "تعديل";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(454, 134);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 32);
            this.button2.TabIndex = 8;
            this.button2.Text = "إضافة";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 531);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "عدد السلع المضافة : ";
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(117, 519);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(88, 36);
            this.button7.TabIndex = 28;
            this.button7.Text = "تعديل";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // lbl_prdAjt
            // 
            this.lbl_prdAjt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_prdAjt.AutoSize = true;
            this.lbl_prdAjt.Location = new System.Drawing.Point(428, 531);
            this.lbl_prdAjt.Name = "lbl_prdAjt";
            this.lbl_prdAjt.Size = new System.Drawing.Size(13, 13);
            this.lbl_prdAjt.TabIndex = 5;
            this.lbl_prdAjt.Text = "0";
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button9.Enabled = false;
            this.button9.Location = new System.Drawing.Point(220, 519);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(88, 36);
            this.button9.TabIndex = 28;
            this.button9.Text = "مسح";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(326, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // AjtProduits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 567);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groubbox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dgr_nvProd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_prdAjt);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AjtProduits";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "إضافة السلع";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AjtProduits_FormClosing);
            this.Load += new System.EventHandler(this.AjtProduits_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_qttMn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_qtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgr_nvProd)).EndInit();
            this.groubbox1.ResumeLayout(false);
            this.groubbox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_nomTp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_nomPrd;
        private System.Windows.Forms.ComboBox cb_tpPrd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nud_qttMn;
        private System.Windows.Forms.NumericUpDown nud_qtt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgr_nvProd;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groubbox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_prxB;
        private System.Windows.Forms.TextBox txt_prxC;
        private System.Windows.Forms.TextBox txt_prxA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label lbl_prdAjt;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ComboBox cb_nvType;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}