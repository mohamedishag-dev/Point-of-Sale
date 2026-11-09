using Microsoft.Extensions.DependencyInjection;
using POS.Controls;
using POS.Forms;
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
            services.AddTransient<frmListUsers>();
            services.AddTransient<frmListSupplier>();
            ServiceProvider = services.BuildServiceProvider();

            var MainForm = ServiceProvider.GetRequiredService<frmMain>();
            Application.Run(MainForm);

        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<frmMain>();
            services.AddTransient<frmListSupplier>();
            // services.AddTransient<frmAddEditSupplier>();
            // services.AddTransient<frmListCustomer>();

            // الخدمات (مثال)
            // services.AddScoped<ISupplierService, SupplierService>();
            // services.AddDbContext<AppDbContext>();
        }

    }


}