using Microsoft.Extensions.DependencyInjection;
using POS_Business.Services;
using POS_Business.Servicies;
using System;
using System.Data;
using System.Windows.Forms;

namespace POS.Products
{
    public partial class frmListProducts : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private DataTable _dtAllProducts;

        public frmListProducts(IProductService productService, ICategoryService categoryService)
        {
            InitializeComponent();
            _productService = productService;
            _categoryService = categoryService;
        }

        private void frmListProducts_Load(object sender, EventArgs e)
        {
            _dtAllProducts = _productService.GetAllProducts();
            cbFilterBy.SelectedIndex = 0;
            dgvProducts.RowTemplate.Height = 35;
            dgvProducts.DataSource = _dtAllProducts;
            dgvProducts.Columns.RemoveAt(0);

            _FillCategoriesAndUnits();

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

        private void _FillCategoriesAndUnits()
        {
            dgvUnits.RowTemplate.Height = 30;
            dgvUnits.DataSource = _categoryService.GetAllUnits();
            if (dgvUnits.Rows.Count > 0)
            {

                dgvUnits.Columns[0].HeaderText = "الرقم";
                dgvUnits.Columns[0].Width = 20;

                dgvUnits.Columns[1].HeaderText = "اسم الوحدة";
                dgvUnits.Columns[1].Width = 80;

            }

            dgvCategories.RowTemplate.Height = 30;
            dgvCategories.DataSource = _categoryService.GetAllCategories();
            if (dgvCategories.Rows.Count > 0)
            {

                dgvCategories.Columns[0].HeaderText = "الرقم";
                dgvCategories.Columns[0].Width = 20;

                dgvCategories.Columns[1].HeaderText = "اسم القسم";
                dgvCategories.Columns[1].Width = 50;

                dgvCategories.Columns[2].HeaderText = "الحالة";
                dgvCategories.Columns[2].Width = 40;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Focus();
            txtFilterValue.Text = "";
            _dtAllProducts.DefaultView.RowFilter = "";
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {

            var frm = POS.Program.ServiceProvider.GetRequiredService<frmAddProduct>();
            frm.ShowDialog();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var frm = POS.Program.ServiceProvider.GetRequiredService<frmAddCategory>();
            frm.ShowDialog();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = POS.Program.ServiceProvider.GetRequiredService<frmAddCategory>();
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
