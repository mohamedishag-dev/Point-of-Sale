using POS_Business.interfaceis;
using POS_Business.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Suppliers
{
    public partial class frmListSupplier : Form
    {
        private readonly ISupplierService _supplierService;
        private DataTable _dtAllSuppliers;

        public frmListSupplier(ISupplierService supplierService)
        {
            InitializeComponent();
            _supplierService = supplierService;
       
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هذه الميزة لم يتم تنفيذها بعد!", "غير جاهزة!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void frmListSupplier_Load(object sender, EventArgs e)
        {
            dgvSuppliers.RowTemplate.Height = 35;
            _dtAllSuppliers = _supplierService.GetAllSuppliers();
            dgvSuppliers.DataSource = _dtAllSuppliers;
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = (cbFilterBy.Text != "لا شي");
            lblRecordsCount.Text = dgvSuppliers.Rows.Count.ToString();


            if (dgvSuppliers.Rows.Count > 0)
            {
                dgvSuppliers.Columns[0].HeaderText = "المعرف";
                dgvSuppliers.Columns[0].Width = 50;

                dgvSuppliers.Columns[1].HeaderText = "الاسم المورد";
                dgvSuppliers.Columns[1].Width = 130;

                dgvSuppliers.Columns[2].HeaderText = "رقم الهاتق";
                dgvSuppliers.Columns[2].Width = 70;

                dgvSuppliers.Columns[3].HeaderText = "البريد الالكتروني";
                dgvSuppliers.Columns[3].Width = 130;

                dgvSuppliers.Columns[4].HeaderText = "المدينة";
                dgvSuppliers.Columns[4].Width = 50;

                dgvSuppliers.Columns[5].HeaderText = "العنوان";
                dgvSuppliers.Columns[5].Width = 130;

                dgvSuppliers.Columns[6].HeaderText = "المبلغ المتبقي";
                dgvSuppliers.Columns[6].Width = 150;

            }
        }


    }
}
