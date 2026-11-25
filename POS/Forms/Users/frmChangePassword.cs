using POS_Business.Security.Users;
using POS_Business.Services;
using POS_Business.Validations;
using System;
using System.Windows.Forms;

namespace POS.Users
{
    public partial class frmChangePassword : Form
    {
        private UserDto _UserDto;
        public int UserID = -1;
        private IUserService _userService;

        public frmChangePassword(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void frmChangePassword2_Load(object sender, EventArgs e)
        {

            _UserDto = _userService.GetUserByID(UserID);
            if (_UserDto == null)
            {
                this.UserID = -1;
                ResetUserInfo();
                MessageBox.Show("لا يوجد مستخدم برقم المستخدم = " + _UserDto.UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                _FillUserInfo();

        }

        private void _FillUserInfo()
        {
            UserID = _UserDto.UserID;
            lblUserID.Text = _UserDto.UserID.ToString();
            lblFullName.Text = _UserDto.FullName;
            lblUsername.Text = _UserDto.Username;
            lblPhone.Text = _UserDto.Phone;
            lblEmail.Text = _UserDto.Email;

            lblAddress.Text = _UserDto.Address;
            lblRoleName.Text = _UserDto.Role.RoleName;
            // _LoadPresonImage();

        }

        public void ResetUserInfo()
        {
            UserID = -1;
            lblUserID.Text = "N/A";
            lblFullName.Text = "[????]";
            lblUsername.Text = "[????]";
            lblPhone.Text = "[????]";
            lblEmail.Text = "[????]";
            lblAddress.Text = "[????]";
            lblRoleName.Text = "[????]";

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


            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("كلمة المرور ولا تمطابق حاول مجددا",
                   "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool success = _userService.ChangePassword(UserID, txtCrruentPassword.Text, txtNewPassword.Text);

                if (success)
                {
                    btnSave.Enabled = false;
                    MessageBox.Show("تم حفظ كلمة المرور بنجاح.", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("خطأ: لم يتم حفظ البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (ValidationException ex)
            {
                MessageBox.Show(string.Join("\n", ex.Errors), "خطأ في البيانات");
            }
        }

        private void txtCrruentPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCrruentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCrruentPassword, "كلمة المرور لا يمكن أن تكون فارغة");
            }
            else
                errorProvider1.SetError(txtCrruentPassword, null);

        }

        private void txtNewPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "كلمة المرور لا يمكن أن تكون فارغة");
            }
            else
                errorProvider1.SetError(txtNewPassword, null);

        }

        private void txtConfirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "كلمة المرور لا يمكن أن تكون فارغة");
            }
            else
                errorProvider1.SetError(txtConfirmPassword, null);
        }
    }
}
