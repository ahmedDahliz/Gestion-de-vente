namespace Gestion_des_factures
{
    partial class AffProduit
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
            this.button6 = new System.Windows.Forms.Button();
            this.dgv_AfficheProd = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_datAjout = new System.Windows.Forms.DateTimePicker();
            this.rb_b = new System.Windows.Forms.RadioButton();
            this.rb_c = new System.Windows.Forms.RadioButton();
            this.rb_a = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_NomProd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txt_nuProd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_nmProd = new System.Windows.Forms.Label();
            this.txt_prix = new System.Windows.Forms.TextBox();
            this.rb_sansprx = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AfficheProd)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(744, 531);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 36);
            this.button6.TabIndex = 32;
            this.button6.Text = "إغلاق";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // dgv_AfficheProd
            // 
            this.dgv_AfficheProd.AllowUserToAddRows = false;
            this.dgv_AfficheProd.AllowUserToDeleteRows = false;
            this.dgv_AfficheProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AfficheProd.Location = new System.Drawing.Point(9, 203);
            this.dgv_AfficheProd.Name = "dgv_AfficheProd";
            this.dgv_AfficheProd.ReadOnly = true;
            this.dgv_AfficheProd.Size = new System.Drawing.Size(823, 291);
            this.dgv_AfficheProd.TabIndex = 30;
            this.dgv_AfficheProd.Sorted += new System.EventHandler(this.dgv_AfficheProd_Sorted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(295, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 44);
            this.label1.TabIndex = 33;
            this.label1.Text = "لائحة السلع";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_prix);
            this.groupBox2.Controls.Add(this.txt_nuProd);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtp_datAjout);
            this.groupBox2.Controls.Add(this.rb_b);
            this.groupBox2.Controls.Add(this.rb_c);
            this.groupBox2.Controls.Add(this.rb_sansprx);
            this.groupBox2.Controls.Add(this.rb_a);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txt_NomProd);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cb_type);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(820, 127);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "بحث حسب";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "تاريخ الإضافة : ";
            // 
            // dtp_datAjout
            // 
            this.dtp_datAjout.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_datAjout.Location = new System.Drawing.Point(185, 53);
            this.dtp_datAjout.Name = "dtp_datAjout";
            this.dtp_datAjout.Size = new System.Drawing.Size(96, 20);
            this.dtp_datAjout.TabIndex = 26;
            this.dtp_datAjout.ValueChanged += new System.EventHandler(this.dtp_datAjout_ValueChanged);
            // 
            // rb_b
            // 
            this.rb_b.AutoSize = true;
            this.rb_b.Location = new System.Drawing.Point(546, 54);
            this.rb_b.Name = "rb_b";
            this.rb_b.Size = new System.Drawing.Size(32, 17);
            this.rb_b.TabIndex = 25;
            this.rb_b.Text = "B";
            this.rb_b.UseVisualStyleBackColor = true;
            // 
            // rb_c
            // 
            this.rb_c.AutoSize = true;
            this.rb_c.Location = new System.Drawing.Point(594, 54);
            this.rb_c.Name = "rb_c";
            this.rb_c.Size = new System.Drawing.Size(32, 17);
            this.rb_c.TabIndex = 24;
            this.rb_c.Text = "C";
            this.rb_c.UseVisualStyleBackColor = true;
            // 
            // rb_a
            // 
            this.rb_a.AutoSize = true;
            this.rb_a.Location = new System.Drawing.Point(500, 54);
            this.rb_a.Name = "rb_a";
            this.rb_a.Size = new System.Drawing.Size(32, 17);
            this.rb_a.TabIndex = 23;
            this.rb_a.Text = "A";
            this.rb_a.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(770, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "الثمن  :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "السلع على وشك الإنتهاء";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_NomProd
            // 
            this.txt_NomProd.Location = new System.Drawing.Point(287, 21);
            this.txt_NomProd.Name = "txt_NomProd";
            this.txt_NomProd.Size = new System.Drawing.Size(197, 20);
            this.txt_NomProd.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(490, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "إسم السلعة : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "نوع :  ";
            // 
            // cb_type
            // 
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Location = new System.Drawing.Point(80, 21);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(138, 21);
            this.cb_type.TabIndex = 12;
            this.cb_type.Text = " ";
            this.cb_type.SelectedIndexChanged += new System.EventHandler(this.cb_type_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(396, 88);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "إفراغ الحقول";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(617, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = " السلع المنتهية";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(714, 88);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "جميع السلع";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txt_nuProd
            // 
            this.txt_nuProd.Location = new System.Drawing.Point(593, 21);
            this.txt_nuProd.Name = "txt_nuProd";
            this.txt_nuProd.Size = new System.Drawing.Size(123, 20);
            this.txt_nuProd.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(747, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "رقم السلعة :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 511);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "عدد السلع : ";
            // 
            // lbl_nmProd
            // 
            this.lbl_nmProd.AutoSize = true;
            this.lbl_nmProd.Location = new System.Drawing.Point(90, 511);
            this.lbl_nmProd.Name = "lbl_nmProd";
            this.lbl_nmProd.Size = new System.Drawing.Size(13, 13);
            this.lbl_nmProd.TabIndex = 35;
            this.lbl_nmProd.Text = "0";
            // 
            // txt_prix
            // 
            this.txt_prix.Location = new System.Drawing.Point(632, 53);
            this.txt_prix.Name = "txt_prix";
            this.txt_prix.Size = new System.Drawing.Size(84, 20);
            this.txt_prix.TabIndex = 30;
            this.txt_prix.TextChanged += new System.EventHandler(this.txt_prix_TextChanged);
            // 
            // rb_sansprx
            // 
            this.rb_sansprx.AutoSize = true;
            this.rb_sansprx.Checked = true;
            this.rb_sansprx.Location = new System.Drawing.Point(396, 54);
            this.rb_sansprx.Name = "rb_sansprx";
            this.rb_sansprx.Size = new System.Drawing.Size(88, 17);
            this.rb_sansprx.TabIndex = 23;
            this.rb_sansprx.Text = "بحث بدون ثمن";
            this.rb_sansprx.UseVisualStyleBackColor = true;
            // 
            // AffProduit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 579);
            this.Controls.Add(this.lbl_nmProd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dgv_AfficheProd);
            this.Name = "AffProduit";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "لائحة السلع";
            this.Load += new System.EventHandler(this.AffProduit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AfficheProd)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dgv_AfficheProd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.TextBox txt_NomProd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rb_b;
        private System.Windows.Forms.RadioButton rb_c;
        private System.Windows.Forms.RadioButton rb_a;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_datAjout;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_nuProd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_nmProd;
        private System.Windows.Forms.TextBox txt_prix;
        private System.Windows.Forms.RadioButton rb_sansprx;
    }
}