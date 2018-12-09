namespace Gestion_des_factures
{
    partial class MdfDette
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
            this.txt_adress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.msk_teleC = new System.Windows.Forms.MaskedTextBox();
            this.txt_nmC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_nmC = new System.Windows.Forms.ComboBox();
            this.txt_pxD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_numD = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_adress
            // 
            this.txt_adress.Location = new System.Drawing.Point(7, 52);
            this.txt_adress.Multiline = true;
            this.txt_adress.Name = "txt_adress";
            this.txt_adress.Size = new System.Drawing.Size(185, 53);
            this.txt_adress.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "عنوان الزبون : ";
            // 
            // msk_teleC
            // 
            this.msk_teleC.Location = new System.Drawing.Point(6, 15);
            this.msk_teleC.Mask = "00 00 00 00 00 00";
            this.msk_teleC.Name = "msk_teleC";
            this.msk_teleC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.msk_teleC.Size = new System.Drawing.Size(186, 20);
            this.msk_teleC.TabIndex = 59;
            // 
            // txt_nmC
            // 
            this.txt_nmC.Location = new System.Drawing.Point(336, 19);
            this.txt_nmC.Name = "txt_nmC";
            this.txt_nmC.Size = new System.Drawing.Size(186, 20);
            this.txt_nmC.TabIndex = 54;
            this.txt_nmC.TextChanged += new System.EventHandler(this.txt_nmC_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = " هاتف الزبون : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 36);
            this.button1.TabIndex = 57;
            this.button1.Text = "حفض";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(508, 280);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 36);
            this.button6.TabIndex = 58;
            this.button6.Text = "إغلاق";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(532, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "الدين :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Mistral", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(203, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(201, 44);
            this.label10.TabIndex = 55;
            this.label10.Text = "تعديل القروض ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(330, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "إسم الزبون : ";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(431, 82);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 23);
            this.button4.TabIndex = 48;
            this.button4.Text = "تعديل الدين";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(528, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "الإسم : ";
            // 
            // cb_nmC
            // 
            this.cb_nmC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_nmC.FormattingEnabled = true;
            this.cb_nmC.Location = new System.Drawing.Point(410, 72);
            this.cb_nmC.Name = "cb_nmC";
            this.cb_nmC.Size = new System.Drawing.Size(186, 21);
            this.cb_nmC.TabIndex = 63;
            this.cb_nmC.SelectedIndexChanged += new System.EventHandler(this.cb_nmC_SelectedIndexChanged);
            this.cb_nmC.SelectionChangeCommitted += new System.EventHandler(this.cb_nmC_SelectionChangeCommitted);
            // 
            // txt_pxD
            // 
            this.txt_pxD.Location = new System.Drawing.Point(407, 52);
            this.txt_pxD.Name = "txt_pxD";
            this.txt_pxD.Size = new System.Drawing.Size(115, 20);
            this.txt_pxD.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 65;
            this.label4.Text = "رقم الدين : ";
            // 
            // txt_numD
            // 
            this.txt_numD.Location = new System.Drawing.Point(75, 72);
            this.txt_numD.Name = "txt_numD";
            this.txt_numD.Size = new System.Drawing.Size(115, 20);
            this.txt_numD.TabIndex = 64;
            this.txt_numD.TextChanged += new System.EventHandler(this.txt_numD_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_nmC);
            this.groupBox1.Controls.Add(this.txt_pxD);
            this.groupBox1.Controls.Add(this.txt_adress);
            this.groupBox1.Controls.Add(this.msk_teleC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(15, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 119);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "معلومات الزبون";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(268, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "تم تعديل المعلومات بنجاح";
            this.label5.Visible = false;
            // 
            // MdfDette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 328);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_numD);
            this.Controls.Add(this.cb_nmC);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(628, 366);
            this.MinimumSize = new System.Drawing.Size(628, 366);
            this.Name = "MdfDette";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "تعديل قرض";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MdfDette_FormClosing);
            this.Load += new System.EventHandler(this.MdfDette_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_adress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox msk_teleC;
        private System.Windows.Forms.TextBox txt_nmC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_nmC;
        private System.Windows.Forms.TextBox txt_pxD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_numD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
    }
}