using POS_Business.Interfaces;
using System;
using System.Data;
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

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هذه الميزة لم يتم تنفيذها بعد!", "غير جاهزة!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void frmListSupplier_Load(object sender, EventArgs e)
        {
            _dtAllSuppliers = _supplierService.GetAllSuppliers();
            dgvSuppliers.DataSource = _dtAllSuppliers;
            dgvSuppliers.RowTemplate.Height = 35;

            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = (cbFilterBy.Text != "لا شي");
            lblRecordsCount.Text = dgvSuppliers.Rows.Count.ToString();


            if (dgvSuppliers.Rows.Count > 0)
            {
                dgvSuppliers.Columns[0].HeaderText = "المعرف";
                dgvSuppliers.Columns[0].Width = 60;

                dgvSuppliers.Columns[1].HeaderText = "الاسم المورد";
                dgvSuppliers.Columns[1].Width = 130;

                dgvSuppliers.Columns[2].HeaderText = "رقم الهاتق";
                dgvSuppliers.Columns[2].Width = 60;

                dgvSuppliers.Columns[3].HeaderText = "البريد الالكتروني";
                dgvSuppliers.Columns[3].Width = 130;

                dgvSuppliers.Columns[4].HeaderText = "المدينة";
                dgvSuppliers.Columns[4].Width = 40;

                dgvSuppliers.Columns[5].HeaderText = "العنوان";
                dgvSuppliers.Columns[5].Width = 100;

                dgvSuppliers.Columns[6].HeaderText = "المبلغ المتبقي";
                dgvSuppliers.Columns[6].Width = 100;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "لا شي");
            txtFilterValue.Text = "";
            txtFilterValue.Focus();

            _dtAllSuppliers.DefaultView.RowFilter = "";
            lblRecordsCount.Text = dgvSuppliers.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "المعرف":
                    FilterColumn = "SupplierID";
                    break;

                case "الاسم المورد":
                    FilterColumn = "SupplierName";
                    break;

                case "الهاتق":
                    FilterColumn = "Phone";
                    break;
               
                case "الايميل":
                    FilterColumn = "Email";
                    break;
              
                case "المدينة":
                    FilterColumn = "City";
                    break;

                default:
                    FilterColumn = "لا شي";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "لا شي")
            {
                _dtAllSuppliers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvSuppliers.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "SupplierID")
                //     in this case we deal with integer not string.
                _dtAllSuppliers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllSuppliers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvSuppliers.Rows.Count.ToString();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase supplier id is selected.
            if (cbFilterBy.Text == "المعرف")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
