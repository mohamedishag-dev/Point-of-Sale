using POS.Helpers;
using POS_Business.Security;
using POS_Business.Security.Products;
using POS_Business.Security.Users;
using POS_Business.Services;
using POS_Business.Servicies;
using POS_Business.Validations;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace POS.Products
{
    public partial class frmAddProduct : Form
    {
        private int productID = -1;
        private ProductDto _product;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public frmAddProduct(IProductService productService, ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _productService = productService;
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            txtCreatedAt.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            if (Session.CurrentUser != null)
            {
                txtCreatedBy.Text = Session.CurrentUser.Username + " (" + Session.CurrentUser.Role.RoleName + ")";
            }

            _FillUnitsInComoboBox();
            _FillCategoriesInComoboBox();
            cbUnits.SelectedIndex = 0;
            cbCategories.SelectedIndex = 0;
            btnRemoveImage.Visible = false;
            MessageBox.Show("مطلوب (SKU) كود الصنف");
        }

        private void _FillUnitsInComoboBox()
        {
            DataTable dtRoles = _categoryService.GetAllUnits();

            foreach (DataRow row in dtRoles.Rows)
            {
                cbUnits.Items.Add(row["UnitName"]);
            }

        }
        private void _FillCategoriesInComoboBox()
        {
            DataTable dtRoles = _categoryService.GetAllCategories();

            foreach (DataRow row in dtRoles.Rows)
            {
                cbCategories.Items.Add(row["CategoryName"]);
            }

        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "ملفات الصور|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbProductImage.Load(selectedFilePath);
                btnRemoveImage.Visible = true;
                // ...
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            btnRemoveImage.Visible = false;
            pbProductImage.ImageLocation = null;
            pbProductImage.Image = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _HandleProductImage()
        {

            //this procedure will handle the product image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_product.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_product.ImagePath != pbProductImage.ImageLocation)
            {
                if (_product.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_product.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pbProductImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbProductImage.ImageLocation.ToString();

                    if (Util.CopyProductImage(ref SourceImageFile))
                    {
                        pbProductImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _product = new ProductDto();

            if (!_HandleProductImage())
                return;


            _product.ProductName = txtProductName.Text;
            _product.SKU = txtKSU.Text;
            _product.Barcode = txtBarcode.Text;
            _product.Description = txtDescription.Text;
            _product.Price = Convert.ToDecimal(txtPrice.Text);
            _product.UnitID = _categoryService.GetByUnitName(cbUnits.Text).UnitID;
            _product.CategoryID = _categoryService.GetByCategoryName(cbCategories.Text).CategoryID;

            try
            {
                bool success = _productService.AddProduct(_product);

                if (success)
                {
                    btnSave.Enabled = false;
                    MessageBox.Show("تم حفظ البيانات بنجاح.", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("خطأ: لم يتم حفظ البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (ValidationException ex)
            {
                MessageBox.Show(string.Join("\n", ex.Errors), "خطأ في البيانات");
            }


        }
    }
}
