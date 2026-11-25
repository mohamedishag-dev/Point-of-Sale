using Microsoft.Extensions.DependencyInjection;
using POS.Forms;
using POS.Login;
using POS.Products;
using POS.Purchases;
using POS.Settings;
using POS.Stock_Movements;
using POS.Suppliers;
using POS.Users;
using POS_Business;
using System;
using System.Windows.Forms;
namespace POS
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            DependencyInjection.AddBusiness(services);
            services.AddTransient<frmAddProduct>();
            services.AddTransient<frmAddUpdateUser>();
            services.AddTransient<frmChangePassword>();

            services.AddTransient<frmMain>();
            services.AddTransient<frmSale>();
            services.AddTransient<frmLogin>();
            services.AddTransient<frmSettings>();
            services.AddTransient<frmListStock>();
            services.AddTransient<frmListUsers>();
            services.AddTransient<frmAddCategory>();
            services.AddTransient<frmLisPurchases>();
            services.AddTransient<frmListProducts>();
            services.AddTransient<frmListSupplier>();
            ServiceProvider = services.BuildServiceProvider();

            using (var login = ServiceProvider.GetRequiredService<frmLogin>())
            {
                if (login.ShowDialog() != DialogResult.OK) return;
            }

            var MainForm = ServiceProvider.GetRequiredService<frmMain>();
            MainForm.ShowDialog();

        }

    }

}