using Microsoft.Extensions.DependencyInjection;
using POS.Forms;
using POS.Products;
using POS.Suppliers;
using POS_Business.interfaceis;
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
            var frm = POS.Program.ServiceProvider.GetRequiredService<frmListUsers>();
            frm.ShowDialog();

        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            frmSale frm = new frmSale();
            frm.ShowDialog();

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            frmListProducts frm = new frmListProducts();
            frm.ShowDialog();

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هذه الميزة لم يتم تنفيذها بعد!", "غير جاهزة!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnSuppliers_Click(object sender, EventArgs e)    
        {

            var frm = POS.Program.ServiceProvider.GetRequiredService<frmListSupplier>();
            frm.ShowDialog(); 

        }

        private void btnReturns_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هذه الميزة لم يتم تنفيذها بعد!", "غير جاهزة!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هذه الميزة لم يتم تنفيذها بعد!", "غير جاهزة!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هذه الميزة لم يتم تنفيذها بعد!", "غير جاهزة!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هذه الميزة لم يتم تنفيذها بعد!", "غير جاهزة!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
    }
}
