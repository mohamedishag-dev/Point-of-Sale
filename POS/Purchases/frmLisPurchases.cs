using POS_Business.Interfaces;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace POS.Purchases
{
    public partial class frmLisPurchases : Form
    {
        private readonly IPurchaseService _purchaseService;
        private DataTable _dtAllPurchases;

        public frmLisPurchases(IPurchaseService purchaseService)
        {
            InitializeComponent();
            _purchaseService = purchaseService;
        }

        private void frmLisPurchases_Load(object sender, EventArgs e)
        {

            _dtAllPurchases = _purchaseService.GetAllPurchases();
            dgvPurchases.DataSource = _dtAllPurchases;
            dgvPurchases.RowTemplate.Height = 35;

            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = (cbFilterBy.Text != "لا شي");
            lblRecordsCount.Text = dgvPurchases.Rows.Count.ToString();


            if (dgvPurchases.Rows.Count > 0)
            {
                dgvPurchases.Columns[0].HeaderText = "رقم الفاتورة";
                dgvPurchases.Columns[0].Width = 60;

                dgvPurchases.Columns[1].HeaderText = "الاسم المورد";
                dgvPurchases.Columns[1].Width = 150;

                dgvPurchases.Columns[2].HeaderText = "اسم المستخدم";
                dgvPurchases.Columns[2].Width = 70;

                dgvPurchases.Columns[3].HeaderText = "تاريخ العملية";
                dgvPurchases.Columns[3].Width = 80;

                dgvPurchases.Columns[4].HeaderText = "المبلغ المدفوع";
                dgvPurchases.Columns[4].Width = 100;

                dgvPurchases.Columns[5].HeaderText = "إجمالي الفاتورة";
                dgvPurchases.Columns[5].Width = 100;

                dgvPurchases.Columns[6].HeaderText = "المبلغ المتبقي";
                dgvPurchases.Columns[6].Width = 100;

                dgvPurchases.Columns[7].HeaderText = "حالة العملية";
                dgvPurchases.Columns[7].Width = 100;

            }

            dtpFrom.Value = DateTime.Now.AddDays(-7);
            dtpTo.Value = DateTime.Now;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FiltterFordate_ValueChanged(object sender, EventArgs e)
        {

            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date.AddDays(1);

            string from = fromDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            string to = toDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            _dtAllPurchases.DefaultView.RowFilter =
                "[PurchaseDate] >= #" + from + "# AND [PurchaseDate] < #" + to + "#";


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _dtAllPurchases = _purchaseService.GetAllPurchases();
            dgvPurchases.DataSource = _dtAllPurchases;
            FiltterFordate_ValueChanged(null, null);
            lblRecordsCount.Text = dgvPurchases.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "حالة العملية")
            {
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
                txtFilterValue.Visible = false;
                return;
            }
            else
            {

                cbIsActive.Visible = false;
                txtFilterValue.Visible = (cbFilterBy.Text != "لا شي");
                txtFilterValue.Text = "";
                txtFilterValue.Focus();

                _dtAllPurchases.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvPurchases.Rows.Count.ToString();

            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "Status";
            string FilterValue = cbIsActive.Text;

            if (FilterValue == "الكل")
                _dtAllPurchases.DefaultView.RowFilter = "";
            else
                _dtAllPurchases.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, FilterValue);

            lblRecordsCount.Text = dgvPurchases.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase purchase id is selected.
            if (cbFilterBy.Text == "رقم الفاتورة")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "رقم الفاتورة":
                    FilterColumn = "PurchaseID";
                    break;

                case "الاسم المورد":
                    FilterColumn = "SupplierName";
                    break;

                case "اسم المستخدم":
                    FilterColumn = "Username";
                    break;

                default:
                    FilterColumn = "لا شي";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "لا شي")
            {
                _dtAllPurchases.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvPurchases.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PurchaseID")
                //     in this case we deal with integer not string.
                _dtAllPurchases.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllPurchases.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvPurchases.Rows.Count.ToString();
        }
    }
}
