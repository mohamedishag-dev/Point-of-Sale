using POS_Business.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace POS.Products
{
    public partial class frmListProducts : Form
    {
        private readonly ProductService _productService = new ProductService();
        private DataTable _dtAllProducts;

        public frmListProducts()
        {
            InitializeComponent();
        }

        private void frmListProducts_Load(object sender, EventArgs e)
        {

            _dtAllProducts = _productService.GetAllProducts();
            cbFilterBy.SelectedIndex = 0;
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

    }
}
