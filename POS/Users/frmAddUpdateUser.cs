using POS.Properties;
using POS_Business.DTOs.Users;
using POS_Business.Services;
using POS_Business.Validations;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class frmAddUpdateUser : Form
    {
        private readonly IUserService _userService;
        public enum enMode { AddNew = 0, Update = 1 };
        public int UserID = -1;
        public enMode Mode;

        public frmAddUpdateUser(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            Mode = enMode.AddNew;
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            llRemoveImage.Visible = false;

            if (Mode == enMode.Update)
                _LoadData();

        }

        private void _LoadData()
        {

            UserDto userDto = _userService.GetUserByID(UserID);

            if (userDto == null)
            {
                MessageBox.Show("لا يوجد مستخدم بالرقم = " + UserID, "المستخدم غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the user was not found
            txtFullName.Text = userDto.FullName;
            txtUserName.Text = userDto.Username;
            txtPhone.Text = userDto.Phone;
            txtEmail.Text = userDto.Email;
            txtAddress.Text = userDto.Address;
            txtEmail.Text = userDto.Email;
            checkbIsActive.Checked = userDto.IsActive;

            //load user image incase it was set.
            if (userDto.ImagePath != string.Empty)
                circlepbUserImage.ImageLocation = userDto.ImagePath;


            //hide/show the remove linke incase there is no image for the user.
            llRemoveImage.Visible = (userDto.ImagePath != "");

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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

            CreateUserDto createUserDto = new CreateUserDto
            {
                FullName = txtFullName.Text.Trim(),
                Username = txtUserName.Text.Trim(),
                Password = txtPassword.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                Address = txtAddress.Text.Trim(),
                ImagePath = circlepbUserImage.ImageLocation,
                IsActive = checkbIsActive.Checked,
                RoleID = 2
            };

            bool success = false;

            success = _userService.AddUser(createUserDto);

            try
            {
                success = _userService.AddUser(createUserDto);
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

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            //no need to validate the email incase it's empty.
            if (txtEmail.Text.Trim() == "")
                return;

            //validate email format
            if (!Validatoin.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "صيغة البريد الإلكتروني غير صحيحة!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }

        }

        private void ValidateEmptyTestBox(object sender, CancelEventArgs e)
        {

            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "هذا الحقل مطلوب!");
            }
            else
            {
                errorProvider1.SetError(Temp, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "كلمة المرور لا يمكن أن تكون فارغة");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {

            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "تأكيد كلمة المرور لا يطابق كلمة المرور!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }

        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llRemoveImage.Visible = false;
            circlepbUserImage.ImageLocation = null;
            circlepbUserImage.Image = Resources.Male_512;

        }

        private void llOpenFileDialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "ملفات الصور|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                circlepbUserImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
                // ...
            }

        }

      
    }
}
