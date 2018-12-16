namespace Gestion_des_factures
{
    partial class MdfProduit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MdfProduit));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_pb = new System.Windows.Forms.TextBox();
            this.txt_pc = new System.Windows.Forms.TextBox();
            this.txt_pa = new System.Windows.Forms.TextBox();
            this.nud_qttMn = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.nud_qtt = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_nmPrd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_tpPrd = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_nmType = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cb_chngType = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_qttMn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_qtt)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(275, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 44);
            this.label1.TabIndex = 34;
            this.label1.Text = "تعديل السلعة رقم : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txt_pb);
            this.groupBox2.Controls.Add(this.txt_pc);
            this.groupBox2.Controls.Add(this.txt_pa);
            this.groupBox2.Controls.Add(this.nud_qttMn);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.nud_qtt);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txt_nmPrd);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cb_tpPrd);
            this.groupBox2.Location = new System.Drawing.Point(12, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(657, 117);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "تعديل السلع";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(326, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "تم تعديل المعلومات بنجاح";
            this.label3.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(500, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 34;
            this.button2.Text = "تعديل سلعة";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_pb
            // 
            this.txt_pb.Location = new System.Drawing.Point(353, 52);
            this.txt_pb.Name = "txt_pb";
            this.txt_pb.Size = new System.Drawing.Size(67, 20);
            this.txt_pb.TabIndex = 33;
            this.txt_pb.TextChanged += new System.EventHandler(this.saved);
            // 
            // txt_pc
            // 
            this.txt_pc.Location = new System.Drawing.Point(216, 49);
            this.txt_pc.Name = "txt_pc";
            this.txt_pc.Size = new System.Drawing.Size(67, 20);
            this.txt_pc.TabIndex = 33;
            this.txt_pc.TextChanged += new System.EventHandler(this.saved);
            // 
            // txt_pa
            // 
            this.txt_pa.Location = new System.Drawing.Point(508, 52);
            this.txt_pa.Name = "txt_pa";
            this.txt_pa.Size = new System.Drawing.Size(67, 20);
            this.txt_pa.TabIndex = 33;
            this.txt_pa.TextChanged += new System.EventHandler(this.saved);
            // 
            // nud_qttMn
            // 
            this.nud_qttMn.Location = new System.Drawing.Point(6, 49);
            this.nud_qttMn.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nud_qttMn.Name = "nud_qttMn";
            this.nud_qttMn.Size = new System.Drawing.Size(65, 20);
            this.nud_qttMn.TabIndex = 32;
            this.nud_qttMn.ValueChanged += new System.EventHandler(this.saved);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(73, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = " العدد الأدنى للتنبيه : ";
            // 
            // nud_qtt
            // 
            this.nud_qtt.Location = new System.Drawing.Point(6, 19);
            this.nud_qtt.Name = "nud_qtt";
            this.nud_qtt.Size = new System.Drawing.Size(65, 20);
            this.nud_qtt.TabIndex = 30;
            this.nud_qtt.ValueChanged += new System.EventHandler(this.saved);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(75, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "العدد : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(289, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "الثمن C :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(426, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "الثمن B :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(605, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "الثمن A :";
            // 
            // txt_nmPrd
            // 
            this.txt_nmPrd.Location = new System.Drawing.Point(353, 19);
            this.txt_nmPrd.Name = "txt_nmPrd";
            this.txt_nmPrd.Size = new System.Drawing.Size(222, 20);
            this.txt_nmPrd.TabIndex = 15;
            this.txt_nmPrd.TextChanged += new System.EventHandler(this.saved);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(584, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "إسم السلعة : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "نوع :  ";
            // 
            // cb_tpPrd
            // 
            this.cb_tpPrd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tpPrd.FormattingEnabled = true;
            this.cb_tpPrd.Location = new System.Drawing.Point(145, 19);
            this.cb_tpPrd.Name = "cb_tpPrd";
            this.cb_tpPrd.Size = new System.Drawing.Size(138, 21);
            this.cb_tpPrd.TabIndex = 12;
            this.cb_tpPrd.SelectedIndexChanged += new System.EventHandler(this.cb_tpPrd_SelectedIndexChanged);
            this.cb_tpPrd.SelectedValueChanged += new System.EventHandler(this.saved);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(109, 260);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "إغلاق";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 260);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "حفظ التعديلات";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txt_nmType);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.cb_chngType);
            this.groupBox1.Location = new System.Drawing.Point(12, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 51);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تعديل النوع";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(86, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 22);
            this.button1.TabIndex = 16;
            this.button1.Text = "تعديل";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_nmType
            // 
            this.txt_nmType.Location = new System.Drawing.Point(216, 17);
            this.txt_nmType.Name = "txt_nmType";
            this.txt_nmType.Size = new System.Drawing.Size(119, 20);
            this.txt_nmType.TabIndex = 15;
            this.txt_nmType.TextChanged += new System.EventHandler(this.txt_nmType_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(344, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "إسم النوع : ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(614, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "نوع :  ";
            // 
            // cb_chngType
            // 
            this.cb_chngType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_chngType.FormattingEnabled = true;
            this.cb_chngType.Location = new System.Drawing.Point(461, 17);
            this.cb_chngType.Name = "cb_chngType";
            this.cb_chngType.Size = new System.Drawing.Size(138, 21);
            this.cb_chngType.TabIndex = 12;
            this.cb_chngType.SelectedIndexChanged += new System.EventHandler(this.cb_chngType_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(210, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            // 
            // MdfProduit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 292);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(692, 330);
            this.Name = "MdfProduit";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "تعديل السلع";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MdfProduit_FormClosing);
            this.Load += new System.EventHandler(this.MdfProduit_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_qttMn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_qtt)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_nmPrd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nud_qttMn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nud_qtt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cb_tpPrd;
        private System.Windows.Forms.TextBox txt_pb;
        private System.Windows.Forms.TextBox txt_pc;
        private System.Windows.Forms.TextBox txt_pa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_nmType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cb_chngType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}