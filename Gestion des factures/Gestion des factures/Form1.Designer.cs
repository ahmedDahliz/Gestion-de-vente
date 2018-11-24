namespace Gestion_des_factures
{
    partial class Form1
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
            this.تعديلToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_nbrPrdStk = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_PrdFini = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_PrdPrsqFini = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.القروضToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.إضافةتعديلالسلعToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.إضافةقرضToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تعديلقرضToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تعديلالسلعToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.البحثToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.إضافةفاتورةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.جميعالمبيعاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.البحثفيالقروضToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.إضافةToolStripMenuItem,
            this.تعديلToolStripMenuItem,
            this.القروضToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(972, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // إضافةToolStripMenuItem
            // 
            this.إضافةToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.إضافةفاتورةToolStripMenuItem,
            this.جميعالمبيعاتToolStripMenuItem});
            this.إضافةToolStripMenuItem.Name = "إضافةToolStripMenuItem";
            this.إضافةToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.إضافةToolStripMenuItem.Text = "المبيعات";
            // 
            // تعديلToolStripMenuItem
            // 
            this.تعديلToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.البحثToolStripMenuItem,
            this.إضافةتعديلالسلعToolStripMenuItem,
            this.تعديلالسلعToolStripMenuItem});
            this.تعديلToolStripMenuItem.Name = "تعديلToolStripMenuItem";
            this.تعديلToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.تعديلToolStripMenuItem.Text = "المخزن";
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
            this.lbl_nbrPrdStk.Location = new System.Drawing.Point(124, 364);
            this.lbl_nbrPrdStk.Name = "lbl_nbrPrdStk";
            this.lbl_nbrPrdStk.Size = new System.Drawing.Size(13, 13);
            this.lbl_nbrPrdStk.TabIndex = 3;
            this.lbl_nbrPrdStk.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "السلع المنتهية : ";
            // 
            // lbl_PrdFini
            // 
            this.lbl_PrdFini.AutoSize = true;
            this.lbl_PrdFini.Location = new System.Drawing.Point(417, 364);
            this.lbl_PrdFini.Name = "lbl_PrdFini";
            this.lbl_PrdFini.Size = new System.Drawing.Size(13, 13);
            this.lbl_PrdFini.TabIndex = 5;
            this.lbl_PrdFini.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 407);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "سلع شارفة على الإنتهاء : ";
            // 
            // lbl_PrdPrsqFini
            // 
            this.lbl_PrdPrsqFini.AutoSize = true;
            this.lbl_PrdPrsqFini.Location = new System.Drawing.Point(143, 407);
            this.lbl_PrdPrsqFini.Name = "lbl_PrdPrsqFini";
            this.lbl_PrdPrsqFini.Size = new System.Drawing.Size(13, 13);
            this.lbl_PrdPrsqFini.TabIndex = 7;
            this.lbl_PrdPrsqFini.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Location = new System.Drawing.Point(14, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 252);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "آخر السلع المضافة";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(507, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 338);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "آخر المبيعات";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(436, 307);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 19);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(436, 223);
            this.dataGridView2.TabIndex = 1;
            // 
            // القروضToolStripMenuItem
            // 
            this.القروضToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.البحثفيالقروضToolStripMenuItem,
            this.إضافةقرضToolStripMenuItem,
            this.تعديلقرضToolStripMenuItem});
            this.القروضToolStripMenuItem.Name = "القروضToolStripMenuItem";
            this.القروضToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.القروضToolStripMenuItem.Text = "إدارة القروض";
            // 
            // إضافةتعديلالسلعToolStripMenuItem
            // 
            this.إضافةتعديلالسلعToolStripMenuItem.Name = "إضافةتعديلالسلعToolStripMenuItem";
            this.إضافةتعديلالسلعToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.إضافةتعديلالسلعToolStripMenuItem.Text = "إضافة السلع";
            // 
            // إضافةقرضToolStripMenuItem
            // 
            this.إضافةقرضToolStripMenuItem.Name = "إضافةقرضToolStripMenuItem";
            this.إضافةقرضToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.إضافةقرضToolStripMenuItem.Text = "إضافة قرض";
            // 
            // تعديلقرضToolStripMenuItem
            // 
            this.تعديلقرضToolStripMenuItem.Name = "تعديلقرضToolStripMenuItem";
            this.تعديلقرضToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.تعديلقرضToolStripMenuItem.Text = "تعديل قرض";
            // 
            // تعديلالسلعToolStripMenuItem
            // 
            this.تعديلالسلعToolStripMenuItem.Name = "تعديلالسلعToolStripMenuItem";
            this.تعديلالسلعToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.تعديلالسلعToolStripMenuItem.Text = "تعديل السلع";
            // 
            // البحثToolStripMenuItem
            // 
            this.البحثToolStripMenuItem.Name = "البحثToolStripMenuItem";
            this.البحثToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.البحثToolStripMenuItem.Text = "إظهار السلع";
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
            // إضافةفاتورةToolStripMenuItem
            // 
            this.إضافةفاتورةToolStripMenuItem.Name = "إضافةفاتورةToolStripMenuItem";
            this.إضافةفاتورةToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.إضافةفاتورةToolStripMenuItem.Text = "إضافة بيع";
            // 
            // جميعالمبيعاتToolStripMenuItem
            // 
            this.جميعالمبيعاتToolStripMenuItem.Name = "جميعالمبيعاتToolStripMenuItem";
            this.جميعالمبيعاتToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.جميعالمبيعاتToolStripMenuItem.Text = "جميع المبيعات";
            // 
            // البحثفيالقروضToolStripMenuItem
            // 
            this.البحثفيالقروضToolStripMenuItem.Name = "البحثفيالقروضToolStripMenuItem";
            this.البحثفيالقروضToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.البحثفيالقروضToolStripMenuItem.Text = "إظهار القروض";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 492);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_PrdPrsqFini);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_PrdFini);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_nbrPrdStk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "إدارة المبيعات";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem إضافةتعديلالسلعToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تعديلالسلعToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem البحثToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem القروضToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem إضافةقرضToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تعديلقرضToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem إضافةفاتورةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem جميعالمبيعاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem البحثفيالقروضToolStripMenuItem;
    }
}

