using POS_Business.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class frmSale : Form
    {
        private decimal subtotal = 0.00m;
        private const decimal taxRate = 0.08m;

        private readonly ProductService _productService = new ProductService();
        private DataTable _dtAllProducts;


        public frmSale()
        {
            InitializeComponent();

        }

        private void frmSale_Load(object sender, EventArgs e)
        {

            _dtAllProducts = _productService.GetAllProducts();
            cbFilterBy.SelectedIndex = 0;
            dgvCart.RowTemplate.Height = 30;
            dgvProducts.RowTemplate.Height = 35;

            dgvProducts.DataSource = _dtAllProducts;
            dgvProducts.Columns.RemoveAt(0);

            if (dgvProducts.Rows.Count > 0)
            {
                dgvProducts.Columns[0].Width = 70;

                dgvProducts.Columns[1].Width = 120;

                dgvProducts.Columns[2].HeaderText = "اسم المنتج";
                dgvProducts.Columns[2].Width = 150;

                dgvProducts.Columns[3].HeaderText = "السعر";
                dgvProducts.Columns[3].Width = 60;

                dgvProducts.Columns[4].HeaderText = "الوحدة";
                dgvProducts.Columns[4].Width = 50;

                dgvProducts.Columns[5].HeaderText = "الكمية المتاحة";
                dgvProducts.Columns[5].Width = 80;


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("السلة فارغة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("تم إتمام عملية الدفع بنجاح! شكراً لك.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvCart.Rows.Clear();
            CalculateTotals();
        }

        private void AddToCart(string productName, decimal price)
        {
            // التحقق مما إذا كان المنتج موجوداً مسبقاً في السلة لزيادة الكمية
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["ColProductName"].Value.ToString() == productName)
                {
                    int qty = Convert.ToInt32(row.Cells["ColQuantity"].Value) + 1;
                    row.Cells["ColQuantity"].Value = qty;
                    CalculateTotals();
                    return;
                }
            }

            // إذا لم يكن موجوداً، أضفه كصف جديد
            dgvCart.Rows.Add(productName, 1, price.ToString("F2"), price.ToString("F2"));
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            subtotal = 0.00m;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                int qty = Convert.ToInt32(row.Cells["colQuantity"].Value);
                decimal price = Convert.ToDecimal(row.Cells["ColCost"].Value);
                subtotal += (qty * price);
            }

            decimal tax = subtotal * taxRate;
            decimal total = subtotal + tax;

            lblSubtotal.Text = $"المجموع الفرعي: ${subtotal:F2}";
            lblTax.Text = $"الضريبة (8%): ${tax:F2}";
            lblTotal.Text = $"الإجمالي الكلي: ${total:F2}";
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvCart.Rows[e.RowIndex];
            decimal qty = Convert.ToDecimal(row.Cells["ColQuantity"].Value);
            decimal unitPrice = Convert.ToDecimal(row.Cells["ColCost"].Value);

            switch (dgvCart.Columns[e.ColumnIndex].Name)
            {
                case "ColPlus": qty++; break;
                case "ColMinus": qty--; break;
                case "Coldel":
                    if (MessageBox.Show("Are you delete is product", "", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                        qty = 0; break;
                default: return;
            }

            if (qty <= 0)
                dgvCart.Rows.RemoveAt(e.RowIndex);
            else
            {
                row.Cells["ColQuantity"].Value = qty;
                row.Cells["ColPrice"].Value = qty * unitPrice;
            }

            CalculateTotals();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Focus();
            txtFilterValue.Text = "";
            _dtAllProducts.DefaultView.RowFilter = "";

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase لاarcode is selected.
            if (cbFilterBy.Text == "Barcode")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "SKU":
                    FilterColumn = "SKU";
                    break;

                case "Barcode":
                    FilterColumn = "Barcode";
                    break;
                case "اسم المنتج":
                    FilterColumn = "ProductName";
                    break;

                default:
                    FilterColumn = "SKU";
                    break;

            }

            _dtAllProducts.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

        }

        private void dgvProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string productName = (string)dgvProducts.CurrentRow.Cells[2].Value;
            decimal price = (decimal)dgvProducts.CurrentRow.Cells[3].Value;
            AddToCart(productName, price);

        }

    }
}
