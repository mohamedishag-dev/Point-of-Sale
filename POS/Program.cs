using Microsoft.Extensions.DependencyInjection;
using POS.Controls;
using POS.Forms;
using POS.Products;
using POS.Purchases;
using POS.Settings;
using POS.Suppliers;
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
            services.AddTransient<frmMain>();
            services.AddTransient<frmSale>();
            services.AddTransient<frmSettings>();
            services.AddTransient<frmListUsers>();
            services.AddTransient<frmLisPurchases>();
            services.AddTransient<frmListProducts>();
            services.AddTransient<frmListSupplier>();
            ServiceProvider = services.BuildServiceProvider();

            var MainForm = ServiceProvider.GetRequiredService<frmMain>();
            Application.Run(MainForm);

        }

    }

}