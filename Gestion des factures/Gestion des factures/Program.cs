using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Gestion_des_factures
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            String thisprocessname = Process.GetCurrentProcess().ProcessName;

            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
            {
                MessageBox.Show("لايمكن تشغيل البرنامج, فهو قيد الشغيل", "البرنامج مشغل", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                return;
            }
            MessageBoxManager.OK = "حسنا";
            MessageBoxManager.Yes = "نعم";
            MessageBoxManager.No = "لا";
            MessageBoxManager.Register();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Acceuil());
        }
    }
}
