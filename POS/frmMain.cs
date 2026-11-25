using Microsoft.Extensions.DependencyInjection;
using POS.Forms;
using POS.Products;
using POS.Purchases;
using POS.Settings;
using POS.Stock_Movements;
using POS.Suppliers;
using POS_Business.Security;
using POS_Business.Services;
using System;
using System.Windows.Forms;
namespace POS
{
    public partial class frmMain : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public frmMain(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Session.Has(Perm.UsersView);
            var frm = _serviceProvider.GetRequiredService<frmListUsers>();
            frm.ShowDialog();
        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<frmSale>();
            frm.ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<frmListProducts>();
            frm.ShowDialog();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<frmListSupplier>();
            frm.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<frmSettings>();
            frm.ShowDialog();
        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<frmLisPurchases>();
            frm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.End();
            Application.Restart();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Session.CurrentUser != null)
            {
                lblUser.Text = Session.CurrentUser.Username;

                btnCashier.Visible = Session.Has(Perm.UsersView);
                btnProducts.Visible = Session.Has(Perm.ProductsView);
                btnSuppliers.Visible = Session.Has(Perm.SuppliersView);
                btnReturns.Visible = Session.Has(Perm.ReportsSales);
                btnInventory.Visible = Session.Has(Perm.InventoryView);
                btnReports.Visible = Session.Has(Perm.ReportsSales);
                btnUsers.Visible = Session.Has(Perm.UsersView);
                btnPurchases.Visible = Session.Has(Perm.PurchasesReceive);
                btnSettings.Visible = Session.Has(Perm.SettingsManage);
                btnCashier.Visible = Session.Has(Perm.SalesCreate);

            }
        }


        private void btnInventory_Click(object sender, EventArgs e)
        {

            var frm = _serviceProvider.GetRequiredService<frmListStock>();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هذه الميزة لم يتم تنفيذها بعد!", "غير جاهزة!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        private void btnReturns_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هذه الميزة لم يتم تنفيذها بعد!", "غير جاهزة!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnReports_Click(object sender, EventArgs e)
        {

            MessageBox.Show("هذه الميزة لم يتم تنفيذها بعد!", "غير جاهزة!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

      

   
    }

}
