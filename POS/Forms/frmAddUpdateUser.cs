using POS.Properties;
using POS_Business.DTOs.Users;
using POS_Business.Services;
using POS_DataAccess.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class frmAddUpdateUser : Form
    {
        private UserService _userService = new UserService();
        public enum enMode { AddNew = 0, Update = 1 };
        private UserDto _createUserDto;
        private int _userID = -1;
        private enMode _Mode;

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateUser(int userID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _userID = userID;
        }


        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            llRemoveImage.Visible = false;

            //     اضافة مستخدم جديد
        }

        private void _LoadData()
        {

            UserDto userDto = _userService.GetUserById(_userID);

            if (userDto == null)
            {
                MessageBox.Show("No User with ID = " + _userID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the user was not found
            lblUserID.Text = _userID.ToString();
            txtFullName.Text = userDto.FullName;
            txtAddress.Text = userDto.Address;
            txtPhone.Text = userDto.Phone;
            txtEmail.Text = userDto.Email;
            // cbCountry.SelectedIndex = cbCountry.FindString(_Person.countryInfo.CountryName);


            //load user image incase it was set.
            if (userDto.ImagePath != string.Empty)
                pbPersonImage.ImageLocation = userDto.ImagePath;


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
            //MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //return;


            if (!this.ValidateChildren())
            {
                //Here we don't continue becuase the from is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CreateUserDto createUserDto = new CreateUserDto();
            createUserDto.FullName = txtFullName.Text.Trim();
            createUserDto.Username = txtUserName.Text.Trim();
            createUserDto.PasswordHash = txtPassword.Text.Trim();
            createUserDto.Phone = txtPhone.Text.Trim();
            createUserDto.Email = txtEmail.Text.Trim();
            createUserDto.Address = txtAddress.Text.Trim();
            createUserDto.ImagePath = txtUserName.Text.Trim();

            createUserDto.IsActive = checkbIsActive.Checked;
            createUserDto.RoleID = 2;
           
            if (_userService.AddNewUser(ref createUserDto))
            {
                lblUserID.Text = createUserDto.UserID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "تعديل مستخدم";
                MessageBox.Show("تم حفظ البيانات بنجاح.", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("خطأ: لم يتم حفظ البيانات بنجاح.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void llOpenFileDialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
                // ...
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
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
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
                errorProvider1.SetError(Temp, "This field is required!");
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
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
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
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }

        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llRemoveImage.Visible = false;
            pbPersonImage.ImageLocation = null;
            pbPersonImage.Image = Resources.Male_512;

        }
    }
}
