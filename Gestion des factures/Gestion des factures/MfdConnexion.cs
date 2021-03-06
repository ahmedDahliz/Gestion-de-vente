﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Transactions;
namespace Gestion_des_factures
{
    public partial class MfdConnexion : Form
    {
        public MfdConnexion()
        {
            InitializeComponent();
        }
        
        SQLiteDataAdapter dta = new SQLiteDataAdapter("select * from Users", Acceuil.cnx);
        DataSet ds = new DataSet();
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nomU.Text != "")
                {

                    if (txt_pwN.Text.Equals(txt_psCN.Text))
                    {
                        if (ds.Tables["users"].Rows[0]["password"].ToString() == txt_psO.Text)
                        {
                            using (TransactionScope trans = new TransactionScope())
                            {
                                ds.Tables["users"].Rows[0].BeginEdit();
                                ds.Tables["users"].Rows[0]["username"] = txt_nomU.Text;
                                ds.Tables["users"].Rows[0]["password"] = txt_psCN.Text;
                                ds.Tables["users"].Rows[0].EndEdit();
                                Acceuil.cnx.Open();
                                SQLiteCommandBuilder cmdb = new SQLiteCommandBuilder(dta);
                                dta.Update(ds, "users");
                                Acceuil.cnx.Close();
                                MessageBox.Show("نم تغيير المعلومات بنجاح", "تعديل المعلومات ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                            }
                        }
                        else MessageBox.Show("كلمة السر الحالية غير صحيحة", "كلمة السر الحالية", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    }
                    else MessageBox.Show("كلمتا السر غير متطابقتان", "تأكيد كلمة السر", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                }
                else MessageBox.Show("المرجوا إدخال إسم المستخدم", "إسم المستخدم فارغ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

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
            Close();
        }

        private void MfdConnexion_Load(object sender, EventArgs e)
        {
            try
            {
                dta.Fill(ds, "users");
                txt_nomU.Text = ds.Tables["users"].Rows[0]["username"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }
    }
}
