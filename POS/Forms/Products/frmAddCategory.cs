using POS_Business.DTOs.Products;
using POS_Business.Servicies;
using POS_Business.Validations;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace POS.Products
{
    public partial class frmAddCategory : Form
    {
        private readonly ICategoryService _categoryService;
        public frmAddCategory(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("بعض الحقول غير صالحة! ضع مؤشر الفأرة فوق الأيقونة الحمراء",
                    "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                CategoryDto categoryDto = new CategoryDto
                {
                    CategoryName = txtName.Text,
                    Description = txtDescription.Text
                };

                bool success = _categoryService.AddCategory(categoryDto);

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

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtName, "هذا الحقل مطلوب!");
            }
            else
            {
                errorProvider1.SetError(txtName, null);
            }
        }
    }
}
