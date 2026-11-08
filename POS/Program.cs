using Microsoft.Extensions.DependencyInjection;
using POS.Controls;
using POS.Forms;
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
            ServiceProvider = services.BuildServiceProvider();

            var MainForm = ServiceProvider.GetRequiredService<frmMain>();
            Application.Run(MainForm);









            //   Application.Run(new frmSale());
            //  Application.Run(new frmListProducts());

        }

    }


}