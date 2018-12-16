namespace Gestion_des_factures
{
    partial class AffDette
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AffDette));
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ch_ShDt = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_datAjout = new System.Windows.Forms.DateTimePicker();
            this.txt_teleC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_numD = new System.Windows.Forms.TextBox();
            this.txt_pxD = new System.Windows.Forms.TextBox();
            this.txt_nmC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.dgv_affDette = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.lbl_nmDett = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_affDette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Mistral", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(277, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(190, 44);
            this.label10.TabIndex = 37;
            this.label10.Text = "لائحة القروض";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ch_ShDt);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtp_datAjout);
            this.groupBox2.Controls.Add(this.txt_teleC);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_numD);
            this.groupBox2.Controls.Add(this.txt_pxD);
            this.groupBox2.Controls.Add(this.txt_nmC);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(12, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(662, 127);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "بحث حسب";
            // 
            // ch_ShDt
            // 
            this.ch_ShDt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ch_ShDt.AutoSize = true;
            this.ch_ShDt.Checked = true;
            this.ch_ShDt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ch_ShDt.Location = new System.Drawing.Point(91, 60);
            this.ch_ShDt.Name = "ch_ShDt";
            this.ch_ShDt.Size = new System.Drawing.Size(98, 17);
            this.ch_ShDt.TabIndex = 34;
            this.ch_ShDt.Text = "بحث بدون تاريخ";
            this.ch_ShDt.UseVisualStyleBackColor = true;
            this.ch_ShDt.CheckedChanged += new System.EventHandler(this.ch_ShDt_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "تاريخ الإضافة : ";
            // 
            // dtp_datAjout
            // 
            this.dtp_datAjout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_datAjout.Checked = false;
            this.dtp_datAjout.Enabled = false;
            this.dtp_datAjout.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_datAjout.Location = new System.Drawing.Point(15, 19);
            this.dtp_datAjout.Name = "dtp_datAjout";
            this.dtp_datAjout.Size = new System.Drawing.Size(96, 20);
            this.dtp_datAjout.TabIndex = 32;
            this.dtp_datAjout.Value = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_datAjout.ValueChanged += new System.EventHandler(this.txt_nmV_TextChanged_1);
            // 
            // txt_teleC
            // 
            this.txt_teleC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_teleC.Location = new System.Drawing.Point(207, 58);
            this.txt_teleC.Name = "txt_teleC";
            this.txt_teleC.Size = new System.Drawing.Size(163, 20);
            this.txt_teleC.TabIndex = 30;
            this.txt_teleC.TextChanged += new System.EventHandler(this.txt_nmV_TextChanged_1);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(373, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = " هاتف الزبون : ";
            // 
            // txt_numD
            // 
            this.txt_numD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_numD.Location = new System.Drawing.Point(467, 19);
            this.txt_numD.Name = "txt_numD";
            this.txt_numD.Size = new System.Drawing.Size(98, 20);
            this.txt_numD.TabIndex = 28;
            this.txt_numD.TextChanged += new System.EventHandler(this.txt_nmV_TextChanged_1);
            // 
            // txt_pxD
            // 
            this.txt_pxD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_pxD.Location = new System.Drawing.Point(467, 57);
            this.txt_pxD.Name = "txt_pxD";
            this.txt_pxD.Size = new System.Drawing.Size(98, 20);
            this.txt_pxD.TabIndex = 28;
            this.txt_pxD.TextChanged += new System.EventHandler(this.txt_nmV_TextChanged_1);
            // 
            // txt_nmC
            // 
            this.txt_nmC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_nmC.Location = new System.Drawing.Point(207, 19);
            this.txt_nmC.Name = "txt_nmC";
            this.txt_nmC.Size = new System.Drawing.Size(163, 20);
            this.txt_nmC.TabIndex = 28;
            this.txt_nmC.TextChanged += new System.EventHandler(this.txt_nmV_TextChanged_1);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(597, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "رقم الدين : ";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(592, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "واجب الدين :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(382, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "إسم الزبون : ";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(560, 98);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "جميع الديون";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dgv_affDette
            // 
            this.dgv_affDette.AllowUserToAddRows = false;
            this.dgv_affDette.AllowUserToDeleteRows = false;
            this.dgv_affDette.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_affDette.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_affDette.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_affDette.Location = new System.Drawing.Point(12, 188);
            this.dgv_affDette.Name = "dgv_affDette";
            this.dgv_affDette.ReadOnly = true;
            this.dgv_affDette.Size = new System.Drawing.Size(662, 218);
            this.dgv_affDette.TabIndex = 39;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(586, 412);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 36);
            this.button6.TabIndex = 40;
            this.button6.Text = "إغلاق";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // lbl_nmDett
            // 
            this.lbl_nmDett.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_nmDett.AutoSize = true;
            this.lbl_nmDett.Location = new System.Drawing.Point(87, 424);
            this.lbl_nmDett.Name = "lbl_nmDett";
            this.lbl_nmDett.Size = new System.Drawing.Size(13, 13);
            this.lbl_nmDett.TabIndex = 41;
            this.lbl_nmDett.Text = "0";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 424);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "عدد االديون : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(206, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // AffDette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 458);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_nmDett);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dgv_affDette);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label10);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AffDette";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "لائحة القروض";
            this.Load += new System.EventHandler(this.AffDette_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_affDette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_teleC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nmC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dgv_affDette;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txt_pxD;
        private System.Windows.Forms.TextBox txt_numD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_nmDett;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ch_ShDt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_datAjout;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}