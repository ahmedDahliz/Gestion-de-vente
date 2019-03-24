using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Gestion_des_factures
{
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }
        private Acceuil FrmAcc;
        public void ConnexionShow(Acceuil Acc)
        {
            this.Show();
            FrmAcc = Acc;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Connexion_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Connexion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand("select * from Users where username = '" + txt_username.Text.Trim() + "' and password = '" + txt_password.Text + "'", Acceuil.cnx);
                Acceuil.cnx.Open();
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (FrmAcc == null)
                    {
                        Acceuil ac = new Acceuil(this);
                        ac.Show();

                    }
                    else FrmAcc.Show();
                    txt_password.Text = "";
                    Hide();
                }
                else MessageBox.Show("إسم الدخول أو كلمة المرور خاطئة", "المعلومات خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                Acceuil.cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ أثناء العملية المرجوا إعادة المحاولة");
                string Err = "[" + DateTime.Now + "] [Exception] __ [Form :" + this.Name + " ; Button: " + sender.ToString() + " ; Event: " + e.ToString() + "] __ ExceptionMessage : " + ex.Message;
                Acceuil.WriteLog(Err);
            }
        }

        private void Connexion_FormClosing(object sender, FormClosingEventArgs e)
        {   
            Application.Exit();
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) button1.PerformClick();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
