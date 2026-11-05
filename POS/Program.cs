using POS.Controls;
using POS.Forms;
using POS.Products;
using System;
using System.Windows.Forms;

namespace POS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
//            Application.Run(new frmMain());
         //   Application.Run(new frmSale());
            Application.Run(new frmListProducts());

        }

    }


}

