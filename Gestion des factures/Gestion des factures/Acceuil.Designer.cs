namespace Gestion_des_factures
{
    partial class Acceuil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.إضافةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AjtVentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ttVentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تعديلToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AffProdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AjtProdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MdfProdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.القروضToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AffDtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AjtDtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MdfDtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تعديلالدخولToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_nbrPrdStk = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_PrdFini = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_PrdPrsqFini = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_dernProdajt = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_prodFini = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dernProdajt)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prodFini)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.إضافةToolStripMenuItem,
            this.تعديلToolStripMenuItem,
            this.القروضToolStripMenuItem,
            this.تعديلالدخولToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(972, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // إضافةToolStripMenuItem
            // 
            this.إضافةToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AjtVentToolStripMenuItem,
            this.ttVentToolStripMenuItem});
            this.إضافةToolStripMenuItem.Name = "إضافةToolStripMenuItem";
            this.إضافةToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.إضافةToolStripMenuItem.Text = "المبيعات";
            // 
            // AjtVentToolStripMenuItem
            // 
            this.AjtVentToolStripMenuItem.Name = "AjtVentToolStripMenuItem";
            this.AjtVentToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.AjtVentToolStripMenuItem.Text = "إضافة بيع";
            this.AjtVentToolStripMenuItem.Click += new System.EventHandler(this.AjtVentToolStripMenuItem_Click);
            // 
            // ttVentToolStripMenuItem
            // 
            this.ttVentToolStripMenuItem.Name = "ttVentToolStripMenuItem";
            this.ttVentToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ttVentToolStripMenuItem.Text = "جميع المبيعات";
            this.ttVentToolStripMenuItem.Click += new System.EventHandler(this.ttVentToolStripMenuItem_Click);
            // 
            // تعديلToolStripMenuItem
            // 
            this.تعديلToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AffProdToolStripMenuItem,
            this.AjtProdToolStripMenuItem,
            this.MdfProdToolStripMenuItem});
            this.تعديلToolStripMenuItem.Name = "تعديلToolStripMenuItem";
            this.تعديلToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.تعديلToolStripMenuItem.Text = "المخزن";
            // 
            // AffProdToolStripMenuItem
            // 
            this.AffProdToolStripMenuItem.Name = "AffProdToolStripMenuItem";
            this.AffProdToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.AffProdToolStripMenuItem.Text = "إظهار السلع";
            this.AffProdToolStripMenuItem.Click += new System.EventHandler(this.AffProdToolStripMenuItem_Click);
            // 
            // AjtProdToolStripMenuItem
            // 
            this.AjtProdToolStripMenuItem.Name = "AjtProdToolStripMenuItem";
            this.AjtProdToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.AjtProdToolStripMenuItem.Text = "إضافة السلع";
            this.AjtProdToolStripMenuItem.Click += new System.EventHandler(this.AjtProdToolStripMenuItem_Click);
            // 
            // MdfProdToolStripMenuItem
            // 
            this.MdfProdToolStripMenuItem.Name = "MdfProdToolStripMenuItem";
            this.MdfProdToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.MdfProdToolStripMenuItem.Text = "تعديل السلع";
            this.MdfProdToolStripMenuItem.Click += new System.EventHandler(this.MdfProdToolStripMenuItem_Click);
            // 
            // القروضToolStripMenuItem
            // 
            this.القروضToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AffDtToolStripMenuItem,
            this.AjtDtToolStripMenuItem,
            this.MdfDtToolStripMenuItem});
            this.القروضToolStripMenuItem.Name = "القروضToolStripMenuItem";
            this.القروضToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.القروضToolStripMenuItem.Text = "إدارة القروض";
            // 
            // AffDtToolStripMenuItem
            // 
            this.AffDtToolStripMenuItem.Name = "AffDtToolStripMenuItem";
            this.AffDtToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.AffDtToolStripMenuItem.Text = "إظهار القروض";
            this.AffDtToolStripMenuItem.Click += new System.EventHandler(this.AffDtToolStripMenuItem_Click);
            // 
            // AjtDtToolStripMenuItem
            // 
            this.AjtDtToolStripMenuItem.Name = "AjtDtToolStripMenuItem";
            this.AjtDtToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.AjtDtToolStripMenuItem.Text = "إضافة قرض";
            this.AjtDtToolStripMenuItem.Click += new System.EventHandler(this.AjtDtToolStripMenuItem_Click);
            // 
            // MdfDtToolStripMenuItem
            // 
            this.MdfDtToolStripMenuItem.Name = "MdfDtToolStripMenuItem";
            this.MdfDtToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.MdfDtToolStripMenuItem.Text = "تعديل قرض";
            this.MdfDtToolStripMenuItem.Click += new System.EventHandler(this.MdfDtToolStripMenuItem_Click);
            // 
            // تعديلالدخولToolStripMenuItem
            // 
            this.تعديلالدخولToolStripMenuItem.Name = "تعديلالدخولToolStripMenuItem";
            this.تعديلالدخولToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.تعديلالدخولToolStripMenuItem.Text = "تعديل الدخول";
            this.تعديلالدخولToolStripMenuItem.Click += new System.EventHandler(this.تعديلالدخولToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(393, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "إدارة المبيعات";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "السلع في المخزن :  ";
            // 
            // lbl_nbrPrdStk
            // 
            this.lbl_nbrPrdStk.AutoSize = true;
            this.lbl_nbrPrdStk.Location = new System.Drawing.Point(113, 364);
            this.lbl_nbrPrdStk.Name = "lbl_nbrPrdStk";
            this.lbl_nbrPrdStk.Size = new System.Drawing.Size(13, 13);
            this.lbl_nbrPrdStk.TabIndex = 3;
            this.lbl_nbrPrdStk.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = " عدد السلع المنتهية : ";
            // 
            // lbl_PrdFini
            // 
            this.lbl_PrdFini.AutoSize = true;
            this.lbl_PrdFini.Location = new System.Drawing.Point(325, 313);
            this.lbl_PrdFini.Name = "lbl_PrdFini";
            this.lbl_PrdFini.Size = new System.Drawing.Size(13, 13);
            this.lbl_PrdFini.TabIndex = 5;
            this.lbl_PrdFini.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "سلع شارفة على الإنتهاء : ";
            // 
            // lbl_PrdPrsqFini
            // 
            this.lbl_PrdPrsqFini.AutoSize = true;
            this.lbl_PrdPrsqFini.Location = new System.Drawing.Point(292, 364);
            this.lbl_PrdPrsqFini.Name = "lbl_PrdPrsqFini";
            this.lbl_PrdPrsqFini.Size = new System.Drawing.Size(13, 13);
            this.lbl_PrdPrsqFini.TabIndex = 7;
            this.lbl_PrdPrsqFini.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_dernProdajt);
            this.groupBox1.Location = new System.Drawing.Point(14, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 252);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "آخر السلع المضافة";
            // 
            // dgv_dernProdajt
            // 
            this.dgv_dernProdajt.AllowUserToAddRows = false;
            this.dgv_dernProdajt.AllowUserToDeleteRows = false;
            this.dgv_dernProdajt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dernProdajt.Location = new System.Drawing.Point(6, 19);
            this.dgv_dernProdajt.Name = "dgv_dernProdajt";
            this.dgv_dernProdajt.ReadOnly = true;
            this.dgv_dernProdajt.Size = new System.Drawing.Size(436, 223);
            this.dgv_dernProdajt.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_prodFini);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lbl_PrdFini);
            this.groupBox2.Location = new System.Drawing.Point(507, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 338);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "السلع المنتهية : ";
            // 
            // dgv_prodFini
            // 
            this.dgv_prodFini.AllowUserToAddRows = false;
            this.dgv_prodFini.AllowUserToDeleteRows = false;
            this.dgv_prodFini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_prodFini.Location = new System.Drawing.Point(6, 19);
            this.dgv_prodFini.Name = "dgv_prodFini";
            this.dgv_prodFini.ReadOnly = true;
            this.dgv_prodFini.Size = new System.Drawing.Size(436, 284);
            this.dgv_prodFini.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(848, 438);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 42);
            this.button1.TabIndex = 11;
            this.button1.Text = "خروج";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 444);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 36);
            this.button2.TabIndex = 12;
            this.button2.Text = "فتح مجلد الفاتورات";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(146, 444);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 36);
            this.button3.TabIndex = 12;
            this.button3.Text = "قفل البرنامج";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Acceuil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 492);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_PrdPrsqFini);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_nbrPrdStk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Acceuil";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "إدارة المبيعات";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dernProdajt)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prodFini)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem إضافةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تعديلToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_nbrPrdStk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_PrdFini;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_PrdPrsqFini;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem AjtProdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MdfProdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AffProdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem القروضToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AjtDtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MdfDtToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv_dernProdajt;
        private System.Windows.Forms.DataGridView dgv_prodFini;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem AjtVentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ttVentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AffDtToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem تعديلالدخولToolStripMenuItem;
        private System.Windows.Forms.Button button3;
    }
}

