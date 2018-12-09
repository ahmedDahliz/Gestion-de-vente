namespace Gestion_des_factures
{
    partial class AjtDette
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
            this.label10 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.dgv_AjtDette = new System.Windows.Forms.DataGridView();
            this.txt_nmClt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.mst_teleClt = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Adrss = new System.Windows.Forms.TextBox();
            this.txt_pxDtt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_DetteAjt = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AjtDette)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Mistral", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(311, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(201, 44);
            this.label10.TabIndex = 38;
            this.label10.Text = "إضافة القروض";
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.Location = new System.Drawing.Point(196, 402);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 36);
            this.button6.TabIndex = 44;
            this.button6.Text = "إغلاق";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // dgv_AjtDette
            // 
            this.dgv_AjtDette.AllowUserToAddRows = false;
            this.dgv_AjtDette.AllowUserToDeleteRows = false;
            this.dgv_AjtDette.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_AjtDette.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_AjtDette.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AjtDette.Location = new System.Drawing.Point(319, 74);
            this.dgv_AjtDette.MultiSelect = false;
            this.dgv_AjtDette.Name = "dgv_AjtDette";
            this.dgv_AjtDette.ReadOnly = true;
            this.dgv_AjtDette.Size = new System.Drawing.Size(512, 364);
            this.dgv_AjtDette.TabIndex = 43;
            this.dgv_AjtDette.SelectionChanged += new System.EventHandler(this.dgv_AjtDette_SelectionChanged);
            // 
            // txt_nmClt
            // 
            this.txt_nmClt.Location = new System.Drawing.Point(98, 91);
            this.txt_nmClt.Name = "txt_nmClt";
            this.txt_nmClt.Size = new System.Drawing.Size(186, 20);
            this.txt_nmClt.TabIndex = 30;
            this.txt_nmClt.TextChanged += new System.EventHandler(this.txt_nmClt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = " هاتف الزبون : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "الدين :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "إسم الزبون : ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(123, 284);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "إفراغ الحقول";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(21, 284);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "أضف الدين";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // mst_teleClt
            // 
            this.mst_teleClt.Location = new System.Drawing.Point(98, 131);
            this.mst_teleClt.Mask = "00 00 00 00 00 00";
            this.mst_teleClt.Name = "mst_teleClt";
            this.mst_teleClt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mst_teleClt.Size = new System.Drawing.Size(186, 20);
            this.mst_teleClt.TabIndex = 45;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(12, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 36);
            this.button1.TabIndex = 44;
            this.button1.Text = "حفض";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "عنوان الزبون : ";
            // 
            // txt_Adrss
            // 
            this.txt_Adrss.Location = new System.Drawing.Point(99, 178);
            this.txt_Adrss.Multiline = true;
            this.txt_Adrss.Name = "txt_Adrss";
            this.txt_Adrss.Size = new System.Drawing.Size(185, 63);
            this.txt_Adrss.TabIndex = 47;
            // 
            // txt_pxDtt
            // 
            this.txt_pxDtt.Location = new System.Drawing.Point(98, 247);
            this.txt_pxDtt.Name = "txt_pxDtt";
            this.txt_pxDtt.Size = new System.Drawing.Size(108, 20);
            this.txt_pxDtt.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "عدد الديون : ";
            // 
            // lbl_DetteAjt
            // 
            this.lbl_DetteAjt.AutoSize = true;
            this.lbl_DetteAjt.Location = new System.Drawing.Point(95, 376);
            this.lbl_DetteAjt.Name = "lbl_DetteAjt";
            this.lbl_DetteAjt.Size = new System.Drawing.Size(13, 13);
            this.lbl_DetteAjt.TabIndex = 49;
            this.lbl_DetteAjt.Text = "0";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(21, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "تعديل";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(21, 284);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(91, 23);
            this.button5.TabIndex = 50;
            this.button5.Text = "تعديل";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(123, 325);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(91, 23);
            this.button7.TabIndex = 10;
            this.button7.Text = "مسح";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // AjtDette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.lbl_DetteAjt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Adrss);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mst_teleClt);
            this.Controls.Add(this.txt_pxDtt);
            this.Controls.Add(this.txt_nmClt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dgv_AjtDette);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Name = "AjtDette";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "إضافة قرض";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AjtDette_FormClosing);
            this.Load += new System.EventHandler(this.AjtDette_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AjtDette)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dgv_AjtDette;
        private System.Windows.Forms.TextBox txt_nmClt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MaskedTextBox mst_teleClt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Adrss;
        private System.Windows.Forms.TextBox txt_pxDtt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_DetteAjt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
    }
}